using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms.CareRequirementForms
{
    partial class CareRequirementEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLighting, txtWateringSummer, txtWateringWinter, txtTempSummer, txtTempWinter;
        private Button btnSave, btnCancel;
        private Label lblLighting, lblWateringSummer, lblWateringWinter, lblTempSummer, lblTempWinter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtLighting = new TextBox();
            txtWateringSummer = new TextBox();
            txtWateringWinter = new TextBox();
            txtTempSummer = new TextBox();
            txtTempWinter = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblLighting = new Label();
            lblWateringSummer = new Label();
            lblWateringWinter = new Label();
            lblTempSummer = new Label();
            lblTempWinter = new Label();
            SuspendLayout();
            // 
            // txtLighting
            // 
            txtLighting.Location = new Point(170, 20);
            txtLighting.Name = "txtLighting";
            txtLighting.Size = new Size(250, 23);
            txtLighting.TabIndex = 1;
            // 
            // txtWateringSummer
            // 
            txtWateringSummer.Location = new Point(170, 60);
            txtWateringSummer.Name = "txtWateringSummer";
            txtWateringSummer.Size = new Size(250, 23);
            txtWateringSummer.TabIndex = 3;
            // 
            // txtWateringWinter
            // 
            txtWateringWinter.Location = new Point(170, 100);
            txtWateringWinter.Name = "txtWateringWinter";
            txtWateringWinter.Size = new Size(250, 23);
            txtWateringWinter.TabIndex = 5;
            // 
            // txtTempSummer
            // 
            txtTempSummer.Location = new Point(170, 140);
            txtTempSummer.Name = "txtTempSummer";
            txtTempSummer.Size = new Size(250, 23);
            txtTempSummer.TabIndex = 7;
            // 
            // txtTempWinter
            // 
            txtTempWinter.Location = new Point(170, 180);
            txtTempWinter.Name = "txtTempWinter";
            txtTempWinter.Size = new Size(250, 23);
            txtTempWinter.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(170, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 10;
            btnSave.Text = "💾 Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(290, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "❌ Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblLighting
            // 
            lblLighting.Location = new Point(20, 20);
            lblLighting.Name = "lblLighting";
            lblLighting.Size = new Size(140, 25);
            lblLighting.TabIndex = 0;
            lblLighting.Text = "Освещение:";
            // 
            // lblWateringSummer
            // 
            lblWateringSummer.Location = new Point(20, 60);
            lblWateringSummer.Name = "lblWateringSummer";
            lblWateringSummer.Size = new Size(140, 25);
            lblWateringSummer.TabIndex = 2;
            lblWateringSummer.Text = "Полив (лето):";
            // 
            // lblWateringWinter
            // 
            lblWateringWinter.Location = new Point(20, 100);
            lblWateringWinter.Name = "lblWateringWinter";
            lblWateringWinter.Size = new Size(140, 25);
            lblWateringWinter.TabIndex = 4;
            lblWateringWinter.Text = "Полив (зима):";
            // 
            // lblTempSummer
            // 
            lblTempSummer.Location = new Point(20, 140);
            lblTempSummer.Name = "lblTempSummer";
            lblTempSummer.Size = new Size(140, 25);
            lblTempSummer.TabIndex = 6;
            lblTempSummer.Text = "Температура (лето):";
            // 
            // lblTempWinter
            // 
            lblTempWinter.Location = new Point(20, 180);
            lblTempWinter.Name = "lblTempWinter";
            lblTempWinter.Size = new Size(140, 25);
            lblTempWinter.TabIndex = 8;
            lblTempWinter.Text = "Температура (зима):";
            // 
            // CareRequirementEditForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(634, 295);
            Controls.Add(lblLighting);
            Controls.Add(txtLighting);
            Controls.Add(lblWateringSummer);
            Controls.Add(txtWateringSummer);
            Controls.Add(lblWateringWinter);
            Controls.Add(txtWateringWinter);
            Controls.Add(lblTempSummer);
            Controls.Add(txtTempSummer);
            Controls.Add(lblTempWinter);
            Controls.Add(txtTempWinter);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CareRequirementEditForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}