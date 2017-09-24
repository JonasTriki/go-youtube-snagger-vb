Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class CommentBox

    Public Class CommentBoxCollection
        Inherits CollectionBase

        Dim m_CommentBox As CommentBox

        Public Event CommentBoxItemAdded As EventHandler

        Public Sub New(ByVal commentBox As CommentBox)
            m_CommentBox = commentBox
        End Sub

        Private Function getWidth() As Integer
            If getTotalHeightPlusMargin() >= m_CommentBox.pBox.Height Then
                Return m_CommentBox.pBox.Width - 23
            Else
                Return m_CommentBox.pBox.Width - 6
            End If
        End Function

        Private Function getTotalHeightPlusMargin() As Integer
            Dim resultHeight As Integer = 0
            For Each i As CommentBoxItem In Me
                If List.IndexOf(i) = 0 Then
                    resultHeight += i.Height + 6
                Else
                    resultHeight += i.Height + 3
                End If
            Next
            Return resultHeight
        End Function

        Public Sub fixLine()
            If Count = 2 Then
                DirectCast(List(0), CommentBoxItem).showLine = True
            ElseIf Count > 2 Then
                For Each i As CommentBoxItem In Me
                    i.showLine = Not List.IndexOf(i) = List.Count - 1
                Next
            ElseIf Count = 1 Then
                DirectCast(List(0), CommentBoxItem).showLine = False
            End If
        End Sub

        Public Function Add(ByVal commentBoxItem As CommentBoxItem) As CommentBoxItem
            commentBoxItem.SuspendLayout()
            m_CommentBox.SuspendLayout()
            List.Add(commentBoxItem)
            commentBoxItem.ResumeLayout()
            m_CommentBox.ResumeLayout()
            RaiseEvent CommentBoxItemAdded(Me, New EventArgs)
            Return commentBoxItem
        End Function

        Public Function Add(ByVal comment As String, ByVal username As String, ByVal secondsago As Double) As CommentBoxItem
            Dim commentBoxItem As New CommentBoxItem(comment, username, secondsago)
            commentBoxItem.SuspendLayout()
            m_CommentBox.SuspendLayout()
            List.Add(commentBoxItem)
            commentBoxItem.ResumeLayout()
            m_CommentBox.ResumeLayout()
            RaiseEvent CommentBoxItemAdded(Me, New EventArgs)
            Return commentBoxItem
        End Function

        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            MyBase.OnInsertComplete(index, value)
            Dim item As CommentBoxItem = value
            If index = 0 Then
                item.Location = New Point(3, 3)
            Else
                item.Location = New Point(3, getTotalHeightPlusMargin() - item.Height)
            End If
            item.Size = New Size(getWidth, item.Height)
            item.Anchor = AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right
            m_CommentBox.pBox.Controls.Add(item)
            fixLine()
        End Sub

        Protected Overrides Sub OnClear()
            MyBase.OnClear()
        End Sub

        Protected Overrides Sub OnClearComplete()
            MyBase.OnClearComplete()
            m_CommentBox.pBox.Controls.Clear()
        End Sub

    End Class

    Dim m_Items As New CommentBoxCollection(Me)
    Dim m_BorderColorDisabled As Color = Color.FromArgb(180, 180, 180)
    Dim m_BorderColor As Color = Color.FromArgb(130, 130, 130)

    <DefaultValue(GetType(Color), "Color.FromArgb(130, 130, 130)")> _
    Public Property BorderColor As Color
        Get
            Return m_BorderColor
        End Get
        Set(value As Color)
            m_BorderColor = value
            Me.Invalidate()
        End Set
    End Property

    Public ReadOnly Property Items() As CommentBoxCollection
        Get
            Return m_Items
        End Get
    End Property

    Private Function DrawArc(ByVal Rectangle As Rectangle, ByVal RadiusLeftTop As Integer, ByVal RadiusRightTop As Integer, ByVal RadiusRightBottom As Integer, ByVal RadiusLeftBottom As Integer) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, RadiusLeftTop, RadiusLeftTop, 180, 90)
        Path.AddArc(Rectangle.Width - RadiusRightTop, Rectangle.Y, RadiusRightTop, RadiusRightTop, 270, 90)
        Path.AddArc(Rectangle.Width - RadiusRightBottom, Rectangle.Height - RadiusRightBottom, RadiusRightBottom, RadiusRightBottom, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - RadiusLeftBottom, RadiusLeftBottom, RadiusLeftBottom, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    Private Sub CommentBox_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged
        Me.Invalidate()
    End Sub

    Private Sub CommentBox_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Private Sub CommentBox_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub CommentBox_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        'Draw backgroundcolor...
        e.Graphics.FillPath(New SolidBrush(Color.White), DrawArc(New Rectangle(1, 1, Me.Width - 2, Me.Height - 2), 1, 1, 1, 1))

        'Draw bordercolor...
        e.Graphics.DrawPath(New Pen(If(Me.Enabled, m_BorderColor, m_BorderColorDisabled), 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 1, 1, 1, 1))

    End Sub

    Private Sub CommentBox_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles MyBase.Scroll
        Me.Invalidate()
    End Sub
End Class