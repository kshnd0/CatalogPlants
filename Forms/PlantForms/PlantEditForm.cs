using CatalogPlants.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CatalogPlants.Forms.PlantForms
{
    public partial class PlantEditForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;
        private Plant _plant;
        private bool _isEditMode;

        public PlantEditForm(CatalogContext context, User currentUser, int? plantId = null)
        {
            _context = context;
            _currentUser = currentUser;
            _isEditMode = plantId.HasValue;
            InitializeComponent();

            LoadComboBoxes();

            if (_isEditMode)
            {
                _plant = _context.Plants.Find(plantId.Value);
                LoadPlantData();
                this.Text = "✏ Редактирование растения";
            }
            else
            {
                _plant = new Plant();
                this.Text = "➕ Добавление растения";
            }
        }

        private void LoadComboBoxes()
        {
            cmbLifeForm.DataSource = _context.LifeForms.ToList();
            cmbLifeForm.DisplayMember = "Name";
            cmbLifeForm.ValueMember = "LifeFormId";

            var careList = _context.CareRequirements.ToList();
            var careListWithEmpty = new System.Collections.Generic.List<CareRequirement>();
            careListWithEmpty.Add(new CareRequirement { Lighting = "— Не выбрано —", CareRequirementsId = -1 });
            careListWithEmpty.AddRange(careList);

            cmbCareRequirement.DataSource = careListWithEmpty;
            cmbCareRequirement.DisplayMember = "Lighting";
            cmbCareRequirement.ValueMember = "CareRequirementsId";
        }

        private void LoadPlantData()
        {
            txtName.Text = _plant.Name;
            txtLatinName.Text = _plant.LatinName;
            cmbLifeForm.SelectedValue = _plant.LifeFormId;

            if (_plant.CareRequirementsId.HasValue)
                cmbCareRequirement.SelectedValue = _plant.CareRequirementsId.Value;
            else
                cmbCareRequirement.SelectedValue = -1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название растения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _plant.Name = txtName.Text;
            _plant.LatinName = txtLatinName.Text;
            _plant.LifeFormId = cmbLifeForm.SelectedValue as int?;

            int careId = (int)cmbCareRequirement.SelectedValue;
            if (careId == -1)
                _plant.CareRequirementsId = null;
            else
                _plant.CareRequirementsId = careId;

            if (!_isEditMode)
            {
                _plant.CreatedByUserId = _currentUser.Id;
                _context.Plants.Add(_plant);
            }

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