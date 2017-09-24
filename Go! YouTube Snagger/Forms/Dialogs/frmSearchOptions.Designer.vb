<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchOptions))
        Me.lResultType = New System.Windows.Forms.Label()
        Me.lOrderBy = New System.Windows.Forms.Label()
        Me.lUploadDate = New System.Windows.Forms.Label()
        Me.lCategories = New System.Windows.Forms.Label()
        Me.lDuration = New System.Windows.Forms.Label()
        Me.lFunctions = New System.Windows.Forms.Label()
        Me.cbResultType = New System.Windows.Forms.ComboBox()
        Me.cbSortBy = New System.Windows.Forms.ComboBox()
        Me.cbCategories = New System.Windows.Forms.ComboBox()
        Me.cbUploadDate = New System.Windows.Forms.ComboBox()
        Me.cbFunctions = New System.Windows.Forms.ComboBox()
        Me.cbDuration = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.llReset = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lResultType
        '
        Me.lResultType.AutoSize = True
        Me.lResultType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lResultType.Location = New System.Drawing.Point(12, 15)
        Me.lResultType.Name = "lResultType"
        Me.lResultType.Size = New System.Drawing.Size(75, 15)
        Me.lResultType.TabIndex = 0
        Me.lResultType.Text = "Resultattype:"
        '
        'lOrderBy
        '
        Me.lOrderBy.AutoSize = True
        Me.lOrderBy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lOrderBy.Location = New System.Drawing.Point(12, 44)
        Me.lOrderBy.Name = "lOrderBy"
        Me.lOrderBy.Size = New System.Drawing.Size(68, 15)
        Me.lOrderBy.TabIndex = 1
        Me.lOrderBy.Text = "Sorter etter:"
        '
        'lUploadDate
        '
        Me.lUploadDate.AutoSize = True
        Me.lUploadDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lUploadDate.Location = New System.Drawing.Point(12, 73)
        Me.lUploadDate.Name = "lUploadDate"
        Me.lUploadDate.Size = New System.Drawing.Size(97, 15)
        Me.lUploadDate.TabIndex = 2
        Me.lUploadDate.Text = "Opplastingsdato:"
        '
        'lCategories
        '
        Me.lCategories.AutoSize = True
        Me.lCategories.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCategories.Location = New System.Drawing.Point(12, 102)
        Me.lCategories.Name = "lCategories"
        Me.lCategories.Size = New System.Drawing.Size(64, 15)
        Me.lCategories.TabIndex = 2
        Me.lCategories.Text = "Kategorier:"
        '
        'lDuration
        '
        Me.lDuration.AutoSize = True
        Me.lDuration.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lDuration.Location = New System.Drawing.Point(12, 131)
        Me.lDuration.Name = "lDuration"
        Me.lDuration.Size = New System.Drawing.Size(54, 15)
        Me.lDuration.TabIndex = 3
        Me.lDuration.Text = "Varighet:"
        '
        'lFunctions
        '
        Me.lFunctions.AutoSize = True
        Me.lFunctions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lFunctions.Location = New System.Drawing.Point(12, 160)
        Me.lFunctions.Name = "lFunctions"
        Me.lFunctions.Size = New System.Drawing.Size(68, 15)
        Me.lFunctions.TabIndex = 3
        Me.lFunctions.Text = "Funksjoner:"
        '
        'cbResultType
        '
        Me.cbResultType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbResultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbResultType.FormattingEnabled = True
        Me.cbResultType.Location = New System.Drawing.Point(191, 12)
        Me.cbResultType.Name = "cbResultType"
        Me.cbResultType.Size = New System.Drawing.Size(156, 23)
        Me.cbResultType.TabIndex = 45
        '
        'cbSortBy
        '
        Me.cbSortBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSortBy.FormattingEnabled = True
        Me.cbSortBy.Location = New System.Drawing.Point(191, 41)
        Me.cbSortBy.Name = "cbSortBy"
        Me.cbSortBy.Size = New System.Drawing.Size(156, 23)
        Me.cbSortBy.TabIndex = 46
        '
        'cbCategories
        '
        Me.cbCategories.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategories.FormattingEnabled = True
        Me.cbCategories.Location = New System.Drawing.Point(191, 99)
        Me.cbCategories.Name = "cbCategories"
        Me.cbCategories.Size = New System.Drawing.Size(156, 23)
        Me.cbCategories.TabIndex = 48
        '
        'cbUploadDate
        '
        Me.cbUploadDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbUploadDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUploadDate.FormattingEnabled = True
        Me.cbUploadDate.Location = New System.Drawing.Point(191, 70)
        Me.cbUploadDate.Name = "cbUploadDate"
        Me.cbUploadDate.Size = New System.Drawing.Size(156, 23)
        Me.cbUploadDate.TabIndex = 47
        '
        'cbFunctions
        '
        Me.cbFunctions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFunctions.FormattingEnabled = True
        Me.cbFunctions.Location = New System.Drawing.Point(191, 157)
        Me.cbFunctions.Name = "cbFunctions"
        Me.cbFunctions.Size = New System.Drawing.Size(156, 23)
        Me.cbFunctions.TabIndex = 50
        '
        'cbDuration
        '
        Me.cbDuration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDuration.FormattingEnabled = True
        Me.cbDuration.Location = New System.Drawing.Point(191, 128)
        Me.cbDuration.Name = "cbDuration"
        Me.cbDuration.Size = New System.Drawing.Size(156, 23)
        Me.cbDuration.TabIndex = 49
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 186)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 1)
        Me.Panel1.TabIndex = 51
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(272, 193)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 52
        Me.btnCancel.Text = "&Avbryt"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(191, 193)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 53
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'llReset
        '
        Me.llReset.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.llReset.AutoSize = True
        Me.llReset.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.llReset.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.llReset.Location = New System.Drawing.Point(12, 197)
        Me.llReset.Name = "llReset"
        Me.llReset.Size = New System.Drawing.Size(125, 15)
        Me.llReset.TabIndex = 54
        Me.llReset.TabStop = True
        Me.llReset.Text = "Tilbakestill alternativer"
        '
        'frmSearchOptions
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(359, 228)
        Me.Controls.Add(Me.llReset)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbFunctions)
        Me.Controls.Add(Me.cbDuration)
        Me.Controls.Add(Me.cbCategories)
        Me.Controls.Add(Me.cbUploadDate)
        Me.Controls.Add(Me.cbSortBy)
        Me.Controls.Add(Me.cbResultType)
        Me.Controls.Add(Me.lFunctions)
        Me.Controls.Add(Me.lDuration)
        Me.Controls.Add(Me.lCategories)
        Me.Controls.Add(Me.lUploadDate)
        Me.Controls.Add(Me.lOrderBy)
        Me.Controls.Add(Me.lResultType)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Søkealternativer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lResultType As System.Windows.Forms.Label
    Friend WithEvents lOrderBy As System.Windows.Forms.Label
    Friend WithEvents lUploadDate As System.Windows.Forms.Label
    Friend WithEvents lCategories As System.Windows.Forms.Label
    Friend WithEvents lDuration As System.Windows.Forms.Label
    Friend WithEvents lFunctions As System.Windows.Forms.Label
    Friend WithEvents cbResultType As System.Windows.Forms.ComboBox
    Friend WithEvents cbSortBy As System.Windows.Forms.ComboBox
    Friend WithEvents cbCategories As System.Windows.Forms.ComboBox
    Friend WithEvents cbUploadDate As System.Windows.Forms.ComboBox
    Friend WithEvents cbFunctions As System.Windows.Forms.ComboBox
    Friend WithEvents cbDuration As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents llReset As System.Windows.Forms.LinkLabel
End Class
