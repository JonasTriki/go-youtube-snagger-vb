Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Security.Permissions
Imports System.Security
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes

<DefaultEvent("TextChanged")> _
Public Class GoTextBox

    Dim m_Disabled As Boolean
    Dim m_Selected As Boolean
    Dim m_Hover As Boolean

    Dim m_NormalIcon As Image
    Dim m_DisabledIcon As Image

    Dim m_BackgroundColor As Color = Color.FromArgb(255, 255, 255)

    Dim m_NormalBorderColor As Color = Color.FromArgb(160, 160, 160)
    Dim m_HoverBorderColor As Color = Color.FromArgb(130, 130, 130)
    Dim m_SelectedBorderColor As Color = Color.FromArgb(130, 130, 130)
    Dim m_DisabledBorderColor As Color = Color.FromArgb(180, 180, 180)

    Dim m_CutRadius As Integer = 5
    Dim m_ContextMenuStrip As ContextMenuStrip

    Dim m_AutoCompleteCustomSource As String()

    Dim m_UseFileNameCharacters As Boolean = False

    Dim m_Icon As Image
    Dim m_ShowIcon As Boolean = True
    Dim m_ShowIsReadOnlyIcon As Boolean = True

    Dim m_CustomButtonHover As Boolean
    Dim m_CustomButtonPressed As Boolean
    Dim m_imgCustomButtonNormal As Image
    Dim m_imgCustomButtonHover As Image
    Dim m_imgCustomButtonPressed As Image
    Dim m_ShowCustomButtonIcon As Boolean

    <Description("Occurs when the text changes.")> _
    Public Shadows Event TextChanged As EventHandler
    Public Shadows Event KeyDown As KeyEventHandler
    Public Event CustomButtonClick As MouseEventHandler

    Public Sub New()
        InitializeComponent()
        Me.Size = New Size(150, 22)
    End Sub

    Private Sub CheckIconVisibility()
        If m_ShowIcon Then
            txtText.Location = New Point(26, 3)
            txtText.Size = New Size(Me.Width - If(m_ShowIsReadOnlyIcon And txtText.ReadOnly Or m_ShowCustomButtonIcon, 46, 28), Me.Height - 6)

            Me.Invalidate()
        Else
            txtText.Location = New Point(3, 3)
            txtText.Size = New Size(Me.Width - If(m_ShowIsReadOnlyIcon And txtText.ReadOnly Or m_ShowCustomButtonIcon, 24, 6), Me.Height - 6)

            Me.Invalidate()
        End If
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

    Private Function CheckForBadCharaters(ByVal inputString As String) As String

        Dim outputString As String = inputString

        For Each nAC As String In Split("\ / : * ? "" < > |")
            If outputString.Contains(nAC) Then
                outputString = outputString.Replace(nAC, "")
            End If
        Next

        Return outputString

    End Function

    ''' <summary>
    ''' Returns the GoTextBox.
    ''' </summary>
    ''' <remarks></remarks>
    <Browsable(False)> _
    Public ReadOnly Property [Object] As GoTextBox
        Get
            Return Me
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets maximum length of the string in the textbox.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets maximum length of the string in the textbox.")> _
    Public Property MaxLength As Integer
        Get
            Return txtText.MaxLength
        End Get
        Set(ByVal value As Integer)
            txtText.MaxLength = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the textbox only should not allow the filename charaters.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the textbox only should not allow the filename charaters.")> <DefaultValue(False)> _
    Public Property UseFileNameCharacters As Boolean
        Get
            Return m_UseFileNameCharacters
        End Get
        Set(ByVal value As Boolean)
            m_UseFileNameCharacters = value
            If value Then
                txtText.Text = CheckForBadCharaters(txtText.Text)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the AutoCompleteSource.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the AutoCompleteSource.")> <DefaultValue(True)> _
    Public Property AutoCompleteSource As AutoCompleteSource
        Get
            Return txtText.AutoCompleteSource
        End Get
        Set(ByVal value As AutoCompleteSource)
            If Not txtText.AutoCompleteSource = value = value Then
                txtText.AutoCompleteSource = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the AutoCompleteMode.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the AutoCompleteMode.")> <DefaultValue(True)> _
    Public Property AutoCompleteMode As AutoCompleteMode
        Get
            Return txtText.AutoCompleteMode
        End Get
        Set(ByVal value As AutoCompleteMode)
            If Not txtText.AutoCompleteMode = value = value Then
                txtText.AutoCompleteMode = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the AutoCompleteCustomSource.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the AutoCompleteCustomSource.")> <DefaultValue(True)> _
    Public Property AutoCompleteCustomSource As String()
        Get
            Return m_AutoCompleteCustomSource
        End Get
        Set(ByVal value As String())
            If Not m_AutoCompleteCustomSource Is value Then
                m_AutoCompleteCustomSource = value
                txtText.AutoCompleteCustomSource.Clear()
                txtText.AutoCompleteCustomSource.AddRange(value)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the image to be previewed.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the image to be previewed.")> _
    Public Property Icon As Image
        Get
            Return m_Icon
        End Get
        Set(ByVal value As Image)
            If Not IsNothing(value) Then
                m_NormalIcon = value
                m_DisabledIcon = GrayScaleConverter.ColorImageToGrayScaleImage(value)
                m_Icon = If(Enabled, m_NormalIcon, m_DisabledIcon)
                Me.Invalidate()
            Else
                m_NormalIcon = Nothing
                m_DisabledIcon = Nothing
                m_Icon = Nothing
            End If
        End Set
    End Property

    Public Property imgCustomButtonNormal As Image
        Get
            Return m_imgCustomButtonNormal
        End Get
        Set(ByVal value As Image)
            m_imgCustomButtonNormal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property imgCustomButtonHover As Image
        Get
            Return m_imgCustomButtonHover
        End Get
        Set(ByVal value As Image)
            m_imgCustomButtonHover = value
            Me.Invalidate()
        End Set
    End Property

    Public Property imgCustomButtonPressed As Image
        Get
            Return m_imgCustomButtonPressed
        End Get
        Set(ByVal value As Image)
            m_imgCustomButtonPressed = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the read-only icon should be showed, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the read-only icon should be showed, or not.")> <DefaultValue(True)> _
    Public Property ShowIsReadOnlyIcon As Boolean
        Get
            Return m_ShowIsReadOnlyIcon
        End Get
        Set(ByVal value As Boolean)
            m_ShowIsReadOnlyIcon = value
            CheckIconVisibility()
        End Set
    End Property

    '
    ''' <summary>
    ''' Gets or sets indicating if the custom button icon should be showed, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the custom button icon should be showed, or not.")> <DefaultValue(False)> _
    Public Property ShowCustomButtonIcon As Boolean
        Get
            Return m_ShowCustomButtonIcon
        End Get
        Set(ByVal value As Boolean)
            m_ShowCustomButtonIcon = value
            CheckIconVisibility()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the icon should be showed, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the icon should be showed, or not.")> <DefaultValue(True)> _
    Public Property ShowIcon As Boolean
        Get
            Return m_ShowIcon
        End Get
        Set(ByVal value As Boolean)
            m_ShowIcon = value
            CheckIconVisibility()
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
    ''' Gets or sets the context menu strip.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the context menu strip.")> <DefaultValue(False)> _
    Public Shadows Property ContextMenuStrip As ContextMenuStrip
        Get
            Return m_ContextMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            If Not m_ContextMenuStrip Is value Then
                If Not value Is Nothing Then
                    m_ContextMenuStrip = value
                    MyBase.ContextMenuStrip = value
                    txtText.ContextMenuStrip = value
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the textbox should use the system password char, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the textbox should use the system password char, or not.")> <DefaultValue(False)> _
    Public Property UseSystemPasswordChar As Boolean
        Get
            Return txtText.UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            txtText.UseSystemPasswordChar = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the password char.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the password char.")> _
    Public Property PasswordChar As Char
        Get
            Return txtText.PasswordChar
        End Get
        Set(ByVal value As Char)
            txtText.PasswordChar = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the textbox should be multiline, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the textbox should be multiline, or not.")> <DefaultValue(False)> _
    Public Property MultiLine As Boolean
        Get
            Return txtText.Multiline
        End Get
        Set(ByVal value As Boolean)
            txtText.Multiline = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the scrollbars to the textbox.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the scrollbars to the textbox.")> <DefaultValue(GetType(ScrollBars), "0")> _
    Public Property ScrollBars As ScrollBars
        Get
            Return txtText.ScrollBars
        End Get
        Set(ByVal value As ScrollBars)
            txtText.ScrollBars = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the textbox should be read only, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the textbox should be read only, or not.")> <DefaultValue(False)> _
    Public Property IsReadOnly As Boolean
        Get
            Return txtText.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            txtText.ReadOnly = value
            txtText.BackColor = m_BackgroundColor
            CheckIconVisibility()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the text to the control.")> <Browsable(True)> <Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")> _
    Public Overrides Property [Text] As String
        Get
            Return txtText.Text
        End Get
        Set(ByVal value As String)
            txtText.Text = value
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
            txtText.BackColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the normal border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the normal border color.")> _
    Public Property NormalBorderColor As Color
        Get
            Return m_NormalBorderColor
        End Get
        Set(ByVal value As Color)
            m_NormalBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the hover border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the hover border color.")> _
    Public Property HoverBorderColor As Color
        Get
            Return m_HoverBorderColor
        End Get
        Set(ByVal value As Color)
            m_HoverBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the selected border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the selected border color.")> _
    Public Property SelectedBorderColor As Color
        Get
            Return m_SelectedBorderColor
        End Get
        Set(ByVal value As Color)
            m_SelectedBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the disabled border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the disabled border color.")> _
    Public Property DisabledBorderColor As Color
        Get
            Return m_DisabledBorderColor
        End Get
        Set(ByVal value As Color)
            m_DisabledBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Return's the control's disabled state.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Return's the control's disabled state.")> _
    Public ReadOnly Property Disabled As Boolean
        Get
            Return m_Disabled
        End Get
    End Property

    ''' <summary>
    ''' Return's the controls selected state.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Return's the control's selected state.")> _
    Public ReadOnly Property Selected As Boolean
        Get
            Return m_Selected
        End Get
    End Property

    ''' <summary>
    ''' Return's the controls hover state.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Return's the control's hover state.")> _
    Public ReadOnly Property Hover As Boolean
        Get
            Return m_Hover
        End Get
    End Property

    Private Sub txtText_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtText.KeyPress
        If m_UseFileNameCharacters Then
            e.Handled = True
            If Not (e.KeyChar = "\" Or e.KeyChar = "/" Or e.KeyChar = ":" Or e.KeyChar = "*" Or e.KeyChar = """" Or e.KeyChar = "<" Or e.KeyChar = ">" Or e.KeyChar = "|") Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub txtText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtText.TextChanged
        RaiseEvent TextChanged(sender, e)
        m_Selected = True
        m_Hover = False
        Me.Invalidate()
        txtText.Select()
    End Sub

    Private Sub GoTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        RaiseEvent KeyDown(sender, e)
    End Sub

    Private Sub GoTextBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        CheckIconVisibility()
    End Sub

    Private Sub GoTextBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Invalidate()
    End Sub

    Private Sub GoTextBox_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged

        m_Disabled = Not Enabled

        m_Icon = If(Enabled, m_NormalIcon, m_DisabledIcon)

        txtText.BackColor = m_BackgroundColor

        Me.Invalidate()

    End Sub

    Private Sub GoTextBox_FontChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FontChanged
        txtText.Font = Me.Font
    End Sub

    Private Sub GoTextBox_ForeColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ForeColorChanged
        txtText.ForeColor = Me.ForeColor
    End Sub

    Private Sub GoTextBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        'Fill the background color...
        e.Graphics.FillPath(New SolidBrush(m_BackgroundColor), DrawArc(New Rectangle(0, 0, Me.Width, Me.Height), m_CutRadius))

        'Draw the border...
        If m_Disabled Then
            e.Graphics.DrawPath(New Pen(m_DisabledBorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))
        ElseIf m_Selected Then
            e.Graphics.DrawPath(New Pen(m_SelectedBorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))
        ElseIf m_Hover Then
            e.Graphics.DrawPath(New Pen(m_HoverBorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))
        Else
            e.Graphics.DrawPath(New Pen(m_NormalBorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))
        End If

        If m_ShowIcon Then

            'Draw the icon...
            If Not IsNothing(m_Icon) Then
                e.Graphics.DrawImage(m_Icon, New Rectangle(3, 3, 16, 16))
            End If

            'Draw the border line, for the icon box...
            If m_Disabled Then
                e.Graphics.DrawLine(New Pen(m_DisabledBorderColor, 1), 22, 0, 22, Me.Height - 1)
            ElseIf m_Selected Then
                e.Graphics.DrawLine(New Pen(m_SelectedBorderColor, 1), 22, 0, 22, Me.Height - 1)
            ElseIf m_Hover Then
                e.Graphics.DrawLine(New Pen(m_HoverBorderColor, 1), 22, 0, 22, Me.Height - 1)
            Else
                e.Graphics.DrawLine(New Pen(m_NormalBorderColor, 1), 22, 0, 22, Me.Height - 1)
            End If

        End If

        'Draw the read-only icon OR the custom button icon...
        If txtText.ReadOnly Then
            If m_ShowIsReadOnlyIcon Then
                e.Graphics.DrawImage(My.Resources.lock, New Rectangle(Me.Width - 19, 3, 16, 16))
            End If
        ElseIf m_ShowCustomButtonIcon Then
            If m_CustomButtonHover Then
                If Not IsNothing(m_imgCustomButtonHover) Then
                    e.Graphics.DrawImage(m_imgCustomButtonHover, New Rectangle(Me.Width - 19, 3, 16, 16))
                End If
            ElseIf m_CustomButtonPressed Then
                If Not IsNothing(m_imgCustomButtonPressed) Then
                    e.Graphics.DrawImage(m_imgCustomButtonPressed, New Rectangle(Me.Width - 19, 3, 16, 16))
                End If
            Else
                If Not IsNothing(m_imgCustomButtonNormal) Then
                    e.Graphics.DrawImage(m_imgCustomButtonNormal, New Rectangle(Me.Width - 19, 3, 16, 16))
                End If
            End If
        End If
    End Sub

    Private Sub Controls_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        If m_ShowCustomButtonIcon Then
            m_CustomButtonHover = False
            m_CustomButtonPressed = False
            Me.Invalidate()
        Else
            If Not m_Selected Then
                m_Hover = False
                Me.Invalidate()
            End If
        End If
    End Sub

    Private Sub txtText_MouseLeave(sender As Object, e As System.EventArgs) Handles txtText.MouseLeave
        If Not m_Selected Then
            m_Hover = False
            Me.Invalidate()
        End If
    End Sub

    Private Sub GoTextBox_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If (Me.RectangleToScreen(New Rectangle(Me.Width - 19, 3, 16, 16)).Contains(Me.PointToScreen(New Point(MousePosition.X - Me.ParentForm.Location.X, MousePosition.Y - Me.ParentForm.Location.Y))) Or Me.RectangleToScreen(New Rectangle(Me.Width - 19, 3, 16, 16)).Contains(Me.PointToScreen(New Point(e.X, e.Y)))) And m_ShowCustomButtonIcon Then
            m_CustomButtonHover = True
            m_CustomButtonPressed = False
            Me.Invalidate()
        End If
    End Sub

    Private Sub Controls_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        If (Me.RectangleToScreen(New Rectangle(Me.Width - 19, 3, 16, 16)).Contains(Me.PointToScreen(New Point(MousePosition.X - Me.ParentForm.Location.X, MousePosition.Y - Me.ParentForm.Location.Y)))) And m_ShowCustomButtonIcon Then
            m_CustomButtonHover = True
            m_CustomButtonPressed = False
            Me.Invalidate()
        Else
            If Not m_Selected Then
                m_Hover = True
                Me.Invalidate()
            End If
        End If
    End Sub

    Private Sub txtText_MouseEnter(sender As Object, e As System.EventArgs) Handles txtText.MouseEnter
        If Not m_Selected Then
            m_Hover = True
            Me.Invalidate()
        End If
    End Sub

    Private Sub Controls_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus, Me.GotFocus, txtText.GotFocus
        If Not m_Selected Then
            Focus()
            m_Selected = True
            m_Hover = False
            Me.Invalidate()
            txtText.Focus()
            txtText.Select()
        End If
    End Sub

    Private Sub Controls_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If (Me.RectangleToScreen(New Rectangle(Me.Width - 19, 3, 16, 16)).Contains(Me.PointToScreen(New Point(MousePosition.X - Me.ParentForm.Location.X, MousePosition.Y - Me.ParentForm.Location.Y))) Or Me.RectangleToScreen(New Rectangle(Me.Width - 19, 3, 16, 16)).Contains(Me.PointToScreen(New Point(e.X, e.Y)))) And m_ShowCustomButtonIcon Then
            m_CustomButtonHover = False
            m_CustomButtonPressed = True
            Me.Invalidate()
        Else
            Focus()
            m_Selected = True
            m_Hover = False
            Me.Invalidate()
            txtText.Focus()
            txtText.Select()
        End If
    End Sub

    Private Sub txtText_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtText.MouseDown
        Focus()
        m_Selected = True
        m_Hover = False
        Me.Invalidate()
        txtText.Focus()
        txtText.Select()
    End Sub

    Private Sub Controls_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If (Me.RectangleToScreen(New Rectangle(Me.Width - 19, 3, 16, 16)).Contains(Me.PointToScreen(New Point(MousePosition.X - Me.ParentForm.Location.X, MousePosition.Y - Me.ParentForm.Location.Y))) Or Me.RectangleToScreen(New Rectangle(Me.Width - 19, 3, 16, 16)).Contains(Me.PointToScreen(New Point(e.X, e.Y)))) And m_ShowCustomButtonIcon Then
            m_CustomButtonHover = True
            m_CustomButtonPressed = False
            Me.Invalidate()
            RaiseEvent CustomButtonClick(Me, e)
        ElseIf m_ShowCustomButtonIcon Then
            m_CustomButtonHover = False
            m_CustomButtonPressed = False
            Me.Invalidate()
        End If
    End Sub

    Private Sub Controls_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave, Me.Leave
        If m_Hover Or m_Selected Then
            m_Hover = False
            m_Selected = False
            Me.Invalidate()
        End If
    End Sub

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