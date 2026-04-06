using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLogin, txtPassword, txtFullName;
        private Button btnSave, btnCancel;
        private Label lblLogin, lblPassword, lblFullName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblLogin = new Label();
            lblPassword = new Label();
            lblFullName = new Label();
            SuspendLayout();

            Size = new Size(450, 280);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.White;

            lblLogin.Text = "Логин:";
            lblLogin.Location = new Point(20, 20);
            lblLogin.Size = new Size(100, 25);
            txtLogin.Location = new Point(130, 20);
            txtLogin.Size = new Size(270, 25);

            lblPassword.Text = "Пароль:";
            lblPassword.Location = new Point(20, 65);
            lblPassword.Size = new Size(100, 25);
            txtPassword.Location = new Point(130, 65);
            txtPassword.Size = new Size(270, 25);
            txtPassword.PasswordChar = '*';

            lblFullName.Text = "ФИО:";
            lblFullName.Location = new Point(20, 110);
            lblFullName.Size = new Size(100, 25);
            txtFullName.Location = new Point(130, 110);
            txtFullName.Size = new Size(270, 25);

            btnSave.Text = "💾 Сохранить";
            btnSave.Location = new Point(130, 180);
            btnSave.Size = new Size(100, 35);
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            btnCancel.Text = "❌ Отмена";
            btnCancel.Location = new Point(250, 180);
            btnCancel.Size = new Size(100, 35);
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += BtnCancel_Click;

            Controls.Add(lblLogin);
            Controls.Add(txtLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}