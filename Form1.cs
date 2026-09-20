using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TF2Logic;

namespace TF2WinForms
{
    /// <summary>
    /// Главная форма приложения. Служит представлением для работы
    /// с наёмниками: позволяет добавлять, удалять, изменять и искать записи.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Экземпляр бизнес-логики, через который форма работает с данными.
        /// </summary>
        private Logic logic = new Logic();

        /// <summary>
        /// Инициализирует форму, настраивает таблицу, заполняет её тестовыми
        /// данными и подгружает записи на экран.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            gridMercs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridMercs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMercs.MultiSelect = false;
            gridMercs.AllowUserToAddRows = false;
            logic.CreateMerc("Солдат", "Ракетница", "Дробовик", "Лопака", 200, "Атака");
            logic.CreateMerc("Медик", "Арбалет крестоносца", "Лечебная пушка", "Убер-пила", 150, "Поддержка");
            logic.CreateMerc("Хэви", "Миниган", "Бутерброд", "Горящие рукавицы ускорения", 300, "Оборона");

            UpdateGrid();
        }

        /// <summary>
        /// Обновляет содержимое таблицы: сбрасывает привязку и заново
        /// загружает список наёмников из бизнес-логики.
        /// </summary>
        private void UpdateGrid()
        {
            gridMercs.DataSource = null;
            gridMercs.DataSource = logic.ReadAll();
        }

        /// <summary>
        /// Обработчик кнопки «Нанять наемника». Проверяет ввод и создаёт
        /// нового наёмника через Logic.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Введите имя бойца!");
                    return;
                }

                if (txtRole.Text == "")
                {
                    MessageBox.Show("Введите роль бойца!");
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
                    MessageBox.Show("Не удалось создать бойца. Проверьте данные.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        /// <summary>
        /// Обработчик кнопки «Уволить наемника». Удаляет выделенного
        /// в таблице наёмника.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridMercs.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выделите бойца в таблице!");
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

        /// <summary>
        /// Обработчик кнопки «Изменить данные». Обновляет информацию
        /// о выделенном наёмнике на основе введённых в поля значений.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridMercs.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выделите бойца в таблице!");
                    return;
                }

                if (txtName.Text == "")
                {
                    MessageBox.Show("Введите имя бойца!");
                    return;
                }

                if (txtRole.Text == "")
                {
                    MessageBox.Show("Введите роль бойца!");
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

        /// <summary>
        /// Обработчик кнопки «Отчёт». Формирует и показывает отчёт
        /// о наёмниках, сгруппированных по ролям.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Обработчик кнопки «Поиск оружия». Ищет наёмников по названию
        /// оружия, введённому в поле «Основное», и отображает результат в таблице.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtPrim.Text;

                if (query == "")
                {
                    MessageBox.Show("Введите название оружия в поле 'Основное'!");
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

        /// <summary>
        /// Обработчик кнопки «Сброс фильтра». Возвращает таблицу
        /// к исходному виду — показывает всех наёмников.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Очищает все текстовые поля ввода на форме.
        /// </summary>
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