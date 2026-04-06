using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;
using CatalogPlants.Services;

namespace CatalogPlants.Forms
{
    public partial class UserManagementForm : Form
    {
        private CatalogContext _context;

        public UserManagementForm(CatalogContext context)
        {
            _context = context;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var users = _context.Users.Select(u => new { u.Id, u.Login, u.FullName }).ToList();
            dgvUsers.DataSource = users;
            if (dgvUsers.Columns.Contains("Id"))
                dgvUsers.Columns["Id"].Visible = false;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadData();
                return;
            }

            var users = _context.Users
                .Where(u => u.Login.ToLower().Contains(searchText) ||
                           (u.FullName != null && u.FullName.ToLower().Contains(searchText)))
                .Select(u => new { u.Id, u.Login, u.FullName })
                .ToList();
            dgvUsers.DataSource = users;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new UserEditForm(_context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя!");
                return;
            }

            dynamic selected = dgvUsers.SelectedRows[0].DataBoundItem;
            using (var form = new UserEditForm(_context, selected.Id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя!");
                return;
            }

            dynamic selected = dgvUsers.SelectedRows[0].DataBoundItem;
            if (selected.Login == "admin")
            {
                MessageBox.Show("Нельзя удалить администратора!");
                return;
            }

            if (MessageBox.Show($"Удалить пользователя '{selected.Login}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var user = _context.Users.Find(selected.Id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            var exportService = new ExcelExportService(_context);
            exportService.ExportUsersToExcel();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}