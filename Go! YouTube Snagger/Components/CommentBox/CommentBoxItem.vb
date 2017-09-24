Imports System.ComponentModel

Public Class CommentBoxItem

    Public _showLine As Boolean = True

    Dim m_Comment As String
    Dim m_Username As String
    Dim m_SeconsAgo As Double

    Public Sub New()
        InitializeComponent()
        checkControls()
    End Sub

    Public Sub New(ByVal comment As String, ByVal username As String, ByVal secondsago As Double)
        InitializeComponent()
        m_Comment = comment
        m_Username = username
        m_SeconsAgo = secondsago
        checkControls()
    End Sub

    Public Property showLine As Boolean
        Get
            Return _showLine
        End Get
        Set(value As Boolean)
            _showLine = value
            Me.Invalidate()
        End Set
    End Property

    Private Function CountVisibleLine() As Integer
        Dim Txtsize As Size = TextRenderer.MeasureText(txtComment.Text, txtComment.Font)
        Dim z = txtComment.Lines
        Dim MaxLine = txtComment.Height \ (Txtsize.Height \ z.Count)
        Dim LineCount As Integer = 0
        For Each Ln In txtComment.Lines
            Dim LnLines = Math.Ceiling(TextRenderer.MeasureText(Ln, txtComment.Font).Width / txtComment.Width)
            LineCount += CInt(LnLines)
        Next
        If LineCount > MaxLine Then LineCount = MaxLine
        Return LineCount
    End Function

    Private Function secondsToYouTubeTime(ByVal secs As Double) As String
        Dim resultString As String = ""
        If secs < 60 Then
            'Seconds...
            resultString = If(secs <> 1, secs & " seconds ago", secs & " second ago")
        ElseIf secs >= 60 And secs < 3600 Then
            'Minutes...
            resultString = If(secs \ 60 <> 1, secs \ 60 & " minutes ago", secs \ 60 & " minute ago")
        ElseIf secs >= 3600 And secs < 86400 Then
            'Hours...
            resultString = If(secs \ 3600 <> 1, secs \ 3600 & " hours ago", secs \ 3600 & " hour ago")
        ElseIf secs >= 86400 And secs < 2629743.83 Then
            'Days...
            resultString = If(secs \ 86400 <> 1, secs \ 86400 & " days ago", secs \ 86400 & " day ago")
        ElseIf secs >= 2629743.83 And secs < 31556926 Then
            'Months...
            resultString = If(secs \ 2629743.83 <> 1, secs \ 2629743.83 & " months ago", secs \ 2629743.83 & " month ago")
        ElseIf secs >= 31556926 Then
            'Years...
            resultString = If(Math.Round(secs / 31556926, 0) <> 1, Math.Round(secs / 31556926, 0) & " years ago", Math.Round(secs / 31556926, 0) & " year ago")
        End If
        Return resultString
    End Function

    Private Sub checkControls()

        'Fix comment and height...
        txtComment.Text = m_Comment

        Dim lines As Integer = CountVisibleLine()
        Me.Height = (((txtComment.Font.SizeInPoints * lines) + ((lines * txtComment.Margin.All) * 2))) + 25
        txtComment.ScrollBars = ScrollBars.None
        txtComment.Location = New Point(0, 0)
        txtComment.Size = New Size(Me.Width, Me.Height - 25)

        'Fix username and time ago...
        llUsername.Text = m_Username
        llUsername.Location = New Point(0, llUsername.Location.Y)
        lWhen.Text = "~ " & secondsToYouTubeTime(m_SeconsAgo)
        lWhen.Location = New Point(llUsername.Location.X + llUsername.Width - 3, lWhen.Location.Y)

    End Sub

    <Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")> _
    Public Property Comment As String
        Get
            Return m_Comment
        End Get
        Set(value As String)
            m_Comment = value
            checkControls()
        End Set
    End Property

    Public Property Username As String
        Get
            Return m_Username
        End Get
        Set(value As String)
            If value.Length > 20 Then
                Throw New IndexOutOfRangeException("Username can not be longer than 20 characters.")
            Else
                m_Username = value
                checkControls()
            End If
        End Set
    End Property

    Public Property SeconsAgo As Double
        Get
            Return m_SeconsAgo
        End Get
        Set(value As Double)
            m_SeconsAgo = value
            checkControls()
        End Set
    End Property

    Private Sub CommentBoxItem_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Private Sub CommentBoxItem_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Invalidate()
    End Sub

    Private Sub CommentBoxItem_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If _showLine Then
            e.Graphics.DrawLine(New Pen(Color.FromArgb(130, 130, 130), 1), 0, Me.Height - 1, Me.Width - 1, Me.Height - 1)
        End If
    End Sub
End Class