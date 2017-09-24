Imports System.IO
Imports System.Globalization
Imports System.Xml

Public Class frmMain

    Public WithEvents infoGetter As New YouTubeVideoInfoGetter
    Public resultInfo As YouTubeVideoInfo

    Public lastCheckedVideoURLWhoWorked As String
    Public lastCheckedVideoQualityWhoWorked As Integer
    Public doRestart As Boolean = False

    'InfoGetter - Code
    Dim connectingToYouTube As String
    Dim checkingIfYouTubeVideoIsValid As String
    Dim receivingAllVideoInformation As String
    Dim checkingVideoQuality As String
    Dim videoQualityIsNotAvailable As String
    Dim youTubeVideoIsReadyToBeAdded As String
    Dim youTubeVideoIsNotValid As String

    'SomeCommands - Code
    Dim pleaseEnterAValidYouTubeVideoLink As String
    Public downloadVideoTo As String
    Dim bestAvailable As String
    Public theChoosenFileNameIsAlreadyAdded As String
    Dim aNewVersionIsAvailable As String
    Dim wouldYouLikeToDownloadItNow As String
    Dim goYouTubeSnaggerCanNotConnectToTheServer As String
    Dim pleaseTryAgainLater As String
    Dim download As String
    Dim success As String
    Dim _exportList As String
    Dim theListIsExportedTo As String
    Dim _importList As String
    Dim anUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces As String
    Dim _err As String

    Public videoInfos As New List(Of YouTubeVideoInfo)
    Public fileNames As New List(Of String)
    Public notAllowedFileNames As New List(Of String)

    Dim internetConnected As Boolean

    Dim langFile As IniFile
    Dim index As Integer = 1

    Enum Status

        Downloaded = 1
        Downloading = 2
        Failed = 3
        Paused = 4
        Stopped = 5

    End Enum

    Structure UnRealFileInfo

        Dim FileName As String
        Dim Name As String
        Dim NameWithoutExtension As String
        Dim Extension As String
        Dim Directory As String

    End Structure

    Public Function GetQuality() As YouTubeVideoInfoGetter.Qualities

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

    Public Function GetHTML(ByVal URL As String) As String
        Try
            Dim Request As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create(URL), Net.HttpWebRequest)
            Request.Method = "GET"
            Return New IO.StreamReader(DirectCast(Request.GetResponse, Net.HttpWebResponse).GetResponseStream, System.Text.Encoding.UTF8).ReadToEnd
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function CheckYouTubeVideoURL(ByVal url As String) As String
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

    Public Function GetYouTubeVideoTag(ByVal url As String) As String
        Dim resultID As String = ""
        If Not url.StartsWith("http://www.youtube.com/watch?v=") Then
            For Each ip As String In Split(url.Remove(0, Len("http://www.youtube.com/watch?")), "&")
                If ip.StartsWith("v=") Then
                    resultID = ip.Replace("v=", "")
                    Exit For
                End If
                Application.DoEvents()
            Next
        Else
            resultID = Split(url.Replace("http://www.youtube.com/watch?v=", ""), "&")(0)
        End If
        Return resultID
    End Function

    Public Function CheckAndOnlyGetYouTubeVideoURL(ByVal url As String) As String
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

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Private Function StringToBASE64(ByVal input As String) As String
        Return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input))
    End Function

    Private Function BASE64ToString(ByVal base64 As String) As String
        Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64))
    End Function

    Private Function exportList(ByVal items As ListView.ListViewItemCollection, ByVal outputFileName As String) As Boolean
        Try
            'Write the XML...
            With New XmlTextWriter(outputFileName, System.Text.Encoding.UTF8)
                .Formatting = Formatting.Indented
                .WriteStartDocument()
                .WriteStartElement("items")
                For Each item As ListViewItem In items
                    Dim yvi As YouTubeVideoInfo = videoInfos(items.IndexOf(item))
                    .WriteStartElement("item")
                    .WriteStartElement("youtubevideoinfo")
                    .WriteElementString("VideoURL", yvi.VideoURL)
                    .WriteEndElement()
                    .WriteEndElement()
                Next
                .WriteEndElement()
                .WriteEndDocument()
                .Flush()
                .Close()
            End With

            'Convert the XML to BASE64...
            My.Computer.FileSystem.WriteAllText(outputFileName, StringToBASE64(My.Computer.FileSystem.ReadAllText(outputFileName)), False)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Function importList(ByVal inputFileName As String) As Boolean
        Try
            'Convert the BASE64 to XML...
            Dim temp As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & IO.Path.GetFileNameWithoutExtension(IO.Path.GetRandomFileName) & ".ysl"
            My.Computer.FileSystem.WriteAllText(temp, BASE64ToString(My.Computer.FileSystem.ReadAllText(inputFileName)), False)

            'Load the XML list...
            videoInfos.Clear()
            fileNames.Clear()
            notAllowedFileNames.Clear()
            lvVideos.Items.Clear()
            Dim XMLReader As New XmlTextReader(temp)
            XMLReader.MoveToContent()
            Dim elementName As String = ""
            Dim nextItem As Boolean = True
            Dim item As New ListViewItem
            Dim folder As String = ""
            Dim name As String = ""
            Dim fi As FileInfo = Nothing
            Do While XMLReader.Read
                If nextItem Then
                    item = New ListViewItem
                    folder = ""
                    name = ""
                    nextItem = False
                End If
                Select Case XMLReader.NodeType
                    Case XmlNodeType.Element
                        elementName = XMLReader.Name
                    Case XmlNodeType.Text
                        Select Case elementName
                            Case "VideoURL"
                                Dim dlg As New frmChooseVideoQuality(False, "http://www.youtube.com" & XMLReader.Value, notAllowedFileNames, Nothing)
                                If dlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                                    If dlg.isOK Then
                                        fi = New FileInfo(dlg.resultFileName)
                                        If Not ilStatuses.Images.ContainsKey(fi.Extension & "_" & Status.Downloaded) Then ilStatuses.Images.Add(fi.Extension & "_" & Status.Downloaded, CreateFileTypeIcon(fi.Extension, Status.Downloaded))
                                        item.Text = fi.Name
                                        item.SubItems.Add(lvVideos.Items.Count + 1)
                                        item.SubItems.Add(fi.Directory.FullName)
                                        item.SubItems.Add(GetQualityName(dlg.resultInfo.VideoQuality, dlg.resultInfo.BestVideoQuality))
                                        item.SubItems.Add(dlg.resultinfo.YouTubeFeedInfo.Video.Title)
                                        item.SubItems.Add(dlg.resultinfo.YouTubeFeedInfo.Video.Uploader)
                                        item.SubItems.Add(dlg.resultinfo.YouTubeFeedInfo.Video.VideoId)
                                        item.SubItems.Add("http://www.youtube.com" & dlg.resultInfo.VideoURL)
                                        item.Tag = dlg.resultInfo
                                        item.ImageKey = fi.Extension & "_" & Status.Downloaded
                                        videoInfos.Add(dlg.resultInfo)
                                        fileNames.Add(folder & "\" & name)
                                        notAllowedFileNames.Add(folder & "\" & name)
                                        lvVideos.Items.Add(item)
                                        item.EnsureVisible()
                                        nextItem = True
                                    End If
                                End If
                        End Select
                End Select
            Loop
            XMLReader.Close()

            'Delete the temp file...
            My.Computer.FileSystem.DeleteFile(temp, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        bestAvailable = langFile.GetString("SomeCommands", "BestAvailable")
        downloadVideoTo = langFile.GetString("SomeCommands", "DownloadVideoTo")
        pleaseEnterAValidYouTubeVideoLink = langFile.GetString("SomeCommands", "PleaseEnterAValidYouTubeVideoLink")
        theChoosenFileNameIsAlreadyAdded = langFile.GetString("SomeCommands", "TheChoosenFileNameIsAlreadyAdded")
        aNewVersionIsAvailable = langFile.GetString("SomeCommands", "ANewVersionIsAvailable")
        wouldYouLikeToDownloadItNow = langFile.GetString("SomeCommands", "WouldYouLikeToDownloadItNow")
        goYouTubeSnaggerCanNotConnectToTheServer = langFile.GetString("SomeCommands", "GoYouTubeSnaggerCanNotConnectToTheServer")
        pleaseTryAgainLater = langFile.GetString("SomeCommands", "PleaseTryAgainLater")
        download = langFile.GetString("SomeCommands", "Download")
        success = langFile.GetString("SomeCommands", "Success")
        _exportList = langFile.GetString("SomeCommands", "ExportList")
        theListIsExportedTo = langFile.GetString("SomeCommands", "TheListIsExportedTo")
        _importList = langFile.GetString("SomeCommands", "ImportList")
        anUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces = langFile.GetString("SomeCommands", "AnUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces")
        _err = langFile.GetString("SomeCommands", "Error")

        'InfoGetter = langFile.GetString("InfoGetter", "")
        connectingToYouTube = langFile.GetString("InfoGetter", "ConnectingToYouTube")
        checkingIfYouTubeVideoIsValid = langFile.GetString("InfoGetter", "CheckingIfYouTubeVideoIsValid")
        receivingAllVideoInformation = langFile.GetString("InfoGetter", "ReceivingAllVideoInformation")
        checkingVideoQuality = langFile.GetString("InfoGetter", "CheckingVideoQuality")
        videoQualityIsNotAvailable = langFile.GetString("InfoGetter", "VideoQualityIsNotAvailable")
        youTubeVideoIsReadyToBeAdded = langFile.GetString("InfoGetter", "YouTubeVideoIsReadyToBeAdded")
        youTubeVideoIsNotValid = langFile.GetString("InfoGetter", "YouTubeVideoIsNotValid")

        'frmMain = langFile.GetString("frmMain", "")
        Me.Text = langFile.GetString("frmMain", "Text")

        'frmMainControls = langFile.GetString("frmMainControls", "")
        lStatus.Text = langFile.GetString("frmMainControls", "Status")
        lStatusValue.Text = pleaseEnterAValidYouTubeVideoLink
        chFileName.Text = langFile.GetString("frmMainControls", "FileName")
        chIndex.Text = langFile.GetString("frmMainControls", "ID")
        chFileFolder.Text = langFile.GetString("frmMainControls", "Folder")
        chVideoQuality.Text = langFile.GetString("frmMainControls", "VideoQuality")
        chTitle.Text = langFile.GetString("frmMainControls", "VideoTitle")
        chUserName.Text = langFile.GetString("frmMainControls", "Username")
        chVideoID.Text = langFile.GetString("frmMainControls", "VideoID")
        chVideoURL.Text = langFile.GetString("frmMainControls", "VideoURL")
        btnSearch.Text = langFile.GetString("frmMainControls", "Search")
        btnAddVideo.Text = langFile.GetString("frmMainControls", "AddVideo")
        btnRemoveVideos.Text = langFile.GetString("frmMainControls", "RemoveVideo(s)")
        btnOpenVideoURL.Text = langFile.GetString("frmMainControls", "OpenVideoURL")
        btnPlayVideo.Text = langFile.GetString("frmMainControls", "PlayVideo")
        btnShowThumbnailImages.Text = langFile.GetString("frmMainControls", "ShowThumbnailImages")
        btnExport.Text = langFile.GetString("frmMainControls", "ExportList")
        btnImport.Text = langFile.GetString("frmMainControls", "ImportList")
        btnSendList.Text = langFile.GetString("frmMainControls", "SendListTo")
        btnMoveUp.Text = langFile.GetString("frmMainControls", "MoveUp")
        btnMoveDown.Text = langFile.GetString("frmMainControls", "MoveDown")
        btnCopyVideoID.Text = langFile.GetString("frmMainControls", "CopyVideoID")
        btnCopyVideoURL.Text = langFile.GetString("frmMainControls", "CopyVideoURL")
        btnAbout.Text = langFile.GetString("frmMainControls", "AboutGoYouTubeSnagger")
        btnOptions.Text = langFile.GetString("frmMainControls", "Settings")
        btnReportBug.Text = langFile.GetString("frmMainControls", "ReportBug")
        btnExit.Text = langFile.GetString("frmMainControls", "Exit")
        btnDownloadVideos.Text = langFile.GetString("frmMainControls", "DownloadVideos")
        InstillingerToolStripMenuItem.Text = langFile.GetString("frmMainControls", "Settings")
        OmGoYoutubeSnaggerToolStripMenuItem.Text = langFile.GetString("frmMainControls", "AboutGoYouTubeSnagger")
        AvsluttToolStripMenuItem.Text = langFile.GetString("frmMainControls", "Exit")

    End Sub

    Public Function CreateFileTypeIcon(ByVal fileType As String, ByVal status As Status) As Image
        Dim ftImage As Image = Shell32.GetIcon(fileType).ToBitmap
        Dim g As Graphics = Graphics.FromImage(ftImage)
        Dim statusImage As Image = Nothing
        Select Case status
            Case frmMain.Status.Downloaded
                statusImage = My.Resources.downloaded_small
            Case frmMain.Status.Downloading
                statusImage = My.Resources.downloading_small
            Case frmMain.Status.Failed
                statusImage = My.Resources.failed_small
            Case frmMain.Status.Paused
                statusImage = My.Resources.paused_small
            Case frmMain.Status.Stopped
                statusImage = My.Resources.paused_small
        End Select
        g.DrawImage(statusImage, New Rectangle(ftImage.Width - statusImage.Width, ftImage.Height - statusImage.Height, statusImage.Width, statusImage.Height))
        Return ftImage
    End Function

    Public Function QualityToStringName(ByVal quality As YouTubeVideoInfoGetter.Qualities) As String
        Dim resultString As String = ""
        If quality = YouTubeVideoInfoGetter.Qualities._144p_176x144 Then
            resultString = "144p - 176x144"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._240p_400x240 Then
            resultString = "240p - 400x240"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._360p_480x360 Then
            resultString = "360p - 480x360"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._360p_640x360 Then
            resultString = "360p - 640x360"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._480p_854x480 Then
            resultString = "480p - 854x480"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._480p_854x480_WebM_HTML5 Then
            resultString = "480p - 854x480 - WebM(HTML5)"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._720p_1280x720 Then
            resultString = "720p - 1280x720"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._720p_1280x720_WebM_HTML5 Then
            resultString = "720p - 1280x720 - WebM(HTML5)"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._1080p_1920x1080 Then
            resultString = "1080p - 1920x1080"
        ElseIf quality = YouTubeVideoInfoGetter.Qualities._4096p_4096x3072 Then
            resultString = "4096p - 4096x3072/4096x2304"
        End If
        Return resultString
    End Function

    Public Function GetQualityName(ByVal quality As YouTubeVideoInfoGetter.Qualities, ByVal bestQualityAvailable As YouTubeVideoInfoGetter.Qualities)
        If quality = YouTubeVideoInfoGetter.Qualities._Best_Available Then
            Return bestAvailable & " (" & QualityToStringName(bestQualityAvailable) & ")"
        Else
            Return QualityToStringName(quality)
        End If
    End Function

    Public Sub CheckItems()
        For Each i As ListViewItem In lvVideos.Items
            i.SubItems(1).Text = i.Index + 1
            Application.DoEvents()
        Next
    End Sub

    Public Function GetUnRealFileInfo(ByVal fileName As String) As UnRealFileInfo
        Dim resultInfo As New UnRealFileInfo
        If fileName <> "" Then
            Dim splitted_Filename As String() = Split(fileName, "\")
            Dim folder_Index As Integer = fileName.IndexOf(splitted_Filename(splitted_Filename.Count - 2)) + splitted_Filename(splitted_Filename.Count - 2).Length
            resultInfo.FileName = fileName
            resultInfo.Directory = fileName.Remove(folder_Index, fileName.Length - folder_Index)
            resultInfo.Name = splitted_Filename(splitted_Filename.Count - 1)
            resultInfo.NameWithoutExtension = Split(resultInfo.Name, ".")(0)
            resultInfo.Extension = "." & Split(resultInfo.Name, ".")(1)
        End If
        Return resultInfo
    End Function

    Public Function FixAutoFileName(ByVal autoFileName As String, ByVal fileNames As List(Of String)) As String
        Dim info As UnRealFileInfo = GetUnRealFileInfo(autoFileName)
        Dim resultString As String = autoFileName
        If fileNames.Contains(autoFileName) Then
            Dim index As Integer = 1
            Do Until Not fileNames.Contains(info.Directory & "\" & info.NameWithoutExtension & " (" & index & ")" & info.Extension)
                index += 1
            Loop
            resultString = info.Directory & "\" & info.NameWithoutExtension & " (" & index & ")" & info.Extension
        End If
        Return resultString
    End Function

    Public Function CheckInternetConnection() As Boolean
        If Not My.Computer.Network.IsAvailable Then Return False
        Dim WebRequest As Net.WebRequest = Net.WebRequest.Create(New Uri("http://www.Google.com/"))
        Try
            Dim WebResponse As Net.WebResponse = WebRequest.GetResponse
            WebResponse.Close()
            WebRequest = Nothing
            Return True
        Catch Ex As Exception
            WebRequest = Nothing
            Return False
        End Try
    End Function

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Size = New Size(800, 479)
        If My.Settings.autoUpdate Then
            bwUpdate.RunWorkerAsync()
        End If
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If doRestart Then
            Shell(Application.ExecutablePath, AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CheckLang()
        If My.Application.CommandLineArgs.Count = 1 Then
            If My.Application.CommandLineArgs(0).EndsWith(".ysl") And My.Computer.FileSystem.FileExists(My.Application.CommandLineArgs(0)) Then
                importList(My.Application.CommandLineArgs(0))
            End If
        End If
        cbQuality.SelectedIndex = 1
        cbQuality.Items.Add("")
        txtURL.Text = "http://www.youtube.com/"
    End Sub

    Private Sub tListView_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tListView.Tick
        btnRemoveVideos.Enabled = lvVideos.SelectedIndices.Count > 0
        btnOpenVideoURL.Enabled = lvVideos.SelectedIndices.Count = 1
        btnExport.Enabled = lvVideos.Items.Count > 0
        btnSendList.Enabled = lvVideos.Items.Count > 0
        btnShowThumbnailImages.Enabled = lvVideos.SelectedIndices.Count = 1
        btnPlayVideo.Enabled = lvVideos.SelectedIndices.Count = 1
        If lvVideos.SelectedIndices.Count = 1 Then
            btnMoveUp.Enabled = lvVideos.SelectedIndices(0) <> 0
            btnMoveDown.Enabled = lvVideos.SelectedIndices(0) <> lvVideos.Items.Count - 1
        Else
            btnMoveUp.Enabled = False
            btnMoveDown.Enabled = False
        End If
        btnCopyVideoID.Enabled = lvVideos.SelectedIndices.Count = 1
        btnCopyVideoURL.Enabled = lvVideos.SelectedIndices.Count = 1
        btnDownloadVideos.Enabled = lvVideos.Items.Count > 0
    End Sub

    Private Sub clockTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clockTimer.Tick
        If index = 1 Then
            index = 2
            txtURL.Icon = My.Resources.Clock_2
        ElseIf index = 2 Then
            index = 3
            txtURL.Icon = My.Resources.Clock_3
        ElseIf index = 3 Then
            index = 4
            txtURL.Icon = My.Resources.Clock_4
        ElseIf index = 4 Then
            index = 5
            txtURL.Icon = My.Resources.Clock_5
        ElseIf index = 5 Then
            index = 6
            txtURL.Icon = My.Resources.Clock_6
        ElseIf index = 6 Then
            index = 7
            txtURL.Icon = My.Resources.Clock_7
        ElseIf index = 7 Then
            index = 8
            txtURL.Icon = My.Resources.Clock_8
        ElseIf index = 8 Then
            index = 9
            txtURL.Icon = My.Resources.Clock_8
        ElseIf index = 9 Then
            index = 10
            txtURL.Icon = My.Resources.Clock_10
        ElseIf index = 10 Then
            index = 11
            txtURL.Icon = My.Resources.Clock_11
        ElseIf index = 11 Then
            index = 12
            txtURL.Icon = My.Resources.Clock_12
        ElseIf index = 12 Then
            index = 13
            txtURL.Icon = My.Resources.Clock_13
        ElseIf index = 13 Then
            index = 14
            txtURL.Icon = My.Resources.Clock_14
        ElseIf index = 14 Then
            index = 15
            txtURL.Icon = My.Resources.Clock_15
        ElseIf index = 15 Then
            index = 16
            txtURL.Icon = My.Resources.Clock_16
        ElseIf index = 16 Then
            index = 1
            txtURL.Icon = My.Resources.Clock_1
        End If
    End Sub

    Dim checkedYouTubeVideoURL As String
    Private Sub bwVideoCheck_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwVideoCheck.DoWork
        checkedYouTubeVideoURL = CheckYouTubeVideoURL(txtURL.Text)
        resultInfo = infoGetter.GetYouTubeVideoInfo(checkedYouTubeVideoURL, GetQuality)
        Dim dlURL As String = resultInfo.VideoDownloadURL
        If Not resultInfo.IsValidYouTubeVideo Then infoGetter_YouTubeVideoIsNotValid(infoGetter, New EventArgs)
    End Sub

    Private Sub bwVideoCheck_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwVideoCheck.RunWorkerCompleted
        btnAddVideo.Enabled = True
        If infoGetter.ReadyToDownload Then
            lastCheckedVideoURLWhoWorked = CheckAndOnlyGetYouTubeVideoURL(checkedYouTubeVideoURL)
            lastCheckedVideoQualityWhoWorked = cbQuality.SelectedIndex
            Dim name As String = ""
            Dim filename As String = ""
            Dim filenameUnRealFileInfo As New UnRealFileInfo
            GoTo dowork
dowork:
            If My.Settings.autoSave Then
                Dim autoFileName As String = My.Settings.standardSaveLocation & "\" & CheckForBadCharaters(resultInfo.YouTubeFeedInfo.Video.Title) & resultInfo.FileType
                If notAllowedFileNames.Contains(autoFileName) Then
                    autoFileName = FixAutoFileName(autoFileName, fileNames)
                End If
                videoInfos.Add(resultInfo)
                fileNames.Add(autoFileName)
                notAllowedFileNames.Add(autoFileName)
                Dim fi As New FileInfo(autoFileName)
                Dim item As New ListViewItem(fi.Name)
                If Not ilStatuses.Images.ContainsKey(fi.Extension & "_" & Status.Downloaded) Then ilStatuses.Images.Add(fi.Extension & "_" & Status.Downloaded, CreateFileTypeIcon(fi.Extension, Status.Downloaded))
                item.SubItems.Add(lvVideos.Items.Count + 1)
                item.SubItems.Add(fi.Directory.FullName)
                item.SubItems.Add(GetQualityName(resultInfo.VideoQuality, resultInfo.BestVideoQuality))
                item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.Title)
                item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.Uploader)
                item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.VideoId)
                item.SubItems.Add("http://www.youtube.com" & resultInfo.VideoURL)
                item.Tag = resultInfo
                item.ImageKey = fi.Extension & "_" & Status.Downloaded
                lvVideos.Items.Add(item)
                item.EnsureVisible()
            Else
                Dim saveDlg As New SaveFileDialog
                saveDlg.Title = downloadVideoTo
                saveDlg.Filter = Shell32.GetFileType(resultInfo.FileType) & "|*" & resultInfo.FileType
                saveDlg.FileName = CheckForBadCharaters(resultInfo.YouTubeFeedInfo.Video.Title)
                saveDlg.InitialDirectory = If(filenameUnRealFileInfo.Directory <> "", filenameUnRealFileInfo.Directory, My.Settings.standardSaveLocation)
                If saveDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If notAllowedFileNames.Contains(saveDlg.FileName) Then
                        MessageBox.ShowMessageBox(theChoosenFileNameIsAlreadyAdded, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
                        filename = saveDlg.FileName
                        filenameUnRealFileInfo = GetUnRealFileInfo(filename)
                        name = filenameUnRealFileInfo.Name
                        GoTo dowork
                    Else
                        videoInfos.Add(resultInfo)
                        fileNames.Add(saveDlg.FileName)
                        notAllowedFileNames.Add(saveDlg.FileName)
                        Dim fi As New FileInfo(saveDlg.FileName)
                        Dim item As New ListViewItem(fi.Name)
                        If Not ilStatuses.Images.ContainsKey(fi.Extension & "_" & Status.Downloaded) Then ilStatuses.Images.Add(fi.Extension & "_" & Status.Downloaded, CreateFileTypeIcon(fi.Extension, Status.Downloaded))
                        item.SubItems.Add(lvVideos.Items.Count + 1)
                        item.SubItems.Add(fi.Directory.FullName)
                        item.SubItems.Add(GetQualityName(resultInfo.VideoQuality, resultInfo.BestVideoQuality))
                        item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.Title)
                        item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.Uploader)
                        item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.VideoId)
                        item.SubItems.Add("http://www.youtube.com" & resultInfo.VideoURL)
                        item.Tag = resultInfo
                        item.ImageKey = fi.Extension & "_" & Status.Downloaded
                        lvVideos.Items.Add(item)
                        item.EnsureVisible()
                    End If
                End If
            End If
        End If
    End Sub

    Dim ibRestart_show As Boolean = False
    Private Sub bwUpdate_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwUpdate.DoWork
        Application.DoEvents()
        Dim downloadVersion As String = GetHTML("http://govisualteam.zxq.net/products/versions/ys.txt")
        Application.DoEvents()
        If downloadVersion <> "" Then
            Dim curVersion As String = My.Application.Info.Version.ToString
            If Not curVersion = downloadVersion Then
                ibRestart.Message = aNewVersionIsAvailable & " (" & downloadVersion & "). " & wouldYouLikeToDownloadItNow & " -->"
                ibRestart.ExtraButtonCaption = download & "..."
                ibRestart_show = True
            End If
        Else
            MessageBox.ShowMessageBox(goYouTubeSnaggerCanNotConnectToTheServer & vbNewLine & pleaseTryAgainLater, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information)
        End If
    End Sub

    Private Sub bwUpdate_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUpdate.RunWorkerCompleted
        ibRestart.Visible = ibRestart_show
        ibRestart_show = False
    End Sub

    Private Sub ibRestart_Showed(sender As System.Object, e As System.EventArgs) Handles ibRestart.Showed
        Me.Size = New Size(800, 501)
    End Sub

    Private Sub ibRestart_Closed(sender As System.Object, e As System.EventArgs) Handles ibRestart.Closed
        Me.Size = New Size(800, 479)
    End Sub

    Private Sub ibRestart_ExtraButtonClicked(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ibRestart.ExtraButtonClicked
        Dim updaterPath As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "UpdaterPath", "")
        If updaterPath <> "" Then
            Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
            startInfo.UseShellExecute = True
            startInfo.Arguments = "-dao -" & My.Settings.language
            startInfo.WorkingDirectory = New IO.FileInfo(updaterPath).Directory.FullName
            startInfo.FileName = updaterPath
            startInfo.Verb = "runas"
            Try
                Process.Start(startInfo)
            Catch ex As Exception
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub txtURL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtURL.TextChanged
        If txtURL.Text.StartsWith("http://www.youtube.com/watch?") And txtURL.Text.Length > Len("http://www.youtube.com/watch?") Then
            If If(lastCheckedVideoURLWhoWorked <> "", GetYouTubeVideoTag(txtURL.Text) = GetYouTubeVideoTag(lastCheckedVideoURLWhoWorked) And cbQuality.SelectedIndex = lastCheckedVideoQualityWhoWorked And infoGetter.ReadyToDownload, False) Then
                lStatusValue.Text = youTubeVideoIsReadyToBeAdded
                txtURL.Icon = My.Resources.downloading_Normal
            Else
                lStatusValue.Text = pleaseEnterAValidYouTubeVideoLink
                txtURL.Icon = My.Resources.youtube
            End If
        Else
            lStatusValue.Text = pleaseEnterAValidYouTubeVideoLink
            txtURL.Icon = My.Resources.youtube
        End If
        btnAddVideo.Enabled = txtURL.Text.StartsWith("http://www.youtube.com/watch?") And txtURL.Text.Length > Len("http://www.youtube.com/watch?")
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim dlg As New frmSearch
        dlg.ShowDialog()
    End Sub

    Private Sub btnAddVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddVideo.Click
        If If(lastCheckedVideoURLWhoWorked <> "", GetYouTubeVideoTag(txtURL.Text) = GetYouTubeVideoTag(lastCheckedVideoURLWhoWorked) And cbQuality.SelectedIndex = lastCheckedVideoQualityWhoWorked And infoGetter.ReadyToDownload, False) Then
            Dim name As String = ""
            Dim filename As String = ""
            Dim filenameUnRealFileInfo As UnRealFileInfo = GetUnRealFileInfo(filename)
            GoTo dowork2
dowork2:
            lastCheckedVideoURLWhoWorked = CheckAndOnlyGetYouTubeVideoURL(lastCheckedVideoURLWhoWorked)
            lastCheckedVideoQualityWhoWorked = cbQuality.SelectedIndex
            If My.Settings.autoSave Then
                Dim autoFileName As String = My.Settings.standardSaveLocation & "\" & CheckForBadCharaters(resultInfo.YouTubeFeedInfo.Video.Title) & resultInfo.FileType
                If notAllowedFileNames.Contains(autoFileName) Then
                    autoFileName = FixAutoFileName(autoFileName, fileNames)
                End If
                videoInfos.Add(resultInfo)
                fileNames.Add(autoFileName)
                notAllowedFileNames.Add(autoFileName)
                Dim fi As New FileInfo(autoFileName)
                Dim item As New ListViewItem(fi.Name)
                If Not ilStatuses.Images.ContainsKey(fi.Extension & "_" & Status.Downloaded) Then ilStatuses.Images.Add(fi.Extension & "_" & Status.Downloaded, CreateFileTypeIcon(fi.Extension, Status.Downloaded))
                item.SubItems.Add(lvVideos.Items.Count + 1)
                item.SubItems.Add(fi.Directory.FullName)
                item.SubItems.Add(GetQualityName(resultInfo.VideoQuality, resultInfo.BestVideoQuality))
                item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.Title)
                item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.Uploader)
                item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.VideoId)
                item.SubItems.Add("http://www.youtube.com" & resultInfo.VideoURL)
                item.Tag = resultInfo
                item.ImageKey = fi.Extension & "_" & Status.Downloaded
                lvVideos.Items.Add(item)
                item.EnsureVisible()
            Else
                Dim saveDlg As New SaveFileDialog
                saveDlg.Title = downloadVideoTo
                saveDlg.Filter = Shell32.GetFileType(resultInfo.FileType) & "|*" & resultInfo.FileType
                saveDlg.FileName = CheckForBadCharaters(resultInfo.YouTubeFeedInfo.Video.Title)
                saveDlg.InitialDirectory = If(filenameUnRealFileInfo.Directory <> "", filenameUnRealFileInfo.Directory, My.Settings.standardSaveLocation)
                If saveDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If notAllowedFileNames.Contains(saveDlg.FileName) Then
                        MessageBox.ShowMessageBox(theChoosenFileNameIsAlreadyAdded, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
                        filename = saveDlg.FileName
                        filenameUnRealFileInfo = GetUnRealFileInfo(filename)
                        name = filenameUnRealFileInfo.Name
                        GoTo dowork2
                    Else
                        videoInfos.Add(resultInfo)
                        fileNames.Add(saveDlg.FileName)
                        notAllowedFileNames.Add(saveDlg.FileName)
                        Dim fi As New FileInfo(saveDlg.FileName)
                        Dim item As New ListViewItem(fi.Name)
                        If Not ilStatuses.Images.ContainsKey(fi.Extension & "_" & Status.Downloaded) Then ilStatuses.Images.Add(fi.Extension & "_" & Status.Downloaded, CreateFileTypeIcon(fi.Extension, Status.Downloaded))
                        item.SubItems.Add(lvVideos.Items.Count + 1)
                        item.SubItems.Add(fi.Directory.FullName)
                        item.SubItems.Add(GetQualityName(resultInfo.VideoQuality, resultInfo.BestVideoQuality))
                        item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.Title)
                        item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.Uploader)
                        item.SubItems.Add(resultInfo.YouTubeFeedInfo.Video.VideoId)
                        item.SubItems.Add("http://www.youtube.com" & resultInfo.VideoURL)
                        item.Tag = resultInfo
                        item.ImageKey = fi.Extension & "_" & Status.Downloaded
                        lvVideos.Items.Add(item)
                        item.EnsureVisible()
                    End If
                End If
            End If
        Else
            btnAddVideo.Enabled = False
            clockTimer.Start()
            bwVideoCheck.RunWorkerAsync()
        End If
    End Sub

    Private Sub lvVideos_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lvVideos.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            If DirectCast(e.Data.GetData(DataFormats.FileDrop), String()).Count = 1 Then
                Dim file As String = e.Data.GetData(DataFormats.FileDrop)(0)
                If file.ToLower.EndsWith(".ysl") And My.Computer.FileSystem.FileExists(file) Then
                    e.Effect = e.AllowedEffect
                Else
                    e.Effect = DragDropEffects.None
                End If
            End If
        End If
    End Sub

    Private Sub lvVideos_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lvVideos.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            If DirectCast(e.Data.GetData(DataFormats.FileDrop), String()).Count = 1 Then
                Dim file As String = e.Data.GetData(DataFormats.FileDrop)(0)
                importList(file)
            End If
        End If
    End Sub

    Private Sub btnRemoveVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveVideos.Click
        For Each i As ListViewItem In lvVideos.SelectedItems
            videoInfos.RemoveAt(i.Index)
            fileNames.RemoveAt(i.Index)
            notAllowedFileNames.RemoveAt(i.Index)
            lvVideos.Items.Remove(i)
            Application.DoEvents()
        Next
        CheckItems()
    End Sub

    Private Sub btnOpenVideoURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenVideoURL.Click
        OpenURL.OpenURL(lvVideos.SelectedItems(0).SubItems(7).Text)
    End Sub

    Private Sub btnPlayVideo_Click(sender As System.Object, e As System.EventArgs) Handles btnPlayVideo.Click
        Dim dlg As New frmPlayVideo(lvVideos.SelectedItems(0).SubItems(6).Text)
        dlg.Show()
    End Sub

    Private Sub btnShowThumbnailImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowThumbnailImages.Click
        Dim dlg As New frmVideoThumbnails(lvVideos.SelectedItems(0).SubItems(6).Text)
        dlg.Show()
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim dlg As New SaveFileDialog
        dlg.Title = _exportList
        dlg.Filter = Shell32.GetFileType(".ysl") & "|*.ysl"
        dlg.FileName = ""
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            If exportList(lvVideos.Items, dlg.FileName) Then
                MessageBox.ShowMessageBox(theListIsExportedTo & " " & dlg.FileName, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information, success)
            End If
        End If
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        Dim dlg As New OpenFileDialog
        dlg.Title = _importList
        dlg.Filter = Shell32.GetFileType(".ysl") & "|*.ysl"
        dlg.FileName = ""
        dlg.Multiselect = False
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            importList(dlg.FileName)
        End If
    End Sub

    Private Sub btnSendList_Click(sender As System.Object, e As System.EventArgs) Handles btnSendList.Click
        Dim temp As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & IO.Path.GetFileNameWithoutExtension(IO.Path.GetRandomFileName) & ".ysl"
        If exportList(lvVideos.Items, temp) Then
            Dim sdlg As New frmSendListTo(temp)
            sdlg.ShowDialog()
        End If
    End Sub

    Private Sub btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUp.Click
        Dim item As ListViewItem = lvVideos.SelectedItems(0).Clone
        Dim fileName As String = item.SubItems(2).Text & "\" & item.Text
        Dim newIndex As Integer = lvVideos.SelectedItems(0).Index - 1
        videoInfos.Remove(item.Tag)
        fileNames.Remove(fileName)
        lvVideos.Items.Remove(lvVideos.SelectedItems(0))
        lvVideos.Items.Insert(newIndex, item)
        videoInfos.Insert(newIndex, item.Tag)
        fileNames.Insert(newIndex, fileName)
        lvVideos.Focus()
        item.Selected = True
        CheckItems()
    End Sub

    Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDown.Click
        Dim item As ListViewItem = lvVideos.SelectedItems(0).Clone
        Dim fileName As String = item.SubItems(2).Text & "\" & item.Text
        Dim newIndex As Integer = lvVideos.SelectedItems(0).Index + 1
        videoInfos.Remove(item.Tag)
        fileNames.Remove(fileName)
        lvVideos.Items.Remove(lvVideos.SelectedItems(0))
        lvVideos.Items.Insert(newIndex, item)
        videoInfos.Insert(newIndex, item.Tag)
        fileNames.Insert(newIndex, fileName)
        lvVideos.Focus()
        item.Selected = True
        CheckItems()
    End Sub

    Private Sub btnCopyVideoID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyVideoID.Click
        Try
            Clipboard.SetText(lvVideos.SelectedItems(0).SubItems(6).Text)
        Catch ex As Exception
            MessageBox.ShowMessageBox(anUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
        End Try
    End Sub

    Private Sub btnCopyVideoURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyVideoURL.Click
        Try
            Clipboard.SetText(lvVideos.SelectedItems(0).SubItems(7).Text)
        Catch ex As Exception
            MessageBox.ShowMessageBox(anUnexpectedErrorOccurredAndTheCopyProcessDidNotSucces, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
        End Try
    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        Dim dlg As New frmAbout
        dlg.ShowDialog()
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        Dim dlg As New frmOptions
        dlg.ShowDialog()
    End Sub

    Private Sub btnReportBug_Click(sender As System.Object, e As System.EventArgs) Handles btnReportBug.Click
        Dim dlg As New frmReportBug
        dlg.Show()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        My.Settings.Save()
        End
    End Sub

    Private Sub btnDownloadVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadVideos.Click
        Dim dlg As New frmDownloadProgress(videoInfos, fileNames)
        dlg.Show()
        videoInfos.Clear()
        fileNames.Clear()
        lvVideos.Items.Clear()
    End Sub

    Private Sub infoGetter_ConnectingToYouTube(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.ConnectingToYouTube
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
        clockTimer.Stop()
        index = 1
        txtURL.Icon = My.Resources.failed_Normal
        lStatusValue.Text = videoQualityIsNotAvailable
        MessageBox.ShowMessageBox(videoQualityIsNotAvailable, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation, _err)
    End Sub

    Private Sub infoGetter_Done(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.Done
        clockTimer.Stop()
        index = 1
        txtURL.Icon = My.Resources.downloading_Normal
        lStatusValue.Text = youTubeVideoIsReadyToBeAdded
    End Sub

    Private Sub infoGetter_YouTubeVideoIsNotValid(ByVal sender As Object, ByVal e As EventArgs) Handles infoGetter.YouTubeVideoIsNotValid
        clockTimer.Stop()
        index = 1
        txtURL.Icon = My.Resources.failed_Normal
        lStatusValue.Text = youTubeVideoIsNotValid
        MessageBox.ShowMessageBox(youTubeVideoIsNotValid, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation, _err)
    End Sub

    Private Sub OmGoYoutubeSnaggerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OmGoYoutubeSnaggerToolStripMenuItem.Click
        btnAbout.PerformClick()
    End Sub

    Private Sub InstillingerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstillingerToolStripMenuItem.Click
        btnOptions.PerformClick()
    End Sub

    Private Sub AvsluttToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvsluttToolStripMenuItem.Click
        btnExit.PerformClick()
    End Sub
End Class