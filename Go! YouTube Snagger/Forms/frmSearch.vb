Imports Google.GData.Client
Imports Google.GData.Extensions
Imports Google.GData.YouTube
Imports Google.GData.Extensions.MediaRss
Imports Google.YouTube

Public Class frmSearch

    Dim lvMouseDown As Boolean = False

    Dim clockIndex As Integer = 1
    Dim pageIndex As Double = 0
    Dim pages As Double = 0

    Dim pageIndexComment As Double = 0
    Dim pagesComment As Double = 0

    'SomeCommands - Code
    Dim noViews As String
    Dim noRatings As String
    Dim result As String
    Dim results As String
    Dim noResults As String
    Dim page As String
    Dim _of As String
    Dim ready As String
    Dim searchingFor As String
    Dim comment As String
    Dim comments As String
    Dim noComments As String
    Dim loadingPage As String

    Dim timerGoToEnable As Boolean = True
    Dim timerSearchEnable As Boolean = True
    Dim timerNextEnable As Boolean = True
    Dim timerPrevEnable As Boolean = True

    Dim timerGoToEnableComment As Boolean = True
    Dim timerSearchEnableComment As Boolean = True
    Dim timerNextEnableComment As Boolean = True
    Dim timerPrevEnableComment As Boolean = True

    Dim selectedVideo As Video
    Dim curVideoQuery As YouTubeQuery
    Dim curVideoFeed As Feed(Of Video)
    Dim curCommentQuery As YouTubeQuery
    Dim curCommentFeed As Feed(Of Comment)
    Dim curPlaylistFeed As Feed(Of Playlist)
    Dim request As New YouTubeRequest(New YouTubeRequestSettings("Go! YouTube Snagger", "AI39si70mC4QX3pZDiET5sLg1K300ZOmzGiWGfsde_mHojCYVyWEbdpMLYhM6BCMLYLTkFKCYkolaJAqjNgY0lJgsaxSc2mu_w"))

    Dim langFile As IniFile

    Private Sub searchKeyword(ByVal keyword As String)
        Dim curURL As String = YouTubeQuery.DefaultVideoUri & "?q=" & keyword
        Select Case My.Settings.resultType
            Case 1
                curURL &= "&search_type=search_users"
            Case 2
                curURL &= "&search_type=search_playlists"
            Case 3
                curURL &= "&search_type=videos"
        End Select
        Select Case My.Settings.sortBy
            Case 0
                curURL &= "&orderby=relevance"
           Case 1
                curURL &= "&orderby=published"
            Case 2
                curURL &= "&orderby=viewCount"
             Case 3
                curURL &= "&orderby=rating"
        End Select
        Select Case My.Settings.uploadDate
            Case 1
                curURL &= "&uploaded=d"
            Case 2
                curURL &= "&uploaded=w"
            Case 3
                curURL &= "&uploaded=h"
        End Select
        Select Case My.Settings.categories
            Case 1
                curURL &= "&search_category=2"
            Case 2
                curURL &= "&search_category=1"
            Case 3
                curURL &= "&search_category=29"
            Case 4
                curURL &= "&search_category=26"
            Case 5
                curURL &= "&search_category=15"
            Case 6
                curURL &= "&search_category=23"
            Case 7
                curURL &= "&search_category=22"
            Case 8
                curURL &= "&search_category=_News"
            Case 9
                curURL &= "&search_category=19"
            Case 10
                curURL &= "&search_category=20"
            Case 11
                curURL &= "&search_category=_Sports"
            Case 12
                curURL &= "&search_category=24"
            Case 13
                curURL &= "&search_category=_Education"
            Case 14
                curURL &= "&search_category=28"
        End Select
        Select Case My.Settings.duration
            Case 1
                curURL &= "&search_duration=short"
            Case 2
                curURL &= "&search_duration=long"
        End Select
        Select Case My.Settings.functions
            Case 1
                curURL &= "&closed_captions=1"
            Case 2
                curURL &= "&high_definition=1"
            Case 3
                curURL &= "&partner=1"
            Case 4
                curURL &= "&rental=1"
            Case 5
                curURL &= "&webm=1"
        End Select
        curVideoQuery = New YouTubeQuery(curURL)
        bwVideoFeed.RunWorkerAsync()
    End Sub

    Private Sub searchUsername(ByVal username As String)
        Dim curURL As String = "http://gdata.youtube.com/feeds/api/users/" & username
        Select Case cbUsername.SelectedIndex
            Case 0
                curURL &= "/uploads"
                curVideoQuery = New YouTubeQuery(curURL)
                bwVideoFeed.RunWorkerAsync()
            Case 1
                curURL &= "/favorites"
                curVideoQuery = New YouTubeQuery(curURL)
                bwVideoFeed.RunWorkerAsync()
            Case 2
                Me.username = username
                bwPlaylists.RunWorkerAsync()
        End Select
    End Sub

    Private Sub loadPlaylist(ByVal p As Playlist)
        Dim tempID As String() = Split(p.Id, ":")
        Dim feedURL As String = "http://gdata.youtube.com/feeds/api/playlists/" & tempID(tempID.GetUpperBound(0)) & "?v=2"
        curVideoQuery = New YouTubeQuery(feedURL)
        curVideoFeed = request.Get(Of Video)(curVideoQuery)
        loadVideoFeed(curVideoFeed)
    End Sub

    Private Sub loadComment(ByVal v As Video)
        cbComments.Items.Clear()
        curCommentQuery = New YouTubeQuery("http://gdata.youtube.com/feeds/api/videos/" & v.VideoId & "/comments")
        bwComment.RunWorkerAsync()
    End Sub

    Private Sub loadVideoFeed(ByVal feed As Feed(Of Video))
        For Each v As Video In feed.Entries
            Dim item As New ListViewItem(lvVideos.Items.Count + 1)
            item.SubItems.Add(v.Title)
            item.SubItems.Add(If(v.ViewCount = -1, noViews, FormatNumber(v.ViewCount, 0, TriState.False, TriState.False, TriState.True).Replace(".", " ").Replace(",", " ")))
            item.SubItems.Add(v.Uploader)
            item.SubItems.Add(If(v.RatingAverage = -1, noRatings, v.RatingAverage))
            item.Tag = v
            lvVideos.Items.Add(item)
        Next
    End Sub

    Dim commentFeedEntries As IEnumerable(Of Comment)
    Private Sub loadCommentFeed(ByVal feed As Feed(Of Comment))
        commentFeedEntries = feed.Entries
    End Sub

    Public Function dateToSecondDifference(ByVal d As Date) As Double
        Return Math.Round((DateTime.UtcNow - d.ToUniversalTime).TotalSeconds, 0)
    End Function

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        noViews = langFile.GetString("SomeCommands", "NoViews")
        noRatings = langFile.GetString("SomeCommands", "NoRatings")
        result = langFile.GetString("SomeCommands", "Result")
        results = langFile.GetString("SomeCommands", "Results")
        noResults = langFile.GetString("SomeCommands", "NoResults")
        page = langFile.GetString("SomeCommands", "Page")
        _of = langFile.GetString("SomeCommands", "Of")
        ready = langFile.GetString("SomeCommands", "Ready")
        searchingFor = langFile.GetString("SomeCommands", "SearchingFor")
        comment = langFile.GetString("SomeCommands", "Comment")
        comments = langFile.GetString("SomeCommands", "Comments")
        noComments = langFile.GetString("SomeCommands", "NoComments")
        loadingPage = langFile.GetString("SomeCommands", "LoadingPage")

        'frmSearch = langFile.GetString("frmSearch", "")
        Me.Text = langFile.GetString("frmSearch", "Text")

        'frmSearchControls = langFile.GetString("frmSearchControls", "")
        rbSearchKeyword.Text = langFile.GetString("frmSearchControls", "SearchKeyword")
        btnSearchOptions.Text = langFile.GetString("frmSearchControls", "SearchOptions")
        rbUsername.Text = langFile.GetString("frmSearchControls", "SearchUsername")
        cbUsername.Items.Add(langFile.GetString("frmSearchControls", "UploadedVideos"))
        cbUsername.Items.Add(langFile.GetString("frmSearchControls", "Favorites"))
        cbUsername.Items.Add(langFile.GetString("frmSearchControls", "Playlists"))
        lStatus.Text = langFile.GetString("frmSearchControls", "Status")
        lStatusValue.Text = noResults
        btnSearch.Text = langFile.GetString("frmSearchControls", "Search")
        chIndex.Text = langFile.GetString("frmSearchControls", "ID")
        chTitle.Text = langFile.GetString("frmSearchControls", "Title")
        chViews.Text = langFile.GetString("frmSearchControls", "ViewCount")
        chUsername.Text = langFile.GetString("frmSearchControls", "Username")
        chRating.Text = langFile.GetString("frmSearchControls", "Rating")
        lPageResults.Text = page & " 0 " & _of & " 0 "
        btnGoToPageResults.Text = langFile.GetString("frmSearchControls", "Goto")
        btnPrevPageResults.Text = langFile.GetString("frmSearchControls", "PrevPage")
        btnNextPageResults.Text = langFile.GetString("frmSearchControls", "NextPage")
        lComments.Text = noComments
        lPageComments.Text = page & " 0 " & _of & " 0 "
        btnGotoComments.Text = langFile.GetString("frmSearchControls", "Goto")
        btnPrevPageComments.Text = "<"
        btnNextPageComments.Text = ">"
        btnAdd.Text = langFile.GetString("frmSearchControls", "AddVideosToList")
        btnCancel.Text = langFile.GetString("frmSearchControls", "Cancel")

    End Sub

    Private Sub frmSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CheckLang()
        cbUsername.SelectedIndex = 0
    End Sub

    Private Sub tCheckButtons_Tick(sender As System.Object, e As System.EventArgs) Handles tCheckButtons.Tick
        btnGoToPageResults.Enabled = pages > 1 And timerGoToEnable And Not pageIndex = nudPageResults.Value - 1
        btnPrevPageResults.Enabled = pageIndex + 1 > 1 And timerPrevEnable
        btnNextPageResults.Enabled = IIf(pages >= 39, pageIndex + 1 < 39, pageIndex + 1 < pages) And timerNextEnable
        btnSearch.Enabled = If(rbSearchKeyword.Checked, txtKeyword.Text.Length > 0, If(rbUsername.Checked, txtUsername.Text.Length > 0, False)) And timerSearchEnable
        btnGotoComments.Enabled = pagesComment > 1 And timerGoToEnableComment And Not pageIndexComment = nudPageComments.Value - 1
        btnPrevPageComments.Enabled = pageIndexComment + 1 > 1 And timerPrevEnableComment
        btnNextPageComments.Enabled = IIf(pagesComment >= 39, pageIndexComment + 1 < 39, pageIndexComment + 1 < pagesComment) And timerNextEnableComment
        btnAdd.Enabled = lvVideos.SelectedItems.Count > 0
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

    Private Sub bwVideoFeed_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwVideoFeed.DoWork
        curVideoFeed = request.Get(Of Video)(curVideoQuery)
        loadVideoFeed(curVideoFeed)
        lStatusValue.Text = If(curVideoFeed.TotalResults > 0, FormatNumber(curVideoFeed.TotalResults, 0, TriState.False, TriState.False, TriState.True).Replace(".", " ").Replace(",", " ") & " " & If(curVideoFeed.TotalResults = 1, result, results), noResults)
        pages = If(Math.Round(curVideoFeed.TotalResults / 25, 0) = 0, 1, Math.Round(curVideoFeed.TotalResults / 25, 0))
        nudPageResults.Maximum = If(pages > 39, 39, pages)
        lPageResults.Text = page & " " & pageIndex + 1 & " " & _of & " " & pages
    End Sub

    Private Sub bwVideoFeed_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwVideoFeed.RunWorkerCompleted
        timerGoToEnable = True
        timerPrevEnable = True
        timerNextEnable = True
        timerSearchEnable = True
        tClock.Stop()
        pbClock.Image = My.Resources.downloaded_Normal
        lStatusValue.Text = ready
    End Sub

    Private Sub bwComment_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwComment.DoWork
        curCommentFeed = request.Get(Of Comment)(curCommentQuery)
        loadCommentFeed(curCommentFeed)
        pagesComment = If(Math.Round(selectedVideo.CommmentCount / 25, 0) = 0, 1, Math.Round(selectedVideo.CommmentCount / 25, 0))
        nudPageComments.Maximum = If(pagesComment > 39, 39, pagesComment)
        lPageComments.Text = page & " " & pageIndexComment + 1 & " " & _of & " " & pagesComment
    End Sub

    Private Sub bwComment_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwComment.RunWorkerCompleted
        For Each c As Comment In commentFeedEntries
            cbComments.Items.Add(c.Content, c.Author, dateToSecondDifference(c.CommentEntry.Published))
            Application.DoEvents()
        Next
        lvVideos.Enabled = True
        timerGoToEnableComment = True
        timerPrevEnableComment = True
        timerNextEnableComment = True
        tClock.Stop()
        pbClock.Image = My.Resources.downloaded_Normal
        lStatusValue.Text = ready
        lvVideos.Focus()
    End Sub

    Dim username As String
    Private Sub bwPlaylists_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwPlaylists.DoWork
        curPlaylistFeed = request.GetPlaylistsFeed(username)
        For Each p As Playlist In curPlaylistFeed.Entries
            loadPlaylist(p)
        Next
    End Sub

    Private Sub bwPlaylists_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwPlaylists.RunWorkerCompleted
        Try
            If Not IsNothing(curVideoFeed) Then
                lStatusValue.Text = If(curVideoFeed.TotalResults > 0, FormatNumber(curVideoFeed.TotalResults, 0, TriState.False, TriState.False, TriState.True).Replace(".", " ").Replace(",", " ") & " " & If(curVideoFeed.TotalResults = 1, result, results), noResults)
                pages = If(Math.Round(curVideoFeed.TotalResults / 25, 0) = 0, 1, Math.Round(curVideoFeed.TotalResults / 25, 0))
                nudPageResults.Maximum = If(pages > 39, 39, pages)
                lPageResults.Text = page & " " & pageIndex + 1 & " " & _of & " " & pages
            Else
                lStatusValue.Text = noResults
                pages = 1
                nudPageResults.Maximum = If(pages > 39, 39, pages)
                lPageResults.Text = page & " " & pageIndex + 1 & " " & _of & " " & pages
            End If
        Catch ex As Exception
            lStatusValue.Text = noResults
            pages = 1
            nudPageResults.Maximum = If(pages > 39, 39, pages)
            lPageResults.Text = page & " " & pageIndex + 1 & " " & _of & " " & pages
        End Try
        timerGoToEnable = True
        timerPrevEnable = True
        timerNextEnable = True
        timerSearchEnable = True
        tClock.Stop()
        pbClock.Image = My.Resources.downloaded_Normal
        lStatusValue.Text = ready
    End Sub

    Private Sub rb_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbSearchKeyword.CheckedChanged, rbUsername.CheckedChanged
        txtKeyword.Enabled = rbSearchKeyword.Checked
        btnSearchOptions.Enabled = rbSearchKeyword.Checked
        txtUsername.Enabled = rbUsername.Checked
        cbUsername.Enabled = rbUsername.Checked
    End Sub

    Private Sub btnSearchOptions_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchOptions.Click
        Dim dlg As New frmSearchOptions
        dlg.ShowDialog()
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        timerSearchEnable = False
        timerGoToEnable = False
        timerPrevEnable = False
        timerNextEnable = False
        lvVideos.Items.Clear()
        tClock.Start()
        If rbSearchKeyword.Checked Then
            lStatusValue.Text = searchingFor & " '" & txtKeyword.Text & "'..."
            searchKeyword(txtKeyword.Text)
        ElseIf rbUsername.Checked Then
            lStatusValue.Text = searchingFor & " '" & txtUsername.Text & "'..."
            searchUsername(txtUsername.Text)
        End If
    End Sub

    Private Sub lvVideos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvVideos.SelectedIndexChanged
        If Not lvMouseDown Then
            If lvVideos.SelectedIndices.Count = 1 Then
                If lvVideos.SelectedIndices(0) <> -1 Then
                    selectedVideo = lvVideos.SelectedItems(0).Tag
                    txtDescription.Enabled = True
                    txtDescription.Text = selectedVideo.Description
                    lComments.Text = If(selectedVideo.CommmentCount > 0, selectedVideo.CommmentCount & " " & If(selectedVideo.CommmentCount = 1, comment, comments), noComments)
                    cbComments.Enabled = True
                    lvVideos.Enabled = False
                    loadComment(selectedVideo)
                Else
                    selectedVideo = Nothing
                    txtDescription.Enabled = False
                    txtDescription.Text = ""
                    lComments.Text = noComments
                    cbComments.Enabled = False
                    cbComments.Items.Clear()
                End If
            Else
                selectedVideo = Nothing
                txtDescription.Enabled = False
                txtDescription.Text = ""
                lComments.Text = noComments
                cbComments.Enabled = False
                cbComments.Items.Clear()
            End If
        Else
            selectedVideo = Nothing
            txtDescription.Enabled = False
            txtDescription.Text = ""
            lComments.Text = noComments
            cbComments.Enabled = False
            cbComments.Items.Clear()
        End If
    End Sub

    Private Sub lvVideos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvVideos.MouseDown
        lvMouseDown = True
    End Sub

    Private Sub lvVideos_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvVideos.MouseUp
        lvMouseDown = False
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If lvVideos.SelectedIndices.Count = 1 Then
                If lvVideos.SelectedIndices(0) <> -1 Then
                    selectedVideo = lvVideos.SelectedItems(0).Tag
                    txtDescription.Enabled = True
                    txtDescription.Text = selectedVideo.Description
                    lComments.Text = If(selectedVideo.CommmentCount > 0, selectedVideo.CommmentCount & " " & If(selectedVideo.CommmentCount = 1, comment, comments), noComments)
                    cbComments.Enabled = True
                    lvVideos.Enabled = False 
                    loadComment(selectedVideo)
                Else
                    selectedVideo = Nothing
                    txtDescription.Enabled = False
                    txtDescription.Text = ""
                    lComments.Text = noComments
                    cbComments.Enabled = False
                    cbComments.Items.Clear()
                End If
            Else
                selectedVideo = Nothing
                txtDescription.Enabled = False
                txtDescription.Text = ""
                lComments.Text = noComments
                cbComments.Enabled = False
                cbComments.Items.Clear()
            End If
        End If
    End Sub

    Private Sub btnGoToPageResults_Click(sender As System.Object, e As System.EventArgs) Handles btnGoToPageResults.Click
        selectedVideo = Nothing
        txtDescription.Enabled = False
        txtDescription.Text = ""
        lComments.Text = noComments
        cbComments.Enabled = False
        cbComments.Items.Clear()
        timerSearchEnable = False
        timerGoToEnable = False
        timerPrevEnable = False
        timerNextEnable = False
        lvVideos.Items.Clear()
        pageIndex = nudPageResults.Value - 1
        curVideoQuery.StartIndex = pageIndex * 25
        tClock.Start()
        lStatusValue.Text = loadingPage & " " & pageIndex + 1 & " " & _of & " " & pages
        bwVideoFeed.RunWorkerAsync()
    End Sub

    Private Sub btnPrevPageResults_Click(sender As System.Object, e As System.EventArgs) Handles btnPrevPageResults.Click
        selectedVideo = Nothing
        txtDescription.Enabled = False
        txtDescription.Text = ""
        lComments.Text = noComments
        cbComments.Enabled = False
        cbComments.Items.Clear()
        timerSearchEnable = False
        timerGoToEnable = False
        timerPrevEnable = False
        timerNextEnable = False
        lvVideos.Items.Clear()
        pageIndex -= 1
        nudPageResults.Value = pageIndex + 1
        curVideoQuery.StartIndex = pageIndex * 25
        tClock.Start()
        lStatusValue.Text = loadingPage & " " & pageIndex + 1 & " " & _of & " " & pages
        bwVideoFeed.RunWorkerAsync()
    End Sub

    Private Sub btnNextPageResults_Click(sender As System.Object, e As System.EventArgs) Handles btnNextPageResults.Click
        selectedVideo = Nothing
        txtDescription.Enabled = False
        txtDescription.Text = ""
        lComments.Text = noComments
        cbComments.Enabled = False
        cbComments.Items.Clear()
        timerSearchEnable = False
        timerGoToEnable = False
        timerPrevEnable = False
        timerNextEnable = False
        lvVideos.Items.Clear()
        pageIndex += 1
        nudPageResults.Value = pageIndex + 1
        curVideoQuery.StartIndex = pageIndex * 25
        tClock.Start()
        lStatusValue.Text = loadingPage & " " & pageIndex + 1 & " " & _of & " " & pages
        bwVideoFeed.RunWorkerAsync()
    End Sub

    Private Sub btnGotoComments_Click(sender As System.Object, e As System.EventArgs) Handles btnGotoComments.Click
        timerGoToEnableComment = False
        timerPrevEnableComment = False
        timerNextEnableComment = False
        btnGotoComments.Enabled = False
        btnPrevPageComments.Enabled = False
        btnNextPageComments.Enabled = False
        cbComments.Items.Clear()
        pageIndexComment = nudPageComments.Value - 1
        curCommentQuery.StartIndex = pageIndexComment * 25
        tClock.Start()
        lStatusValue.Text = loadingPage & " " & pageIndexComment + 1 & " " & _of & " " & pagesComment
        bwComment.RunWorkerAsync()
    End Sub

    Private Sub btnPrevPageComments_Click(sender As System.Object, e As System.EventArgs) Handles btnPrevPageComments.Click
        timerGoToEnableComment = False
        timerPrevEnableComment = False
        timerNextEnableComment = False
        btnGotoComments.Enabled = False
        btnPrevPageComments.Enabled = False
        btnNextPageComments.Enabled = False
        cbComments.Items.Clear()
        pageIndexComment -= 1
        nudPageComments.Value = pageIndexComment + 1
        curCommentQuery.StartIndex = pageIndexComment * 25
        tClock.Start()
        lStatusValue.Text = loadingPage & " " & pageIndexComment + 1 & " " & _of & " " & pagesComment
        bwComment.RunWorkerAsync()
    End Sub

    Private Sub btnNextPageComments_Click(sender As System.Object, e As System.EventArgs) Handles btnNextPageComments.Click
        timerGoToEnableComment = False
        timerPrevEnableComment = False
        timerNextEnableComment = False
        btnGotoComments.Enabled = False
        btnPrevPageComments.Enabled = False
        btnNextPageComments.Enabled = False
        cbComments.Items.Clear()
        pageIndexComment += 1
        nudPageComments.Value = pageIndexComment + 1
        curCommentQuery.StartIndex = pageIndexComment * 25
        tClock.Start()
        lStatusValue.Text = loadingPage & " " & pageIndexComment + 1 & " " & _of & " " & pagesComment
        bwComment.RunWorkerAsync()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        For Each i As ListViewItem In lvVideos.SelectedItems
            Dim curUrl As String = "http://www.youtube.com/watch?v=" & DirectCast(i.Tag, Video).VideoId
            Dim dlg As New frmChooseVideoQuality(False, curUrl, frmMain.notAllowedFileNames, Nothing)
            If dlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                If dlg.isOK Then
                    frmMain.videoInfos.Add(dlg.resultInfo)
                    frmMain.fileNames.Add(dlg.resultFileName)
                    frmMain.notAllowedFileNames.Add(dlg.resultFileName)
                    Dim fi As New IO.FileInfo(dlg.resultFileName)
                    Dim item As New ListViewItem(fi.Name)
                    If Not frmMain.ilStatuses.Images.ContainsKey(fi.Extension & "_" & frmMain.Status.Downloaded) Then frmMain.ilStatuses.Images.Add(fi.Extension & "_" & frmMain.Status.Downloaded, frmMain.CreateFileTypeIcon(fi.Extension, frmMain.Status.Downloaded))
                    item.SubItems.Add(frmMain.lvVideos.Items.Count + 1)
                    item.SubItems.Add(fi.Directory.FullName)
                    item.SubItems.Add(frmMain.GetQualityName(dlg.resultInfo.VideoQuality, dlg.resultInfo.BestVideoQuality))
                    item.SubItems.Add(dlg.resultinfo.YouTubeFeedInfo.Video.Title)
                    item.SubItems.Add(dlg.resultinfo.YouTubeFeedInfo.Video.Uploader)
                    item.SubItems.Add(dlg.resultinfo.YouTubeFeedInfo.Video.VideoId)
                    item.SubItems.Add("http://www.youtube.com" & dlg.resultInfo.VideoURL)
                    item.Tag = dlg.resultInfo
                    item.ImageKey = fi.Extension & "_" & frmMain.Status.Downloaded
                    frmMain.lvVideos.Items.Add(item)
                    item.EnsureVisible()
                End If
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class