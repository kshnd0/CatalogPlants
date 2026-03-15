using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CatalogPlants.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogPlants
{
    public partial class PlantCatalogForm : Form
    {
        private CatalogContext _context;

        public PlantCatalogForm()
        {
            InitializeComponent();
            _context = new CatalogContext();
            LoadAllData();
            SetupFormStyle();
        }

        private void SetupFormStyle()
        {
            // Настройка стиля формы
            this.BackColor = Color.FromArgb(240, 248, 255); // Светло-голубой фон
            this.Font = new Font("Segoe UI", 10F);

            // Настройка TabControl
            tabControlMain.Appearance = TabAppearance.FlatButtons;
            tabControlMain.ItemSize = new Size(120, 40);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabControlMain.BackColor = Color.FromArgb(45, 66, 91); // Темно-синий
            tabControlMain.ForeColor = Color.White;
        }

        private void LoadAllData()
        {
            try
            {
                LoadPlants();
                LoadLifeForms();
                LoadCareRequirements();
                LoadCareLogs();
                LoadPathogens();
                LoadDiseaseHistory();
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Растения (Plants)
        private void LoadPlants()
        {
            var plants = _context.Plants
                .Include(p => p.LifeForm)
                .Include(p => p.CareRequirements)
                .Select(p => new
                {
                    p.PlantId,
                    Название = p.Name,
                    Латинское_название = p.LatinName ?? "-",
                    Жизненная_форма = p.LifeForm != null ? p.LifeForm.Name : "Не указана",
                    Уход = p.CareRequirements != null ? "Есть рекомендации" : "Не указан"
                })
                .ToList();

            dgvPlants.DataSource = plants;
            StyleDataGridView(dgvPlants);

            // Скрываем колонку ID
            if (dgvPlants.Columns.Contains("PlantId"))
                dgvPlants.Columns["PlantId"].Visible = false;

            // Явно устанавливаем цвет текста для всех колонок
            foreach (DataGridViewColumn col in dgvPlants.Columns)
            {
                col.DefaultCellStyle.ForeColor = Color.Black;
            }

            // Загрузка данных для комбобоксов
            cmbPlantLifeForm.DataSource = _context.LifeForms.ToList();
            cmbPlantLifeForm.DisplayMember = "Name";
            cmbPlantLifeForm.ValueMember = "LifeFormId";

            cmbPlantCareRequirement.DataSource = _context.CareRequirements.ToList();
            cmbPlantCareRequirement.DisplayMember = "CareRequirementsId";
            cmbPlantCareRequirement.Format += (s, e) =>
            {
                if (e.ListItem is CareRequirement cr)
                    e.Value = $"ID: {cr.CareRequirementsId}";
            };
        }

        private void btnAddPlant_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPlantName.Text))
                {
                    MessageBox.Show("Введите название растения", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var plant = new Plant
                {
                    Name = txtPlantName.Text,
                    LatinName = txtLatinName.Text,
                    LifeFormId = cmbPlantLifeForm.SelectedValue as int?,
                    CareRequirementsId = cmbPlantCareRequirement.SelectedValue as int?
                };

                _context.Plants.Add(plant);
                _context.SaveChanges();
                LoadPlants();
                ClearPlantFields();

                MessageBox.Show("Растение успешно добавлено!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePlant_Click(object sender, EventArgs e)
        {
            if (dgvPlants.SelectedRows.Count > 0)
            {
                try
                {
                    dynamic selectedPlant = dgvPlants.SelectedRows[0].DataBoundItem;
                    int plantId = selectedPlant.PlantId;
                    var plant = _context.Plants.Find(plantId);

                    if (plant != null)
                    {
                        plant.Name = txtPlantName.Text;
                        plant.LatinName = txtLatinName.Text;
                        plant.LifeFormId = cmbPlantLifeForm.SelectedValue as int?;
                        plant.CareRequirementsId = cmbPlantCareRequirement.SelectedValue as int?;

                        _context.SaveChanges();
                        LoadPlants();

                        MessageBox.Show("Растение обновлено!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeletePlant_Click(object sender, EventArgs e)
        {
            if (dgvPlants.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Удалить растение? Это также удалит все связанные записи!",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dynamic selectedPlant = dgvPlants.SelectedRows[0].DataBoundItem;
                        int plantId = selectedPlant.PlantId;
                        var plant = _context.Plants.Find(plantId);

                        if (plant != null)
                        {
                            _context.Plants.Remove(plant);
                            _context.SaveChanges();
                            LoadPlants();
                            ClearPlantFields();

                            MessageBox.Show("Растение удалено!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvPlants_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlants.SelectedRows.Count > 0)
            {
                dynamic selectedPlant = dgvPlants.SelectedRows[0].DataBoundItem;
                int plantId = selectedPlant.PlantId;
                var plant = _context.Plants.Find(plantId);

                if (plant != null)
                {
                    txtPlantName.Text = plant.Name;
                    txtLatinName.Text = plant.LatinName;
                    cmbPlantLifeForm.SelectedValue = plant.LifeFormId;
                    cmbPlantCareRequirement.SelectedValue = plant.CareRequirementsId;
                }
            }
        }

        private void ClearPlantFields()
        {
            txtPlantName.Clear();
            txtLatinName.Clear();
            cmbPlantLifeForm.SelectedIndex = -1;
            cmbPlantCareRequirement.SelectedIndex = -1;
        }
        #endregion

        #region Жизненные формы (LifeForms)
        private void LoadLifeForms()
        {
            var lifeForms = _context.LifeForms
                .Select(lf => new
                {
                    lf.LifeFormId,
                    lf.Name,
                    PlantsCount = lf.Plants.Count
                })
                .ToList();

            dgvLifeForms.DataSource = lifeForms;
            StyleDataGridView(dgvLifeForms);

            if (dgvLifeForms.Columns.Contains("LifeFormId"))
                dgvLifeForms.Columns["LifeFormId"].Visible = false;
            if (dgvLifeForms.Columns.Contains("Name"))
                dgvLifeForms.Columns["Name"].HeaderText = "Название";
            if (dgvLifeForms.Columns.Contains("PlantsCount"))
                dgvLifeForms.Columns["PlantsCount"].HeaderText = "Количество растений";
        }

        private void btnAddLifeForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLifeFormName.Text))
                {
                    MessageBox.Show("Введите название жизненной формы");
                    return;
                }

                var lifeForm = new LifeForm
                {
                    Name = txtLifeFormName.Text
                };

                _context.LifeForms.Add(lifeForm);
                _context.SaveChanges();
                LoadLifeForms();
                txtLifeFormName.Clear();

                // Обновляем комбобоксы в других вкладках
                LoadPlants();

                MessageBox.Show("Жизненная форма добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnDeleteLifeForm_Click(object sender, EventArgs e)
        {
            if (dgvLifeForms.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Удалить жизненную форму?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dynamic selected = dgvLifeForms.SelectedRows[0].DataBoundItem;
                        int id = selected.LifeFormId;
                        var lifeForm = _context.LifeForms.Find(id);

                        if (lifeForm != null)
                        {
                            _context.LifeForms.Remove(lifeForm);
                            _context.SaveChanges();
                            LoadLifeForms();
                            LoadPlants();

                            MessageBox.Show("Жизненная форма удалена!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }
        #endregion

        #region Рекомендации по уходу (CareRequirements)
        private void LoadCareRequirements()
        {
            var careReqs = _context.CareRequirements
                .Select(cr => new
                {
                    cr.CareRequirementsId,
                    cr.Lighting,
                    cr.WateringSummer,
                    cr.WateringWinter,
                    cr.TemperatureSummer,
                    cr.TemperatureWinter,
                    PlantsCount = cr.Plants.Count
                })
                .ToList();

            dgvCareRequirements.DataSource = careReqs;
            StyleDataGridView(dgvCareRequirements);

            if (dgvCareRequirements.Columns.Contains("CareRequirementsId"))
                dgvCareRequirements.Columns["CareRequirementsId"].Visible = false;
            if (dgvCareRequirements.Columns.Contains("Lighting"))
                dgvCareRequirements.Columns["Lighting"].HeaderText = "Освещение";
            if (dgvCareRequirements.Columns.Contains("WateringSummer"))
                dgvCareRequirements.Columns["WateringSummer"].HeaderText = "Полив (лето)";
            if (dgvCareRequirements.Columns.Contains("WateringWinter"))
                dgvCareRequirements.Columns["WateringWinter"].HeaderText = "Полив (зима)";
            if (dgvCareRequirements.Columns.Contains("TemperatureSummer"))
                dgvCareRequirements.Columns["TemperatureSummer"].HeaderText = "Температура (лето)";
            if (dgvCareRequirements.Columns.Contains("TemperatureWinter"))
                dgvCareRequirements.Columns["TemperatureWinter"].HeaderText = "Температура (зима)";
        }

        private void btnAddCareRequirement_Click(object sender, EventArgs e)
        {
            try
            {
                var careReq = new CareRequirement
                {
                    Lighting = txtLighting.Text,
                    WateringSummer = txtWateringSummer.Text,
                    WateringWinter = txtWateringWinter.Text,
                    TemperatureSummer = txtTempSummer.Text,
                    TemperatureWinter = txtTempWinter.Text
                };

                _context.CareRequirements.Add(careReq);
                _context.SaveChanges();
                LoadCareRequirements();
                ClearCareRequirementFields();

                // Обновляем комбобоксы в растениях
                LoadPlants();

                MessageBox.Show("Рекомендации по уходу добавлены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnUpdateCareRequirement_Click(object sender, EventArgs e)
        {
            if (dgvCareRequirements.SelectedRows.Count > 0)
            {
                try
                {
                    dynamic selected = dgvCareRequirements.SelectedRows[0].DataBoundItem;
                    int id = selected.CareRequirementsId;
                    var careReq = _context.CareRequirements.Find(id);

                    if (careReq != null)
                    {
                        careReq.Lighting = txtLighting.Text;
                        careReq.WateringSummer = txtWateringSummer.Text;
                        careReq.WateringWinter = txtWateringWinter.Text;
                        careReq.TemperatureSummer = txtTempSummer.Text;
                        careReq.TemperatureWinter = txtTempWinter.Text;

                        _context.SaveChanges();
                        LoadCareRequirements();

                        MessageBox.Show("Рекомендации обновлены!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void btnDeleteCareRequirement_Click(object sender, EventArgs e)
        {
            if (dgvCareRequirements.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Удалить рекомендации по уходу?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dynamic selected = dgvCareRequirements.SelectedRows[0].DataBoundItem;
                        int id = selected.CareRequirementsId;
                        var careReq = _context.CareRequirements.Find(id);

                        if (careReq != null)
                        {
                            _context.CareRequirements.Remove(careReq);
                            _context.SaveChanges();
                            LoadCareRequirements();
                            ClearCareRequirementFields();
                            LoadPlants();

                            MessageBox.Show("Рекомендации удалены!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }

        private void dgvCareRequirements_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCareRequirements.SelectedRows.Count > 0)
            {
                dynamic selected = dgvCareRequirements.SelectedRows[0].DataBoundItem;
                int id = selected.CareRequirementsId;
                var careReq = _context.CareRequirements.Find(id);

                if (careReq != null)
                {
                    txtLighting.Text = careReq.Lighting;
                    txtWateringSummer.Text = careReq.WateringSummer;
                    txtWateringWinter.Text = careReq.WateringWinter;
                    txtTempSummer.Text = careReq.TemperatureSummer;
                    txtTempWinter.Text = careReq.TemperatureWinter;
                }
            }
        }

        private void ClearCareRequirementFields()
        {
            txtLighting.Clear();
            txtWateringSummer.Clear();
            txtWateringWinter.Clear();
            txtTempSummer.Clear();
            txtTempWinter.Clear();
        }
        #endregion

        #region Журнал ухода (CareLogs)
        private void LoadCareLogs()
        {
            var careLogs = _context.CareLogs
                .Include(cl => cl.Plant)
                .Select(cl => new
                {
                    cl.CareLogId,
                    PlantName = cl.Plant != null ? cl.Plant.Name : "Не указано",
                    cl.DateTime,
                    cl.Description
                })
                .OrderByDescending(cl => cl.DateTime)
                .ToList();

            dgvCareLogs.DataSource = careLogs;
            StyleDataGridView(dgvCareLogs);

            if (dgvCareLogs.Columns.Contains("CareLogId"))
                dgvCareLogs.Columns["CareLogId"].Visible = false;
            if (dgvCareLogs.Columns.Contains("PlantName"))
                dgvCareLogs.Columns["PlantName"].HeaderText = "Растение";
            if (dgvCareLogs.Columns.Contains("DateTime"))
                dgvCareLogs.Columns["DateTime"].HeaderText = "Дата и время";
            if (dgvCareLogs.Columns.Contains("Description"))
                dgvCareLogs.Columns["Description"].HeaderText = "Описание";

            // Загрузка растений для комбобокса
            cmbCareLogPlant.DataSource = _context.Plants.ToList();
            cmbCareLogPlant.DisplayMember = "Name";
            cmbCareLogPlant.ValueMember = "PlantId";
        }

        private void btnAddCareLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCareLogPlant.SelectedValue == null)
                {
                    MessageBox.Show("Выберите растение");
                    return;
                }

                var careLog = new CareLog
                {
                    PlantId = (int)cmbCareLogPlant.SelectedValue,
                    DateTime = dtpCareLogDate.Value,
                    Description = txtCareLogDescription.Text
                };

                _context.CareLogs.Add(careLog);
                _context.SaveChanges();
                LoadCareLogs();
                ClearCareLogFields();

                MessageBox.Show("Запись об уходе добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnDeleteCareLog_Click(object sender, EventArgs e)
        {
            if (dgvCareLogs.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Удалить запись об уходе?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dynamic selected = dgvCareLogs.SelectedRows[0].DataBoundItem;
                        int id = selected.CareLogId;
                        var careLog = _context.CareLogs.Find(id);

                        if (careLog != null)
                        {
                            _context.CareLogs.Remove(careLog);
                            _context.SaveChanges();
                            LoadCareLogs();

                            MessageBox.Show("Запись удалена!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }

        private void ClearCareLogFields()
        {
            cmbCareLogPlant.SelectedIndex = -1;
            dtpCareLogDate.Value = DateTime.Now;
            txtCareLogDescription.Clear();
        }
        #endregion

        #region Патогены (Pathogens)
        private void LoadPathogens()
        {
            var pathogens = _context.Pathogens
                .Select(p => new
                {
                    p.PathogenId,
                    p.Name,
                    p.Description,
                    DiseasesCount = p.DiseaseHistories.Count
                })
                .ToList();

            dgvPathogens.DataSource = pathogens;
            StyleDataGridView(dgvPathogens);

            if (dgvPathogens.Columns.Contains("PathogenId"))
                dgvPathogens.Columns["PathogenId"].Visible = false;
            if (dgvPathogens.Columns.Contains("Name"))
                dgvPathogens.Columns["Name"].HeaderText = "Название";
            if (dgvPathogens.Columns.Contains("Description"))
                dgvPathogens.Columns["Description"].HeaderText = "Описание";
            if (dgvPathogens.Columns.Contains("DiseasesCount"))
                dgvPathogens.Columns["DiseasesCount"].HeaderText = "Количество заболеваний";
        }

        private void btnAddPathogen_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPathogenName.Text))
                {
                    MessageBox.Show("Введите название патогена");
                    return;
                }

                var pathogen = new Pathogen
                {
                    Name = txtPathogenName.Text,
                    Description = txtPathogenDescription.Text
                };

                _context.Pathogens.Add(pathogen);
                _context.SaveChanges();
                LoadPathogens();
                ClearPathogenFields();

                // Обновляем комбобоксы в истории болезней
                LoadDiseaseHistory();

                MessageBox.Show("Патоген добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnUpdatePathogen_Click(object sender, EventArgs e)
        {
            if (dgvPathogens.SelectedRows.Count > 0)
            {
                try
                {
                    dynamic selected = dgvPathogens.SelectedRows[0].DataBoundItem;
                    int id = selected.PathogenId;
                    var pathogen = _context.Pathogens.Find(id);

                    if (pathogen != null)
                    {
                        pathogen.Name = txtPathogenName.Text;
                        pathogen.Description = txtPathogenDescription.Text;

                        _context.SaveChanges();
                        LoadPathogens();

                        MessageBox.Show("Патоген обновлен!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void btnDeletePathogen_Click(object sender, EventArgs e)
        {
            if (dgvPathogens.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Удалить патоген?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dynamic selected = dgvPathogens.SelectedRows[0].DataBoundItem;
                        int id = selected.PathogenId;
                        var pathogen = _context.Pathogens.Find(id);

                        if (pathogen != null)
                        {
                            _context.Pathogens.Remove(pathogen);
                            _context.SaveChanges();
                            LoadPathogens();
                            ClearPathogenFields();
                            LoadDiseaseHistory();

                            MessageBox.Show("Патоген удален!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }

        private void dgvPathogens_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPathogens.SelectedRows.Count > 0)
            {
                dynamic selected = dgvPathogens.SelectedRows[0].DataBoundItem;
                int id = selected.PathogenId;
                var pathogen = _context.Pathogens.Find(id);

                if (pathogen != null)
                {
                    txtPathogenName.Text = pathogen.Name;
                    txtPathogenDescription.Text = pathogen.Description;
                }
            }
        }

        private void ClearPathogenFields()
        {
            txtPathogenName.Clear();
            txtPathogenDescription.Clear();
        }
        #endregion

        #region История болезней (DiseaseHistory)
        private void LoadDiseaseHistory()
        {
            var diseases = _context.DiseaseHistories
                .Include(d => d.Plant)
                .Include(d => d.Pathogen)
                .Select(d => new
                {
                    d.DiseaseHistoryId,
                    PlantName = d.Plant != null ? d.Plant.Name : "Не указано",
                    PathogenName = d.Pathogen != null ? d.Pathogen.Name : "Не указан",
                    d.StartDate,
                    d.EndDate,
                    d.Description,
                    Status = d.EndDate.HasValue ? "Вылечено" : "Болеет",
                    Duration = d.EndDate.HasValue ?
                        (d.EndDate.Value - d.StartDate).Days.ToString() + " дней" : "Болеет"
                })
                .OrderByDescending(d => d.StartDate)
                .ToList();

            dgvDiseaseHistory.DataSource = diseases;
            StyleDataGridView(dgvDiseaseHistory);

            if (dgvDiseaseHistory.Columns.Contains("DiseaseHistoryId"))
                dgvDiseaseHistory.Columns["DiseaseHistoryId"].Visible = false;
            if (dgvDiseaseHistory.Columns.Contains("PlantName"))
                dgvDiseaseHistory.Columns["PlantName"].HeaderText = "Растение";
            if (dgvDiseaseHistory.Columns.Contains("PathogenName"))
                dgvDiseaseHistory.Columns["PathogenName"].HeaderText = "Патоген";
            if (dgvDiseaseHistory.Columns.Contains("StartDate"))
                dgvDiseaseHistory.Columns["StartDate"].HeaderText = "Дата начала";
            if (dgvDiseaseHistory.Columns.Contains("EndDate"))
                dgvDiseaseHistory.Columns["EndDate"].HeaderText = "Дата окончания";
            if (dgvDiseaseHistory.Columns.Contains("Description"))
                dgvDiseaseHistory.Columns["Description"].HeaderText = "Описание";
            if (dgvDiseaseHistory.Columns.Contains("Status"))
                dgvDiseaseHistory.Columns["Status"].HeaderText = "Статус";
            if (dgvDiseaseHistory.Columns.Contains("Duration"))
                dgvDiseaseHistory.Columns["Duration"].HeaderText = "Длительность";

            // Загрузка данных для комбобоксов
            cmbDiseasePlant.DataSource = _context.Plants.ToList();
            cmbDiseasePlant.DisplayMember = "Name";
            cmbDiseasePlant.ValueMember = "PlantId";

            cmbDiseasePathogen.DataSource = _context.Pathogens.ToList();
            cmbDiseasePathogen.DisplayMember = "Name";
            cmbDiseasePathogen.ValueMember = "PathogenId";
        }

        private void btnAddDisease_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDiseasePlant.SelectedValue == null)
                {
                    MessageBox.Show("Выберите растение");
                    return;
                }

                var disease = new DiseaseHistory
                {
                    PlantId = (int)cmbDiseasePlant.SelectedValue,
                    PathogenId = cmbDiseasePathogen.SelectedValue as int?,
                    StartDate = dtpDiseaseStart.Value,
                    EndDate = chkDiseaseCured.Checked ? dtpDiseaseEnd.Value : (DateTime?)null,
                    Description = txtDiseaseDescription.Text
                };

                _context.DiseaseHistories.Add(disease);
                _context.SaveChanges();
                LoadDiseaseHistory();
                ClearDiseaseFields();

                MessageBox.Show("Запись о болезни добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnUpdateDisease_Click(object sender, EventArgs e)
        {
            if (dgvDiseaseHistory.SelectedRows.Count > 0)
            {
                try
                {
                    dynamic selected = dgvDiseaseHistory.SelectedRows[0].DataBoundItem;
                    int id = selected.DiseaseHistoryId;
                    var disease = _context.DiseaseHistories.Find(id);

                    if (disease != null)
                    {
                        disease.PlantId = (int)cmbDiseasePlant.SelectedValue;
                        disease.PathogenId = cmbDiseasePathogen.SelectedValue as int?;
                        disease.StartDate = dtpDiseaseStart.Value;
                        disease.EndDate = chkDiseaseCured.Checked ? dtpDiseaseEnd.Value : (DateTime?)null;
                        disease.Description = txtDiseaseDescription.Text;

                        _context.SaveChanges();
                        LoadDiseaseHistory();

                        MessageBox.Show("Запись обновлена!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void btnDeleteDisease_Click(object sender, EventArgs e)
        {
            if (dgvDiseaseHistory.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Удалить запись о болезни?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dynamic selected = dgvDiseaseHistory.SelectedRows[0].DataBoundItem;
                        int id = selected.DiseaseHistoryId;
                        var disease = _context.DiseaseHistories.Find(id);

                        if (disease != null)
                        {
                            _context.DiseaseHistories.Remove(disease);
                            _context.SaveChanges();
                            LoadDiseaseHistory();
                            ClearDiseaseFields();

                            MessageBox.Show("Запись удалена!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }

        private void dgvDiseaseHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDiseaseHistory.SelectedRows.Count > 0)
            {
                dynamic selected = dgvDiseaseHistory.SelectedRows[0].DataBoundItem;
                int id = selected.DiseaseHistoryId;
                var disease = _context.DiseaseHistories.Find(id);

                if (disease != null)
                {
                    cmbDiseasePlant.SelectedValue = disease.PlantId;
                    cmbDiseasePathogen.SelectedValue = disease.PathogenId;
                    dtpDiseaseStart.Value = disease.StartDate;
                    if (disease.EndDate.HasValue)
                    {
                        dtpDiseaseEnd.Value = disease.EndDate.Value;
                        chkDiseaseCured.Checked = true;
                    }
                    else
                    {
                        chkDiseaseCured.Checked = false;
                    }
                    txtDiseaseDescription.Text = disease.Description;
                }
            }
        }

        private void chkDiseaseCured_CheckedChanged(object sender, EventArgs e)
        {
            dtpDiseaseEnd.Enabled = chkDiseaseCured.Checked;
        }

        private void ClearDiseaseFields()
        {
            cmbDiseasePlant.SelectedIndex = -1;
            cmbDiseasePathogen.SelectedIndex = -1;
            dtpDiseaseStart.Value = DateTime.Now;
            dtpDiseaseEnd.Value = DateTime.Now;
            chkDiseaseCured.Checked = false;
            txtDiseaseDescription.Clear();
        }
        #endregion

        #region Статистика
        private void LoadStatistics()
        {
            try
            {
                int totalPlants = _context.Plants.Count();
                int totalLifeForms = _context.LifeForms.Count();
                int totalCareReqs = _context.CareRequirements.Count();
                int totalPathogens = _context.Pathogens.Count();
                int activeDiseases = _context.DiseaseHistories.Count(d => !d.EndDate.HasValue);
                int totalCareLogs = _context.CareLogs.Count();

                lblStatsPlants.Text = $"Всего растений: {totalPlants}";
                lblStatsLifeForms.Text = $"Жизненных форм: {totalLifeForms}";
                lblStatsCareReqs.Text = $"Рекомендаций по уходу: {totalCareReqs}";
                lblStatsPathogens.Text = $"Патогенов: {totalPathogens}";
                lblStatsActiveDiseases.Text = $"Активных заболеваний: {activeDiseases}";
                lblStatsCareLogs.Text = $"Записей об уходе: {totalCareLogs}";

                // Самые популярные растения по заболеваниям
                var topPlants = _context.DiseaseHistories
                    .GroupBy(d => d.Plant.Name)
                    .Select(g => new { Plant = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(5)
                    .ToList();

                string topPlantsText = "Топ-5 растений по заболеваниям:\n";
                foreach (var item in topPlants)
                {
                    topPlantsText += $"- {item.Plant}: {item.Count} случаев\n";
                }
                lblStatsTopPlants.Text = topPlantsText;
            }
            catch (Exception ex)
            {
                // Игнорируем ошибки статистики
            }
        }

        private void btnRefreshStats_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }
        #endregion

        #region Вспомогательные методы
        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.LightGray;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            // ==== ВАЖНО: цвет текста по умолчанию ====
            dgv.DefaultCellStyle.ForeColor = Color.Black;  // Черный текст
            dgv.DefaultCellStyle.BackColor = Color.White;  // Белый фон
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            // ==== Цвет выделенной строки ====
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(76, 175, 80);  // Зеленый
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;  // Белый текст при выделении

            // ==== Цвет строк через одну (для лучшей читаемости) ====
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);  // Светло-голубой
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // Стиль заголовков
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 66, 91);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            dgv.RowTemplate.Height = 30;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtGlobalSearch.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadPlants();
            }
            else
            {
                var filteredPlants = _context.Plants
                    .Where(p => p.Name.ToLower().Contains(searchText) ||
                               (p.LatinName != null && p.LatinName.ToLower().Contains(searchText)))
                    .Select(p => new
                    {
                        p.PlantId,
                        p.Name,
                        p.LatinName,
                        LifeForm = p.LifeForm != null ? p.LifeForm.Name : "Не указана"
                    })
                    .ToList();

                dgvPlants.DataSource = filteredPlants;
            }
        }
        #endregion
    }
}