using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.PlantForms
{
    partial class PlantEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName, txtLatinName;
        private ComboBox cmbLifeForm, cmbCareRequirement;
        private Button btnSave, btnCancel;
        private Label lblName, lblLatinName, lblLifeForm, lblCare;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtLatinName = new TextBox();
            cmbLifeForm = new ComboBox();
            cmbCareRequirement = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            lblLatinName = new Label();
            lblLifeForm = new Label();
            lblCare = new Label();
            SuspendLayout();

            Size = new Size(500, 300);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;

            lblName.Text = "Название:";
            lblName.Location = new Point(20, 30);
            lblName.Size = new Size(120, 25);
            txtName.Location = new Point(150, 27);
            txtName.Size = new Size(300, 25);

            lblLatinName.Text = "Латинское название:";
            lblLatinName.Location = new Point(20, 70);
            lblLatinName.Size = new Size(120, 25);
            txtLatinName.Location = new Point(150, 67);
            txtLatinName.Size = new Size(300, 25);

            lblLifeForm.Text = "Жизненная форма:";
            lblLifeForm.Location = new Point(20, 110);
            lblLifeForm.Size = new Size(120, 25);
            cmbLifeForm.Location = new Point(150, 107);
            cmbLifeForm.Size = new Size(300, 25);
            cmbLifeForm.DropDownStyle = ComboBoxStyle.DropDownList;

            lblCare.Text = "Рекомендации по уходу:";
            lblCare.Location = new Point(20, 150);
            lblCare.Size = new Size(150, 25);
            cmbCareRequirement.Location = new Point(180, 147);
            cmbCareRequirement.Size = new Size(270, 25);
            cmbCareRequirement.DropDownStyle = ComboBoxStyle.DropDownList;

            btnSave.Text = "💾 Сохранить";
            btnSave.Location = new Point(150, 210);
            btnSave.Size = new Size(100, 35);
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            btnCancel.Text = "❌ Отмена";
            btnCancel.Location = new Point(270, 210);
            btnCancel.Size = new Size(100, 35);
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += BtnCancel_Click;

            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblLatinName);
            Controls.Add(txtLatinName);
            Controls.Add(lblLifeForm);
            Controls.Add(cmbLifeForm);
            Controls.Add(lblCare);
            Controls.Add(cmbCareRequirement);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}