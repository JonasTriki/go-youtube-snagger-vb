Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<DefaultProperty("Value"), DefaultEvent("ValueChanged")> _
Public Class GoProgressBar

    Dim m_BlockColor As Color = Color.FromArgb(0, 174, 255)

    Dim m_BorderColor As Color = Color.FromArgb(0, 112, 238)
    Dim m_BackgroundColor As Color = Color.White

    Dim m_TextFont As Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
    Dim m_TextColor As Color = Color.FromArgb(32, 32, 32)

    Dim m_MaxValue As Double = 100
    Dim m_MinValue As Double = 0
    Dim m_Value As Double = 0

    Dim m_Icon As Image
    Dim m_ShowIcon As Boolean = False
    Dim m_ShowText As Boolean = True

    Dim m_ExtraText As String = ""

    Dim m_CutRadius As Integer = 5

    <Description("Occurs when the value, maximum and minimum value is changed.")> _
    Public Event ValueChanged(ByVal sender As System.Object, ByVal e As ValueChangedEventArgs)

#Region " Class ValueChangedEventArgs "

    <Description("Provides data for the ValueChangedEventArgs event.")> _
    Public Class ValueChangedEventArgs
        Inherits System.EventArgs

        Dim m_MaxValue As Integer
        Dim m_MinValue As Integer
        Dim m_Value As Integer

        <Description("Initializes a new instance of the ValueChangedEventArgs class.")> _
        Public Sub New(ByVal Value As Integer, ByVal MinValue As Integer, ByVal MaxValue As Integer)
            m_MaxValue = MaxValue
            m_MinValue = MinValue
            m_Value = Value
        End Sub

        <Description("Returns the progressbar's minimum value.")> _
        Public ReadOnly Property MinValue() As Integer
            Get
                Return m_MinValue
            End Get
        End Property

        <Description("Returns the progressbar's maximum value.")> _
        Public ReadOnly Property MaxValue() As Integer
            Get
                Return m_MaxValue
            End Get
        End Property

        <Description("Returns the progressbar's value.")> _
        Public ReadOnly Property Value() As Integer
            Get
                Return m_Value
            End Get
        End Property

    End Class

#End Region

    Public Sub New()

        InitializeComponent()

        Me.Size = New Size(100, 22)

    End Sub

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

    Public Function GetDrawTextToGraphicsBounds(ByVal g As Graphics, ByVal textToDraw As String, ByVal sizeToControl As Size, ByVal f As Font, ByVal foreColor As Color) As RectangleF

        Dim sb As New SolidBrush(foreColor)
        Dim sf As New StringFormat(StringFormatFlags.NoWrap)
        sf.Trimming = StringTrimming.EllipsisCharacter
        Dim ms As SizeF = g.MeasureString(textToDraw, f, sizeToControl, sf)

        Return New RectangleF(New PointF((sizeToControl.Width - ms.Width) / 2, (sizeToControl.Height - ms.Height) / 2), New SizeF(sizeToControl.Width, sizeToControl.Height))

    End Function

    Public Sub DrawTextToGraphics(ByVal g As Graphics, ByVal textToDraw As String, ByVal sizeToControl As Size, ByVal f As Font, ByVal foreColor As Color)

        Dim sb As New SolidBrush(foreColor)
        Dim sf As New StringFormat(StringFormatFlags.NoWrap)
        sf.Trimming = StringTrimming.EllipsisCharacter
        Dim ms As SizeF = g.MeasureString(textToDraw, f, sizeToControl, sf)
        Dim bounds As New RectangleF(New PointF((sizeToControl.Width - ms.Width) / 2, (sizeToControl.Height - ms.Height) / 2), New SizeF(sizeToControl.Width, sizeToControl.Height))

        g.DrawString(textToDraw, f, sb, bounds, sf)

    End Sub

    Private Sub GoProgressBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
    End Sub

    Private Sub GoProgressBar_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    ''' <summary>
    ''' Gets or sets the colors for blocks in the bar.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the colors for the blocks in the bar.")> _
    Public Property BlockColor As Color
        Get
            Return m_BlockColor
        End Get
        Set(ByVal value As Color)
            m_BlockColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the border color.")> _
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
    ''' Gets or sets the background color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the background color.")> _
    Public Property BackgroundColor As Color
        Get
            Return m_BackgroundColor
        End Get
        Set(ByVal value As Color)
            m_BackgroundColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the font to the text.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the font to the text.")> _
    Public Shadows Property TextFont As Font
        Get
            Return m_TextFont
        End Get
        Set(ByVal value As Font)
            m_TextFont = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the color to the text.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the color to the text.")> _
    Public Shadows Property TextColor As Color
        Get
            Return m_TextColor
        End Get
        Set(ByVal value As Color)
            m_TextColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the value.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the value.")> <DefaultValue(0)> _
    Public Property Value As Double
        Get
            Return m_Value
        End Get
        Set(ByVal value As Double)
            If value > m_MaxValue Then
                m_Value = m_MaxValue
            ElseIf value < m_MinValue Then
                m_Value = m_MinValue
            Else
                m_Value = value
            End If
            Me.Invalidate()
            RaiseEvent ValueChanged(Me, New ValueChangedEventArgs(m_Value, m_MinValue, m_MaxValue))
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the minimum value.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the minimum value.")> <DefaultValue(0)> _
    Public Property MinValue As Double
        Get
            Return m_MinValue
        End Get
        Set(ByVal value As Double)
            m_MinValue = value
            If m_MinValue > m_Value Then
                m_Value = m_MinValue
            ElseIf m_MinValue > m_MaxValue Then
                m_MaxValue = m_MinValue
            End If
            Me.Invalidate()
            RaiseEvent ValueChanged(Me, New ValueChangedEventArgs(m_Value, m_MinValue, m_MaxValue))
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the maximum value.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the maximum value.")> <DefaultValue(100)> _
    Public Property MaxValue As Double
        Get
            Return m_MaxValue
        End Get
        Set(ByVal value As Double)
            If value < m_Value Then
                m_MaxValue = m_Value
            ElseIf value < m_MinValue Then
                m_MaxValue = m_MinValue
            Else
                m_MaxValue = value
            End If
            Me.Invalidate()
            RaiseEvent ValueChanged(Me, New ValueChangedEventArgs(m_Value, m_MinValue, m_MaxValue))
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the cut for the radius on the border.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the cut for the radius on the border.")> <DefaultValue(5)> _
    Public Property CutRadius As Integer
        Get
            Return m_CutRadius
        End Get
        Set(ByVal value As Integer)
            m_CutRadius = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the icon.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the icon.")> _
    Public Property Icon As Image
        Get
            Return m_Icon
        End Get
        Set(ByVal value As Image)
            m_Icon = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the icon should be showed.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the icon should be showed.")> <DefaultValue(False)> _
    Public Property ShowIcon As Boolean
        Get
            Return m_ShowIcon
        End Get
        Set(ByVal value As Boolean)
            m_ShowIcon = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the text should be showed.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the text should be showed.")> <DefaultValue(True)> _
    Public Property ShowText As Boolean
        Get
            Return m_ShowText
        End Get
        Set(ByVal value As Boolean)
            m_ShowText = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the extra text.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the extra text.")> _
    Public Property ExtraText As String
        Get
            Return m_ExtraText
        End Get
        Set(ByVal value As String)
            m_ExtraText = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Returns the current percentage.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Returns the current percentage.")> _
    Public ReadOnly Property Percentage As Double
        Get
            Return (m_Value * 100) / m_MaxValue
        End Get
    End Property

    Private Sub GoProgressBar_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        'Fill the background color...
        e.Graphics.FillPath(New SolidBrush(m_BackgroundColor), DrawArc(New Rectangle(0, 0, Me.Width, Me.Height), m_CutRadius))

        'Draw the border...
        e.Graphics.DrawPath(New Pen(m_BorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))

        If m_ShowIcon Then

            'Draw the icon line...
            e.Graphics.DrawLine(New Pen(m_BorderColor, 1), New Point(Me.Height - 1, 1), New Point(Me.Height - 1, Me.Height - 2))

            'Draw the icon...
            If Not IsNothing(m_Icon) Then
                e.Graphics.DrawImage(m_Icon, New Rectangle(New Point((Me.Height - m_Icon.Height) / 2, (Me.Height - m_Icon.Height) / 2), m_Icon.Size))
            End If

            'Get the progressbar information...                          
            Dim h As Integer = Height - 1
            Dim drawWidth As Integer = (((Width - Me.Height - 1) / m_MaxValue) * m_Value)

            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed

            'Draw the block...
            e.Graphics.FillRectangle(New SolidBrush(m_BlockColor), New Rectangle(Me.Height, 1, drawWidth, h - 1))
            If m_Value < m_MaxValue And m_Value > m_MinValue Then e.Graphics.DrawLine(New Pen(m_BorderColor, 1), New Point(drawWidth + Me.Height - 1, 1), New Point(drawWidth + Me.Height - 1, h - 1))


            If m_ShowText Then

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

                'Draw text wall...
                Dim bounds As RectangleF = GetDrawTextToGraphicsBounds(e.Graphics, IIf(m_ExtraText <> "", m_ExtraText & " ", "") & (m_Value / m_MaxValue) * 100 & "%", New Size(Width + Me.Height, h), m_TextFont, m_TextColor)

                e.Graphics.FillPath(New SolidBrush(m_BackgroundColor), DrawArc(New Rectangle(bounds.X - 1, bounds.Y + 1, bounds.Width - bounds.X - 1, bounds.Height - bounds.Y - 1), 3))
                e.Graphics.DrawPath(New Pen(m_BorderColor, 1), DrawArc(New Rectangle(bounds.X - 1, bounds.Y + 1, bounds.Width - bounds.X - 1, bounds.Height - bounds.Y - 1), 3))

                'Draw text...
                DrawTextToGraphics(e.Graphics, IIf(m_ExtraText <> "", m_ExtraText & " ", "") & (m_Value * 100) / m_MaxValue & "%", New Size(Width + Me.Height - 1, h), m_TextFont, m_TextColor)

            End If
        Else

            'Get the progressbar information...                          
            Dim h As Integer = Height - 1
            Dim drawWidth As Integer = ((Width - 1) / m_MaxValue) * m_Value

            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed

            'Draw the block...
            e.Graphics.FillRectangle(New SolidBrush(m_BlockColor), New Rectangle(1, 1, drawWidth - 1, h - 1))
            If m_Value < m_MaxValue And m_Value > m_MinValue Then e.Graphics.DrawLine(New Pen(m_BorderColor, 1), New Point(drawWidth, 1), New Point(drawWidth, h - 1))


            If m_ShowText Then

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

                'Draw text wall...
                Dim bounds As RectangleF = GetDrawTextToGraphicsBounds(e.Graphics, IIf(m_ExtraText <> "", m_ExtraText & " ", "") & (m_Value * 100) / m_MaxValue & "%", New Size(Width, h), m_TextFont, m_TextColor)

                e.Graphics.FillPath(New SolidBrush(m_BackgroundColor), DrawArc(New Rectangle(bounds.X - 1, bounds.Y + 1, bounds.Width - bounds.X - 1, bounds.Height - bounds.Y - 1), 3))
                e.Graphics.DrawPath(New Pen(m_BorderColor, 1), DrawArc(New Rectangle(bounds.X - 1, bounds.Y + 1, bounds.Width - bounds.X - 1, bounds.Height - bounds.Y - 1), 3))

                'Draw text...
                DrawTextToGraphics(e.Graphics, IIf(m_ExtraText <> "", m_ExtraText & " ", "") & (m_Value * 100) / m_MaxValue & "%", New Size(Width - 1, h), m_TextFont, m_TextColor)

            End If
        End If

    End Sub

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property Font As Font
        Get
            Return Nothing
        End Get
        Set(ByVal value As Font)
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property ForeColor As Color
        Get
        End Get
        Set(ByVal value As Color)
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property BackColor As Color
        Get
        End Get
        Set(ByVal value As Color)
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property BackgroundImage As Image
        Get
            Return Nothing
        End Get
        Set(ByVal value As Image)
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property BackgroundImageLayout As ImageLayout
        Get
            Return ImageLayout.Tile
        End Get
        Set(ByVal value As ImageLayout)
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property BorderStyle As BorderStyle
        Get
            Return BorderStyle.None
        End Get
        Set(ByVal value As BorderStyle)
        End Set
    End Property
End Class