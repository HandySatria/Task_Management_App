Imports MySql.Data.MySqlClient
Public Class FormAddDivisi
    Dim tString As String
    Dim cek_simpan As Integer
    Sub resetForm()
        TextBoxNamaDivisi.Text = ""
        LabelId.Text = "id"
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tString = TextBoxNamaDivisi.Text
        cek_simpan = 0
        For j = 0 To tString.Length - 1
            If tString.Chars(j) = "'" Then
                MsgBox("Tidak Boleh Ada Tanda " & "( ' )" & " Pada NIK", vbOKOnly, "MESSAGE")
                TextBoxNamaDivisi.Focus()
                cek_simpan = 1
            End If
        Next
        If TextBoxNamaDivisi.Text = "" Then
            MsgBox("Nama Divisi Tidak Boleh Kosong", vbOKOnly, "MESSAGE")
            cek_simpan = 1
        End If
        If cek_simpan = 0 Then
            Try
                If LabelId.Text = "" Then
                    Call Koneksi()
                    Cmd = New MySqlCommand("INSERT INTO divisi(divisi_name, user_crt, user_upd, dtm_crt,dtm_upd) values(@divisi_name, @user_crt, @user_upd, @dtm_crt,@dtm_upd)  ", Conn)

                    Cmd.Parameters.Add("@divisi_name", MySqlDbType.VarChar).Value = TextBoxNamaDivisi.Text
                    Cmd.Parameters.Add("@user_crt", MySqlDbType.VarChar).Value = Nama_User
                    Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = Nama_User
                    Cmd.Parameters.Add("@dtm_crt", MySqlDbType.DateTime).Value = DateTime.Now
                    Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                    Cmd.ExecuteNonQuery()

                    MsgBox("Input Data Berhasil", vbOKOnly, "Success Message")

                Else
                    Call Koneksi()
                    'ImportData = "INSERT INTO tbl_pegawai VALUES('" & TextBoxNIK.Text & "','" & TextBoxNama.Text & "','" & TglLahir & "','" & status & "','" & ComboBoxStatus.Text & "','" & TglMK & "','" & TglMPT & "','" & ComboBoxGolKer.Text & "')"
                    Cmd = New MySqlCommand("Update divisi set divisi_name=@divisi_name where divisi_id = '" & LabelId.Text & "'", Conn)
                    Cmd.Parameters.Add("@divisi_name", MySqlDbType.VarChar).Value = TextBoxNamaDivisi.Text
                    Cmd.ExecuteNonQuery()

                    MsgBox("Edit Data Berhasil", vbOKOnly, "Success Message")
                End If
                resetForm()
                FormMasterDivisi.resetForm()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        resetForm()
        Me.Close()
    End Sub

End Class