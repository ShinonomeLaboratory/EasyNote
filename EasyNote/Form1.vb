Imports System.IO

Public Class Form1

    Private CN_String(0 To 3) As String
    Private EN_String(0 To 3) As String
    Private HumanOperateChange As Boolean
    Private LanguageIsEn As Boolean
    Private IWR As New IniWR

    Private Const WidthRem = 25
    Private Const HeightRem = 50
    Private FilePath As String


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Int16

        HumanOperateChange = False

        FilePath = Application.StartupPath & "\Personal.ini"

        CN_String(0) = "紧急且重要"
        CN_String(1) = "紧急不重要"
        CN_String(2) = "重要不紧急"
        CN_String(3) = "既不紧急也不重要"

        EN_String(0) = "Important And Emergency"
        EN_String(1) = "Not Important But Emergency"
        EN_String(2) = "Important And Not Emergency"
        EN_String(3) = "Neither Important Nor Emergency"

        CmbSelect.Items.Clear()
        For i = 0 To 3
            CmbSelect.Items.Add(EN_String(i))
        Next i
        CmbSelect.SelectedIndex = 0
        'LanguageIsEn = True
        Me.MinimizeBox = False

        ReadSettings()
    End Sub

    Private Sub CmbSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSelect.SelectedIndexChanged
        HumanOperateChange = True
        Dim ReadStr As String
        ReadStr = IWR.GetINI("Text", "LOG" & CStr(CmbSelect.SelectedIndex), "", FilePath)
        EvText.Text = Replace(ReadStr, Chr(23), vbCrLf)
        HumanOperateChange = False
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim res As System.Windows.Forms.DialogResult
        res = FontDlg.ShowDialog()
        If Not (res = System.Windows.Forms.DialogResult.Cancel) Then
            EvText.Font = FontDlg.Font
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        UpdateSettings()
        End
    End Sub

    Private Sub HideToolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolToolStripMenuItem.Click
        Me.ShowInTaskbar = Not Me.ShowInTaskbar
        Execute_Rules()
        UpdateSettings()
    End Sub

    Private Sub ClearThisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearThisToolStripMenuItem.Click
        If MsgBox("Are you sure to clear this textbox?", vbYesNo) = MsgBoxResult.Yes Then
            EvText.Text = ""
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

    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        CmbSelect.Width = Me.Width - WidthRem
        EvText.Width = Me.Width - WidthRem
        EvText.Height = Me.Height - (CmbSelect.Top + CmbSelect.Height + HeightRem)
    End Sub

    Private Sub KeepFrontMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeepFrontMenuItem.Click
        Me.TopMost = Not Me.TopMost
        Call Execute_Rules()
        UpdateSettings()
    End Sub

    Private Sub Language_as_Chinese()
        Dim NS As Int16
        LanguageIsEn = False
        NS = CmbSelect.SelectedIndex
        CmbSelect.Items.Clear()
        For i = 0 To 3
            CmbSelect.Items.Add(CN_String(i))
        Next i
        CmbSelect.SelectedIndex = NS
        OperateToolStripMenuItem.Text = "操作"
        ClearThisToolStripMenuItem.Text = "清除此文本框"
        ClearAllToolStripMenuItem.Text = "语言选择"
        ToolStripMenuItem1.Text = "字体"
        ExitToolStripMenuItem.Text = "退出"
        Execute_Rules()
        Me.Text = "简单笔记"
    End Sub

    Private Sub Language_as_English()
        Dim NS As Int16
        LanguageIsEn = True
        NS = CmbSelect.SelectedIndex
        CmbSelect.Items.Clear()
        For i = 0 To 3
            CmbSelect.Items.Add(EN_String(i))
        Next i
        CmbSelect.SelectedIndex = NS
        OperateToolStripMenuItem.Text = "Operation"
        ClearThisToolStripMenuItem.Text = "Clear This"
        ClearAllToolStripMenuItem.Text = "Language"
        ToolStripMenuItem1.Text = "Font"
        ExitToolStripMenuItem.Text = "Exit"
        Execute_Rules()
        Me.Text = "Easy Note"
    End Sub

    Private Sub Execute_Rules()

        If Me.ShowInTaskbar = True Then
            If LanguageIsEn Then
                HideToolToolStripMenuItem.Text = "Hide in Taskbar"
            Else
                HideToolToolStripMenuItem.Text = "在任务栏中隐藏"
            End If

        Else
            If LanguageIsEn Then
                HideToolToolStripMenuItem.Text = "Show in Taskbar"
            Else
                HideToolToolStripMenuItem.Text = "在任务栏中显示"
            End If
        End If

        If Me.TopMost = True Then
            If LanguageIsEn Then
                KeepFrontMenuItem.Text = "Discard Keep Front"
            Else
                KeepFrontMenuItem.Text = "取消最前"
            End If

        Else
            If LanguageIsEn Then
                KeepFrontMenuItem.Text = "Keep Front"
            Else
                KeepFrontMenuItem.Text = "始终最前"
            End If
        End If

    End Sub

    Private Sub ReadSettings()
        Dim IWR As New IniWR

        LanguageIsEn = Str2Bool(IWR.GetINI("Sets", "Language", "1", FilePath))

        If LanguageIsEn Then
            Language_as_English()
        Else
            Language_as_Chinese()
        End If

        Me.TopMost = Str2Bool(IWR.GetINI("Sets", "TopMost", "0", FilePath))

        Me.ShowInTaskbar = Str2Bool(IWR.GetINI("Sets", "ShowInTaskbar", "1", FilePath))

        Execute_Rules()

    End Sub

    Private Sub UpdateSettings()
        '保存在前，隐藏和语言

        IWR.WriteINI("Sets", "Language", Bool2String(LanguageIsEn), FilePath)
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


    Private Sub EvText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvText.TextChanged
        If Not HumanOperateChange Then
            Dim WriteStr As String
            WriteStr = Replace(EvText.Text, vbCrLf, Chr(23))
            IWR.WriteINI("Text", "LOG" & CStr(CmbSelect.SelectedIndex), WriteStr, FilePath)
        End If
    End Sub
End Class
