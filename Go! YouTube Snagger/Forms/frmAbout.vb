Public Class frmAbout

    Dim langFile As IniFile

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'frmAbout = langFile.GetString("frmAbout","")
        Me.Text = langFile.GetString("frmAbout", "Text")

        'frmAboutControls = langFile.GetString("frmAboutControls","")
        lInfo.Text = langFile.GetString("frmAboutControls", "ThisProgramIsMadeByGoVisualTeamForMoreInformationPleaseVisitOurSite").Replace("&NEWLINE&", vbNewLine)

        'SomeCommands = langFile.GetString("SomeCommands","")
        lCopyright.Text = langFile.GetString("SomeCommands", "Copyright")

        'Credits = langFile.GetString("Credits","")
        llCredits.Text = langFile.GetString("Credits", "Credits")
        llCreditsValue.Text = langFile.GetString("Credits", "Pierre")

        'Developers = langFile.GetString("Developers","")
        llDevelopers.Text = langFile.GetString("Developers", "Developers")
        llDevelopersValue.Text = langFile.GetString("Developers", "Jonas")

    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckLang()
        lVersion.Text = My.Application.Info.Version.ToString
    End Sub

    Private Sub pbIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbIcon.Click
        OpenURL.OpenURL("http://www.govisualteam.zxq.net/")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class