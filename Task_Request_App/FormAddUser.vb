Imports MySql.Data.MySqlClient
Public Class FormAddUser
    Dim tString, mode As String
    Dim cek_simpan As Integer
    Dim divisiDictionary As New Dictionary(Of Integer, String)()
    Sub resetForm()
        TextBoxNama.Text = ""
        TextBoxUsername.Text = ""
        TextBoxPassword.Text = ""
        ComboBoxDivisi.SelectedValue = -1
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cek_simpan = 0
        tString = TextBoxNama.Text
        For j = 0 To tString.Length - 1
            If tString.Chars(j) = "'" Then
                MsgBox("Tidak Boleh Ada Tanda " & "( ' )" & " Pada Nama Lengkap", vbOKOnly, "MESSAGE")
                TextBoxNama.Focus()
                cek_simpan = 1
            End If
        Next
        If cek_simpan = 0 Then
            tString = TextBoxUsername.Text
            For j = 0 To tString.Length - 1
                If tString.Chars(j) = "'" Then
                    MsgBox("Tidak Boleh Ada Tanda " & "( ' )" & " Pada Username", vbOKOnly, "MESSAGE")
                    TextBoxNama.Focus()
                    cek_simpan = 1
                End If
            Next
        End If
        If cek_simpan = 0 Then
            If TextBoxNama.Text = "" Then
                MsgBox("Nama Lengkap Tidak Boleh Kosong", vbOKOnly, "MESSAGE")
                cek_simpan = 1
            End If
        End If
        If cek_simpan = 0 Then
            If TextBoxUsername.Text = "" Then
                MsgBox("Username Tidak Boleh Kosong", vbOKOnly, "MESSAGE")
                cek_simpan = 1
            End If
        End If
        If cek_simpan = 0 Then
            If ComboBoxDivisi.SelectedValue = -1 Then
                MsgBox("Harap Pilih Divisi", vbOKOnly, "MESSAGE")
                cek_simpan = 1
            End If
        End If

        If cek_simpan = 0 Then
            Try
                Call Enkripsi(TextBoxPassword.Text)
                If LabelId.Text = "" Then
                    Call Koneksi()
                    Cmd = New MySqlCommand("INSERT INTO user(username,  password, fullname, divisi_id, user_crt, user_upd, dtm_crt,dtm_upd) values(@username,  @password, @fullname, @divisi_id, @user_crt, @user_upd, @dtm_crt, @dtm_upd) ", Conn)
                    Cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = TextBoxUsername.Text
                    Cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = HasilEnkripsi
                    Cmd.Parameters.Add("@fullname", MySqlDbType.VarChar).Value = TextBoxNama.Text
                    Cmd.Parameters.Add("@divisi_id", MySqlDbType.VarChar).Value = ComboBoxDivisi.SelectedValue
                    Cmd.Parameters.Add("@user_crt", MySqlDbType.VarChar).Value = Nama_User
                    Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = Nama_User
                    Cmd.Parameters.Add("@dtm_crt", MySqlDbType.DateTime).Value = DateTime.Now
                    Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                    Cmd.ExecuteNonQuery()
                    MsgBox("Input Data Berhasil", vbOKOnly, "Success Message")

                Else
                    Call Koneksi()
                    Cmd = New MySqlCommand("Update user set username=@username, password=@password, fullname=@fullname, divisi_id=@divisi_id, user_upd=@user_upd, dtm_upd=@dtm_upd where user_id = '" & LabelId.Text & "'", Conn)
                    Cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = TextBoxUsername.Text
                    Cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = HasilEnkripsi
                    Cmd.Parameters.Add("@fullname", MySqlDbType.VarChar).Value = TextBoxNama.Text
                    Cmd.Parameters.Add("@divisi_id", MySqlDbType.VarChar).Value = ComboBoxDivisi.SelectedValue
                    Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = Nama_User
                    Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                    Cmd.ExecuteNonQuery()
                    MsgBox("Edit Data Berhasil", vbOKOnly, "Success Message")
                End If
                resetForm()
                FormMasterUser.resetForm()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FormAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setComboBoxDivisiValue()
        If LabelId.Text = "" Then
            mode = "add"
            resetForm()
        Else
            mode = "edit"
            Call Koneksi()
            Cmd = New MySqlCommand("SELECT u.user_id as user_id, u.fullname as fullname, u.username as username, u.password as password, d.divisi_name as divisi_name, d.divisi_id as divisi_id FROM user u left join divisi d on u.divisi_id = d.divisi_id where u.user_id ='" & LabelId.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            If Rd.HasRows Then
                Do While Rd.Read
                    TextBoxNama.Text = Rd.Item("fullname")
                    TextBoxUsername.Text = Rd.Item("username")
                    TextBoxPassword.Text = ""
                    ComboBoxDivisi.SelectedValue = Rd.Item("divisi_id")
                Loop
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        resetForm()
        Me.Close()
    End Sub

    Sub setComboBoxDivisiValue()
        divisiDictionary.Clear()
        ComboBoxDivisi.DataSource = Nothing
        Call Koneksi()
        Cmd = New MySqlCommand("select divisi_id, divisi_name from divisi", Conn)
        Rd = Cmd.ExecuteReader
        divisiDictionary.Add(-1, "Pilih Divisi")
        ComboBoxDivisi.Items.Add(divisiDictionary)
        Do While Rd.Read
            divisiDictionary.Add(Rd.Item("divisi_id"), Rd.Item("divisi_name"))
            ComboBoxDivisi.Items.Add(divisiDictionary)
        Loop
        ComboBoxDivisi.DisplayMember = "Value"
        ComboBoxDivisi.ValueMember = "Key"
        ComboBoxDivisi.DataSource = New BindingSource(divisiDictionary, Nothing)
    End Sub

End Class