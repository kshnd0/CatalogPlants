using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;
using Microsoft.EntityFrameworkCore;
using CatalogPlants.Forms.CareLogForms;

namespace CatalogPlants.Forms.CareLogForms
{
    public partial class CareLogListForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;

        public CareLogListForm(CatalogContext context, User currentUser)
        {
            _context = context;
            _currentUser = currentUser;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var query = _context.CareLogs.Include(cl => cl.Plant).AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(cl => cl.CreatedByUserId == _currentUser.Id);

            var careLogs = query.Select(cl => new
            {
                cl.CareLogId,
                Растение = cl.Plant != null ? cl.Plant.Name : "Не указано",
                Дата = cl.DateTime,
                Описание = cl.Description
            }).OrderByDescending(cl => cl.Дата).ToList();

            dgvCareLogs.DataSource = careLogs;
            if (dgvCareLogs.Columns.Contains("CareLogId"))
                dgvCareLogs.Columns["CareLogId"].Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new CareLogEditForm(_context, _currentUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCareLogs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }

            if (MessageBox.Show("Удалить запись?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dynamic selected = dgvCareLogs.SelectedRows[0].DataBoundItem;
                var careLog = _context.CareLogs.Find(selected.CareLogId);
                if (careLog != null)
                {
                    _context.CareLogs.Remove(careLog);
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}