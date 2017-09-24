Public Class frmPlayVideo

    'SomeCommands - Code
    Dim status As String
    Dim loading As String
    Dim ready As String

    Dim clockIndex As Integer = 1
    Dim langFile As IniFile

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Private Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        status = langFile.GetString("YouTubeInfo", "Status")
        tsslStatus.Text = status
        loading = langFile.GetString("SomeCommands", "Loading")
        ready = langFile.GetString("SomeCommands", "Ready")

        'frmPlayVideo = langFile.GetString("frmPlayVideo", "")
        Me.Text = langFile.GetString("frmPlayVideo", "Text")

    End Sub

    Public Sub New(ByVal videoID As String)
        InitializeComponent()
        CheckLang()
        tsslStatusValue.Text = loading
        tClock.Start()
        swfVideo.Movie = "http://youtube.com/v/" & videoID
        swfVideo.Play()
    End Sub

    Private Sub tClock_Tick(sender As System.Object, e As System.EventArgs) Handles tClock.Tick
        If clockIndex = 1 Then
            clockIndex = 2
            tsslStatusValue.Image = My.Resources.Clock_2
        ElseIf clockIndex = 2 Then
            clockIndex = 3
            tsslStatusValue.Image = My.Resources.Clock_3
        ElseIf clockIndex = 3 Then
            clockIndex = 4
            tsslStatusValue.Image = My.Resources.Clock_4
        ElseIf clockIndex = 4 Then
            clockIndex = 5
            tsslStatusValue.Image = My.Resources.Clock_5
        ElseIf clockIndex = 5 Then
            clockIndex = 6
            tsslStatusValue.Image = My.Resources.Clock_6
        ElseIf clockIndex = 6 Then
            clockIndex = 7
            tsslStatusValue.Image = My.Resources.Clock_7
        ElseIf clockIndex = 7 Then
            clockIndex = 8
            tsslStatusValue.Image = My.Resources.Clock_8
        ElseIf clockIndex = 8 Then
            clockIndex = 9
            tsslStatusValue.Image = My.Resources.Clock_8
        ElseIf clockIndex = 9 Then
            clockIndex = 10
            tsslStatusValue.Image = My.Resources.Clock_10
        ElseIf clockIndex = 10 Then
            clockIndex = 11
            tsslStatusValue.Image = My.Resources.Clock_11
        ElseIf clockIndex = 11 Then
            clockIndex = 12
            tsslStatusValue.Image = My.Resources.Clock_12
        ElseIf clockIndex = 12 Then
            clockIndex = 13
            tsslStatusValue.Image = My.Resources.Clock_13
        ElseIf clockIndex = 13 Then
            clockIndex = 14
            tsslStatusValue.Image = My.Resources.Clock_14
        ElseIf clockIndex = 14 Then
            clockIndex = 15
            tsslStatusValue.Image = My.Resources.Clock_15
        ElseIf clockIndex = 15 Then
            clockIndex = 16
            tsslStatusValue.Image = My.Resources.Clock_16
        ElseIf clockIndex = 16 Then
            clockIndex = 1
            tsslStatusValue.Image = My.Resources.Clock_1
        End If
    End Sub

    Private Sub swfVideo_OnReadyStateChange(sender As Object, e As AxShockwaveFlashObjects._IShockwaveFlashEvents_OnReadyStateChangeEvent) Handles swfVideo.OnReadyStateChange
        If e.newState = 4 Then
            tClock.Stop()
            tsslStatusValue.Image = My.Resources.downloaded_Normal
            tsslStatusValue.Text = ready
        End If
    End Sub
End Class