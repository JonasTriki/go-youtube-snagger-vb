<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChooseVideoQuality
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChooseVideoQuality))
        Me.cbQuality = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lStatusValue = New System.Windows.Forms.Label()
        Me.pbClock = New System.Windows.Forms.PictureBox()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.pSplit = New System.Windows.Forms.Panel()
        Me.tClock = New System.Windows.Forms.Timer(Me.components)
        Me.bwDownloadVideo = New System.ComponentModel.BackgroundWorker()
        CType(Me.pbClock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbQuality
        '
        Me.cbQuality.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQuality.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbQuality.FormattingEnabled = True
        Me.cbQuality.Items.AddRange(New Object() {"144p - 176x144", "240p - 400x240", "360p - 480x360", "360p - 640x360", "480p - 854x480", "480p - 854x480 - WebM(HTML5)", "720p - 1280x720", "720p - 1280x720 - WebM(HTML5)", "1080p - 1920x1080", "4096p - 4096x3072/4096x2304"})
        Me.cbQuality.Location = New System.Drawing.Point(12, 12)
        Me.cbQuality.Name = "cbQuality"
        Me.cbQuality.Size = New System.Drawing.Size(353, 23)
        Me.cbQuality.TabIndex = 8
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(452, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Avbryt"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(371, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lStatusValue
        '
        Me.lStatusValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatusValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lStatusValue.Location = New System.Drawing.Point(76, 49)
        Me.lStatusValue.Name = "lStatusValue"
        Me.lStatusValue.Size = New System.Drawing.Size(451, 15)
        Me.lStatusValue.TabIndex = 12
        Me.lStatusValue.Text = "Vennligst velg en video kvalitet..."
        '
        'pbClock
        '
        Me.pbClock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbClock.Image = Global.Go__YouTube_Snagger.My.Resources.Resources.youtube
        Me.pbClock.Location = New System.Drawing.Point(12, 49)
        Me.pbClock.Name = "pbClock"
        Me.pbClock.Size = New System.Drawing.Size(16, 16)
        Me.pbClock.TabIndex = 129
        Me.pbClock.TabStop = False
        '
        'lStatus
        '
        Me.lStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lStatus.AutoSize = True
        Me.lStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatus.Location = New System.Drawing.Point(28, 49)
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(42, 15)
        Me.lStatus.TabIndex = 128
        Me.lStatus.Text = "Status:"
        '
        'pSplit
        '
        Me.pSplit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pSplit.Location = New System.Drawing.Point(0, 41)
        Me.pSplit.Name = "pSplit"
        Me.pSplit.Size = New System.Drawing.Size(539, 1)
        Me.pSplit.TabIndex = 130
        '
        'tClock
        '
        Me.tClock.Interval = 50
        '
        'bwDownloadVideo
        '
        '
        'frmChooseVideoQuality
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(539, 73)
        Me.Controls.Add(Me.pSplit)
        Me.Controls.Add(Me.pbClock)
        Me.Controls.Add(Me.lStatus)
        Me.Controls.Add(Me.lStatusValue)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cbQuality)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChooseVideoQuality"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Velg video kvalitet..."
        CType(Me.pbClock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbQuality As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lStatusValue As System.Windows.Forms.Label
    Friend WithEvents pbClock As System.Windows.Forms.PictureBox
    Friend WithEvents lStatus As System.Windows.Forms.Label
    Friend WithEvents pSplit As System.Windows.Forms.Panel
    Friend WithEvents tClock As System.Windows.Forms.Timer
    Friend WithEvents bwDownloadVideo As System.ComponentModel.BackgroundWorker
End Class
