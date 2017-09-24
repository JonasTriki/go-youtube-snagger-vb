<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendListTo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendListTo))
        Me.lName = New System.Windows.Forms.Label()
        Me.lFrom = New System.Windows.Forms.Label()
        Me.lTo = New System.Windows.Forms.Label()
        Me.lMessage = New System.Windows.Forms.Label()
        Me.pbClock = New System.Windows.Forms.PictureBox()
        Me.btnSendList = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtMessage = New Go__YouTube_Snagger.GoTextBox()
        Me.txtTo = New Go__YouTube_Snagger.GoTextBox()
        Me.txtFrom = New Go__YouTube_Snagger.GoTextBox()
        Me.txtName = New Go__YouTube_Snagger.GoTextBox()
        Me.clockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tCheck = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pbClock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lName
        '
        Me.lName.AutoSize = True
        Me.lName.Location = New System.Drawing.Point(12, 15)
        Me.lName.Name = "lName"
        Me.lName.Size = New System.Drawing.Size(49, 15)
        Me.lName.TabIndex = 2
        Me.lName.Text = "* Navn: "
        '
        'lFrom
        '
        Me.lFrom.AutoSize = True
        Me.lFrom.Location = New System.Drawing.Point(12, 43)
        Me.lFrom.Name = "lFrom"
        Me.lFrom.Size = New System.Drawing.Size(79, 15)
        Me.lFrom.TabIndex = 2
        Me.lFrom.Text = "* Fra (e-mail):"
        '
        'lTo
        '
        Me.lTo.AutoSize = True
        Me.lTo.Location = New System.Drawing.Point(12, 71)
        Me.lTo.Name = "lTo"
        Me.lTo.Size = New System.Drawing.Size(76, 15)
        Me.lTo.TabIndex = 2
        Me.lTo.Text = "* Til (e-mail):"
        '
        'lMessage
        '
        Me.lMessage.AutoSize = True
        Me.lMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMessage.Location = New System.Drawing.Point(12, 98)
        Me.lMessage.Name = "lMessage"
        Me.lMessage.Size = New System.Drawing.Size(112, 15)
        Me.lMessage.TabIndex = 7
        Me.lMessage.Text = "Melding (valgfritt):"
        '
        'pbClock
        '
        Me.pbClock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbClock.Image = Global.Go__YouTube_Snagger.My.Resources.Resources.Clock_1
        Me.pbClock.Location = New System.Drawing.Point(15, 327)
        Me.pbClock.Name = "pbClock"
        Me.pbClock.Size = New System.Drawing.Size(16, 23)
        Me.pbClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbClock.TabIndex = 11
        Me.pbClock.TabStop = False
        Me.pbClock.Visible = False
        '
        'btnSendList
        '
        Me.btnSendList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendList.Location = New System.Drawing.Point(136, 327)
        Me.btnSendList.Name = "btnSendList"
        Me.btnSendList.Size = New System.Drawing.Size(115, 23)
        Me.btnSendList.TabIndex = 10
        Me.btnSendList.Text = "&Send liste..."
        Me.btnSendList.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(257, 327)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "&Lukk"
        Me.btnClose.UseVisualStyleBackColor = True
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
        Me.txtMessage.Location = New System.Drawing.Point(15, 122)
        Me.txtMessage.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtMessage.MultiLine = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtMessage.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessage.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtMessage.ShowIcon = False
        Me.txtMessage.ShowIsReadOnlyIcon = False
        Me.txtMessage.Size = New System.Drawing.Size(317, 199)
        Me.txtMessage.TabIndex = 6
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTo.AutoCompleteCustomSource = Nothing
        Me.txtTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtTo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTo.ContextMenuStrip = Nothing
        Me.txtTo.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtTo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTo.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtTo.Icon = Nothing
        Me.txtTo.Location = New System.Drawing.Point(107, 68)
        Me.txtTo.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtTo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTo.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtTo.ShowIcon = False
        Me.txtTo.Size = New System.Drawing.Size(225, 22)
        Me.txtTo.TabIndex = 3
        '
        'txtFrom
        '
        Me.txtFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFrom.AutoCompleteCustomSource = Nothing
        Me.txtFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtFrom.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFrom.ContextMenuStrip = Nothing
        Me.txtFrom.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFrom.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtFrom.Icon = Nothing
        Me.txtFrom.Location = New System.Drawing.Point(107, 40)
        Me.txtFrom.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtFrom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFrom.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtFrom.ShowIcon = False
        Me.txtFrom.Size = New System.Drawing.Size(225, 22)
        Me.txtFrom.TabIndex = 3
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
        Me.txtName.Location = New System.Drawing.Point(76, 12)
        Me.txtName.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtName.Name = "txtName"
        Me.txtName.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtName.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtName.ShowIcon = False
        Me.txtName.Size = New System.Drawing.Size(256, 22)
        Me.txtName.TabIndex = 3
        '
        'clockTimer
        '
        Me.clockTimer.Interval = 50
        '
        'tCheck
        '
        Me.tCheck.Enabled = True
        Me.tCheck.Interval = 1
        '
        'frmSendListTo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(344, 362)
        Me.Controls.Add(Me.pbClock)
        Me.Controls.Add(Me.btnSendList)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lMessage)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.lTo)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.lFrom)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(360, 400)
        Me.Name = "frmSendListTo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Send liste til..."
        CType(Me.pbClock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtName As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents lName As System.Windows.Forms.Label
    Friend WithEvents lFrom As System.Windows.Forms.Label
    Friend WithEvents txtFrom As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents lTo As System.Windows.Forms.Label
    Friend WithEvents txtTo As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents lMessage As System.Windows.Forms.Label
    Friend WithEvents txtMessage As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents pbClock As System.Windows.Forms.PictureBox
    Friend WithEvents btnSendList As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents clockTimer As System.Windows.Forms.Timer
    Friend WithEvents tCheck As System.Windows.Forms.Timer
End Class
