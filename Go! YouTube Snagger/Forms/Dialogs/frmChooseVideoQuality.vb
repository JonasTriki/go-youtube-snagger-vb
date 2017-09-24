Public Class frmChooseVideoQuality

    Dim WithEvents infoGetter As New YouTubeVideoInfoGetter

    Dim lastCheckedVideoURLWhoWorked As String
    Dim lastCheckedVideoQualityWhoWorked As Integer

    Dim m_URL As String
    Dim m_RelatedVideo As Boolean
    Dim m_NotAllowedFileNames As New List(Of String)

    Public resultInfo As YouTubeVideoInfo
    Public resultFileName As String

    'SomeCommands - Code
    Dim pleaseEnterAValidYouTubeVideoLink As String
    Dim downloadVideoTo As String
    Dim bestAvailable As String
    Dim theChoosenFileNameIsAlreadyAdded As String

    'InfoGetter - Code
    Dim connectingToYouTube As String
    Dim checkingIfYouTubeVideoIsValid As String
    Dim receivingAllVideoInformation As String
    Dim checkingVideoQuality As String
    Dim videoQualityIsNotAvailable As String
    Dim youTubeVideoIsReadyForDownload As String
    Dim youTubeVideoIsNotValid As String

    Dim m_frmDownloadProgress As frmDownloadProgress
    Public isOK As Boolean = False

    Dim clockIndex As Integer = 1
    Dim langFile As IniFile

    Public Sub New(ByVal relatedVideo As Boolean, ByVal URL As String, ByVal notAllowedFileNames As List(Of String), ByVal frmDownloadProgress As frmDownloadProgress)
        InitializeComponent()
        m_RelatedVideo = relatedVideo
        m_URL = URL
        m_NotAllowedFileNames = notAllowedFileNames
        m_frmDownloadProgress = frmDownloadProgress
    End Sub

    Private Function GetQuality() As YouTubeVideoInfoGetter.Qualities

        Dim resultQuality As YouTubeVideoInfoGetter.Qualities

        If cbQuality.SelectedIndex = 0 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._144p_176x144
        ElseIf cbQuality.SelectedIndex = 1 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._240p_400x240
        ElseIf cbQuality.SelectedIndex = 2 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._360p_480x360
        ElseIf cbQuality.SelectedIndex = 3 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._360p_640x360
        ElseIf cbQuality.SelectedIndex = 4 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._480p_854x480
        ElseIf cbQuality.SelectedIndex = 5 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._480p_854x480_WebM_HTML5
        ElseIf cbQuality.SelectedIndex = 6 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._720p_1280x720
        ElseIf cbQuality.SelectedIndex = 7 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._720p_1280x720_WebM_HTML5
        ElseIf cbQuality.SelectedIndex = 8 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._1080p_1920x1080
        ElseIf cbQuality.SelectedIndex = 9 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._4096p_4096x3072
        ElseIf cbQuality.SelectedIndex = 10 Then
            resultQuality = YouTubeVideoInfoGetter.Qualities._Best_Available
        End If

        Return resultQuality

    End Function

    Private Function CheckYouTubeVideoURL(ByVal url As String) As String
        Dim resultURL As String = ""
        If Not url.StartsWith("http://www.youtube.com/watch?v=") Then
            For Each ip As String In Split(url.Remove(0, Len("http://www.youtube.com/watch?")), "&")
                If ip.StartsWith("v=") Then
                    resultURL = "http://www.youtube.com/watch?" & ip
                    Exit For
                End If
                Application.DoEvents()
            Next
        Else
            resultURL = url
        End If
        Return resultURL
    End Function

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        bestAvailable = langFile.GetString("SomeCommands", "BestAvailable")
        downloadVideoTo = langFile.GetString("SomeCommands", "DownloadVideoTo")
        pleaseEnterAValidYouTubeVideoLink = langFile.GetString("SomeCommands", "PleaseEnterAValidYouTubeVideoLink")
        theChoosenFileNameIsAlreadyAdded = langFile.GetString("SomeCommands", "TheChoosenFileNameIsAlreadyAdded")

        'InfoGetter = langFile.GetString("InfoGetter", "")
        connectingToYouTube = langFile.GetString("InfoGetter", "ConnectingToYouTube")
        checkingIfYouTubeVideoIsValid = langFile.GetString("InfoGetter", "CheckingIfYouTubeVideoIsValid")
        receivingAllVideoInformation = langFile.GetString("InfoGetter", "ReceivingAllVideoInformation")
        checkingVideoQuality = langFile.GetString("InfoGetter", "CheckingVideoQuality")
        videoQualityIsNotAvailable = langFile.GetString("InfoGetter", "VideoQualityIsNotAvailable")
        youTubeVideoIsReadyForDownload = langFile.GetString("InfoGetter", "YouTubeVideoIsReadyForDownload")
        youTubeVideoIsNotValid = langFile.GetString("InfoGetter", "YouTubeVideoIsNotValid")

        'frmChooseVideoQuality = langFile.GetString("frmChooseVideoQuality", "")
        Me.Text = langFile.GetString("frmChooseVideoQuality", "Text")

        'frmChooseVideoQualityControls = langFile.GetString("frmChooseVideoQualityControls", "")
        btnOK.Text = langFile.GetString("frmChooseVideoQualityControls", "OK")
        btnCancel.Text = langFile.GetString("frmChooseVideoQualityControls", "Cancel")
        lStatus.Text = langFile.GetString("frmChooseVideoQualityControls", "Status")
        lStatusValue.Text = pleaseEnterAValidYouTubeVideoLink

    End Sub

    Private Function CheckAndOnlyGetYouTubeVideoURL(ByVal url As String) As String
        Dim resultURL As String = ""
        For Each ip As String In Split(url.Remove(0, Len("http://www.youtube.com/watch?")), "&")
            If ip.StartsWith("v=") Then
                resultURL = "http://www.youtube.com/watch?" & ip
                Exit For
            End If
            Application.DoEvents()
        Next
        Return resultURL
    End Function

    Private Function GetYouTubeVideoTag(ByVal url As String) As String
        Try
            Return Split(url.Remove(0, Len("http://www.youtube.com/watch?v=")), "&")(0)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function CheckForBadCharaters(ByVal inputString As String) As String

        Dim outputString As String = inputString

        For Each nAC As String In Split("\ / : * ? "" < > |")
            If outputString.Contains(nAC) Then
                outputString = outputString.Replace(nAC, "")
            End If
        Next

        Return FixEncodingString(outputString)

    End Function

    Private Function FixEncodingString(ByVal s As String) As String
        Return s.Replace("\/", "/").Replace("\", "&").Replace("u0026", "")
    End Function

    Private Sub frmChooseVideoQuality_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CheckLang()
        cbQuality.SelectedIndex = 1
        cbQuality.Items.Add(bestAvailable)
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

    Private Sub infoGetter_ConnectingToYouTube(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.ConnectingToYouTube
        tClock.Start()
        lStatusValue.Text = connectingToYouTube
    End Sub

    Private Sub infoGetter_CheckingIfYouTubeVideoIsValid(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.CheckingIfYouTubeVideoIsValid
        lStatusValue.Text = checkingIfYouTubeVideoIsValid
    End Sub

    Private Sub infoGetter_GettingAllVideoInformation(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.GettingAllVideoInformation
        lStatusValue.Text = receivingAllVideoInformation
    End Sub

    Private Sub infoGetter_CheckingQuality(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.CheckingQuality
        lStatusValue.Text = checkingVideoQuality
    End Sub

    Private Sub infoGetter_VideoQualityIsNotAvailable(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.VideoQualityIsNotAvailable
        tClock.Stop()
        clockIndex = 1
        pbClock.Image = My.Resources.failed_Normal
        lStatusValue.Text = videoQualityIsNotAvailable
    End Sub

    Private Sub infoGetter_Done(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.Done
        tClock.Stop()
        clockIndex = 1
        pbClock.Image = My.Resources.downloading_Normal
        lStatusValue.Text = youTubeVideoIsReadyForDownload
    End Sub

    Private Sub infoGetter_YouTubeVideoIsNotValid(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.YouTubeVideoIsNotValid
        tClock.Stop()
        clockIndex = 1
        pbClock.Image = My.Resources.failed_Normal
        lStatusValue.Text = youTubeVideoIsNotValid
    End Sub

    Private Sub bwDownloadVideo_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwDownloadVideo.DoWork
        resultInfo = infoGetter.GetYouTubeVideoInfo(m_URL, GetQuality)
    End Sub

    Private Sub bwDownloadVideo_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDownloadVideo.RunWorkerCompleted
        btnOK.Enabled = True
        tClock.Stop()
        If infoGetter.ReadyToDownload Then
            lastCheckedVideoURLWhoWorked = CheckAndOnlyGetYouTubeVideoURL(m_URL)
            lastCheckedVideoQualityWhoWorked = cbQuality.SelectedIndex
            Dim name As String = ""
            Dim filename As String = ""
            GoTo dowork
dowork:
            If m_RelatedVideo Then
                If My.Settings.autoSave Then
                    m_frmDownloadProgress.AddDownload(resultInfo, My.Settings.standardSaveLocation & "\" & CheckForBadCharaters(resultInfo.YouTubeFeedInfo.Video.Title) & resultInfo.FileType)
                    isOK = True
                    Me.Close()
                Else
                    Dim saveDlg As New SaveFileDialog

                    saveDlg.Title = downloadVideoTo
                    saveDlg.Filter = Shell32.GetFileType(resultInfo.FileType) & "|*" & resultInfo.FileType
                    saveDlg.FileName = CheckForBadCharaters(If(name = "", resultInfo.YouTubeFeedInfo.Video.Title, name))
                    If filename <> "" Then
                        Dim splitted_Filename As String() = Split(filename, "\")
                        Dim folder_Index As Integer = filename.IndexOf(splitted_Filename(splitted_Filename.Count - 2)) + splitted_Filename(splitted_Filename.Count - 2).Length
                        Dim folder As String = filename.Remove(folder_Index, filename.Length - folder_Index)
                        saveDlg.InitialDirectory = folder
                    End If

                    If saveDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If m_NotAllowedFileNames.Contains(saveDlg.FileName) Then
                            MessageBox.ShowMessageBox(theChoosenFileNameIsAlreadyAdded, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
                            Dim splitted_Filename As String() = Split(saveDlg.FileName, "\")
                            name = splitted_Filename(splitted_Filename.Count - 1)
                            GoTo dowork
                        Else
                            m_frmDownloadProgress.AddDownload(resultInfo, saveDlg.FileName)
                            isOK = True
                            Me.Close()
                        End If
                    End If
                End If
            Else
                If My.Settings.autoSave Then
                    resultFileName = My.Settings.standardSaveLocation & "\" & resultinfo.YouTubeFeedInfo.Video.Title & resultInfo.FileType
                    isOK = True
                    Me.Close()
                Else
                    Dim saveDlg As New SaveFileDialog

                    saveDlg.Title = downloadVideoTo
                    saveDlg.Filter = Shell32.GetFileType(resultInfo.FileType) & "|*" & resultInfo.FileType
                    saveDlg.FileName = If(name = "", resultinfo.YouTubeFeedInfo.Video.Title, name)
                    If filename <> "" Then
                        Dim splitted_Filename As String() = Split(filename, "\")
                        Dim folder_Index As Integer = filename.IndexOf(splitted_Filename(splitted_Filename.Count - 2)) + splitted_Filename(splitted_Filename.Count - 2).Length
                        Dim folder As String = filename.Remove(folder_Index, filename.Length - folder_Index)
                        saveDlg.InitialDirectory = folder
                    End If

                    If saveDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If m_NotAllowedFileNames.Contains(saveDlg.FileName) Then
                            MessageBox.ShowMessageBox(theChoosenFileNameIsAlreadyAdded, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
                            Dim splitted_Filename As String() = Split(saveDlg.FileName, "\")
                            name = splitted_Filename(splitted_Filename.Count - 1)
                            filename = saveDlg.FileName
                            GoTo dowork
                        Else
                            resultFileName = saveDlg.FileName
                            isOK = True
                            Me.Close()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If If(lastCheckedVideoURLWhoWorked <> "", GetYouTubeVideoTag(m_URL) = GetYouTubeVideoTag(lastCheckedVideoURLWhoWorked) And cbQuality.SelectedIndex = lastCheckedVideoQualityWhoWorked And infoGetter.ReadyToDownload, False) Then
            Dim name As String = ""
            Dim filename As String = ""
            GoTo dowork2
dowork2:
            If m_RelatedVideo Then
                If My.Settings.autoSave Then
                    m_frmDownloadProgress.AddDownload(resultInfo, My.Settings.standardSaveLocation & "\" & CheckForBadCharaters(resultInfo.YouTubeFeedInfo.Video.Title) & resultInfo.FileType)
                    isOK = True
                    Me.Close()
                Else
                    Dim saveDlg As New SaveFileDialog

                    saveDlg.Title = downloadVideoTo
                    saveDlg.Filter = Shell32.GetFileType(resultInfo.FileType) & "|*" & resultInfo.FileType
                    saveDlg.FileName = CheckForBadCharaters(If(name = "", resultInfo.YouTubeFeedInfo.Video.Title, name))
                    If filename <> "" Then
                        Dim splitted_Filename As String() = Split(filename, "\")
                        Dim folder_Index As Integer = filename.IndexOf(splitted_Filename(splitted_Filename.Count - 2)) + splitted_Filename(splitted_Filename.Count - 2).Length
                        Dim folder As String = filename.Remove(folder_Index, filename.Length - folder_Index)
                        saveDlg.InitialDirectory = folder
                    End If

                    If saveDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If m_NotAllowedFileNames.Contains(saveDlg.FileName) Then
                            MessageBox.ShowMessageBox(theChoosenFileNameIsAlreadyAdded, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
                            Dim splitted_Filename As String() = Split(saveDlg.FileName, "\")
                            name = splitted_Filename(splitted_Filename.Count - 1)
                            GoTo dowork2
                        Else
                            m_frmDownloadProgress.AddDownload(resultInfo, saveDlg.FileName)
                            isOK = True
                            Me.Close()
                        End If
                    End If
                End If
            Else
                If My.Settings.autoSave Then
                    resultFileName = My.Settings.standardSaveLocation & "\" & CheckForBadCharaters(resultInfo.YouTubeFeedInfo.Video.Title) & resultInfo.FileType
                    isOK = True
                    Me.Close()
                Else
                    Dim saveDlg As New SaveFileDialog

                    saveDlg.Title = downloadVideoTo
                    saveDlg.Filter = Shell32.GetFileType(resultInfo.FileType) & "|*" & resultInfo.FileType
                    saveDlg.FileName = CheckForBadCharaters(If(name = "", resultInfo.YouTubeFeedInfo.Video.Title, name))
                    If filename <> "" Then
                        Dim splitted_Filename As String() = Split(filename, "\")
                        Dim folder_Index As Integer = filename.IndexOf(splitted_Filename(splitted_Filename.Count - 2)) + splitted_Filename(splitted_Filename.Count - 2).Length
                        Dim folder As String = filename.Remove(folder_Index, filename.Length - folder_Index)
                        saveDlg.InitialDirectory = folder
                    End If

                    If saveDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If m_NotAllowedFileNames.Contains(saveDlg.FileName) Then
                            MessageBox.ShowMessageBox(theChoosenFileNameIsAlreadyAdded, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
                            Dim splitted_Filename As String() = Split(saveDlg.FileName, "\")
                            name = splitted_Filename(splitted_Filename.Count - 1)
                            filename = saveDlg.FileName
                            GoTo dowork2
                        Else
                            resultFileName = saveDlg.FileName
                            isOK = True
                            Me.Close()
                        End If
                    End If
                End If
            End If
        Else
            btnOK.Enabled = False
            tClock.Start()
            bwDownloadVideo.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        isOK = False
        Me.Close()
    End Sub
End Class