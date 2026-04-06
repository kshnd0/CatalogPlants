using CatalogPlants.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CatalogPlants.Forms.PathogenForms
{
    public partial class PathogenEditForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;
        private Pathogen _pathogen;
        private bool _isEditMode;

        public PathogenEditForm(CatalogContext context, User currentUser, int? id = null)
        {
            _context = context;
            _currentUser = currentUser;
            _isEditMode = id.HasValue;
            InitializeComponent();

            if (_isEditMode)
            {
                _pathogen = _context.Pathogens.Find(id.Value);
                LoadData();
                this.Text = "✏ Редактирование патогена";
            }
            else
            {
                _pathogen = new Pathogen();
                this.Text = "➕ Добавление патогена";
            }
        }

        private void LoadData()
        {
            txtName.Text = _pathogen.Name;
            txtDescription.Text = _pathogen.Description;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название патогена!");
                return;
            }

            _pathogen.Name = txtName.Text;
            _pathogen.Description = txtDescription.Text;

            if (!_isEditMode)
            {
                _pathogen.CreatedByUserId = _currentUser.Id;
                _context.Pathogens.Add(_pathogen);
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