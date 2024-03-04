Imports MySql.Data.MySqlClient
Public Class FormLogin

    Sub KondisiTerbuka()
        FormMenu.RequestToolStripMenuItem.Visible = True
        FormMenu.TaskToolStripMenuItem.Visible = True
        If activeUserData.getIsAdmin Then
            FormMenu.SettingToolStripMenuItem.Visible = True
        End If
        FormMenu.ButtonLogin.Text = "LOGOUT"
    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        login()

    End Sub

    Sub login()
        If TextBoxNama.Text = "" Or TextBoxPassword.Text = "" Then
            MsgBox("Silahkan Isi Nama dan Password Terlebih Dahulu")
        Else
            Try
                Call Enkripsi(TextBoxPassword.Text)
                Call Koneksi()
                'Cmd = New MySqlCommand("SELECT u.user_id as user_id, u.fullname as fullname, u.username as username, u.password as password, d.divisi_name as divisi_name, d.divisi_id as divisi_id FROM user u left join divisi d on u.divisi_id = d.divisi_id where u.username = '" & TextBoxNama.Text & "' and u.password = '" & HasilEnkripsi & "'", Conn)
                Cmd = New MySqlCommand("SELECT u.user_id as user_id, u.fullname as fullname, u.username as username, u.password as password, d.divisi_name as divisi_name, d.divisi_id as divisi_id, u.is_admin as is_admin, mc.id as id_cabang, mc.nama as nama_cabang FROM user u left join divisi d on u.divisi_id = d.divisi_id left join mcabang mc on u.id_cabang = mc.id where u.username = @username and u.password = @password", Conn)
                Cmd.Parameters.AddWithValue("@username", TextBoxNama.Text)
                Cmd.Parameters.AddWithValue("@password", HasilEnkripsi)

                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    MsgBox("Username atau Password Salah!")
                Else
                    'Divisi_Name = Rd.Item("divisi_name")
                    activeUserData = New UserData(CInt(Rd.Item("divisi_id")), Rd.Item("divisi_name"), CInt(Rd.Item("user_id")), Rd.Item("username"), Rd.Item("fullname"), Rd.Item("is_admin"), Rd.Item("nama_cabang"))
                    FormMenu.LabelHeader.Text = "Welcome, " & activeUserData.getFullName & " Dari Divisi " & activeUserData.getDivisionName
                    Me.Close()
                    Call KondisiTerbuka()
                    Start_BotAsync()

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


    Private Sub TextBoxNamaKeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxNama.KeyPress
        If e.KeyChar = Chr(13) Then
            login()
        End If
    End Sub

    Private Sub TextBoxPasswordKeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            login()
        End If
    End Sub

End Class