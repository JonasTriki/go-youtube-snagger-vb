<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectLanguage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectLanguage))
        Me.lChoose = New System.Windows.Forms.Label()
        Me.cbLanguages = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lChoose
        '
        Me.lChoose.AutoSize = True
        Me.lChoose.Location = New System.Drawing.Point(12, 9)
        Me.lChoose.Name = "lChoose"
        Me.lChoose.Size = New System.Drawing.Size(132, 15)
        Me.lChoose.TabIndex = 0
        Me.lChoose.Text = "Vennligst velg ett språk:"
        '
        'cbLanguages
        '
        Me.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLanguages.FormattingEnabled = True
        Me.cbLanguages.Location = New System.Drawing.Point(12, 33)
        Me.cbLanguages.Name = "cbLanguages"
        Me.cbLanguages.Size = New System.Drawing.Size(185, 23)
        Me.cbLanguages.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(203, 33)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmSelectLanguage
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(284, 68)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cbLanguages)
        Me.Controls.Add(Me.lChoose)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectLanguage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Velg språk..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lChoose As System.Windows.Forms.Label
    Friend WithEvents cbLanguages As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
