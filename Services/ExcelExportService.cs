using CatalogPlants.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CatalogPlants.Services
{
    public class ExcelExportService
    {
        private CatalogContext _context;

        public ExcelExportService(CatalogContext context)
        {
            _context = context;
            // Установка лицензии должна быть в статическом конструкторе или при первом использовании
        }

        static ExcelExportService()
        {
            // Устанавливаем лицензионный контекст один раз для всего приложения
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void ExportPlantsToExcel(User currentUser)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = $"Растения_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                saveFileDialog.Title = "Сохранить файл растений";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Растения");

                        worksheet.Cells[1, 1].Value = "ID";
                        worksheet.Cells[1, 2].Value = "Название";
                        worksheet.Cells[1, 3].Value = "Латинское название";
                        worksheet.Cells[1, 4].Value = "Жизненная форма";
                        worksheet.Cells[1, 5].Value = "Уход";

                        using (var range = worksheet.Cells[1, 1, 1, 5])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        var query = _context.Plants
                            .Include(p => p.LifeForm)
                            .Include(p => p.CareRequirements)
                            .AsQueryable();

                        if (currentUser.Role != "Admin")
                        {
                            query = query.Where(p => p.CreatedByUserId == currentUser.Id);
                        }

                        var plants = query.Select(p => new
                        {
                            p.PlantId,
                            p.Name,
                            p.LatinName,
                            LifeFormName = p.LifeForm != null ? p.LifeForm.Name : "Не указана",
                            CareInfo = p.CareRequirements != null ? "Есть" : "Нет"
                        }).ToList();

                        int row = 2;
                        foreach (var plant in plants)
                        {
                            worksheet.Cells[row, 1].Value = plant.PlantId;
                            worksheet.Cells[row, 2].Value = plant.Name;
                            worksheet.Cells[row, 3].Value = plant.LatinName ?? "-";
                            worksheet.Cells[row, 4].Value = plant.LifeFormName;
                            worksheet.Cells[row, 5].Value = plant.CareInfo;
                            row++;
                        }

                        worksheet.Cells.AutoFitColumns();
                        package.SaveAs(new FileInfo(saveFileDialog.FileName));

                        MessageBox.Show($"Экспортировано {plants.Count} растений!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void ExportUsersToExcel()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = $"Пользователи_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                saveFileDialog.Title = "Сохранить файл пользователей";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Пользователи");

                        worksheet.Cells[1, 1].Value = "ID";
                        worksheet.Cells[1, 2].Value = "Логин";
                        worksheet.Cells[1, 3].Value = "ФИО";
                        worksheet.Cells[1, 4].Value = "Роль";
                        worksheet.Cells[1, 5].Value = "Количество растений";

                        using (var range = worksheet.Cells[1, 1, 1, 5])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        var users = _context.Users
                            .Select(u => new
                            {
                                u.Id,
                                u.Login,
                                u.FullName,
                                u.Role,
                                PlantsCount = _context.Plants.Count(p => p.CreatedByUserId == u.Id)
                            })
                            .ToList();

                        int row = 2;
                        foreach (var user in users)
                        {
                            worksheet.Cells[row, 1].Value = user.Id;
                            worksheet.Cells[row, 2].Value = user.Login;
                            worksheet.Cells[row, 3].Value = user.FullName ?? "-";
                            worksheet.Cells[row, 4].Value = user.Role;
                            worksheet.Cells[row, 5].Value = user.PlantsCount;
                            row++;
                        }

                        worksheet.Cells.AutoFitColumns();
                        package.SaveAs(new FileInfo(saveFileDialog.FileName));

                        MessageBox.Show($"Экспортировано {users.Count} пользователей!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void ExportAllDataToExcel(User currentUser)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = $"Каталог_растений_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                saveFileDialog.Title = "Сохранить полный отчет";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        var plantSheet = package.Workbook.Worksheets.Add("Растения");
                        ExportPlantsToSheet(plantSheet, currentUser);

                        var lifeFormSheet = package.Workbook.Worksheets.Add("Жизненные формы");
                        ExportLifeFormsToSheet(lifeFormSheet, currentUser);

                        var careSheet = package.Workbook.Worksheets.Add("Рекомендации по уходу");
                        ExportCareRequirementsToSheet(careSheet, currentUser);

                        var pathogenSheet = package.Workbook.Worksheets.Add("Патогены");
                        ExportPathogensToSheet(pathogenSheet, currentUser);

                        var diseaseSheet = package.Workbook.Worksheets.Add("История болезней");
                        ExportDiseasesToSheet(diseaseSheet, currentUser);

                        var careLogSheet = package.Workbook.Worksheets.Add("Журнал ухода");
                        ExportCareLogsToSheet(careLogSheet, currentUser);

                        if (currentUser.Role == "Admin")
                        {
                            var userSheet = package.Workbook.Worksheets.Add("Пользователи");
                            ExportUsersToSheet(userSheet);
                        }

                        package.SaveAs(new FileInfo(saveFileDialog.FileName));

                        MessageBox.Show("Полный отчет успешно экспортирован!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ExportPlantsToSheet(ExcelWorksheet worksheet, User currentUser)
        {
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Название";
            worksheet.Cells[1, 3].Value = "Латинское название";
            worksheet.Cells[1, 4].Value = "Жизненная форма";
            worksheet.Cells[1, 5].Value = "Уход";

            using (var range = worksheet.Cells[1, 1, 1, 5])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }

            var query = _context.Plants
                .Include(p => p.LifeForm)
                .Include(p => p.CareRequirements)
                .AsQueryable();

            if (currentUser.Role != "Admin")
                query = query.Where(p => p.CreatedByUserId == currentUser.Id);

            var plants = query.ToList();

            int row = 2;
            foreach (var plant in plants)
            {
                worksheet.Cells[row, 1].Value = plant.PlantId;
                worksheet.Cells[row, 2].Value = plant.Name;
                worksheet.Cells[row, 3].Value = plant.LatinName ?? "-";
                worksheet.Cells[row, 4].Value = plant.LifeForm?.Name ?? "Не указана";
                worksheet.Cells[row, 5].Value = plant.CareRequirements != null ? "Есть" : "Нет";
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }

        private void ExportLifeFormsToSheet(ExcelWorksheet worksheet, User currentUser)
        {
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Название";
            worksheet.Cells[1, 3].Value = "Количество растений";

            using (var range = worksheet.Cells[1, 1, 1, 3])
                range.Style.Font.Bold = true;

            var query = _context.LifeForms.AsQueryable();
            if (currentUser.Role != "Admin")
                query = query.Where(lf => lf.CreatedByUserId == currentUser.Id);

            var lifeForms = query.ToList();

            int row = 2;
            foreach (var lf in lifeForms)
            {
                worksheet.Cells[row, 1].Value = lf.LifeFormId;
                worksheet.Cells[row, 2].Value = lf.Name;
                worksheet.Cells[row, 3].Value = lf.Plants.Count;
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }

        private void ExportCareRequirementsToSheet(ExcelWorksheet worksheet, User currentUser)
        {
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Освещение";
            worksheet.Cells[1, 3].Value = "Полив (лето)";
            worksheet.Cells[1, 4].Value = "Полив (зима)";
            worksheet.Cells[1, 5].Value = "Температура (лето)";
            worksheet.Cells[1, 6].Value = "Температура (зима)";

            using (var range = worksheet.Cells[1, 1, 1, 6])
                range.Style.Font.Bold = true;

            var query = _context.CareRequirements.AsQueryable();
            if (currentUser.Role != "Admin")
                query = query.Where(cr => cr.CreatedByUserId == currentUser.Id);

            var careReqs = query.ToList();

            int row = 2;
            foreach (var cr in careReqs)
            {
                worksheet.Cells[row, 1].Value = cr.CareRequirementsId;
                worksheet.Cells[row, 2].Value = cr.Lighting ?? "-";
                worksheet.Cells[row, 3].Value = cr.WateringSummer ?? "-";
                worksheet.Cells[row, 4].Value = cr.WateringWinter ?? "-";
                worksheet.Cells[row, 5].Value = cr.TemperatureSummer ?? "-";
                worksheet.Cells[row, 6].Value = cr.TemperatureWinter ?? "-";
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }

        private void ExportPathogensToSheet(ExcelWorksheet worksheet, User currentUser)
        {
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Название";
            worksheet.Cells[1, 3].Value = "Описание";
            worksheet.Cells[1, 4].Value = "Количество заболеваний";

            using (var range = worksheet.Cells[1, 1, 1, 4])
                range.Style.Font.Bold = true;

            var query = _context.Pathogens.AsQueryable();
            if (currentUser.Role != "Admin")
                query = query.Where(p => p.CreatedByUserId == currentUser.Id);

            var pathogens = query.ToList();

            int row = 2;
            foreach (var p in pathogens)
            {
                worksheet.Cells[row, 1].Value = p.PathogenId;
                worksheet.Cells[row, 2].Value = p.Name;
                worksheet.Cells[row, 3].Value = p.Description ?? "-";
                worksheet.Cells[row, 4].Value = p.DiseaseHistories.Count;
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }

        private void ExportDiseasesToSheet(ExcelWorksheet worksheet, User currentUser)
        {
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Растение";
            worksheet.Cells[1, 3].Value = "Патоген";
            worksheet.Cells[1, 4].Value = "Дата начала";
            worksheet.Cells[1, 5].Value = "Дата окончания";
            worksheet.Cells[1, 6].Value = "Статус";
            worksheet.Cells[1, 7].Value = "Описание";

            using (var range = worksheet.Cells[1, 1, 1, 7])
                range.Style.Font.Bold = true;

            var query = _context.DiseaseHistories
                .Include(d => d.Plant)
                .Include(d => d.Pathogen)
                .AsQueryable();

            if (currentUser.Role != "Admin")
                query = query.Where(d => d.CreatedByUserId == currentUser.Id);

            var diseases = query.ToList();

            int row = 2;
            foreach (var d in diseases)
            {
                worksheet.Cells[row, 1].Value = d.DiseaseHistoryId;
                worksheet.Cells[row, 2].Value = d.Plant?.Name ?? "Не указано";
                worksheet.Cells[row, 3].Value = d.Pathogen?.Name ?? "Не указан";
                worksheet.Cells[row, 4].Value = d.StartDate.ToString("dd.MM.yyyy");
                worksheet.Cells[row, 5].Value = d.EndDate?.ToString("dd.MM.yyyy") ?? "—";
                worksheet.Cells[row, 6].Value = d.EndDate.HasValue ? "Вылечено" : "Болеет";
                worksheet.Cells[row, 7].Value = d.Description ?? "-";
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }

        private void ExportCareLogsToSheet(ExcelWorksheet worksheet, User currentUser)
        {
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Растение";
            worksheet.Cells[1, 3].Value = "Дата и время";
            worksheet.Cells[1, 4].Value = "Описание";

            using (var range = worksheet.Cells[1, 1, 1, 4])
                range.Style.Font.Bold = true;

            var query = _context.CareLogs
                .Include(cl => cl.Plant)
                .AsQueryable();

            if (currentUser.Role != "Admin")
                query = query.Where(cl => cl.CreatedByUserId == currentUser.Id);

            var careLogs = query.OrderByDescending(cl => cl.DateTime).ToList();

            int row = 2;
            foreach (var cl in careLogs)
            {
                worksheet.Cells[row, 1].Value = cl.CareLogId;
                worksheet.Cells[row, 2].Value = cl.Plant?.Name ?? "Не указано";
                worksheet.Cells[row, 3].Value = cl.DateTime.ToString("dd.MM.yyyy HH:mm");
                worksheet.Cells[row, 4].Value = cl.Description ?? "-";
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }

        private void ExportUsersToSheet(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Логин";
            worksheet.Cells[1, 3].Value = "ФИО";
            worksheet.Cells[1, 4].Value = "Роль";
            worksheet.Cells[1, 5].Value = "Количество растений";

            using (var range = worksheet.Cells[1, 1, 1, 5])
                range.Style.Font.Bold = true;

            var users = _context.Users.ToList();

            int row = 2;
            foreach (var u in users)
            {
                worksheet.Cells[row, 1].Value = u.Id;
                worksheet.Cells[row, 2].Value = u.Login;
                worksheet.Cells[row, 3].Value = u.FullName ?? "-";
                worksheet.Cells[row, 4].Value = u.Role;
                worksheet.Cells[row, 5].Value = _context.Plants.Count(p => p.CreatedByUserId == u.Id);
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }
    }
}