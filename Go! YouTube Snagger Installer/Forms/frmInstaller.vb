Imports System.IO
Imports IWshRuntimeLibrary
Imports Microsoft.Win32

#Region " READ ME "

'Thanks to the following.
'   Developers
' Jonas T - (Go! Visual Team)
'   Credits
' Pierre Bondoerffer (Xylem Studios)

#End Region

Public Class frmInstaller

    Dim doDeleteMe As Boolean = False
    Dim isAllowedToRun As Boolean = False
    Dim applicationPath As String

    Dim installerPath As String
    Dim delText As String
    Dim progVersion As String = "1.5.1.62"

    Dim stopInstallation As Boolean = False
    Dim errorResult As MessageBox.MessageDialogResults

    Dim messageBox As New MessageBox

    'SomeCommands - Code
    Dim pleaseChooseAFolderWhereYouWantToLocateTheFilesOfTheInstallation As String
    Dim goYouTubeSnaggerHasBeenSuccessfullyInstalledOnYourComputer As String
    Dim goYouTubeSnaggerHasBeenSuccessfullyUninstalledOnYourComputer As String
    Dim goYouTubeSnaggerHasBeenSuccessfullyRepaired As String
    Dim success As String
    Dim goYouTubeSnaggerIsAlreadyRunning As String

    'frmInstallerControls - Code
    Dim _close As String

    Dim m_index As Integer
    Dim langFile As IniFile

    Enum PanelModes

        pStart = 1

        pInstalled = 2

        pUninstall = 3

        pRepair = 4

    End Enum

    Public Sub New(ByVal langpackFileName As String, ByVal index As Integer)
        InitializeComponent()
        langFile = New IniFile(langpackFileName)
        m_index = index
        My.Settings.language = index
        checkLang()
    End Sub

    Private ReadOnly Property GoYouTubeSnaggerIsInstalledOnCurrentMachine() As Boolean
        Get
            Return Not My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", False) Is Nothing
        End Get
    End Property

#Region " FUNCTIONS/SUBS "

    Private Function FixFileNameForBatch(ByVal fileName As String) As String
        Dim resultString As String = ""
        Dim filename_Splitted As String() = Split(fileName, "\")
        For Each p As String In filename_Splitted
            If p.Contains(" ") Then
                resultString &= """" & p & IIf(Array.IndexOf(filename_Splitted, p) <> filename_Splitted.Count - 1, """\", """")
            Else
                resultString &= p & IIf(Array.IndexOf(filename_Splitted, p) <> filename_Splitted.Count - 1, "\", "")
            End If
        Next
        Return resultString
    End Function

    Private Sub LoadSettings()

        'Check if Go! YouTube Snagger is installated or not...
        If GoYouTubeSnaggerIsInstalledOnCurrentMachine Then
            SelectPanel(PanelModes.pInstalled)
        Else
            SelectPanel(PanelModes.pStart)
            'Load standard installation folder...
            txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\Go! Visual Team\Go! YouTube Snagger"
        End If

    End Sub

    Private Function GetStartMenuDir() As String

        If Environment.OSVersion.Version.Major > 5 Then
            Dim sysDir As String = Environment.SystemDirectory.Replace("Windows\system32", "")
            Return sysDir & "ProgramData\Microsoft\Windows\Start Menu\Programs\"
        Else
            Return Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\"
        End If

    End Function

    Private Sub SelectPanel(ByVal PanelMode As PanelModes)

        If PanelMode = PanelModes.pStart Then

            'Set the visibilities...
            pStart.Visible = True
            pInstalled.Visible = False
            pUninstall.Visible = False
            pRepair.Visible = False

            'Bring the panel to front...
            pStart.BringToFront()

        ElseIf PanelMode = PanelModes.pInstalled Then

            'Set the visibilities...
            pStart.Visible = True
            pInstalled.Visible = True
            pUninstall.Visible = False
            pRepair.Visible = False

            'Bring the panel to front...
            pStart.BringToFront()

        ElseIf PanelMode = PanelModes.pUninstall Then

            'Set the visibilities...
            pStart.Visible = True
            pInstalled.Visible = True
            pUninstall.Visible = True
            pRepair.Visible = False

            'Bring the panel to front...
            pStart.BringToFront()

        ElseIf PanelMode = PanelModes.pRepair Then

            'Set the visibilities...
            pStart.Visible = True
            pInstalled.Visible = True
            pUninstall.Visible = True
            pRepair.Visible = True

            'Bring the panel to front...
            pStart.BringToFront()

        End If

    End Sub

    Private Sub ChangeEnabilityOfButtons(ByVal Enabled As Boolean)
        txtPath.Enabled = Enabled
        btnChoose.Enabled = Enabled
        cbShortcut.Enabled = Enabled
        cbRun.Enabled = Enabled
        btnClose.Enabled = Enabled
    End Sub

    Private Sub CreateShortcut(ByVal SaveTo As String, ByVal TargetPath As String, ByVal Name As String, ByVal WorkingDir As String, ByVal IconFile As String, ByVal IconIndex As Integer)
        Dim shortCut As IWshShortcut = DirectCast(New IWshShell_Class().CreateShortcut(SaveTo), IWshShortcut)
        shortCut.TargetPath = TargetPath
        shortCut.WindowStyle = 1
        shortCut.Description = Name
        shortCut.WorkingDirectory = WorkingDir
        shortCut.IconLocation = IconFile & ", " & IconIndex
        shortCut.Save()
    End Sub

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

    Private Sub checkLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        pleaseChooseAFolderWhereYouWantToLocateTheFilesOfTheInstallation = langFile.GetString("SomeCommands", "PleaseChooseAFolderWhereYouWantToLocateTheFilesOfTheInstallation")
        goYouTubeSnaggerHasBeenSuccessfullyInstalledOnYourComputer = langFile.GetString("SomeCommands", "GoYouTubeSnaggerHasBeenSuccessfullyInstalledOnYourComputer")
        goYouTubeSnaggerHasBeenSuccessfullyUninstalledOnYourComputer = langFile.GetString("SomeCommands", "GoYouTubeSnaggerHasBeenSuccessfullyUninstalledOnYourComputer")
        goYouTubeSnaggerHasBeenSuccessfullyRepaired = langFile.GetString("SomeCommands", "GoYouTubeSnaggerHasBeenSuccessfullyRepaired")
        success = langFile.GetString("SomeCommands", "Success")
        goYouTubeSnaggerIsAlreadyRunning = langFile.GetString("SomeCommands", "GoYouTubeSnaggerIsAlreadyRunning")

        'frmInstaller - langFile.GetString("frmInstaller", "")
        Me.Text = langFile.GetString("frmInstaller", "Text")

        'frmInstallerControls - langFile.GetString("frmInstallerControls", "")
        lWelcome.Text = langFile.GetString("frmInstallerControls", "WelcomeToGoYouTubeSnaggerInstallation")
        lChooseDirectory.Text = langFile.GetString("frmInstallerControls", "ChooseAFolderWhereYouWantGoYouTubeSnaggerToBeInstalled")
        cbShortcut.Text = langFile.GetString("frmInstallerControls", "CreateAShortcutOnDesktop")
        lInstallationProgress.Text = langFile.GetString("frmInstallerControls", "InstallationProgress")
        cbRun.Text = langFile.GetString("frmInstallerControls", "RunGoYouTubeSnaggerWhenTheInstallationFinishes")
        btnStartOrStopInstallation.Text = langFile.GetString("frmInstallerControls", "StartInstallation")
        _close = langFile.GetString("frmInstallerControls", "Close")
        btnClose.Text = _close
        lInstalled.Text = langFile.GetString("frmInstallerControls", "GoYouTubeSnaggerIsAlreadyInstalledOnThisComputer")
        btnUninstall.Text = langFile.GetString("frmInstallerControls", "Uninstall")
        btnRepair.Text = langFile.GetString("frmInstallerControls", "Repair")
        btnClose1.Text = _close
        lUninstallProgress.Text = langFile.GetString("frmInstallerControls", "UninstallProgress")
        btnClose2.Text = _close
        lRepairProgess.Text = langFile.GetString("frmInstallerControls", "RepairProgress")
        btnClose3.Text = _close

        '''' - For MessageBox - ''''
        messageBox.messageBoxButtonsInfo.DoNotShowThisMessageBoxAgain = langFile.GetString("MessageBoxCommands", "DoNotShowThisMessageBoxAgain")
        messageBox.messageBoxButtonsInfo.OK = langFile.GetString("MessageBoxCommands", "OK")
        messageBox.messageBoxButtonsInfo.Cancel = langFile.GetString("MessageBoxCommands", "Cancel")
        messageBox.messageBoxButtonsInfo.Yes = langFile.GetString("MessageBoxCommands", "Yes")
        messageBox.messageBoxButtonsInfo.No = langFile.GetString("MessageBoxCommands", "No")
        messageBox.messageBoxButtonsInfo.Help = langFile.GetString("MessageBoxCommands", "Help")
        messageBox.messageBoxButtonsInfo.Retry = langFile.GetString("MessageBoxCommands", "Retry")
        messageBox.messageBoxButtonsInfo.Save = langFile.GetString("MessageBoxCommands", "Save")
        messageBox.messageBoxButtonsInfo.DoNotSave = langFile.GetString("MessageBoxCommands", "DoNotSave")

    End Sub

#Region " FOR INSTALLER "

    Private Sub DeleteMe()

        delText = "echo off" & vbNewLine & ":DELETE" & vbNewLine & "RMDIR " & FixFileNameForBatch(New DirectoryInfo(installerPath).Parent.FullName) & " /s /q" & vbNewLine & "if exist " & FixFileNameForBatch(installerPath) & " goto DELETE" & vbNewLine & "del %PATH%"

        'Create and set the temporary filename...
        Dim tempPath As String = Path.GetTempFileName
        My.Computer.FileSystem.DeleteFile(tempPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        tempPath = My.Computer.FileSystem.GetFileInfo(tempPath).Directory.FullName & "\" & IO.Path.GetFileNameWithoutExtension(tempPath) & ".bat"
        My.Computer.FileSystem.WriteAllText(tempPath, delText.Replace("%PATH%", tempPath), True)

        'Create and run the process...
        Dim p As New Process()
        p.StartInfo.FileName = tempPath
        p.StartInfo.Verb = "runas"
        p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
        p.StartInfo.UseShellExecute = False
        p.Start()

    End Sub

    Private Sub AssocateYSL(ByVal iconPath As String, ByVal appPath As String)
        My.Computer.Registry.ClassesRoot.CreateSubKey(".ysl").SetValue("", "Go! YouTube Snagger List", Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.ClassesRoot.CreateSubKey("Go! YouTube Snagger List\shell\open\command").SetValue("", appPath & " ""%1"" ", Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.ClassesRoot.CreateSubKey("Go! YouTube Snagger List\DefaultIcon").SetValue("", iconPath)
        Shell32.RefreshRegistry()
    End Sub

    Private Function IconToByte(ByVal icon As Icon) As Byte()
        Dim ms As New IO.MemoryStream() : icon.Save(ms)
        Return ms.ToArray
    End Function

    Private Function RepairYS() As Boolean
        applicationPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallPath", "")
        GoTo doWork
doWork:
        If CheckProcess("Go! YouTube Snagger", ".exe", My.Computer.FileSystem.GetFileInfo(applicationPath).Directory.FullName) Then
            errorResult = messageBox.ShowDialog(goYouTubeSnaggerIsAlreadyRunning, messageBox.MessageButtons.RetryCancel, messageBox.MessageIcons.Exlamation)
            If errorResult = messageBox.MessageDialogResults.Retry Then
                GoTo doWork
            Else
                Return False
            End If
        Else
            Dim InstallDir As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallLocation", "")
            Dim Shortcut As Boolean = Convert.ToBoolean(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Shortcut", 1))

            '*****************UNINSTALL_BEGIN*******************
            Dim RootFolder As String = DirectCast(My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", False).GetValue("InstallLocation"), String)
            'Delete the files in the root folder...
            For Each f As String In My.Computer.FileSystem.GetFiles(RootFolder)
                Dim info As New FileInfo(f)
                info.Delete()
            Next
            gpbRepairProgress.Value = 5
            'Delete folder's in the root folder, without the installation folder...
            For Each fo As DirectoryInfo In New DirectoryInfo(RootFolder).GetDirectories()
                If Not fo.Name = "installer" Then
                    fo.Delete(True)
                End If
            Next
            gpbRepairProgress.Value = 10
            'Delete all the added shortcuts and startmenu folder...
            If Shortcut Then
                If My.Computer.FileSystem.FileExists(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Go! YouTube Snagger.lnk") Then
                    My.Computer.FileSystem.DeleteFile(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Go! YouTube Snagger.lnk")
                End If
            End If
            gpbRepairProgress.Value = 15
            If My.Computer.FileSystem.FileExists(GetStartMenuDir() & "Go! YouTube Snagger.lnk") Then
                My.Computer.FileSystem.DeleteFile(GetStartMenuDir() & "Go! YouTube Snagger.lnk")
            End If
            gpbRepairProgress.Value = 20
            If Directory.Exists(GetStartMenuDir() & "Go! Visual Team\Go! YouTube Snagger") Then
                My.Computer.FileSystem.DeleteDirectory(GetStartMenuDir() & "Go! Visual Team\Go! YouTube Snagger", FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
            gpbRepairProgress.Value = 25
            'Delete created registy files...
            My.Computer.Registry.LocalMachine.DeleteSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger")
            gpbRepairProgress.Value = 30
            My.Computer.Registry.LocalMachine.DeleteSubKey("SOFTWARE\Go! YouTube Snagger\Capabilities")
            gpbRepairProgress.Value = 35
            My.Computer.Registry.LocalMachine.DeleteSubKey("SOFTWARE\Go! YouTube Snagger")
            gpbRepairProgress.Value = 40
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\RegisteredApplications", True).DeleteValue("Go! YouTube Snagger")
            gpbRepairProgress.Value = 45
            Try
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", True).DeleteValue(RootFolder & "\Go! YouTube Snagger.exe")
            Catch ex As Exception
            End Try
            'The installation file will be deleted if the user wanted to uninstall it, but if the user wanted to repair it then not delete it...
            gpbRepairProgress.Value = 50
            '*****************UNINSTALL_END*******************
            '
            '*****************INSTALL_BEGIN*******************
            If stopInstallation Then
                gpbRepairProgress.Value = 100
                UninstallYS()
                Return False
            Else
                'Create the installation folder...
                My.Computer.FileSystem.CreateDirectory(InstallDir)
                gpbRepairProgress.Value = 55
                'Create all needed folders...
                My.Computer.FileSystem.CreateDirectory(InstallDir & "\installer")
                My.Computer.FileSystem.CreateDirectory(InstallDir & "\languages")
                My.Computer.FileSystem.CreateDirectory(InstallDir & "\resources")
                Dim languagesDir As New DirectoryInfo(InstallDir & "\languages")
                languagesDir.Attributes = FileAttributes.Hidden
                Dim resourcesDir As New DirectoryInfo(InstallDir & "\resources")
                resourcesDir.Attributes = FileAttributes.Hidden
                gpbRepairProgress.Value = 60
                'Extract all files in the installation folder.
                '*****************BEGIN*******************
                'EXE-files...
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Go! YouTube Snagger.exe", My.Resources.Go__YouTube_Snagger, False)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Go! YouTube Snagger Updater.exe", My.Resources.Go__YouTube_Snagger_Updater, False)
                gpbRepairProgress.Value = 65
                'TXT-files...
                My.Computer.FileSystem.WriteAllText(InstallDir & "\Go! YouTube Snagger.exe.config", My.Resources.Go__YouTube_Snagger_exe, False)
                My.Computer.FileSystem.WriteAllText(InstallDir & "\Go! YouTube Snagger Updater.exe.config", My.Resources.Go__YouTube_Snagger_Updater_exe, False)
                'DLL-files...
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\AxInterop.ShockwaveFlashObjects.dll", My.Resources.AxInterop_ShockwaveFlashObjects, True)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Google.GData.Client.dll", My.Resources.Google_GData_Client, True)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Google.GData.Extensions.dll", My.Resources.Google_GData_Extensions, True)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Google.GData.YouTube.dll", My.Resources.Google_GData_YouTube, True)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Interop.ShockwaveFlashObjects.dll", My.Resources.Interop_ShockwaveFlashObjects, True)
                gpbRepairProgress.Value = 70
                '***********************************************
                'languages's files....
                '***********************************************
                'LANG-files...
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\languages\nb-no.lang", My.Resources.nb_no, False)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\languages\fr-fr.lang", My.Resources.fr_fr, False)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\languages\es-es.lang", My.Resources.es_es, False)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\languages\en-us.lang", My.Resources.en_us, False)
                '***********************************************
                'resources' files....
                '***********************************************
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\resources\ysl.ico", IconToByte(My.Resources.ysl), False)
                gpbRepairProgress.Value = 85
                '*****************END*******************
                Application.DoEvents()
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Go! YouTube Snagger\Capabilities", "ApplicationDescription", "")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Go! YouTube Snagger\Capabilities", "ApplicationIcon", InstallDir & "\Go! YouTube Snagger.exe,0")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Go! YouTube Snagger\Capabilities", "ApplicationName", "Go! YouTube Snagger")
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\RegisteredApplications", True).SetValue("Go! YouTube Snagger", "SORTWARE\Go! YouTube Snagger\Capabilities")
                Try
                    My.Computer.Registry.CurrentUser.OpenSubKey("Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", True).SetValue(InstallDir & "\Go! YouTube Snagger.exe", "Go! YouTube Snagger")
                Catch ex As Exception
                End Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "DisplayIcon", InstallDir & "\Go! YouTube Snagger.exe")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "DisplayName", "Go! YouTube Snagger")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "DisplayVersion", progVersion)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallerPath", InstallDir & "\installer")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallPath", InstallDir & "\Go! YouTube Snagger.exe")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallDate", Date.Today)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallLocation", InstallDir)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "EstimatedSize", My.Resources.Go__YouTube_Snagger.LongLength / 1024, Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "NoModify", 0, Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "NoRepair", 0, Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "HelpLink", "http://govisualteam.zxq.net/")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Publisher", "Go! Visual Team")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "UninstallString", InstallDir & "\installer\Go! YouTube Snagger Installer.exe")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "URLInfoAbout", "http://govisualteam.zxq.net/")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Version", progVersion)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Shortcut", Convert.ToInt32(Shortcut), Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "UpdaterPath", InstallDir & "\Go! YouTube Snagger Updater.exe")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "YSLIconPath", InstallDir & "\resources\ysl.ico")
                AssocateYSL(InstallDir & "\resources\ysl.ico", InstallDir & "\Go! YouTube Snagger.exe")
                gpbRepairProgress.Value = 90
                Application.DoEvents()
                '***********************************************
                'Add shortcut's...
                '***********************************************
                If cbRun.Checked Then
                    CreateShortcut(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Go! YouTube Snagger.lnk", InstallDir & "\Go! YouTube Snagger.exe", "Go! YouTube Snagger", InstallDir & "\", InstallDir & "\Go! YouTube Snagger.exe", 0)
                End If
                gpbRepairProgress.Value = 95
                Application.DoEvents()
                '***********************************************
                'Add shortcut's to startmenu...
                '***********************************************
                CreateShortcut(GetStartMenuDir() & "Go! YouTube Snagger.lnk", InstallDir & "\Go! YouTube Snagger.exe", "Go! YouTube Snagger", InstallDir & "\", InstallDir & "\Go! YouTube Snagger.exe", 0)
                My.Computer.FileSystem.CreateDirectory(GetStartMenuDir() & "Go! Visual Team")
                My.Computer.FileSystem.CreateDirectory(GetStartMenuDir() & "Go! Visual Team\Go! YouTube Snagger")
                CreateShortcut(GetStartMenuDir() & "Go! Visual Team\Go! YouTube Snagger\Go! YouTube Snagger.lnk", InstallDir & "\Go! YouTube Snagger.exe", "Go! YouTube Snagger", InstallDir & "\", InstallDir & "\Go! YouTube Snagger.exe", 0)
                gpbRepairProgress.Value = 100
                Application.DoEvents()
                Return True
            End If
        End If
        Return True
    End Function

    Private Function UninstallYS() As Boolean
        applicationPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallPath", "")
        installerPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallerPath", "")
        GoTo doWork
doWork:
        If CheckProcess("Go! YouTube Snagger", ".exe", My.Computer.FileSystem.GetFileInfo(applicationPath).Directory.FullName) Then
            errorResult = messageBox.ShowDialog(goYouTubeSnaggerIsAlreadyRunning, messageBox.MessageButtons.RetryCancel, messageBox.MessageIcons.Exlamation)
            If errorResult = messageBox.MessageDialogResults.Retry Then
                GoTo doWork
            Else
                Return False
            End If
        Else
            Dim Shortcut As Boolean = Convert.ToBoolean(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Shortcut", 1))

            Dim RootFolder As String = DirectCast(My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", False).GetValue("InstallLocation"), String)
            'Delete the files in the root folder...
            For Each f As String In My.Computer.FileSystem.GetFiles(RootFolder)
                Dim info As New FileInfo(f)
                info.Delete()
            Next
            gpbUninstallationProgress.Value = 10
            'Delete folder's in the root folder, without the installation folder...
            For Each fo As DirectoryInfo In New DirectoryInfo(RootFolder).GetDirectories()
                If Not fo.Name = "installer" Then
                    fo.Delete(True)
                End If
            Next
            gpbUninstallationProgress.Value = 20
            'Delete all the added shortcuts and startmenu folder...
            If Shortcut Then
                If My.Computer.FileSystem.FileExists(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Go! YouTube Snagger.lnk") Then
                    My.Computer.FileSystem.DeleteFile(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Go! YouTube Snagger.lnk")
                End If
            End If
            gpbUninstallationProgress.Value = 30
            If My.Computer.FileSystem.FileExists(GetStartMenuDir() & "Go! YouTube Snagger.lnk") Then
                My.Computer.FileSystem.DeleteFile(GetStartMenuDir() & "Go! YouTube Snagger.lnk")
            End If
            gpbUninstallationProgress.Value = 40
            If Directory.Exists(GetStartMenuDir() & "Go! Visual Team\Go! YouTube Snagger") Then
                My.Computer.FileSystem.DeleteDirectory(GetStartMenuDir() & "Go! Visual Team\Go! YouTube Snagger", FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
            gpbUninstallationProgress.Value = 50
            'Delete created registy files...
            My.Computer.Registry.LocalMachine.DeleteSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger")
            gpbUninstallationProgress.Value = 60
            My.Computer.Registry.LocalMachine.DeleteSubKey("SOFTWARE\Go! YouTube Snagger\Capabilities")
            gpbUninstallationProgress.Value = 70
            My.Computer.Registry.LocalMachine.DeleteSubKey("SOFTWARE\Go! YouTube Snagger")
            gpbUninstallationProgress.Value = 80
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\RegisteredApplications", True).DeleteValue("Go! YouTube Snagger")
            gpbUninstallationProgress.Value = 90
            Try
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", True).DeleteValue(RootFolder & "\Go! YouTube Snagger.exe")
            Catch ex As Exception
            End Try
            'The installation file will be deleted if the user wanted to uninstall it, but if the user wanted to repair it then not delete it...
            gpbUninstallationProgress.Value = 100
        End If
        Return True
    End Function

    Private Function StopInstallationOfYS() As Boolean
        stopInstallation = True
        Return stopInstallation
    End Function

    Private Function InstallYS() As Boolean
        Dim InstallDir As String = txtPath.Text
        applicationPath = InstallDir & "\Go! YouTube Snagger.exe"
        GoTo doWork
doWork:
        If CheckProcess("Go! YouTube Snagger", ".exe", My.Computer.FileSystem.GetFileInfo(applicationPath).Directory.FullName) Then
            errorResult = messageBox.ShowDialog(goYouTubeSnaggerIsAlreadyRunning, messageBox.MessageButtons.RetryCancel, messageBox.MessageIcons.Exlamation)
            If errorResult = messageBox.MessageDialogResults.Retry Then
                GoTo doWork
            Else
                Return False
            End If
        Else
            If stopInstallation Then
                gpbInstallationProgress.Value = 100
                UninstallYS()
                Return False
            Else
                'Create the installation folder...
                My.Computer.FileSystem.CreateDirectory(InstallDir)
                gpbInstallationProgress.Value = 10
                'Create all needed folders...
                My.Computer.FileSystem.CreateDirectory(InstallDir & "\installer")
                My.Computer.FileSystem.CreateDirectory(InstallDir & "\languages")
                My.Computer.FileSystem.CreateDirectory(InstallDir & "\resources")
                Dim languagesDir As New DirectoryInfo(InstallDir & "\languages")
                languagesDir.Attributes = FileAttributes.Hidden
                Dim resourcesDir As New DirectoryInfo(InstallDir & "\resources")
                resourcesDir.Attributes = FileAttributes.Hidden
                gpbInstallationProgress.Value = 20
                'Extract all files in the installation folder.
                '*****************BEGIN*******************
                'EXE-files...
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Go! YouTube Snagger.exe", My.Resources.Go__YouTube_Snagger, False)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Go! YouTube Snagger Updater.exe", My.Resources.Go__YouTube_Snagger_Updater, False)
                gpbInstallationProgress.Value = 30
                'TXT-files...
                My.Computer.FileSystem.WriteAllText(InstallDir & "\Go! YouTube Snagger.exe.config", My.Resources.Go__YouTube_Snagger_exe, False)
                My.Computer.FileSystem.WriteAllText(InstallDir & "\Go! YouTube Snagger Updater.exe.config", My.Resources.Go__YouTube_Snagger_Updater_exe, False)
                'DLL-files...
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\AxInterop.ShockwaveFlashObjects.dll", My.Resources.AxInterop_ShockwaveFlashObjects, True)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Google.GData.Client.dll", My.Resources.Google_GData_Client, True)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Google.GData.Extensions.dll", My.Resources.Google_GData_Extensions, True)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Google.GData.YouTube.dll", My.Resources.Google_GData_YouTube, True)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\Interop.ShockwaveFlashObjects.dll", My.Resources.Interop_ShockwaveFlashObjects, True)
                gpbInstallationProgress.Value = 40
                '***********************************************
                'Installer's files....
                '***********************************************
                'EXE-files...
                My.Computer.FileSystem.CopyFile(Application.ExecutablePath, InstallDir & "\installer\Go! YouTube Snagger Installer.exe", True)
                gpbInstallationProgress.Value = 50
                'DLL-files...
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\installer\Interop.IWshRuntimeLibrary.dll", My.Resources.Interop_IWshRuntimeLibrary, True)
                gpbInstallationProgress.Value = 60
                'TXT-files...
                My.Computer.FileSystem.CopyFile(Application.StartupPath & "\Go! YouTube Snagger Installer.exe.config", InstallDir & "\installer\Go! YouTube Snagger Installer.exe.config", True)
                gpbInstallationProgress.Value = 65
                '***********************************************
                'languages's files....
                '***********************************************
                'LANG-files...
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\languages\nb-no.lang", My.Resources.nb_no, False)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\languages\fr-fr.lang", My.Resources.fr_fr, False)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\languages\es-es.lang", My.Resources.es_es, False)
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\languages\en-us.lang", My.Resources.en_us, False)
                '***********************************************
                'resources' files....
                '***********************************************
                My.Computer.FileSystem.WriteAllBytes(InstallDir & "\resources\ysl.ico", IconToByte(My.Resources.ysl), False)
                gpbInstallationProgress.Value = 70
                '*****************END*******************
                Application.DoEvents()
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Go! YouTube Snagger\Capabilities", "ApplicationDescription", "")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Go! YouTube Snagger\Capabilities", "ApplicationIcon", InstallDir & "\Go! YouTube Snagger.exe,0")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Go! YouTube Snagger\Capabilities", "ApplicationName", "Go! YouTube Snagger")
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\RegisteredApplications", True).SetValue("Go! YouTube Snagger", "SORTWARE\Go! YouTube Snagger\Capabilities")
                Try
                    My.Computer.Registry.CurrentUser.OpenSubKey("Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", True).SetValue(InstallDir & "\Go! YouTube Snagger.exe", "Go! YouTube Snagger")
                Catch ex As Exception
                End Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "DisplayIcon", InstallDir & "\Go! YouTube Snagger.exe")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "DisplayName", "Go! YouTube Snagger")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "DisplayVersion", progVersion)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallerPath", InstallDir & "\installer")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallPath", InstallDir & "\Go! YouTube Snagger.exe")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallDate", Date.Now)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "InstallLocation", InstallDir)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "EstimatedSize", My.Resources.Go__YouTube_Snagger.LongLength / 1024, Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "NoModify", 0, Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "NoRepair", 0, Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "HelpLink", "http://govisualteam.zxq.net/")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Publisher", "Go! Visual Team")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "UninstallString", InstallDir & "\installer\Go! YouTube Snagger Installer.exe")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "URLInfoAbout", "http://govisualteam.zxq.net/")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Version", progVersion)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "Shortcut", Convert.ToInt32(cbShortcut.Checked), Microsoft.Win32.RegistryValueKind.DWord)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "UpdaterPath", InstallDir & "\Go! YouTube Snagger Updater.exe")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Go! YouTube Snagger", "YSLIconPath", InstallDir & "\resources\ysl.ico")
                AssocateYSL(InstallDir & "\resources\ysl.ico", InstallDir & "\Go! YouTube Snagger.exe")
                gpbInstallationProgress.Value = 80
                Application.DoEvents()
                '***********************************************
                'Add shortcut's...
                '***********************************************
                If cbRun.Checked Then
                    CreateShortcut(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Go! YouTube Snagger.lnk", InstallDir & "\Go! YouTube Snagger.exe", "Go! YouTube Snagger", InstallDir & "\", InstallDir & "\Go! YouTube Snagger.exe", 0)
                End If
                gpbInstallationProgress.Value = 90
                Application.DoEvents()
                '***********************************************
                'Add shortcut's to startmenu...
                '***********************************************
                CreateShortcut(GetStartMenuDir() & "Go! YouTube Snagger.lnk", InstallDir & "\Go! YouTube Snagger.exe", "Go! YouTube Snagger", InstallDir & "\", InstallDir & "\Go! YouTube Snagger.exe", 0)
                My.Computer.FileSystem.CreateDirectory(GetStartMenuDir() & "Go! Visual Team")
                My.Computer.FileSystem.CreateDirectory(GetStartMenuDir() & "Go! Visual Team\Go! YouTube Snagger")
                CreateShortcut(GetStartMenuDir() & "Go! Visual Team\Go! YouTube Snagger\Go! YouTube Snagger.lnk", InstallDir & "\Go! YouTube Snagger.exe", "Go! YouTube Snagger", InstallDir & "\", InstallDir & "\Go! YouTube Snagger.exe", 0)
                gpbInstallationProgress.Value = 100
                Application.DoEvents()
            End If
        End If
        Return True
    End Function

#End Region

#End Region

    Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If isAllowedToRun Then
            If cbRun.Checked Then
                Dim p As New Process()
                p.StartInfo.FileName = applicationPath
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                p.StartInfo.UseShellExecute = True
                p.StartInfo.Arguments = "-" & m_index
                p.Start()
            End If
        End If
        If doDeleteMe Then
            DeleteMe()
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click

        Dim Dialog As New FolderBrowserDialog

        Dialog.SelectedPath = txtPath.Text
        Dialog.ShowNewFolderButton = True
        Dialog.Description = pleaseChooseAFolderWhereYouWantToLocateTheFilesOfTheInstallation

        If Dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPath.Text = Dialog.SelectedPath
        End If

    End Sub

    Private Sub btnStartOrStopInstallation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartOrStopInstallation.Click
        ChangeEnabilityOfButtons(False)
        btnStartOrStopInstallation.Enabled = False
        If InstallYS() Then
            messageBox.ShowDialog(goYouTubeSnaggerHasBeenSuccessfullyInstalledOnYourComputer, messageBox.MessageButtons.OKOnly, messageBox.MessageIcons.Information, success)
            isAllowedToRun = True
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click, btnClose1.Click, btnClose2.Click, btnClose3.Click
        Me.Close()
    End Sub

    Private Sub btnUninstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUninstall.Click

        'Select the panel...
        SelectPanel(PanelModes.pUninstall)

        If UninstallYS() Then
            messageBox.ShowDialog(goYouTubeSnaggerHasBeenSuccessfullyUninstalledOnYourComputer, messageBox.MessageButtons.OKOnly, messageBox.MessageIcons.Information, success)
            doDeleteMe = True
            Me.Close()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepair.Click

        'Select the panel...
        SelectPanel(PanelModes.pRepair)

        If RepairYS() Then
            messageBox.ShowDialog(goYouTubeSnaggerHasBeenSuccessfullyRepaired, messageBox.MessageButtons.OKOnly, messageBox.MessageIcons.Information, success)
            isAllowedToRun = True
            Me.Close()
        Else
            Me.Close()
        End If

    End Sub
End Class