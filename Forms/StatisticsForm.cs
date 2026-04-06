using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;

namespace CatalogPlants.Forms
{
    public partial class StatisticsForm : Form
    {
        private CatalogContext _context;

        public StatisticsForm(CatalogContext context)
        {
            _context = context;
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            int totalPlants = _context.Plants.Count();
            int totalLifeForms = _context.LifeForms.Count();
            int totalCareReqs = _context.CareRequirements.Count();
            int totalPathogens = _context.Pathogens.Count();
            int activeDiseases = _context.DiseaseHistories.Count(d => !d.EndDate.HasValue);
            int totalCareLogs = _context.CareLogs.Count();

            // ВАЖНО: сохраняем текст с описанием, а не только цифры
            lblStatsPlants.Text = $"Всего растений: {totalPlants}";
            lblStatsLifeForms.Text = $"Жизненных форм: {totalLifeForms}";
            lblStatsCareReqs.Text = $"Рекомендаций по уходу: {totalCareReqs}";
            lblStatsPathogens.Text = $"Патогенов: {totalPathogens}";
            lblStatsActiveDiseases.Text = $"Активных заболеваний: {activeDiseases}";
            lblStatsCareLogs.Text = $"Записей об уходе: {totalCareLogs}";

            var topPlants = _context.DiseaseHistories
                .Where(d => d.Plant != null)
                .GroupBy(d => d.Plant.Name)
                .Select(g => new { Plant = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            string topPlantsText = "🌿 Топ-5 растений по заболеваниям:\n\n";
            if (topPlants.Count > 0)
            {
                for (int i = 0; i < topPlants.Count; i++)
                {
                    topPlantsText += $"{i + 1}. {topPlants[i].Plant} — {topPlants[i].Count} случаев\n";
                }
            }
            else
            {
                topPlantsText += "Нет данных о заболеваниях";
            }

            lblStatsTopPlants.Text = topPlantsText;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }
    }
}