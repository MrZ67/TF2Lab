using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TF2Logic;

namespace TF2WinForms
{
    public partial class Form1 : Form
    {
        private Logic logic = new Logic();

        public Form1()
        {
            InitializeComponent();

            gridMercs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridMercs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMercs.MultiSelect = false;
            gridMercs.AllowUserToAddRows = false;

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            gridMercs.DataSource = null;
            gridMercs.DataSource = logic.ReadAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Введи имя бойца!");
                    return;
                }

                if (txtRole.Text == "")
                {
                    MessageBox.Show("Введи роль бойца!");
                    return;
                }

                int hp;
                if (int.TryParse(txtHP.Text, out hp) == false)
                {
                    MessageBox.Show("HP должно быть числом!");
                    return;
                }

                if (hp < 0)
                {
                    MessageBox.Show("HP не может быть отрицательным!");
                    return;
                }

                bool ok = logic.CreateMerc(txtName.Text, txtPrim.Text, txtSec.Text, txtMelee.Text, hp, txtRole.Text);

                if (ok == true)
                {
                    UpdateGrid();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Не удалось создать бойца. Проверь данные.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridMercs.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выдели бойца в таблице!");
                    return;
                }

                Mercenary selectedMerc = (Mercenary)gridMercs.SelectedRows[0].DataBoundItem;
                logic.DeleteMerc(selectedMerc.Id);
                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridMercs.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выдели бойца в таблице!");
                    return;
                }

                if (txtName.Text == "")
                {
                    MessageBox.Show("Введи имя бойца!");
                    return;
                }

                if (txtRole.Text == "")
                {
                    MessageBox.Show("Введи роль бойца!");
                    return;
                }

                int hp;
                if (int.TryParse(txtHP.Text, out hp) == false)
                {
                    MessageBox.Show("HP должно быть числом!");
                    return;
                }

                if (hp < 0)
                {
                    MessageBox.Show("HP не может быть отрицательным!");
                    return;
                }

                Mercenary selectedMerc = (Mercenary)gridMercs.SelectedRows[0].DataBoundItem;

                bool ok = logic.UpdateMerc(selectedMerc.Id, txtName.Text, txtPrim.Text, txtSec.Text, txtMelee.Text, hp, txtRole.Text);

                if (ok == true)
                {
                    UpdateGrid();
                }
                else
                {
                    MessageBox.Show("Не удалось обновить бойца.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> reportLines = logic.GetRolesReport();

                if (reportLines.Count == 0)
                {
                    MessageBox.Show("Список бойцов пуст.");
                    return;
                }

                string fullReport = "";
                foreach (string line in reportLines)
                {
                    fullReport = fullReport + line + "\n";
                }

                MessageBox.Show(fullReport, "Роли");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtPrim.Text;

                if (query == "")
                {
                    MessageBox.Show("Введи название оружия в поле 'Основное'!");
                    return;
                }

                List<Mercenary> found = logic.FindByWeapon(query);

                if (found.Count == 0)
                {
                    MessageBox.Show("Ничего не найдено.");
                }
                else
                {
                    gridMercs.DataSource = null;
                    gridMercs.DataSource = found;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPrim.Clear();
            txtSec.Clear();
            txtMelee.Clear();
            txtHP.Clear();
            txtRole.Clear();
        }
    }
}