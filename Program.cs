using System;
using System.Windows.Forms;
using CatalogPlants.Forms;
using OfficeOpenXml;

namespace CatalogPlants
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(loginForm.CurrentUser));
                }
            }
        }
    }
}