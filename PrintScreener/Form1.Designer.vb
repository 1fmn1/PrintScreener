<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.РежимСохраненияВБужерОбменаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.РежимВыгрузкиНаPiccyinfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыходToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыходToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox11 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "PrintScreener (Press Shift+Insert for screenshot)"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.РежимСохраненияВБужерОбменаToolStripMenuItem, Me.РежимВыгрузкиНаPiccyinfoToolStripMenuItem, Me.ВыходToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(297, 70)
        '
        'РежимСохраненияВБужерОбменаToolStripMenuItem
        '
        Me.РежимСохраненияВБужерОбменаToolStripMenuItem.Checked = True
        Me.РежимСохраненияВБужерОбменаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.РежимСохраненияВБужерОбменаToolStripMenuItem.Name = "РежимСохраненияВБужерОбменаToolStripMenuItem"
        Me.РежимСохраненияВБужерОбменаToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.РежимСохраненияВБужерОбменаToolStripMenuItem.Size = New System.Drawing.Size(296, 22)
        Me.РежимСохраненияВБужерОбменаToolStripMenuItem.Text = "Режим сохранения в бужер обмена"
        '
        'РежимВыгрузкиНаPiccyinfoToolStripMenuItem
        '
        Me.РежимВыгрузкиНаPiccyinfoToolStripMenuItem.Name = "РежимВыгрузкиНаPiccyinfoToolStripMenuItem"
        Me.РежимВыгрузкиНаPiccyinfoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.РежимВыгрузкиНаPiccyinfoToolStripMenuItem.Size = New System.Drawing.Size(296, 22)
        Me.РежимВыгрузкиНаPiccyinfoToolStripMenuItem.Text = "Режим выгрузки на Piccy.info"
        '
        'ВыходToolStripMenuItem1
        '
        Me.ВыходToolStripMenuItem1.Name = "ВыходToolStripMenuItem1"
        Me.ВыходToolStripMenuItem1.Size = New System.Drawing.Size(296, 22)
        Me.ВыходToolStripMenuItem1.Text = "Выход"
        '
        'ВыходToolStripMenuItem
        '
        Me.ВыходToolStripMenuItem.Name = "ВыходToolStripMenuItem"
        Me.ВыходToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ВыходToolStripMenuItem.Text = "Настройки"
        '
        'TextBox11
        '
        Me.TextBox11.AutoSize = True
        Me.TextBox11.ForeColor = System.Drawing.Color.Yellow
        Me.TextBox11.Location = New System.Drawing.Point(3, 8)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(39, 13)
        Me.TextBox11.TabIndex = 1
        Me.TextBox11.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(54, 30)
        Me.Controls.Add(Me.TextBox11)
        Me.Cursor = System.Windows.Forms.Cursors.Cross
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Opacity = 0.2R
        Me.ShowInTaskbar = False
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ВыходToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВыходToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents РежимСохраненияВБужерОбменаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents РежимВыгрузкиНаPiccyinfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox11 As Label
End Class
