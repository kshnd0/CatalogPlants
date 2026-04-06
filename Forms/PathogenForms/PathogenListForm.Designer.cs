using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.PathogenForms
{
    partial class PathogenListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvPathogens;
        private TextBox txtSearch;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;
        private Panel panelSearch, panelButtons;
        private Label lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvPathogens = new DataGridView();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            panelSearch = new Panel();
            lblSearch = new Label();
            panelButtons = new Panel();
            panelSearch.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPathogens).BeginInit();
            SuspendLayout();

            Size = new Size(1150, 600);
            BackColor = Color.White;

            panelSearch.Dock = DockStyle.Top;
            panelSearch.Height = 45;
            panelSearch.Padding = new Padding(5);

            lblSearch.Text = "🔍 Поиск:";
            lblSearch.Location = new Point(10, 10);
            lblSearch.Size = new Size(60, 25);

            txtSearch.Location = new Point(75, 7);
            txtSearch.Size = new Size(300, 25);
            txtSearch.TextChanged += TxtSearch_TextChanged;

            panelSearch.Controls.Add(lblSearch);
            panelSearch.Controls.Add(txtSearch);

            dgvPathogens.Dock = DockStyle.Fill;
            dgvPathogens.AllowUserToAddRows = false;
            dgvPathogens.AllowUserToDeleteRows = false;
            dgvPathogens.ReadOnly = true;
            dgvPathogens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPathogens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPathogens.BackgroundColor = Color.White;
            dgvPathogens.RowHeadersVisible = false;

            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Height = 55;
            panelButtons.Padding = new Padding(5);

            btnAdd.Text = "➕ Добавить";
            btnAdd.Location = new Point(10, 10);
            btnAdd.Size = new Size(120, 35);
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Click += BtnAdd_Click;

            btnEdit.Text = "✏ Редактировать";
            btnEdit.Location = new Point(140, 10);
            btnEdit.Size = new Size(120, 35);
            btnEdit.BackColor = Color.FromArgb(33, 150, 243);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Click += BtnEdit_Click;

            btnDelete.Text = "🗑 Удалить";
            btnDelete.Location = new Point(270, 10);
            btnDelete.Size = new Size(120, 35);
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Click += BtnDelete_Click;

            btnRefresh.Text = "🔄 Обновить";
            btnRefresh.Location = new Point(400, 10);
            btnRefresh.Size = new Size(120, 35);
            btnRefresh.BackColor = Color.FromArgb(158, 158, 158);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Click += BtnRefresh_Click;

            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnRefresh);

            Controls.Add(dgvPathogens);
            Controls.Add(panelSearch);
            Controls.Add(panelButtons);

            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPathogens).EndInit();
            ResumeLayout(false);
        }
    }
}