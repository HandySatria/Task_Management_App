Imports MySql.Data.MySqlClient
Public Class FormLogin

    Sub KondisiTerbuka()
        FormMenu.RequestToolStripMenuItem.Visible = True
        FormMenu.TaskToolStripMenuItem.Visible = True
        FormMenu.SettingToolStripMenuItem.Visible = True
        FormMenu.ButtonLogin.Text = "LOGOUT"
    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        If TextBoxNama.Text = "" Or TextBoxPassword.Text = "" Then
            MsgBox("Silahkan Isi Nama dan Password Terlebih Dahulu")
        Else
            Try
                Call Enkripsi(TextBoxPassword.Text)
                Call Koneksi()
                Cmd = New MySqlCommand("Select * From user where username = '" & TextBoxNama.Text & "' and password = '" & HasilEnkripsi & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    MsgBox("Nama atau Password Salah!")
                Else
                    Nama_User = Rd.Item("UserName")
                    Divisi_Id_User = Rd.Item("divisi_id")
                    FormMenu.LabelHeader.Text = "Welcome, " & Nama_User & " from " & Divisi_Id_User
                    Me.Close()
                    Call KondisiTerbuka()

                    'Call Koneksi()
                    'Cmd = New MySqlCommand("select * from hak_akses where Level='" & Level_User & "'", Conn)
                    'Rd = Cmd.ExecuteReader
                    'If Rd.HasRows Then
                    '    Do While Rd.Read
                    '        If Rd.Item("Input_Data") <> "Y" Then
                    '            FormMenu.ButtonInput.Enabled = False
                    '        End If
                    '        If Rd.Item("Pengaturan") <> "Y" Then
                    '            FormMenu.ButtonPengaturan.Enabled = False
                    '        End If
                    '    Loop
                    'Else
                    '    FormMenu.ButtonInput.Enabled = False
                    '    FormMenu.ButtonPengaturan.Enabled = False
                    'End If
                    'Conn.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBoxPassword.PasswordChar = ""
        ElseIf CheckBox1.Checked = False Then
            TextBoxPassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxNama.Text = "admin01"
        TextBoxPassword.Text = "admin01"
    End Sub
End Class