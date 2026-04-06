using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;
using CatalogPlants.Forms.PathogenForms;

namespace CatalogPlants.Forms.PathogenForms
{
    public partial class PathogenListForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;

        public PathogenListForm(CatalogContext context, User currentUser)
        {
            _context = context;
            _currentUser = currentUser;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var query = _context.Pathogens.AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(p => p.CreatedByUserId == _currentUser.Id);

            var pathogens = query.Select(p => new
            {
                p.PathogenId,
                Название = p.Name,
                Описание = p.Description ?? "-",
                Заболеваний = p.DiseaseHistories.Count
            }).ToList();

            dgvPathogens.DataSource = pathogens;
            if (dgvPathogens.Columns.Contains("PathogenId"))
                dgvPathogens.Columns["PathogenId"].Visible = false;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadData();
                return;
            }

            var query = _context.Pathogens
                .Where(p => p.Name.ToLower().Contains(searchText) ||
                           (p.Description != null && p.Description.ToLower().Contains(searchText)))
                .AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(p => p.CreatedByUserId == _currentUser.Id);

            var pathogens = query.Select(p => new
            {
                p.PathogenId,
                Название = p.Name,
                Описание = p.Description ?? "-",
                Заболеваний = p.DiseaseHistories.Count
            }).ToList();

            dgvPathogens.DataSource = pathogens;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PathogenEditForm(_context, _currentUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPathogens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите патоген!");
                return;
            }

            dynamic selected = dgvPathogens.SelectedRows[0].DataBoundItem;
            using (var form = new PathogenEditForm(_context, _currentUser, selected.PathogenId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPathogens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите патоген!");
                return;
            }

            if (MessageBox.Show("Удалить патоген?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dynamic selected = dgvPathogens.SelectedRows[0].DataBoundItem;
                var pathogen = _context.Pathogens.Find(selected.PathogenId);
                if (pathogen != null)
                {
                    _context.Pathogens.Remove(pathogen);
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