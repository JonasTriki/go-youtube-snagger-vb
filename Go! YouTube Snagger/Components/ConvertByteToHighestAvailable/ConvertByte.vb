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
        langFile = ControlCL.GetLangFile
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

#Region " ~ Enums ~ "

    Enum BinaryTypes
        KB = 0
        MB = 1
        GB = 2
        TB = 3
        PB = 4
        EB = 5
        ZB = 6
        YB = 7
    End Enum

#End Region

    Public Function ConvertByte(ByVal bytes As Double) As String
        Dim mString As String = ""
        Dim binaryTypesArray As String() = {KB, MB, GB, TB, PB, EB, ZB, YB}
        For i As Integer = 0 To binaryTypesArray.Count - 1
            Dim index As Integer = (binaryTypesArray.Count - 1) - i
            If bytes <= 1023 Then
                mString = bytes & " " & _byte
                Exit For
            ElseIf bytes >= 1024 ^ (index + 1) Then
                mString = Math.Round(bytes / (1024 ^ (index + 1)), 2) & " " & binaryTypesArray(index)
                Exit For
            End If
            Application.DoEvents()
        Next
        Return mString
    End Function

    Public Function ConvertByte(ByVal bytes As Double, ByVal outputBinaryType As BinaryTypes)
        Dim index As Integer = outputBinaryType
        Dim binaryTypesArray As String() = {KB, MB, GB, TB, PB, EB, ZB, YB}
        Return Math.Round(bytes / (1024 ^ (index + 1)), 2) & " " & binaryTypesArray(index)
    End Function

End Class
