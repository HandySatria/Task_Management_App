Imports MySql.Data.MySqlClient
Public Class FormNotApprove
    Dim Cari_Data, to_divisi, from_divisi, from_divisi_id, to_divisi_id, subjek, deskripsi, prioritas As String
    Sub resetForm()
        TextBoxCatatan.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        resetForm()
        Me.Close()
    End Sub

    Private Async Sub Button1_ClickAsync(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ProgressPanelUtil.ShowProgressPanel(Me)
            If LabelTitle.Text = "DATA REVISI" Then

                Call Koneksi()
                Cmd = New MySqlCommand("Update request set status=@status, user_upd=@user_upd, dtm_upd=@dtm_upd where request_id = '" & LabelId.Text & "'", Conn)
                Cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 9
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = activeUserData.getUserName
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()

                Call Koneksi()
                Cmd = New MySqlCommand("INSERT INTO hist_request(request_id, ref_status_id, catatan, user_crt, user_upd, dtm_crt, dtm_upd) values( @request_id, @ref_status_id, @catatan, @user_crt, @user_upd, @dtm_crt, @dtm_upd) ", Conn)
                Cmd.Parameters.Add("@request_id", MySqlDbType.VarChar).Value = LabelId.Text
                Cmd.Parameters.Add("@ref_status_id", MySqlDbType.VarChar).Value = 9
                Cmd.Parameters.Add("@catatan", MySqlDbType.VarChar).Value = TextBoxCatatan.Text
                Cmd.Parameters.Add("@user_crt", MySqlDbType.VarChar).Value = activeUserData.getUserName
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = activeUserData.getUserName
                Cmd.Parameters.Add("@dtm_crt", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()

                Call Koneksi()
                Cmd = New MySqlCommand("SELECT user_id, divisi_id, chat_id_telegram FROM user where divisi_id = '" & to_divisi_id & "'", Conn)
                Rd = Cmd.ExecuteReader
                '  Rd.Read()
                If Rd.HasRows Then
                    Do While Rd.Read
                        Dim chatIdTujuan As Long = Rd.Item("chat_id_telegram")
                        Dim pesan As String
                        pesan = "** TASK DENGAN ID : " & LabelId.Text & " PERLU DI REVISI **" & Environment.NewLine & Environment.NewLine & Environment.NewLine &
                        "- Dari Divisi : " & from_divisi & Environment.NewLine & Environment.NewLine &
                        "- Subject : " & subjek & Environment.NewLine & Environment.NewLine &
                        "- Deskripsi : " & deskripsi & Environment.NewLine & Environment.NewLine &
                        "- Prioritas : " & prioritas & Environment.NewLine & Environment.NewLine &
                        "- User : " & activeUserData.getFullName & Environment.NewLine & Environment.NewLine &
                        "- Alasan Revisi : " & TextBoxCatatan.Text & Environment.NewLine & Environment.NewLine
                        Await KirimPesanKeOrangLainAsync(botClient, chatIdTujuan, pesan, cts.Token)
                    Loop
                End If

            Else
                Call Koneksi()
                Cmd = New MySqlCommand("Update request set status=@status, user_upd=@user_upd, dtm_upd=@dtm_upd where request_id = '" & LabelId.Text & "'", Conn)
                Cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 4
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = activeUserData.getUserName
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()

                Call Koneksi()
                Cmd = New MySqlCommand("INSERT INTO hist_request(request_id, ref_status_id, catatan, user_crt, user_upd, dtm_crt, dtm_upd) values( @request_id, @ref_status_id, @catatan, @user_crt, @user_upd, @dtm_crt, @dtm_upd) ", Conn)
                Cmd.Parameters.Add("@request_id", MySqlDbType.VarChar).Value = LabelId.Text
                Cmd.Parameters.Add("@ref_status_id", MySqlDbType.VarChar).Value = 4
                Cmd.Parameters.Add("@catatan", MySqlDbType.VarChar).Value = TextBoxCatatan.Text
                Cmd.Parameters.Add("@user_crt", MySqlDbType.VarChar).Value = activeUserData.getUserName
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = activeUserData.getUserName
                Cmd.Parameters.Add("@dtm_crt", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()

                Call Koneksi()
                Cmd = New MySqlCommand("SELECT user_id, divisi_id, chat_id_telegram FROM user where divisi_id = '" & from_divisi_id & "'", Conn)
                Rd = Cmd.ExecuteReader
                '  Rd.Read()
                If Rd.HasRows Then
                    Do While Rd.Read
                        Dim chatIdTujuan As Long = Rd.Item("chat_id_telegram")
                        Dim pesan As String
                        pesan = "** REQUEST DENGAN ID : " & LabelId.Text & " DITOLAK **" & Environment.NewLine & Environment.NewLine & Environment.NewLine &
                        "- Untuk Divisi : " & to_divisi & Environment.NewLine & Environment.NewLine &
                        "- Subject : " & subjek & Environment.NewLine & Environment.NewLine &
                        "- Deskripsi : " & deskripsi & Environment.NewLine & Environment.NewLine &
                        "- Prioritas : " & prioritas & Environment.NewLine & Environment.NewLine &
                        "- User : " & activeUserData.getFullName & Environment.NewLine & Environment.NewLine &
                        "- Alasan Ditolak : " & TextBoxCatatan.Text & Environment.NewLine & Environment.NewLine
                        Await KirimPesanKeOrangLainAsync(botClient, chatIdTujuan, pesan, cts.Token)
                    Loop
                End If
            End If
            MsgBox("Update Status Berhasil", vbOKOnly, "Success Message")
            ProgressPanelUtil.HideProgressPanel()
            resetForm()
            FormTask.resetForm()
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            ProgressPanelUtil.HideProgressPanel()
        End Try
        ProgressPanelUtil.HideProgressPanel()
    End Sub

    Private Sub FormNotApprove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Call Koneksi()
            Cari_Data = "select r.request_id as request_id, r.subject as subject, r.description as  description, dTo.divisi_name as to_divisi,dTo.divisi_id as to_divisi_id, dFrom.divisi_name as from_divisi, dFrom.divisi_id as from_divisi_id, 
                                rp.prioritas_name as prioritas_name, rp.ref_prioritas_id as ref_prioritas_id, rs.status_name as status_name, rs.ref_status_id as ref_status_id, 
                                r.user_crt as user_crt, r.user_upd as user_upd, r.dtm_crt as dtm_crt, r.dtm_upd as dtm_upd 
                        from request r 
                            left join divisi dTo on dTo.divisi_id = r.to_divisi 
                            left join divisi dFrom on dFrom.divisi_id = r.from_divisi 
                            left join ref_status rs on rs.ref_status_id = r.status
                            left join ref_prioritas rp on rp.ref_prioritas_id = r.prioritas
                        where r.request_id = " & LabelId.Text
            Cmd = New MySqlCommand(Cari_Data, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                to_divisi = Rd.Item("to_divisi")
                from_divisi = Rd.Item("from_divisi")
                from_divisi_id = Rd.Item("from_divisi_id")
                to_divisi_id = Rd.Item("to_divisi_id")
                subjek = Rd.Item("subject")
                deskripsi = Rd.Item("description")
                prioritas = Rd.Item("prioritas_name")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class