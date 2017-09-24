Public Class VersionManager
    ''' <summary>
    ''' Determines if the application is running on XP.
    ''' </summary>
    Public Shared ReadOnly Property RunningOnXP() As Boolean
        Get
            Return Not Environment.OSVersion.Version.Major > 5
        End Get
    End Property

    ''' <summary>
    ''' Determines if the application is running on Vista.
    ''' </summary>
    Public Shared ReadOnly Property RunningOnVista() As Boolean
        Get
            Return Environment.OSVersion.Version.Major >= 6
        End Get
    End Property

    ''' <summary>
    ''' Determines if the application is running on Windows 7.
    ''' </summary>
    Public Shared ReadOnly Property RunningOnWin7() As Boolean
        Get
            Return (Environment.OSVersion.Version.Major > 6) OrElse (Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor >= 1)
        End Get
    End Property

    ''' <summary>
    ''' Determines if the application is running on Windows XP or up.
    ''' </summary>
    Public Shared ReadOnly Property RunningOnWinXPOrUp() As Boolean
        Get
            Return Not Environment.OSVersion.Version.Major > 5 Or Environment.OSVersion.Version.Major >= 6 Or (Environment.OSVersion.Version.Major > 6) OrElse (Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor >= 1)
        End Get
    End Property
End Class