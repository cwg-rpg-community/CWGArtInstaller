namespace CWGArtInstaller
{
    partial class MainForm
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabWizard = new CWGArtInstaller.WizardTabControl();
            this.tabPageWelcome = new System.Windows.Forms.TabPage();
            this.btnInstall = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabPagePath = new System.Windows.Forms.TabPage();
            this.btnInstallModels = new System.Windows.Forms.Button();
            this.lblPathStatus = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtInstallPath = new System.Windows.Forms.TextBox();
            this.lblSelectPath = new System.Windows.Forms.Label();
            this.tabPageInstall = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblComplete = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblDownloading = new System.Windows.Forms.Label();
            this.tabPageManage = new System.Windows.Forms.TabPage();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnReinstall = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.lblManageDescription = new System.Windows.Forms.Label();
            this.lblManageTitle = new System.Windows.Forms.Label();
            this.tabPageValidate = new System.Windows.Forms.TabPage();
            this.btnRecheck = new System.Windows.Forms.Button();
            this.btnValidateBack = new System.Windows.Forms.Button();
            this.lblValidateSummary = new System.Windows.Forms.Label();
            this.lblCheckModels = new System.Windows.Forms.Label();
            this.lblCheckRegistry = new System.Windows.Forms.Label();
            this.btnValidateBrowse = new System.Windows.Forms.Button();
            this.txtValidatePath = new System.Windows.Forms.TextBox();
            this.lblValidatePath = new System.Windows.Forms.Label();
            this.lblValidateTitle = new System.Windows.Forms.Label();
            this.tabPageUninstall = new System.Windows.Forms.TabPage();
            this.btnUninstallClose = new System.Windows.Forms.Button();
            this.lblUninstallComplete = new System.Windows.Forms.Label();
            this.lblUninstallDetails = new System.Windows.Forms.Label();
            this.lblUninstallTitle = new System.Windows.Forms.Label();
            this.tabWizard.SuspendLayout();
            this.tabPageWelcome.SuspendLayout();
            this.tabPagePath.SuspendLayout();
            this.tabPageInstall.SuspendLayout();
            this.tabPageManage.SuspendLayout();
            this.tabPageValidate.SuspendLayout();
            this.tabPageUninstall.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabWizard
            // 
            this.tabWizard.Controls.Add(this.tabPageWelcome);
            this.tabWizard.Controls.Add(this.tabPagePath);
            this.tabWizard.Controls.Add(this.tabPageInstall);
            this.tabWizard.Controls.Add(this.tabPageManage);
            this.tabWizard.Controls.Add(this.tabPageValidate);
            this.tabWizard.Controls.Add(this.tabPageUninstall);
            this.tabWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWizard.Location = new System.Drawing.Point(0, 0);
            this.tabWizard.Name = "tabWizard";
            this.tabWizard.SelectedIndex = 0;
            this.tabWizard.Size = new System.Drawing.Size(534, 261);
            this.tabWizard.TabIndex = 0;
            // 
            // tabPageWelcome
            // 
            this.tabPageWelcome.Controls.Add(this.btnInstall);
            this.tabPageWelcome.Controls.Add(this.lblDescription);
            this.tabPageWelcome.Controls.Add(this.lblTitle);
            this.tabPageWelcome.Location = new System.Drawing.Point(4, 24);
            this.tabPageWelcome.Name = "tabPageWelcome";
            this.tabPageWelcome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWelcome.Size = new System.Drawing.Size(526, 233);
            this.tabPageWelcome.TabIndex = 0;
            this.tabPageWelcome.Text = "Welcome";
            this.tabPageWelcome.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInstall.Location = new System.Drawing.Point(193, 140);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(140, 52);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(6, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(514, 40);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "This will enable local models for Warcraft III\r\nvia registry editor and install custom models for CWG in your Warcraft III folder";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblTitle.Location = new System.Drawing.Point(6, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(514, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CWG Art Installer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPagePath
            // 
            this.tabPagePath.Controls.Add(this.btnInstallModels);
            this.tabPagePath.Controls.Add(this.lblPathStatus);
            this.tabPagePath.Controls.Add(this.btnBrowse);
            this.tabPagePath.Controls.Add(this.txtInstallPath);
            this.tabPagePath.Controls.Add(this.lblSelectPath);
            this.tabPagePath.Location = new System.Drawing.Point(4, 24);
            this.tabPagePath.Name = "tabPagePath";
            this.tabPagePath.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePath.Size = new System.Drawing.Size(526, 233);
            this.tabPagePath.TabIndex = 1;
            this.tabPagePath.Text = "Install Path";
            this.tabPagePath.UseVisualStyleBackColor = true;
            // 
            // btnInstallModels
            // 
            this.btnInstallModels.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInstallModels.Location = new System.Drawing.Point(193, 160);
            this.btnInstallModels.Name = "btnInstallModels";
            this.btnInstallModels.Size = new System.Drawing.Size(140, 45);
            this.btnInstallModels.TabIndex = 4;
            this.btnInstallModels.Text = "Install Models";
            this.btnInstallModels.UseVisualStyleBackColor = true;
            this.btnInstallModels.Click += new System.EventHandler(this.btnInstallModels_Click);
            // 
            // lblPathStatus
            // 
            this.lblPathStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPathStatus.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPathStatus.Location = new System.Drawing.Point(30, 98);
            this.lblPathStatus.Name = "lblPathStatus";
            this.lblPathStatus.Size = new System.Drawing.Size(466, 20);
            this.lblPathStatus.TabIndex = 3;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(411, 66);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(85, 27);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtInstallPath
            // 
            this.txtInstallPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstallPath.Location = new System.Drawing.Point(30, 68);
            this.txtInstallPath.Name = "txtInstallPath";
            this.txtInstallPath.Size = new System.Drawing.Size(375, 23);
            this.txtInstallPath.TabIndex = 1;
            // 
            // lblSelectPath
            // 
            this.lblSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectPath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSelectPath.Location = new System.Drawing.Point(6, 20);
            this.lblSelectPath.Name = "lblSelectPath";
            this.lblSelectPath.Size = new System.Drawing.Size(514, 28);
            this.lblSelectPath.TabIndex = 0;
            this.lblSelectPath.Text = "Please select your Warcraft III install path";
            this.lblSelectPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageInstall
            // 
            this.tabPageInstall.Controls.Add(this.btnClose);
            this.tabPageInstall.Controls.Add(this.lblComplete);
            this.tabPageInstall.Controls.Add(this.lblStatus);
            this.tabPageInstall.Controls.Add(this.progressBar);
            this.tabPageInstall.Controls.Add(this.lblDownloading);
            this.tabPageInstall.Location = new System.Drawing.Point(4, 24);
            this.tabPageInstall.Name = "tabPageInstall";
            this.tabPageInstall.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstall.Size = new System.Drawing.Size(526, 233);
            this.tabPageInstall.TabIndex = 2;
            this.tabPageInstall.Text = "Installing";
            this.tabPageInstall.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Location = new System.Drawing.Point(223, 198);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblComplete
            // 
            this.lblComplete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComplete.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblComplete.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblComplete.Location = new System.Drawing.Point(6, 160);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(514, 32);
            this.lblComplete.TabIndex = 3;
            this.lblComplete.Text = "Complete";
            this.lblComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblComplete.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblStatus.Location = new System.Drawing.Point(30, 112);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(466, 40);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(60, 80);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(406, 25);
            this.progressBar.TabIndex = 1;
            // 
            // lblDownloading
            // 
            this.lblDownloading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDownloading.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblDownloading.Location = new System.Drawing.Point(6, 20);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(514, 45);
            this.lblDownloading.TabIndex = 0;
            this.lblDownloading.Text = "Downloading & Installing Models";
            this.lblDownloading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDownloading.UseMnemonic = false;
            // 
            // tabPageManage
            // 
            this.tabPageManage.Controls.Add(this.btnUninstall);
            this.tabPageManage.Controls.Add(this.btnReinstall);
            this.tabPageManage.Controls.Add(this.btnValidate);
            this.tabPageManage.Controls.Add(this.lblManageDescription);
            this.tabPageManage.Controls.Add(this.lblManageTitle);
            this.tabPageManage.Location = new System.Drawing.Point(4, 24);
            this.tabPageManage.Name = "tabPageManage";
            this.tabPageManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManage.Size = new System.Drawing.Size(526, 233);
            this.tabPageManage.TabIndex = 3;
            this.tabPageManage.Text = "Manage";
            this.tabPageManage.UseVisualStyleBackColor = true;
            // 
            // btnUninstall
            // 
            this.btnUninstall.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUninstall.Location = new System.Drawing.Point(348, 140);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(130, 52);
            this.btnUninstall.TabIndex = 4;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // btnReinstall
            // 
            this.btnReinstall.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReinstall.Location = new System.Drawing.Point(198, 140);
            this.btnReinstall.Name = "btnReinstall";
            this.btnReinstall.Size = new System.Drawing.Size(130, 52);
            this.btnReinstall.TabIndex = 3;
            this.btnReinstall.Text = "Reinstall";
            this.btnReinstall.UseVisualStyleBackColor = true;
            this.btnReinstall.Click += new System.EventHandler(this.btnReinstall_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnValidate.Location = new System.Drawing.Point(48, 140);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(130, 52);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // lblManageDescription
            // 
            this.lblManageDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManageDescription.Location = new System.Drawing.Point(6, 75);
            this.lblManageDescription.Name = "lblManageDescription";
            this.lblManageDescription.Size = new System.Drawing.Size(514, 40);
            this.lblManageDescription.TabIndex = 1;
            this.lblManageDescription.Text = "CWG models were found in your Warcraft III folder.\r\nWhat would you like to do?";
            this.lblManageDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblManageTitle
            // 
            this.lblManageTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManageTitle.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblManageTitle.Location = new System.Drawing.Point(6, 18);
            this.lblManageTitle.Name = "lblManageTitle";
            this.lblManageTitle.Size = new System.Drawing.Size(514, 45);
            this.lblManageTitle.TabIndex = 0;
            this.lblManageTitle.Text = "CWG Art Installer";
            this.lblManageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageValidate
            // 
            this.tabPageValidate.Controls.Add(this.btnRecheck);
            this.tabPageValidate.Controls.Add(this.btnValidateBack);
            this.tabPageValidate.Controls.Add(this.lblValidateSummary);
            this.tabPageValidate.Controls.Add(this.lblCheckModels);
            this.tabPageValidate.Controls.Add(this.lblCheckRegistry);
            this.tabPageValidate.Controls.Add(this.btnValidateBrowse);
            this.tabPageValidate.Controls.Add(this.txtValidatePath);
            this.tabPageValidate.Controls.Add(this.lblValidatePath);
            this.tabPageValidate.Controls.Add(this.lblValidateTitle);
            this.tabPageValidate.Location = new System.Drawing.Point(4, 24);
            this.tabPageValidate.Name = "tabPageValidate";
            this.tabPageValidate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageValidate.Size = new System.Drawing.Size(526, 233);
            this.tabPageValidate.TabIndex = 4;
            this.tabPageValidate.Text = "Validate";
            this.tabPageValidate.UseVisualStyleBackColor = true;
            // 
            // btnRecheck
            // 
            this.btnRecheck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRecheck.Location = new System.Drawing.Point(273, 192);
            this.btnRecheck.Name = "btnRecheck";
            this.btnRecheck.Size = new System.Drawing.Size(100, 30);
            this.btnRecheck.TabIndex = 8;
            this.btnRecheck.Text = "Re-check";
            this.btnRecheck.UseVisualStyleBackColor = true;
            this.btnRecheck.Click += new System.EventHandler(this.btnRecheck_Click);
            // 
            // btnValidateBack
            // 
            this.btnValidateBack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnValidateBack.Location = new System.Drawing.Point(153, 192);
            this.btnValidateBack.Name = "btnValidateBack";
            this.btnValidateBack.Size = new System.Drawing.Size(100, 30);
            this.btnValidateBack.TabIndex = 7;
            this.btnValidateBack.Text = "Back";
            this.btnValidateBack.UseVisualStyleBackColor = true;
            this.btnValidateBack.Click += new System.EventHandler(this.btnValidateBack_Click);
            // 
            // lblValidateSummary
            // 
            this.lblValidateSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValidateSummary.Location = new System.Drawing.Point(20, 166);
            this.lblValidateSummary.Name = "lblValidateSummary";
            this.lblValidateSummary.Size = new System.Drawing.Size(486, 20);
            this.lblValidateSummary.TabIndex = 6;
            this.lblValidateSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheckModels
            // 
            this.lblCheckModels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckModels.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckModels.Location = new System.Drawing.Point(20, 124);
            this.lblCheckModels.Name = "lblCheckModels";
            this.lblCheckModels.Size = new System.Drawing.Size(486, 40);
            this.lblCheckModels.TabIndex = 5;
            // 
            // lblCheckRegistry
            // 
            this.lblCheckRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckRegistry.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckRegistry.Location = new System.Drawing.Point(20, 98);
            this.lblCheckRegistry.Name = "lblCheckRegistry";
            this.lblCheckRegistry.Size = new System.Drawing.Size(486, 24);
            this.lblCheckRegistry.TabIndex = 4;
            // 
            // btnValidateBrowse
            // 
            this.btnValidateBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidateBrowse.Location = new System.Drawing.Point(426, 61);
            this.btnValidateBrowse.Name = "btnValidateBrowse";
            this.btnValidateBrowse.Size = new System.Drawing.Size(80, 27);
            this.btnValidateBrowse.TabIndex = 3;
            this.btnValidateBrowse.Text = "Browse...";
            this.btnValidateBrowse.UseVisualStyleBackColor = true;
            this.btnValidateBrowse.Click += new System.EventHandler(this.btnValidateBrowse_Click);
            // 
            // txtValidatePath
            // 
            this.txtValidatePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValidatePath.Location = new System.Drawing.Point(150, 63);
            this.txtValidatePath.Name = "txtValidatePath";
            this.txtValidatePath.Size = new System.Drawing.Size(270, 23);
            this.txtValidatePath.TabIndex = 2;
            // 
            // lblValidatePath
            // 
            this.lblValidatePath.Location = new System.Drawing.Point(20, 63);
            this.lblValidatePath.Name = "lblValidatePath";
            this.lblValidatePath.Size = new System.Drawing.Size(125, 23);
            this.lblValidatePath.TabIndex = 1;
            this.lblValidatePath.Text = "Warcraft III folder:";
            this.lblValidatePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValidateTitle
            // 
            this.lblValidateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValidateTitle.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblValidateTitle.Location = new System.Drawing.Point(6, 12);
            this.lblValidateTitle.Name = "lblValidateTitle";
            this.lblValidateTitle.Size = new System.Drawing.Size(514, 40);
            this.lblValidateTitle.TabIndex = 0;
            this.lblValidateTitle.Text = "Validate Installation";
            this.lblValidateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageUninstall
            // 
            this.tabPageUninstall.Controls.Add(this.btnUninstallClose);
            this.tabPageUninstall.Controls.Add(this.lblUninstallComplete);
            this.tabPageUninstall.Controls.Add(this.lblUninstallDetails);
            this.tabPageUninstall.Controls.Add(this.lblUninstallTitle);
            this.tabPageUninstall.Location = new System.Drawing.Point(4, 24);
            this.tabPageUninstall.Name = "tabPageUninstall";
            this.tabPageUninstall.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUninstall.Size = new System.Drawing.Size(526, 233);
            this.tabPageUninstall.TabIndex = 5;
            this.tabPageUninstall.Text = "Uninstall";
            this.tabPageUninstall.UseVisualStyleBackColor = true;
            // 
            // btnUninstallClose
            // 
            this.btnUninstallClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUninstallClose.Location = new System.Drawing.Point(223, 198);
            this.btnUninstallClose.Name = "btnUninstallClose";
            this.btnUninstallClose.Size = new System.Drawing.Size(80, 28);
            this.btnUninstallClose.TabIndex = 3;
            this.btnUninstallClose.Text = "Close";
            this.btnUninstallClose.UseVisualStyleBackColor = true;
            this.btnUninstallClose.Visible = false;
            this.btnUninstallClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUninstallComplete
            // 
            this.lblUninstallComplete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUninstallComplete.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblUninstallComplete.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblUninstallComplete.Location = new System.Drawing.Point(6, 160);
            this.lblUninstallComplete.Name = "lblUninstallComplete";
            this.lblUninstallComplete.Size = new System.Drawing.Size(514, 32);
            this.lblUninstallComplete.TabIndex = 2;
            this.lblUninstallComplete.Text = "Complete";
            this.lblUninstallComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUninstallComplete.Visible = false;
            // 
            // lblUninstallDetails
            // 
            this.lblUninstallDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUninstallDetails.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblUninstallDetails.Location = new System.Drawing.Point(20, 75);
            this.lblUninstallDetails.Name = "lblUninstallDetails";
            this.lblUninstallDetails.Size = new System.Drawing.Size(486, 80);
            this.lblUninstallDetails.TabIndex = 1;
            this.lblUninstallDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUninstallTitle
            // 
            this.lblUninstallTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUninstallTitle.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblUninstallTitle.Location = new System.Drawing.Point(6, 20);
            this.lblUninstallTitle.Name = "lblUninstallTitle";
            this.lblUninstallTitle.Size = new System.Drawing.Size(514, 45);
            this.lblUninstallTitle.TabIndex = 0;
            this.lblUninstallTitle.Text = "Uninstalling CWG Models";
            this.lblUninstallTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 261);
            this.Controls.Add(this.tabWizard);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CWG Art Installer";
            this.tabWizard.ResumeLayout(false);
            this.tabPageWelcome.ResumeLayout(false);
            this.tabPagePath.ResumeLayout(false);
            this.tabPagePath.PerformLayout();
            this.tabPageInstall.ResumeLayout(false);
            this.tabPageManage.ResumeLayout(false);
            this.tabPageValidate.ResumeLayout(false);
            this.tabPageValidate.PerformLayout();
            this.tabPageUninstall.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CWGArtInstaller.WizardTabControl tabWizard;
        private System.Windows.Forms.TabPage tabPageWelcome;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabPage tabPagePath;
        private System.Windows.Forms.Button btnInstallModels;
        private System.Windows.Forms.Label lblPathStatus;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtInstallPath;
        private System.Windows.Forms.Label lblSelectPath;
        private System.Windows.Forms.TabPage tabPageInstall;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblComplete;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.TabPage tabPageManage;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Button btnReinstall;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Label lblManageDescription;
        private System.Windows.Forms.Label lblManageTitle;
        private System.Windows.Forms.TabPage tabPageValidate;
        private System.Windows.Forms.Button btnRecheck;
        private System.Windows.Forms.Button btnValidateBack;
        private System.Windows.Forms.Label lblValidateSummary;
        private System.Windows.Forms.Label lblCheckModels;
        private System.Windows.Forms.Label lblCheckRegistry;
        private System.Windows.Forms.Button btnValidateBrowse;
        private System.Windows.Forms.TextBox txtValidatePath;
        private System.Windows.Forms.Label lblValidatePath;
        private System.Windows.Forms.Label lblValidateTitle;
        private System.Windows.Forms.TabPage tabPageUninstall;
        private System.Windows.Forms.Button btnUninstallClose;
        private System.Windows.Forms.Label lblUninstallComplete;
        private System.Windows.Forms.Label lblUninstallDetails;
        private System.Windows.Forms.Label lblUninstallTitle;
    }
}
