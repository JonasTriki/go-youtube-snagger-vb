<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportBug
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportBug))
        Me.lName = New System.Windows.Forms.Label()
        Me.lError = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSendError = New System.Windows.Forms.Button()
        Me.tCheck = New System.Windows.Forms.Timer(Me.components)
        Me.clockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lSecurityControl = New System.Windows.Forms.Label()
        Me.lMessageCount = New System.Windows.Forms.Label()
        Me.lCode = New System.Windows.Forms.Label()
        Me.pbReload = New System.Windows.Forms.PictureBox()
        Me.pbSpeaker = New System.Windows.Forms.PictureBox()
        Me.pbCaptcha = New System.Windows.Forms.PictureBox()
        Me.pbClock = New System.Windows.Forms.PictureBox()
        Me.ttCaptchaButtons = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCaptcha = New Go__YouTube_Snagger.GoTextBox()
        Me.txtMessage = New Go__YouTube_Snagger.GoTextBox()
        Me.txtName = New Go__YouTube_Snagger.GoTextBox()
        CType(Me.pbReload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSpeaker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCaptcha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lName
        '
        Me.lName.AutoSize = True
        Me.lName.Location = New System.Drawing.Point(12, 15)
        Me.lName.Name = "lName"
        Me.lName.Size = New System.Drawing.Size(49, 15)
        Me.lName.TabIndex = 0
        Me.lName.Text = "* Navn: "
        '
        'lError
        '
        Me.lError.AutoSize = True
        Me.lError.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lError.Location = New System.Drawing.Point(12, 42)
        Me.lError.Name = "lError"
        Me.lError.Size = New System.Drawing.Size(85, 15)
        Me.lError.TabIndex = 5
        Me.lError.Text = "* Feilmelding: "
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(268, 316)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Lukk"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSendError
        '
        Me.btnSendError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendError.Location = New System.Drawing.Point(120, 316)
        Me.btnSendError.Name = "btnSendError"
        Me.btnSendError.Size = New System.Drawing.Size(142, 23)
        Me.btnSendError.TabIndex = 7
        Me.btnSendError.Text = "&Send feilmeldig"
        Me.btnSendError.UseVisualStyleBackColor = True
        '
        'tCheck
        '
        Me.tCheck.Enabled = True
        Me.tCheck.Interval = 1
        '
        'clockTimer
        '
        Me.clockTimer.Interval = 50
        '
        'lSecurityControl
        '
        Me.lSecurityControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lSecurityControl.AutoSize = True
        Me.lSecurityControl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lSecurityControl.Location = New System.Drawing.Point(12, 194)
        Me.lSecurityControl.Name = "lSecurityControl"
        Me.lSecurityControl.Size = New System.Drawing.Size(122, 15)
        Me.lSecurityControl.TabIndex = 9
        Me.lSecurityControl.Text = "* Sikkerhets kontrol:"
        '
        'lMessageCount
        '
        Me.lMessageCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lMessageCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMessageCount.ForeColor = System.Drawing.Color.Maroon
        Me.lMessageCount.Location = New System.Drawing.Point(271, 48)
        Me.lMessageCount.Name = "lMessageCount"
        Me.lMessageCount.Size = New System.Drawing.Size(61, 15)
        Me.lMessageCount.TabIndex = 10
        Me.lMessageCount.Text = "0/50"
        Me.lMessageCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lCode
        '
        Me.lCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lCode.AutoSize = True
        Me.lCode.Location = New System.Drawing.Point(12, 291)
        Me.lCode.Name = "lCode"
        Me.lCode.Size = New System.Drawing.Size(84, 15)
        Me.lCode.TabIndex = 13
        Me.lCode.Text = "Skriv inn kode:"
        '
        'pbReload
        '
        Me.pbReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbReload.Image = CType(resources.GetObject("pbReload.Image"), System.Drawing.Image)
        Me.pbReload.Location = New System.Drawing.Point(316, 244)
        Me.pbReload.Name = "pbReload"
        Me.pbReload.Size = New System.Drawing.Size(16, 16)
        Me.pbReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbReload.TabIndex = 12
        Me.pbReload.TabStop = False
        '
        'pbSpeaker
        '
        Me.pbSpeaker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbSpeaker.Image = CType(resources.GetObject("pbSpeaker.Image"), System.Drawing.Image)
        Me.pbSpeaker.Location = New System.Drawing.Point(316, 266)
        Me.pbSpeaker.Name = "pbSpeaker"
        Me.pbSpeaker.Size = New System.Drawing.Size(16, 16)
        Me.pbSpeaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbSpeaker.TabIndex = 12
        Me.pbSpeaker.TabStop = False
        '
        'pbCaptcha
        '
        Me.pbCaptcha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCaptcha.Location = New System.Drawing.Point(15, 217)
        Me.pbCaptcha.Name = "pbCaptcha"
        Me.pbCaptcha.Size = New System.Drawing.Size(295, 65)
        Me.pbCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbCaptcha.TabIndex = 11
        Me.pbCaptcha.TabStop = False
        '
        'pbClock
        '
        Me.pbClock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbClock.Image = Global.Go__YouTube_Snagger.My.Resources.Resources.Clock_1
        Me.pbClock.Location = New System.Drawing.Point(15, 316)
        Me.pbClock.Name = "pbClock"
        Me.pbClock.Size = New System.Drawing.Size(16, 23)
        Me.pbClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbClock.TabIndex = 8
        Me.pbClock.TabStop = False
        Me.pbClock.Visible = False
        '
        'txtCaptcha
        '
        Me.txtCaptcha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCaptcha.AutoCompleteCustomSource = Nothing
        Me.txtCaptcha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtCaptcha.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtCaptcha.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCaptcha.ContextMenuStrip = Nothing
        Me.txtCaptcha.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtCaptcha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaptcha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCaptcha.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtCaptcha.Icon = Nothing
        Me.txtCaptcha.imgCustomButtonHover = Nothing
        Me.txtCaptcha.imgCustomButtonNormal = Nothing
        Me.txtCaptcha.imgCustomButtonPressed = Nothing
        Me.txtCaptcha.Location = New System.Drawing.Point(120, 288)
        Me.txtCaptcha.MaxLength = 10
        Me.txtCaptcha.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtCaptcha.Name = "txtCaptcha"
        Me.txtCaptcha.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtCaptcha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCaptcha.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtCaptcha.ShowIcon = False
        Me.txtCaptcha.Size = New System.Drawing.Size(212, 22)
        Me.txtCaptcha.TabIndex = 14
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.AutoCompleteCustomSource = Nothing
        Me.txtMessage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtMessage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtMessage.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMessage.ContextMenuStrip = Nothing
        Me.txtMessage.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMessage.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtMessage.Icon = Nothing
        Me.txtMessage.imgCustomButtonHover = Nothing
        Me.txtMessage.imgCustomButtonNormal = Nothing
        Me.txtMessage.imgCustomButtonPressed = Nothing
        Me.txtMessage.Location = New System.Drawing.Point(15, 66)
        Me.txtMessage.MaxLength = 32767
        Me.txtMessage.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtMessage.MultiLine = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtMessage.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessage.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtMessage.ShowIcon = False
        Me.txtMessage.ShowIsReadOnlyIcon = False
        Me.txtMessage.Size = New System.Drawing.Size(317, 120)
        Me.txtMessage.TabIndex = 4
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.AutoCompleteCustomSource = Nothing
        Me.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtName.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtName.ContextMenuStrip = Nothing
        Me.txtName.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtName.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtName.Icon = Nothing
        Me.txtName.imgCustomButtonHover = Nothing
        Me.txtName.imgCustomButtonNormal = Nothing
        Me.txtName.imgCustomButtonPressed = Nothing
        Me.txtName.Location = New System.Drawing.Point(76, 12)
        Me.txtName.MaxLength = 32767
        Me.txtName.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtName.Name = "txtName"
        Me.txtName.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtName.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtName.ShowIcon = False
        Me.txtName.Size = New System.Drawing.Size(256, 22)
        Me.txtName.TabIndex = 1
        '
        'frmReportBug
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(344, 351)
        Me.Controls.Add(Me.txtCaptcha)
        Me.Controls.Add(Me.lCode)
        Me.Controls.Add(Me.pbReload)
        Me.Controls.Add(Me.pbSpeaker)
        Me.Controls.Add(Me.pbCaptcha)
        Me.Controls.Add(Me.lMessageCount)
        Me.Controls.Add(Me.lSecurityControl)
        Me.Controls.Add(Me.pbClock)
        Me.Controls.Add(Me.btnSendError)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lError)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(360, 389)
        Me.Name = "frmReportBug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Raporter en feil..."
        CType(Me.pbReload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSpeaker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCaptcha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lName As System.Windows.Forms.Label
    Friend WithEvents txtName As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents txtMessage As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents lError As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSendError As System.Windows.Forms.Button
    Friend WithEvents pbClock As System.Windows.Forms.PictureBox
    Friend WithEvents tCheck As System.Windows.Forms.Timer
    Friend WithEvents clockTimer As System.Windows.Forms.Timer
    Friend WithEvents lSecurityControl As System.Windows.Forms.Label
    Friend WithEvents lMessageCount As System.Windows.Forms.Label
    Friend WithEvents pbCaptcha As System.Windows.Forms.PictureBox
    Friend WithEvents pbSpeaker As System.Windows.Forms.PictureBox
    Friend WithEvents pbReload As System.Windows.Forms.PictureBox
    Friend WithEvents lCode As System.Windows.Forms.Label
    Friend WithEvents txtCaptcha As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents ttCaptchaButtons As System.Windows.Forms.ToolTip
End Class
