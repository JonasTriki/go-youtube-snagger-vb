<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.clockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnOptions = New System.Windows.Forms.Button()
        Me.niSystem = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmniSystem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InstillingerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OmGoYoutubeSnaggerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvsluttToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pSplit = New System.Windows.Forms.Panel()
        Me.btnRemoveVideos = New System.Windows.Forms.Button()
        Me.btnShowThumbnailImages = New System.Windows.Forms.Button()
        Me.btnCopyVideoURL = New System.Windows.Forms.Button()
        Me.btnCopyVideoID = New System.Windows.Forms.Button()
        Me.btnOpenVideoURL = New System.Windows.Forms.Button()
        Me.cbQuality = New System.Windows.Forms.ComboBox()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.lStatusValue = New System.Windows.Forms.Label()
        Me.pSplit2 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.tListView = New System.Windows.Forms.Timer(Me.components)
        Me.ilStatuses = New System.Windows.Forms.ImageList(Me.components)
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.btnReportBug = New System.Windows.Forms.Button()
        Me.bwUpdate = New System.ComponentModel.BackgroundWorker()
        Me.bwVideoCheck = New System.ComponentModel.BackgroundWorker()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnSendList = New System.Windows.Forms.Button()
        Me.btnDownloadVideos = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPlayVideo = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lvVideos = New Go__YouTube_Snagger.UnBuggyListView()
        Me.chFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFileFolder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chVideoQuality = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chUserName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chVideoID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chVideoURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GoManager = New Go__YouTube_Snagger.GoManager(Me.components)
        Me.ibRestart = New Go__YouTube_Snagger.InfoBar()
        Me.txtURL = New Go__YouTube_Snagger.GoTextBox()
        Me.btnAddVideo = New System.Windows.Forms.Button()
        Me.cmniSystem.SuspendLayout()
        Me.SuspendLayout()
        '
        'clockTimer
        '
        Me.clockTimer.Interval = 50
        '
        'btnAbout
        '
        Me.btnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbout.Location = New System.Drawing.Point(12, 443)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(231, 23)
        Me.btnAbout.TabIndex = 11
        Me.btnAbout.Text = "Om Go! YouTube Snagger..."
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'btnOptions
        '
        Me.btnOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOptions.Location = New System.Drawing.Point(249, 443)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(102, 23)
        Me.btnOptions.TabIndex = 12
        Me.btnOptions.Text = "Innstillinger..."
        Me.btnOptions.UseVisualStyleBackColor = True
        '
        'niSystem
        '
        Me.niSystem.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.niSystem.BalloonTipText = "Go! YouTube Snagger har blitt minimert til systemfeltet, for å gjennopprette appl" & _
    "ikasjonen igjen, klikk på boblen..."
        Me.niSystem.BalloonTipTitle = "Go! YouTube Snagger"
        Me.niSystem.ContextMenuStrip = Me.cmniSystem
        Me.niSystem.Icon = CType(resources.GetObject("niSystem.Icon"), System.Drawing.Icon)
        Me.niSystem.Text = "Go! YouTube Snagger"
        Me.niSystem.Visible = True
        '
        'cmniSystem
        '
        Me.cmniSystem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstillingerToolStripMenuItem, Me.ToolStripSeparator2, Me.OmGoYoutubeSnaggerToolStripMenuItem, Me.AvsluttToolStripMenuItem})
        Me.cmniSystem.Name = "cmniSystem"
        Me.cmniSystem.Size = New System.Drawing.Size(219, 76)
        '
        'InstillingerToolStripMenuItem
        '
        Me.InstillingerToolStripMenuItem.Name = "InstillingerToolStripMenuItem"
        Me.InstillingerToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.InstillingerToolStripMenuItem.Text = "Instillinger..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(215, 6)
        '
        'OmGoYoutubeSnaggerToolStripMenuItem
        '
        Me.OmGoYoutubeSnaggerToolStripMenuItem.Name = "OmGoYoutubeSnaggerToolStripMenuItem"
        Me.OmGoYoutubeSnaggerToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.OmGoYoutubeSnaggerToolStripMenuItem.Text = "Om Go! Youtube Snagger..."
        '
        'AvsluttToolStripMenuItem
        '
        Me.AvsluttToolStripMenuItem.Name = "AvsluttToolStripMenuItem"
        Me.AvsluttToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AvsluttToolStripMenuItem.Text = "Avslutt"
        '
        'pSplit
        '
        Me.pSplit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pSplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pSplit.Location = New System.Drawing.Point(0, 89)
        Me.pSplit.Name = "pSplit"
        Me.pSplit.Size = New System.Drawing.Size(794, 1)
        Me.pSplit.TabIndex = 10
        '
        'btnRemoveVideos
        '
        Me.btnRemoveVideos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveVideos.Enabled = False
        Me.btnRemoveVideos.Location = New System.Drawing.Point(627, 96)
        Me.btnRemoveVideos.Name = "btnRemoveVideos"
        Me.btnRemoveVideos.Size = New System.Drawing.Size(155, 23)
        Me.btnRemoveVideos.TabIndex = 27
        Me.btnRemoveVideos.Text = "Fjern video(er)..."
        Me.btnRemoveVideos.UseVisualStyleBackColor = True
        '
        'btnShowThumbnailImages
        '
        Me.btnShowThumbnailImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnShowThumbnailImages.Enabled = False
        Me.btnShowThumbnailImages.Location = New System.Drawing.Point(627, 190)
        Me.btnShowThumbnailImages.Name = "btnShowThumbnailImages"
        Me.btnShowThumbnailImages.Size = New System.Drawing.Size(155, 23)
        Me.btnShowThumbnailImages.TabIndex = 26
        Me.btnShowThumbnailImages.Text = "Vis miniatyr bilder..."
        Me.btnShowThumbnailImages.UseVisualStyleBackColor = True
        '
        'btnCopyVideoURL
        '
        Me.btnCopyVideoURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopyVideoURL.Enabled = False
        Me.btnCopyVideoURL.Location = New System.Drawing.Point(627, 407)
        Me.btnCopyVideoURL.Name = "btnCopyVideoURL"
        Me.btnCopyVideoURL.Size = New System.Drawing.Size(155, 23)
        Me.btnCopyVideoURL.TabIndex = 25
        Me.btnCopyVideoURL.Text = "Kopier video link"
        Me.btnCopyVideoURL.UseVisualStyleBackColor = True
        '
        'btnCopyVideoID
        '
        Me.btnCopyVideoID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopyVideoID.Enabled = False
        Me.btnCopyVideoID.Location = New System.Drawing.Point(627, 378)
        Me.btnCopyVideoID.Name = "btnCopyVideoID"
        Me.btnCopyVideoID.Size = New System.Drawing.Size(155, 23)
        Me.btnCopyVideoID.TabIndex = 24
        Me.btnCopyVideoID.Text = "Kopier video ID"
        Me.btnCopyVideoID.UseVisualStyleBackColor = True
        '
        'btnOpenVideoURL
        '
        Me.btnOpenVideoURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpenVideoURL.Enabled = False
        Me.btnOpenVideoURL.Location = New System.Drawing.Point(627, 125)
        Me.btnOpenVideoURL.Name = "btnOpenVideoURL"
        Me.btnOpenVideoURL.Size = New System.Drawing.Size(155, 23)
        Me.btnOpenVideoURL.TabIndex = 23
        Me.btnOpenVideoURL.Text = "Åpne video link..."
        Me.btnOpenVideoURL.UseVisualStyleBackColor = True
        '
        'cbQuality
        '
        Me.cbQuality.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQuality.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbQuality.FormattingEnabled = True
        Me.cbQuality.Items.AddRange(New Object() {"144p - 176x144", "240p - 400x240", "360p - 480x360", "360p - 640x360", "480p - 854x480", "480p - 854x480 - WebM(HTML5)", "720p - 1280x720", "720p - 1280x720 - WebM(HTML5)", "1080p - 1920x1080", "4096p - 4096x3072/4096x2304"})
        Me.cbQuality.Location = New System.Drawing.Point(548, 34)
        Me.cbQuality.Name = "cbQuality"
        Me.cbQuality.Size = New System.Drawing.Size(234, 23)
        Me.cbQuality.TabIndex = 7
        '
        'lStatus
        '
        Me.lStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lStatus.AutoSize = True
        Me.lStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lStatus.Location = New System.Drawing.Point(9, 65)
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(42, 15)
        Me.lStatus.TabIndex = 8
        Me.lStatus.Text = "Status:"
        '
        'lStatusValue
        '
        Me.lStatusValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatusValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lStatusValue.Location = New System.Drawing.Point(57, 65)
        Me.lStatusValue.Name = "lStatusValue"
        Me.lStatusValue.Size = New System.Drawing.Size(485, 15)
        Me.lStatusValue.TabIndex = 9
        Me.lStatusValue.Text = "Vennligst skriv inn en gyldig YouTube video link..."
        '
        'pSplit2
        '
        Me.pSplit2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pSplit2.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pSplit2.Location = New System.Drawing.Point(0, 436)
        Me.pSplit2.Name = "pSplit2"
        Me.pSplit2.Size = New System.Drawing.Size(794, 1)
        Me.pSplit2.TabIndex = 11
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(524, 443)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(97, 23)
        Me.btnExit.TabIndex = 29
        Me.btnExit.Text = "Avslutt..."
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'tListView
        '
        Me.tListView.Enabled = True
        Me.tListView.Interval = 1
        '
        'ilStatuses
        '
        Me.ilStatuses.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilStatuses.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilStatuses.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMoveDown.Enabled = False
        Me.btnMoveDown.Location = New System.Drawing.Point(627, 349)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(155, 23)
        Me.btnMoveDown.TabIndex = 30
        Me.btnMoveDown.Text = "Flytt ned..."
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMoveUp.Enabled = False
        Me.btnMoveUp.Location = New System.Drawing.Point(627, 320)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(155, 23)
        Me.btnMoveUp.TabIndex = 31
        Me.btnMoveUp.Text = "Flytt opp..."
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnReportBug
        '
        Me.btnReportBug.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReportBug.Location = New System.Drawing.Point(357, 443)
        Me.btnReportBug.Name = "btnReportBug"
        Me.btnReportBug.Size = New System.Drawing.Size(128, 23)
        Me.btnReportBug.TabIndex = 33
        Me.btnReportBug.Text = "Raporter en feil..."
        Me.btnReportBug.UseVisualStyleBackColor = True
        '
        'bwUpdate
        '
        '
        'bwVideoCheck
        '
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Enabled = False
        Me.btnExport.Location = New System.Drawing.Point(627, 226)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(155, 23)
        Me.btnExport.TabIndex = 34
        Me.btnExport.Text = "Eksporter liste..."
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(627, 255)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(155, 23)
        Me.btnImport.TabIndex = 36
        Me.btnImport.Text = "Importer liste..."
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnSendList
        '
        Me.btnSendList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSendList.Location = New System.Drawing.Point(627, 284)
        Me.btnSendList.Name = "btnSendList"
        Me.btnSendList.Size = New System.Drawing.Size(155, 23)
        Me.btnSendList.TabIndex = 37
        Me.btnSendList.Text = "Send liste til..."
        Me.btnSendList.UseVisualStyleBackColor = True
        '
        'btnDownloadVideos
        '
        Me.btnDownloadVideos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDownloadVideos.Enabled = False
        Me.btnDownloadVideos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownloadVideos.Location = New System.Drawing.Point(627, 443)
        Me.btnDownloadVideos.Name = "btnDownloadVideos"
        Me.btnDownloadVideos.Size = New System.Drawing.Size(155, 23)
        Me.btnDownloadVideos.TabIndex = 0
        Me.btnDownloadVideos.Text = "Last ned videoer..."
        Me.btnDownloadVideos.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(548, 61)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(109, 23)
        Me.btnSearch.TabIndex = 39
        Me.btnSearch.Text = "Søk etter..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(621, 219)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(173, 1)
        Me.Panel1.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(621, 313)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(173, 1)
        Me.Panel2.TabIndex = 11
        '
        'btnPlayVideo
        '
        Me.btnPlayVideo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPlayVideo.Enabled = False
        Me.btnPlayVideo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnPlayVideo.Location = New System.Drawing.Point(627, 161)
        Me.btnPlayVideo.Name = "btnPlayVideo"
        Me.btnPlayVideo.Size = New System.Drawing.Size(155, 23)
        Me.btnPlayVideo.TabIndex = 26
        Me.btnPlayVideo.Text = "Spill av video..."
        Me.btnPlayVideo.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(621, 154)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(173, 1)
        Me.Panel3.TabIndex = 11
        '
        'lvVideos
        '
        Me.lvVideos.AllowDrop = True
        Me.lvVideos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvVideos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chFileName, Me.chIndex, Me.chFileFolder, Me.chVideoQuality, Me.chTitle, Me.chUserName, Me.chVideoID, Me.chVideoURL})
        Me.lvVideos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lvVideos.FullRowSelect = True
        Me.lvVideos.GridLines = True
        Me.lvVideos.HideSelection = False
        Me.lvVideos.Location = New System.Drawing.Point(12, 96)
        Me.lvVideos.Name = "lvVideos"
        Me.lvVideos.Size = New System.Drawing.Size(609, 334)
        Me.lvVideos.SmallImageList = Me.ilStatuses
        Me.lvVideos.TabIndex = 20
        Me.lvVideos.UseCompatibleStateImageBehavior = False
        Me.lvVideos.View = System.Windows.Forms.View.Details
        '
        'chFileName
        '
        Me.chFileName.Text = "Filnavn"
        Me.chFileName.Width = 300
        '
        'chIndex
        '
        Me.chIndex.Text = "#"
        Me.chIndex.Width = 30
        '
        'chFileFolder
        '
        Me.chFileFolder.Text = "Mappe"
        Me.chFileFolder.Width = 149
        '
        'chVideoQuality
        '
        Me.chVideoQuality.Text = "Video kvalitet"
        Me.chVideoQuality.Width = 136
        '
        'chTitle
        '
        Me.chTitle.Text = "Video tittel"
        Me.chTitle.Width = 169
        '
        'chUserName
        '
        Me.chUserName.Text = "Brukernavn"
        Me.chUserName.Width = 115
        '
        'chVideoID
        '
        Me.chVideoID.Text = "Video ID"
        Me.chVideoID.Width = 115
        '
        'chVideoURL
        '
        Me.chVideoURL.Text = "Video link"
        Me.chVideoURL.Width = 308
        '
        'ibRestart
        '
        Me.ibRestart.BackColor = System.Drawing.Color.Transparent
        Me.ibRestart.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.ibRestart.BackgroundColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.ibRestart.BorderColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.ibRestart.CloseButtonContextMenuStrip = Nothing
        Me.ibRestart.Dock = System.Windows.Forms.DockStyle.Top
        Me.ibRestart.ExtraButtonCaption = ""
        Me.ibRestart.Icon = CType(resources.GetObject("ibRestart.Icon"), System.Drawing.Image)
        Me.ibRestart.Location = New System.Drawing.Point(0, 0)
        Me.ibRestart.Message = ""
        Me.ibRestart.Name = "ibRestart"
        Me.ibRestart.ShowExtraButton = True
        Me.ibRestart.Size = New System.Drawing.Size(794, 22)
        Me.ibRestart.TabIndex = 32
        Me.ibRestart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ibRestart.Visible = False
        '
        'txtURL
        '
        Me.txtURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtURL.AutoCompleteCustomSource = New String(-1) {}
        Me.txtURL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtURL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl
        Me.txtURL.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtURL.ContextMenuStrip = Nothing
        Me.txtURL.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtURL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtURL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtURL.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtURL.Icon = Global.Go__YouTube_Snagger.My.Resources.Resources.youtube
        Me.txtURL.imgCustomButtonHover = CType(resources.GetObject("txtURL.imgCustomButtonHover"), System.Drawing.Image)
        Me.txtURL.imgCustomButtonNormal = CType(resources.GetObject("txtURL.imgCustomButtonNormal"), System.Drawing.Image)
        Me.txtURL.imgCustomButtonPressed = CType(resources.GetObject("txtURL.imgCustomButtonPressed"), System.Drawing.Image)
        Me.txtURL.Location = New System.Drawing.Point(12, 34)
        Me.txtURL.MaxLength = 32767
        Me.txtURL.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtURL.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtURL.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtURL.ShowIsReadOnlyIcon = False
        Me.txtURL.Size = New System.Drawing.Size(530, 22)
        Me.txtURL.TabIndex = 0
        '
        'btnAddVideo
        '
        Me.btnAddVideo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddVideo.Enabled = False
        Me.btnAddVideo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddVideo.Location = New System.Drawing.Point(663, 61)
        Me.btnAddVideo.Name = "btnAddVideo"
        Me.btnAddVideo.Size = New System.Drawing.Size(119, 23)
        Me.btnAddVideo.TabIndex = 13
        Me.btnAddVideo.Text = "Legg til video..."
        Me.btnAddVideo.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(794, 478)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnSendList)
        Me.Controls.Add(Me.btnReportBug)
        Me.Controls.Add(Me.ibRestart)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnMoveUp)
        Me.Controls.Add(Me.btnMoveDown)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pSplit2)
        Me.Controls.Add(Me.btnRemoveVideos)
        Me.Controls.Add(Me.btnCopyVideoURL)
        Me.Controls.Add(Me.btnCopyVideoID)
        Me.Controls.Add(Me.btnOpenVideoURL)
        Me.Controls.Add(Me.btnPlayVideo)
        Me.Controls.Add(Me.btnShowThumbnailImages)
        Me.Controls.Add(Me.btnOptions)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.lvVideos)
        Me.Controls.Add(Me.btnDownloadVideos)
        Me.Controls.Add(Me.pSplit)
        Me.Controls.Add(Me.lStatusValue)
        Me.Controls.Add(Me.lStatus)
        Me.Controls.Add(Me.btnAddVideo)
        Me.Controls.Add(Me.cbQuality)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Go! YouTube Snagger"
        Me.cmniSystem.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clockTimer As System.Windows.Forms.Timer
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents btnOptions As System.Windows.Forms.Button
    Friend WithEvents GoManager As Go__YouTube_Snagger.GoManager
    Friend WithEvents cmniSystem As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents InstillingerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lvVideos As Go__YouTube_Snagger.UnBuggyListView
    Friend WithEvents chFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFileFolder As System.Windows.Forms.ColumnHeader
    Friend WithEvents chVideoQuality As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUserName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chVideoID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chVideoURL As System.Windows.Forms.ColumnHeader
    Friend WithEvents pSplit As System.Windows.Forms.Panel
    Friend WithEvents btnRemoveVideos As System.Windows.Forms.Button
    Friend WithEvents btnShowThumbnailImages As System.Windows.Forms.Button
    Friend WithEvents btnCopyVideoURL As System.Windows.Forms.Button
    Friend WithEvents btnCopyVideoID As System.Windows.Forms.Button
    Friend WithEvents btnOpenVideoURL As System.Windows.Forms.Button
    Friend WithEvents txtURL As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents cbQuality As System.Windows.Forms.ComboBox
    Friend WithEvents lStatus As System.Windows.Forms.Label
    Friend WithEvents lStatusValue As System.Windows.Forms.Label
    Friend WithEvents pSplit2 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents tListView As System.Windows.Forms.Timer
    Friend WithEvents ilStatuses As System.Windows.Forms.ImageList
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents OmGoYoutubeSnaggerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvsluttToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ibRestart As Go__YouTube_Snagger.InfoBar
    Friend WithEvents niSystem As System.Windows.Forms.NotifyIcon
    Friend WithEvents btnReportBug As System.Windows.Forms.Button
    Friend WithEvents bwUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwVideoCheck As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnSendList As System.Windows.Forms.Button
    Friend WithEvents btnDownloadVideos As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnPlayVideo As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnAddVideo As System.Windows.Forms.Button

End Class
