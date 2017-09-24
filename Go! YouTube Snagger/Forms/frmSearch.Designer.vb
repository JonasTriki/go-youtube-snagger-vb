<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tCheckButtons = New System.Windows.Forms.Timer(Me.components)
        Me.bwVideoFeed = New System.ComponentModel.BackgroundWorker()
        Me.bwComment = New System.ComponentModel.BackgroundWorker()
        Me.bwPlaylists = New System.ComponentModel.BackgroundWorker()
        Me.tClock = New System.Windows.Forms.Timer(Me.components)
        Me.bwVideoCheck = New System.ComponentModel.BackgroundWorker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lStatusValue = New System.Windows.Forms.Label()
        Me.pbClock = New System.Windows.Forms.PictureBox()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearchOptions = New System.Windows.Forms.Button()
        Me.nudPageComments = New System.Windows.Forms.NumericUpDown()
        Me.nudPageResults = New System.Windows.Forms.NumericUpDown()
        Me.lComments = New System.Windows.Forms.Label()
        Me.btnGotoComments = New System.Windows.Forms.Button()
        Me.lPageComments = New System.Windows.Forms.Label()
        Me.btnPrevPageComments = New System.Windows.Forms.Button()
        Me.btnNextPageComments = New System.Windows.Forms.Button()
        Me.cbUsername = New System.Windows.Forms.ComboBox()
        Me.btnGoToPageResults = New System.Windows.Forms.Button()
        Me.lPageResults = New System.Windows.Forms.Label()
        Me.btnPrevPageResults = New System.Windows.Forms.Button()
        Me.btnNextPageResults = New System.Windows.Forms.Button()
        Me.rbUsername = New System.Windows.Forms.RadioButton()
        Me.rbSearchKeyword = New System.Windows.Forms.RadioButton()
        Me.txtDescription = New Go__YouTube_Snagger.GoTextBox()
        Me.cbComments = New Go__YouTube_Snagger.CommentBox()
        Me.txtUsername = New Go__YouTube_Snagger.GoTextBox()
        Me.lvVideos = New Go__YouTube_Snagger.UnBuggyListView()
        Me.chIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chViews = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chUsername = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chRating = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtKeyword = New Go__YouTube_Snagger.GoTextBox()
        CType(Me.pbClock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPageComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPageResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 441)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(601, 1)
        Me.Panel2.TabIndex = 92
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Enabled = False
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(308, 448)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(185, 23)
        Me.btnAdd.TabIndex = 93
        Me.btnAdd.Text = "Legg til video(er) i liste..."
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(499, 448)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 23)
        Me.btnCancel.TabIndex = 94
        Me.btnCancel.Text = "Avbryt"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tCheckButtons
        '
        Me.tCheckButtons.Enabled = True
        Me.tCheckButtons.Interval = 1
        '
        'bwVideoFeed
        '
        '
        'bwComment
        '
        '
        'bwPlaylists
        '
        '
        'tClock
        '
        Me.tClock.Interval = 50
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Enabled = False
        Me.btnSearch.Location = New System.Drawing.Point(481, 133)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(109, 23)
        Me.btnSearch.TabIndex = 182
        Me.btnSearch.Text = "Søk etter..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lStatusValue
        '
        Me.lStatusValue.AutoSize = True
        Me.lStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatusValue.Location = New System.Drawing.Point(67, 137)
        Me.lStatusValue.Name = "lStatusValue"
        Me.lStatusValue.Size = New System.Drawing.Size(97, 15)
        Me.lStatusValue.TabIndex = 206
        Me.lStatusValue.Text = "Ingen resultater"
        '
        'pbClock
        '
        Me.pbClock.Image = Global.Go__YouTube_Snagger.My.Resources.Resources.downloaded_Normal
        Me.pbClock.Location = New System.Drawing.Point(12, 137)
        Me.pbClock.Name = "pbClock"
        Me.pbClock.Size = New System.Drawing.Size(16, 16)
        Me.pbClock.TabIndex = 205
        Me.pbClock.TabStop = False
        '
        'lStatus
        '
        Me.lStatus.AutoSize = True
        Me.lStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatus.Location = New System.Drawing.Point(28, 137)
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(42, 15)
        Me.lStatus.TabIndex = 189
        Me.lStatus.Text = "Status:"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(0, 145)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(602, 1)
        Me.Panel3.TabIndex = 184
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(602, 1)
        Me.Panel1.TabIndex = 183
        '
        'btnSearchOptions
        '
        Me.btnSearchOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchOptions.Location = New System.Drawing.Point(434, 36)
        Me.btnSearchOptions.Name = "btnSearchOptions"
        Me.btnSearchOptions.Size = New System.Drawing.Size(156, 23)
        Me.btnSearchOptions.TabIndex = 204
        Me.btnSearchOptions.Text = "Søkealternativer..."
        Me.btnSearchOptions.UseVisualStyleBackColor = True
        '
        'nudPageComments
        '
        Me.nudPageComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudPageComments.Location = New System.Drawing.Point(434, 412)
        Me.nudPageComments.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPageComments.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPageComments.Name = "nudPageComments"
        Me.nudPageComments.Size = New System.Drawing.Size(80, 23)
        Me.nudPageComments.TabIndex = 203
        Me.nudPageComments.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudPageResults
        '
        Me.nudPageResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudPageResults.Location = New System.Drawing.Point(265, 277)
        Me.nudPageResults.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPageResults.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPageResults.Name = "nudPageResults"
        Me.nudPageResults.Size = New System.Drawing.Size(57, 23)
        Me.nudPageResults.TabIndex = 202
        Me.nudPageResults.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lComments
        '
        Me.lComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lComments.AutoSize = True
        Me.lComments.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lComments.Location = New System.Drawing.Point(209, 303)
        Me.lComments.Name = "lComments"
        Me.lComments.Size = New System.Drawing.Size(120, 15)
        Me.lComments.TabIndex = 201
        Me.lComments.Text = "Ingen kommentarer"
        '
        'btnGotoComments
        '
        Me.btnGotoComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGotoComments.Enabled = False
        Me.btnGotoComments.Location = New System.Drawing.Point(366, 412)
        Me.btnGotoComments.Name = "btnGotoComments"
        Me.btnGotoComments.Size = New System.Drawing.Size(62, 23)
        Me.btnGotoComments.TabIndex = 200
        Me.btnGotoComments.Text = "Gå til:"
        Me.btnGotoComments.UseVisualStyleBackColor = True
        '
        'lPageComments
        '
        Me.lPageComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lPageComments.AutoSize = True
        Me.lPageComments.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lPageComments.Location = New System.Drawing.Point(209, 416)
        Me.lPageComments.Name = "lPageComments"
        Me.lPageComments.Size = New System.Drawing.Size(67, 15)
        Me.lPageComments.TabIndex = 199
        Me.lPageComments.Text = "Side 0 av 0"
        '
        'btnPrevPageComments
        '
        Me.btnPrevPageComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrevPageComments.Enabled = False
        Me.btnPrevPageComments.Location = New System.Drawing.Point(520, 412)
        Me.btnPrevPageComments.Name = "btnPrevPageComments"
        Me.btnPrevPageComments.Size = New System.Drawing.Size(32, 23)
        Me.btnPrevPageComments.TabIndex = 198
        Me.btnPrevPageComments.Text = "<"
        Me.btnPrevPageComments.UseVisualStyleBackColor = True
        '
        'btnNextPageComments
        '
        Me.btnNextPageComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextPageComments.Enabled = False
        Me.btnNextPageComments.Location = New System.Drawing.Point(558, 412)
        Me.btnNextPageComments.Name = "btnNextPageComments"
        Me.btnNextPageComments.Size = New System.Drawing.Size(32, 23)
        Me.btnNextPageComments.TabIndex = 197
        Me.btnNextPageComments.Text = ">"
        Me.btnNextPageComments.UseVisualStyleBackColor = True
        '
        'cbUsername
        '
        Me.cbUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUsername.Enabled = False
        Me.cbUsername.FormattingEnabled = True
        Me.cbUsername.Location = New System.Drawing.Point(434, 104)
        Me.cbUsername.Name = "cbUsername"
        Me.cbUsername.Size = New System.Drawing.Size(156, 23)
        Me.cbUsername.TabIndex = 196
        '
        'btnGoToPageResults
        '
        Me.btnGoToPageResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGoToPageResults.Enabled = False
        Me.btnGoToPageResults.Location = New System.Drawing.Point(197, 277)
        Me.btnGoToPageResults.Name = "btnGoToPageResults"
        Me.btnGoToPageResults.Size = New System.Drawing.Size(62, 23)
        Me.btnGoToPageResults.TabIndex = 193
        Me.btnGoToPageResults.Text = "Gå til:"
        Me.btnGoToPageResults.UseVisualStyleBackColor = True
        '
        'lPageResults
        '
        Me.lPageResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lPageResults.AutoSize = True
        Me.lPageResults.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lPageResults.Location = New System.Drawing.Point(15, 281)
        Me.lPageResults.Name = "lPageResults"
        Me.lPageResults.Size = New System.Drawing.Size(67, 15)
        Me.lPageResults.TabIndex = 192
        Me.lPageResults.Text = "Side 0 av 0"
        '
        'btnPrevPageResults
        '
        Me.btnPrevPageResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrevPageResults.Enabled = False
        Me.btnPrevPageResults.Location = New System.Drawing.Point(328, 277)
        Me.btnPrevPageResults.Name = "btnPrevPageResults"
        Me.btnPrevPageResults.Size = New System.Drawing.Size(128, 23)
        Me.btnPrevPageResults.TabIndex = 191
        Me.btnPrevPageResults.Text = "< Forrige side"
        Me.btnPrevPageResults.UseVisualStyleBackColor = True
        '
        'btnNextPageResults
        '
        Me.btnNextPageResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextPageResults.Enabled = False
        Me.btnNextPageResults.Location = New System.Drawing.Point(462, 277)
        Me.btnNextPageResults.Name = "btnNextPageResults"
        Me.btnNextPageResults.Size = New System.Drawing.Size(128, 23)
        Me.btnNextPageResults.TabIndex = 190
        Me.btnNextPageResults.Text = "Neste side >"
        Me.btnNextPageResults.UseVisualStyleBackColor = True
        '
        'rbUsername
        '
        Me.rbUsername.AutoSize = True
        Me.rbUsername.Location = New System.Drawing.Point(12, 80)
        Me.rbUsername.Name = "rbUsername"
        Me.rbUsername.Size = New System.Drawing.Size(133, 19)
        Me.rbUsername.TabIndex = 188
        Me.rbUsername.Text = "Søk fra brukernavn..."
        Me.rbUsername.UseVisualStyleBackColor = True
        '
        'rbSearchKeyword
        '
        Me.rbSearchKeyword.AutoSize = True
        Me.rbSearchKeyword.Checked = True
        Me.rbSearchKeyword.Location = New System.Drawing.Point(12, 12)
        Me.rbSearchKeyword.Name = "rbSearchKeyword"
        Me.rbSearchKeyword.Size = New System.Drawing.Size(125, 19)
        Me.rbSearchKeyword.TabIndex = 186
        Me.rbSearchKeyword.TabStop = True
        Me.rbSearchKeyword.Text = "Søk etter søkeord..."
        Me.rbSearchKeyword.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.AutoCompleteCustomSource = Nothing
        Me.txtDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtDescription.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDescription.ContextMenuStrip = Nothing
        Me.txtDescription.CutRadius = 1
        Me.txtDescription.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtDescription.Enabled = False
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDescription.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtDescription.Icon = Nothing
        Me.txtDescription.imgCustomButtonHover = Nothing
        Me.txtDescription.imgCustomButtonNormal = Nothing
        Me.txtDescription.imgCustomButtonPressed = Nothing
        Me.txtDescription.IsReadOnly = True
        Me.txtDescription.Location = New System.Drawing.Point(15, 306)
        Me.txtDescription.MaxLength = 1
        Me.txtDescription.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtDescription.MultiLine = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtDescription.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtDescription.ShowIcon = False
        Me.txtDescription.ShowIsReadOnlyIcon = False
        Me.txtDescription.Size = New System.Drawing.Size(191, 129)
        Me.txtDescription.TabIndex = 195
        '
        'cbComments
        '
        Me.cbComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbComments.BorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.cbComments.Enabled = False
        Me.cbComments.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbComments.Location = New System.Drawing.Point(212, 321)
        Me.cbComments.Name = "cbComments"
        Me.cbComments.Size = New System.Drawing.Size(381, 85)
        Me.cbComments.TabIndex = 194
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.AutoCompleteCustomSource = New String(-1) {}
        Me.txtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtUsername.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUsername.ContextMenuStrip = Nothing
        Me.txtUsername.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtUsername.Enabled = False
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtUsername.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtUsername.Icon = Global.Go__YouTube_Snagger.My.Resources.Resources.youtube
        Me.txtUsername.imgCustomButtonHover = CType(resources.GetObject("txtUsername.imgCustomButtonHover"), System.Drawing.Image)
        Me.txtUsername.imgCustomButtonNormal = CType(resources.GetObject("txtUsername.imgCustomButtonNormal"), System.Drawing.Image)
        Me.txtUsername.imgCustomButtonPressed = CType(resources.GetObject("txtUsername.imgCustomButtonPressed"), System.Drawing.Image)
        Me.txtUsername.Location = New System.Drawing.Point(12, 105)
        Me.txtUsername.MaxLength = 20
        Me.txtUsername.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUsername.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtUsername.ShowIsReadOnlyIcon = False
        Me.txtUsername.Size = New System.Drawing.Size(416, 22)
        Me.txtUsername.TabIndex = 187
        '
        'lvVideos
        '
        Me.lvVideos.AllowDrop = True
        Me.lvVideos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvVideos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chIndex, Me.chTitle, Me.chViews, Me.chUsername, Me.chRating})
        Me.lvVideos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lvVideos.FullRowSelect = True
        Me.lvVideos.GridLines = True
        Me.lvVideos.HideSelection = False
        Me.lvVideos.Location = New System.Drawing.Point(12, 162)
        Me.lvVideos.Name = "lvVideos"
        Me.lvVideos.Size = New System.Drawing.Size(578, 109)
        Me.lvVideos.TabIndex = 185
        Me.lvVideos.UseCompatibleStateImageBehavior = False
        Me.lvVideos.View = System.Windows.Forms.View.Details
        '
        'chIndex
        '
        Me.chIndex.Text = "#"
        Me.chIndex.Width = 27
        '
        'chTitle
        '
        Me.chTitle.Text = "Tittel"
        Me.chTitle.Width = 289
        '
        'chViews
        '
        Me.chViews.Text = "Visninger"
        Me.chViews.Width = 96
        '
        'chUsername
        '
        Me.chUsername.Text = "Brukernavn"
        Me.chUsername.Width = 146
        '
        'chRating
        '
        Me.chRating.Text = "Vurdering"
        Me.chRating.Width = 87
        '
        'txtKeyword
        '
        Me.txtKeyword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKeyword.AutoCompleteCustomSource = New String(-1) {}
        Me.txtKeyword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtKeyword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtKeyword.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtKeyword.ContextMenuStrip = Nothing
        Me.txtKeyword.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtKeyword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeyword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtKeyword.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtKeyword.Icon = CType(resources.GetObject("txtKeyword.Icon"), System.Drawing.Image)
        Me.txtKeyword.imgCustomButtonHover = CType(resources.GetObject("txtKeyword.imgCustomButtonHover"), System.Drawing.Image)
        Me.txtKeyword.imgCustomButtonNormal = CType(resources.GetObject("txtKeyword.imgCustomButtonNormal"), System.Drawing.Image)
        Me.txtKeyword.imgCustomButtonPressed = CType(resources.GetObject("txtKeyword.imgCustomButtonPressed"), System.Drawing.Image)
        Me.txtKeyword.Location = New System.Drawing.Point(12, 37)
        Me.txtKeyword.MaxLength = 32767
        Me.txtKeyword.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtKeyword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKeyword.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtKeyword.ShowIsReadOnlyIcon = False
        Me.txtKeyword.Size = New System.Drawing.Size(416, 22)
        Me.txtKeyword.TabIndex = 181
        '
        'frmSearch
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(602, 483)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lStatusValue)
        Me.Controls.Add(Me.pbClock)
        Me.Controls.Add(Me.lStatus)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSearchOptions)
        Me.Controls.Add(Me.nudPageComments)
        Me.Controls.Add(Me.nudPageResults)
        Me.Controls.Add(Me.lComments)
        Me.Controls.Add(Me.btnGotoComments)
        Me.Controls.Add(Me.lPageComments)
        Me.Controls.Add(Me.btnPrevPageComments)
        Me.Controls.Add(Me.btnNextPageComments)
        Me.Controls.Add(Me.cbUsername)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.cbComments)
        Me.Controls.Add(Me.btnGoToPageResults)
        Me.Controls.Add(Me.lPageResults)
        Me.Controls.Add(Me.btnPrevPageResults)
        Me.Controls.Add(Me.btnNextPageResults)
        Me.Controls.Add(Me.rbUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.rbSearchKeyword)
        Me.Controls.Add(Me.lvVideos)
        Me.Controls.Add(Me.txtKeyword)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(618, 521)
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Søk etter..."
        CType(Me.pbClock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPageComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPageResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tCheckButtons As System.Windows.Forms.Timer
    Friend WithEvents bwVideoFeed As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwComment As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwPlaylists As System.ComponentModel.BackgroundWorker
    Friend WithEvents tClock As System.Windows.Forms.Timer
    Friend WithEvents bwVideoCheck As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lStatusValue As System.Windows.Forms.Label
    Friend WithEvents pbClock As System.Windows.Forms.PictureBox
    Friend WithEvents lStatus As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSearchOptions As System.Windows.Forms.Button
    Friend WithEvents nudPageComments As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudPageResults As System.Windows.Forms.NumericUpDown
    Friend WithEvents lComments As System.Windows.Forms.Label
    Friend WithEvents btnGotoComments As System.Windows.Forms.Button
    Friend WithEvents lPageComments As System.Windows.Forms.Label
    Friend WithEvents btnPrevPageComments As System.Windows.Forms.Button
    Friend WithEvents btnNextPageComments As System.Windows.Forms.Button
    Friend WithEvents cbUsername As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents cbComments As Go__YouTube_Snagger.CommentBox
    Friend WithEvents btnGoToPageResults As System.Windows.Forms.Button
    Friend WithEvents lPageResults As System.Windows.Forms.Label
    Friend WithEvents btnPrevPageResults As System.Windows.Forms.Button
    Friend WithEvents btnNextPageResults As System.Windows.Forms.Button
    Friend WithEvents rbUsername As System.Windows.Forms.RadioButton
    Friend WithEvents txtUsername As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents rbSearchKeyword As System.Windows.Forms.RadioButton
    Friend WithEvents lvVideos As Go__YouTube_Snagger.UnBuggyListView
    Friend WithEvents chIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chViews As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUsername As System.Windows.Forms.ColumnHeader
    Friend WithEvents chRating As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtKeyword As Go__YouTube_Snagger.GoTextBox
End Class
