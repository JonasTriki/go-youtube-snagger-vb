'Return's a list of all made Structures for functions...
Imports Google.GData.Client
Imports Google.GData.Extensions
Imports Google.GData.YouTube
Imports Google.GData.Extensions.MediaRss
Imports Google.YouTube

Public Structure YouTubeVideoInfo

    Dim YouTubeFeedInfo As YouTubeFeedInfo
    Dim FileType As String

    Dim VideoDownloadURL As String
    Dim VideoURL As String
    Dim VideoQuality As YouTubeVideoInfoGetter.Qualities
    Dim BestVideoQuality As YouTubeVideoInfoGetter.Qualities

    Dim ContentType As String
    Dim IsValidYouTubeVideo As Boolean

End Structure

Public Structure YouTubeFeedInfo
    Dim Video As Video
    Dim Likes As Integer
    Dim Dislikes As Integer
    Dim FavouriteCount As Integer
    Dim RelatedVideos As Feed(Of Video)
End Structure

Public Structure YouTubeVideoThumbnailInfo

    Dim _Default As Image

    Dim _0 As Image
    Dim _1 As Image
    Dim _2 As Image
    Dim _3 As Image

End Structure

Public Structure YouTubeVideoUserNameAndTitle

    Dim UserName As String
    Dim Title As String

    Dim VideoAvailable As Boolean

End Structure