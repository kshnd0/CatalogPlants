using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;
using CatalogPlants.Forms.CareRequirementForms;

namespace CatalogPlants.Forms.CareRequirementForms
{
    public partial class CareRequirementListForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;

        public CareRequirementListForm(CatalogContext context, User currentUser)
        {
            _context = context;
            _currentUser = currentUser;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var query = _context.CareRequirements.AsQueryable();

            if (_currentUser.Role != "Admin")
                query = query.Where(cr => cr.CreatedByUserId == _currentUser.Id);

            var careReqs = query.Select(cr => new
            {
                cr.CareRequirementsId,
                Освещение = cr.Lighting,
                Полив_лето = cr.WateringSummer,
                Полив_зима = cr.WateringWinter,
                Температура_лето = cr.TemperatureSummer,
                Температура_зима = cr.TemperatureWinter,
                Растений = cr.Plants.Count
            }).ToList();

            dgvCareRequirements.DataSource = careReqs;
            if (dgvCareRequirements.Columns.Contains("CareRequirementsId"))
                dgvCareRequirements.Columns["CareRequirementsId"].Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new CareRequirementEditForm(_context, _currentUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCareRequirements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите рекомендации!");
                return;
            }

            dynamic selected = dgvCareRequirements.SelectedRows[0].DataBoundItem;
            using (var form = new CareRequirementEditForm(_context, _currentUser, selected.CareRequirementsId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCareRequirements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите рекомендации!");
                return;
            }

            if (MessageBox.Show("Удалить рекомендации?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dynamic selected = dgvCareRequirements.SelectedRows[0].DataBoundItem;
                var careReq = _context.CareRequirements.Find(selected.CareRequirementsId);
                if (careReq != null)
                {
                    _context.CareRequirements.Remove(careReq);
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