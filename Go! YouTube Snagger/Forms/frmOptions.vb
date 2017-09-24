Imports System.Security.Principal
Imports System.Globalization

Public Class frmOptions

    'SomeCommands - Code
    Dim pleaseChooseAFolder As String
    Dim pleaseChooseALanguagePack As String
    Dim theLanguagePackIsAlreadyAdded As String
    Dim _error As String
    Dim wouldYouLikeToSaveChanges As String

    Dim langFile As IniFile
    Dim langFile_Names As New List(Of String)
    Dim langFile_FileNames As New List(Of String)

    Private Declare Ansi Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As String) As Integer
    Private Const BCM_FIRST As Int32 = &H1600
    Private Const BCM_SETSHIELD As Int32 = (BCM_FIRST + &HC)

    Public Function IsAdmin() As Boolean
        Dim id As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim p As WindowsPrincipal = New WindowsPrincipal(id)
        Return p.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Sub AddShieldToButton(ByRef b As Button)
        b.FlatStyle = FlatStyle.System
        SendMessage(b.Handle, BCM_SETSHIELD, 0, &HFFFFFFFF)
    End Sub

    Private Function fixNativeName(ByVal name As String) As String
        If name.Length > 0 Then
            Return UCase(name(0)) & name.Remove(0, 1)
        Else
            Return name
        End If
    End Function

    Public Sub LoadLanguages()
        cbLang.Items.Clear()
        For Each lang As IO.FileInfo In New IO.DirectoryInfo(Application.StartupPath & "\languages").GetFiles("*.lang")
            cbLang.Items.Add(fixNativeName(New CultureInfo(New IniFile(lang.FullName).GetString("LanguagePackInfo", "Name")).NativeName))
            langFile_Names.Add(New IniFile(lang.FullName).GetString("LanguagePackInfo", "Name"))
            langFile_FileNames.Add(New IO.FileInfo(lang.FullName).Name)
        Next
        cbLang.SelectedIndex = My.Settings.language
    End Sub

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        pleaseChooseAFolder = langFile.GetString("SomeCommands", "PleaseChooseAFolder")
        pleaseChooseALanguagePack = langFile.GetString("SomeCommands", "PleaseChooseALanguagePack")
        theLanguagePackIsAlreadyAdded = langFile.GetString("SomeCommands", "TheLanguagePackIsAlreadyAdded")
        _error = langFile.GetString("SomeCommands", "Error")
        wouldYouLikeToSaveChanges = langFile.GetString("SomeCommands", "WouldYouLikeToSaveChanges")

        'frmOptions = langFile.GetString("frmOptions", "")
        Me.Text = langFile.GetString("frmOptions", "Text")

        'frmOptionsControls = langFile.GetString("frmOptionsControls", "")
        ibRestart.Message = langFile.GetString("frmOptionsControls", "RestartGoYouTubeSnaggerForThisChangeToTakeEffect")
        lSaveLocation.Text = langFile.GetString("frmOptionsControls", "StandardSavingLocation")
        cbAutoSave.Text = langFile.GetString("frmOptionsControls", "AutoSave")
        lLangPacks.Text = langFile.GetString("frmOptionsControls", "LanguagePacks")
        btnAdd.Text = langFile.GetString("frmOptionsControls", "AddLanguagePack")
        lUpdate.Text = langFile.GetString("frmOptionsControls", "Update")
        cbAutoUpdate.Text = langFile.GetString("frmOptionsControls", "CheckForUpdatesOnStartup")
        btnCheckForUpdates.Text = langFile.GetString("frmOptionsControls", "CheckForUpdates")
        btnRestart.Text = langFile.GetString("frmOptionsControls", "Restart")
        btnCancel.Text = langFile.GetString("frmOptionsControls", "Cancel")
        btnOK.Text = langFile.GetString("frmOptionsControls", "OK")

    End Sub

    Private Sub CheckAdmin()
        If Not IsAdmin() Then
            AddShieldToButton(btnCheckForUpdates)
        End If
    End Sub

    Public Function GetLangIndex(ByVal lang As String) As Integer

        Dim str As String = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\languages").IndexOf(lang & ".lang")

        If str.Contains("-") Then
            str = str.Replace("-", "")
        End If

        Return str

    End Function

    Private Sub frmOptions_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If My.Settings.standardSaveLocation = txtPath.Text Then
            If My.Settings.autoSave = cbAutoSave.Checked Then
                If My.Settings.language = cbLang.SelectedIndex Then
                    If My.Settings.autoUpdate = cbAutoUpdate.Checked Then
                        e.Cancel = False
                    Else
                        Dim result As MessageBox.MessageDialogResults = MessageBox.ShowMessageBox(wouldYouLikeToSaveChanges, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Exlamation)
                        If result = MessageBox.MessageDialogResults.Yes Then
                            My.Settings.standardSaveLocation = txtPath.Text
                            My.Settings.autoSave = cbAutoSave.Checked
                            My.Settings.language = cbLang.SelectedIndex
                            My.Settings.autoUpdate = cbAutoUpdate.Checked
                        End If
                        e.Cancel = True
                    End If
                Else
                    Dim result As MessageBox.MessageDialogResults = MessageBox.ShowMessageBox(wouldYouLikeToSaveChanges, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Exlamation)
                    If result = MessageBox.MessageDialogResults.Yes Then
                        My.Settings.standardSaveLocation = txtPath.Text
                        My.Settings.autoSave = cbAutoSave.Checked
                        My.Settings.language = cbLang.SelectedIndex
                        My.Settings.autoUpdate = cbAutoUpdate.Checked
                    End If
                    e.Cancel = True
                End If
            Else
                Dim result As MessageBox.MessageDialogResults = MessageBox.ShowMessageBox(wouldYouLikeToSaveChanges, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Exlamation)
                If result = MessageBox.MessageDialogResults.Yes Then
                    My.Settings.standardSaveLocation = txtPath.Text
                    My.Settings.autoSave = cbAutoSave.Checked
                    My.Settings.language = cbLang.SelectedIndex
                    My.Settings.autoUpdate = cbAutoUpdate.Checked
                End If
                e.Cancel = True
            End If
        Else
            Dim result As MessageBox.MessageDialogResults = MessageBox.ShowMessageBox(wouldYouLikeToSaveChanges, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Exlamation)
            If result = MessageBox.MessageDialogResults.Yes Then
                My.Settings.standardSaveLocation = txtPath.Text
                My.Settings.autoSave = cbAutoSave.Checked
                My.Settings.language = cbLang.SelectedIndex
                My.Settings.autoUpdate = cbAutoUpdate.Checked
            End If
            e.Cancel = True
        End If
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.standardSaveLocation = "" Then My.Settings.standardSaveLocation = My.Computer.FileSystem.SpecialDirectories.Desktop

        CheckLang()
        CheckAdmin()

        Me.Size = New Size(635, 208)

        txtPath.Text = My.Settings.standardSaveLocation
        txtPath.Icon = If(My.Settings.standardSaveLocation <> "", Shell32.GetIconFromFolder(My.Settings.standardSaveLocation).ToBitmap, My.Resources.folder)
        cbAutoSave.Checked = My.Settings.autoSave
        cbAutoUpdate.Checked = My.Settings.autoUpdate

        LoadLanguages()

    End Sub

    Private Sub ibRestart_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibRestart.Closed
        Me.Size = New Size(600, 208)
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.SelectedPath = folderDlg.SelectedPath
        folderDlg.ShowNewFolderButton = True
        folderDlg.Description = pleaseChooseAFolder
        If folderDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPath.Text = folderDlg.SelectedPath
            txtPath.Icon = If(folderDlg.SelectedPath <> "", Shell32.GetIconFromFolder(folderDlg.SelectedPath).ToBitmap, My.Resources.folder)
        End If
    End Sub

    Private Sub cbLang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLang.SelectedIndexChanged
        ibRestart.Visible = cbLang.SelectedIndex <> My.Settings.language
        btnRestart.Visible = cbLang.SelectedIndex <> My.Settings.language
        If ibRestart.Visible Then
            Me.Size = New Size(635, 230)
        Else
            Me.Size = New Size(635, 208)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim openDlg As New OpenFileDialog

        openDlg.Title = pleaseChooseALanguagePack
        openDlg.Filter = Shell32.GetFileType(".lang") & "|*.lang"
        openDlg.Multiselect = False

        If openDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim langFile As New IniFile(openDlg.FileName)
            If langFile.GetString("IsGoYouTubeSnaggerLangFile", "TrueOrFalse") = "True" Then
                If Not langFile_FileNames.Contains(New IO.FileInfo(openDlg.FileName).Name) Then
                    If Not langFile_Names.Contains(langFile.GetString("LanguagePackInfo", "Name")) Then

                        My.Computer.FileSystem.CopyFile(openDlg.FileName, Application.StartupPath & "\languages\" & New IO.FileInfo(openDlg.FileName).Name)

                        cbLang.Items.Add(IO.Path.GetFileNameWithoutExtension(openDlg.FileName))
                        If cbLang.Items.IndexOf(IO.Path.GetFileNameWithoutExtension(openDlg.FileName)) >= 1 Then
                            My.Settings.language += 1
                        End If

                        LoadLanguages()

                    Else
                        MessageBox.ShowMessageBox(theLanguagePackIsAlreadyAdded, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation, _error)
                    End If
                Else
                    MessageBox.ShowMessageBox(theLanguagePackIsAlreadyAdded, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation, _error)
                End If
            End If
        End If
    End Sub

    Private Sub btnCheckForUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckForUpdates.Click
        Dim updaterPath As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "UpdaterPath", "")
        If updaterPath <> "" Then
            Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
            startInfo.UseShellExecute = True
            startInfo.Arguments = "-" & My.Settings.language
            startInfo.WorkingDirectory = New IO.FileInfo(updaterPath).Directory.FullName
            startInfo.FileName = updaterPath
            startInfo.Verb = "runas"
            Try
                Process.Start(startInfo)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click
        My.Settings.standardSaveLocation = txtPath.Text
        My.Settings.autoSave = cbAutoSave.Checked
        My.Settings.language = cbLang.SelectedIndex
        My.Settings.autoUpdate = cbAutoUpdate.Checked
        My.Settings.Save()
        frmMain.doRestart = True
        Application.Exit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        My.Settings.standardSaveLocation = txtPath.Text
        My.Settings.autoSave = cbAutoSave.Checked
        My.Settings.language = cbLang.SelectedIndex
        My.Settings.autoUpdate = cbAutoUpdate.Checked
        Me.Close()
    End Sub
End Class