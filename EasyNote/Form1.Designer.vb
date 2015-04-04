<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.CmbSelect = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OperateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviewAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearThisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnglishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChineseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeepFrontMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontDlg = New System.Windows.Forms.FontDialog()
        Me.EvText = New System.Windows.Forms.TextBox()
        Me.TmrSaver = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbSelect
        '
        Me.CmbSelect.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSelect.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmbSelect.FormattingEnabled = True
        Me.CmbSelect.ItemHeight = 20
        Me.CmbSelect.Location = New System.Drawing.Point(5, 27)
        Me.CmbSelect.Name = "CmbSelect"
        Me.CmbSelect.Size = New System.Drawing.Size(500, 28)
        Me.CmbSelect.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperateToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(511, 26)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OperateToolStripMenuItem
        '
        Me.OperateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviewAllToolStripMenuItem, Me.ClearThisToolStripMenuItem, Me.ClearAllToolStripMenuItem, Me.KeepFrontMenuItem, Me.HideToolToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.OperateToolStripMenuItem.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OperateToolStripMenuItem.Name = "OperateToolStripMenuItem"
        Me.OperateToolStripMenuItem.Size = New System.Drawing.Size(88, 22)
        Me.OperateToolStripMenuItem.Text = "Operation"
        '
        'PreviewAllToolStripMenuItem
        '
        Me.PreviewAllToolStripMenuItem.Name = "PreviewAllToolStripMenuItem"
        Me.PreviewAllToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.PreviewAllToolStripMenuItem.Text = "PreviewAll"
        '
        'ClearThisToolStripMenuItem
        '
        Me.ClearThisToolStripMenuItem.Name = "ClearThisToolStripMenuItem"
        Me.ClearThisToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ClearThisToolStripMenuItem.Text = "Clear All"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnglishToolStripMenuItem, Me.ChineseToolStripMenuItem})
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ClearAllToolStripMenuItem.Text = "Language"
        '
        'EnglishToolStripMenuItem
        '
        Me.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem"
        Me.EnglishToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.EnglishToolStripMenuItem.Text = "English"
        '
        'ChineseToolStripMenuItem
        '
        Me.ChineseToolStripMenuItem.Name = "ChineseToolStripMenuItem"
        Me.ChineseToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ChineseToolStripMenuItem.Text = "简体中文"
        '
        'KeepFrontMenuItem
        '
        Me.KeepFrontMenuItem.Name = "KeepFrontMenuItem"
        Me.KeepFrontMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.KeepFrontMenuItem.Text = "Keep Front"
        '
        'HideToolToolStripMenuItem
        '
        Me.HideToolToolStripMenuItem.Name = "HideToolToolStripMenuItem"
        Me.HideToolToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.HideToolToolStripMenuItem.Text = "Hide in Taskbar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem1.Text = "Font"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EvText
        '
        Me.EvText.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EvText.Location = New System.Drawing.Point(5, 61)
        Me.EvText.Multiline = True
        Me.EvText.Name = "EvText"
        Me.EvText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.EvText.Size = New System.Drawing.Size(385, 290)
        Me.EvText.TabIndex = 4
        '
        'TmrSaver
        '
        Me.TmrSaver.Enabled = True
        Me.TmrSaver.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(511, 363)
        Me.Controls.Add(Me.EvText)
        Me.Controls.Add(Me.CmbSelect)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easy Note"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbSelect As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OperateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearThisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDlg As System.Windows.Forms.FontDialog
    Friend WithEvents EnglishToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChineseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeepFrontMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EvText As System.Windows.Forms.TextBox
    Friend WithEvents TmrSaver As System.Windows.Forms.Timer
    Friend WithEvents PreviewAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
