Imports System.Collections
Imports System.Globalization
Imports System.Resources

Public Class frmSelectLanguage

    Dim resourceSet As ResourceSet
    Dim fileNames As New List(Of String)

    Dim langFile As IniFile

    Private Sub checkLang()
        langFile = New IniFile(fileNames(cbLanguages.SelectedIndex))
        loadLang()
    End Sub

    Private Sub loadLang()

        'frmSelectLanguage = langFile.GetString("frmSelectLanguage", "")
        Me.Text = langFile.GetString("frmSelectLanguage", "Text")

        'frmSelectLanguageControls = langFile.GetString("frmSelectLanguageControls", "")
        lChoose.Text = langFile.GetString("frmSelectLanguageControls", "PleaseChooseALanguage")
        btnOK.Text = langFile.GetString("frmSelectLanguageControls", "OK")

    End Sub

    Private Function fixNativeName(ByVal name As String) As String
        If name.Length > 0 Then
            Return UCase(name(0)) & name.Remove(0, 1)
        Else
            Return name
        End If
    End Function

    Private Sub loadLangs()
        resourceSet = My.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, True, True)
        For Each langName As String In My.Settings.languageIDs
            Dim fn As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & IO.Path.GetFileNameWithoutExtension(IO.Path.GetRandomFileName) & ".lang"
            My.Computer.FileSystem.WriteAllBytes(fn, resourceSet.GetObject(langName.Replace("-", "_")), True)
            fileNames.Add(fn)
            cbLanguages.Items.Add(fixNativeName(New CultureInfo(langName).NativeName))
        Next
        selectLang()
    End Sub

    Private Sub selectLang()
        Dim languageName As String = CultureInfo.InstalledUICulture.Name.ToLower
        For Each f As String In fileNames
            If New IniFile(f).GetString("LanguagePackInfo", "Name") = languageName Then
                cbLanguages.SelectedIndex = fileNames.IndexOf(f)
                Exit For
            End If
            Application.DoEvents()
        Next
        If cbLanguages.SelectedIndex = -1 Then
            cbLanguages.SelectedItem = My.Settings.standardLanguage
        End If
    End Sub

    Private Sub frmSelectLanguage_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        For Each f As String In fileNames
            My.Computer.FileSystem.DeleteFile(f, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Application.DoEvents()
        Next
    End Sub

    Private Sub frmSelectLanguage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadLangs()
    End Sub

    Private Sub cbLanguages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLanguages.SelectedIndexChanged
        checkLang()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim dlg As New frmInstaller(fileNames(cbLanguages.SelectedIndex), cbLanguages.SelectedIndex)
        dlg.Show()
        Me.Close()
    End Sub
End Class