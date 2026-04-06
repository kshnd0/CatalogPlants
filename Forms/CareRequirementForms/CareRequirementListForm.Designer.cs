using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.CareRequirementForms
{
    partial class CareRequirementListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCareRequirements;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;
        private Panel panelButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvCareRequirements = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            panelButtons = new Panel();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCareRequirements).BeginInit();
            SuspendLayout();

            Size = new Size(1150, 600);
            BackColor = Color.White;

            dgvCareRequirements.Dock = DockStyle.Fill;
            dgvCareRequirements.AllowUserToAddRows = false;
            dgvCareRequirements.AllowUserToDeleteRows = false;
            dgvCareRequirements.ReadOnly = true;
            dgvCareRequirements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCareRequirements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCareRequirements.BackgroundColor = Color.White;
            dgvCareRequirements.RowHeadersVisible = false;

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

            Controls.Add(dgvCareRequirements);
            Controls.Add(panelButtons);

            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCareRequirements).EndInit();
            ResumeLayout(false);
        }
    }
}