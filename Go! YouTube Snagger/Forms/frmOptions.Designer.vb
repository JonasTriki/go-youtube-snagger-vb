<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.lSaveLocation = New System.Windows.Forms.Label()
        Me.cbAutoSave = New System.Windows.Forms.CheckBox()
        Me.pSplit = New System.Windows.Forms.Panel()
        Me.lLangPacks = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cbLang = New System.Windows.Forms.ComboBox()
        Me.pSplit1 = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.pSplit2 = New System.Windows.Forms.Panel()
        Me.btnCheckForUpdates = New System.Windows.Forms.Button()
        Me.lUpdate = New System.Windows.Forms.Label()
        Me.cbAutoUpdate = New System.Windows.Forms.CheckBox()
        Me.txtPath = New Go__YouTube_Snagger.GoTextBox()
        Me.ibRestart = New Go__YouTube_Snagger.InfoBar()
        Me.SuspendLayout()
        '
        'lSaveLocation
        '
        Me.lSaveLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lSaveLocation.AutoSize = True
        Me.lSaveLocation.Location = New System.Drawing.Point(12, 33)
        Me.lSaveLocation.Name = "lSaveLocation"
        Me.lSaveLocation.Size = New System.Drawing.Size(127, 15)
        Me.lSaveLocation.TabIndex = 5
        Me.lSaveLocation.Text = "Standard lagringssted: "
        '
        'cbAutoSave
        '
        Me.cbAutoSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAutoSave.Location = New System.Drawing.Point(15, 58)
        Me.cbAutoSave.Name = "cbAutoSave"
        Me.cbAutoSave.Size = New System.Drawing.Size(602, 19)
        Me.cbAutoSave.TabIndex = 7
        Me.cbAutoSave.Text = "Bruk autolagring når du laster ned videoer"
        Me.cbAutoSave.UseVisualStyleBackColor = True
        '
        'pSplit
        '
        Me.pSplit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit.Location = New System.Drawing.Point(0, 83)
        Me.pSplit.Name = "pSplit"
        Me.pSplit.Size = New System.Drawing.Size(629, 1)
        Me.pSplit.TabIndex = 8
        '
        'lLangPacks
        '
        Me.lLangPacks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lLangPacks.AutoSize = True
        Me.lLangPacks.Location = New System.Drawing.Point(12, 94)
        Me.lLangPacks.Name = "lLangPacks"
        Me.lLangPacks.Size = New System.Drawing.Size(77, 15)
        Me.lLangPacks.TabIndex = 9
        Me.lLangPacks.Text = "Språkpakker: "
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(433, 91)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(184, 23)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "&Legg til språkpakke"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cbLang
        '
        Me.cbLang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLang.FormattingEnabled = True
        Me.cbLang.Location = New System.Drawing.Point(159, 90)
        Me.cbLang.Name = "cbLang"
        Me.cbLang.Size = New System.Drawing.Size(268, 23)
        Me.cbLang.Sorted = True
        Me.cbLang.TabIndex = 13
        '
        'pSplit1
        '
        Me.pSplit1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit1.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit1.Location = New System.Drawing.Point(0, 120)
        Me.pSplit1.Name = "pSplit1"
        Me.pSplit1.Size = New System.Drawing.Size(629, 1)
        Me.pSplit1.TabIndex = 9
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(542, 167)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(461, 167)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "&Avbryt"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRestart
        '
        Me.btnRestart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRestart.Location = New System.Drawing.Point(12, 167)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(207, 23)
        Me.btnRestart.TabIndex = 18
        Me.btnRestart.Text = "&Restart Go! YouTube Snagger"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'btnChoose
        '
        Me.btnChoose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChoose.Location = New System.Drawing.Point(587, 30)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(30, 22)
        Me.btnChoose.TabIndex = 19
        Me.btnChoose.Text = "..."
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'pSplit2
        '
        Me.pSplit2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit2.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit2.Location = New System.Drawing.Point(0, 156)
        Me.pSplit2.Name = "pSplit2"
        Me.pSplit2.Size = New System.Drawing.Size(629, 1)
        Me.pSplit2.TabIndex = 16
        '
        'btnCheckForUpdates
        '
        Me.btnCheckForUpdates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCheckForUpdates.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckForUpdates.Location = New System.Drawing.Point(433, 127)
        Me.btnCheckForUpdates.Name = "btnCheckForUpdates"
        Me.btnCheckForUpdates.Size = New System.Drawing.Size(184, 23)
        Me.btnCheckForUpdates.TabIndex = 18
        Me.btnCheckForUpdates.Text = "&Se etter oppdateringer..."
        Me.btnCheckForUpdates.UseVisualStyleBackColor = True
        '
        'lUpdate
        '
        Me.lUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lUpdate.AutoSize = True
        Me.lUpdate.Location = New System.Drawing.Point(12, 131)
        Me.lUpdate.Name = "lUpdate"
        Me.lUpdate.Size = New System.Drawing.Size(80, 15)
        Me.lUpdate.TabIndex = 15
        Me.lUpdate.Text = "Oppdatering: "
        '
        'cbAutoUpdate
        '
        Me.cbAutoUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAutoUpdate.Location = New System.Drawing.Point(159, 130)
        Me.cbAutoUpdate.Name = "cbAutoUpdate"
        Me.cbAutoUpdate.Size = New System.Drawing.Size(268, 19)
        Me.cbAutoUpdate.TabIndex = 20
        Me.cbAutoUpdate.Text = "Se etter oppdateringer ved oppstart"
        Me.cbAutoUpdate.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.AutoCompleteCustomSource = Nothing
        Me.txtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtPath.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPath.ContextMenuStrip = Nothing
        Me.txtPath.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtPath.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPath.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtPath.Icon = Global.Go__YouTube_Snagger.My.Resources.Resources.folder
        Me.txtPath.IsReadOnly = True
        Me.txtPath.Location = New System.Drawing.Point(159, 30)
        Me.txtPath.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtPath.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPath.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtPath.Size = New System.Drawing.Size(422, 22)
        Me.txtPath.TabIndex = 6
        '
        'ibRestart
        '
        Me.ibRestart.BackColor = System.Drawing.Color.Transparent
        Me.ibRestart.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.ibRestart.BackgroundColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.ibRestart.BorderColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.ibRestart.CloseButtonContextMenuStrip = Nothing
        Me.ibRestart.Dock = System.Windows.Forms.DockStyle.Top
        Me.ibRestart.ExtraButtonCaption = "Télécharger..."
        Me.ibRestart.Icon = CType(resources.GetObject("ibRestart.Icon"), System.Drawing.Image)
        Me.ibRestart.Location = New System.Drawing.Point(0, 0)
        Me.ibRestart.Message = "Start Go! YouTube Snagger på nytt for at endringen skal tre i kraft..."
        Me.ibRestart.Name = "ibRestart"
        Me.ibRestart.ShowExtraButton = False
        Me.ibRestart.Size = New System.Drawing.Size(629, 22)
        Me.ibRestart.TabIndex = 0
        Me.ibRestart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ibRestart.Visible = False
        '
        'frmOptions
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(629, 202)
        Me.Controls.Add(Me.cbAutoUpdate)
        Me.Controls.Add(Me.pSplit2)
        Me.Controls.Add(Me.btnCheckForUpdates)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.btnRestart)
        Me.Controls.Add(Me.lUpdate)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.pSplit1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.cbLang)
        Me.Controls.Add(Me.lLangPacks)
        Me.Controls.Add(Me.pSplit)
        Me.Controls.Add(Me.cbAutoSave)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.lSaveLocation)
        Me.Controls.Add(Me.ibRestart)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Instillinger..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ibRestart As Go__YouTube_Snagger.InfoBar
    Friend WithEvents lSaveLocation As System.Windows.Forms.Label
    Friend WithEvents txtPath As Go__YouTube_Snagger.GoTextBox
    Friend WithEvents cbAutoSave As System.Windows.Forms.CheckBox
    Friend WithEvents pSplit As System.Windows.Forms.Panel
    Friend WithEvents lLangPacks As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cbLang As System.Windows.Forms.ComboBox
    Friend WithEvents pSplit1 As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRestart As System.Windows.Forms.Button
    Friend WithEvents btnChoose As System.Windows.Forms.Button
    Friend WithEvents pSplit2 As System.Windows.Forms.Panel
    Friend WithEvents btnCheckForUpdates As System.Windows.Forms.Button
    Friend WithEvents lUpdate As System.Windows.Forms.Label
    Friend WithEvents cbAutoUpdate As System.Windows.Forms.CheckBox
End Class
