<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommentBoxItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.lWhen = New System.Windows.Forms.Label()
        Me.llUsername = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.BackColor = System.Drawing.Color.White
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtComment.Location = New System.Drawing.Point(0, 0)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ReadOnly = True
        Me.txtComment.Size = New System.Drawing.Size(181, 75)
        Me.txtComment.TabIndex = 8
        '
        'lWhen
        '
        Me.lWhen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lWhen.AutoSize = True
        Me.lWhen.ForeColor = System.Drawing.Color.Gray
        Me.lWhen.Location = New System.Drawing.Point(81, 81)
        Me.lWhen.Name = "lWhen"
        Me.lWhen.Size = New System.Drawing.Size(88, 15)
        Me.lWhen.TabIndex = 5
        Me.lWhen.Text = "~ 1 minute ago"
        '
        'llUsername
        '
        Me.llUsername.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.llUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llUsername.AutoSize = True
        Me.llUsername.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.llUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.llUsername.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.llUsername.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.llUsername.Location = New System.Drawing.Point(3, 81)
        Me.llUsername.Name = "llUsername"
        Me.llUsername.Size = New System.Drawing.Size(83, 15)
        Me.llUsername.TabIndex = 4
        Me.llUsername.TabStop = True
        Me.llUsername.Text = "GoVisualTeam"
        Me.llUsername.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'CommentBoxItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.lWhen)
        Me.Controls.Add(Me.llUsername)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Name = "CommentBoxItem"
        Me.Size = New System.Drawing.Size(181, 99)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents lWhen As System.Windows.Forms.Label
    Friend WithEvents llUsername As System.Windows.Forms.LinkLabel

End Class
