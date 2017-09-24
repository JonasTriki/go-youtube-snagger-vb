<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVideoThumbnails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVideoThumbnails))
        Me.cbOptions = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSaveAs = New System.Windows.Forms.Button()
        Me.bwLoad = New System.ComponentModel.BackgroundWorker()
        Me.gibThumbnail = New Go__YouTube_Snagger.GoImageBox()
        Me.SuspendLayout()
        '
        'cbOptions
        '
        Me.cbOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOptions.FormattingEnabled = True
        Me.cbOptions.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cbOptions.Location = New System.Drawing.Point(391, 398)
        Me.cbOptions.Name = "cbOptions"
        Me.cbOptions.Size = New System.Drawing.Size(121, 23)
        Me.cbOptions.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(12, 398)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Lukk"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSaveAs
        '
        Me.btnSaveAs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAs.Location = New System.Drawing.Point(93, 398)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(131, 23)
        Me.btnSaveAs.TabIndex = 4
        Me.btnSaveAs.Text = "Lagre som..."
        Me.btnSaveAs.UseVisualStyleBackColor = True
        '
        'bwLoad
        '
        '
        'gibThumbnail
        '
        Me.gibThumbnail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gibThumbnail.BackColor = System.Drawing.Color.White
        Me.gibThumbnail.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.gibThumbnail.BorderSize = 1.0!
        Me.gibThumbnail.Image = Nothing
        Me.gibThumbnail.ImageStyle = Go__YouTube_Snagger.GoImageBox.ImageDrawingStyle.Center
        Me.gibThumbnail.Location = New System.Drawing.Point(12, 12)
        Me.gibThumbnail.Name = "gibThumbnail"
        Me.gibThumbnail.ShowBorder = True
        Me.gibThumbnail.Size = New System.Drawing.Size(500, 380)
        Me.gibThumbnail.TabIndex = 1
        '
        'frmVideoThumbnails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(524, 433)
        Me.Controls.Add(Me.btnSaveAs)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cbOptions)
        Me.Controls.Add(Me.gibThumbnail)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(540, 471)
        Me.Name = "frmVideoThumbnails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Video miniatyr bilder..."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gibThumbnail As Go__YouTube_Snagger.GoImageBox
    Friend WithEvents cbOptions As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSaveAs As System.Windows.Forms.Button
    Friend WithEvents bwLoad As System.ComponentModel.BackgroundWorker
End Class
