using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;
using CatalogPlants.Forms.LifeFormForms;

namespace CatalogPlants.Forms.LifeFormForms
{
    public partial class LifeFormListForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;

        public LifeFormListForm(CatalogContext context, User currentUser)
        {
            _context = context;
            _currentUser = currentUser;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var query = _context.LifeForms.AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(lf => lf.CreatedByUserId == _currentUser.Id);

            var lifeForms = query.Select(lf => new
            {
                lf.LifeFormId,
                Название = lf.Name,
                Количество_растений = lf.Plants.Count
            }).ToList();

            dgvLifeForms.DataSource = lifeForms;
            if (dgvLifeForms.Columns.Contains("LifeFormId"))
                dgvLifeForms.Columns["LifeFormId"].Visible = false;
            dgvLifeForms.ClearSelection();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadData();
                return;
            }

            var query = _context.LifeForms.Where(lf => lf.Name.ToLower().Contains(searchText)).AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(lf => lf.CreatedByUserId == _currentUser.Id);

            var lifeForms = query.Select(lf => new
            {
                lf.LifeFormId,
                Название = lf.Name,
                Количество_растений = lf.Plants.Count
            }).ToList();

            dgvLifeForms.DataSource = lifeForms;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new LifeFormEditForm(_context, _currentUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLifeForms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите жизненную форму!");
                return;
            }

            dynamic selected = dgvLifeForms.SelectedRows[0].DataBoundItem;
            using (var form = new LifeFormEditForm(_context, _currentUser, selected.LifeFormId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLifeForms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите жизненную форму!");
                return;
            }

            if (MessageBox.Show("Удалить жизненную форму?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dynamic selected = dgvLifeForms.SelectedRows[0].DataBoundItem;
                var lifeForm = _context.LifeForms.Find(selected.LifeFormId);
                if (lifeForm != null)
                {
                    _context.LifeForms.Remove(lifeForm);
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