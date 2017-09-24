<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatedVideos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelatedVideos))
        Me.pControls = New System.Windows.Forms.Panel()
        Me.btnDownloadVideo = New System.Windows.Forms.Button()
        Me.btnShowThumbnailImages = New System.Windows.Forms.Button()
        Me.btnCopyVideoURL = New System.Windows.Forms.Button()
        Me.btnCopyVideoID = New System.Windows.Forms.Button()
        Me.btnOpenVideoURL = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ilStatuses = New System.Windows.Forms.ImageList(Me.components)
        Me.bwLoad = New System.ComponentModel.BackgroundWorker()
        Me.tClock = New System.Windows.Forms.Timer(Me.components)
        Me.lvVideos = New Go__YouTube_Snagger.UnBuggyListView()
        Me.chTitle = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chIndex = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chUserName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chVideoID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chURL = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.lStatusValue = New System.Windows.Forms.Label()
        Me.pbClock = New System.Windows.Forms.PictureBox()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.pControls.SuspendLayout
        CType(Me.pbClock,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'pControls
        '
        Me.pControls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pControls.Controls.Add(Me.btnDownloadVideo)
        Me.pControls.Controls.Add(Me.btnShowThumbnailImages)
        Me.pControls.Controls.Add(Me.btnCopyVideoURL)
        Me.pControls.Controls.Add(Me.btnCopyVideoID)
        Me.pControls.Controls.Add(Me.btnOpenVideoURL)
        Me.pControls.Controls.Add(Me.btnClose)
        Me.pControls.Location = New System.Drawing.Point(472, 12)
        Me.pControls.Name = "pControls"
        Me.pControls.Size = New System.Drawing.Size(160, 351)
        Me.pControls.TabIndex = 1
        '
        'btnDownloadVideo
        '
        Me.btnDownloadVideo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnDownloadVideo.Enabled = false
        Me.btnDownloadVideo.Location = New System.Drawing.Point(2, 3)
        Me.btnDownloadVideo.Name = "btnDownloadVideo"
        Me.btnDownloadVideo.Size = New System.Drawing.Size(155, 23)
        Me.btnDownloadVideo.TabIndex = 5
        Me.btnDownloadVideo.Text = "Last ned..."
        Me.btnDownloadVideo.UseVisualStyleBackColor = true
        '
        'btnShowThumbnailImages
        '
        Me.btnShowThumbnailImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnShowThumbnailImages.Enabled = false
        Me.btnShowThumbnailImages.Location = New System.Drawing.Point(2, 61)
        Me.btnShowThumbnailImages.Name = "btnShowThumbnailImages"
        Me.btnShowThumbnailImages.Size = New System.Drawing.Size(155, 23)
        Me.btnShowThumbnailImages.TabIndex = 4
        Me.btnShowThumbnailImages.Text = "Vis miniatyr bilder..."
        Me.btnShowThumbnailImages.UseVisualStyleBackColor = true
        '
        'btnCopyVideoURL
        '
        Me.btnCopyVideoURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCopyVideoURL.Enabled = false
        Me.btnCopyVideoURL.Location = New System.Drawing.Point(2, 296)
        Me.btnCopyVideoURL.Name = "btnCopyVideoURL"
        Me.btnCopyVideoURL.Size = New System.Drawing.Size(155, 23)
        Me.btnCopyVideoURL.TabIndex = 3
        Me.btnCopyVideoURL.Text = "Kopier video link"
        Me.btnCopyVideoURL.UseVisualStyleBackColor = true
        '
        'btnCopyVideoID
        '
        Me.btnCopyVideoID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCopyVideoID.Enabled = false
        Me.btnCopyVideoID.Location = New System.Drawing.Point(2, 267)
        Me.btnCopyVideoID.Name = "btnCopyVideoID"
        Me.btnCopyVideoID.Size = New System.Drawing.Size(155, 23)
        Me.btnCopyVideoID.TabIndex = 2
        Me.btnCopyVideoID.Text = "Kopier video ID"
        Me.btnCopyVideoID.UseVisualStyleBackColor = true
        '
        'btnOpenVideoURL
        '
        Me.btnOpenVideoURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOpenVideoURL.Enabled = false
        Me.btnOpenVideoURL.Location = New System.Drawing.Point(2, 32)
        Me.btnOpenVideoURL.Name = "btnOpenVideoURL"
        Me.btnOpenVideoURL.Size = New System.Drawing.Size(155, 23)
        Me.btnOpenVideoURL.TabIndex = 1
        Me.btnOpenVideoURL.Text = "Åpne video link..."
        Me.btnOpenVideoURL.UseVisualStyleBackColor = true
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(2, 325)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(155, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Lukk"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'ilStatuses
        '
        Me.ilStatuses.ImageStream = CType(resources.GetObject("ilStatuses.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ilStatuses.TransparentColor = System.Drawing.Color.Transparent
        Me.ilStatuses.Images.SetKeyName(0, "AvailableForDownload.png")
        Me.ilStatuses.Images.SetKeyName(1, "Failed.png")
        '
        'bwLoad
        '
        '
        'tClock
        '
        Me.tClock.Interval = 50
        '
        'lvVideos
        '
        Me.lvVideos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lvVideos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chTitle, Me.chIndex, Me.chUserName, Me.chVideoID, Me.chURL})
        Me.lvVideos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.lvVideos.FullRowSelect = true
        Me.lvVideos.GridLines = true
        Me.lvVideos.HideSelection = false
        Me.lvVideos.Location = New System.Drawing.Point(12, 35)
        Me.lvVideos.MultiSelect = false
        Me.lvVideos.Name = "lvVideos"
        Me.lvVideos.Size = New System.Drawing.Size(456, 328)
        Me.lvVideos.SmallImageList = Me.ilStatuses
        Me.lvVideos.TabIndex = 0
        Me.lvVideos.UseCompatibleStateImageBehavior = false
        Me.lvVideos.View = System.Windows.Forms.View.Details
        '
        'chTitle
        '
        Me.chTitle.Text = "Tittel"
        Me.chTitle.Width = 169
        '
        'chIndex
        '
        Me.chIndex.Text = "#"
        Me.chIndex.Width = 30
        '
        'chUserName
        '
        Me.chUserName.Text = "Brukernavn"
        Me.chUserName.Width = 115
        '
        'chVideoID
        '
        Me.chVideoID.Text = "Video ID"
        Me.chVideoID.Width = 115
        '
        'chURL
        '
        Me.chURL.Text = "Video link"
        Me.chURL.Width = 308
        '
        'lStatusValue
        '
        Me.lStatusValue.AutoSize = true
        Me.lStatusValue.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lStatusValue.Location = New System.Drawing.Point(67, 12)
        Me.lStatusValue.Name = "lStatusValue"
        Me.lStatusValue.Size = New System.Drawing.Size(97, 15)
        Me.lStatusValue.TabIndex = 209
        Me.lStatusValue.Text = "Ingen resultater"
        '
        'pbClock
        '
        Me.pbClock.Image = Global.Go__YouTube_Snagger.My.Resources.Resources.downloaded_Normal
        Me.pbClock.Location = New System.Drawing.Point(12, 12)
        Me.pbClock.Name = "pbClock"
        Me.pbClock.Size = New System.Drawing.Size(16, 16)
        Me.pbClock.TabIndex = 208
        Me.pbClock.TabStop = false
        '
        'lStatus
        '
        Me.lStatus.AutoSize = true
        Me.lStatus.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lStatus.Location = New System.Drawing.Point(28, 12)
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(42, 15)
        Me.lStatus.TabIndex = 207
        Me.lStatus.Text = "Status:"
        '
        'frmRelatedVideos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(644, 372)
        Me.Controls.Add(Me.lStatusValue)
        Me.Controls.Add(Me.pbClock)
        Me.Controls.Add(Me.lStatus)
        Me.Controls.Add(Me.pControls)
        Me.Controls.Add(Me.lvVideos)
        Me.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmRelatedVideos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relaterte videoer..."
        Me.pControls.ResumeLayout(false)
        CType(Me.pbClock,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents lvVideos As UnBuggyListView
    Friend WithEvents pControls As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chVideoID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents chURL As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnShowThumbnailImages As System.Windows.Forms.Button
    Friend WithEvents btnCopyVideoURL As System.Windows.Forms.Button
    Friend WithEvents btnCopyVideoID As System.Windows.Forms.Button
    Friend WithEvents btnOpenVideoURL As System.Windows.Forms.Button
    Friend WithEvents btnDownloadVideo As System.Windows.Forms.Button
    Friend WithEvents chTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUserName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ilStatuses As System.Windows.Forms.ImageList
    Friend WithEvents bwLoad As System.ComponentModel.BackgroundWorker
    Friend WithEvents tClock As System.Windows.Forms.Timer
    Friend WithEvents lStatusValue As System.Windows.Forms.Label
    Friend WithEvents pbClock As System.Windows.Forms.PictureBox
    Friend WithEvents lStatus As System.Windows.Forms.Label
End Class
