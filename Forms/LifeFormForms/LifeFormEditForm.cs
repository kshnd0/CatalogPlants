using CatalogPlants.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CatalogPlants.Forms.LifeFormForms
{
    public partial class LifeFormEditForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;
        private LifeForm _lifeForm;
        private bool _isEditMode;

        public LifeFormEditForm(CatalogContext context, User currentUser, int? id = null)
        {
            _context = context;
            _currentUser = currentUser;
            _isEditMode = id.HasValue;
            InitializeComponent();

            if (_isEditMode)
            {
                _lifeForm = _context.LifeForms.Find(id.Value);
                txtName.Text = _lifeForm.Name;
                this.Text = "✏ Редактирование жизненной формы";
            }
            else
            {
                _lifeForm = new LifeForm();
                this.Text = "➕ Добавление жизненной формы";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название!");
                return;
            }

            _lifeForm.Name = txtName.Text;

            if (!_isEditMode)
            {
                _lifeForm.CreatedByUserId = _currentUser.Id;
                _context.LifeForms.Add(_lifeForm);
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