using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.DiseaseForms
{
    partial class DiseaseEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbPlant, cmbPathogen;
        private DateTimePicker dtpStart, dtpEnd;
        private CheckBox chkCured;
        private TextBox txtDescription;
        private Button btnSave, btnCancel;
        private Label lblPlant, lblPathogen, lblStart, lblEnd, lblDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbPlant = new ComboBox();
            cmbPathogen = new ComboBox();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            chkCured = new CheckBox();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblPlant = new Label();
            lblPathogen = new Label();
            lblStart = new Label();
            lblEnd = new Label();
            lblDescription = new Label();
            SuspendLayout();

            Size = new Size(550, 400);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.White;

            lblPlant.Text = "Растение:";
            lblPlant.Location = new Point(20, 20);
            lblPlant.Size = new Size(100, 25);
            cmbPlant.Location = new Point(130, 20);
            cmbPlant.Size = new Size(370, 25);
            cmbPlant.DropDownStyle = ComboBoxStyle.DropDownList;

            lblPathogen.Text = "Патоген:";
            lblPathogen.Location = new Point(20, 60);
            lblPathogen.Size = new Size(100, 25);
            cmbPathogen.Location = new Point(130, 60);
            cmbPathogen.Size = new Size(370, 25);
            cmbPathogen.DropDownStyle = ComboBoxStyle.DropDownList;

            lblStart.Text = "Дата начала:";
            lblStart.Location = new Point(20, 100);
            lblStart.Size = new Size(100, 25);
            dtpStart.Location = new Point(130, 100);
            dtpStart.Size = new Size(200, 25);
            dtpStart.Format = DateTimePickerFormat.Short;

            lblEnd.Text = "Дата окончания:";
            lblEnd.Location = new Point(20, 140);
            lblEnd.Size = new Size(100, 25);
            dtpEnd.Location = new Point(130, 140);
            dtpEnd.Size = new Size(200, 25);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Enabled = false;

            chkCured.Text = "Вылечено";
            chkCured.Location = new Point(350, 135);
            chkCured.Size = new Size(100, 25);
            chkCured.CheckedChanged += ChkCured_CheckedChanged;

            lblDescription.Text = "Описание:";
            lblDescription.Location = new Point(20, 180);
            lblDescription.Size = new Size(100, 25);
            txtDescription.Location = new Point(130, 180);
            txtDescription.Size = new Size(370, 100);
            txtDescription.Multiline = true;

            btnSave.Text = "💾 Сохранить";
            btnSave.Location = new Point(130, 310);
            btnSave.Size = new Size(100, 35);
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            btnCancel.Text = "❌ Отмена";
            btnCancel.Location = new Point(250, 310);
            btnCancel.Size = new Size(100, 35);
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += BtnCancel_Click;

            Controls.Add(lblPlant);
            Controls.Add(cmbPlant);
            Controls.Add(lblPathogen);
            Controls.Add(cmbPathogen);
            Controls.Add(lblStart);
            Controls.Add(dtpStart);
            Controls.Add(lblEnd);
            Controls.Add(dtpEnd);
            Controls.Add(chkCured);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}