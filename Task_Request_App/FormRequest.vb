Imports MySql.Data.MySqlClient
Public Class FormRequest
    Dim Cari_Data, Condition As String
    Dim baris As Integer
    Dim divisiDictionary As New Dictionary(Of Integer, String)()
    Dim statusDictionary As New Dictionary(Of Integer, String)()

    Private Sub FormRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetForm()
        setComboBoxValue()
    End Sub
    Sub setComboBoxValue()
        divisiDictionary.Clear()
        ComboBoxDivisi.DataSource = Nothing
        Call Koneksi()
        Cmd = New MySqlCommand("select divisi_id, divisi_name from divisi", Conn)
        Rd = Cmd.ExecuteReader
        divisiDictionary.Add(-1, "Pilih Divisi")
        ComboBoxDivisi.Items.Add(divisiDictionary)
        Do While Rd.Read
            Dim divisiId As String
            divisiId = Rd.Item("divisi_id")
            If divisiId = activeUserData.getDivisionId Or divisiId = 3 Or divisiId = 2 Then
            Else
                divisiDictionary.Add(Rd.Item("divisi_id"), Rd.Item("divisi_name"))
                ComboBoxDivisi.Items.Add(divisiDictionary)
            End If
        Loop
        ComboBoxDivisi.DisplayMember = "Value"
        ComboBoxDivisi.ValueMember = "Key"
        ComboBoxDivisi.DataSource = New BindingSource(divisiDictionary, Nothing)

        statusDictionary.Clear()
        ComboBoxStatus.DataSource = Nothing
        Call Koneksi()
        Cmd = New MySqlCommand("select ref_status_id, status_name from ref_status", Conn)
        Rd = Cmd.ExecuteReader
        statusDictionary.Add(-1, "Pilih Status")
        ComboBoxStatus.Items.Add(statusDictionary)
        Do While Rd.Read
            Dim statusId As String
            statusId = Rd.Item("ref_status_id")
            If statusId = 3 Or statusId = 2 Then
            Else
                statusDictionary.Add(Rd.Item("ref_status_id"), Rd.Item("status_name"))
                ComboBoxStatus.Items.Add(statusDictionary)
            End If
        Loop
        ComboBoxStatus.DisplayMember = "Value"
        ComboBoxStatus.ValueMember = "Key"
        ComboBoxStatus.DataSource = New BindingSource(statusDictionary, Nothing)
    End Sub

    Private Sub GetData()
        Try
            Condition = " Where dFrom.divisi_id = " & activeUserData.getDivisionId
            If TextBoxRequestId.Text IsNot "" Then
                Condition = Condition & " and r.request_id = '" & TextBoxRequestId.Text & "'"
            End If
            If TextBoxSubject.Text IsNot "" Then
                Condition = Condition & " and r.subject like '%" & TextBoxSubject.Text & "%'"
            End If
            If ComboBoxDivisi.SelectedItem IsNot Nothing Then
                If DirectCast(ComboBoxDivisi.SelectedValue, Integer) >= 0 Then
                    Condition = Condition & " and dTo.divisi_id = '" & DirectCast(ComboBoxDivisi.SelectedValue, Integer) & "'"
                End If
            End If
            If ComboBoxStatus.SelectedItem IsNot Nothing Then
                If DirectCast(ComboBoxStatus.SelectedValue, Integer) >= 0 Then
                    Condition = Condition & " and rs.ref_status_id = '" & DirectCast(ComboBoxStatus.SelectedValue, Integer) & "'"
                End If
            End If
            If DateEdit1.Text IsNot "" Then
                Condition = Condition & " and date(r.dtm_crt) >= '" & DateEdit1.Text & "'"
            End If
            If DateEdit2.Text IsNot "" Then
                Condition = Condition & " and date(r.dtm_crt) <= '" & DateEdit2.Text & "'"
            End If



            Call Koneksi()
            Cari_Data = "select r.request_id as request_id, r.subject as subject, r.description as description, dTo.divisi_name as to_divisi,dTo.divisi_id as to_divisi_id, dFrom.divisi_name as from_divisi, 
                                rp.prioritas_name as prioritas_name, rp.ref_prioritas_id as ref_prioritas_id, rs.status_name as status_name, rs.ref_status_id as ref_status_id, 
                                r.user_crt as user_crt, r.user_upd as user_upd, r.dtm_crt as dtm_crt, r.dtm_upd as dtm_upd 
                        from request r 
                            left join divisi dTo on dTo.divisi_id = r.to_divisi 
                            left join divisi dFrom on dFrom.divisi_id = r.from_divisi 
                            left join ref_status rs on rs.ref_status_id = r.status
                            left join ref_prioritas rp on rp.ref_prioritas_id = r.prioritas" & Condition
            Cmd = New MySqlCommand(Cari_Data, Conn)
            Rd = Cmd.ExecuteReader
            DataGridView1.Columns.Clear()

            'Call format_dgv(DataGridView1)
            DataGridView1.ColumnCount = 13
            baris = 0
            If Rd.HasRows Then
                DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("sanserif", 10, FontStyle.Regular)
                DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView1.DefaultCellStyle.Font = New Font("sanserif", 10, FontStyle.Regular)
                DataGridView1.DefaultCellStyle.ForeColor = Color.Black
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridView1.Columns(0).Width = 40
                DataGridView1.Columns(1).Width = 150
                DataGridView1.Columns(2).Width = 150
                DataGridView1.Columns(3).Width = 250
                DataGridView1.Columns(4).Width = 150
                DataGridView1.Columns(5).Width = 150
                DataGridView1.Columns(6).Width = 150
                DataGridView1.Columns(7).Width = 100
                DataGridView1.Columns(8).Width = 100
                DataGridView1.Columns(9).Width = 150
                DataGridView1.Columns(10).Width = 150

                DataGridView1.Columns(0).HeaderText = "ID"
                DataGridView1.Columns(1).HeaderText = "Dari Divisi"
                DataGridView1.Columns(2).HeaderText = "Ke Divisi    "
                DataGridView1.Columns(3).HeaderText = "Subjek"
                DataGridView1.Columns(4).HeaderText = "Deskripsi"
                DataGridView1.Columns(5).HeaderText = "Status"
                DataGridView1.Columns(6).HeaderText = "Prioritas"
                DataGridView1.Columns(7).HeaderText = "User Create"
                DataGridView1.Columns(8).HeaderText = "User Update"
                DataGridView1.Columns(9).HeaderText = "DateTime Create"
                DataGridView1.Columns(10).HeaderText = "DateTime Update"
                DataGridView1.Columns(11).HeaderText = "To Divisi ID"
                DataGridView1.Columns(12).HeaderText = "Id Status"
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Do While Rd.Read
                    DataGridView1.Rows.Add()
                    DataGridView1(0, baris).Value = Rd.Item("request_id")
                    DataGridView1(1, baris).Value = Rd.Item("from_divisi")
                    DataGridView1(2, baris).Value = Rd.Item("to_divisi")
                    DataGridView1(3, baris).Value = Rd.Item("subject")
                    DataGridView1(4, baris).Value = Rd.Item("description")
                    DataGridView1(5, baris).Value = Rd.Item("status_name")
                    DataGridView1(6, baris).Value = Rd.Item("prioritas_name")
                    DataGridView1(7, baris).Value = Rd.Item("user_crt")
                    DataGridView1(8, baris).Value = Rd.Item("user_upd")
                    DataGridView1(9, baris).Value = Rd.Item("dtm_crt")
                    DataGridView1(10, baris).Value = Rd.Item("dtm_upd")
                    DataGridView1(11, baris).Value = Rd.Item("to_divisi_id")
                    DataGridView1(12, baris).Value = Rd.Item("ref_status_id")

                    If Rd.Item("ref_status_id") = 1 Then
                        DataGridView1(5, baris).Style.BackColor = Color.LightYellow
                    ElseIf Rd.Item("ref_status_id") = 2 Then
                        DataGridView1(5, baris).Style.BackColor = Color.Yellow
                    ElseIf Rd.Item("ref_status_id") = 4 Then
                        DataGridView1(5, baris).Style.BackColor = Color.Red
                    ElseIf Rd.Item("ref_status_id") = 5 Then
                        DataGridView1(5, baris).Style.BackColor = Color.LightBlue
                    ElseIf Rd.Item("ref_status_id") = 6 Then
                        DataGridView1(5, baris).Style.BackColor = Color.Blue
                    ElseIf Rd.Item("ref_status_id") = 7 Then
                        DataGridView1(5, baris).Style.BackColor = Color.LawnGreen
                    ElseIf Rd.Item("ref_status_id") = 8 Then
                        DataGridView1(5, baris).Style.BackColor = Color.Green
                    ElseIf Rd.Item("ref_status_id") = 9 Then
                        DataGridView1(5, baris).Style.BackColor = Color.MediumSlateBlue
                    End If

                    If Rd.Item("ref_prioritas_id") = 1 Then
                        DataGridView1(6, baris).Style.ForeColor = Color.Red
                    ElseIf Rd.Item("ref_prioritas_id") = 2 Then
                        DataGridView1(6, baris).Style.ForeColor = Color.Blue
                    ElseIf Rd.Item("ref_prioritas_id") = 3 Then
                        DataGridView1(6, baris).Style.ForeColor = Color.Green
                    End If
                    baris = baris + 1
                Loop
                'TextBoxHasil.Text = baris
                DataGridView1.Columns(DataGridView1.ColumnCount - 2).Visible = False
                DataGridView1.Columns(DataGridView1.ColumnCount - 1).Visible = False
                LabelTotal.Text = "Total Data : " & baris
                ButtonExport.Enabled = True
                DataGridView1.Enabled = True

            Else
                MsgBox("Data Tidak Ditemukan", vbOKOnly, "MESSAGE")
                DataGridView1.Columns.Clear()
                DataGridView1.Enabled = False
                ButtonExport.Enabled = False
                LabelTotal.Text = ""
            End If
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub resetForm()
        TextBoxRequestId.Text = ""
        TextBoxSubject.Text = ""
        DataGridView1.Columns.Clear()
        LabelTotal.Text = ""
        ComboBoxDivisi.SelectedValue = -1
        ComboBoxStatus.SelectedValue = -1
        ButtonExport.Enabled = False
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        GetData()
    End Sub

    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        resetForm()
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        Try
            Dim ExcelApp As Object
            Dim ExcelBook As Object
            Dim ExcelSheet As Object
            ExcelApp = CreateObject("Excel.Application")
            ExcelBook = ExcelApp.WorkBooks.Add
            ExcelSheet = ExcelBook.WorkSheets(1)
            For i = 1 To DataGridView1.RowCount + 1
                For j = 1 To DataGridView1.ColumnCount
                    If i = 1 Then
                        ExcelSheet.cells(i, j) = DataGridView1.Columns(j - 1).HeaderText
                    Else
                        ExcelSheet.cells(i, j) = DataGridView1(j - 1, i - 2).Value
                    End If
                Next
            Next
            ExcelApp.Visible = True
            ExcelSheet = Nothing
            ExcelBook = Nothing
            ExcelApp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub hapusData()
        Call Koneksi()
        Cmd = New MySqlCommand("delete from request where request_id = '" & DataGridView1.CurrentRow.Cells(0).Value & "'", Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Request dengan Subject " & DataGridView1.CurrentRow.Cells(3).Value & " telah dihapus", vbOKOnly, "Success Message")
        resetForm()
    End Sub

    Private Sub EditDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDataToolStripMenuItem.Click
        FormAddRequest.LabelId.Text = DataGridView1.CurrentRow.Cells(0).Value
        FormAddRequest.ShowDialog()
    End Sub

    Private Sub HapusDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusDataToolStripMenuItem.Click
        Select Case MsgBox("Apakah anda yakin ingin menghapus Request " & DataGridView1.CurrentRow.Cells(3).Value & " ?", MsgBoxStyle.YesNo, "MESSAGE")
            Case MsgBoxResult.Yes
                hapusData()
        End Select
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If DataGridView1.CurrentRow.Cells(DataGridView1.ColumnCount - 1).Value = 7 Then
            KonfirmasiSelesaiToolStripMenuItem.Visible = True
        Else
            KonfirmasiSelesaiToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Async Sub KonfirmasiSelesaiToolStripMenuItem_ClickAsync(sender As Object, e As EventArgs) Handles KonfirmasiSelesaiToolStripMenuItem.Click
        Select Case MsgBox("Apakah anda yakin akan mengkonfirmasi request ini ?", MsgBoxStyle.YesNo, "MESSAGE")
            Case MsgBoxResult.Yes
                Call Koneksi()
                Cmd = New MySqlCommand("Update request set status=@status, user_upd=@user_upd, dtm_upd=@dtm_upd where request_id = '" & DataGridView1.CurrentRow.Cells(0).Value & "'", Conn)
                Cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 8
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = activeUserData.getUserName
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()

                Call Koneksi()
                Cmd = New MySqlCommand("SELECT user_id, divisi_id, chat_id_telegram FROM user where divisi_id = '" & DataGridView1.CurrentRow.Cells(DataGridView1.ColumnCount - 2).Value & "'", Conn)
                Rd = Cmd.ExecuteReader
                '  Rd.Read()
                If Rd.HasRows Then
                    Do While Rd.Read
                        Dim chatIdTujuan As Long = Rd.Item("chat_id_telegram")
                        Dim pesan As String
                        pesan = "** TASK DENGAN ID : " & DataGridView1.CurrentRow.Cells(0).Value & " TELAH TERKONFIRMASI MENJADI FINISH **" & Environment.NewLine & Environment.NewLine & Environment.NewLine &
                                "- Untuk Divisi : " & activeUserData.getDivisionName & Environment.NewLine & Environment.NewLine &
                                "- Subject : " & DataGridView1.CurrentRow.Cells(3).Value & Environment.NewLine & Environment.NewLine &
                                "- Deskripsi : " & DataGridView1.CurrentRow.Cells(4).Value & Environment.NewLine & Environment.NewLine &
                                "- Prioritas : " & DataGridView1.CurrentRow.Cells(6).Value & Environment.NewLine & Environment.NewLine &
                                "- User : " & activeUserData.getFullName & Environment.NewLine & Environment.NewLine
                        Await KirimPesanKeOrangLainAsync(botClient, chatIdTujuan, pesan, cts.Token)
                    Loop
                End If
                MsgBox("Update Status Berhasil", vbOKOnly, "Success Message")
                GetData()
        End Select
    End Sub

    Private Sub TextBoxRequestIdKeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxRequestId.KeyPress
        If e.KeyChar = Chr(13) Then
            GetData()
        End If
    End Sub

    Private Sub TextBoxSubjectKeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSubject.KeyPress
        If e.KeyChar = Chr(13) Then
            GetData()
        End If
    End Sub

    Private Sub ComboBoxDivisi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDivisi.SelectedIndexChanged

    End Sub

    Private Sub NotApproveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotApproveToolStripMenuItem.Click
        FormNotApprove.LabelId.Text = DataGridView1.CurrentRow.Cells(0).Value
        FormNotApprove.ShowDialog()
    End Sub

    Private Async Function ButtonAdd_ClickAsync(sender As Object, e As EventArgs) As Task Handles ButtonAdd.Click
        FormAddRequest.LabelId.Text = ""
        FormAddRequest.ShowDialog()

    End Function
End Class