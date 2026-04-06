using System;
using System.Drawing;
using System.Windows.Forms;
using CatalogPlants.Models;
using CatalogPlants.Forms.PlantForms;
using CatalogPlants.Forms.LifeFormForms;
using CatalogPlants.Forms.CareRequirementForms;
using CatalogPlants.Forms.CareLogForms;
using CatalogPlants.Forms.PathogenForms;
using CatalogPlants.Forms.DiseaseForms;
using CatalogPlants.Services;

namespace CatalogPlants.Forms
{
    public partial class MainForm : Form
    {
        private CatalogContext _context;
        private User _currentUser;

        public MainForm(User currentUser)
        {
            _context = new CatalogContext();
            _currentUser = currentUser;
            InitializeComponent();
            this.Text = $"🌿 Каталог растений - {_currentUser.FullName}";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1200, 750);
            this.BackColor = Color.FromArgb(240, 248, 255);
            LoadTabs();
        }

        private void LoadTabs()
        {
            AddTab("🌱 Растения", new PlantListForm(_context, _currentUser));
            AddTab("🌳 Жизненные формы", new LifeFormListForm(_context, _currentUser));
            AddTab("💧 Рекомендации по уходу", new CareRequirementListForm(_context, _currentUser));
            AddTab("📝 Журнал ухода", new CareLogListForm(_context, _currentUser));
            AddTab("🦠 Патогены", new PathogenListForm(_context, _currentUser));
            AddTab("📋 История болезней", new DiseaseListForm(_context, _currentUser));
            AddTab("📊 Статистика", new StatisticsForm(_context));

            if (_currentUser.Role == "Admin")
            {
                AddTab("👥 Пользователи", new UserManagementForm(_context));
            }
        }

        private void AddTab(string title, Form form)
        {
            var tabPage = new TabPage(title);
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabPage.Controls.Add(form);
            tabControlMain.TabPages.Add(tabPage);
            form.Show();
        }

        private void BtnExportAll_Click(object sender, EventArgs e)
        {
            var exportService = new ExcelExportService(_context);
            exportService.ExportAllDataToExcel(_currentUser);
        }

    }
}