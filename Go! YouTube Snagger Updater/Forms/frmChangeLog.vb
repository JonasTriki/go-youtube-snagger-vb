Public Class frmChangeLog

    Dim langFile As IniFile

    Public Sub New(ByVal changeLog As String)
        InitializeComponent()
        txtLog.Text = changeLog
    End Sub

    Public Sub checkLang()
        langFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\languages").Item(My.Settings.language))
        loadLang()
    End Sub

    Private Sub loadLang()

        'frmChangeLog - langFile.GetString("frmChangeLog", "")
        Me.Text = langFile.GetString("frmChangeLog", "Text")

        'frmChangeLogControls - langFile.GetString("frmChangeLogControls", "")
        btnClose.Text = langFile.GetString("frmChangeLogControls", "Close")

    End Sub

    Private Sub frmChangeLog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        checkLang()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class