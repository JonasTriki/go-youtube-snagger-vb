Imports Microsoft.Win32

Public Class OpenURL
    Public Shared Function GetDefaultBrowser() As String
        Dim key As RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey("HTTP\shell\open\command", False)
        Dim resultString As String = key.GetValue("").ToString().ToLower().Replace("""", "")

        If Not resultString.EndsWith(".exe") Then
            resultString = resultString.Substring(0, resultString.LastIndexOf(".exe") + 4)
        End If

        Return resultString
    End Function

    Public Shared Sub OpenURL(ByVal url As String)
        Try
            Dim p As New Process
            p.StartInfo.FileName = GetDefaultBrowser()
            p.StartInfo.Arguments = url
            p.Start()
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub
End Class