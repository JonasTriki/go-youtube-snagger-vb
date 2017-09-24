<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownloadProgress
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDownloadProgress))
        Me.lName = New System.Windows.Forms.Label()
        Me.lFolder = New System.Windows.Forms.Label()
        Me.lFolderValue = New System.Windows.Forms.Label()
        Me.pSplit = New System.Windows.Forms.Panel()
        Me.lDownloadedValue = New System.Windows.Forms.Label()
        Me.lDownloaded = New System.Windows.Forms.Label()
        Me.lFileSizeValue = New System.Windows.Forms.Label()
        Me.lFileSize = New System.Windows.Forms.Label()
        Me.lRemaining = New System.Windows.Forms.Label()
        Me.lRemainingValue = New System.Windows.Forms.Label()
        Me.pSplit1 = New System.Windows.Forms.Panel()
        Me.pSplit2 = New System.Windows.Forms.Panel()
        Me.lDownloadSpeedValue = New System.Windows.Forms.Label()
        Me.lDownloadSpeed = New System.Windows.Forms.Label()
        Me.lTimeRemainingValue = New System.Windows.Forms.Label()
        Me.lTimeRemaining = New System.Windows.Forms.Label()
        Me.lTimeElapsedValue = New System.Windows.Forms.Label()
        Me.lTimeElapsed = New System.Windows.Forms.Label()
        Me.pSplit3 = New System.Windows.Forms.Panel()
        Me.lStatusValue = New System.Windows.Forms.Label()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.btnStopDownload = New System.Windows.Forms.Button()
        Me.btnRelatedVideos = New System.Windows.Forms.Button()
        Me.btnOpenVideo = New System.Windows.Forms.Button()
        Me.btnOpenFolder = New System.Windows.Forms.Button()
        Me.lNameValue = New System.Windows.Forms.Label()
        Me.downloadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnStopAllDownloads = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ilStatuses = New System.Windows.Forms.ImageList(Me.components)
        Me.gpbCurrentDownloadProgress = New Go__YouTube_Snagger.GoProgressBar()
        Me.gpbDownloadProgresses = New Go__YouTube_Snagger.GoProgressBar()
        Me.SuspendLayout()
        '
        'lName
        '
        Me.lName.AutoSize = True
        Me.lName.Location = New System.Drawing.Point(12, 73)
        Me.lName.Name = "lName"
        Me.lName.Size = New System.Drawing.Size(41, 15)
        Me.lName.TabIndex = 1
        Me.lName.Text = "Navn: "
        '
        'lFolder
        '
        Me.lFolder.AutoSize = True
        Me.lFolder.Location = New System.Drawing.Point(12, 96)
        Me.lFolder.Name = "lFolder"
        Me.lFolder.Size = New System.Drawing.Size(50, 15)
        Me.lFolder.TabIndex = 3
        Me.lFolder.Text = "Mappe: "
        '
        'lFolderValue
        '
        Me.lFolderValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lFolderValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lFolderValue.Location = New System.Drawing.Point(142, 96)
        Me.lFolderValue.Name = "lFolderValue"
        Me.lFolderValue.Size = New System.Drawing.Size(410, 15)
        Me.lFolderValue.TabIndex = 4
        Me.lFolderValue.Text = "?"
        '
        'pSplit
        '
        Me.pSplit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit.Location = New System.Drawing.Point(0, 122)
        Me.pSplit.Name = "pSplit"
        Me.pSplit.Size = New System.Drawing.Size(564, 1)
        Me.pSplit.TabIndex = 5
        '
        'lDownloadedValue
        '
        Me.lDownloadedValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lDownloadedValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lDownloadedValue.Location = New System.Drawing.Point(142, 157)
        Me.lDownloadedValue.Name = "lDownloadedValue"
        Me.lDownloadedValue.Size = New System.Drawing.Size(410, 15)
        Me.lDownloadedValue.TabIndex = 9
        Me.lDownloadedValue.Text = "?"
        '
        'lDownloaded
        '
        Me.lDownloaded.AutoSize = True
        Me.lDownloaded.Location = New System.Drawing.Point(12, 157)
        Me.lDownloaded.Name = "lDownloaded"
        Me.lDownloaded.Size = New System.Drawing.Size(67, 15)
        Me.lDownloaded.TabIndex = 8
        Me.lDownloaded.Text = "Lastet ned: "
        '
        'lFileSizeValue
        '
        Me.lFileSizeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lFileSizeValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lFileSizeValue.Location = New System.Drawing.Point(142, 134)
        Me.lFileSizeValue.Name = "lFileSizeValue"
        Me.lFileSizeValue.Size = New System.Drawing.Size(410, 15)
        Me.lFileSizeValue.TabIndex = 7
        Me.lFileSizeValue.Text = "?"
        '
        'lFileSize
        '
        Me.lFileSize.AutoSize = True
        Me.lFileSize.Location = New System.Drawing.Point(12, 134)
        Me.lFileSize.Name = "lFileSize"
        Me.lFileSize.Size = New System.Drawing.Size(58, 15)
        Me.lFileSize.TabIndex = 6
        Me.lFileSize.Text = "Størrelse: "
        '
        'lRemaining
        '
        Me.lRemaining.AutoSize = True
        Me.lRemaining.Location = New System.Drawing.Point(12, 180)
        Me.lRemaining.Name = "lRemaining"
        Me.lRemaining.Size = New System.Drawing.Size(56, 15)
        Me.lRemaining.TabIndex = 10
        Me.lRemaining.Text = "Gjenstår: "
        '
        'lRemainingValue
        '
        Me.lRemainingValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lRemainingValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lRemainingValue.Location = New System.Drawing.Point(142, 180)
        Me.lRemainingValue.Name = "lRemainingValue"
        Me.lRemainingValue.Size = New System.Drawing.Size(410, 15)
        Me.lRemainingValue.TabIndex = 11
        Me.lRemainingValue.Text = "?"
        '
        'pSplit1
        '
        Me.pSplit1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit1.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit1.Location = New System.Drawing.Point(0, 206)
        Me.pSplit1.Name = "pSplit1"
        Me.pSplit1.Size = New System.Drawing.Size(564, 1)
        Me.pSplit1.TabIndex = 6
        '
        'pSplit2
        '
        Me.pSplit2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit2.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit2.Location = New System.Drawing.Point(0, 290)
        Me.pSplit2.Name = "pSplit2"
        Me.pSplit2.Size = New System.Drawing.Size(564, 1)
        Me.pSplit2.TabIndex = 13
        '
        'lDownloadSpeedValue
        '
        Me.lDownloadSpeedValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lDownloadSpeedValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lDownloadSpeedValue.Location = New System.Drawing.Point(142, 264)
        Me.lDownloadSpeedValue.Name = "lDownloadSpeedValue"
        Me.lDownloadSpeedValue.Size = New System.Drawing.Size(410, 15)
        Me.lDownloadSpeedValue.TabIndex = 18
        Me.lDownloadSpeedValue.Text = "?"
        '
        'lDownloadSpeed
        '
        Me.lDownloadSpeed.AutoSize = True
        Me.lDownloadSpeed.Location = New System.Drawing.Point(12, 264)
        Me.lDownloadSpeed.Name = "lDownloadSpeed"
        Me.lDownloadSpeed.Size = New System.Drawing.Size(124, 15)
        Me.lDownloadSpeed.TabIndex = 17
        Me.lDownloadSpeed.Text = "Nedlastingshastighet: "
        '
        'lTimeRemainingValue
        '
        Me.lTimeRemainingValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lTimeRemainingValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTimeRemainingValue.Location = New System.Drawing.Point(142, 241)
        Me.lTimeRemainingValue.Name = "lTimeRemainingValue"
        Me.lTimeRemainingValue.Size = New System.Drawing.Size(410, 15)
        Me.lTimeRemainingValue.TabIndex = 16
        Me.lTimeRemainingValue.Text = "?"
        '
        'lTimeRemaining
        '
        Me.lTimeRemaining.AutoSize = True
        Me.lTimeRemaining.Location = New System.Drawing.Point(12, 241)
        Me.lTimeRemaining.Name = "lTimeRemaining"
        Me.lTimeRemaining.Size = New System.Drawing.Size(59, 15)
        Me.lTimeRemaining.TabIndex = 15
        Me.lTimeRemaining.Text = "Tid igjen: "
        '
        'lTimeElapsedValue
        '
        Me.lTimeElapsedValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lTimeElapsedValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTimeElapsedValue.Location = New System.Drawing.Point(142, 218)
        Me.lTimeElapsedValue.Name = "lTimeElapsedValue"
        Me.lTimeElapsedValue.Size = New System.Drawing.Size(410, 15)
        Me.lTimeElapsedValue.TabIndex = 14
        Me.lTimeElapsedValue.Text = "?"
        '
        'lTimeElapsed
        '
        Me.lTimeElapsed.AutoSize = True
        Me.lTimeElapsed.Location = New System.Drawing.Point(12, 218)
        Me.lTimeElapsed.Name = "lTimeElapsed"
        Me.lTimeElapsed.Size = New System.Drawing.Size(61, 15)
        Me.lTimeElapsed.TabIndex = 12
        Me.lTimeElapsed.Text = "Tid brukt: "
        '
        'pSplit3
        '
        Me.pSplit3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit3.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit3.Location = New System.Drawing.Point(0, 328)
        Me.pSplit3.Name = "pSplit3"
        Me.pSplit3.Size = New System.Drawing.Size(564, 1)
        Me.pSplit3.TabIndex = 19
        '
        'lStatusValue
        '
        Me.lStatusValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatusValue.Location = New System.Drawing.Point(142, 302)
        Me.lStatusValue.Name = "lStatusValue"
        Me.lStatusValue.Size = New System.Drawing.Size(410, 15)
        Me.lStatusValue.TabIndex = 21
        Me.lStatusValue.Text = "?"
        '
        'lStatus
        '
        Me.lStatus.AutoSize = True
        Me.lStatus.Location = New System.Drawing.Point(9, 302)
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(45, 15)
        Me.lStatus.TabIndex = 20
        Me.lStatus.Text = "Status: "
        '
        'btnStopDownload
        '
        Me.btnStopDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStopDownload.Location = New System.Drawing.Point(449, 11)
        Me.btnStopDownload.Name = "btnStopDownload"
        Me.btnStopDownload.Size = New System.Drawing.Size(103, 24)
        Me.btnStopDownload.TabIndex = 22
        Me.btnStopDownload.Text = "Stopp"
        Me.btnStopDownload.UseVisualStyleBackColor = True
        '
        'btnRelatedVideos
        '
        Me.btnRelatedVideos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRelatedVideos.Enabled = False
        Me.btnRelatedVideos.Location = New System.Drawing.Point(320, 335)
        Me.btnRelatedVideos.Name = "btnRelatedVideos"
        Me.btnRelatedVideos.Size = New System.Drawing.Size(150, 23)
        Me.btnRelatedVideos.TabIndex = 23
        Me.btnRelatedVideos.Text = "Vis relaterte videoer..."
        Me.btnRelatedVideos.UseVisualStyleBackColor = True
        '
        'btnOpenVideo
        '
        Me.btnOpenVideo.Enabled = False
        Me.btnOpenVideo.Location = New System.Drawing.Point(12, 335)
        Me.btnOpenVideo.Name = "btnOpenVideo"
        Me.btnOpenVideo.Size = New System.Drawing.Size(100, 23)
        Me.btnOpenVideo.TabIndex = 24
        Me.btnOpenVideo.Text = "Åpne video"
        Me.btnOpenVideo.UseVisualStyleBackColor = True
        '
        'btnOpenFolder
        '
        Me.btnOpenFolder.Enabled = False
        Me.btnOpenFolder.Location = New System.Drawing.Point(118, 335)
        Me.btnOpenFolder.Name = "btnOpenFolder"
        Me.btnOpenFolder.Size = New System.Drawing.Size(97, 23)
        Me.btnOpenFolder.TabIndex = 25
        Me.btnOpenFolder.Text = "Åpne mappe"
        Me.btnOpenFolder.UseVisualStyleBackColor = True
        '
        'lNameValue
        '
        Me.lNameValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lNameValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lNameValue.Location = New System.Drawing.Point(142, 73)
        Me.lNameValue.Name = "lNameValue"
        Me.lNameValue.Size = New System.Drawing.Size(410, 15)
        Me.lNameValue.TabIndex = 2
        Me.lNameValue.Text = "?"
        '
        'downloadTimer
        '
        Me.downloadTimer.Interval = 1000
        '
        'btnStopAllDownloads
        '
        Me.btnStopAllDownloads.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStopAllDownloads.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStopAllDownloads.Location = New System.Drawing.Point(449, 39)
        Me.btnStopAllDownloads.Name = "btnStopAllDownloads"
        Me.btnStopAllDownloads.Size = New System.Drawing.Size(103, 24)
        Me.btnStopAllDownloads.TabIndex = 28
        Me.btnStopAllDownloads.Text = "Stopp alle"
        Me.btnStopAllDownloads.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Enabled = False
        Me.btnClose.Location = New System.Drawing.Point(476, 335)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 29
        Me.btnClose.Text = "Lukk"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ilStatuses
        '
        Me.ilStatuses.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilStatuses.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilStatuses.TransparentColor = System.Drawing.Color.Transparent
        '
        'gpbCurrentDownloadProgress
        '
        Me.gpbCurrentDownloadProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbCurrentDownloadProgress.BackgroundColor = System.Drawing.Color.White
        Me.gpbCurrentDownloadProgress.BlockColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.gpbCurrentDownloadProgress.BorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.gpbCurrentDownloadProgress.ExtraText = "Gjeldende nedlasting:"
        Me.gpbCurrentDownloadProgress.Icon = Global.Go__YouTube_Snagger.My.Resources.Resources.downloading_Normal
        Me.gpbCurrentDownloadProgress.Location = New System.Drawing.Point(12, 12)
        Me.gpbCurrentDownloadProgress.MaxValue = 100.0R
        Me.gpbCurrentDownloadProgress.MinValue = 0.0R
        Me.gpbCurrentDownloadProgress.Name = "gpbCurrentDownloadProgress"
        Me.gpbCurrentDownloadProgress.ShowIcon = True
        Me.gpbCurrentDownloadProgress.Size = New System.Drawing.Size(431, 22)
        Me.gpbCurrentDownloadProgress.TabIndex = 27
        Me.gpbCurrentDownloadProgress.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.gpbCurrentDownloadProgress.TextFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbCurrentDownloadProgress.Value = 0.0R
        '
        'gpbDownloadProgresses
        '
        Me.gpbDownloadProgresses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbDownloadProgresses.BackgroundColor = System.Drawing.Color.White
        Me.gpbDownloadProgresses.BlockColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.gpbDownloadProgresses.BorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.gpbDownloadProgresses.ExtraText = "Alle nedlastinger:"
        Me.gpbDownloadProgresses.Icon = Global.Go__YouTube_Snagger.My.Resources.Resources.downloading_Normal
        Me.gpbDownloadProgresses.Location = New System.Drawing.Point(12, 40)
        Me.gpbDownloadProgresses.MaxValue = 100.0R
        Me.gpbDownloadProgresses.MinValue = 0.0R
        Me.gpbDownloadProgresses.Name = "gpbDownloadProgresses"
        Me.gpbDownloadProgresses.ShowIcon = True
        Me.gpbDownloadProgresses.Size = New System.Drawing.Size(431, 22)
        Me.gpbDownloadProgresses.TabIndex = 0
        Me.gpbDownloadProgresses.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.gpbDownloadProgresses.TextFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbDownloadProgresses.Value = 0.0R
        '
        'frmDownloadProgress
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(564, 370)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStopAllDownloads)
        Me.Controls.Add(Me.gpbCurrentDownloadProgress)
        Me.Controls.Add(Me.btnOpenFolder)
        Me.Controls.Add(Me.btnOpenVideo)
        Me.Controls.Add(Me.btnRelatedVideos)
        Me.Controls.Add(Me.btnStopDownload)
        Me.Controls.Add(Me.pSplit3)
        Me.Controls.Add(Me.lStatusValue)
        Me.Controls.Add(Me.pSplit2)
        Me.Controls.Add(Me.lStatus)
        Me.Controls.Add(Me.pSplit1)
        Me.Controls.Add(Me.lDownloadSpeedValue)
        Me.Controls.Add(Me.lRemainingValue)
        Me.Controls.Add(Me.lDownloadSpeed)
        Me.Controls.Add(Me.lRemaining)
        Me.Controls.Add(Me.lTimeRemainingValue)
        Me.Controls.Add(Me.lDownloadedValue)
        Me.Controls.Add(Me.lTimeRemaining)
        Me.Controls.Add(Me.lDownloaded)
        Me.Controls.Add(Me.lTimeElapsedValue)
        Me.Controls.Add(Me.lFileSizeValue)
        Me.Controls.Add(Me.lTimeElapsed)
        Me.Controls.Add(Me.lFileSize)
        Me.Controls.Add(Me.pSplit)
        Me.Controls.Add(Me.lFolderValue)
        Me.Controls.Add(Me.lFolder)
        Me.Controls.Add(Me.lNameValue)
        Me.Controls.Add(Me.lName)
        Me.Controls.Add(Me.gpbDownloadProgresses)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDownloadProgress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "0% - ? - Last ned..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpbDownloadProgresses As Go__YouTube_Snagger.GoProgressBar
    Friend WithEvents lName As System.Windows.Forms.Label
    Friend WithEvents lFolder As System.Windows.Forms.Label
    Friend WithEvents lFolderValue As System.Windows.Forms.Label
    Friend WithEvents pSplit As System.Windows.Forms.Panel
    Friend WithEvents lDownloadedValue As System.Windows.Forms.Label
    Friend WithEvents lDownloaded As System.Windows.Forms.Label
    Friend WithEvents lFileSizeValue As System.Windows.Forms.Label
    Friend WithEvents lFileSize As System.Windows.Forms.Label
    Friend WithEvents lRemaining As System.Windows.Forms.Label
    Friend WithEvents lRemainingValue As System.Windows.Forms.Label
    Friend WithEvents pSplit1 As System.Windows.Forms.Panel
    Friend WithEvents pSplit2 As System.Windows.Forms.Panel
    Friend WithEvents lDownloadSpeedValue As System.Windows.Forms.Label
    Friend WithEvents lDownloadSpeed As System.Windows.Forms.Label
    Friend WithEvents lTimeRemainingValue As System.Windows.Forms.Label
    Friend WithEvents lTimeRemaining As System.Windows.Forms.Label
    Friend WithEvents lTimeElapsedValue As System.Windows.Forms.Label
    Friend WithEvents lTimeElapsed As System.Windows.Forms.Label
    Friend WithEvents pSplit3 As System.Windows.Forms.Panel
    Friend WithEvents lStatusValue As System.Windows.Forms.Label
    Friend WithEvents lStatus As System.Windows.Forms.Label
    Friend WithEvents btnStopDownload As System.Windows.Forms.Button
    Friend WithEvents btnRelatedVideos As System.Windows.Forms.Button
    Friend WithEvents btnOpenVideo As System.Windows.Forms.Button
    Friend WithEvents btnOpenFolder As System.Windows.Forms.Button
    Friend WithEvents lNameValue As System.Windows.Forms.Label
    Friend WithEvents downloadTimer As System.Windows.Forms.Timer
    Friend WithEvents gpbCurrentDownloadProgress As Go__YouTube_Snagger.GoProgressBar
    Friend WithEvents btnStopAllDownloads As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ilStatuses As System.Windows.Forms.ImageList
End Class
