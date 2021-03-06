﻿Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Imports Microsoft.VisualBasic.Devices

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Dim WithEvents smtpClient As New SmtpClient() With {.Credentials = New NetworkCredential("govisualteambugreports@gmail.com", "govt1234"), .Port = 587, .Host = "smtp.gmail.com", .EnableSsl = True}

        'SomeCommands - Code
        Dim anUnexpectedErrorAppeared As String
        Dim wouldYouLikeToReportTheErrorToOurAdministators As String
        Dim thankYouForSendingTheErrorReport As String

        Dim installPath As String

        Public Shared langFile As IniFile

        Private Function createErrorBody(ByVal ex As Exception) As String
            Return "<p>Message: " & ex.Message & "</p>" & vbNewLine _
                 & "<p>Source: " & ex.Source & "</p>" & vbNewLine _
                 & "<p>StackTrace: " & ex.StackTrace & "</p>"
        End Function

        Private Function createBody(ByVal body As String) As String
            Dim resultString As String = ""
            resultString &= "<link href=""http://govisualteam.zxq.net/css/main.css"" rel=""stylesheet"" />" & vbNewLine
            resultString &= "<center><img src=""http://govisualteam.zxq.net/images/banner_mini.png""> </a></center>" & vbNewLine
            resultString &= "<hr />" & vbNewLine
            resultString &= "<font size=""3"" face=""Segoe UI"" color=""Black"">" & vbNewLine
            resultString &= "<p align=""center""><b>Go! YouTube Snagger ~ Error  Report ~ <u>AUTO GENERATED BY APPLICATION</u></b></p>" & vbNewLine
            resultString &= "</font>" & vbNewLine
            resultString &= "<font size=""2"" face=""Segoe UI"" color=""Black"">" & vbNewLine
            resultString &= "<p>Program version: " & My.Application.Info.Version.ToString & "<br />" & "Date: " & DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") & "</p>" & vbNewLine
            resultString &= "<p>OS Version: " & New ComputerInfo().OSFullName & "</p>" & vbNewLine
            resultString &= "<p><b>Exception (Error):</b></p>" & vbNewLine
            resultString &= "<p>" & body & "</p>"
            resultString &= "</font>" & vbNewLine
            Return resultString
        End Function

        Private Sub sendErrorReport(ByVal ex As Exception)
            Dim message As New MailMessage("govisualteambugreports@gmail.com", "govisualteam@gmail.com", "Go! YouTube Snagger ~ Error  Report ~ AUTO GENERATED BY APPLICATION", createBody(createErrorBody(ex))) With {.IsBodyHtml = True}
            smtpClient.SendAsync(message, Nothing)
        End Sub

        Private Sub setLangFile(ByVal fileName As String)
            langFile = New IniFile(fileName)
        End Sub

        Private Sub setLangFile(ByVal fileName As String, ByVal index As Integer)
            My.Settings.language = index
            langFile = New IniFile(fileName)
        End Sub

        '        Private Sub checkLang(ByVal commandLine As String())
        '            If My.Settings.firstRun Then
        '                My.Settings.firstRun = False
        '                Dim languageName As String = CultureInfo.InstalledUICulture.Name.ToLower

        '                'Check languages folder...
        '                Dim files As String() = My.Computer.FileSystem.GetFiles(installPath & "\languages").ToArray
        '                For Each lang As String In files
        '                    If New IniFile(lang).GetString("LanguagePackInfo", "Name") = languageName Then
        '                        My.Settings.language = Array.IndexOf(files, lang)
        '                        setLangFile(lang)
        '                        Exit For
        '                    End If
        '                Next
        '                If langFile.FileName = "" Then GoTo normal
        '            Else
        '                GoTo normal
        '            End If
        'normal:
        '            Dim standardLangFilePath As String = My.Computer.FileSystem.GetFiles(installPath & "\languages").Item(My.Settings.language)
        '            If commandLine.Length = 1 Then
        '                If IsNumeric(commandLine(0).Replace("-", "")) Then
        '                    If commandLine(0).Replace("-", "") < My.Computer.FileSystem.GetFiles(installPath & "\languages").Count Then
        '                        Dim index As Integer = commandLine(0).Replace("-", "")
        '                        standardLangFilePath = My.Computer.FileSystem.GetFiles(installPath & "\languages").Item(index)
        '                        setLangFile(standardLangFilePath, index)
        '                    Else
        '                        setLangFile(standardLangFilePath)
        '                    End If
        '                Else
        '                    setLangFile(standardLangFilePath)
        '                End If
        '            Else
        '                setLangFile(standardLangFilePath)
        '            End If
        '        End Sub

        Private Sub loadLang()

            'SomeCommands = langFile.GetString("SomeCommands", "")
            anUnexpectedErrorAppeared = langFile.GetString("SomeCommands", "AnUnexpectedErrorAppeared")
            wouldYouLikeToReportTheErrorToOurAdministators = langFile.GetString("SomeCommands", "WouldYouLikeToReportTheErrorToOurAdministators")
            thankYouForSendingTheErrorReport = langFile.GetString("SomeCommands", "ThankYouForSendingTheErrorReport")

        End Sub

        Private Sub smtpClient_SendCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles smtpClient.SendCompleted
            If Not IsNothing(e.Error) And Not e.Cancelled Then
                Throw e.Error
            Else
                MessageBox.ShowMessageBox(thankYouForSendingTheErrorReport, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information)
            End If
        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            ' My.Settings.firstRun = True
            If NetFrameworkChecker.IsNetFrameworkHigherThanOr35 Then
                installPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallLocation", "")
                'checkLang(e.CommandLine.ToArray)
                'loadLang()
            Else
                Dim result As MsgBoxResult = MsgBox(".Net Framework 3.5 is not installed on your computer! This component is needed for running Go! YouTube Snagger." & vbNewLine & "Would you like to download it now?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Error!")
                If result = MsgBoxResult.Yes Then
                    OpenURL.OpenURL("http://www.microsoft.com/downloads/en/details.aspx?FamilyId=333325fd-ae52-4e35-b531-508d977d32a6&displaylang=en")
                End If
            End If
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            'This is important; if you don't set to False, the application will close :(
            e.ExitApplication = False

            'Show an error message...
            Dim result As MessageBox.MessageDialogResults = MessageBox.ShowMessageBox(anUnexpectedErrorAppeared & "." & vbNewLine & wouldYouLikeToReportTheErrorToOurAdministators, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Exlamation)
            If result = MessageBox.MessageDialogResults.Yes Then
                sendErrorReport(e.Exception)
            End If
        End Sub
    End Class
End Namespace

