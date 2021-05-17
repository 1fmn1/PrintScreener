Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.InteropServices
Public Class Form1
    Private Enum SavingMode As Integer
        SMODE_CLIPBOARD = 0
        SMODE_WEBLINK = 1
    End Enum
    'Dim mystream As New StreamReader(My.Resources.Image1)
    'Dim mycursor As Cursor = New Cursor()
    Dim MySavingMode As SavingMode = 0
    Dim Inputbox As HtmlElement
    Dim ButtonBox As HtmlElement
    Dim Imgur As New ImgurSharp.Imgur("f9dbe5ee44f2562")
    Dim ImgurImg As ImgurSharp.ImgurImage '= New ImgurSharp.ImgurImage()
    Dim xyFormatString As String = "X={0} ; Y={1}"
    ' Public FileName As String = "Screen.png"
    <DllImport("USER32.DLL", CharSet:=CharSet.Unicode)>
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function
    <DllImport("USER32.DLL")>
    Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function
    'Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer
    Public Enum HotKeyModifiers As Integer
        MOD_ALT = &H1
        MOD_CONTROL = &H2
        MOD_SHIFT = &H4
        MOD_WIN = &H8
    End Enum
    Private Const WM_HOTKEY As Integer = &H312
    Declare Auto Function RegisterHotKey Lib "user32" (ByVal hWnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Boolean
    Declare Auto Function UnregisterHotKey Lib "user32" (ByVal hWnd As IntPtr, ByVal id As Integer) As Boolean
    Friend MouseAltPressed As Boolean, MousePressed As Boolean, Running As Boolean
    Dim startX As Integer, startY As Integer, startx1 As Integer, starty1 As Integer, mp As New Media.SoundPlayer, PenColor As New Pen(System.Drawing.Color.Red), helpBit As Bitmap
#Region "FormEvents"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RegisterHotKey(Me.Handle, 1020, HotKeyModifiers.MOD_SHIFT, Keys.Insert)
        'RegisterHotKey(Me.Handle, 1020, HotKeyModifiers.MOD_CONTROL, Keys.Insert)
        'TextBox11 = New Label With {.Visible = True, .Location = New Point(0, 0), .Text = "X=0 ; Y=0", .ForeColor = Color.Gold, .BackColor = Color.White, .AutoSize = True}
        Me.Top = Screen.PrimaryScreen.Bounds.Top
        Me.Left = Screen.PrimaryScreen.Bounds.Left
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.Visible = False
        NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
        NotifyIcon1.Visible = True
        PenColor.Width = 3
        mp.Stream = My.Resources.fotospusk
    End Sub
    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            helpBit.Dispose()
            Me.Hide()
        End If
        If e.KeyCode = Keys.F11 Then
            MySavingMode = SavingMode.SMODE_CLIPBOARD
        End If
        If e.KeyCode = Keys.F12 Then
            MySavingMode = SavingMode.SMODE_WEBLINK
        End If
    End Sub

    Private Sub Form2_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        Dim helpx As Integer, helpy As Integer, helpBool As Boolean

        startX = e.X : startY = e.Y : startx1 = e.X : starty1 = e.Y

        If e.Button = MouseButtons.Left Then
            MousePressed = True
            Do While MousePressed = True
                Application.DoEvents()
                Me.Invalidate()
            Loop
        ElseIf e.Button = MouseButtons.Right Then
            MouseAltPressed = True

            Dim altGraphics As Graphics = Graphics.FromImage(helpBit)
            Do While MouseAltPressed = True
                Application.DoEvents()
                If helpBool = False Then
                    altGraphics.FillEllipse(Brushes.Red, New Rectangle(startX - 1, startY - 1, 3, 3))
                    helpBool = True
                Else
                    altGraphics.DrawLine(PenColor, startX, startY, helpx, helpy)
                End If
                helpx = startX
                helpy = startY
                Me.Invalidate()
            Loop
            altGraphics.Dispose()
            helpBool = False
        End If
    End Sub

    Private Sub Form2_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        TextBox11.Location = New Point(e.X + 5, e.Y + 5)
        TextBox11.Text = String.Format(xyFormatString, e.X, e.Y)
        If MousePressed = True Or MouseAltPressed = True Then
            startX = e.X
            startY = e.Y
        End If
    End Sub

    Private Async Sub Form2_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Dim MyImage() As Byte
        If e.Button = MouseButtons.Left Then
                Dim x As Integer, y As Integer
                MousePressed = False
                If Math.Abs(startx1 - e.X) < 15 Or Math.Abs(starty1 - e.Y) < 15 _
                    Then : Me.Hide() : helpBit.Dispose() : Exit Sub
                End If
                Me.Hide()
                Application.DoEvents()
                Dim bmp As Bitmap = New Bitmap(Math.Abs(startx1 - e.X), Math.Abs(starty1 - e.Y))
                Dim scr As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmp)
                If startx1 > e.X Then : x = e.X : Else : x = startx1 : End If
                If starty1 > e.Y Then : y = e.Y : Else : y = starty1 : End If
                scr.CopyFromScreen(x, y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy)
                scr.DrawImage(helpBit, New Rectangle(New Point(0, 0), bmp.Size), New Rectangle(New Point(x, y), bmp.Size), GraphicsUnit.Pixel)
                bmp.Save("Screen.png", Imaging.ImageFormat.Png)
            If MySavingMode = SavingMode.SMODE_CLIPBOARD Then
                My.Computer.Clipboard.SetImage(bmp)
            ElseIf MySavingMode = SavingMode.SMODE_WEBLINK Then
                MyImage = File.ReadAllBytes("Screen.png")
                Dim myStream As MemoryStream = New MemoryStream(MyImage)
                ImgurImg = Await Imgur.UploadImageAnonymous(mystream, "PrintScreener", "img-" & DateAndTime.Now.ToShortDateString, "")
                My.Computer.Clipboard.SetText(ImgurImg.Link)
                Dim ImgLinks As New StreamWriter("Links.txt", True)
                ImgLinks.Write(ImgurImg.Link & vbCrLf)
                    ImgLinks.Flush()
                    ImgLinks.Close()
                End If
                'WB1.Navigate("http: //imgur.com/upload)
                'Application.DoEvents()
                mp.Play()
                scr.Dispose()
                bmp.Dispose()
                helpBit.Dispose()
            ElseIf e.Button = MouseButtons.Right Then
                MouseAltPressed = False
            End If
        ' Catch ex As Exception
        'MsgBox(ex.Message,, "Printscreener")
        'End Try
    End Sub

    Private Sub Form2_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If Running = True Then
            If MousePressed = True Then
                Redraw(e.Graphics, startX, startY, startx1, starty1)
            End If
            e.Graphics.DrawImage(helpBit, 0, 0)
        End If
    End Sub


    Private Sub Form2_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Running = False And Me.Visible = True Then
            Running = True
            Me.Visible = False
        Else
            If Me.Visible = True Then
                helpBit = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            End If
        End If
    End Sub
#Region "-------------------------------------------------Менюшки-------------------------------------------------------------------"
    Private Sub РежимСохраненияВБужерОбменаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles РежимСохраненияВБужерОбменаToolStripMenuItem.Click
        РежимВыгрузкиНаPiccyinfoToolStripMenuItem.Checked = False
        РежимСохраненияВБужерОбменаToolStripMenuItem.Checked = True
        MySavingMode = SavingMode.SMODE_CLIPBOARD
    End Sub

    Private Sub РежимВыгрузкиНаPiccyinfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles РежимВыгрузкиНаPiccyinfoToolStripMenuItem.Click
        РежимВыгрузкиНаPiccyinfoToolStripMenuItem.Checked = True
        РежимСохраненияВБужерОбменаToolStripMenuItem.Checked = False
        MySavingMode = SavingMode.SMODE_WEBLINK
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If MySavingMode = SavingMode.SMODE_CLIPBOARD Then
            РежимВыгрузкиНаPiccyinfoToolStripMenuItem.Checked = False
            РежимСохраненияВБужерОбменаToolStripMenuItem.Checked = True
        Else
            РежимВыгрузкиНаPiccyinfoToolStripMenuItem.Checked = True
            РежимСохраненияВБужерОбменаToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub ВыходToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem1.Click
        NotifyIcon1.ContextMenuStrip.Hide()
        NotifyIcon1.Visible = False
        NotifyIcon1.Dispose()
        End
    End Sub
#End Region
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        UnregisterHotKey(Me.Handle, 1020)
    End Sub
#End Region

    Sub Redraw(Graphicsfun As Graphics, sX As Integer, sY As Integer, X As Integer, Y As Integer)
        Dim HelpX As Integer, HelpY As Integer
        If sX >= X Then
            HelpX = X
        Else
            HelpX = sX
        End If
        If sY >= Y Then
            HelpY = Y
        Else
            HelpY = sY
        End If
        Graphicsfun.FillRectangle(Brushes.DarkGray, HelpX, HelpY, Math.Abs(sX - X), Math.Abs(sY - Y))

    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If (m.Msg = WM_HOTKEY) Then

            Dim hotKeyId As Integer = m.WParam.ToInt32()
            Debug.Print(hotKeyId)
            If hotKeyId = 1020 Then
                Me.Visible = True
                NoActivate.UnsafeNativeMethods.SetForegroundWindow(Me.Handle)
            End If
        End If
    End Sub

End Class

Namespace NoActivate

    Friend NotInheritable Class UnsafeNativeMethods

        ''' <summary>
        ''' Retrieve a handle to the foreground window.
        ''' http://msdn.microsoft.com/en-us/library/ms633505(VS.85).aspx
        ''' </summary>
        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Public Shared Function GetForegroundWindow() As IntPtr
        End Function

        ''' <summary>
        ''' Bring the thread that created the specified window into the foreground
        ''' and activates the window. 
        ''' http://msdn.microsoft.com/en-us/library/ms633539(VS.85).aspx
        ''' </summary>
        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
        End Function

        ''' <summary>
        ''' Determine whether the specified window handle identifies an existing window. 
        ''' http://msdn.microsoft.com/en-us/library/ms633528(VS.85).aspx
        ''' </summary>
        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Public Shared Function IsWindow(ByVal hWnd As IntPtr) As Boolean
        End Function

    End Class

End Namespace
