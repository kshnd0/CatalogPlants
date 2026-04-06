using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.PathogenForms
{
    partial class PathogenEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName, txtDescription;
        private Button btnSave, btnCancel;
        private Label lblName, lblDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            lblDescription = new Label();
            SuspendLayout();

            Size = new Size(500, 250);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.White;

            lblName.Text = "Название:";
            lblName.Location = new Point(20, 20);
            lblName.Size = new Size(100, 25);
            txtName.Location = new Point(130, 20);
            txtName.Size = new Size(320, 25);

            lblDescription.Text = "Описание:";
            lblDescription.Location = new Point(20, 65);
            lblDescription.Size = new Size(100, 25);
            txtDescription.Location = new Point(130, 65);
            txtDescription.Size = new Size(320, 80);
            txtDescription.Multiline = true;

            btnSave.Text = "💾 Сохранить";
            btnSave.Location = new Point(130, 165);
            btnSave.Size = new Size(100, 35);
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            btnCancel.Text = "❌ Отмена";
            btnCancel.Location = new Point(250, 165);
            btnCancel.Size = new Size(100, 35);
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += BtnCancel_Click;

            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}