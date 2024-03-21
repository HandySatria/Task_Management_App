Public Class FormMenu
    Private CurrentBtn As Button
    Private LeftBorderBtn As Panel
    Sub switchForm(ByVal panel As Form)
        PanelDekstop.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = FormBorderStyle.None
        panel.Dock = DockStyle.Fill
        PanelDekstop.Controls.Add(panel)
        panel.Show()
    End Sub

    Sub KondisiTertutup()
        switchForm(FormHome)
        ButtonLogin.Text = "LOGIN"
        RequestToolStripMenuItem.Visible = False
        TaskToolStripMenuItem.Visible = False
        DASHBOARDToolStripMenuItem.Visible = False
        SettingToolStripMenuItem.Visible = False
    End Sub
    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        If ButtonLogin.Text = "LOGIN" Then
            FormLogin.Show()
        ElseIf ButtonLogin.Text = "LOGOUT" Then
            Select Case MsgBox("Apakah Anda Yakin Ingin Logout ?", MsgBoxStyle.YesNo, "MESSAGE")
                Case MsgBoxResult.Yes
                    FormRequest.Close()
                    FormTask.Close()
                    FormMasterDivisi.Close()
                    FormMasterUser.Close()
                    LabelHeader.Text = ""
                    DisableButtonColor()
                    KondisiTertutup()
            End Select
        End If
    End Sub

    Private Sub DisableButtonColor()
        RequestToolStripMenuItem.BackColor = Color.LightPink
        TaskToolStripMenuItem.BackColor = Color.LightPink
        SettingToolStripMenuItem.BackColor = Color.LightPink
        MASTERUSERToolStripMenuItem.BackColor = Color.LightPink
        MASTERDIVISIToolStripMenuItem.BackColor = Color.LightPink
        DASHBOARDToolStripMenuItem.BackColor = Color.LightPink
    End Sub

    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        switchForm(FormHome)
        Call KondisiTertutup()
    End Sub

    Private Sub RequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestToolStripMenuItem.Click
        DisableButtonColor()
        switchForm(FormRequest)
        RequestToolStripMenuItem.BackColor = Color.GhostWhite
    End Sub

    Private Sub TaskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaskToolStripMenuItem.Click
        DisableButtonColor()
        switchForm(FormTask)
        TaskToolStripMenuItem.BackColor = Color.GhostWhite
    End Sub

    Private Sub MASTERUSERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MASTERUSERToolStripMenuItem.Click
        DisableButtonColor()
        switchForm(FormMasterUser)
        MASTERUSERToolStripMenuItem.BackColor = Color.GhostWhite
        SettingToolStripMenuItem.BackColor = Color.GhostWhite

    End Sub

    Private Sub MASTERDIVISIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MASTERDIVISIToolStripMenuItem.Click
        DisableButtonColor()
        switchForm(FormMasterDivisi)
        MASTERDIVISIToolStripMenuItem.BackColor = Color.GhostWhite
        SettingToolStripMenuItem.BackColor = Color.GhostWhite
    End Sub

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click

    End Sub

    Private Sub DASHBOARDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DASHBOARDToolStripMenuItem.Click
        DisableButtonColor()
        switchForm(XtraForm1)
        DASHBOARDToolStripMenuItem.BackColor = Color.GhostWhite
    End Sub
End Class
