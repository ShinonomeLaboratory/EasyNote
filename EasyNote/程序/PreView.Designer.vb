<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreView))
        Me.TxtShow = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TxtShow
        '
        Me.TxtShow.Location = New System.Drawing.Point(1, 1)
        Me.TxtShow.Multiline = True
        Me.TxtShow.Name = "TxtShow"
        Me.TxtShow.ReadOnly = True
        Me.TxtShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtShow.Size = New System.Drawing.Size(446, 414)
        Me.TxtShow.TabIndex = 0
        '
        'PreView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 417)
        Me.Controls.Add(Me.TxtShow)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PreView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PreView"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtShow As System.Windows.Forms.TextBox
End Class
