Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class CaptchaGenerator

#Region " ~ Structures & Enums ~"

    Structure CaptchaInfo
        Dim CaptchaImage As Image
        Dim CaptchaVerificationString As String
    End Structure

#End Region

#Region " ~ Public Properties & Functions ~ "

    Dim m_CaptchaSize As New Size(200, 200)

    Public Sub New(ByVal captchaSize As Size)
        m_CaptchaSize = captchaSize
    End Sub

    Public Sub New()

    End Sub

    Public Property CaptchaSize As Size
        Get
            Return m_CaptchaSize
        End Get
        Set(value As Size)
            m_CaptchaSize = value
        End Set
    End Property

    Public Function GenerateCaptcha(ByVal charCount As Integer) As CaptchaInfo
        Dim resultCapthaInfo As New CaptchaInfo
        Dim rnd As New Random()
        Dim bmp As New Bitmap(m_CaptchaSize.Width, m_CaptchaSize.Height, PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim drawRect As New RectangleF(0, 0, m_CaptchaSize.Width, m_CaptchaSize.Height)
        g.TextRenderingHint = TextRenderingHint.AntiAlias

        'Draw under background...
        Dim underHatchBrush As New HatchBrush(m_HatchStyles(rnd.Next(m_HatchStyles.Length - 1)), Color.FromArgb(rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255)), Color.White)
        g.FillRectangle(underHatchBrush, drawRect)

        'Draw the CAPTCHA text...
        resultCapthaInfo.CaptchaVerificationString = generateRandomNumber(charCount)
        Dim matrix As New Matrix
        For i As Integer = 0 To charCount - 1
            matrix.Reset()
            Dim x As Integer = (m_CaptchaSize.Width / (charCount + 1) * i) + 4
            If x.ToString.Contains("-") Then x = 0
            Dim y As Integer = m_CaptchaSize.Height / 2

            'Randomly rotate the text...
            matrix.RotateAt(rnd.Next(-45, 45), New PointF(x, y))
            g.Transform = matrix

            'Draw the random text...
            g.DrawString(resultCapthaInfo.CaptchaVerificationString(i), New Font(m_FontNames(rnd.Next(m_FontNames.Length - 1)), m_FontEmSizes(rnd.Next(m_FontEmSizes.Length - 1)), m_FontStyles(rnd.Next(m_FontStyles.Length - 1))), New SolidBrush(Color.FromArgb(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100))), x, rnd.Next(10, 40))
            g.ResetTransform()
        Next

        'Draw over background...
        Dim overHatchBrush As New HatchBrush(HatchStyle.LargeConfetti, Color.FromArgb(200, rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255)), Color.Transparent)
        g.FillRectangle(overHatchBrush, drawRect)

        resultCapthaInfo.CaptchaImage = bmp
        Return resultCapthaInfo
    End Function

#End Region

#Region " ~ Private Functions & Variables ~ "

    Dim m_BackgroundNoiseColor As Integer() = New Integer() {150, 150, 150}
    Dim m_TextColor As Integer() = New Integer() {64, 64, 64}
    Dim m_FontEmSizes As Integer() = New Integer() {15, 20, 25}
    Dim m_FontNames As String() = New String() {"Comic Sans MS", "Arial", "Times New Roman", "Georgia", "Verdana", "Geneva"}
    Dim m_FontStyles As FontStyle() = New FontStyle() {FontStyle.Bold, FontStyle.Italic, FontStyle.Regular, FontStyle.Strikeout, FontStyle.Underline}
    Dim m_HatchStyles As HatchStyle() = New HatchStyle() {HatchStyle.BackwardDiagonal, HatchStyle.Cross, HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal, HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical, HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross, HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid, HatchStyle.ForwardDiagonal, HatchStyle.Horizontal, HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard, HatchStyle.LargeConfetti, HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal, HatchStyle.LightUpwardDiagonal, HatchStyle.LightVertical, HatchStyle.Max, HatchStyle.Min, HatchStyle.NarrowHorizontal, HatchStyle.NarrowVertical, HatchStyle.OutlinedDiamond, HatchStyle.Plaid, HatchStyle.Shingle, HatchStyle.SmallCheckerBoard, HatchStyle.SmallConfetti, HatchStyle.SmallGrid, HatchStyle.SolidDiamond, HatchStyle.Sphere, HatchStyle.Trellis, HatchStyle.Vertical, HatchStyle.Wave, HatchStyle.Weave, HatchStyle.WideDownwardDiagonal, HatchStyle.WideUpwardDiagonal, HatchStyle.ZigZag}

    Private Function generateRandomNumber(ByVal numberCount As Integer) As String
        Dim resultString As String = ""
        Dim rnd As New Random()
        For i As Integer = 0 To numberCount - 1
            resultString &= Chr(rnd.Next(48, 57))
        Next
        Return resultString
    End Function

#End Region

End Class