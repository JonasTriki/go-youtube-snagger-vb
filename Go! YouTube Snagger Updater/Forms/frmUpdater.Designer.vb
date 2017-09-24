<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdater
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdater))
        Me.pSplit = New System.Windows.Forms.Panel()
        Me.lStatusValue = New System.Windows.Forms.Label()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.pSplit1 = New System.Windows.Forms.Panel()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.downloadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ilStatuses = New System.Windows.Forms.ImageList(Me.components)
        Me.btnWhatsNew = New System.Windows.Forms.Button()
        Me.bwUpdater = New System.ComponentModel.BackgroundWorker()
        Me.clockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.gpbProgress = New Go__YouTube_Snagger_Updater.GoProgressBar()
        Me.SuspendLayout()
        '
        'pSplit
        '
        Me.pSplit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit.Location = New System.Drawing.Point(0, 40)
        Me.pSplit.Name = "pSplit"
        Me.pSplit.Size = New System.Drawing.Size(544, 1)
        Me.pSplit.TabIndex = 1
        '
        'lStatusValue
        '
        Me.lStatusValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatusValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lStatusValue.Location = New System.Drawing.Point(60, 52)
        Me.lStatusValue.Name = "lStatusValue"
        Me.lStatusValue.Size = New System.Drawing.Size(472, 15)
        Me.lStatusValue.TabIndex = 11
        Me.lStatusValue.Text = "Ser etter nye oppdateringer..."
        '
        'lStatus
        '
        Me.lStatus.AutoSize = True
        Me.lStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lStatus.Location = New System.Drawing.Point(12, 52)
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(42, 15)
        Me.lStatus.TabIndex = 10
        Me.lStatus.Text = "Status:"
        '
        'pSplit1
        '
        Me.pSplit1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplit1.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplit1.Location = New System.Drawing.Point(0, 79)
        Me.pSplit1.Name = "pSplit1"
        Me.pSplit1.Size = New System.Drawing.Size(544, 1)
        Me.pSplit1.TabIndex = 12
        '
        'btnDownload
        '
        Me.btnDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDownload.Enabled = False
        Me.btnDownload.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownload.Location = New System.Drawing.Point(351, 86)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(100, 23)
        Me.btnDownload.TabIndex = 13
        Me.btnDownload.Text = "Last ned..."
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(457, 86)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Avbryt"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'downloadTimer
        '
        Me.downloadTimer.Interval = 1000
        '
        'ilStatuses
        '
        Me.ilStatuses.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilStatuses.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilStatuses.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnWhatsNew
        '
        Me.btnWhatsNew.Enabled = False
        Me.btnWhatsNew.Location = New System.Drawing.Point(12, 86)
        Me.btnWhatsNew.Name = "btnWhatsNew"
        Me.btnWhatsNew.Size = New System.Drawing.Size(111, 23)
        Me.btnWhatsNew.TabIndex = 15
        Me.btnWhatsNew.Text = "Hva er nytt?"
        Me.btnWhatsNew.UseVisualStyleBackColor = True
        '
        'bwUpdater
        '
        '
        'clockTimer
        '
        Me.clockTimer.Interval = 50
        '
        'gpbProgress
        '
        Me.gpbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbProgress.BackgroundColor = System.Drawing.Color.White
        Me.gpbProgress.BlockColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.gpbProgress.BorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.gpbProgress.ExtraText = ""
        Me.gpbProgress.Icon = Global.Go__YouTube_Snagger_Updater.My.Resources.Resources.paused_Normal
        Me.gpbProgress.Location = New System.Drawing.Point(12, 12)
        Me.gpbProgress.MaxValue = 100.0R
        Me.gpbProgress.MinValue = 0.0R
        Me.gpbProgress.Name = "gpbProgress"
        Me.gpbProgress.ShowIcon = True
        Me.gpbProgress.Size = New System.Drawing.Size(520, 22)
        Me.gpbProgress.TabIndex = 0
        Me.gpbProgress.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.gpbProgress.TextFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbProgress.Value = 0.0R
        '
        'frmUpdater
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(544, 121)
        Me.Controls.Add(Me.btnWhatsNew)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.pSplit1)
        Me.Controls.Add(Me.lStatusValue)
        Me.Controls.Add(Me.lStatus)
        Me.Controls.Add(Me.pSplit)
        Me.Controls.Add(Me.gpbProgress)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdater"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Oppdaterer..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpbProgress As Go__YouTube_Snagger_Updater.GoProgressBar
    Friend WithEvents pSplit As System.Windows.Forms.Panel
    Friend WithEvents lStatusValue As System.Windows.Forms.Label
    Friend WithEvents lStatus As System.Windows.Forms.Label
    Friend WithEvents pSplit1 As System.Windows.Forms.Panel
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents downloadTimer As System.Windows.Forms.Timer
    Friend WithEvents ilStatuses As System.Windows.Forms.ImageList
    Friend WithEvents btnWhatsNew As System.Windows.Forms.Button
    Friend WithEvents bwUpdater As System.ComponentModel.BackgroundWorker
    Friend WithEvents clockTimer As System.Windows.Forms.Timer

End Class
