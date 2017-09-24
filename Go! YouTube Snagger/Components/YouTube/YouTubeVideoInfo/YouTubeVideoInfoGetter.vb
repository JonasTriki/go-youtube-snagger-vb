Imports System.Net
Imports System.IO
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class YouTubeVideoInfoGetter

    Dim videoFeedGetter As New YouTubeVideoFeedGetter

    Public Event ConnectingToYouTube As EventHandler
    Public Event CheckingIfYouTubeVideoIsValid As EventHandler
    Public Event GettingAllVideoInformation As EventHandler
    Public Event CheckingQuality As EventHandler
    Public Event VideoQualityIsNotAvailable As EventHandler
    Public Event Done As EventHandler
    Public Event YouTubeVideoIsNotValid As EventHandler

    Public ReadyToDownload As Boolean

    Enum Qualities

        _Best_Available = 2

        _144p_176x144 = 17
        _720p_1280x720_WebM_HTML5 = 45
        _480p_854x480_WebM_HTML5 = 43
        _4096p_4096x3072 = 38
        _1080p_1920x1080 = 37
        _720p_1280x720 = 22
        _480p_854x480 = 35
        _360p_480x360 = 18
        _360p_640x360 = 34
        _240p_400x240 = 5

    End Enum

    Private Function GetContentType(ByVal Quality As Qualities) As String
        Dim resultContentType As String = ""
        If Quality = Qualities._144p_176x144 Then
            resultContentType = "video/3gpp"
        ElseIf Quality = Qualities._240p_400x240 Or Quality = Qualities._360p_640x360 Or Quality = Qualities._480p_854x480 Then
            resultContentType = "video/x-flv"
        ElseIf Quality = Qualities._360p_480x360 Or Quality = Qualities._720p_1280x720 Or Quality = Qualities._1080p_1920x1080 Or Quality = Qualities._4096p_4096x3072 Then
            resultContentType = "video/mp4"
        ElseIf Quality = Qualities._480p_854x480_WebM_HTML5 Or Quality = Qualities._720p_1280x720_WebM_HTML5 Then
            resultContentType = "video/webm"
        End If
        Return resultContentType
    End Function

    Private Function CheckForBadCharaters(ByVal inputString As String) As String

        Dim outputString As String = inputString

        For Each nAC As String In Split("\ / : * ? "" < > |")
            If outputString.Contains(nAC) Then
                outputString = outputString.Replace(nAC, "")
            End If
        Next

        Return FixEncodingString(outputString)

    End Function

    Private Function FixEncodingString(ByVal s As String) As String
        Return s.Replace("\/", "/").Replace("\", "&").Replace("u0026", "")
    End Function

    Public Function GetYouTubeVideoTag(ByVal url As String) As String
        Dim resultID As String = ""
        If Not url.StartsWith("http://www.youtube.com/watch?v=") Then
            For Each ip As String In Split(url.Remove(0, Len("http://www.youtube.com/watch?")), "&")
                If ip.StartsWith("v=") Then
                    resultID = ip.Replace("v=", "")
                    Exit For
                End If
                Application.DoEvents()
            Next
        Else
            resultID = Split(url.Replace("http://www.youtube.com/watch?v=", ""), "&")(0)
        End If
        Return resultID
    End Function

    Public Function GetYouTubeVideoInfo(ByVal URL As String, ByVal Quality As Qualities) As YouTubeVideoInfo
       Dim result As New YouTubeVideoInfo
        ReadyToDownload = False

        RaiseEvent ConnectingToYouTube(Me, New EventArgs) : Application.DoEvents()
        Dim VideoSource As String
        Try
            Dim HttpWebResponse As HttpWebResponse = DirectCast(DirectCast(Net.WebRequest.Create(URL), System.Net.HttpWebRequest).GetResponse, Net.HttpWebResponse)
            URL = HttpWebResponse.ResponseUri.ToString
            VideoSource = New StreamReader(HttpWebResponse.GetResponseStream, System.Text.Encoding.UTF8).ReadToEnd
        Catch ex As Exception
            VideoSource = ""
        End Try

        If VideoSource <> "" Then
            Try
                RaiseEvent CheckingIfYouTubeVideoIsValid(Me, New EventArgs) : Application.DoEvents()
                result.IsValidYouTubeVideo = VideoSource.IndexOf("video_id") > -1 And URL.StartsWith(New Uri(URL).Scheme & "://" & New Uri(URL).Host & "/watch?v=")

                If result.IsValidYouTubeVideo Then
                    Dim VideoSignature As String = Split(VideoSource, ("""fmt_url_map"": """))(1)
                    'My.Computer.FileSystem.WriteAllText("C:\Users\Jonas\Desktop\video.htm", VideoSignature, True)

                    RaiseEvent GettingAllVideoInformation(Me, New EventArgs) : Application.DoEvents()
                    result.VideoURL = Split(URL, New Uri(URL).Scheme & "://" & New Uri(URL).Host)(1)
                    result.VideoQuality = Quality
                    result.YouTubeFeedInfo = videoFeedGetter.GetVideoInfo(GetYouTubeVideoTag(URL))

                    RaiseEvent CheckingQuality(Me, New EventArgs) : Application.DoEvents()
                    If Not Quality = Qualities._Best_Available Then
                        Select Case Quality
                            Case Qualities._720p_1280x720_WebM_HTML5
                                If Split(VideoSignature, "|")(0) = Qualities._720p_1280x720_WebM_HTML5 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._720p_1280x720_WebM_HTML5 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1)), ",")(0)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            Case Qualities._480p_854x480_WebM_HTML5
                                If Split(VideoSignature, "|")(0) = Qualities._480p_854x480_WebM_HTML5 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._480p_854x480_WebM_HTML5 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1)), ",")(0)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            Case Qualities._4096p_4096x3072
                                If Split(VideoSignature, "|")(0) = Qualities._4096p_4096x3072 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._4096p_4096x3072 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1)), ",")(0)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            Case Qualities._1080p_1920x1080
                                If Split(VideoSignature, "|")(0) = Qualities._1080p_1920x1080 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._1080p_1920x1080 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1)), ",")(0)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            Case Qualities._720p_1280x720
                                'Check if 720p is the best available...
                                If Split(VideoSignature, "|")(0) = Qualities._720p_1280x720 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._720p_1280x720 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1)), ",")(0)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            Case Qualities._480p_854x480
                                'Check if 480p is the best available...
                                If Split(VideoSignature, "|")(0) = Qualities._480p_854x480 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._480p_854x480 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1)), ",")(0)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            Case Qualities._360p_640x360
                                'Check if 360p is the best available...
                                If Split(VideoSignature, "|")(0) = Qualities._360p_640x360 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._360p_640x360 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1)), ",")(0)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            Case Qualities._240p_400x240
                                'Check if 240p is the best available...
                                If Split(VideoSignature, "|")(0) = Qualities._240p_400x240 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._240p_400x240 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1)), ",")(0)
                                                    result.VideoDownloadURL = result.VideoDownloadURL.Remove(result.VideoDownloadURL.Length - 1, 1)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            Case Qualities._144p_176x144
                                'Check if 240p is the best available...
                                If Split(VideoSignature, "|")(0) = Qualities._144p_176x144 Then
                                    'It's the best available, so just do the same as _Best_Available
                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                                Else
                                    'It's not the best available, so let's do a loop to catch it...
                                    Dim VideoSignature_Splitted As String() = Split(VideoSignature, "|")
                                    For i As Integer = 0 To VideoSignature_Splitted.Count - 1
                                        If Not i = 0 Then
                                            Dim line As String = Split(VideoSignature_Splitted(i), ",")(1)
                                            Try
                                                If line = Qualities._144p_176x144 Then
                                                    result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(i + 1).Replace("\/", "/")), ",")(0)
                                                    result.VideoDownloadURL = result.VideoDownloadURL.Remove(result.VideoDownloadURL.Length - 1, 1)
                                                    Exit For
                                                End If
                                            Catch ex As Exception
                                                Exit For
                                            End Try
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                        End Select
                    Else
                        result.VideoDownloadURL = Split(FixEncodingString(Split(VideoSignature, "|")(1)), ",")(0)
                        result.BestVideoQuality = Split(FixEncodingString(Split(VideoSignature, "|")(0)), ",")(0)
                    End If
                    If result.VideoDownloadURL = "" Then
                        RaiseEvent VideoQualityIsNotAvailable(Me, New EventArgs)
                    Else
                        result.ContentType = GetContentType(If(Quality = Qualities._Best_Available, result.BestVideoQuality, Quality))

                        If result.ContentType = "video/x-flv" Then
                            result.FileType = ".flv"
                        ElseIf result.ContentType = "video/mp4" Then
                            result.FileType = ".mp4"
                        ElseIf result.ContentType = "video/webm" Then
                            result.FileType = ".webm"
                        ElseIf result.ContentType = "video/3gpp" Then
                            result.FileType = ".3gpp"
                        End If

                        ReadyToDownload = True
                        RaiseEvent Done(Me, New EventArgs) : Application.DoEvents()
                    End If
                End If
            Catch ex As Exception
                'MsgBox(ex.StackTrace)
                'MsgBox(ex.Message)
                Throw ex
            End Try
        Else
            result.IsValidYouTubeVideo = False
        End If

        If Not result.IsValidYouTubeVideo Then
            RaiseEvent YouTubeVideoIsNotValid(Me, New EventArgs)
        End If
        Return If(Not result.IsValidYouTubeVideo Or result.VideoURL = "", New YouTubeVideoInfo, result)
    End Function

End Class