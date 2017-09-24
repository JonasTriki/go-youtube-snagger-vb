Imports System.Net
Imports System.Globalization

Public Class frmUpdater

    Dim WithEvents client As New WebClient
    Dim downloadFileNameQueue As New List(Of String)
    Dim downloadURLQueue As New List(Of String)
    Dim addedDownload As Boolean = False
    Dim currentURL As String
    Dim currentFileName As String
    Dim currentFileInfo As UnRealFileInfo

    'SomeCommands - Code
    Dim youHaveGotTheLatestVersionAvailable As String
    Dim aNewVersionIsAvailable As String
    Dim goYouTubeSnaggerCanNotConnectToTheServer As String
    Dim pleaseTryAgainLater As String
    Dim goYouTubeSnaggerIsAlreadyRunning As String
    Dim downloading As String
    Dim eachSecond As String
    Dim anUnexpectedErrorAppeared As String

    'frmUpdater - Code
    Dim title As String

    Dim dlSpeed As Double
    Dim seconds As Double

    Dim downloadVersion As String
    Dim downloadURLs As New List(Of String)

    Dim pathInfo As IO.FileInfo
    Dim versionURL As String = "http://govisualteam.zxq.net/products/versions/ys.txt"
    Dim update_filesURL As String = "http://govisualteam.zxq.net/products/update_files/ys.txt"
    Dim update_fileNamesURL As String = "http://govisualteam.zxq.net/products/update_fileNames/ys.txt"
    Dim update_changelogURL As String = "http://govisualteam.zxq.net/products/update_changelog/ys.txt"
    Dim changelog As String

    Dim dao As Boolean

    Dim errorResult As MessageBox.MessageDialogResults
    Dim langFile As IniFile

    Dim index As Integer = 1

    Enum Statuses

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

    Public Shared Function CheckProcess(ByVal name As String, ByVal extension As String, ByVal directory As String) As Boolean
        Dim resultBoolean As Boolean = False
        For Each p As Process In Process.GetProcesses(My.Computer.Name)
            On Error Resume Next
            If IO.Path.GetFileName(p.ProcessName) = name Then
                Dim fileName As String = directory & "\" & name & extension
                If fileName = p.Modules(0).FileName Then
                    resultBoolean = True
                    Exit For
                End If
            End If
            Application.DoEvents()
        Next
        Return resultBoolean
    End Function

    Private Function GetHTML(ByVal URL As String) As String
        Try
            Dim Request As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create(URL), Net.HttpWebRequest)
            Request.Method = "GET"
            Return New IO.StreamReader(DirectCast(Request.GetResponse, Net.HttpWebResponse).GetResponseStream, System.Text.Encoding.UTF8).ReadToEnd
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub checkForUpdates()
        bwUpdater.RunWorkerAsync()
    End Sub

    Dim language As Integer = 0
    Public Sub CheckLang()
        My.Settings.language = language
        langFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\languages").Item(My.Settings.language))
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        youHaveGotTheLatestVersionAvailable = langFile.GetString("SomeCommands", "YouHaveGotTheLatestVersionAvailable")
        aNewVersionIsAvailable = langFile.GetString("SomeCommands", "ANewVersionIsAvailable")
        goYouTubeSnaggerCanNotConnectToTheServer = langFile.GetString("SomeCommands", "GoYouTubeSnaggerCanNotConnectToTheServer")
        pleaseTryAgainLater = langFile.GetString("SomeCommands", "PleaseTryAgainLater")
        goYouTubeSnaggerIsAlreadyRunning = langFile.GetString("SomeCommands", "GoYouTubeSnaggerIsAlreadyRunning")
        downloading = langFile.GetString("SomeCommands", "Downloading")
        eachSecond = langFile.GetString("SomeCommands", "EachSecond")
        anUnexpectedErrorAppeared = langFile.GetString("SomeCommands", "AnUnexpectedErrorAppeared")

        'frmUpdater = langFile.GetString("frmUpdater", "")
        title = langFile.GetString("frmUpdater", "Text")
        Me.Text = title

        'frmUpdaterControls = langFile.GetString("frmUpdaterControls", "")
        lStatus.Text = langFile.GetString("frmUpdaterControls", "Status")
        lStatusValue.Text = langFile.GetString("frmUpdaterControls", "LookingForNewUpdates")
        btnWhatsNew.Text = langFile.GetString("frmUpdaterControls", "WhatsNew")
        btnDownload.Text = langFile.GetString("frmUpdaterControls", "Download")
        btnCancel.Text = langFile.GetString("frmUpdaterControls", "Cancel")

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

    Private Function GetUnRealFileInfo(ByVal fileName As String) As UnRealFileInfo
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

    Private Function getExt(ByVal filename As String) As String
        Dim splitted As String() = Split(filename, ".")
        Return "." & splitted(splitted.Length - 1)
    End Function

    Public Sub AddDownload(ByVal url As String, ByVal fileName As String)
        Dim ext As String = getExt(fileName)
        ilStatuses.Images.Add(ext & "_" & Statuses.Downloaded, CreateFileTypeIcon(ext, Statuses.Downloaded))
        ilStatuses.Images.Add(ext & "_" & Statuses.Downloading, CreateFileTypeIcon(ext, Statuses.Downloading))
        ilStatuses.Images.Add(ext & "_" & Statuses.Failed, CreateFileTypeIcon(ext, Statuses.Failed))
        ilStatuses.Images.Add(ext & "_" & Statuses.Paused, CreateFileTypeIcon(ext, Statuses.Paused))
        ilStatuses.Images.Add(ext & "_" & Statuses.Stopped, CreateFileTypeIcon(ext, Statuses.Stopped))
        gpbProgress.Icon = ilStatuses.Images(ext & "_" & Statuses.Downloading)
        If Not client.IsBusy Then
            btnDownload.Enabled = False
            btnCancel.Enabled = False
            currentURL = url
            currentFileName = fileName
            currentFileInfo = GetUnRealFileInfo(currentFileName)
            client.DownloadFileAsync(New Uri(url), fileName)
            downloadTimer.Start()
        Else
            addedDownload = True
            dlCount += 1
            gpbProgress.MaxValue = dlCount * 100
            downloadURLQueue.Add(url)
            downloadFileNameQueue.Add(fileName)
        End If
    End Sub

    Public Shared Function RoundUpTo2Decimals(ByVal val As Double) As Double
        Return val.ToString("F2")
    End Function

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If My.Application.CommandLineArgs.Count = 2 Then
            If My.Application.CommandLineArgs(0) = "-dao" Then
                If IsNumeric(My.Application.CommandLineArgs(1).Replace("-", "")) Then
                    language = My.Application.CommandLineArgs(1).Replace("-", "")
                    CheckLang()
                    pathInfo = New IO.FileInfo(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallPath", ""))
                    GoTo main
main:
                    If CheckProcess(IO.Path.GetFileNameWithoutExtension(pathInfo.Name), pathInfo.Extension, pathInfo.Directory.FullName) Then
                        errorResult = MessageBox.ShowMessageBox(goYouTubeSnaggerIsAlreadyRunning, MessageBox.MessageButtons.RetryCancel, MessageBox.MessageIcons.Exlamation)
                        If errorResult = MessageBox.MessageDialogResults.Retry Then
                            GoTo main
                        End If
                    Else
                        Dim d As String() = Split(GetHTML(update_filesURL), ",")
                        Dim f As String() = Split(GetHTML(update_fileNamesURL), ",")
                        downloadVersion = GetHTML(versionURL)
                        For Each url As String In d
                            AddDownload(url, f(Array.IndexOf(d, url)).Replace("%APPLOC%", My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallLocation", "")))
                            downloadURLs.Add(url)
                            Application.DoEvents()
                        Next
                    End If
                    dao = True
                End If
            End If
        ElseIf My.Application.CommandLineArgs.Count = 1 Then
            If IsNumeric(My.Application.CommandLineArgs(0).Replace("-", "")) Then
                language = My.Application.CommandLineArgs(0).Replace("-", "")
                CheckLang()
                clockTimer.Start()
                checkForUpdates()
            End If
        Else
            CheckLang()
            clockTimer.Start()
            checkForUpdates()
        End If
    End Sub

    Private Sub clockTimer_Tick(sender As System.Object, e As System.EventArgs) Handles clockTimer.Tick
        If index = 1 Then
            index = 2
            gpbProgress.Icon = My.Resources.Clock_2
        ElseIf index = 2 Then
            index = 3
            gpbProgress.Icon = My.Resources.Clock_3
        ElseIf index = 3 Then
            index = 4
            gpbProgress.Icon = My.Resources.Clock_4
        ElseIf index = 4 Then
            index = 5
            gpbProgress.Icon = My.Resources.Clock_5
        ElseIf index = 5 Then
            index = 6
            gpbProgress.Icon = My.Resources.Clock_6
        ElseIf index = 6 Then
            index = 7
            gpbProgress.Icon = My.Resources.Clock_7
        ElseIf index = 7 Then
            index = 8
            gpbProgress.Icon = My.Resources.Clock_8
        ElseIf index = 8 Then
            index = 9
            gpbProgress.Icon = My.Resources.Clock_8
        ElseIf index = 9 Then
            index = 10
            gpbProgress.Icon = My.Resources.Clock_10
        ElseIf index = 10 Then
            index = 11
            gpbProgress.Icon = My.Resources.Clock_11
        ElseIf index = 11 Then
            index = 12
            gpbProgress.Icon = My.Resources.Clock_12
        ElseIf index = 12 Then
            index = 13
            gpbProgress.Icon = My.Resources.Clock_13
        ElseIf index = 13 Then
            index = 14
            gpbProgress.Icon = My.Resources.Clock_14
        ElseIf index = 14 Then
            index = 15
            gpbProgress.Icon = My.Resources.Clock_15
        ElseIf index = 15 Then
            index = 16
            gpbProgress.Icon = My.Resources.Clock_16
        ElseIf index = 16 Then
            index = 1
            gpbProgress.Icon = My.Resources.Clock_1
        End If
    End Sub

    Private Sub downloadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downloadTimer.Tick
        seconds += 1
        dlSpeed = IIf(bytesReceived > 0, bytesReceived / 1024 / seconds * 1000, 0)
    End Sub

    Dim totalBytesToReceive As Long
    Dim bytesReceived As Long
    Private Sub client_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles client.DownloadProgressChanged
        totalBytesToReceive = e.TotalBytesToReceive
        bytesReceived = e.BytesReceived
        Dim progressPercentage As Double = RoundUpTo2Decimals((bytesReceived / totalBytesToReceive) * 100)
        gpbProgress.Value = RoundUpTo2Decimals(IIf(dlCount > 1, ((dlIndex - 1) * 100) + progressPercentage, progressPercentage))
        Me.Text = gpbProgress.Percentage & "% - " & title
        lStatusValue.Text = downloading & " """ & currentFileInfo.Name & """... (" & dlIndex & "/" & dlCount & ") - " & New ConvertByte().ToHighestAvailable(dlSpeed) & eachSecond & " - " & progressPercentage & "%"
    End Sub

    Dim dlCount As Integer = 1
    Dim dlIndex As Integer = 1
    Private Sub client_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles client.DownloadFileCompleted
        downloadTimer.Stop()
        If Not IsNothing(e.Error) Then
            btnDownload.Enabled = False
            btnCancel.Enabled = True
            gpbProgress.Icon = ilStatuses.Images(getExt(currentFileName) & "_" & Statuses.Failed)
            lStatusValue.Text = anUnexpectedErrorAppeared
        Else
            If downloadURLQueue.Count > 0 Then
                dlIndex += 1
                btnDownload.Enabled = False
                btnCancel.Enabled = False
                currentURL = downloadURLQueue(0)
                currentFileName = downloadFileNameQueue(0)
                currentFileInfo = GetUnRealFileInfo(currentFileName)
                gpbProgress.Icon = ilStatuses.Images(getExt(currentFileName) & "_" & Statuses.Downloading)
                client.DownloadFileAsync(New Uri(currentURL), currentFileName)
                downloadFileNameQueue.RemoveAt(0)
                downloadURLQueue.RemoveAt(0)
            Else
                btnDownload.Enabled = False
                btnCancel.Enabled = True
                gpbProgress.Icon = ilStatuses.Images(getExt(currentFileName) & "_" & Statuses.Downloaded)
                dlIndex = 1
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "DisplayVersion", downloadVersion)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "EstimatedSize", My.Computer.FileSystem.GetFileInfo(currentFileName).Length, Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Version", downloadVersion)
                If dao Then
                    Dim updaterPath As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallPath", "")
                    If updaterPath <> "" Then
                        Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
                        startInfo.UseShellExecute = True
                        startInfo.Arguments = "-" & language
                        startInfo.WorkingDirectory = New IO.FileInfo(updaterPath).Directory.FullName
                        startInfo.FileName = updaterPath
                        Try
                            Process.Start(startInfo)
                        Catch ex As Exception
                        End Try
                    End If
                End If
                Me.Close()
            End If
        End If
    End Sub

    Private Sub bwUpdater_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwUpdater.DoWork
        Application.DoEvents()
        downloadVersion = GetHTML(versionURL)
        Application.DoEvents()
        If downloadVersion <> "" Then
            Dim curVersion As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "DisplayVersion", "1.0.0.0")
            If curVersion = downloadVersion Then
                gpbProgress.Icon = My.Resources.downloaded_Normal
                gpbProgress.Value = 100
                lStatusValue.Text = youHaveGotTheLatestVersionAvailable & " (" & curVersion & ")"
            Else
                gpbProgress.Icon = My.Resources.downloading_Normal
                lStatusValue.Text = aNewVersionIsAvailable & " (" & downloadVersion & ")"
                btnDownload.Enabled = True
                btnWhatsNew.Enabled = True
                changelog = GetHTML(update_changelogURL).Replace("&NEWLINE&", vbNewLine)
                pathInfo = New IO.FileInfo(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallPath", ""))
            End If
        Else
            MessageBox.ShowMessageBox(goYouTubeSnaggerCanNotConnectToTheServer & vbNewLine & pleaseTryAgainLater, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Information)
        End If
    End Sub

    Private Sub bwUpdater_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUpdater.RunWorkerCompleted
        clockTimer.Stop()
    End Sub

    Private Sub btnWhatsNew_Click(sender As System.Object, e As System.EventArgs) Handles btnWhatsNew.Click
        Dim dlg As New frmChangeLog(changelog)
        dlg.ShowDialog()
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        GoTo main
main:
        If CheckProcess(IO.Path.GetFileNameWithoutExtension(pathInfo.Name), pathInfo.Extension, pathInfo.Directory.FullName) Then
            errorResult = MessageBox.ShowMessageBox(goYouTubeSnaggerIsAlreadyRunning, MessageBox.MessageButtons.RetryCancel, MessageBox.MessageIcons.Exlamation)
            If errorResult = MessageBox.MessageDialogResults.Retry Then
                GoTo main
            End If
        Else
            Dim d As String() = Split(GetHTML(update_filesURL), ",")
            Dim f As String() = Split(GetHTML(update_fileNamesURL), ",")
            For Each url As String In d
                AddDownload(url, f(Array.IndexOf(d, url)).Replace("%APPLOC%", My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallLocation", "")))
                downloadURLs.Add(url)
                Application.DoEvents()
            Next
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class