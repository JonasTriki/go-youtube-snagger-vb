Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class InfoBar

    Dim m_ExtraButtonSelected As Boolean = False
    Dim m_ExtraButtonBorderColor As Color = Color.FromArgb(130, 130, 130)
    Dim m_ExtraButtonBorderColorDisabled As Color = Color.FromArgb(130, 130, 130)
    Dim m_ExtraButtonBorderColorSelected As Color = Color.FromArgb(140, 181, 90)
    Dim m_ExtraButtonBackgroundColor As Color = Color.FromArgb(160, 160, 160)
    Dim m_ExtraButtonBackgroundColorDisabled As Color = Color.FromArgb(180, 180, 180)
    Dim m_ExtraButtonBackgroundColorSelected As Color = Color.FromArgb(204, 255, 133)
    Dim m_ExtraButtonCaptionColor As Color = Color.White
    Dim m_ExtraButtonCaptionColorDisabled As Color = Color.White
    Dim m_ExtraButtonCaptionColorSelected As Color = Color.FromArgb(83, 125, 125)
    Dim m_ExtraButtonCaptionFont As New Font("Segoe UI", 10.0, FontStyle.Bold, GraphicsUnit.World)
    Dim m_ExtraButtonCaption As String = "Télécharger..."

    Dim m_BackgroundColor As Color = Color.FromArgb(254, 235, 106)
    Dim m_BackgroundColor2 As Color = Color.FromArgb(231, 192, 33)

    Dim m_BorderColor As Color = Color.FromArgb(172, 140, 28)

    Dim m_Message As String
    Dim m_ShowExtraButton As Boolean = False

    Dim m_ContextMenuStrip As ContextMenuStrip
    Dim m_CloseButtonContextMenuStrip As ContextMenuStrip

    Public Event Showed As EventHandler
    Public Event Closed As EventHandler
    Public Event ExtraButtonClicked As MouseEventHandler

    Public Sub New()

        InitializeComponent()

        Me.MaximumSize = New Size(0, 22)
        Me.MinimumSize = New Size(41, 22)

        Me.Dock = DockStyle.Top

    End Sub

    Private Sub checkInfoTextSize()
        InfoText.Size = New Size(Me.Width - If(m_ShowExtraButton, 154, 52), InfoText.Height)
    End Sub

    Public Sub DrawTextToGraphics(ByVal g As Graphics, ByVal textToDraw As String, ByVal sizeToControl As Size, ByVal f As Font, ByVal foreColor As Color)

        Dim sb As New SolidBrush(foreColor)
        Dim sf As New StringFormat(StringFormatFlags.NoWrap)
        sf.Trimming = StringTrimming.EllipsisCharacter
        Dim ms As SizeF = g.MeasureString(textToDraw, f, sizeToControl, sf)
        Dim bounds As New RectangleF(New PointF((sizeToControl.Width - ms.Width) / 2, (sizeToControl.Height - ms.Height) / 2), New SizeF(sizeToControl.Width, sizeToControl.Height))

        g.DrawString(textToDraw, f, sb, bounds, sf)

    End Sub

    Public Function DrawArc(ByVal Rectangle As Rectangle, Optional ByVal Radius As Integer = 2) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    Private Sub InfoBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
        InfoText.Text = m_Message
    End Sub

    Private Sub InfoBar_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        'Draw the gradient background color...
        Dim Brush As New LinearGradientBrush(New Point(0, 0), New Point(0, Me.Height - 1), m_BackgroundColor, m_BackgroundColor2)
        e.Graphics.FillRectangle(Brush, New Rectangle(0, 0, Me.Width, Me.Height))

        'Draw the border line on the bottom...
        e.Graphics.DrawLine(New Pen(m_BorderColor, 1), New Point(0, Me.Height - 1), New Point(Me.Width, Me.Height - 1))

    End Sub

    <Description("Get or sets the caption to the extrac button.")> _
    Public Property ExtraButtonCaption() As String
        Get
            Return m_ExtraButtonCaption
        End Get
        Set(ByVal value As String)
            m_ExtraButtonCaption = value
            pExtraBtn.Invalidate()
        End Set
    End Property

    <Description("Get or sets the first background color to the control.")> _
    Public Property BackgroundColor() As Color
        Get
            Return m_BackgroundColor
        End Get
        Set(ByVal value As Color)
            m_BackgroundColor = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Get or sets the second background color to the control.")> _
    Public Property BackgroundColor2() As Color
        Get
            Return m_BackgroundColor2
        End Get
        Set(ByVal value As Color)
            m_BackgroundColor2 = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Get or sets the border color to the control.")> _
    Public Property BorderColor() As Color
        Get
            Return m_BorderColor
        End Get
        Set(ByVal value As Color)
            m_BorderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Get or sets the message to the control.")> <DefaultValue(True)> _
    Public Property Message() As String
        Get
            Return m_Message
        End Get
        Set(ByVal value As String)
            m_Message = value
            InfoText.Text = m_Message
        End Set
    End Property

    <Description("Get or sets the visibility fo the extra button.")> _
    Public Property ShowExtraButton() As Boolean
        Get
            Return m_ShowExtraButton
        End Get
        Set(ByVal value As Boolean)
            m_ShowExtraButton = value
            pExtraBtn.Visible = m_ShowExtraButton
            checkInfoTextSize()
        End Set
    End Property

    <Description("Get or sets the font to the control.")> _
    Public Overloads Property Font() As Font
        Get
            Return InfoText.Font
        End Get
        Set(ByVal value As Font)
            InfoText.Font = value
        End Set
    End Property

    <Description("Get or sets indicating if the close button is visible.")> <DefaultValue(True)> _
    Public Property CloseButtonVisible() As Boolean
        Get
            Return InfoCloseBtn.Visible
        End Get
        Set(ByVal value As Boolean)
            InfoCloseBtn.Visible = value
        End Set
    End Property

    <Description("Get or sets indicating if the close button is enabled.")> <DefaultValue(True)> _
    Public Property CloseButtonEnabled() As Boolean
        Get
            Return InfoCloseBtn.Enabled
        End Get
        Set(ByVal value As Boolean)
            InfoCloseBtn.Enabled = value
        End Set
    End Property

    <Description("Get or sets the CloseButtonContextMenuStrip for the control.")> _
    Public Property CloseButtonContextMenuStrip() As ContextMenuStrip
        Get
            Return m_CloseButtonContextMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            m_CloseButtonContextMenuStrip = value
        End Set
    End Property

    <Description("Get or sets the ContextMenuStrip for the control.")> _
    Public Overloads Property ContextMenuStrip() As ContextMenuStrip
        Get
            Return m_ContextMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            m_ContextMenuStrip = value
        End Set
    End Property

    <Description("Gets or sets the textalgin to the control.")> _
    <Browsable(True)> <DefaultValue(ContentAlignment.TopLeft)> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return InfoText.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            InfoText.TextAlign = value
        End Set
    End Property

    <Description("Gets or sets the icon to the control.")> _
    Public Property Icon() As Image
        Get
            Return InfoIcon.Image
        End Get
        Set(ByVal value As Image)
            InfoIcon.Image = value
        End Set
    End Property

    Private Sub InfoCloseBtn_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoCloseBtn.MouseEnter
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.close_Hover
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoCloseBtn.MouseDown
        If InfoCloseBtn.Enabled Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                InfoCloseBtn.Image = My.Resources.close_Pressed
            End If
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoCloseBtn.MouseUp
        If InfoCloseBtn.Enabled Then
            If e.Button = Windows.Forms.MouseButtons.Left And InfoCloseBtn.RectangleToScreen(InfoCloseBtn.ClientRectangle).Contains(InfoCloseBtn.PointToScreen(New Point(MousePosition.X - Me.ParentForm.Location.X, MousePosition.Y - Me.ParentForm.Location.Y))) Or InfoCloseBtn.RectangleToScreen(InfoCloseBtn.ClientRectangle).Contains(InfoCloseBtn.PointToScreen(New Point(e.X, e.Y))) Then
                InfoCloseBtn.Image = My.Resources.close_Hover
                Me.Visible = False
                RaiseEvent Closed(Me, New EventArgs)
            End If
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoCloseBtn.MouseLeave
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.close_Normal
        End If
    End Sub

    Private Sub InfoCloseBtn_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoCloseBtn.EnabledChanged
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.close_Normal
        Else
            InfoCloseBtn.Image = My.Resources.close_Disabled
        End If
    End Sub

    Private Sub InfoBar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.close_Normal
        End If
    End Sub

    Private Sub InfoBar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.close_Disabled
        End If
    End Sub

    Private Sub InfoBar_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            RaiseEvent Showed(Me, New EventArgs)
            My.Computer.Audio.Play(My.Resources.Information_Bar, AudioPlayMode.Background)
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoCloseBtn.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not IsNothing(m_CloseButtonContextMenuStrip) Then
                m_CloseButtonContextMenuStrip.Show(Me.ParentForm, New Point(MousePosition.X - Me.ParentForm.Location.X - 8, MousePosition.Y - Me.ParentForm.Location.Y - 31))
            End If
        End If
    End Sub

    Private Sub InfoText_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoText.MouseClick, InfoIcon.MouseClick, MyBase.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not IsNothing(m_ContextMenuStrip) Then
                m_ContextMenuStrip.Show(Me.ParentForm, New Point(MousePosition.X - Me.ParentForm.Location.X - 8, MousePosition.Y - Me.ParentForm.Location.Y - 30))
            End If
        End If
    End Sub

#Region " Obsolete properties "

    <Browsable(False)> _
    <EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property MinimumSize() As Size
        Get
        End Get
        Set(ByVal value As Size)
        End Set
    End Property

    <Browsable(False)> _
    <EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property MaximumSize() As Size
        Get
        End Get
        Set(ByVal value As Size)
        End Set
    End Property

#End Region

    Private Sub InfoBar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Invalidate()
    End Sub

    Private Sub pExtraBtn_MouseEnter(sender As Object, e As System.EventArgs) Handles pExtraBtn.MouseEnter
        If Me.Enabled Then
            m_ExtraButtonSelected = True
            Me.Invalidate()
        End If
    End Sub

    Private Sub pExtraBtn_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pExtraBtn.MouseDown
        If Me.Enabled Then
            m_ExtraButtonSelected = True
            Me.Invalidate()
        End If
    End Sub

    Private Sub pExtraBtn_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pExtraBtn.MouseUp
        If Me.Enabled Then
            If Me.RectangleToScreen(Me.ClientRectangle).Contains(Me.PointToScreen(New Point(MousePosition.X - Me.ParentForm.Location.X, MousePosition.Y - Me.ParentForm.Location.Y))) Or Me.RectangleToScreen(Me.ClientRectangle).Contains(Me.PointToScreen(New Point(e.X, e.Y))) Then
                m_ExtraButtonSelected = True
                Me.Invalidate()
                RaiseEvent ExtraButtonClicked(Me, e)
            Else
                m_ExtraButtonSelected = False
                Me.Invalidate()
            End If
        End If
    End Sub

    Private Sub pExtraBtn_MouseLeave(sender As Object, e As System.EventArgs) Handles pExtraBtn.MouseLeave
        If Me.Enabled Then
            m_ExtraButtonSelected = False
            Me.Invalidate()
        End If
    End Sub

    Private Sub pExtraBtn_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pExtraBtn.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim drawingRect As New Rectangle(0, 0, pExtraBtn.Width - 1, pExtraBtn.Height - 1)

        'Fill the backgroundcolor...
        If m_ExtraButtonSelected Then
            e.Graphics.FillPath(New SolidBrush(m_ExtraButtonBackgroundColorSelected), DrawArc(drawingRect))
        ElseIf Not Me.Enabled Then
            e.Graphics.FillPath(New SolidBrush(m_ExtraButtonBackgroundColorDisabled), DrawArc(drawingRect))
        Else
            e.Graphics.FillPath(New SolidBrush(m_ExtraButtonBackgroundColor), DrawArc(drawingRect))
        End If

        'Draw the border...
        If m_ExtraButtonSelected Then
            e.Graphics.DrawPath(New Pen(m_ExtraButtonBorderColorSelected, 1), DrawArc(drawingRect))
        ElseIf Not Me.Enabled Then
            e.Graphics.DrawPath(New Pen(m_ExtraButtonBorderColorDisabled, 1), DrawArc(drawingRect))
        Else
            e.Graphics.DrawPath(New Pen(m_ExtraButtonBorderColor, 1), DrawArc(drawingRect))
        End If

        'Draw the text...
        If m_ExtraButtonSelected Then
            DrawTextToGraphics(e.Graphics, m_ExtraButtonCaption, drawingRect.Size, m_ExtraButtonCaptionFont, m_ExtraButtonCaptionColorSelected)
        ElseIf Not Me.Enabled Then
            DrawTextToGraphics(e.Graphics, m_ExtraButtonCaption, drawingRect.Size, m_ExtraButtonCaptionFont, m_ExtraButtonCaptionColorDisabled)
        Else
            DrawTextToGraphics(e.Graphics, m_ExtraButtonCaption, drawingRect.Size, m_ExtraButtonCaptionFont, m_ExtraButtonCaptionColor)
        End If
    End Sub
End Class

