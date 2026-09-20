namespace TF2WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridMercs = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtPrim = new System.Windows.Forms.TextBox();
            this.txtSec = new System.Windows.Forms.TextBox();
            this.txtMelee = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPrim = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblMelee = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridMercs)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMercs
            // 
            this.gridMercs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMercs.Location = new System.Drawing.Point(400, 12);
            this.gridMercs.Name = "gridMercs";
            this.gridMercs.Size = new System.Drawing.Size(370, 200);
            this.gridMercs.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtHP
            // 
            this.txtHP.Location = new System.Drawing.Point(140, 32);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(100, 20);
            this.txtHP.TabIndex = 2;
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(268, 32);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(100, 20);
            this.txtRole.TabIndex = 3;
            // 
            // txtPrim
            // 
            this.txtPrim.Location = new System.Drawing.Point(12, 100);
            this.txtPrim.Name = "txtPrim";
            this.txtPrim.Size = new System.Drawing.Size(100, 20);
            this.txtPrim.TabIndex = 4;
            // 
            // txtSec
            // 
            this.txtSec.Location = new System.Drawing.Point(140, 100);
            this.txtSec.Name = "txtSec";
            this.txtSec.Size = new System.Drawing.Size(100, 20);
            this.txtSec.TabIndex = 5;
            // 
            // txtMelee
            // 
            this.txtMelee.Location = new System.Drawing.Point(268, 100);
            this.txtMelee.Name = "txtMelee";
            this.txtMelee.Size = new System.Drawing.Size(100, 20);
            this.txtMelee.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 222);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 46);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Нанять наемника";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(148, 222);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 46);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Уволить наемника";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(268, 222);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 46);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Изменить данные";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(400, 222);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 46);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "Отчёт";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(531, 222);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 46);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Поиск оружия";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(670, 222);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 46);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Сброс фильтра";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 55);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 13);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Имя";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(176, 55);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(22, 13);
            this.lblHP.TabIndex = 14;
            this.lblHP.Text = "HP";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(303, 55);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.TabIndex = 15;
            this.lblRole.Text = "Роль";
            // 
            // lblPrim
            // 
            this.lblPrim.AutoSize = true;
            this.lblPrim.Location = new System.Drawing.Point(23, 123);
            this.lblPrim.Name = "lblPrim";
            this.lblPrim.Size = new System.Drawing.Size(70, 13);
            this.lblPrim.TabIndex = 16;
            this.lblPrim.Text = "Осн. оружие";
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(145, 123);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(85, 13);
            this.lblSec.TabIndex = 17;
            this.lblSec.Text = "Вторич. оружие";
            // 
            // lblMelee
            // 
            this.lblMelee.AutoSize = true;
            this.lblMelee.Location = new System.Drawing.Point(269, 123);
            this.lblMelee.Name = "lblMelee";
            this.lblMelee.Size = new System.Drawing.Size(99, 13);
            this.lblMelee.TabIndex = 18;
            this.lblMelee.Text = "Оружие ближ. боя";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 280);
            this.Controls.Add(this.lblMelee);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.lblPrim);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMelee);
            this.Controls.Add(this.txtSec);
            this.Controls.Add(this.txtPrim);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.gridMercs);
            this.Name = "Form1";
            this.Text = "TF2: Профиль 10-го класса";
            ((System.ComponentModel.ISupportInitialize)(this.gridMercs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMercs;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtPrim;
        private System.Windows.Forms.TextBox txtSec;
        private System.Windows.Forms.TextBox txtMelee;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPrim;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblMelee;
    }
}