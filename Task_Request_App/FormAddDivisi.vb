Imports MySql.Data.MySqlClient
Public Class FormAddDivisi
    Dim tString As String
    Dim cek_simpan As Integer
    Sub resetForm()
        LabelId.Text = "id"
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressPanelUtil.ShowProgressPanel(Me)
        tString = TextBoxNamaDivisi.Text
        cek_simpan = 0
        For j = 0 To tString.Length - 1
            If tString.Chars(j) = "'" Then
                MsgBox("Tidak Boleh Ada Tanda " & "( ' )" & " Pada Nama Divisi", vbOKOnly, "MESSAGE")
                TextBoxNamaDivisi.Focus()
                cek_simpan = 1
            End If
        Next
        If cek_simpan = 0 And TextBoxNamaDivisi.Text = "" Then
            MsgBox("Nama Divisi Tidak Boleh Kosong", vbOKOnly, "MESSAGE")
            cek_simpan = 1
        End If
        If cek_simpan = 0 Then
            Try
                If LabelId.Text = "" Then
                    Call Koneksi()
                    Cmd = New MySqlCommand("INSERT INTO divisi(divisi_name, user_crt, user_upd, dtm_crt,dtm_upd) values(@divisi_name, @user_crt, @user_upd, @dtm_crt,@dtm_upd)  ", Conn)

                    Cmd.Parameters.Add("@divisi_name", MySqlDbType.VarChar).Value = TextBoxNamaDivisi.Text
                    Cmd.Parameters.Add("@user_crt", MySqlDbType.VarChar).Value = activeUserData.getUserName
                    Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = activeUserData.getUserName
                    Cmd.Parameters.Add("@dtm_crt", MySqlDbType.DateTime).Value = DateTime.Now
                    Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                    Cmd.ExecuteNonQuery()

                    MsgBox("Input Data Berhasil", vbOKOnly, "Success Message")

                Else
                    Call Koneksi()
                    'ImportData = "INSERT INTO tbl_pegawai VALUES('" & TextBoxNIK.Text & "','" & TextBoxNama.Text & "','" & TglLahir & "','" & status & "','" & ComboBoxStatus.Text & "','" & TglMK & "','" & TglMPT & "','" & ComboBoxGolKer.Text & "')"
                    Cmd = New MySqlCommand("Update divisi set divisi_name=@divisi_name, user_upd=@user_upd, dtm_upd=@dtm_upd where divisi_id = '" & LabelId.Text & "'", Conn)
                    Cmd.Parameters.Add("@divisi_name", MySqlDbType.VarChar).Value = TextBoxNamaDivisi.Text
                    Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = activeUserData.getUserName
                    Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now

                    Cmd.ExecuteNonQuery()

                    MsgBox("Edit Data Berhasil", vbOKOnly, "Success Message")
                End If
                ProgressPanelUtil.HideProgressPanel()
                resetForm()
                FormMasterDivisi.resetForm()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                ProgressPanelUtil.HideProgressPanel()
            End Try
        End If
        ProgressPanelUtil.HideProgressPanel()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        resetForm()
        Me.Close()
    End Sub

    Private Sub FormAddDivisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class