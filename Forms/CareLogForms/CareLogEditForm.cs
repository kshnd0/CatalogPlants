using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;

namespace CatalogPlants.Forms.CareLogForms
{
    public partial class CareLogEditForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;

        public CareLogEditForm(CatalogContext context, User currentUser)
        {
            _context = context;
            _currentUser = currentUser;
            InitializeComponent();
            LoadPlants();
        }

        private void LoadPlants()
        {
            var query = _context.Plants.AsQueryable();
            if (_currentUser.Role != "Admin")
                query = query.Where(p => p.CreatedByUserId == _currentUser.Id);

            cmbPlant.DataSource = query.ToList();
            cmbPlant.DisplayMember = "Name";
            cmbPlant.ValueMember = "PlantId";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbPlant.SelectedValue == null)
            {
                MessageBox.Show("Выберите растение!");
                return;
            }

            var careLog = new CareLog
            {
                PlantId = (int)cmbPlant.SelectedValue,
                DateTime = dtpDate.Value,
                Description = txtDescription.Text,
                CreatedByUserId = _currentUser.Id
            };

            _context.CareLogs.Add(careLog);
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