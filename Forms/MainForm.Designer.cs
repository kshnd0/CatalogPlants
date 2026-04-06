using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControlMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControlMain = new TabControl();
            SuspendLayout();

            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 10F);
            tabControlMain.Appearance = TabAppearance.FlatButtons;
            tabControlMain.ItemSize = new Size(120, 40);
            tabControlMain.SizeMode = TabSizeMode.Fixed;

            Controls.Add(tabControlMain);

            ResumeLayout(false);
        }
    }
}