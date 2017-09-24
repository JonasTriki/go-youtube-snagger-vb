Public Class frmVideoThumbnails

    'SomeCommands - Code
    Dim _default As String
    Dim saveTumbnailImageAs As String

    Dim info As YouTubeVideoThumbnailInfo
    Dim m_videoID As String

    Dim langFile As IniFile

    Public Sub New(ByVal videoID As String)
        InitializeComponent()
        m_videoID = videoID
    End Sub

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        _default = langFile.GetString("SomeCommands", "Default")
        saveTumbnailImageAs = langFile.GetString("SomeCommands", "SaveTumbnailImageAs")

        'frmVideoThumbnails = langFile.GetString("frmVideoThumbnails", "")
        Me.Text = langFile.GetString("frmVideoThumbnails", "Text")

        'frmVideoThumbnailsControls = langFile.GetString("frmVideoThumbnailsControls", "")
        btnClose.Text = langFile.GetString("frmVideoThumbnailsControls", "Close")
        btnSaveAs.Text = langFile.GetString("frmVideoThumbnailsControls", "SaveAs")

    End Sub

    Private Sub frmVideoThumbnails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckLang()
        btnSaveAs.Enabled = False
        bwLoad.RunWorkerAsync()
    End Sub

    Private Sub bwLoad_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwLoad.DoWork
        info = New YouTubeVideoThumbnailGetter().GetVideoThumbnailsFromVideoID(m_videoID)
        cbOptions.Items.Insert(0, _default)
        cbOptions.SelectedIndex = 1
    End Sub

    Private Sub bwLoad_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLoad.RunWorkerCompleted
        btnSaveAs.Enabled = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAs.Click

        Dim dlg As New SaveFileDialog

        dlg.Title = saveTumbnailImageAs
        dlg.Filter = Shell32.GetFileType(".png") & "|*.png|" & Shell32.GetFileType(".jpg") & "|*.jpg|" & Shell32.GetFileType(".gif") & "|*.gif|" & Shell32.GetFileType(".bmp") & "|*.bmp"
        dlg.FileName = ""

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            gibThumbnail.Image.Save(dlg.FileName)
        End If

    End Sub

    Private Sub cbOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOptions.SelectedIndexChanged
        Select Case cbOptions.SelectedIndex
            Case 0
                gibThumbnail.Image = info._Default
            Case 1
                gibThumbnail.Image = info._0
            Case 2
                gibThumbnail.Image = info._1
            Case 3
                gibThumbnail.Image = info._2
            Case 4
                gibThumbnail.Image = info._3
        End Select
    End Sub
End Class