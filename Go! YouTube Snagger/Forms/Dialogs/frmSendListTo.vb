Imports System.Net
Imports System.Net.Mail
Imports Microsoft.VisualBasic.Devices
Imports System.Text.RegularExpressions

Public Class frmSendListTo

    Dim WithEvents smtpClient As New SmtpClient() With {.Credentials = New NetworkCredential("govisualteam@gmail.com", "govt1234"), .Port = 587, .Host = "smtp.gmail.com", .EnableSsl = True}

    Dim m_fileName As String

    'SomeCommands - Code
    Dim theSendingWasCancelled As String
    Dim anUnexpectedErrorAppeared As String
    Dim theListHasBeenSendToTheEmailAddress As String
    Dim _sendList As String
    Dim _cancel As String

    Dim sendingMail As Boolean = False

    Dim langFile As IniFile
    Dim index As Integer = 1

    Public Sub New(ByVal fileName As String)
        InitializeComponent()
        m_fileName = fileName
    End Sub

    Public Shared Function IsValidMailAdress(ByRef adress As String) As Boolean
        Dim pattern As String = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
        Dim reg As New Regex(pattern, RegexOptions.Compiled Or RegexOptions.IgnoreCase)
        Return reg.IsMatch(adress)
    End Function

    Private Function createBody(ByVal body As String) As String
        Dim resultString As String = ""
        resultString &= "<font size=""2"" face=""Segoe UI"" color=""Black"">" & vbNewLine
        resultString &= "<link href=""http://govisualteam.zxq.net/css/main.css"" rel=""stylesheet"" />" & vbNewLine
        resultString &= "<center><img src=""http://govisualteam.zxq.net/images/banner_mini.png""> </a></center>" & vbNewLine
        resultString &= "<hr />" & vbNewLine
        resultString &= "<p>From: " & txtName.Text & " (<a href=""mailto:" & txtFrom.Text & """>" & txtFrom.Text & "</a>)</p>"
        resultString &= "<p><b>Message:</b></p>" & vbNewLine
        resultString &= "<p>" & If(txtMessage.Text <> "", txtMessage.Text, "Hey! Check out my video list I created using Go! Youtube Snagger! I've attached it to my message.") & "</p>"
        resultString &= "<hr />"
        resultString &= "<p> If you don't have Go! YouTube Snagger installed on your computer, please click <a href=""http://govisualteam.zxq.net/products/ys.php"" target=""_blank"">here</a> to download it.</p>"
        resultString &= "</font>" & vbNewLine
        Return resultString
    End Function

    Private Sub sendList()
        Dim message As New MailMessage(txtFrom.Text, txtTo.Text, "Go! YouTube Snagger ~ Video List", createBody(txtMessage.Text)) With {.IsBodyHtml = True, .Sender = New MailAddress("govisualteam@hotmail.com", txtName.Text)}
        message.Attachments.Add(New Attachment(m_fileName))
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
        theListHasBeenSendToTheEmailAddress = langFile.GetString("SomeCommands", "TheListHasBeenSendToTheEmailAddress")

        'frmSendListTo = langFile.GetString("frmSendListTo", "")
        Me.Text = langFile.GetString("frmSendListTo", "Text")

        'frmSendListToControls = langFile.GetString("frmSendListToControls", "")
        lName.Text = langFile.GetString("frmSendListToControls", "Name")
        lFrom.Text = langFile.GetString("frmSendListToControls", "From")
        lTo.Text = langFile.GetString("frmSendListToControls", "To")
        lMessage.Text = langFile.GetString("frmSendListToControls", "Message")
        _sendList = langFile.GetString("frmSendListToControls", "SendList")
        _cancel = langFile.GetString("frmSendListToControls", "Cancel")
        btnSendList.Text = _sendList
        btnClose.Text = langFile.GetString("frmSendListToControls", "Close")

    End Sub

    Private Sub frmSendListTo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CheckLang()
    End Sub

    Private Sub tCheck_Tick(sender As System.Object, e As System.EventArgs) Handles tCheck.Tick
        btnSendList.Enabled = txtName.Text <> "" And IsValidMailAdress(txtFrom.Text) And IsValidMailAdress(txtTo.Text)
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
            MessageBox.ShowMessageBox(theListHasBeenSendToTheEmailAddress, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information)
            Me.Close()
        End If
    End Sub

    Private Sub btnSendList_Click(sender As System.Object, e As System.EventArgs) Handles btnSendList.Click
        If sendingMail Then
            smtpClient.SendAsyncCancel()
            btnSendList.Text = _sendList
        Else
            sendList()
            btnSendList.Text = _cancel
        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class