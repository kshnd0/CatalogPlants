using CatalogPlants;
namespace CatalogPlants
{
    partial class PlantCatalogForm
    {
        private System.ComponentModel.IContainer components = null;

        // Основные компоненты
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePlants;
        private System.Windows.Forms.TabPage tabPageLifeForms;
        private System.Windows.Forms.TabPage tabPageCareRequirements;
        private System.Windows.Forms.TabPage tabPageCareLogs;
        private System.Windows.Forms.TabPage tabPagePathogens;
        private System.Windows.Forms.TabPage tabPageDiseaseHistory;
        private System.Windows.Forms.TabPage tabPageStatistics;

        // Общие компоненты
        private System.Windows.Forms.TextBox txtGlobalSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label labelTitle;

        // ===== Вкладка Растения (Plants) =====
        private System.Windows.Forms.DataGridView dgvPlants;
        private System.Windows.Forms.GroupBox groupBoxPlantInfo;
        private System.Windows.Forms.Label lblPlantName;
        private System.Windows.Forms.TextBox txtPlantName;
        private System.Windows.Forms.Label lblLatinName;
        private System.Windows.Forms.TextBox txtLatinName;
        private System.Windows.Forms.Label lblPlantLifeForm;
        private System.Windows.Forms.ComboBox cmbPlantLifeForm;
        private System.Windows.Forms.Label lblPlantCareRequirement;
        private System.Windows.Forms.ComboBox cmbPlantCareRequirement;
        private System.Windows.Forms.Button btnAddPlant;
        private System.Windows.Forms.Button btnUpdatePlant;
        private System.Windows.Forms.Button btnDeletePlant;
        private System.Windows.Forms.Button btnClearPlant;

        // ===== Вкладка Жизненные формы (LifeForms) =====
        private System.Windows.Forms.DataGridView dgvLifeForms;
        private System.Windows.Forms.GroupBox groupBoxLifeFormInfo;
        private System.Windows.Forms.Label lblLifeFormName;
        private System.Windows.Forms.TextBox txtLifeFormName;
        private System.Windows.Forms.Button btnAddLifeForm;
        private System.Windows.Forms.Button btnDeleteLifeForm;

        // ===== Вкладка Рекомендации по уходу (CareRequirements) =====
        private System.Windows.Forms.DataGridView dgvCareRequirements;
        private System.Windows.Forms.GroupBox groupBoxCareRequirementInfo;
        private System.Windows.Forms.Label lblLighting;
        private System.Windows.Forms.TextBox txtLighting;
        private System.Windows.Forms.Label lblWateringSummer;
        private System.Windows.Forms.TextBox txtWateringSummer;
        private System.Windows.Forms.Label lblWateringWinter;
        private System.Windows.Forms.TextBox txtWateringWinter;
        private System.Windows.Forms.Label lblTempSummer;
        private System.Windows.Forms.TextBox txtTempSummer;
        private System.Windows.Forms.Label lblTempWinter;
        private System.Windows.Forms.TextBox txtTempWinter;
        private System.Windows.Forms.Button btnAddCareRequirement;
        private System.Windows.Forms.Button btnUpdateCareRequirement;
        private System.Windows.Forms.Button btnDeleteCareRequirement;
        private System.Windows.Forms.Button btnClearCareRequirement;

        // ===== Вкладка Журнал ухода (CareLogs) =====
        private System.Windows.Forms.DataGridView dgvCareLogs;
        private System.Windows.Forms.GroupBox groupBoxCareLogInfo;
        private System.Windows.Forms.Label lblCareLogPlant;
        private System.Windows.Forms.ComboBox cmbCareLogPlant;
        private System.Windows.Forms.Label lblCareLogDate;
        private System.Windows.Forms.DateTimePicker dtpCareLogDate;
        private System.Windows.Forms.Label lblCareLogDescription;
        private System.Windows.Forms.TextBox txtCareLogDescription;
        private System.Windows.Forms.Button btnAddCareLog;
        private System.Windows.Forms.Button btnDeleteCareLog;

        // ===== Вкладка Патогены (Pathogens) =====
        private System.Windows.Forms.DataGridView dgvPathogens;
        private System.Windows.Forms.GroupBox groupBoxPathogenInfo;
        private System.Windows.Forms.Label lblPathogenName;
        private System.Windows.Forms.TextBox txtPathogenName;
        private System.Windows.Forms.Label lblPathogenDescription;
        private System.Windows.Forms.TextBox txtPathogenDescription;
        private System.Windows.Forms.Button btnAddPathogen;
        private System.Windows.Forms.Button btnUpdatePathogen;
        private System.Windows.Forms.Button btnDeletePathogen;
        private System.Windows.Forms.Button btnClearPathogen;

        // ===== Вкладка История болезней (DiseaseHistory) =====
        private System.Windows.Forms.DataGridView dgvDiseaseHistory;
        private System.Windows.Forms.GroupBox groupBoxDiseaseInfo;
        private System.Windows.Forms.Label lblDiseasePlant;
        private System.Windows.Forms.ComboBox cmbDiseasePlant;
        private System.Windows.Forms.Label lblDiseasePathogen;
        private System.Windows.Forms.ComboBox cmbDiseasePathogen;
        private System.Windows.Forms.Label lblDiseaseStart;
        private System.Windows.Forms.DateTimePicker dtpDiseaseStart;
        private System.Windows.Forms.Label lblDiseaseEnd;
        private System.Windows.Forms.DateTimePicker dtpDiseaseEnd;
        private System.Windows.Forms.CheckBox chkDiseaseCured;
        private System.Windows.Forms.Label lblDiseaseDescription;
        private System.Windows.Forms.TextBox txtDiseaseDescription;
        private System.Windows.Forms.Button btnAddDisease;
        private System.Windows.Forms.Button btnUpdateDisease;
        private System.Windows.Forms.Button btnDeleteDisease;
        private System.Windows.Forms.Button btnClearDisease;

        // ===== Вкладка Статистика (Statistics) =====
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Label lblStatsPlants;
        private System.Windows.Forms.Label lblStatsLifeForms;
        private System.Windows.Forms.Label lblStatsCareReqs;
        private System.Windows.Forms.Label lblStatsPathogens;
        private System.Windows.Forms.Label lblStatsActiveDiseases;
        private System.Windows.Forms.Label lblStatsCareLogs;
        private System.Windows.Forms.Label lblStatsTopPlants;
        private System.Windows.Forms.Button btnRefreshStats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Инициализация компонентов
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPagePlants = new System.Windows.Forms.TabPage();
            this.tabPageLifeForms = new System.Windows.Forms.TabPage();
            this.tabPageCareRequirements = new System.Windows.Forms.TabPage();
            this.tabPageCareLogs = new System.Windows.Forms.TabPage();
            this.tabPagePathogens = new System.Windows.Forms.TabPage();
            this.tabPageDiseaseHistory = new System.Windows.Forms.TabPage();
            this.tabPageStatistics = new System.Windows.Forms.TabPage();

            // Общие компоненты
            this.headerPanel = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.txtGlobalSearch = new System.Windows.Forms.TextBox();

            // Компоненты для растений
            this.dgvPlants = new System.Windows.Forms.DataGridView();
            this.groupBoxPlantInfo = new System.Windows.Forms.GroupBox();
            this.lblPlantName = new System.Windows.Forms.Label();
            this.txtPlantName = new System.Windows.Forms.TextBox();
            this.lblLatinName = new System.Windows.Forms.Label();
            this.txtLatinName = new System.Windows.Forms.TextBox();
            this.lblPlantLifeForm = new System.Windows.Forms.Label();
            this.cmbPlantLifeForm = new System.Windows.Forms.ComboBox();
            this.lblPlantCareRequirement = new System.Windows.Forms.Label();
            this.cmbPlantCareRequirement = new System.Windows.Forms.ComboBox();
            this.btnAddPlant = new System.Windows.Forms.Button();
            this.btnUpdatePlant = new System.Windows.Forms.Button();
            this.btnDeletePlant = new System.Windows.Forms.Button();
            this.btnClearPlant = new System.Windows.Forms.Button();

            // Компоненты для жизненных форм
            this.dgvLifeForms = new System.Windows.Forms.DataGridView();
            this.groupBoxLifeFormInfo = new System.Windows.Forms.GroupBox();
            this.lblLifeFormName = new System.Windows.Forms.Label();
            this.txtLifeFormName = new System.Windows.Forms.TextBox();
            this.btnAddLifeForm = new System.Windows.Forms.Button();
            this.btnDeleteLifeForm = new System.Windows.Forms.Button();

            // Компоненты для рекомендаций по уходу
            this.dgvCareRequirements = new System.Windows.Forms.DataGridView();
            this.groupBoxCareRequirementInfo = new System.Windows.Forms.GroupBox();
            this.lblLighting = new System.Windows.Forms.Label();
            this.txtLighting = new System.Windows.Forms.TextBox();
            this.lblWateringSummer = new System.Windows.Forms.Label();
            this.txtWateringSummer = new System.Windows.Forms.TextBox();
            this.lblWateringWinter = new System.Windows.Forms.Label();
            this.txtWateringWinter = new System.Windows.Forms.TextBox();
            this.lblTempSummer = new System.Windows.Forms.Label();
            this.txtTempSummer = new System.Windows.Forms.TextBox();
            this.lblTempWinter = new System.Windows.Forms.Label();
            this.txtTempWinter = new System.Windows.Forms.TextBox();
            this.btnAddCareRequirement = new System.Windows.Forms.Button();
            this.btnUpdateCareRequirement = new System.Windows.Forms.Button();
            this.btnDeleteCareRequirement = new System.Windows.Forms.Button();
            this.btnClearCareRequirement = new System.Windows.Forms.Button();

            // Компоненты для журнала ухода
            this.dgvCareLogs = new System.Windows.Forms.DataGridView();
            this.groupBoxCareLogInfo = new System.Windows.Forms.GroupBox();
            this.lblCareLogPlant = new System.Windows.Forms.Label();
            this.cmbCareLogPlant = new System.Windows.Forms.ComboBox();
            this.lblCareLogDate = new System.Windows.Forms.Label();
            this.dtpCareLogDate = new System.Windows.Forms.DateTimePicker();
            this.lblCareLogDescription = new System.Windows.Forms.Label();
            this.txtCareLogDescription = new System.Windows.Forms.TextBox();
            this.btnAddCareLog = new System.Windows.Forms.Button();
            this.btnDeleteCareLog = new System.Windows.Forms.Button();

            // Компоненты для патогенов
            this.dgvPathogens = new System.Windows.Forms.DataGridView();
            this.groupBoxPathogenInfo = new System.Windows.Forms.GroupBox();
            this.lblPathogenName = new System.Windows.Forms.Label();
            this.txtPathogenName = new System.Windows.Forms.TextBox();
            this.lblPathogenDescription = new System.Windows.Forms.Label();
            this.txtPathogenDescription = new System.Windows.Forms.TextBox();
            this.btnAddPathogen = new System.Windows.Forms.Button();
            this.btnUpdatePathogen = new System.Windows.Forms.Button();
            this.btnDeletePathogen = new System.Windows.Forms.Button();
            this.btnClearPathogen = new System.Windows.Forms.Button();

            // Компоненты для истории болезней
            this.dgvDiseaseHistory = new System.Windows.Forms.DataGridView();
            this.groupBoxDiseaseInfo = new System.Windows.Forms.GroupBox();
            this.lblDiseasePlant = new System.Windows.Forms.Label();
            this.cmbDiseasePlant = new System.Windows.Forms.ComboBox();
            this.lblDiseasePathogen = new System.Windows.Forms.Label();
            this.cmbDiseasePathogen = new System.Windows.Forms.ComboBox();
            this.lblDiseaseStart = new System.Windows.Forms.Label();
            this.dtpDiseaseStart = new System.Windows.Forms.DateTimePicker();
            this.lblDiseaseEnd = new System.Windows.Forms.Label();
            this.dtpDiseaseEnd = new System.Windows.Forms.DateTimePicker();
            this.chkDiseaseCured = new System.Windows.Forms.CheckBox();
            this.lblDiseaseDescription = new System.Windows.Forms.Label();
            this.txtDiseaseDescription = new System.Windows.Forms.TextBox();
            this.btnAddDisease = new System.Windows.Forms.Button();
            this.btnUpdateDisease = new System.Windows.Forms.Button();
            this.btnDeleteDisease = new System.Windows.Forms.Button();
            this.btnClearDisease = new System.Windows.Forms.Button();

            // Компоненты для статистики
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblStatsTitle = new System.Windows.Forms.Label();
            this.lblStatsPlants = new System.Windows.Forms.Label();
            this.lblStatsLifeForms = new System.Windows.Forms.Label();
            this.lblStatsCareReqs = new System.Windows.Forms.Label();
            this.lblStatsPathogens = new System.Windows.Forms.Label();
            this.lblStatsActiveDiseases = new System.Windows.Forms.Label();
            this.lblStatsCareLogs = new System.Windows.Forms.Label();
            this.lblStatsTopPlants = new System.Windows.Forms.Label();
            this.btnRefreshStats = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(45, 66, 91);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 80;
            this.headerPanel.Controls.Add(this.labelTitle);
            this.headerPanel.Controls.Add(this.labelSearch);
            this.headerPanel.Controls.Add(this.txtGlobalSearch);

            // 
            // labelTitle
            // 
            this.labelTitle.Text = "🌿 КАТАЛОГ РАСТЕНИЙ";
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Size = new System.Drawing.Size(400, 40);

            // 
            // labelSearch
            // 
            this.labelSearch.Text = "🔍 Поиск:";
            this.labelSearch.ForeColor = System.Drawing.Color.White;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSearch.Location = new System.Drawing.Point(700, 30);
            this.labelSearch.Size = new System.Drawing.Size(60, 25);

            // 
            // txtGlobalSearch
            // 
            this.txtGlobalSearch.Location = new System.Drawing.Point(770, 27);
            this.txtGlobalSearch.Size = new System.Drawing.Size(200, 25);
            this.txtGlobalSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGlobalSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 80);
            this.tabControlMain.Size = new System.Drawing.Size(1200, 670);
            this.tabControlMain.TabIndex = 0;

            // ========== ВКЛАДКА РАСТЕНИЯ ==========
            this.tabPagePlants.Text = "🌱 Растения";
            this.tabPagePlants.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            // dgvPlants
            this.dgvPlants.Location = new System.Drawing.Point(10, 200);
            this.dgvPlants.Size = new System.Drawing.Size(1160, 430);
            this.dgvPlants.TabIndex = 0;

            // groupBoxPlantInfo
            this.groupBoxPlantInfo.Text = "Информация о растении";
            this.groupBoxPlantInfo.Location = new System.Drawing.Point(10, 10);
            this.groupBoxPlantInfo.Size = new System.Drawing.Size(1160, 180);
            this.groupBoxPlantInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // lblPlantName
            this.lblPlantName.Text = "Название:";
            this.lblPlantName.Location = new System.Drawing.Point(10, 30);
            this.lblPlantName.Size = new System.Drawing.Size(100, 25);
            this.lblPlantName.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtPlantName
            this.txtPlantName.Location = new System.Drawing.Point(120, 27);
            this.txtPlantName.Size = new System.Drawing.Size(200, 25);

            // lblLatinName
            this.lblLatinName.Text = "Латинское название:";
            this.lblLatinName.Location = new System.Drawing.Point(330, 30);
            this.lblLatinName.Size = new System.Drawing.Size(120, 25);
            this.lblLatinName.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtLatinName
            this.txtLatinName.Location = new System.Drawing.Point(460, 27);
            this.txtLatinName.Size = new System.Drawing.Size(200, 25);

            // lblPlantLifeForm
            this.lblPlantLifeForm.Text = "Жизненная форма:";
            this.lblPlantLifeForm.Location = new System.Drawing.Point(10, 70);
            this.lblPlantLifeForm.Size = new System.Drawing.Size(100, 25);
            this.lblPlantLifeForm.Font = new System.Drawing.Font("Segoe UI", 9F);

            // cmbPlantLifeForm
            this.cmbPlantLifeForm.Location = new System.Drawing.Point(120, 67);
            this.cmbPlantLifeForm.Size = new System.Drawing.Size(200, 25);
            this.cmbPlantLifeForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblPlantCareRequirement
            this.lblPlantCareRequirement.Text = "Рекомендации по уходу:";
            this.lblPlantCareRequirement.Location = new System.Drawing.Point(330, 70);
            this.lblPlantCareRequirement.Size = new System.Drawing.Size(130, 25);
            this.lblPlantCareRequirement.Font = new System.Drawing.Font("Segoe UI", 9F);

            // cmbPlantCareRequirement
            this.cmbPlantCareRequirement.Location = new System.Drawing.Point(460, 67);
            this.cmbPlantCareRequirement.Size = new System.Drawing.Size(200, 25);
            this.cmbPlantCareRequirement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnAddPlant
            this.btnAddPlant.Text = "➕ Добавить";
            this.btnAddPlant.Location = new System.Drawing.Point(700, 27);
            this.btnAddPlant.Size = new System.Drawing.Size(100, 30);
            this.btnAddPlant.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddPlant.ForeColor = System.Drawing.Color.White;
            this.btnAddPlant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPlant.Click += new System.EventHandler(this.btnAddPlant_Click);

            // btnUpdatePlant
            this.btnUpdatePlant.Text = "✏ Обновить";
            this.btnUpdatePlant.Location = new System.Drawing.Point(810, 27);
            this.btnUpdatePlant.Size = new System.Drawing.Size(100, 30);
            this.btnUpdatePlant.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnUpdatePlant.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePlant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePlant.Click += new System.EventHandler(this.btnUpdatePlant_Click);

            // btnDeletePlant
            this.btnDeletePlant.Text = "🗑 Удалить";
            this.btnDeletePlant.Location = new System.Drawing.Point(920, 27);
            this.btnDeletePlant.Size = new System.Drawing.Size(100, 30);
            this.btnDeletePlant.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDeletePlant.ForeColor = System.Drawing.Color.White;
            this.btnDeletePlant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePlant.Click += new System.EventHandler(this.btnDeletePlant_Click);

            // btnClearPlant
            this.btnClearPlant.Text = "🧹 Очистить";
            this.btnClearPlant.Location = new System.Drawing.Point(1030, 27);
            this.btnClearPlant.Size = new System.Drawing.Size(100, 30);
            this.btnClearPlant.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
            this.btnClearPlant.ForeColor = System.Drawing.Color.White;
            this.btnClearPlant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPlant.Click += (s, e) => ClearPlantFields();

            // Добавление элементов на вкладку растений
            this.groupBoxPlantInfo.Controls.Add(this.lblPlantName);
            this.groupBoxPlantInfo.Controls.Add(this.txtPlantName);
            this.groupBoxPlantInfo.Controls.Add(this.lblLatinName);
            this.groupBoxPlantInfo.Controls.Add(this.txtLatinName);
            this.groupBoxPlantInfo.Controls.Add(this.lblPlantLifeForm);
            this.groupBoxPlantInfo.Controls.Add(this.cmbPlantLifeForm);
            this.groupBoxPlantInfo.Controls.Add(this.lblPlantCareRequirement);
            this.groupBoxPlantInfo.Controls.Add(this.cmbPlantCareRequirement);
            this.groupBoxPlantInfo.Controls.Add(this.btnAddPlant);
            this.groupBoxPlantInfo.Controls.Add(this.btnUpdatePlant);
            this.groupBoxPlantInfo.Controls.Add(this.btnDeletePlant);
            this.groupBoxPlantInfo.Controls.Add(this.btnClearPlant);

            this.tabPagePlants.Controls.Add(this.dgvPlants);
            this.tabPagePlants.Controls.Add(this.groupBoxPlantInfo);

            // ========== ВКЛАДКА ЖИЗНЕННЫЕ ФОРМЫ ==========
            this.tabPageLifeForms.Text = "🌳 Жизненные формы";
            this.tabPageLifeForms.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            // dgvLifeForms
            this.dgvLifeForms.Location = new System.Drawing.Point(10, 130);
            this.dgvLifeForms.Size = new System.Drawing.Size(1160, 500);

            // groupBoxLifeFormInfo
            this.groupBoxLifeFormInfo.Text = "Жизненная форма";
            this.groupBoxLifeFormInfo.Location = new System.Drawing.Point(10, 10);
            this.groupBoxLifeFormInfo.Size = new System.Drawing.Size(1160, 110);

            // lblLifeFormName
            this.lblLifeFormName.Text = "Название:";
            this.lblLifeFormName.Location = new System.Drawing.Point(10, 40);
            this.lblLifeFormName.Size = new System.Drawing.Size(80, 25);

            // txtLifeFormName
            this.txtLifeFormName.Location = new System.Drawing.Point(100, 37);
            this.txtLifeFormName.Size = new System.Drawing.Size(300, 25);

            // btnAddLifeForm
            this.btnAddLifeForm.Text = "➕ Добавить";
            this.btnAddLifeForm.Location = new System.Drawing.Point(420, 35);
            this.btnAddLifeForm.Size = new System.Drawing.Size(100, 30);
            this.btnAddLifeForm.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddLifeForm.ForeColor = System.Drawing.Color.White;
            this.btnAddLifeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLifeForm.Click += new System.EventHandler(this.btnAddLifeForm_Click);

            // btnDeleteLifeForm
            this.btnDeleteLifeForm.Text = "🗑 Удалить";
            this.btnDeleteLifeForm.Location = new System.Drawing.Point(530, 35);
            this.btnDeleteLifeForm.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteLifeForm.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDeleteLifeForm.ForeColor = System.Drawing.Color.White;
            this.btnDeleteLifeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLifeForm.Click += new System.EventHandler(this.btnDeleteLifeForm_Click);

            this.groupBoxLifeFormInfo.Controls.Add(this.lblLifeFormName);
            this.groupBoxLifeFormInfo.Controls.Add(this.txtLifeFormName);
            this.groupBoxLifeFormInfo.Controls.Add(this.btnAddLifeForm);
            this.groupBoxLifeFormInfo.Controls.Add(this.btnDeleteLifeForm);

            this.tabPageLifeForms.Controls.Add(this.dgvLifeForms);
            this.tabPageLifeForms.Controls.Add(this.groupBoxLifeFormInfo);

            // ========== ВКЛАДКА РЕКОМЕНДАЦИИ ПО УХОДУ ==========
            this.tabPageCareRequirements.Text = "💧 Рекомендации по уходу";
            this.tabPageCareRequirements.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            // dgvCareRequirements
            this.dgvCareRequirements.Location = new System.Drawing.Point(10, 220);
            this.dgvCareRequirements.Size = new System.Drawing.Size(1160, 410);

            // groupBoxCareRequirementInfo
            this.groupBoxCareRequirementInfo.Text = "Параметры ухода";
            this.groupBoxCareRequirementInfo.Location = new System.Drawing.Point(10, 10);
            this.groupBoxCareRequirementInfo.Size = new System.Drawing.Size(1160, 200);

            // lblLighting
            this.lblLighting.Text = "Освещение:";
            this.lblLighting.Location = new System.Drawing.Point(10, 30);
            this.lblLighting.Size = new System.Drawing.Size(100, 25);

            // txtLighting
            this.txtLighting.Location = new System.Drawing.Point(120, 27);
            this.txtLighting.Size = new System.Drawing.Size(200, 25);

            // lblWateringSummer
            this.lblWateringSummer.Text = "Полив (лето):";
            this.lblWateringSummer.Location = new System.Drawing.Point(330, 30);
            this.lblWateringSummer.Size = new System.Drawing.Size(100, 25);

            // txtWateringSummer
            this.txtWateringSummer.Location = new System.Drawing.Point(440, 27);
            this.txtWateringSummer.Size = new System.Drawing.Size(200, 25);

            // lblWateringWinter
            this.lblWateringWinter.Text = "Полив (зима):";
            this.lblWateringWinter.Location = new System.Drawing.Point(650, 30);
            this.lblWateringWinter.Size = new System.Drawing.Size(100, 25);

            // txtWateringWinter
            this.txtWateringWinter.Location = new System.Drawing.Point(760, 27);
            this.txtWateringWinter.Size = new System.Drawing.Size(200, 25);

            // lblTempSummer
            this.lblTempSummer.Text = "Температура (лето):";
            this.lblTempSummer.Location = new System.Drawing.Point(10, 70);
            this.lblTempSummer.Size = new System.Drawing.Size(120, 25);

            // txtTempSummer
            this.txtTempSummer.Location = new System.Drawing.Point(140, 67);
            this.txtTempSummer.Size = new System.Drawing.Size(200, 25);

            // lblTempWinter
            this.lblTempWinter.Text = "Температура (зима):";
            this.lblTempWinter.Location = new System.Drawing.Point(350, 70);
            this.lblTempWinter.Size = new System.Drawing.Size(120, 25);

            // txtTempWinter
            this.txtTempWinter.Location = new System.Drawing.Point(480, 67);
            this.txtTempWinter.Size = new System.Drawing.Size(200, 25);

            // btnAddCareRequirement
            this.btnAddCareRequirement.Text = "➕ Добавить";
            this.btnAddCareRequirement.Location = new System.Drawing.Point(10, 120);
            this.btnAddCareRequirement.Size = new System.Drawing.Size(120, 35);
            this.btnAddCareRequirement.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddCareRequirement.ForeColor = System.Drawing.Color.White;
            this.btnAddCareRequirement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCareRequirement.Click += new System.EventHandler(this.btnAddCareRequirement_Click);

            // btnUpdateCareRequirement
            this.btnUpdateCareRequirement.Text = "✏ Обновить";
            this.btnUpdateCareRequirement.Location = new System.Drawing.Point(140, 120);
            this.btnUpdateCareRequirement.Size = new System.Drawing.Size(120, 35);
            this.btnUpdateCareRequirement.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnUpdateCareRequirement.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCareRequirement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCareRequirement.Click += new System.EventHandler(this.btnUpdateCareRequirement_Click);

            // btnDeleteCareRequirement
            this.btnDeleteCareRequirement.Text = "🗑 Удалить";
            this.btnDeleteCareRequirement.Location = new System.Drawing.Point(270, 120);
            this.btnDeleteCareRequirement.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteCareRequirement.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDeleteCareRequirement.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCareRequirement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCareRequirement.Click += new System.EventHandler(this.btnDeleteCareRequirement_Click);

            // btnClearCareRequirement
            this.btnClearCareRequirement.Text = "🧹 Очистить";
            this.btnClearCareRequirement.Location = new System.Drawing.Point(400, 120);
            this.btnClearCareRequirement.Size = new System.Drawing.Size(120, 35);
            this.btnClearCareRequirement.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
            this.btnClearCareRequirement.ForeColor = System.Drawing.Color.White;
            this.btnClearCareRequirement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCareRequirement.Click += (s, e) => ClearCareRequirementFields();

            this.groupBoxCareRequirementInfo.Controls.Add(this.lblLighting);
            this.groupBoxCareRequirementInfo.Controls.Add(this.txtLighting);
            this.groupBoxCareRequirementInfo.Controls.Add(this.lblWateringSummer);
            this.groupBoxCareRequirementInfo.Controls.Add(this.txtWateringSummer);
            this.groupBoxCareRequirementInfo.Controls.Add(this.lblWateringWinter);
            this.groupBoxCareRequirementInfo.Controls.Add(this.txtWateringWinter);
            this.groupBoxCareRequirementInfo.Controls.Add(this.lblTempSummer);
            this.groupBoxCareRequirementInfo.Controls.Add(this.txtTempSummer);
            this.groupBoxCareRequirementInfo.Controls.Add(this.lblTempWinter);
            this.groupBoxCareRequirementInfo.Controls.Add(this.txtTempWinter);
            this.groupBoxCareRequirementInfo.Controls.Add(this.btnAddCareRequirement);
            this.groupBoxCareRequirementInfo.Controls.Add(this.btnUpdateCareRequirement);
            this.groupBoxCareRequirementInfo.Controls.Add(this.btnDeleteCareRequirement);
            this.groupBoxCareRequirementInfo.Controls.Add(this.btnClearCareRequirement);

            this.tabPageCareRequirements.Controls.Add(this.dgvCareRequirements);
            this.tabPageCareRequirements.Controls.Add(this.groupBoxCareRequirementInfo);

            // ========== ВКЛАДКА ЖУРНАЛ УХОДА ==========
            this.tabPageCareLogs.Text = "📝 Журнал ухода";
            this.tabPageCareLogs.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            // dgvCareLogs
            this.dgvCareLogs.Location = new System.Drawing.Point(10, 160);
            this.dgvCareLogs.Size = new System.Drawing.Size(1160, 470);

            // groupBoxCareLogInfo
            this.groupBoxCareLogInfo.Text = "Добавить запись об уходе";
            this.groupBoxCareLogInfo.Location = new System.Drawing.Point(10, 10);
            this.groupBoxCareLogInfo.Size = new System.Drawing.Size(1160, 140);

            // lblCareLogPlant
            this.lblCareLogPlant.Text = "Растение:";
            this.lblCareLogPlant.Location = new System.Drawing.Point(10, 35);
            this.lblCareLogPlant.Size = new System.Drawing.Size(70, 25);

            // cmbCareLogPlant
            this.cmbCareLogPlant.Location = new System.Drawing.Point(90, 32);
            this.cmbCareLogPlant.Size = new System.Drawing.Size(200, 25);
            this.cmbCareLogPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblCareLogDate
            this.lblCareLogDate.Text = "Дата и время:";
            this.lblCareLogDate.Location = new System.Drawing.Point(300, 35);
            this.lblCareLogDate.Size = new System.Drawing.Size(90, 25);

            // dtpCareLogDate
            this.dtpCareLogDate.Location = new System.Drawing.Point(400, 32);
            this.dtpCareLogDate.Size = new System.Drawing.Size(200, 25);
            this.dtpCareLogDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCareLogDate.CustomFormat = "dd.MM.yyyy HH:mm";

            // lblCareLogDescription
            this.lblCareLogDescription.Text = "Описание:";
            this.lblCareLogDescription.Location = new System.Drawing.Point(10, 75);
            this.lblCareLogDescription.Size = new System.Drawing.Size(70, 25);

            // txtCareLogDescription
            this.txtCareLogDescription.Location = new System.Drawing.Point(90, 72);
            this.txtCareLogDescription.Size = new System.Drawing.Size(510, 25);

            // btnAddCareLog
            this.btnAddCareLog.Text = "➕ Добавить запись";
            this.btnAddCareLog.Location = new System.Drawing.Point(620, 55);
            this.btnAddCareLog.Size = new System.Drawing.Size(150, 35);
            this.btnAddCareLog.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddCareLog.ForeColor = System.Drawing.Color.White;
            this.btnAddCareLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCareLog.Click += new System.EventHandler(this.btnAddCareLog_Click);

            // btnDeleteCareLog
            this.btnDeleteCareLog.Text = "🗑 Удалить запись";
            this.btnDeleteCareLog.Location = new System.Drawing.Point(780, 55);
            this.btnDeleteCareLog.Size = new System.Drawing.Size(150, 35);
            this.btnDeleteCareLog.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDeleteCareLog.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCareLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCareLog.Click += new System.EventHandler(this.btnDeleteCareLog_Click);

            this.groupBoxCareLogInfo.Controls.Add(this.lblCareLogPlant);
            this.groupBoxCareLogInfo.Controls.Add(this.cmbCareLogPlant);
            this.groupBoxCareLogInfo.Controls.Add(this.lblCareLogDate);
            this.groupBoxCareLogInfo.Controls.Add(this.dtpCareLogDate);
            this.groupBoxCareLogInfo.Controls.Add(this.lblCareLogDescription);
            this.groupBoxCareLogInfo.Controls.Add(this.txtCareLogDescription);
            this.groupBoxCareLogInfo.Controls.Add(this.btnAddCareLog);
            this.groupBoxCareLogInfo.Controls.Add(this.btnDeleteCareLog);

            this.tabPageCareLogs.Controls.Add(this.dgvCareLogs);
            this.tabPageCareLogs.Controls.Add(this.groupBoxCareLogInfo);

            // ========== ВКЛАДКА ПАТОГЕНЫ ==========
            this.tabPagePathogens.Text = "🦠 Патогены";
            this.tabPagePathogens.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            // dgvPathogens
            this.dgvPathogens.Location = new System.Drawing.Point(10, 160);
            this.dgvPathogens.Size = new System.Drawing.Size(1160, 470);

            // groupBoxPathogenInfo
            this.groupBoxPathogenInfo.Text = "Информация о патогене";
            this.groupBoxPathogenInfo.Location = new System.Drawing.Point(10, 10);
            this.groupBoxPathogenInfo.Size = new System.Drawing.Size(1160, 140);

            // lblPathogenName
            this.lblPathogenName.Text = "Название:";
            this.lblPathogenName.Location = new System.Drawing.Point(10, 35);
            this.lblPathogenName.Size = new System.Drawing.Size(70, 25);

            // txtPathogenName
            this.txtPathogenName.Location = new System.Drawing.Point(90, 32);
            this.txtPathogenName.Size = new System.Drawing.Size(300, 25);

            // lblPathogenDescription
            this.lblPathogenDescription.Text = "Описание:";
            this.lblPathogenDescription.Location = new System.Drawing.Point(10, 75);
            this.lblPathogenDescription.Size = new System.Drawing.Size(70, 25);

            // txtPathogenDescription
            this.txtPathogenDescription.Location = new System.Drawing.Point(90, 72);
            this.txtPathogenDescription.Size = new System.Drawing.Size(510, 25);

            // btnAddPathogen
            this.btnAddPathogen.Text = "➕ Добавить";
            this.btnAddPathogen.Location = new System.Drawing.Point(620, 30);
            this.btnAddPathogen.Size = new System.Drawing.Size(100, 35);
            this.btnAddPathogen.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddPathogen.ForeColor = System.Drawing.Color.White;
            this.btnAddPathogen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPathogen.Click += new System.EventHandler(this.btnAddPathogen_Click);

            // btnUpdatePathogen
            this.btnUpdatePathogen.Text = "✏ Обновить";
            this.btnUpdatePathogen.Location = new System.Drawing.Point(730, 30);
            this.btnUpdatePathogen.Size = new System.Drawing.Size(100, 35);
            this.btnUpdatePathogen.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnUpdatePathogen.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePathogen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePathogen.Click += new System.EventHandler(this.btnUpdatePathogen_Click);

            // btnDeletePathogen
            this.btnDeletePathogen.Text = "🗑 Удалить";
            this.btnDeletePathogen.Location = new System.Drawing.Point(840, 30);
            this.btnDeletePathogen.Size = new System.Drawing.Size(100, 35);
            this.btnDeletePathogen.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDeletePathogen.ForeColor = System.Drawing.Color.White;
            this.btnDeletePathogen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePathogen.Click += new System.EventHandler(this.btnDeletePathogen_Click);

            // btnClearPathogen
            this.btnClearPathogen.Text = "🧹 Очистить";
            this.btnClearPathogen.Location = new System.Drawing.Point(950, 30);
            this.btnClearPathogen.Size = new System.Drawing.Size(100, 35);
            this.btnClearPathogen.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
            this.btnClearPathogen.ForeColor = System.Drawing.Color.White;
            this.btnClearPathogen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPathogen.Click += (s, e) => ClearPathogenFields();

            this.groupBoxPathogenInfo.Controls.Add(this.lblPathogenName);
            this.groupBoxPathogenInfo.Controls.Add(this.txtPathogenName);
            this.groupBoxPathogenInfo.Controls.Add(this.lblPathogenDescription);
            this.groupBoxPathogenInfo.Controls.Add(this.txtPathogenDescription);
            this.groupBoxPathogenInfo.Controls.Add(this.btnAddPathogen);
            this.groupBoxPathogenInfo.Controls.Add(this.btnUpdatePathogen);
            this.groupBoxPathogenInfo.Controls.Add(this.btnDeletePathogen);
            this.groupBoxPathogenInfo.Controls.Add(this.btnClearPathogen);

            this.tabPagePathogens.Controls.Add(this.dgvPathogens);
            this.tabPagePathogens.Controls.Add(this.groupBoxPathogenInfo);

            // ========== ВКЛАДКА ИСТОРИЯ БОЛЕЗНЕЙ ==========
            this.tabPageDiseaseHistory.Text = "📋 История болезней";
            this.tabPageDiseaseHistory.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            // dgvDiseaseHistory
            this.dgvDiseaseHistory.Location = new System.Drawing.Point(10, 250);
            this.dgvDiseaseHistory.Size = new System.Drawing.Size(1160, 380);

            // groupBoxDiseaseInfo
            this.groupBoxDiseaseInfo.Text = "Информация о заболевании";
            this.groupBoxDiseaseInfo.Location = new System.Drawing.Point(10, 10);
            this.groupBoxDiseaseInfo.Size = new System.Drawing.Size(1160, 230);

            // lblDiseasePlant
            this.lblDiseasePlant.Text = "Растение:";
            this.lblDiseasePlant.Location = new System.Drawing.Point(10, 35);
            this.lblDiseasePlant.Size = new System.Drawing.Size(70, 25);

            // cmbDiseasePlant
            this.cmbDiseasePlant.Location = new System.Drawing.Point(90, 32);
            this.cmbDiseasePlant.Size = new System.Drawing.Size(200, 25);
            this.cmbDiseasePlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblDiseasePathogen
            this.lblDiseasePathogen.Text = "Патоген:";
            this.lblDiseasePathogen.Location = new System.Drawing.Point(300, 35);
            this.lblDiseasePathogen.Size = new System.Drawing.Size(60, 25);

            // cmbDiseasePathogen
            this.cmbDiseasePathogen.Location = new System.Drawing.Point(370, 32);
            this.cmbDiseasePathogen.Size = new System.Drawing.Size(200, 25);
            this.cmbDiseasePathogen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblDiseaseStart
            this.lblDiseaseStart.Text = "Дата начала:";
            this.lblDiseaseStart.Location = new System.Drawing.Point(10, 75);
            this.lblDiseaseStart.Size = new System.Drawing.Size(80, 25);

            // dtpDiseaseStart
            this.dtpDiseaseStart.Location = new System.Drawing.Point(100, 72);
            this.dtpDiseaseStart.Size = new System.Drawing.Size(150, 25);
            this.dtpDiseaseStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // lblDiseaseEnd
            this.lblDiseaseEnd.Text = "Дата окончания:";
            this.lblDiseaseEnd.Location = new System.Drawing.Point(260, 75);
            this.lblDiseaseEnd.Size = new System.Drawing.Size(100, 25);

            // dtpDiseaseEnd
            this.dtpDiseaseEnd.Location = new System.Drawing.Point(370, 72);
            this.dtpDiseaseEnd.Size = new System.Drawing.Size(150, 25);
            this.dtpDiseaseEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDiseaseEnd.Enabled = false;

            // chkDiseaseCured
            this.chkDiseaseCured.Text = "Вылечено";
            this.chkDiseaseCured.Location = new System.Drawing.Point(530, 72);
            this.chkDiseaseCured.Size = new System.Drawing.Size(80, 25);
            this.chkDiseaseCured.CheckedChanged += new System.EventHandler(this.chkDiseaseCured_CheckedChanged);

            // lblDiseaseDescription
            this.lblDiseaseDescription.Text = "Описание:";
            this.lblDiseaseDescription.Location = new System.Drawing.Point(10, 115);
            this.lblDiseaseDescription.Size = new System.Drawing.Size(70, 25);

            // txtDiseaseDescription
            this.txtDiseaseDescription.Location = new System.Drawing.Point(90, 112);
            this.txtDiseaseDescription.Size = new System.Drawing.Size(700, 25);
            this.txtDiseaseDescription.Multiline = true;
            this.txtDiseaseDescription.Height = 60;

            // btnAddDisease
            this.btnAddDisease.Text = "➕ Добавить";
            this.btnAddDisease.Location = new System.Drawing.Point(10, 185);
            this.btnAddDisease.Size = new System.Drawing.Size(120, 35);
            this.btnAddDisease.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddDisease.ForeColor = System.Drawing.Color.White;
            this.btnAddDisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDisease.Click += new System.EventHandler(this.btnAddDisease_Click);

            // btnUpdateDisease
            this.btnUpdateDisease.Text = "✏ Обновить";
            this.btnUpdateDisease.Location = new System.Drawing.Point(140, 185);
            this.btnUpdateDisease.Size = new System.Drawing.Size(120, 35);
            this.btnUpdateDisease.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnUpdateDisease.ForeColor = System.Drawing.Color.White;
            this.btnUpdateDisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateDisease.Click += new System.EventHandler(this.btnUpdateDisease_Click);

            // btnDeleteDisease
            this.btnDeleteDisease.Text = "🗑 Удалить";
            this.btnDeleteDisease.Location = new System.Drawing.Point(270, 185);
            this.btnDeleteDisease.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteDisease.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDeleteDisease.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDisease.Click += new System.EventHandler(this.btnDeleteDisease_Click);

            // btnClearDisease
            this.btnClearDisease.Text = "🧹 Очистить";
            this.btnClearDisease.Location = new System.Drawing.Point(400, 185);
            this.btnClearDisease.Size = new System.Drawing.Size(120, 35);
            this.btnClearDisease.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
            this.btnClearDisease.ForeColor = System.Drawing.Color.White;
            this.btnClearDisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearDisease.Click += (s, e) => ClearDiseaseFields();

            this.groupBoxDiseaseInfo.Controls.Add(this.lblDiseasePlant);
            this.groupBoxDiseaseInfo.Controls.Add(this.cmbDiseasePlant);
            this.groupBoxDiseaseInfo.Controls.Add(this.lblDiseasePathogen);
            this.groupBoxDiseaseInfo.Controls.Add(this.cmbDiseasePathogen);
            this.groupBoxDiseaseInfo.Controls.Add(this.lblDiseaseStart);
            this.groupBoxDiseaseInfo.Controls.Add(this.dtpDiseaseStart);
            this.groupBoxDiseaseInfo.Controls.Add(this.lblDiseaseEnd);
            this.groupBoxDiseaseInfo.Controls.Add(this.dtpDiseaseEnd);
            this.groupBoxDiseaseInfo.Controls.Add(this.chkDiseaseCured);
            this.groupBoxDiseaseInfo.Controls.Add(this.lblDiseaseDescription);
            this.groupBoxDiseaseInfo.Controls.Add(this.txtDiseaseDescription);
            this.groupBoxDiseaseInfo.Controls.Add(this.btnAddDisease);
            this.groupBoxDiseaseInfo.Controls.Add(this.btnUpdateDisease);
            this.groupBoxDiseaseInfo.Controls.Add(this.btnDeleteDisease);
            this.groupBoxDiseaseInfo.Controls.Add(this.btnClearDisease);

            this.tabPageDiseaseHistory.Controls.Add(this.dgvDiseaseHistory);
            this.tabPageDiseaseHistory.Controls.Add(this.groupBoxDiseaseInfo);

            // ========== ВКЛАДКА СТАТИСТИКА ==========
            this.tabPageStatistics.Text = "📊 Статистика";
            this.tabPageStatistics.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            // panelStats
            this.panelStats.Location = new System.Drawing.Point(10, 10);
            this.panelStats.Size = new System.Drawing.Size(1160, 620);
            this.panelStats.BackColor = System.Drawing.Color.White;
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblStatsTitle
            this.lblStatsTitle.Text = "📊 СТАТИСТИКА КАТАЛОГА";
            this.lblStatsTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatsTitle.ForeColor = System.Drawing.Color.FromArgb(45, 66, 91);
            this.lblStatsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblStatsTitle.Size = new System.Drawing.Size(400, 40);

            // lblStatsPlants
            this.lblStatsPlants.Text = "Всего растений: 0";
            this.lblStatsPlants.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatsPlants.Location = new System.Drawing.Point(20, 80);
            this.lblStatsPlants.Size = new System.Drawing.Size(300, 30);

            // lblStatsLifeForms
            this.lblStatsLifeForms.Text = "Жизненных форм: 0";
            this.lblStatsLifeForms.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatsLifeForms.Location = new System.Drawing.Point(20, 120);
            this.lblStatsLifeForms.Size = new System.Drawing.Size(300, 30);

            // lblStatsCareReqs
            this.lblStatsCareReqs.Text = "Рекомендаций по уходу: 0";
            this.lblStatsCareReqs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatsCareReqs.Location = new System.Drawing.Point(20, 160);
            this.lblStatsCareReqs.Size = new System.Drawing.Size(300, 30);

            // lblStatsPathogens
            this.lblStatsPathogens.Text = "Патогенов: 0";
            this.lblStatsPathogens.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatsPathogens.Location = new System.Drawing.Point(20, 200);
            this.lblStatsPathogens.Size = new System.Drawing.Size(300, 30);

            // lblStatsActiveDiseases
            this.lblStatsActiveDiseases.Text = "Активных заболеваний: 0";
            this.lblStatsActiveDiseases.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatsActiveDiseases.Location = new System.Drawing.Point(20, 240);
            this.lblStatsActiveDiseases.Size = new System.Drawing.Size(300, 30);

            // lblStatsCareLogs
            this.lblStatsCareLogs.Text = "Записей об уходе: 0";
            this.lblStatsCareLogs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatsCareLogs.Location = new System.Drawing.Point(20, 280);
            this.lblStatsCareLogs.Size = new System.Drawing.Size(300, 30);

            // lblStatsTopPlants
            this.lblStatsTopPlants.Text = "Топ-5 растений по заболеваниям:";
            this.lblStatsTopPlants.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatsTopPlants.Location = new System.Drawing.Point(20, 340);
            this.lblStatsTopPlants.Size = new System.Drawing.Size(400, 150);

            // btnRefreshStats
            this.btnRefreshStats.Text = "🔄 Обновить статистику";
            this.btnRefreshStats.Location = new System.Drawing.Point(20, 520);
            this.btnRefreshStats.Size = new System.Drawing.Size(200, 40);
            this.btnRefreshStats.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnRefreshStats.ForeColor = System.Drawing.Color.White;
            this.btnRefreshStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshStats.Click += new System.EventHandler(this.btnRefreshStats_Click);

            this.panelStats.Controls.Add(this.lblStatsTitle);
            this.panelStats.Controls.Add(this.lblStatsPlants);
            this.panelStats.Controls.Add(this.lblStatsLifeForms);
            this.panelStats.Controls.Add(this.lblStatsCareReqs);
            this.panelStats.Controls.Add(this.lblStatsPathogens);
            this.panelStats.Controls.Add(this.lblStatsActiveDiseases);
            this.panelStats.Controls.Add(this.lblStatsCareLogs);
            this.panelStats.Controls.Add(this.lblStatsTopPlants);
            this.panelStats.Controls.Add(this.btnRefreshStats);

            this.tabPageStatistics.Controls.Add(this.panelStats);

            // Добавление вкладок в TabControl
            this.tabControlMain.TabPages.Add(this.tabPagePlants);
            this.tabControlMain.TabPages.Add(this.tabPageLifeForms);
            this.tabControlMain.TabPages.Add(this.tabPageCareRequirements);
            this.tabControlMain.TabPages.Add(this.tabPageCareLogs);
            this.tabControlMain.TabPages.Add(this.tabPagePathogens);
            this.tabControlMain.TabPages.Add(this.tabPageDiseaseHistory);
            this.tabControlMain.TabPages.Add(this.tabPageStatistics);

            // PlantCatalogForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "PlantCatalogForm";
            this.Text = "Каталог растений";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}