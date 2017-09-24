Imports Google.GData.Client
Imports Google.GData.Extensions
Imports Google.GData.YouTube
Imports Google.GData.Extensions.MediaRss
Imports Google.YouTube

Public Class frmRelatedVideos

    Dim clockIndex As Integer = 1

    'SomeCommands - Code
    Dim loading As String
    Dim loadingRelatedVideoInfos As String
    Dim loadedAllInformation As String
    Dim _close As String
    Dim _stop As String
    Dim anUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces As String
    Dim result As String
    Dim results As String
    Dim noResults As String
    Dim page As String
    Dim _of As String

    'InfoGetter - Code
    Dim youTubeVideoIsNotValid As String

    Dim relatedVideos As Feed(Of Video)
    Dim langFile As IniFile

    Dim curVideoQuery As YouTubeQuery
    Dim curVideoFeed As Feed(Of Video)
    Dim curVideo As Video
    Dim curRelatedVideosFeed As Feed(Of Video)
    Dim request As New YouTubeRequest(New YouTubeRequestSettings("Go! YouTube Snagger", "AI39si70mC4QX3pZDiET5sLg1K300ZOmzGiWGfsde_mHojCYVyWEbdpMLYhM6BCMLYLTkFKCYkolaJAqjNgY0lJgsaxSc2mu_w"))
    Dim m_frmDownloadProgress As frmDownloadProgress

    Public Sub New(ByVal v As Video, ByVal frmDownloadProgress As frmDownloadProgress)
        InitializeComponent()
        curVideo = v
        m_frmDownloadProgress = frmDownloadProgress
    End Sub

    Private Sub getRelatedVideos(ByVal v As Video)
        curVideoQuery = New YouTubeQuery("http://gdata.youtube.com/feeds/api/videos/" & v.VideoId)
        curRelatedVideosFeed = request.GetRelatedVideos(v)
        bwLoad.RunWorkerAsync()
    End Sub

    Private Sub loadRelatedVideosFeed(ByVal relatedVideosFeed As Feed(Of Video))
        For Each v As Video In relatedVideosFeed.Entries
            If cancelWorker Then Exit For
            lStatusValue.Text = loadingRelatedVideoInfos & " (" & Math.Round((lvVideos.Items.Count + 1) / relatedVideosFeed.Entries.Count * 100, 0) & "%)"
            Dim item As New ListViewItem
            item.Text = v.Title
            item.SubItems.Add(lvVideos.Items.Count + 1)
            item.SubItems.Add(v.Uploader)
            item.SubItems.Add(v.VideoId)
            item.SubItems.Add("http://youtube.com/watch?v=" & v.VideoId)
            item.ImageIndex = 0
            lvVideos.Items.Add(item)
            Application.DoEvents()
        Next
    End Sub

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        loading = langFile.GetString("SomeCommands", "Loading")
        loadingRelatedVideoInfos = langFile.GetString("SomeCommands", "LoadingRelatedVideoInfos")
        loadedAllInformation = langFile.GetString("SomeCommands", "LoadedAllInformation")
        _stop = langFile.GetString("SomeCommands", "Stop")
        anUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces = langFile.GetString("SomeCommands", "AnUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces")
        result = langFile.GetString("SomeCommands", "Result")
        results = langFile.GetString("SomeCommands", "Results")
        noResults = langFile.GetString("SomeCommands", "NoResults")
        page = langFile.GetString("SomeCommands", "Page")
        _of = langFile.GetString("SomeCommands", "Of")

        'InfoGetter = langFile.GetString("InfoGetter", "")
        youTubeVideoIsNotValid = langFile.GetString("InfoGetter", "YouTubeVideoIsNotValid")

        'frmRelatedVideos = langFile.GetString("frmRelatedVideos", "")
        Me.Text = langFile.GetString("frmRelatedVideos", "Text")

        'frmRelatedVideosControls = langFile.GetString("frmRelatedVideosControls", "")
        btnDownloadVideo.Text = langFile.GetString("frmRelatedVideosControls", "Download")
        btnOpenVideoURL.Text = langFile.GetString("frmRelatedVideosControls", "OpenVideoURL")
        btnShowThumbnailImages.Text = langFile.GetString("frmRelatedVideosControls", "ShowThumbnailImages")
        btnCopyVideoID.Text = langFile.GetString("frmRelatedVideosControls", "CopyVideoID")
        btnCopyVideoURL.Text = langFile.GetString("frmRelatedVideosControls", "CopyVideoURL")
        _close = langFile.GetString("frmRelatedVideosControls", "Close")
        btnClose.Text = _close
        chTitle.Text = langFile.GetString("frmRelatedVideosControls", "Title")
        chIndex.Text = langFile.GetString("frmRelatedVideosControls", "ID")
        chUserName.Text = langFile.GetString("frmRelatedVideosControls", "Username")
        chVideoID.Text = langFile.GetString("frmRelatedVideosControls", "VideoID")
        chURL.Text = langFile.GetString("frmRelatedVideosControls", "VideoURL")
        lStatus.Text = langFile.GetString("frmRelatedVideosControls", "Status")

    End Sub

    Private Sub frmRelatedVideos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        CheckLang()
        tClock.Start()
        lStatusValue.Text = loading
        getRelatedVideos(curVideo)
    End Sub

    Private Sub tClock_Tick(sender As System.Object, e As System.EventArgs) Handles tClock.Tick
        If clockIndex = 1 Then
            clockIndex = 2
            pbClock.Image = My.Resources.Clock_2
        ElseIf clockIndex = 2 Then
            clockIndex = 3
            pbClock.Image = My.Resources.Clock_3
        ElseIf clockIndex = 3 Then
            clockIndex = 4
            pbClock.Image = My.Resources.Clock_4
        ElseIf clockIndex = 4 Then
            clockIndex = 5
            pbClock.Image = My.Resources.Clock_5
        ElseIf clockIndex = 5 Then
            clockIndex = 6
            pbClock.Image = My.Resources.Clock_6
        ElseIf clockIndex = 6 Then
            clockIndex = 7
            pbClock.Image = My.Resources.Clock_7
        ElseIf clockIndex = 7 Then
            clockIndex = 8
            pbClock.Image = My.Resources.Clock_8
        ElseIf clockIndex = 8 Then
            clockIndex = 9
            pbClock.Image = My.Resources.Clock_8
        ElseIf clockIndex = 9 Then
            clockIndex = 10
            pbClock.Image = My.Resources.Clock_10
        ElseIf clockIndex = 10 Then
            clockIndex = 11
            pbClock.Image = My.Resources.Clock_11
        ElseIf clockIndex = 11 Then
            clockIndex = 12
            pbClock.Image = My.Resources.Clock_12
        ElseIf clockIndex = 12 Then
            clockIndex = 13
            pbClock.Image = My.Resources.Clock_13
        ElseIf clockIndex = 13 Then
            clockIndex = 14
            pbClock.Image = My.Resources.Clock_14
        ElseIf clockIndex = 14 Then
            clockIndex = 15
            pbClock.Image = My.Resources.Clock_15
        ElseIf clockIndex = 15 Then
            clockIndex = 16
            pbClock.Image = My.Resources.Clock_16
        ElseIf clockIndex = 16 Then
            clockIndex = 1
            pbClock.Image = My.Resources.Clock_1
        End If
    End Sub

    Dim cancelWorker As Boolean = False
    Private Sub bwLoad_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwLoad.DoWork
        btnClose.Text = _stop
        curVideoFeed = request.Get(Of Video)(curVideoQuery)
        curRelatedVideosFeed = request.GetRelatedVideos(curVideoFeed.Entries(0))
        loadRelatedVideosFeed(curRelatedVideosFeed)
        lStatusValue.Text = loadedAllInformation
    End Sub

    Private Sub bwLoad_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLoad.RunWorkerCompleted
        cancelWorker = False
        tClock.Stop()
        pbClock.Image = My.Resources.downloaded_Normal
        btnClose.Text = _close
    End Sub

    Private Sub lvVideos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvVideos.SelectedIndexChanged
        btnDownloadVideo.Enabled = lvVideos.SelectedItems.Count = 1
        btnOpenVideoURL.Enabled = lvVideos.SelectedItems.Count = 1
        btnShowThumbnailImages.Enabled = lvVideos.SelectedItems.Count = 1
        btnCopyVideoID.Enabled = lvVideos.SelectedItems.Count = 1
        btnCopyVideoURL.Enabled = lvVideos.SelectedItems.Count = 1
    End Sub

    Private Sub btnDownloadVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadVideo.Click
        Dim dlg As New frmChooseVideoQuality(True, lvVideos.SelectedItems(0).SubItems(4).Text, m_frmDownloadProgress.addedFileNames, m_frmDownloadProgress)
        dlg.ShowDialog()
    End Sub

    Private Sub btnOpenVideoURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenVideoURL.Click
        OpenURL.OpenURL(lvVideos.SelectedItems(0).SubItems(4).Text)
    End Sub

    Private Sub btnShowThumbnailImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowThumbnailImages.Click
        Dim dlg As New frmVideoThumbnails(lvVideos.SelectedItems(0).SubItems(3).Text)
        dlg.ShowDialog()
    End Sub

    Private Sub btnCopyVideoID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyVideoID.Click
        Try
            Clipboard.SetText(lvVideos.SelectedItems(0).Text)
        Catch ex As Exception
            MessageBox.ShowMessageBox(anUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
        End Try
    End Sub

    Private Sub btnCopyVideoURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyVideoURL.Click
        Try
            Clipboard.SetText(lvVideos.SelectedItems(0).SubItems(4).Text)
        Catch ex As Exception
            MessageBox.ShowMessageBox(anUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If btnClose.Text = _close Then
            Me.Close()
        ElseIf btnClose.Text = _stop Then
            cancelWorker = True
        End If
    End Sub
End Class