using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;
using Microsoft.EntityFrameworkCore;
using CatalogPlants.Forms.DiseaseForms;

namespace CatalogPlants.Forms.DiseaseForms
{
    public partial class DiseaseListForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;

        public DiseaseListForm(CatalogContext context, User currentUser)
        {
            _context = context;
            _currentUser = currentUser;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var query = _context.DiseaseHistories
                .Include(d => d.Plant)
                .Include(d => d.Pathogen)
                .AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(d => d.CreatedByUserId == _currentUser.Id);

            var diseases = query.Select(d => new
            {
                d.DiseaseHistoryId,
                Растение = d.Plant != null ? d.Plant.Name : "Не указано",
                Патоген = d.Pathogen != null ? d.Pathogen.Name : "Не указан",
                Дата_начала = d.StartDate,
                Дата_окончания = d.EndDate,
                Описание = d.Description,
                Статус = d.EndDate.HasValue ? "Вылечено" : "Болеет"
            }).OrderByDescending(d => d.Дата_начала).ToList();

            dgvDiseases.DataSource = diseases;
            if (dgvDiseases.Columns.Contains("DiseaseHistoryId"))
                dgvDiseases.Columns["DiseaseHistoryId"].Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new DiseaseEditForm(_context, _currentUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDiseases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }

            dynamic selected = dgvDiseases.SelectedRows[0].DataBoundItem;
            using (var form = new DiseaseEditForm(_context, _currentUser, selected.DiseaseHistoryId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiseases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }

            if (MessageBox.Show("Удалить запись о болезни?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dynamic selected = dgvDiseases.SelectedRows[0].DataBoundItem;
                var disease = _context.DiseaseHistories.Find(selected.DiseaseHistoryId);
                if (disease != null)
                {
                    _context.DiseaseHistories.Remove(disease);
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