Public Class PreView

    Public ShowWhat As String


    Private Sub PreView_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub PreView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim meleft, metop, meheight, mewidth As Integer

        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.MinimizeBox = False

        metop = Form1.IWR.GetINI("PSize", "Top", CStr(Me.Top), Form1.FilePath)
        meleft = Form1.IWR.GetINI("PSize", "Left", CStr(Me.Left), Form1.FilePath)
        mewidth = Form1.IWR.GetINI("PSize", "Width", CStr(Me.Width), Form1.FilePath)
        meheight = Form1.IWR.GetINI("PSize", "Height", CStr(Me.Height), Form1.FilePath)

        Me.Top = metop
        Me.Left = meleft
        Me.Width = mewidth
        Me.Height = meheight
    End Sub

    Private Sub PreView_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TxtShow.Width = Me.Width - 18
        TxtShow.Height = Me.Height - 42
    End Sub

    Private Sub PreView_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        TxtShow.Width = Me.Width - 18
        TxtShow.Height = Me.Height - 42
        Form1.IWR.WriteINI("PSize", "Width", CStr(Me.Width), Form1.FilePath)
        Form1.IWR.WriteINI("PSize", "Height", CStr(Me.Height), Form1.FilePath)
        Form1.IWR.WriteINI("PSize", "Top", CStr(Me.Top), Form1.FilePath)
        Form1.IWR.WriteINI("PSize", "Left", CStr(Me.Left), Form1.FilePath)
    End Sub
End Class