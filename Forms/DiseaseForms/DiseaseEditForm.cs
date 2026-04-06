using System;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;

namespace CatalogPlants.Forms.DiseaseForms
{
    public partial class DiseaseEditForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;
        private DiseaseHistory _disease;
        private bool _isEditMode;

        public DiseaseEditForm(CatalogContext context, User currentUser, int? id = null)
        {
            _context = context;
            _currentUser = currentUser;
            _isEditMode = id.HasValue;
            InitializeComponent();
            LoadComboBoxes();

            if (_isEditMode)
            {
                _disease = _context.DiseaseHistories.Find(id.Value);
                LoadData();
                this.Text = "✏ Редактирование записи о болезни";
            }
            else
            {
                _disease = new DiseaseHistory();
                this.Text = "➕ Добавление записи о болезни";
            }
        }

        private void LoadComboBoxes()
        {
            var plantsQuery = _context.Plants.AsQueryable();
            if (_currentUser.Role != "Admin")
                plantsQuery = plantsQuery.Where(p => p.CreatedByUserId == _currentUser.Id);
            cmbPlant.DataSource = plantsQuery.ToList();
            cmbPlant.DisplayMember = "Name";
            cmbPlant.ValueMember = "PlantId";

            var pathogens = _context.Pathogens.ToList();
            var pathogensWithEmpty = new System.Collections.Generic.List<Pathogen>();
            pathogensWithEmpty.Add(new Pathogen { Name = "— Не выбрано —", PathogenId = -1 });
            pathogensWithEmpty.AddRange(pathogens);
            cmbPathogen.DataSource = pathogensWithEmpty;
            cmbPathogen.DisplayMember = "Name";
            cmbPathogen.ValueMember = "PathogenId";
        }

        private void LoadData()
        {
            cmbPlant.SelectedValue = _disease.PlantId;
            cmbPathogen.SelectedValue = _disease.PathogenId ?? -1;
            dtpStart.Value = _disease.StartDate;
            if (_disease.EndDate.HasValue)
            {
                dtpEnd.Value = _disease.EndDate.Value;
                chkCured.Checked = true;
            }
            txtDescription.Text = _disease.Description;
        }

        private void ChkCured_CheckedChanged(object sender, EventArgs e)
        {
            dtpEnd.Enabled = chkCured.Checked;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbPlant.SelectedValue == null)
            {
                MessageBox.Show("Выберите растение!");
                return;
            }

            _disease.PlantId = (int)cmbPlant.SelectedValue;
            int pathogenId = (int)cmbPathogen.SelectedValue;
            _disease.PathogenId = pathogenId == -1 ? null : pathogenId;
            _disease.StartDate = dtpStart.Value;
            _disease.EndDate = chkCured.Checked ? dtpEnd.Value : (DateTime?)null;
            _disease.Description = txtDescription.Text;

            if (!_isEditMode)
            {
                _disease.CreatedByUserId = _currentUser.Id;
                _context.DiseaseHistories.Add(_disease);
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