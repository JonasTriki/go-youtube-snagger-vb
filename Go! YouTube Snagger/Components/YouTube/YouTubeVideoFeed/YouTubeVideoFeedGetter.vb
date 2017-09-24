Imports Google.GData.Client
Imports Google.GData.Extensions
Imports Google.GData.YouTube
Imports Google.GData.Extensions.MediaRss
Imports Google.YouTube
Imports System.ComponentModel
Imports System.Xml

Public Class YouTubeVideoFeedGetter

    Dim curVideoQuery As YouTubeQuery
    Dim curVideo As Video
    Dim curRelatedVideosFeed As Feed(Of Video)
    Dim request As New YouTubeRequest(New YouTubeRequestSettings("uTube Snagger", "AI39si60HCzvyUrXr90MzBOGlcwShwA2Ds8JFQ2Ep5W_g_avBO7L8i7OCId86LhqHcdaO0cnms-6KHKxcc-v99tj2fXAOv_Wbw"))

    Public Function GetVideoInfo(ByVal videoID As String) As YouTubeFeedInfo
        Dim resultInfo As New YouTubeFeedInfo
        Try
            curVideoQuery = New YouTubeQuery("http://gdata.youtube.com/feeds/api/videos/" & videoID)
            curVideo = request.Retrieve(Of Video)(curVideoQuery)
            curRelatedVideosFeed = request.GetRelatedVideos(curVideo)

            'Catch some info from the video...
            'Variables...
            Dim likes As Integer = -1
            Dim dislikes As Integer = -1
            Dim favCount As Integer = -1

            'Favorite count
            Dim ytFavRatingElement As Statistics = DirectCast(curVideo.AtomEntry.FindExtension("statistics", "http://gdata.youtube.com/schemas/2007"), Statistics)
            If ytFavRatingElement IsNot Nothing Then
                favCount = ytFavRatingElement.FavoriteCount
            End If
            MsgBox(favCount)

            'Ratings
            Dim ytRatingElement As XmlExtension = DirectCast(curVideo.AtomEntry.FindExtension("rating", "http://gdata.youtube.com/schemas/2007"), XmlExtension)
            If ytRatingElement IsNot Nothing Then
                For Each attribute As XmlAttribute In ytRatingElement.Node.Attributes
                    Select Case attribute.Name
                        Case "numLikes"
                            likes = Integer.Parse(attribute.Value)
                            Exit Select
                        Case "numDislikes"
                            dislikes = Integer.Parse(attribute.Value)
                            Exit Select
                    End Select
                Next
            End If
            MsgBox(likes)
            MsgBox(dislikes)

            'Set variables to the catched ones...
            resultInfo.Likes = likes
            resultInfo.Dislikes = dislikes
            resultInfo.FavouriteCount = favCount
            resultInfo.Video = curVideo
            resultInfo.RelatedVideos = curRelatedVideosFeed

            'Return the result info :)
            Return resultInfo
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw ex
            Return Nothing
        End Try
    End Function

End Class