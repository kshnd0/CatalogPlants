using System;
using System.Windows.Forms;
using CatalogPlants.Models;

namespace CatalogPlants.Forms.CareRequirementForms
{
    public partial class CareRequirementEditForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;
        private CareRequirement _careReq;
        private bool _isEditMode;

        public CareRequirementEditForm(CatalogContext context, User currentUser, int? id = null)
        {
            _context = context;
            _currentUser = currentUser;
            _isEditMode = id.HasValue;
            InitializeComponent();

            if (_isEditMode)
            {
                _careReq = _context.CareRequirements.Find(id.Value);
                LoadData();
                this.Text = "✏ Редактирование рекомендаций";
            }
            else
            {
                _careReq = new CareRequirement();
                this.Text = "➕ Добавление рекомендаций";
            }
        }

        private void LoadData()
        {
            txtLighting.Text = _careReq.Lighting;
            txtWateringSummer.Text = _careReq.WateringSummer;
            txtWateringWinter.Text = _careReq.WateringWinter;
            txtTempSummer.Text = _careReq.TemperatureSummer;
            txtTempWinter.Text = _careReq.TemperatureWinter;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _careReq.Lighting = txtLighting.Text;
            _careReq.WateringSummer = txtWateringSummer.Text;
            _careReq.WateringWinter = txtWateringWinter.Text;
            _careReq.TemperatureSummer = txtTempSummer.Text;
            _careReq.TemperatureWinter = txtTempWinter.Text;

            if (!_isEditMode)
            {
                _careReq.CreatedByUserId = _currentUser.Id;
                _context.CareRequirements.Add(_careReq);
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