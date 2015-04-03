Public Class PreView

    Public ShowWhat As String

    Private Sub PreView_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub PreView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.MinimizeBox = False

    End Sub

    Private Sub PreView_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TxtShow.Width = Me.Width - 18
        TxtShow.Height = Me.Height - 42
    End Sub

End Class