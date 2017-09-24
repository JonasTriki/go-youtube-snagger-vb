Imports Microsoft.Win32

Public Class NetFrameworkChecker

    Public Shared Function GetAllInstalledNetFrameworks() As List(Of String)
        Dim resultList As New List(Of String)
        For Each v As String In Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP", False).GetSubKeyNames
            If v.StartsWith("v") Then
                Dim version As String = v.Remove(0, 1)
                resultList.Add(version)
            End If
        Next
        Return resultList
    End Function

    Public Shared Function IsNetFrameworkHigherThanOr35() As Boolean
        Return GetAllInstalledNetFrameworks.Contains("3.5")
    End Function
End Class