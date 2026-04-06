using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.CareLogForms
{
    partial class CareLogEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbPlant;
        private DateTimePicker dtpDate;
        private TextBox txtDescription;
        private Button btnSave, btnCancel;
        private Label lblPlant, lblDate, lblDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbPlant = new ComboBox();
            dtpDate = new DateTimePicker();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblPlant = new Label();
            lblDate = new Label();
            lblDescription = new Label();
            SuspendLayout();
            // 
            // cmbPlant
            // 
            cmbPlant.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlant.Location = new Point(130, 20);
            cmbPlant.Name = "cmbPlant";
            cmbPlant.Size = new Size(300, 23);
            cmbPlant.TabIndex = 1;
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(130, 65);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(300, 23);
            dtpDate.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(130, 110);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(300, 60);
            txtDescription.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(130, 190);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 6;
            btnSave.Text = "💾 Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(250, 190);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "❌ Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblPlant
            // 
            lblPlant.Location = new Point(20, 20);
            lblPlant.Name = "lblPlant";
            lblPlant.Size = new Size(100, 25);
            lblPlant.TabIndex = 0;
            lblPlant.Text = "Растение:";
            // 
            // lblDate
            // 
            lblDate.Location = new Point(20, 65);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 25);
            lblDate.TabIndex = 2;
            lblDate.Text = "Дата и время:";
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(20, 110);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 25);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Описание:";
            // 
            // CareLogEditForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(484, 251);
            Controls.Add(lblPlant);
            Controls.Add(cmbPlant);
            Controls.Add(lblDate);
            Controls.Add(dtpDate);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CareLogEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "➕ Добавление записи об уходе";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}