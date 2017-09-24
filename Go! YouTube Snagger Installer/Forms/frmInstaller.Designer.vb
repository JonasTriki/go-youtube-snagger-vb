<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstaller
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstaller))
        Me.cbRun = New System.Windows.Forms.CheckBox()
        Me.btnStartOrStopInstallation = New System.Windows.Forms.Button()
        Me.pSplitBottom = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lInstallationProgress = New System.Windows.Forms.Label()
        Me.btnRepair = New System.Windows.Forms.Button()
        Me.pStart = New System.Windows.Forms.Panel()
        Me.pInstalled = New System.Windows.Forms.Panel()
        Me.pUninstall = New System.Windows.Forms.Panel()
        Me.pRepair = New System.Windows.Forms.Panel()
        Me.gpbRepairProgress = New Go__YouTube_Snagger_Installer.GoProgressBar()
        Me.lRepairProgess = New System.Windows.Forms.Label()
        Me.pbRepair1 = New System.Windows.Forms.PictureBox()
        Me.pSplitBottom3 = New System.Windows.Forms.Panel()
        Me.btnClose3 = New System.Windows.Forms.Button()
        Me.lUninstallProgress = New System.Windows.Forms.Label()
        Me.pbUninstall1 = New System.Windows.Forms.PictureBox()
        Me.pSplitBottom2 = New System.Windows.Forms.Panel()
        Me.btnClose2 = New System.Windows.Forms.Button()
        Me.gpbUninstallationProgress = New Go__YouTube_Snagger_Installer.GoProgressBar()
        Me.btnUninstall = New System.Windows.Forms.Button()
        Me.pSplitBottom1 = New System.Windows.Forms.Panel()
        Me.btnClose1 = New System.Windows.Forms.Button()
        Me.lInstalled = New System.Windows.Forms.Label()
        Me.pbRepair = New System.Windows.Forms.PictureBox()
        Me.pbUninstall = New System.Windows.Forms.PictureBox()
        Me.pSplitMiddle = New System.Windows.Forms.Panel()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.pLogo = New System.Windows.Forms.Panel()
        Me.pSplitLogoTop = New System.Windows.Forms.Panel()
        Me.lChooseDirectory = New System.Windows.Forms.Label()
        Me.lWelcome = New System.Windows.Forms.Label()
        Me.cbShortcut = New System.Windows.Forms.CheckBox()
        Me.txtPath = New Go__YouTube_Snagger_Installer.GoTextBox()
        Me.gpbInstallationProgress = New Go__YouTube_Snagger_Installer.GoProgressBar()
        Me.pStart.SuspendLayout()
        Me.pInstalled.SuspendLayout()
        Me.pUninstall.SuspendLayout()
        Me.pRepair.SuspendLayout()
        CType(Me.pbRepair1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbUninstall1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRepair, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbUninstall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pLogo.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbRun
        '
        Me.cbRun.AutoSize = True
        Me.cbRun.Checked = True
        Me.cbRun.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbRun.Location = New System.Drawing.Point(12, 246)
        Me.cbRun.Name = "cbRun"
        Me.cbRun.Size = New System.Drawing.Size(316, 19)
        Me.cbRun.TabIndex = 31
        Me.cbRun.Text = "Kjør Go! YouTube Snagger når installasjonen er ferdig..."
        Me.cbRun.UseVisualStyleBackColor = True
        '
        'btnStartOrStopInstallation
        '
        Me.btnStartOrStopInstallation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartOrStopInstallation.Location = New System.Drawing.Point(368, 243)
        Me.btnStartOrStopInstallation.Name = "btnStartOrStopInstallation"
        Me.btnStartOrStopInstallation.Size = New System.Drawing.Size(124, 23)
        Me.btnStartOrStopInstallation.TabIndex = 30
        Me.btnStartOrStopInstallation.Text = "&Start installasjon..."
        Me.btnStartOrStopInstallation.UseVisualStyleBackColor = True
        '
        'pSplitBottom
        '
        Me.pSplitBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplitBottom.Location = New System.Drawing.Point(0, 241)
        Me.pSplitBottom.Name = "pSplitBottom"
        Me.pSplitBottom.Size = New System.Drawing.Size(574, 1)
        Me.pSplitBottom.TabIndex = 26
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(496, 243)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 29
        Me.btnClose.Text = "&Lukk"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lInstallationProgress
        '
        Me.lInstallationProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lInstallationProgress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lInstallationProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lInstallationProgress.Location = New System.Drawing.Point(9, 190)
        Me.lInstallationProgress.Name = "lInstallationProgress"
        Me.lInstallationProgress.Size = New System.Drawing.Size(553, 15)
        Me.lInstallationProgress.TabIndex = 28
        Me.lInstallationProgress.Text = "Installasjons fremdrift"
        Me.lInstallationProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRepair
        '
        Me.btnRepair.Location = New System.Drawing.Point(114, 187)
        Me.btnRepair.Name = "btnRepair"
        Me.btnRepair.Size = New System.Drawing.Size(95, 23)
        Me.btnRepair.TabIndex = 33
        Me.btnRepair.Text = "&Reparer"
        Me.btnRepair.UseVisualStyleBackColor = True
        '
        'pStart
        '
        Me.pStart.Controls.Add(Me.pInstalled)
        Me.pStart.Controls.Add(Me.cbRun)
        Me.pStart.Controls.Add(Me.btnStartOrStopInstallation)
        Me.pStart.Controls.Add(Me.pSplitBottom)
        Me.pStart.Controls.Add(Me.btnClose)
        Me.pStart.Controls.Add(Me.lInstallationProgress)
        Me.pStart.Controls.Add(Me.pSplitMiddle)
        Me.pStart.Controls.Add(Me.btnChoose)
        Me.pStart.Controls.Add(Me.pLogo)
        Me.pStart.Controls.Add(Me.lChooseDirectory)
        Me.pStart.Controls.Add(Me.lWelcome)
        Me.pStart.Controls.Add(Me.cbShortcut)
        Me.pStart.Controls.Add(Me.txtPath)
        Me.pStart.Controls.Add(Me.gpbInstallationProgress)
        Me.pStart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pStart.Location = New System.Drawing.Point(0, 0)
        Me.pStart.Name = "pStart"
        Me.pStart.Size = New System.Drawing.Size(574, 268)
        Me.pStart.TabIndex = 1
        '
        'pInstalled
        '
        Me.pInstalled.Controls.Add(Me.pUninstall)
        Me.pInstalled.Controls.Add(Me.btnRepair)
        Me.pInstalled.Controls.Add(Me.btnUninstall)
        Me.pInstalled.Controls.Add(Me.pSplitBottom1)
        Me.pInstalled.Controls.Add(Me.btnClose1)
        Me.pInstalled.Controls.Add(Me.lInstalled)
        Me.pInstalled.Controls.Add(Me.pbRepair)
        Me.pInstalled.Controls.Add(Me.pbUninstall)
        Me.pInstalled.Location = New System.Drawing.Point(0, 0)
        Me.pInstalled.Name = "pInstalled"
        Me.pInstalled.Size = New System.Drawing.Size(574, 268)
        Me.pInstalled.TabIndex = 1
        '
        'pUninstall
        '
        Me.pUninstall.Controls.Add(Me.pRepair)
        Me.pUninstall.Controls.Add(Me.lUninstallProgress)
        Me.pUninstall.Controls.Add(Me.pbUninstall1)
        Me.pUninstall.Controls.Add(Me.pSplitBottom2)
        Me.pUninstall.Controls.Add(Me.btnClose2)
        Me.pUninstall.Controls.Add(Me.gpbUninstallationProgress)
        Me.pUninstall.Location = New System.Drawing.Point(0, 0)
        Me.pUninstall.Name = "pUninstall"
        Me.pUninstall.Size = New System.Drawing.Size(574, 268)
        Me.pUninstall.TabIndex = 1
        '
        'pRepair
        '
        Me.pRepair.Controls.Add(Me.gpbRepairProgress)
        Me.pRepair.Controls.Add(Me.lRepairProgess)
        Me.pRepair.Controls.Add(Me.pbRepair1)
        Me.pRepair.Controls.Add(Me.pSplitBottom3)
        Me.pRepair.Controls.Add(Me.btnClose3)
        Me.pRepair.Location = New System.Drawing.Point(0, 0)
        Me.pRepair.Name = "pRepair"
        Me.pRepair.Size = New System.Drawing.Size(574, 268)
        Me.pRepair.TabIndex = 37
        '
        'gpbRepairProgress
        '
        Me.gpbRepairProgress.BackgroundColor = System.Drawing.Color.White
        Me.gpbRepairProgress.BlockColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.gpbRepairProgress.BorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.gpbRepairProgress.ExtraText = ""
        Me.gpbRepairProgress.Icon = Nothing
        Me.gpbRepairProgress.Location = New System.Drawing.Point(127, 190)
        Me.gpbRepairProgress.MaxValue = 100.0R
        Me.gpbRepairProgress.MinValue = 0.0R
        Me.gpbRepairProgress.Name = "gpbRepairProgress"
        Me.gpbRepairProgress.Size = New System.Drawing.Size(320, 22)
        Me.gpbRepairProgress.TabIndex = 39
        Me.gpbRepairProgress.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.gpbRepairProgress.TextFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbRepairProgress.Value = 0.0R
        '
        'lRepairProgess
        '
        Me.lRepairProgess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lRepairProgess.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lRepairProgess.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lRepairProgess.Location = New System.Drawing.Point(12, 158)
        Me.lRepairProgess.Name = "lRepairProgess"
        Me.lRepairProgess.Size = New System.Drawing.Size(550, 24)
        Me.lRepairProgess.TabIndex = 35
        Me.lRepairProgess.Text = "Reperasjons fremdrift"
        Me.lRepairProgess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbRepair1
        '
        Me.pbRepair1.ErrorImage = Nothing
        Me.pbRepair1.Image = Global.Go__YouTube_Snagger_Installer.My.Resources.Resources.Repair
        Me.pbRepair1.InitialImage = Nothing
        Me.pbRepair1.Location = New System.Drawing.Point(239, 35)
        Me.pbRepair1.Name = "pbRepair1"
        Me.pbRepair1.Size = New System.Drawing.Size(96, 96)
        Me.pbRepair1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbRepair1.TabIndex = 34
        Me.pbRepair1.TabStop = False
        '
        'pSplitBottom3
        '
        Me.pSplitBottom3.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplitBottom3.Location = New System.Drawing.Point(0, 241)
        Me.pSplitBottom3.Name = "pSplitBottom3"
        Me.pSplitBottom3.Size = New System.Drawing.Size(574, 1)
        Me.pSplitBottom3.TabIndex = 33
        '
        'btnClose3
        '
        Me.btnClose3.Enabled = False
        Me.btnClose3.Location = New System.Drawing.Point(497, 243)
        Me.btnClose3.Name = "btnClose3"
        Me.btnClose3.Size = New System.Drawing.Size(75, 23)
        Me.btnClose3.TabIndex = 32
        Me.btnClose3.Text = "&Lukk"
        Me.btnClose3.UseVisualStyleBackColor = True
        '
        'lUninstallProgress
        '
        Me.lUninstallProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lUninstallProgress.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lUninstallProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lUninstallProgress.Location = New System.Drawing.Point(12, 158)
        Me.lUninstallProgress.Name = "lUninstallProgress"
        Me.lUninstallProgress.Size = New System.Drawing.Size(550, 24)
        Me.lUninstallProgress.TabIndex = 35
        Me.lUninstallProgress.Text = "Avinstallasjons fremdrift"
        Me.lUninstallProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbUninstall1
        '
        Me.pbUninstall1.ErrorImage = Nothing
        Me.pbUninstall1.Image = Global.Go__YouTube_Snagger_Installer.My.Resources.Resources.Uninstall
        Me.pbUninstall1.InitialImage = Nothing
        Me.pbUninstall1.Location = New System.Drawing.Point(239, 35)
        Me.pbUninstall1.Name = "pbUninstall1"
        Me.pbUninstall1.Size = New System.Drawing.Size(96, 96)
        Me.pbUninstall1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbUninstall1.TabIndex = 34
        Me.pbUninstall1.TabStop = False
        '
        'pSplitBottom2
        '
        Me.pSplitBottom2.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplitBottom2.Location = New System.Drawing.Point(0, 241)
        Me.pSplitBottom2.Name = "pSplitBottom2"
        Me.pSplitBottom2.Size = New System.Drawing.Size(574, 1)
        Me.pSplitBottom2.TabIndex = 33
        '
        'btnClose2
        '
        Me.btnClose2.Enabled = False
        Me.btnClose2.Location = New System.Drawing.Point(497, 243)
        Me.btnClose2.Name = "btnClose2"
        Me.btnClose2.Size = New System.Drawing.Size(75, 23)
        Me.btnClose2.TabIndex = 32
        Me.btnClose2.Text = "&Lukk"
        Me.btnClose2.UseVisualStyleBackColor = True
        '
        'gpbUninstallationProgress
        '
        Me.gpbUninstallationProgress.BackgroundColor = System.Drawing.Color.White
        Me.gpbUninstallationProgress.BlockColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.gpbUninstallationProgress.BorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.gpbUninstallationProgress.ExtraText = ""
        Me.gpbUninstallationProgress.Icon = Nothing
        Me.gpbUninstallationProgress.Location = New System.Drawing.Point(127, 190)
        Me.gpbUninstallationProgress.MaxValue = 100.0R
        Me.gpbUninstallationProgress.MinValue = 0.0R
        Me.gpbUninstallationProgress.Name = "gpbUninstallationProgress"
        Me.gpbUninstallationProgress.Size = New System.Drawing.Size(320, 22)
        Me.gpbUninstallationProgress.TabIndex = 38
        Me.gpbUninstallationProgress.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.gpbUninstallationProgress.TextFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbUninstallationProgress.Value = 0.0R
        '
        'btnUninstall
        '
        Me.btnUninstall.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUninstall.Location = New System.Drawing.Point(114, 85)
        Me.btnUninstall.Name = "btnUninstall"
        Me.btnUninstall.Size = New System.Drawing.Size(95, 23)
        Me.btnUninstall.TabIndex = 32
        Me.btnUninstall.Text = "&Avinstaller"
        Me.btnUninstall.UseVisualStyleBackColor = True
        '
        'pSplitBottom1
        '
        Me.pSplitBottom1.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplitBottom1.Location = New System.Drawing.Point(0, 241)
        Me.pSplitBottom1.Name = "pSplitBottom1"
        Me.pSplitBottom1.Size = New System.Drawing.Size(574, 1)
        Me.pSplitBottom1.TabIndex = 31
        '
        'btnClose1
        '
        Me.btnClose1.Location = New System.Drawing.Point(497, 243)
        Me.btnClose1.Name = "btnClose1"
        Me.btnClose1.Size = New System.Drawing.Size(75, 23)
        Me.btnClose1.TabIndex = 30
        Me.btnClose1.Text = "&Lukk"
        Me.btnClose1.UseVisualStyleBackColor = True
        '
        'lInstalled
        '
        Me.lInstalled.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lInstalled.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lInstalled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lInstalled.Location = New System.Drawing.Point(114, 12)
        Me.lInstalled.Name = "lInstalled"
        Me.lInstalled.Size = New System.Drawing.Size(448, 24)
        Me.lInstalled.TabIndex = 20
        Me.lInstalled.Text = "Go! YouTube Snagger er allerede installert på denne datamaskinen"
        Me.lInstalled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbRepair
        '
        Me.pbRepair.ErrorImage = Nothing
        Me.pbRepair.Image = Global.Go__YouTube_Snagger_Installer.My.Resources.Resources.Repair
        Me.pbRepair.InitialImage = Nothing
        Me.pbRepair.Location = New System.Drawing.Point(12, 114)
        Me.pbRepair.Name = "pbRepair"
        Me.pbRepair.Size = New System.Drawing.Size(96, 96)
        Me.pbRepair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbRepair.TabIndex = 1
        Me.pbRepair.TabStop = False
        '
        'pbUninstall
        '
        Me.pbUninstall.ErrorImage = Nothing
        Me.pbUninstall.Image = Global.Go__YouTube_Snagger_Installer.My.Resources.Resources.Uninstall
        Me.pbUninstall.InitialImage = Nothing
        Me.pbUninstall.Location = New System.Drawing.Point(12, 12)
        Me.pbUninstall.Name = "pbUninstall"
        Me.pbUninstall.Size = New System.Drawing.Size(96, 96)
        Me.pbUninstall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbUninstall.TabIndex = 0
        Me.pbUninstall.TabStop = False
        '
        'pSplitMiddle
        '
        Me.pSplitMiddle.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplitMiddle.Location = New System.Drawing.Point(0, 183)
        Me.pSplitMiddle.Name = "pSplitMiddle"
        Me.pSplitMiddle.Size = New System.Drawing.Size(574, 1)
        Me.pSplitMiddle.TabIndex = 24
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(534, 132)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(28, 22)
        Me.btnChoose.TabIndex = 23
        Me.btnChoose.Text = "..."
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'pLogo
        '
        Me.pLogo.BackgroundImage = CType(resources.GetObject("pLogo.BackgroundImage"), System.Drawing.Image)
        Me.pLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pLogo.Controls.Add(Me.pSplitLogoTop)
        Me.pLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pLogo.Location = New System.Drawing.Point(0, 0)
        Me.pLogo.Name = "pLogo"
        Me.pLogo.Size = New System.Drawing.Size(574, 60)
        Me.pLogo.TabIndex = 20
        '
        'pSplitLogoTop
        '
        Me.pSplitLogoTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplitLogoTop.Location = New System.Drawing.Point(0, 59)
        Me.pSplitLogoTop.Name = "pSplitLogoTop"
        Me.pSplitLogoTop.Size = New System.Drawing.Size(574, 1)
        Me.pSplitLogoTop.TabIndex = 11
        '
        'lChooseDirectory
        '
        Me.lChooseDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lChooseDirectory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lChooseDirectory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lChooseDirectory.Location = New System.Drawing.Point(9, 109)
        Me.lChooseDirectory.Name = "lChooseDirectory"
        Me.lChooseDirectory.Size = New System.Drawing.Size(553, 15)
        Me.lChooseDirectory.TabIndex = 21
        Me.lChooseDirectory.Text = "Velg en mappe for hvor du vil at Go! YouTube Snagger skal installeres:"
        Me.lChooseDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lWelcome
        '
        Me.lWelcome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lWelcome.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lWelcome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lWelcome.Location = New System.Drawing.Point(12, 64)
        Me.lWelcome.Name = "lWelcome"
        Me.lWelcome.Size = New System.Drawing.Size(550, 34)
        Me.lWelcome.TabIndex = 19
        Me.lWelcome.Text = "Velkommen til Go! YouTube Snagger installasjon"
        Me.lWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbShortcut
        '
        Me.cbShortcut.AutoSize = True
        Me.cbShortcut.Checked = True
        Me.cbShortcut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShortcut.Location = New System.Drawing.Point(15, 159)
        Me.cbShortcut.Name = "cbShortcut"
        Me.cbShortcut.Size = New System.Drawing.Size(194, 19)
        Me.cbShortcut.TabIndex = 32
        Me.cbShortcut.Text = "Lag en snarvei på skrivebordet..."
        Me.cbShortcut.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.AutoCompleteCustomSource = Nothing
        Me.txtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtPath.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPath.ContextMenuStrip = Nothing
        Me.txtPath.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtPath.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPath.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtPath.Icon = Global.Go__YouTube_Snagger_Installer.My.Resources.Resources.folder
        Me.txtPath.Location = New System.Drawing.Point(12, 132)
        Me.txtPath.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtPath.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPath.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtPath.Size = New System.Drawing.Size(516, 22)
        Me.txtPath.TabIndex = 34
        '
        'gpbInstallationProgress
        '
        Me.gpbInstallationProgress.BackgroundColor = System.Drawing.Color.White
        Me.gpbInstallationProgress.BlockColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.gpbInstallationProgress.BorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.gpbInstallationProgress.ExtraText = ""
        Me.gpbInstallationProgress.Icon = Nothing
        Me.gpbInstallationProgress.Location = New System.Drawing.Point(12, 211)
        Me.gpbInstallationProgress.MaxValue = 100.0R
        Me.gpbInstallationProgress.MinValue = 0.0R
        Me.gpbInstallationProgress.Name = "gpbInstallationProgress"
        Me.gpbInstallationProgress.Size = New System.Drawing.Size(550, 22)
        Me.gpbInstallationProgress.TabIndex = 33
        Me.gpbInstallationProgress.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.gpbInstallationProgress.TextFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbInstallationProgress.Value = 0.0R
        '
        'frmInstaller
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(574, 268)
        Me.Controls.Add(Me.pStart)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmInstaller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Go! YouTube Snagger Installasjon"
        Me.pStart.ResumeLayout(False)
        Me.pStart.PerformLayout()
        Me.pInstalled.ResumeLayout(False)
        Me.pInstalled.PerformLayout()
        Me.pUninstall.ResumeLayout(False)
        Me.pUninstall.PerformLayout()
        Me.pRepair.ResumeLayout(False)
        Me.pRepair.PerformLayout()
        CType(Me.pbRepair1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbUninstall1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRepair, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbUninstall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pLogo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbRun As System.Windows.Forms.CheckBox
    Friend WithEvents btnStartOrStopInstallation As System.Windows.Forms.Button
    Friend WithEvents pSplitBottom As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lInstallationProgress As System.Windows.Forms.Label
    Friend WithEvents btnRepair As System.Windows.Forms.Button
    Friend WithEvents pStart As System.Windows.Forms.Panel
    Friend WithEvents pInstalled As System.Windows.Forms.Panel
    Friend WithEvents pUninstall As System.Windows.Forms.Panel
    Friend WithEvents pRepair As System.Windows.Forms.Panel
    Friend WithEvents lRepairProgess As System.Windows.Forms.Label
    Friend WithEvents pbRepair1 As System.Windows.Forms.PictureBox
    Friend WithEvents pSplitBottom3 As System.Windows.Forms.Panel
    Friend WithEvents btnClose3 As System.Windows.Forms.Button
    Friend WithEvents lUninstallProgress As System.Windows.Forms.Label
    Friend WithEvents pbUninstall1 As System.Windows.Forms.PictureBox
    Friend WithEvents pSplitBottom2 As System.Windows.Forms.Panel
    Friend WithEvents btnClose2 As System.Windows.Forms.Button
    Friend WithEvents btnUninstall As System.Windows.Forms.Button
    Friend WithEvents pSplitBottom1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose1 As System.Windows.Forms.Button
    Friend WithEvents lInstalled As System.Windows.Forms.Label
    Friend WithEvents pbRepair As System.Windows.Forms.PictureBox
    Friend WithEvents pbUninstall As System.Windows.Forms.PictureBox
    Friend WithEvents pSplitMiddle As System.Windows.Forms.Panel
    Friend WithEvents btnChoose As System.Windows.Forms.Button
    Friend WithEvents pLogo As System.Windows.Forms.Panel
    Friend WithEvents pSplitLogoTop As System.Windows.Forms.Panel
    Friend WithEvents lChooseDirectory As System.Windows.Forms.Label
    Friend WithEvents lWelcome As System.Windows.Forms.Label
    Friend WithEvents cbShortcut As System.Windows.Forms.CheckBox
    Friend WithEvents gpbInstallationProgress As Go__YouTube_Snagger_Installer.GoProgressBar
    Friend WithEvents txtPath As Go__YouTube_Snagger_Installer.GoTextBox
    Friend WithEvents gpbUninstallationProgress As Go__YouTube_Snagger_Installer.GoProgressBar
    Friend WithEvents gpbRepairProgress As Go__YouTube_Snagger_Installer.GoProgressBar

End Class
