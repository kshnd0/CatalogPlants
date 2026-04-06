using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;

namespace CatalogPlants.Forms
{
    public partial class UserEditForm : Form
    {
        private CatalogContext _context;
        private User _user;
        private bool _isEditMode;

        public UserEditForm(CatalogContext context, int? userId = null)
        {
            _context = context;
            _isEditMode = userId.HasValue;
            InitializeComponent();

            if (_isEditMode)
            {
                _user = _context.Users.Find(userId.Value);
                LoadUserData();
                this.Text = "✏ Редактирование пользователя";
            }
            else
            {
                _user = new User();
                this.Text = "➕ Добавление пользователя";
            }
        }

        private void LoadUserData()
        {
            txtLogin.Text = _user.Login;
            txtFullName.Text = _user.FullName;
            txtPassword.PlaceholderText = "Оставьте пустым, чтобы не менять пароль";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Login == txtLogin.Text && u.Id != _user.Id);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
                return;
            }

            _user.Login = txtLogin.Text;
            _user.FullName = txtFullName.Text;

            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                _user.Password = txtPassword.Text;
            else if (!_isEditMode)
                _user.Password = "123456";

            if (!_isEditMode)
                _context.Users.Add(_user);

            _context.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}