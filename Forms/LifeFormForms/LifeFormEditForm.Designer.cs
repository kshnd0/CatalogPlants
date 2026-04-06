using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.LifeFormForms
{
    partial class LifeFormEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private Button btnSave, btnCancel;
        private Label lblName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            SuspendLayout();

            Size = new Size(400, 150);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.White;

            lblName.Text = "Название:";
            lblName.Location = new Point(20, 30);
            lblName.Size = new Size(100, 25);

            txtName.Location = new Point(120, 27);
            txtName.Size = new Size(230, 25);

            btnSave.Text = "💾 Сохранить";
            btnSave.Location = new Point(120, 70);
            btnSave.Size = new Size(100, 35);
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            btnCancel.Text = "❌ Отмена";
            btnCancel.Location = new Point(240, 70);
            btnCancel.Size = new Size(100, 35);
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += BtnCancel_Click;

            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}