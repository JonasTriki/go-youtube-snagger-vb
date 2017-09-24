Imports System
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

Public Class Shell32

#Region " SHGFI Const's "

    Public Const SHGFI_ICON As UInteger = &H100
    ' get icon
    Public Const SHGFI_DISPLAYNAME As UInteger = &H200
    ' get display name
    Public Const SHGFI_TYPENAME As UInteger = &H400
    ' get type name
    Public Const SHGFI_ATTRIBUTES As UInteger = &H800
    ' get attributes
    Public Const SHGFI_ICONLOCATION As UInteger = &H1000
    ' get icon location
    Public Const SHGFI_EXETYPE As UInteger = &H2000
    ' return exe type
    Public Const SHGFI_SYSICONINDEX As UInteger = &H4000
    ' get system icon index
    Public Const SHGFI_LINKOVERLAY As UInteger = &H8000
    ' put a link overlay on icon
    Public Const SHGFI_SELECTED As UInteger = &H10000
    ' show icon in selected state
    Public Const SHGFI_ATTR_SPECIFIED As UInteger = &H20000
    ' get only specified attributes
    Public Const SHGFI_LARGEICON As UInteger = &H0
    ' get large icon
    Public Const SHGFI_SMALLICON As UInteger = &H1
    ' get small icon
    Public Const SHGFI_OPENICON As UInteger = &H2
    ' get open icon
    Public Const SHGFI_SHELLICONSIZE As UInteger = &H4
    ' get shell size icon
    Public Const SHGFI_PIDL As UInteger = &H8
    ' pszPath is a pidl
    Public Const SHGFI_USEFILEATTRIBUTES As UInteger = &H10
    ' use passed dwFileAttribute
    Public Const SHGFI_ADDOVERLAYS As UInteger = &H20
    ' apply the appropriate overlays
    Public Const SHGFI_OVERLAYINDEX As UInteger = &H40
    ' Get the index of the overlay
    Public Const FILE_ATTRIBUTE_DIRECTORY As UInteger = &H10
    Public Const FILE_ATTRIBUTE_NORMAL As UInteger = &H80

#End Region

    <Flags()> _
    Enum HChangeNotifyFlags
        SHCNF_DWORD = &H3
        SHCNF_IDLIST = &H0
        SHCNF_PATHA = &H1
        SHCNF_PATHW = &H5
        SHCNF_PRINTERA = &H2
        SHCNF_PRINTERW = &H6
        SHCNF_FLUSH = &H1000
        SHCNF_FLUSHNOWAIT = &H2000
    End Enum

    <Flags()> _
    Enum HChangeNotifyEventID
        SHCNE_ALLEVENTS = &H7FFFFFFF
        SHCNE_ASSOCCHANGED = &H8000000
        SHCNE_ATTRIBUTES = &H800
        SHCNE_CREATE = &H2
        SHCNE_DELETE = &H4
        SHCNE_DRIVEADD = &H100
        SHCNE_DRIVEADDGUI = &H10000
        SHCNE_DRIVEREMOVED = &H80
        SHCNE_EXTENDED_EVENT = &H4000000
        SHCNE_FREESPACE = &H40000
        SHCNE_MEDIAINSERTED = &H20
        SHCNE_MEDIAREMOVED = &H40
        SHCNE_MKDIR = &H8
        SHCNE_NETSHARE = &H200
        SHCNE_NETUNSHARE = &H400
        SHCNE_RENAMEFOLDER = &H20000
        SHCNE_RENAMEITEM = &H1
        SHCNE_RMDIR = &H10
        SHCNE_SERVERDISCONNECT = &H4000
        SHCNE_UPDATEDIR = &H1000
        SHCNE_UPDATEIMAGE = &H8000
    End Enum

    Enum IconStyles

        Normal = 1

        LinkOverlay = 2

        Selected = 3

        LinkOverlayAndSelected = 4

    End Enum

#Region " Properities/Functions "

    Public Shared Function GetIconFromFolder(ByVal FolderPath As String, Optional ByVal IconStyle As IconStyles = IconStyles.Normal) As Icon

        Dim flags As UInteger = Shell32.SHGFI_SYSICONINDEX Or Shell32.SHGFI_USEFILEATTRIBUTES

        If IconStyle = IconStyles.Normal Then
            flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.LinkOverlay Then
            flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.Selected Then
            flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
            flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        End If

        Dim ShellFileInfo As New Shell32.SHFILEINFO()

        Shell32.SHGetFileInfo(FolderPath, 251, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

        Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

        Return Icon

    End Function

    Public Shared Function GetIconFromFolder(ByVal FolderPath As String, ByVal LargeIcon As Boolean, Optional ByVal IconStyle As IconStyles = IconStyles.Normal) As Icon

        If Not LargeIcon Then

            Dim flags As UInteger = Shell32.SHGFI_SYSICONINDEX Or Shell32.SHGFI_USEFILEATTRIBUTES

            If IconStyle = IconStyles.Normal Then
                flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.LinkOverlay Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.Selected Then
                flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            End If

            Dim ShellFileInfo As New Shell32.SHFILEINFO()

            Shell32.SHGetFileInfo(FolderPath, 251, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

            Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

            Return Icon

        Else

            Dim flags As UInteger = Shell32.SHGFI_SYSICONINDEX Or Shell32.SHGFI_USEFILEATTRIBUTES

            If IconStyle = IconStyles.Normal Then
                flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.LinkOverlay Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.Selected Then
                flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            End If

            Dim ShellFileInfo As New Shell32.SHFILEINFO()

            Shell32.SHGetFileInfo(FolderPath, 251, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

            Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

            Return Icon

        End If

    End Function

    Public Shared Function GetIcon(ByVal FilePath As String, Optional ByVal IconStyle As IconStyles = IconStyles.Normal) As Icon

        Dim flags As UInteger = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON

        If IconStyle = IconStyles.Normal Then
            flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.LinkOverlay Then
            flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.Selected Then
            flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
            flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
        End If

        'Get the extension
        Dim ext As String = IO.Path.GetExtension(FilePath)

        Dim ShellFileInfo As New Shell32.SHFILEINFO()

        Shell32.SHGetFileInfo(ext, 0, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

        Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

        Return Icon

    End Function

    Public Shared Function GetIcon(ByVal FilePath As String, ByVal LargeIcon As Boolean, Optional ByVal IconStyle As IconStyles = IconStyles.Normal) As Icon

        If Not LargeIcon Then

            Dim flags As UInteger = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON

            If IconStyle = IconStyles.Normal Then
                flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.LinkOverlay Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.Selected Then
                flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_SMALLICON
            End If

            'Get the extension
            Dim ext As String = IO.Path.GetExtension(FilePath)

            Dim ShellFileInfo As New Shell32.SHFILEINFO()

            Shell32.SHGetFileInfo(ext, 0, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

            Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

            Return Icon

        Else

            Dim flags As UInteger = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON

            If IconStyle = IconStyles.Normal Then
                flags = Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.LinkOverlay Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.Selected Then
                flags = Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            ElseIf IconStyle = IconStyles.LinkOverlayAndSelected Then
                flags = Shell32.SHGFI_LINKOVERLAY Or Shell32.SHGFI_SELECTED Or Shell32.SHGFI_ICON Or Shell32.SHGFI_USEFILEATTRIBUTES Or Shell32.SHGFI_LARGEICON
            End If

            'Get the extension
            Dim ext As String = IO.Path.GetExtension(FilePath)

            Dim ShellFileInfo As New SHFILEINFO()

            Shell32.SHGetFileInfo(ext, 0, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

            Dim Icon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(ShellFileInfo.hIcon)

            Return Icon

        End If

    End Function

    Public Shared Function GetFileType(ByVal FilePath As String) As String

        Dim ext As String = IO.Path.GetExtension(FilePath)

        Dim flags As UInteger = Shell32.SHGFI_TYPENAME Or Shell32.SHGFI_USEFILEATTRIBUTES

        Dim ShellFileInfo As New SHFILEINFO()

        Shell32.SHGetFileInfo(ext, FILE_ATTRIBUTE_NORMAL, ShellFileInfo, Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(ShellFileInfo)), flags)

        Return ShellFileInfo.szTypeName

    End Function

    Public Shared Sub RefreshRegistry()
        SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero)
    End Sub

    Public Shared Function GetShell32FileName() As String

        Dim sysDir As String = Environment.SystemDirectory.Replace("Windows\system32", "")

        If VersionManager.RunningOnXP Then
            Return sysDir & "WINDOWS\System32\shell32.dll"
        Else
            Return sysDir & "Windows\System32\shell32.dll"
        End If

    End Function

    <DllImport("shell32.dll")> _
    Shared Sub SHChangeNotify( _
  ByVal wEventID As HChangeNotifyEventID, _
  ByVal uFlags As HChangeNotifyFlags, _
  ByVal dwItem1 As IntPtr, _
  ByVal dwItem2 As IntPtr)
    End Sub

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SHFILEINFO

        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As System.UInt32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String

    End Structure

    <DllImport("Shell32.dll")> _
    Public Shared Function SHGetFileInfo( _
        ByVal pszPath As String, _
        ByVal dwFileAttributes As System.UInt32, _
        ByRef psfi As SHFILEINFO, _
        ByVal cbFileInfo As System.UInt32, _
        ByVal uFlags As System.UInt32) As IntPtr
    End Function
#End Region

End Class