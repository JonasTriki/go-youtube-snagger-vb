Imports System.ComponentModel
Public Class ControlCL

    <Description("Return's the INI lang file for the whole application")> _
    Public Shared Function GetLangFile() As IniFile
        Return My.MyApplication.langFile
    End Function
End Class