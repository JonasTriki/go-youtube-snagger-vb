Imports System.Net
Imports System.Net.Mail
Imports Microsoft.VisualBasic.Devices
Imports System.Speech.Synthesis

Public Class frmReportBug

    Dim WithEvents speechSAPI As New SpeechSynthesizer
    Dim WithEvents smtpClient As New SmtpClient() With {.Credentials = New NetworkCredential("govisualteambugreports@gmail.com", "govt1234"), .Port = 587, .Host = "smtp.gmail.com", .EnableSsl = True}

    'SomeCommands - Code
    Dim theSendingWasCancelled As String
    Dim anUnexpectedErrorAppeared As String
    Dim thankYouForSendingTheErrorReport As String
    Dim theSecurityCodeYouTypedInIsIncorrectPleaseTryAgain As String

    'frmReportBugControls - Design
    Dim _RefreshSecurityImage As String
    Dim _AudioVerification As String

    'frmReportBugControls - Code
    Dim _sendErrorMessage As String
    Dim _cancel As String

    Dim sendingMail As Boolean = False

    Dim speakingSAPI As Boolean = False
    Dim captchaInfo As CaptchaGenerator.CaptchaInfo

    Dim langFile As IniFile
    Dim index As Integer = 1

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal body As String, ByVal readOnlyBody As Boolean)
        InitializeComponent()
        txtMessage.Text = body
        txtMessage.IsReadOnly = readOnlyBody
    End Sub

    Private Function createBody(ByVal body As String) As String
        Dim resultString As String = ""
        resultString &= "<link href=""http://govisualteam.zxq.net/css/main.css"" rel=""stylesheet"" />" & vbNewLine
        resultString &= "<center><img src=""http://govisualteam.zxq.net/images/banner_mini.png""> </a></center>" & vbNewLine
        resultString &= "<hr />" & vbNewLine
        resultString &= "<font size=""3"" face=""Segoe UI"" color=""Black"">" & vbNewLine
        resultString &= "<p align=""center""><b>Go! YouTube Snagger ~ Error  Report</b></p>" & vbNewLine
        resultString &= "</font>" & vbNewLine
        resultString &= "<font size=""2"" face=""Segoe UI"" color=""Black"">" & vbNewLine
        resultString &= "<p>Name: " & txtName.Text & "<br />" & "</p>" & vbNewLine
        resultString &= "<p>Program version: " & My.Application.Info.Version.ToString & "<br />" & "Date: " & DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") & "</p>" & vbNewLine
        resultString &= "<p>OS Version: " & New ComputerInfo().OSFullName & "</p>" & vbNewLine
        resultString &= "<p><b>Message:</b></p>" & vbNewLine
        resultString &= "<p>" & body & "</p>"
        resultString &= "</font>" & vbNewLine
        Return resultString
    End Function

    Private Sub loadCAPTCHA()
        captchaInfo = New CaptchaGenerator(New Size(295, 65)).GenerateCaptcha(10)
        pbCaptcha.Image = captchaInfo.CaptchaImage
    End Sub

    Private Sub speakCAPTCHA()
        If captchaInfo.CaptchaVerificationString <> "" Then
            Dim speakString As String = ""
            For Each c As String In captchaInfo.CaptchaVerificationString
                If captchaInfo.CaptchaVerificationString.IndexOf(c) = captchaInfo.CaptchaVerificationString.Count - 1 Then
                    speakString &= c
                Else
                    speakString &= c & " "
                End If
            Next
            speakingSAPI = True
            speechSAPI.SpeakAsync(speakString)
        End If
    End Sub

    Private Sub sendErrorReport()
        Dim message As New MailMessage("govisualteambugreports@gmail.com", "govisualteam@gmail.com", "Go! YouTube Snagger ~ Error Report", createBody(txtMessage.Text)) With {.IsBodyHtml = True}
        smtpClient.SendAsync(message, Nothing)
        sendingMail = True
        pbClock.Visible = True
        clockTimer.Start()
    End Sub

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        theSendingWasCancelled = langFile.GetString("SomeCommands", "TheSendingWasCancelled")
        anUnexpectedErrorAppeared = langFile.GetString("SomeCommands", "AnUnexpectedErrorAppeared")
        thankYouForSendingTheErrorReport = langFile.GetString("SomeCommands", "ThankYouForSendingTheErrorReport")
        theSecurityCodeYouTypedInIsIncorrectPleaseTryAgain = langFile.GetString("SomeCommands", "TheSecurityCodeYouTypedInIsIncorrectPleaseTryAgain")

        'frmReportBug = langFile.GetString("frmReportBug", "")
        Me.Text = langFile.GetString("frmReportBug", "Text")

        'frmReportBugControls = langFile.GetString("frmReportBugControls", "")
        lName.Text = langFile.GetString("frmReportBugControls", "Name")
        lError.Text = langFile.GetString("frmReportBugControls", "ErrorMessage")
        lSecurityControl.Text = langFile.GetString("frmReportBugControls", "SecurityControl")
        lCode.Text = langFile.GetString("frmReportBugControls", "PleaseEnterCode")
        _RefreshSecurityImage = langFile.GetString("frmReportBugControls", "RefreshSecurityImage")
        ttCaptchaButtons.SetToolTip(pbReload, _RefreshSecurityImage)
        _AudioVerification = langFile.GetString("frmReportBugControls", "AudioVerification")
        ttCaptchaButtons.SetToolTip(pbSpeaker, _AudioVerification)
        _sendErrorMessage = langFile.GetString("frmReportBugControls", "SendErrorMessage")
        _cancel = langFile.GetString("frmReportBugControls", "Cancel")
        btnClose.Text = langFile.GetString("frmReportBugControls", "Close")
        btnSendError.Text = _sendErrorMessage

    End Sub

    Private Sub frmReportBug_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        speechSAPI.SpeakAsyncCancelAll()
    End Sub

    Private Sub frmReportBug_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CheckLang()
        loadCAPTCHA()
    End Sub

    Private Sub clockTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clockTimer.Tick
        If index = 1 Then
            index = 2
            pbClock.Image = My.Resources.Clock_2
        ElseIf index = 2 Then
            index = 3
            pbClock.Image = My.Resources.Clock_3
        ElseIf index = 3 Then
            index = 4
            pbClock.Image = My.Resources.Clock_4
        ElseIf index = 4 Then
            index = 5
            pbClock.Image = My.Resources.Clock_5
        ElseIf index = 5 Then
            index = 6
            pbClock.Image = My.Resources.Clock_6
        ElseIf index = 6 Then
            index = 7
            pbClock.Image = My.Resources.Clock_7
        ElseIf index = 7 Then
            index = 8
            pbClock.Image = My.Resources.Clock_8
        ElseIf index = 8 Then
            index = 9
            pbClock.Image = My.Resources.Clock_8
        ElseIf index = 9 Then
            index = 10
            pbClock.Image = My.Resources.Clock_10
        ElseIf index = 10 Then
            index = 11
            pbClock.Image = My.Resources.Clock_11
        ElseIf index = 11 Then
            index = 12
            pbClock.Image = My.Resources.Clock_12
        ElseIf index = 12 Then
            index = 13
            pbClock.Image = My.Resources.Clock_13
        ElseIf index = 13 Then
            index = 14
            pbClock.Image = My.Resources.Clock_14
        ElseIf index = 14 Then
            index = 15
            pbClock.Image = My.Resources.Clock_15
        ElseIf index = 15 Then
            index = 16
            pbClock.Image = My.Resources.Clock_16
        ElseIf index = 16 Then
            index = 1
            pbClock.Image = My.Resources.Clock_1
        End If
    End Sub

    Private Sub smtpClient_SendCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles smtpClient.SendCompleted
        clockTimer.Stop()
        pbClock.Visible = False
        If e.Cancelled Then
            sendingMail = False
            MessageBox.ShowMessageBox(theSendingWasCancelled, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information)
        ElseIf Not IsNothing(e.Error) Then
            MessageBox.ShowMessageBox(anUnexpectedErrorAppeared, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information)
        Else
            sendingMail = False
            MessageBox.ShowMessageBox(thankYouForSendingTheErrorReport, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information)
            Me.Close()
        End If
    End Sub

    Private Sub tCheck_Tick(sender As System.Object, e As System.EventArgs) Handles tCheck.Tick
        btnSendError.Enabled = txtName.Text <> "" And txtMessage.Text.Length >= 50 And txtCaptcha.Text.Length = 10
    End Sub

    Private Sub speechSAPI_SpeakCompleted(sender As Object, e As System.Speech.Synthesis.SpeakCompletedEventArgs) Handles speechSAPI.SpeakCompleted
        speakingSAPI = False
    End Sub

    Private Sub txtMessage_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMessage.TextChanged
        lMessageCount.Text = txtMessage.Text.Length & "/50"
        If txtMessage.Text.Length < 50 Then
            lMessageCount.ForeColor = Color.Maroon
        ElseIf txtMessage.Text.Length >= 50 Then
            lMessageCount.ForeColor = Color.Green
        End If
    End Sub

    Private Sub pbReload_MouseEnter(sender As System.Object, e As System.EventArgs) Handles pbReload.MouseEnter
        pbReload.Image = My.Resources.reload_selected
    End Sub

    Private Sub pbReload_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pbReload.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            pbReload.Image = My.Resources.reload_selected
        End If
    End Sub

    Private Sub pbReload_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pbReload.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.RectangleToScreen(pbReload.ClientRectangle).Contains(pbReload.PointToScreen(New Point(MousePosition.X - Me.Location.X, MousePosition.Y - Me.Location.Y))) Or pbReload.RectangleToScreen(pbReload.ClientRectangle).Contains(pbReload.PointToScreen(New Point(e.X, e.Y))) Then
                pbReload.Image = My.Resources.reload_selected
                speechSAPI.SpeakAsyncCancelAll()
                loadCAPTCHA()
            End If
        End If
    End Sub

    Private Sub pbReload_MouseLeave(sender As System.Object, e As System.EventArgs) Handles pbReload.MouseLeave
        pbReload.Image = My.Resources.reload_normal
    End Sub

    Private Sub pbSpeaker_MouseEnter(sender As System.Object, e As System.EventArgs) Handles pbSpeaker.MouseEnter
        pbSpeaker.Image = My.Resources.speaker_selected
    End Sub

    Private Sub pbSpeaker_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pbSpeaker.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            pbSpeaker.Image = My.Resources.speaker_selected
        End If
    End Sub

    Private Sub pbSpeaker_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pbSpeaker.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.RectangleToScreen(pbSpeaker.ClientRectangle).Contains(pbSpeaker.PointToScreen(New Point(MousePosition.X - Me.Location.X, MousePosition.Y - Me.Location.Y))) Or pbSpeaker.RectangleToScreen(pbSpeaker.ClientRectangle).Contains(pbSpeaker.PointToScreen(New Point(e.X, e.Y))) Then
                pbSpeaker.Image = My.Resources.speaker_selected
                If Not speakingSAPI Then
                    speakCAPTCHA()
                End If
            End If
        End If
    End Sub

    Private Sub pbSpeaker_MouseLeave(sender As System.Object, e As System.EventArgs) Handles pbSpeaker.MouseLeave
        pbSpeaker.Image = My.Resources.speaker_normal
    End Sub

    Private Sub btnSendError_Click(sender As System.Object, e As System.EventArgs) Handles btnSendError.Click
        If txtCaptcha.Text = captchaInfo.CaptchaVerificationString Then
            If sendingMail Then
                smtpClient.SendAsyncCancel()
                btnSendError.Text = _sendErrorMessage
            Else
                sendErrorReport()
                btnSendError.Text = _cancel
            End If
        Else
            MessageBox.ShowMessageBox(theSecurityCodeYouTypedInIsIncorrectPleaseTryAgain, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Critical)
            loadCAPTCHA()
        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class