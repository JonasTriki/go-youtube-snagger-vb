Imports System.ComponentModel
Imports System.Net

Public Class YouTubeVideoThumbnailGetter

    Private Function GetImageFromURL(ByVal URL As String) As Image
        Try
            Return Image.FromStream(New WebClient().OpenRead(New Uri(URL)))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetVideoThumbnailsFromURL(ByVal videoURL As String) As YouTubeVideoThumbnailInfo

        Dim info As New YouTubeVideoThumbnailInfo

        info._0 = GetImageFromURL("http://img.youtube.com/vi/" & videoURL.Substring(videoURL.IndexOf("?v=") + 3, 11) & "/0.jpg")
        info._1 = GetImageFromURL("http://img.youtube.com/vi/" & videoURL.Substring(videoURL.IndexOf("?v=") + 3, 11) & "/1.jpg")
        info._2 = GetImageFromURL("http://img.youtube.com/vi/" & videoURL.Substring(videoURL.IndexOf("?v=") + 3, 11) & "/2.jpg")
        info._3 = GetImageFromURL("http://img.youtube.com/vi/" & videoURL.Substring(videoURL.IndexOf("?v=") + 3, 11) & "/3.jpg")
        info._Default = GetImageFromURL("http://img.youtube.com/vi/" & videoURL.Substring(videoURL.IndexOf("?v=") + 3, 11) & "/default.jpg")

        Return info

    End Function

    Public Function GetVideoThumbnailsFromVideoID(ByVal videoID As String) As YouTubeVideoThumbnailInfo

        Dim info As New YouTubeVideoThumbnailInfo

        info._0 = GetImageFromURL("http://img.youtube.com/vi/" & videoID & "/0.jpg")
        info._1 = GetImageFromURL("http://img.youtube.com/vi/" & videoID & "/1.jpg")
        info._2 = GetImageFromURL("http://img.youtube.com/vi/" & videoID & "/2.jpg")
        info._3 = GetImageFromURL("http://img.youtube.com/vi/" & videoID & "/3.jpg")
        info._Default = GetImageFromURL("http://img.youtube.com/vi/" & videoID & "/default.jpg")

        Return info

    End Function
End Class