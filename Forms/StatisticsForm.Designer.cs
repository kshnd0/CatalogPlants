using System.Drawing;
using System.Windows.Forms;

namespace CatalogPlants.Forms
{
    partial class StatisticsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblStatsPlants, lblStatsLifeForms, lblStatsCareReqs;
        private Label lblStatsPathogens, lblStatsActiveDiseases, lblStatsCareLogs;
        private Label lblStatsTopPlants;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblStatsPlants = new Label();
            lblStatsLifeForms = new Label();
            lblStatsCareReqs = new Label();
            lblStatsPathogens = new Label();
            lblStatsActiveDiseases = new Label();
            lblStatsCareLogs = new Label();
            lblStatsTopPlants = new Label();
            btnRefresh = new Button();
            SuspendLayout();

            Size = new Size(1150, 600);
            BackColor = Color.White;
            AutoScroll = true;

            // Заголовок
            var lblTitle = new Label();
            lblTitle.Text = "📊 СТАТИСТИКА КАТАЛОГА";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 66, 91);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(400, 40);
            Controls.Add(lblTitle);

            // Всего растений
            lblStatsPlants.Location = new Point(20, 80);
            lblStatsPlants.Size = new Size(350, 30);
            lblStatsPlants.Font = new Font("Segoe UI", 12);
            lblStatsPlants.ForeColor = Color.Black;
            lblStatsPlants.Text = "Всего растений: 0";

            // Жизненных форм
            lblStatsLifeForms.Location = new Point(20, 120);
            lblStatsLifeForms.Size = new Size(350, 30);
            lblStatsLifeForms.Font = new Font("Segoe UI", 12);
            lblStatsLifeForms.ForeColor = Color.Black;
            lblStatsLifeForms.Text = "Жизненных форм: 0";

            // Рекомендаций по уходу
            lblStatsCareReqs.Location = new Point(20, 160);
            lblStatsCareReqs.Size = new Size(350, 30);
            lblStatsCareReqs.Font = new Font("Segoe UI", 12);
            lblStatsCareReqs.ForeColor = Color.Black;
            lblStatsCareReqs.Text = "Рекомендаций по уходу: 0";

            // Патогенов
            lblStatsPathogens.Location = new Point(20, 200);
            lblStatsPathogens.Size = new Size(350, 30);
            lblStatsPathogens.Font = new Font("Segoe UI", 12);
            lblStatsPathogens.ForeColor = Color.Black;
            lblStatsPathogens.Text = "Патогенов: 0";

            // Активных заболеваний
            lblStatsActiveDiseases.Location = new Point(20, 240);
            lblStatsActiveDiseases.Size = new Size(350, 30);
            lblStatsActiveDiseases.Font = new Font("Segoe UI", 12);
            lblStatsActiveDiseases.ForeColor = Color.Black;
            lblStatsActiveDiseases.Text = "Активных заболеваний: 0";

            // Записей об уходе
            lblStatsCareLogs.Location = new Point(20, 280);
            lblStatsCareLogs.Size = new Size(350, 30);
            lblStatsCareLogs.Font = new Font("Segoe UI", 12);
            lblStatsCareLogs.ForeColor = Color.Black;
            lblStatsCareLogs.Text = "Записей об уходе: 0";

            // Топ-5 растений
            lblStatsTopPlants.Location = new Point(20, 330);
            lblStatsTopPlants.Size = new Size(600, 200);
            lblStatsTopPlants.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblStatsTopPlants.ForeColor = Color.Black;
            lblStatsTopPlants.Text = "Топ-5 растений по заболеваниям:";

            // Кнопка обновления
            btnRefresh.Text = "🔄 Обновить статистику";
            btnRefresh.Location = new Point(20, 550);
            btnRefresh.Size = new Size(200, 40);
            btnRefresh.BackColor = Color.FromArgb(33, 150, 243);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Click += BtnRefresh_Click;

            Controls.Add(lblStatsPlants);
            Controls.Add(lblStatsLifeForms);
            Controls.Add(lblStatsCareReqs);
            Controls.Add(lblStatsPathogens);
            Controls.Add(lblStatsActiveDiseases);
            Controls.Add(lblStatsCareLogs);
            Controls.Add(lblStatsTopPlants);
            Controls.Add(btnRefresh);

            ResumeLayout(false);
        }
    }
}