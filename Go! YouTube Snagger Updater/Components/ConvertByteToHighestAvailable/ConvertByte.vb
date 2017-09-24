Public Class ConvertByte

    'SomeCommands - Code
    Dim _byte As String
    Dim YB As String
    Dim ZB As String
    Dim EB As String
    Dim PB As String
    Dim TB As String
    Dim GB As String
    Dim MB As String
    Dim KB As String

    Dim langFile As New IniFile

    Public Sub New()
        CheckLang()
    End Sub

    Public Sub CheckLang()

        If My.Settings.Language.ToString.StartsWith("-") Then
            Do Until Not My.Settings.Language.ToString.StartsWith("-")
                My.Settings.language += 1
            Loop
        End If

        langFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\languages").Item(My.Settings.language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'SomeCommands = langFile.GetString("SomeCommands", "")
        _byte = langFile.GetString("SomeCommands", "Byte")
        YB = langFile.GetString("SomeCommands", "YB")
        ZB = langFile.GetString("SomeCommands", "ZB")
        EB = langFile.GetString("SomeCommands", "EB")
        PB = langFile.GetString("SomeCommands", "PB")
        TB = langFile.GetString("SomeCommands", "TB")
        GB = langFile.GetString("SomeCommands", "GB")
        MB = langFile.GetString("SomeCommands", "MB")
        KB = langFile.GetString("SomeCommands", "KB")

    End Sub

    Public Function ToHighestAvailable(ByVal Size As Long) As String

        Dim resultString As String = ""

        If Size <= 999 Then
            'byte <= 999 byte
            resultString = Size & " " & _byte
        ElseIf Size >= 1.0E+24 Then
            'YB >= 100000000000000000 byte, Value / 1.2089258196146291E+18
            resultString = Math.Round((Size / 1.2089258196146291E+18), 2) & " " & YB
        ElseIf Size >= 1.0E+21 Then
            'ZB >= 1000000000000000 byte, Value / 1.1805916207174114E+17
            resultString = Math.Round((Size / 1.1805916207174114E+17), 2) & " " & ZB
        ElseIf Size >= 1000000000000000000 Then
            'EB >= 10000000000000 byte, Value / 1152921504606846976
            resultString = Math.Round((Size / 1152921504606846976), 2) & " " & EB
        ElseIf Size >= 1000000000000000 Then
            'PB >= 100000000000 byte, Value / 1125899906842624
            resultString = Math.Round((Size / 1125899906842624), 2) & " " & PB
        ElseIf Size >= 1000000000000 Then
            'TB >= 1000000000 byte, Value / 1099511627776
            resultString = Math.Round((Size / 1099511627776), 2) & " " & TB
        ElseIf Size >= 1000000000 Then
            'GB >= 10000000 byte, Value / 1073741824
            resultString = Math.Round((Size / 1073741824), 2) & " " & GB
        ElseIf Size >= 1000000 Then
            'MB >= 1000000 byte, Value / 1048576
            resultString = Math.Round((Size / 1048576), 2) & " " & MB
        ElseIf Size >= 1000 Then
            'KB >= 1000 byte, Value / 1024
            resultString = Math.Round((Size / 1024), 2) & " " & KB
        End If

        Return resultString

    End Function

End Class
