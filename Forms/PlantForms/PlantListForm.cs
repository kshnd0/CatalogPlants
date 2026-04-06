using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;
using Microsoft.EntityFrameworkCore;
using CatalogPlants.Services;

namespace CatalogPlants.Forms.PlantForms
{
    public partial class PlantListForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;

        public PlantListForm(CatalogContext context, User currentUser)
        {
            _context = context;
            _currentUser = currentUser;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var query = _context.Plants
                .Include(p => p.LifeForm)
                .Include(p => p.CareRequirements)
                .AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(p => p.CreatedByUserId == _currentUser.Id);

            var plants = query.Select(p => new
            {
                p.PlantId,
                Название = p.Name,
                Латинское_название = p.LatinName ?? "-",
                Жизненная_форма = p.LifeForm != null ? p.LifeForm.Name : "Не указана",
                Уход = p.CareRequirements != null ? "Есть" : "Нет"
            }).ToList();

            dgvPlants.DataSource = plants;
            if (dgvPlants.Columns.Contains("PlantId"))
                dgvPlants.Columns["PlantId"].Visible = false;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadData();
                return;
            }

            var query = _context.Plants
                .Where(p => p.Name.ToLower().Contains(searchText) ||
                           (p.LatinName != null && p.LatinName.ToLower().Contains(searchText)))
                .AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(p => p.CreatedByUserId == _currentUser.Id);

            var plants = query.Select(p => new
            {
                p.PlantId,
                Название = p.Name,
                Латинское_название = p.LatinName ?? "-",
                Жизненная_форма = p.LifeForm != null ? p.LifeForm.Name : "Не указана"
            }).ToList();

            dgvPlants.DataSource = plants;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PlantEditForm(_context, _currentUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPlants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите растение!");
                return;
            }

            dynamic selected = dgvPlants.SelectedRows[0].DataBoundItem;
            using (var form = new PlantEditForm(_context, _currentUser, selected.PlantId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите растение!");
                return;
            }

            if (MessageBox.Show("Удалить растение?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dynamic selected = dgvPlants.SelectedRows[0].DataBoundItem;
                var plant = _context.Plants.Find(selected.PlantId);
                if (plant != null)
                {
                    _context.Plants.Remove(plant);
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        //для импорта
        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            var exportService = new ExcelExportService(_context);
            exportService.ExportPlantsToExcel(_currentUser);
        }

    }
}