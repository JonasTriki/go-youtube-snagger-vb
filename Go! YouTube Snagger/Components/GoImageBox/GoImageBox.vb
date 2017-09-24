Imports System.Drawing.Drawing2D
Imports System.ComponentModel

<DefaultEvent("ImageChanged")> _
Public Class GoImageBox

    Dim m_ImageStyle As ImageDrawingStyle = ImageDrawingStyle.Center

    Dim m_BorderColor As Color = Color.FromArgb(180, 180, 180)
    Dim m_BorderSize As Single = 1

    Dim m_Image As Image
    Dim m_ShowBorder As Boolean = True

    <Description("Occurs when the control has changed the image.")> _
    Public Event ImageChanged(ByVal sender As Object, ByVal e As ImageChangedEventArgs)

#Region " Class ImageChangedEventArgs "

    <Description("Provides data for GoIconBox.ImageChanged event.")> _
    Public Class ImageChangedEventArgs
        Inherits EventArgs

        Dim m_Image As Image
        Dim m_PreviousImage As Image

        <Description("Initializes a new instance of the GoIconBox.ImageChangedEventArgs class.")> _
        Public Sub New(ByVal Image As Image, ByVal PreviousImage As Image)
            m_Image = Image
            m_PreviousImage = PreviousImage
        End Sub

        <Description("Returns the control's image.")> _
        Public ReadOnly Property Image() As Image
            Get
                Return m_Image
            End Get
        End Property

        <Description("Returns the control's previous Image.")> _
        Public ReadOnly Property PreviousImage() As Image
            Get
                Return m_PreviousImage
            End Get
        End Property

    End Class

#End Region

    Enum ImageDrawingStyle

        Normal = 1

        Center = 2

        Stretch = 3

    End Enum

    Public Function DrawArc(ByVal Rectangle As Rectangle, Optional ByVal Radius As Integer = 5) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    Private Function DrawArc(ByVal Rectangle As Rectangle, ByVal RadiusLeftTop As Integer, ByVal RadiusRightTop As Integer, ByVal RadiusRightBottom As Integer, ByVal RadiusLeftBottom As Integer) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, RadiusLeftTop, RadiusLeftTop, 180, 90)
        Path.AddArc(Rectangle.Width - RadiusRightTop, Rectangle.Y, RadiusRightTop, RadiusRightTop, 270, 90)
        Path.AddArc(Rectangle.Width - RadiusRightBottom, Rectangle.Height - RadiusRightBottom, RadiusRightBottom, RadiusRightBottom, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - RadiusLeftBottom, RadiusLeftBottom, RadiusLeftBottom, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    ''' <summary>
    ''' Gets or sets the border size on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the border size on the control.")> _
    Public Property BorderSize As Single
        Get
            Return m_BorderSize
        End Get
        Set(ByVal value As Single)
            m_BorderSize = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the border color on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the border color on the control.")> _
    Public Property BorderColor As Color
        Get
            Return m_BorderColor
        End Get
        Set(ByVal value As Color)
            m_BorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the image style on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the image style on the control.")> _
    Public Property ImageStyle As ImageDrawingStyle
        Get
            Return m_ImageStyle
        End Get
        Set(ByVal value As ImageDrawingStyle)
            m_ImageStyle = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the image on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the image on the control.")> _
    Public Property Image As Image
        Get
            Return m_Image
        End Get
        Set(ByVal value As Image)
            m_Image = value
            Me.Invalidate()
            RaiseEvent ImageChanged(Me, New ImageChangedEventArgs(m_Image, value))
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the border should be showed, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the border should be showed, or not.")> _
    Public Property ShowBorder As Boolean
        Get
            Return m_ShowBorder
        End Get
        Set(ByVal value As Boolean)
            m_ShowBorder = value
            Me.Invalidate()
        End Set
    End Property

    Private Sub GoImageBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        If Not IsNothing(m_Image) Then
            If m_ImageStyle = ImageDrawingStyle.Normal Then
                e.Graphics.DrawImage(m_Image, New RectangleF(0, 0, m_Image.Width, m_Image.Height))
            ElseIf m_ImageStyle = ImageDrawingStyle.Center Then
                If m_Image.Height > Me.Height And m_Image.Width > Me.Width Then
                    e.Graphics.DrawImage(m_Image, New RectangleF(0, 0, Me.Width, Me.Height))
                ElseIf m_Image.Height > Me.Height Then
                    e.Graphics.DrawImage(m_Image, New RectangleF(If(m_Image.Width < Me.Width, (Me.Width - m_Image.Width) / 2, 0), If(m_Image.Height < Me.Height, (Me.Height - m_Image.Height) / 2, 0), m_Image.Width, Me.Height))
                ElseIf m_Image.Width > Me.Width Then
                    e.Graphics.DrawImage(m_Image, New RectangleF(If(m_Image.Width < Me.Width, (Me.Width - m_Image.Width) / 2, 0), If(m_Image.Height < Me.Height, (Me.Height - m_Image.Height) / 2, 0), Me.Width, m_Image.Height))
                Else
                    e.Graphics.DrawImage(m_Image, New Rectangle(If(m_Image.Width < Me.Width, (Me.Width - m_Image.Width) / 2, 0), If(m_Image.Height < Me.Height, (Me.Height - m_Image.Height) / 2, 0), m_Image.Width, m_Image.Height))
                End If
            ElseIf m_ImageStyle = ImageDrawingStyle.Stretch Then
                e.Graphics.DrawImage(m_Image, New RectangleF(0, 0, Me.Width, Me.Height))
            End If
        End If

        If m_ShowBorder Then
            e.Graphics.DrawPath(New Pen(m_BorderColor, m_BorderSize), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)))
        End If

    End Sub

    Private Sub GoImageBox_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub GoImageBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
    End Sub
End Class
