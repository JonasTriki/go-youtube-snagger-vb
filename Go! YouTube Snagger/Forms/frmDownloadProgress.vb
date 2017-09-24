Imports System.Net
Imports System.ComponentModel
Imports Microsoft.Win32

Public Class frmDownloadProgress

    WithEvents webClient As New WebClient
    Dim m_FullFileName As String

    Dim downloadFileNameQueue As New List(Of String)
    Dim downloadYouTubeVideoInfoQueue As New List(Of YouTubeVideoInfo)
    Dim addedDownload As Boolean = False
    Dim isBusy As Boolean = False

    'SomeCommands - Code
    Dim _stop As String
    Dim _stopAllDownloads As String
    Dim stopped As String
    Dim download As String
    Dim downloading As String
    Dim downloaded As String
    Dim eachSecond As String
    Dim _seconds As String
    Dim _second As String
    Dim _close As String
    Dim currentDownload As String
    Dim allDownloads As String
    Dim downloadError As String
    Dim theDownloadedFileHasNotGotAnyProgramBoundToIt As String
    Dim theDownloadedFileDoesNotExists As String
    Dim _error As String
    Dim areYouSureYouWouldLikeToCancelAllCurrentDownloads As String

    'YouTubeInfo - Code
    Dim _name As String
    Dim folder As String
    Dim _size As String
    Dim downloadedBytes As String
    Dim remaining As String
    Dim timeElapsed As String
    Dim timeLeft As String
    Dim downloadSpeed As String
    Dim status As String

    Dim openVideo As String
    Dim openFolder As String
    Dim showVideoInformation As String

    Dim fi As IO.FileInfo
    Dim m_VideoInfo As YouTubeVideoInfo

    Dim videoInfos As New List(Of YouTubeVideoInfo)
    Dim fileNames As New List(Of String)
    Public addedFileNames As New List(Of String)

    Dim langFile As IniFile

    Public Sub New(ByVal videoInfos As List(Of YouTubeVideoInfo), ByVal fileNames As List(Of String))
        InitializeComponent()
        For Each i As YouTubeVideoInfo In videoInfos
            Me.videoInfos.Add(i)
            Application.DoEvents()
        Next
        For Each i As String In fileNames
            Me.fileNames.Add(i)
            Application.DoEvents()
        Next
        addedFileNames = Me.fileNames
    End Sub

    Public Sub New(ByVal videoInfo As YouTubeVideoInfo, ByVal fileName As String)
        InitializeComponent()
        Me.videoInfos.Clear() : Me.videoInfos.Add(videoInfo)
        Me.fileNames.Clear() : Me.fileNames.Add(fileName) : addedFileNames.Add(fileName)
    End Sub

    Enum Statuses

        Downloaded = 1
        Downloading = 2
        Failed = 3
        Paused = 4
        Stopped = 5

    End Enum

    Public Shared Function RoundUpTo2Decimals(ByVal val As Double) As Double
        Return val.ToString("F2")
    End Function

    Private Function SecondsToDate(ByVal Seconds As Double) As String
        Try
            If Seconds < 60 Then
                Return Seconds & If(Seconds = 1, " " & _second, " " & _seconds)
            Else
                Return Date.FromOADate(Seconds / 86400).ToString("HH:mm:ss")
            End If
        Catch ex As Exception
            Return 0 & " " & _seconds
        End Try
    End Function

    Private Sub SetInfo(ByVal fileName As String)

        fi = New IO.FileInfo(fileName)

        Me.Text = "0% - " & fi.Name & " - " & download & "..."

        lNameValue.Text = fi.Name
        lFolderValue.Text = fi.Directory.FullName

    End Sub

    Private Function CreateFileTypeIcon(ByVal fileType As String, ByVal status As Statuses) As Image
        Dim ftImage As Image = Shell32.GetIcon(fileType).ToBitmap
        Dim g As Graphics = Graphics.FromImage(ftImage)
        Dim statusImage As Image = Nothing
        Select Case status
            Case Statuses.Downloaded
                statusImage = My.Resources.downloaded_small
            Case Statuses.Downloading
                statusImage = My.Resources.downloading_small
            Case Statuses.Failed
                statusImage = My.Resources.failed_small
            Case Statuses.Paused
                statusImage = My.Resources.paused_small
            Case Statuses.Stopped
                statusImage = My.Resources.paused_small
        End Select
        g.DrawImage(statusImage, New Rectangle(ftImage.Width - statusImage.Width, ftImage.Height - statusImage.Height, statusImage.Width, statusImage.Height))
        Return ftImage
    End Function

    Public Sub AddDownload(ByVal info As YouTubeVideoInfo, ByVal FileName As String)
        Dim ext As String = IO.Path.GetExtension(FileName)
        ilStatuses.Images.Add(ext & "_" & Statuses.Downloaded, CreateFileTypeIcon(ext, Statuses.Downloaded))
        ilStatuses.Images.Add(ext & "_" & Statuses.Downloading, CreateFileTypeIcon(ext, Statuses.Downloading))
        ilStatuses.Images.Add(ext & "_" & Statuses.Failed, CreateFileTypeIcon(ext, Statuses.Failed))
        ilStatuses.Images.Add(ext & "_" & Statuses.Paused, CreateFileTypeIcon(ext, Statuses.Paused))
        ilStatuses.Images.Add(ext & "_" & Statuses.Stopped, CreateFileTypeIcon(ext, Statuses.Stopped))
        addedFileNames.Add(FileName)
        gpbCurrentDownloadProgress.Icon = ilStatuses.Images(ext & "_" & Statuses.Downloading)
        gpbDownloadProgresses.Icon = ilStatuses.Images(ext & "_" & Statuses.Downloading)
        If Not isBusy Then
            dlCount = 1
            btnOpenVideo.Enabled = False
            btnOpenFolder.Enabled = False
            btnRelatedVideos.Enabled = True
            btnClose.Enabled = False
            m_VideoInfo = info
            m_FullFileName = FileName
            SetInfo(m_FullFileName)
            webClient.DownloadFileAsync(New Uri(info.VideoDownloadURL), m_FullFileName)
            isBusy = True
            downloadTimer.Start()
        Else
            addedDownload = True
            dlCount += 1
            gpbDownloadProgresses.MaxValue = dlCount * 100
            downloadFileNameQueue.Add(FileName)
            downloadYouTubeVideoInfoQueue.Add(info)
        End If
    End Sub

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        _stop = langFile.GetString("SomeCommands", "Stop")
        _stopAllDownloads = langFile.GetString("SomeCommands", "StopAllDownloads")
        stopped = langFile.GetString("SomeCommands", "Stopped")
        download = langFile.GetString("SomeCommands", "Download")
        downloading = langFile.GetString("SomeCommands", "Downloading")
        downloaded = langFile.GetString("SomeCommands", "Downloaded")
        eachSecond = langFile.GetString("SomeCommands", "EachSecond")
        _seconds = langFile.GetString("SomeCommands", "Seconds")
        _second = langFile.GetString("SomeCommands", "Second")
        _close = langFile.GetString("SomeCommands", "Close")
        currentDownload = langFile.GetString("SomeCommands", "CurrentDownload")
        allDownloads = langFile.GetString("SomeCommands", "AllDownloads")
        downloadError = langFile.GetString("SomeCommands", "DownloadError")
        theDownloadedFileHasNotGotAnyProgramBoundToIt = langFile.GetString("SomeCommands", "TheDownloadedFileHasNotGotAnyProgramBoundToIt").Replace("&NEWLINE&", vbNewLine)
        theDownloadedFileDoesNotExists = langFile.GetString("SomeCommands", "TheDownloadedFileDoesNotExists").Replace("&NEWLINE&", vbNewLine)
        _error = langFile.GetString("SomeCommands", "Error")
        areYouSureYouWouldLikeToCancelAllCurrentDownloads = langFile.GetString("SomeCommands", "AreYouSureYouWouldLikeToCancelAllCurrentDownloads")

        'YouTubeInfo = langFile.GetString("YouTubeInfo", "")
        _name = langFile.GetString("YouTubeInfo", "Name")
        folder = langFile.GetString("YouTubeInfo", "Folder")
        _size = langFile.GetString("YouTubeInfo", "Size")
        downloadedBytes = langFile.GetString("YouTubeInfo", "DownloadedBytes")
        remaining = langFile.GetString("YouTubeInfo", "Remaining")
        timeElapsed = langFile.GetString("YouTubeInfo", "TimeElapsed")
        timeLeft = langFile.GetString("YouTubeInfo", "TimeLeft")
        downloadSpeed = langFile.GetString("YouTubeInfo", "DownloadSpeed")
        status = langFile.GetString("YouTubeInfo", "Status")

        'frmDownload = langFile.GetString("frmDownload", "")
        Me.Text = "0% - ? - " & langFile.GetString("frmDownload", "Text")

        'frmDownloadControls = langFile.GetString("frmDownloadControls", "")
        gpbCurrentDownloadProgress.ExtraText = currentDownload
        btnStopDownload.Text = _stop
        gpbDownloadProgresses.ExtraText = allDownloads
        btnStopAllDownloads.Text = _stopAllDownloads
        lName.Text = _name
        lFolder.Text = folder
        lFileSize.Text = _size
        lDownloaded.Text = downloadedBytes
        lRemaining.Text = remaining
        lTimeElapsed.Text = timeElapsed
        lTimeRemaining.Text = timeLeft
        lDownloadSpeed.Text = downloadSpeed
        lStatus.Text = status
        btnOpenVideo.Text = langFile.GetString("frmDownloadControls", "OpenVideo")
        btnOpenFolder.Text = langFile.GetString("frmDownloadControls", "OpenFolder")
        btnRelatedVideos.Text = langFile.GetString("frmDownloadControls", "ShowRelatedVideos")
        btnClose.Text = langFile.GetString("frmDownloadControls", "Close")

    End Sub

    Private Sub frmDownloadProgress_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If isBusy Then
            e.Cancel = True
            Dim result As MessageBox.MessageDialogResults = MessageBox.ShowMessageBox(areYouSureYouWouldLikeToCancelAllCurrentDownloads, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Question)
            If result = MessageBox.MessageDialogResults.Yes Then
                stopped_all = True
                Dim delFileName As String = m_FullFileName
                webClient.CancelAsync()
                If Not webClient.IsBusy Then
                    GoTo delFile
                End If
delFile:
                Try
                    My.Computer.FileSystem.DeleteFile(delFileName, FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
                Catch ex As Exception
                    GoTo delFile
                End Try
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub frmDownload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckLang()
        For i As Integer = 0 To videoInfos.Count - 1
            AddDownload(videoInfos(i), fileNames(i))
            Application.DoEvents()
        Next
    End Sub

    Dim seconds As Double
    Private Sub downloadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downloadTimer.Tick
        seconds += 1
        Dim milliSeconds As Double = seconds * 1000
        Dim secondsElapsed As Integer = seconds
        lTimeElapsedValue.Text = SecondsToDate(secondsElapsed)
        Dim dlSpeed As Double = If(bytesReceived > 0, bytesReceived * 1024 / milliSeconds, 0)
        Dim sizeKB As Double = totalBytesToReceive * 1024
        Dim downloadedKB As Double = bytesReceived * 1024
        lTimeRemainingValue.Text = SecondsToDate(Math.Round((sizeKB - downloadedKB) * secondsElapsed / downloadedKB, 0))
        lDownloadSpeedValue.Text = New ConvertByte().ConvertByte((dlSpeed)) & eachSecond
    End Sub

    Dim totalBytesToReceive As Long
    Dim bytesReceived As Long
    Private Sub webClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles webClient.DownloadProgressChanged
        totalBytesToReceive = e.TotalBytesToReceive
        bytesReceived = e.BytesReceived
        Dim progressPercentage As Double = RoundUpTo2Decimals((bytesReceived / totalBytesToReceive) * 100)

        btnRelatedVideos.Enabled = True

        lFileSizeValue.Text = New ConvertByte().ConvertByte(totalBytesToReceive)
        lDownloadedValue.Text = New ConvertByte().ConvertByte(bytesReceived)
        lRemainingValue.Text = New ConvertByte().ConvertByte(totalBytesToReceive - bytesReceived)

        gpbCurrentDownloadProgress.Value = progressPercentage
        gpbDownloadProgresses.Value = RoundUpTo2Decimals(If(dlCount > 1, ((dlIndex - 1) * 100) + progressPercentage, progressPercentage))
        Me.Text = progressPercentage & "% - " & fi.Name & " - " & download & "..."

        lStatusValue.Text = downloading & " """ & fi.Name & """... (" & dlIndex & "/" & dlCount & ") " & progressPercentage & "%"
    End Sub

    Dim stopped_all As Boolean = False
    Dim dlCount As Integer = 1
    Dim dlIndex As Integer = 1
    Private Sub webClient_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles webClient.DownloadFileCompleted
        isBusy = False
        downloadTimer.Stop()
        If stopped_all Then
            btnStopDownload.Enabled = False
            btnStopAllDownloads.Enabled = False
        Else
            btnStopDownload.Enabled = downloadYouTubeVideoInfoQueue.Count > 0
            btnStopAllDownloads.Enabled = downloadYouTubeVideoInfoQueue.Count > 0
        End If
        btnOpenVideo.Enabled = If(Not e.Cancelled, If(Not IsNothing(e.Error), False, True), Not e.Cancelled)
        btnOpenFolder.Enabled = If(Not e.Cancelled, If(Not IsNothing(e.Error), False, True), Not e.Cancelled)
        btnRelatedVideos.Enabled = If(Not e.Cancelled, If(Not IsNothing(e.Error), False, True), Not e.Cancelled)
        btnClose.Enabled = True
        addedFileNames.RemoveAt(0)
        If e.Cancelled Then
            If Not stopped_all Then
                If downloadYouTubeVideoInfoQueue.Count > 0 Then
                    dlIndex += 1
                    frmMain.notAllowedFileNames.RemoveAt(0)
                    btnOpenVideo.Enabled = False
                    btnOpenFolder.Enabled = False
                    btnRelatedVideos.Enabled = True
                    btnClose.Enabled = False
                    m_VideoInfo = downloadYouTubeVideoInfoQueue(0)
                    m_FullFileName = downloadFileNameQueue(0)
                    SetInfo(m_FullFileName)
                    webClient.DownloadFileAsync(New Uri(m_VideoInfo.VideoDownloadURL), m_FullFileName)
                    isBusy = True
                    downloadTimer.Start()
                    downloadFileNameQueue.RemoveAt(0)
                    downloadYouTubeVideoInfoQueue.RemoveAt(0)
                Else
                    frmMain.notAllowedFileNames.Clear()
                    stopped_all = False
                    gpbCurrentDownloadProgress.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Failed)
                    gpbDownloadProgresses.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Failed)
                    lStatusValue.Text = stopped
                End If
            Else
                frmMain.notAllowedFileNames.Clear()
                gpbCurrentDownloadProgress.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Failed)
                gpbDownloadProgresses.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Failed)
                lStatusValue.Text = stopped
            End If
        ElseIf Not IsNothing(e.Error) Then
            frmMain.notAllowedFileNames.RemoveAt(0)
            gpbCurrentDownloadProgress.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Failed)
            gpbDownloadProgresses.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Failed)
            lStatusValue.Text = downloadError
            Throw e.Error
        Else
            lStatusValue.Text = downloaded
            addedDownload = Not addedDownload And downloadYouTubeVideoInfoQueue.Count = 1
            If Not stopped_all Then
                If downloadYouTubeVideoInfoQueue.Count > 0 Then
                    dlIndex += 1
                    frmMain.notAllowedFileNames.RemoveAt(0)
                    btnOpenVideo.Enabled = False
                    btnOpenFolder.Enabled = False
                    btnRelatedVideos.Enabled = True
                    btnClose.Enabled = False
                    m_VideoInfo = downloadYouTubeVideoInfoQueue(0)
                    m_FullFileName = downloadFileNameQueue(0)
                    SetInfo(m_FullFileName)
                    webClient.DownloadFileAsync(New Uri(m_VideoInfo.VideoDownloadURL), m_FullFileName)
                    isBusy = True
                    downloadTimer.Start()
                    downloadFileNameQueue.RemoveAt(0)
                    downloadYouTubeVideoInfoQueue.RemoveAt(0)
                Else
                    frmMain.notAllowedFileNames.Clear()
                    gpbCurrentDownloadProgress.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Downloaded)
                    gpbDownloadProgresses.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Downloaded)
                    dlIndex = 1
                End If
            Else
                frmMain.notAllowedFileNames.Clear()
                stopped_all = False
                gpbCurrentDownloadProgress.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Downloaded)
                gpbDownloadProgresses.Icon = ilStatuses.Images(IO.Path.GetExtension(m_FullFileName) & "_" & Statuses.Downloaded)
                dlIndex = 1
            End If
        End If
    End Sub

    Private Sub btnStopDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopDownload.Click
        Dim delFileName As String = m_FullFileName
        webClient.CancelAsync()
        If Not webClient.IsBusy Then
            GoTo delFile
        End If
delFile:
        Try
            My.Computer.FileSystem.DeleteFile(delFileName, FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
        Catch ex As Exception
            GoTo delFile
        End Try
    End Sub

    Private Sub btnStopAllDownloads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopAllDownloads.Click
        stopped_all = True
        Dim delFileName As String = m_FullFileName
        webClient.CancelAsync()
        If Not webClient.IsBusy Then
            GoTo delFile
        End If
delFile:
        Try
            My.Computer.FileSystem.DeleteFile(delFileName, FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
        Catch ex As Exception
            GoTo delFile
        End Try
    End Sub

    Private Sub btnOpenVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenVideo.Click
        Try
            Process.Start(m_FullFileName)
        Catch ex As Exception
            If Not Registry.ClassesRoot.GetSubKeyNames.Contains(IO.Path.GetExtension(m_FullFileName)) Then
                MessageBox.ShowMessageBox(theDownloadedFileHasNotGotAnyProgramBoundToIt, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Critical, _error)
            ElseIf Not My.Computer.FileSystem.FileExists(m_FullFileName) Then
                MessageBox.ShowMessageBox(theDownloadedFileDoesNotExists, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Critical, _error)
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Sub btnOpenFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFolder.Click
        Shell("Explorer.exe /select," & fi.FullName, AppWinStyle.NormalFocus)
    End Sub

    Private Sub btnShowVideoInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelatedVideos.Click
        Dim dlg As New frmRelatedVideos(m_VideoInfo.YouTubeFeedInfo.Video, Me)
        dlg.ShowDialog()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class