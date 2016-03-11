Imports System.IO

Public Class Form1

    Private CN_String(0 To 3) As String
    Private EN_String(0 To 3) As String
    Private JP_String(0 To 3) As String

    Private HumanOperateChange As Boolean

    Private UserLanguage As Int16
    Private Const ul_Chinese = 0
    Private Const ul_English = 1
    Private Const ul_Japanese = 2

    Public IWR As New IniWR
    Private LastIndex As Int16
    Private FreeTime As Int16

    Private Const WidthRem = 25
    Private Const HeightRem = 50
    Public FilePath As String


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Int16
        Dim meleft, metop, meheight, mewidth As Integer

        LastIndex = -1
        FilePath = Application.StartupPath & "\Personal.ini"
        FreeTime = 3
        CN_String(0) = "紧急且重要"
        CN_String(1) = "紧急不重要"
        CN_String(2) = "重要不紧急"
        CN_String(3) = "既不紧急也不重要"

        EN_String(0) = "Important And Emergency"
        EN_String(1) = "Not Important But Emergency"
        EN_String(2) = "Important And Not Emergency"
        EN_String(3) = "Neither Important Nor Emergency"

        JP_String(0) = "重要があるばかりでなく、緊急もある"
        JP_String(1) = "緊急だが重要ではない"
        JP_String(2) = "重要だが緊急ではない"
        JP_String(3) = "重要こともないし、緊急こともない"
        CmbSelect.Items.Clear()

        For i = 0 To 3
            CmbSelect.Items.Add(EN_String(i))
        Next i

        CmbSelect.SelectedIndex = 0
        'UserLanguage = True
        ReadSettings()
        Me.MinimizeBox = Me.ShowInTaskbar

        metop = IWR.GetINI("Size", "Top", CStr(Me.Top), FilePath)
        meleft = IWR.GetINI("Size", "Left", CStr(Me.Left), FilePath)
        mewidth = IWR.GetINI("Size", "Width", CStr(Me.Width), FilePath)
        meheight = IWR.GetINI("Size", "Height", CStr(Me.Height), FilePath)

        Me.Top = metop
        Me.Left = meleft
        Me.Width = mewidth
        Me.Height = meheight
        AutoResizeAX()

        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            End
        End If

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        AutoResizeAX()
    End Sub

    Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        IWR.WriteINI("Size", "Width", CStr(Me.Width), FilePath)
        IWR.WriteINI("Size", "Height", CStr(Me.Height), FilePath)
        IWR.WriteINI("Size", "Top", CStr(Me.Top), FilePath)
        IWR.WriteINI("Size", "Left", CStr(Me.Left), FilePath)
    End Sub

    Private Sub CmbSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSelect.SelectedIndexChanged
        Dim ReadStr As String
        SaveFile()
        ReadStr = IWR.GetINI("Text", "LOG" & CStr(CmbSelect.SelectedIndex), "", FilePath)
        EvText.Text = Replace(ReadStr, Chr(23), vbCrLf)
        LastIndex = CmbSelect.SelectedIndex
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim res As System.Windows.Forms.DialogResult
        res = FontDlg.ShowDialog()
        If Not (res = System.Windows.Forms.DialogResult.Cancel) Then
            EvText.Font = FontDlg.Font
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        SaveFile()
        UpdateSettings()
        End
    End Sub

    Private Sub HideToolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolToolStripMenuItem.Click
        Me.ShowInTaskbar = Not Me.ShowInTaskbar
        Me.MinimizeBox = Me.ShowInTaskbar
        Execute_Rules()
        UpdateSettings()
    End Sub

    Private Sub ClearThisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearThisToolStripMenuItem.Click
        Dim MessageText, MessageTitle As String
        Dim i As Int16

        If UserLanguage = ul_Chinese Then
            MessageText = "注意！此操作将清除所有记录！"
            MessageTitle = "简单笔记"
        ElseIf UserLanguage = ul_English Then
            MessageText = "Warning!This operation will clean all the log!"
            MessageTitle = "Easy Note"
        Else
            MessageText = "注意ください！すべての全手帳を削除します！"
            MessageTitle = "簡単な手帳"
        End If

        If MsgBox(MessageText, vbYesNo, MessageTitle) = MsgBoxResult.Yes Then
            EvText.Text = ""
            For i = 0 To 3
                IWR.WriteINI("Text", "LOG" & CStr(i), "", FilePath)
            Next i
        End If
    End Sub

    Private Sub EnglishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem.Click
        Language_as_English()
        UpdateSettings()
    End Sub

    Private Sub ChineseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChineseToolStripMenuItem.Click
        Language_as_Chinese()
        UpdateSettings()
    End Sub

    Private Sub JapaneseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JapaneseToolStripMenuItem.Click
        Language_as_Japanese()
        UpdateSettings()
    End Sub

    Private Sub KeepFrontMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeepFrontMenuItem.Click
        Me.TopMost = Not Me.TopMost
        Call Execute_Rules()
        UpdateSettings()
    End Sub

    Private Sub Language_as_Chinese()
        Dim NS As Int16
        UserLanguage = ul_Chinese

        NS = CmbSelect.SelectedIndex
        CmbSelect.Items.Clear()
        For i = 0 To 3
            CmbSelect.Items.Add(CN_String(i))
        Next i
        CmbSelect.SelectedIndex = NS
        OperateToolStripMenuItem.Text = "操作"
        ClearThisToolStripMenuItem.Text = "清除所有"
        ClearAllToolStripMenuItem.Text = "语言选择"
        ToolStripMenuItem1.Text = "字体"
        ExitToolStripMenuItem.Text = "退出"
        PreviewAllToolStripMenuItem.Text = "预览所有"
        Execute_Rules()
        Me.Text = "简单笔记"
    End Sub

    Private Sub Language_as_English()
        Dim NS As Int16
        UserLanguage = ul_English

        NS = CmbSelect.SelectedIndex
        CmbSelect.Items.Clear()
        For i = 0 To 3
            CmbSelect.Items.Add(EN_String(i))
        Next i
        CmbSelect.SelectedIndex = NS
        OperateToolStripMenuItem.Text = "Operation"
        ClearThisToolStripMenuItem.Text = "Clear All"
        ClearAllToolStripMenuItem.Text = "Language"
        ToolStripMenuItem1.Text = "Font"
        ExitToolStripMenuItem.Text = "Exit"
        PreviewAllToolStripMenuItem.Text = "Preview All"
        Execute_Rules()
        Me.Text = "Easy Note"
    End Sub

    Private Sub Language_as_Japanese()
        Dim NS As Int16
        UserLanguage = ul_Japanese

        NS = CmbSelect.SelectedIndex
        CmbSelect.Items.Clear()
        For i = 0 To 3
            CmbSelect.Items.Add(JP_String(i))
        Next i
        CmbSelect.SelectedIndex = NS
        OperateToolStripMenuItem.Text = "操作"
        ClearThisToolStripMenuItem.Text = "全手帳を削除する"
        ClearAllToolStripMenuItem.Text = "言語"
        ToolStripMenuItem1.Text = "字体"
        ExitToolStripMenuItem.Text = "クローン"
        PreviewAllToolStripMenuItem.Text = "プレビュー"
        Execute_Rules()
        Me.Text = "簡単な手帳"
    End Sub

    Private Sub Execute_Rules()

        If Me.ShowInTaskbar = True Then
            If UserLanguage = ul_Chinese Then
                HideToolToolStripMenuItem.Text = "在任务栏中隐藏图标"
            ElseIf UserLanguage = ul_English Then
                HideToolToolStripMenuItem.Text = "Hide icon in Taskbar"
            Else
                HideToolToolStripMenuItem.Text = "タスクバーのアイコンを隠す"
            End If

        Else

            If UserLanguage = ul_Chinese Then
                HideToolToolStripMenuItem.Text = "在任务栏中显示图标"
            ElseIf UserLanguage = ul_English Then
                HideToolToolStripMenuItem.Text = "Show icon in Taskbar"
            Else
                HideToolToolStripMenuItem.Text = "タスクバーのアイコンを表示します"
            End If
        End If

        If Me.TopMost = True Then
            If UserLanguage = ul_Chinese Then
                KeepFrontMenuItem.Text = "取消最前"
            ElseIf UserLanguage = ul_English Then
                KeepFrontMenuItem.Text = "Discard Keep Front"
            Else
                KeepFrontMenuItem.Text = "先頭を取り消す"
            End If
        Else
            If UserLanguage = ul_Chinese Then
                KeepFrontMenuItem.Text = "始终最前"
            ElseIf UserLanguage = ul_English Then
                KeepFrontMenuItem.Text = "Keep Front"
            Else
                KeepFrontMenuItem.Text = "先頭を保持する"
            End If
        End If

    End Sub

    Private Sub ReadSettings()
        Dim IWR As New IniWR

        UserLanguage = Str2Int(IWR.GetINI("Sets", "Language", "1", FilePath))

        If UserLanguage = ul_Chinese Then
            Language_as_Chinese()
        ElseIf UserLanguage = ul_English Then
            Language_as_English()
        Else
            Language_as_Japanese()
        End If

        Me.TopMost = Str2Bool(IWR.GetINI("Sets", "TopMost", "0", FilePath))

        Me.ShowInTaskbar = Str2Bool(IWR.GetINI("Sets", "ShowInTaskbar", "1", FilePath))

        Execute_Rules()

    End Sub

    Private Sub UpdateSettings()
        '保存在前，隐藏和语言

        IWR.WriteINI("Sets", "Language", Int2String(UserLanguage), FilePath)
        IWR.WriteINI("Sets", "TopMost", Bool2String(Me.TopMost), FilePath)
        IWR.WriteINI("Sets", "ShowInTaskbar", Bool2String(Me.ShowInTaskbar), FilePath)
    End Sub

    Private Function Bool2String(ByVal InputVal As Boolean) As String
        If InputVal Then
            Bool2String = "1"
        Else
            Bool2String = "0"
        End If
    End Function

    Private Function Str2Bool(ByVal InputVal As String) As Boolean
        If InputVal = "0" Then
            Str2Bool = False
        Else
            Str2Bool = True
        End If
    End Function

    Private Function Int2String(ByVal InputVal As Int16) As String
        Int2String = CStr(InputVal)
    End Function

    Private Function Str2Int(ByVal InputVal As String) As Int16
        Str2Int = Val(InputVal)
    End Function

    Private Sub SaveFile()
        Dim WriteStr As String
        If LastIndex >= 0 Then
            WriteStr = Replace(EvText.Text, vbCrLf, Chr(23))
            IWR.WriteINI("Text", "LOG" & CStr(LastIndex), WriteStr, FilePath)
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SaveFile()
        UpdateSettings()
    End Sub

    Private Sub TmrSaver_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrSaver.Tick
        If FreeTime > 0 Then
            FreeTime = FreeTime - 1
        Else
            TmrSaver.Enabled = False
        End If
        If FreeTime = 1 Then
            SaveFile()
        End If
    End Sub

    Private Sub PreviewAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewAllToolStripMenuItem.Click
        Dim i As Int16
        Dim StringShow As String

        StringShow = ""

        For i = 0 To 3
            If UserLanguage = ul_Chinese Then
                StringShow = StringShow & CN_String(i) & vbCrLf
            ElseIf UserLanguage = ul_English Then
                StringShow = StringShow & EN_String(i) & vbCrLf
            Else
                StringShow = StringShow & JP_String(i) & vbCrLf
            End If

            StringShow = StringShow & IWR.GetINI("Text", "LOG" & CStr(i), "", FilePath) & vbCrLf & vbCrLf
        Next i

        Me.Hide()
        PreView.Show()
        PreView.TxtShow.Font = Me.EvText.Font
        PreView.TxtShow.Text = Replace(StringShow, Chr(23), vbCrLf)

        If UserLanguage = ul_Chinese Then
            PreView.Text = "预览所有"
        ElseIf UserLanguage = ul_English Then
            PreView.Text = "Preview All"
        Else
            PreView.Text = "全部をプレビュー"
        End If

    End Sub


    Private Sub EvText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvText.TextChanged
        FreeTime = 3
        TmrSaver.Enabled = True
    End Sub

    Private Sub AutoResizeAX()
        CmbSelect.Width = Me.Width - WidthRem
        EvText.Width = Me.Width - WidthRem
        EvText.Height = Me.Height - (CmbSelect.Top + CmbSelect.Height + HeightRem)
    End Sub

End Class
