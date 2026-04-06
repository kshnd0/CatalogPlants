using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;

namespace CatalogPlants
{
    public partial class LoginForm : Form
    {
        private CatalogContext _context;
        public User CurrentUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _context = new CatalogContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    return;
                }

                CurrentUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}