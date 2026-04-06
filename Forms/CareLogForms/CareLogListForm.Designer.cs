using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.CareLogForms
{
    partial class CareLogListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCareLogs;
        private Button btnAdd, btnDelete, btnRefresh;
        private Panel panelButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvCareLogs = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            panelButtons = new Panel();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCareLogs).BeginInit();
            SuspendLayout();

            Size = new Size(1150, 600);
            BackColor = Color.White;

            dgvCareLogs.Dock = DockStyle.Fill;
            dgvCareLogs.AllowUserToAddRows = false;
            dgvCareLogs.AllowUserToDeleteRows = false;
            dgvCareLogs.ReadOnly = true;
            dgvCareLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCareLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCareLogs.BackgroundColor = Color.White;
            dgvCareLogs.RowHeadersVisible = false;

            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Height = 55;
            panelButtons.Padding = new Padding(5);

            btnAdd.Text = "➕ Добавить запись";
            btnAdd.Location = new Point(10, 10);
            btnAdd.Size = new Size(140, 35);
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Click += BtnAdd_Click;

            btnDelete.Text = "🗑 Удалить";
            btnDelete.Location = new Point(160, 10);
            btnDelete.Size = new Size(120, 35);
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Click += BtnDelete_Click;

            btnRefresh.Text = "🔄 Обновить";
            btnRefresh.Location = new Point(290, 10);
            btnRefresh.Size = new Size(120, 35);
            btnRefresh.BackColor = Color.FromArgb(158, 158, 158);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Click += BtnRefresh_Click;

            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnRefresh);

            Controls.Add(dgvCareLogs);
            Controls.Add(panelButtons);

            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCareLogs).EndInit();
            ResumeLayout(false);
        }
    }
}