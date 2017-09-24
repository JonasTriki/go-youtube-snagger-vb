<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlayVideo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlayVideo))
        Me.swfVideo = New AxShockwaveFlashObjects.AxShockwaveFlash()
        Me.ssBottom = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslStatusValue = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslSpring = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tClock = New System.Windows.Forms.Timer(Me.components)
        CType(Me.swfVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'swfVideo
        '
        Me.swfVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.swfVideo.Enabled = True
        Me.swfVideo.Location = New System.Drawing.Point(0, 0)
        Me.swfVideo.Name = "swfVideo"
        Me.swfVideo.OcxState = CType(resources.GetObject("swfVideo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.swfVideo.Size = New System.Drawing.Size(640, 338)
        Me.swfVideo.TabIndex = 0
        '
        'ssBottom
        '
        Me.ssBottom.BackgroundImage = CType(resources.GetObject("ssBottom.BackgroundImage"), System.Drawing.Image)
        Me.ssBottom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.tsslStatusValue, Me.tsslSpring})
        Me.ssBottom.Location = New System.Drawing.Point(0, 338)
        Me.ssBottom.Name = "ssBottom"
        Me.ssBottom.Size = New System.Drawing.Size(640, 22)
        Me.ssBottom.TabIndex = 1
        Me.ssBottom.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(45, 17)
        Me.tsslStatus.Text = "Status: "
        '
        'tsslStatusValue
        '
        Me.tsslStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsslStatusValue.Image = Global.Go__YouTube_Snagger.My.Resources.Resources.Clock_1
        Me.tsslStatusValue.Name = "tsslStatusValue"
        Me.tsslStatusValue.Size = New System.Drawing.Size(86, 17)
        Me.tsslStatusValue.Text = "Laster inn..."
        '
        'tsslSpring
        '
        Me.tsslSpring.Name = "tsslSpring"
        Me.tsslSpring.Size = New System.Drawing.Size(494, 17)
        Me.tsslSpring.Spring = True
        '
        'tClock
        '
        Me.tClock.Interval = 50
        '
        'frmPlayVideo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(640, 360)
        Me.Controls.Add(Me.swfVideo)
        Me.Controls.Add(Me.ssBottom)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPlayVideo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spill av video..."
        CType(Me.swfVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBottom.ResumeLayout(False)
        Me.ssBottom.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents swfVideo As AxShockwaveFlashObjects.AxShockwaveFlash
    Friend WithEvents ssBottom As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslStatusValue As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tClock As System.Windows.Forms.Timer
    Friend WithEvents tsslSpring As System.Windows.Forms.ToolStripStatusLabel
End Class
