'Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Public Class FormTask
    Dim Cari_Data, Condition As String
    Dim baris As Integer
    Dim divisiDictionary As New Dictionary(Of Integer, String)()
    Dim statusDictionary As New Dictionary(Of Integer, String)()
    'Private Sub send()
    '    Try
    '        Dim SMTPclient As New SmtpClient
    '        Dim SendMail As New MailMessage()
    '        Dim Email As String
    '        Email = "it.laritta@gmail.com"
    '        Dim password As String
    '        password = "@laritta11"
    '        SMTPclient.UseDefaultCredentials = False
    '        SMTPclient.Credentials = New Net.NetworkCredential(Email, password)
    '        SMTPclient.Port = 587
    '        SMTPclient.EnableSsl = True
    '        SMTPclient.Host = "smtp.gmail.com"
    '        SendMail = New MailMessage()
    '        SendMail.From = New MailAddress("it.laritta@gmail.com")
    '        SendMail.To.Add("satriahandy455@gmail.com")
    '        SendMail.Subject = "Hai"
    '        SendMail.IsBodyHtml = False
    '        SendMail.Body = "Coba kirim pesan"
    '        SMTPclient.Send(SendMail)
    '        MsgBox("Email Sudah Terkirim")
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub
    Private Sub GetData()
        Try
            Condition = " Where dTo.divisi_id = " & Divisi_Id_User
            If TextBoxTaskId.Text IsNot "" Then
                Condition = Condition & " and r.request_id = '" & TextBoxTaskId.Text & "'"
            End If
            If TextBoxSubject.Text IsNot "" Then
                Condition = Condition & " and r.subject like '%" & TextBoxSubject.Text & "%'"
            End If
            If ComboBoxDivisi.SelectedItem IsNot Nothing Then
                If DirectCast(ComboBoxDivisi.SelectedValue, Integer) >= 0 Then
                    Condition = Condition & " and dFrom.divisi_id = '" & DirectCast(ComboBoxDivisi.SelectedValue, Integer) & "'"
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
            Cari_Data = "select r.request_id as request_id, r.subject as subject, r.description description, dTo.divisi_name as to_divisi, dFrom.divisi_name as from_divisi, 
                                rs.status_name as status_name, rs.ref_status_id as ref_status_id, r.user_crt as user_crt, r.user_upd as user_upd, r.dtm_crt as dtm_crt, r.dtm_upd as dtm_upd 
                        from request r 
                            left join divisi dTo on dTo.divisi_id = r.to_divisi 
                            left join divisi dFrom on dFrom.divisi_id = r.from_divisi 
                            left join ref_status rs on rs.ref_status_id = r.status" & Condition
            Cmd = New MySqlCommand(Cari_Data, Conn)
            Rd = Cmd.ExecuteReader
            DataGridView1.Columns.Clear()

            'Call format_dgv(DataGridView1)
            DataGridView1.ColumnCount = 11
            baris = 0
            If Rd.HasRows Then
                DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("sanserif", 10, FontStyle.Regular)
                DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView1.DefaultCellStyle.Font = New Font("sanserif", 10, FontStyle.Regular)
                DataGridView1.DefaultCellStyle.ForeColor = Color.Black
                DataGridView1.Columns(0).Width = 40
                DataGridView1.Columns(1).Width = 150
                DataGridView1.Columns(2).Width = 150
                DataGridView1.Columns(3).Width = 250
                DataGridView1.Columns(4).Width = 150
                DataGridView1.Columns(5).Width = 150
                DataGridView1.Columns(6).Width = 100
                DataGridView1.Columns(7).Width = 100
                DataGridView1.Columns(8).Width = 150
                DataGridView1.Columns(9).Width = 150

                DataGridView1.Columns(0).HeaderText = "ID"
                DataGridView1.Columns(1).HeaderText = "Dari Divisi"
                DataGridView1.Columns(2).HeaderText = "Ke Divisi    "
                DataGridView1.Columns(3).HeaderText = "Subjek"
                DataGridView1.Columns(4).HeaderText = "Deskripsi"
                DataGridView1.Columns(5).HeaderText = "Status"
                DataGridView1.Columns(6).HeaderText = "User Create"
                DataGridView1.Columns(7).HeaderText = "User Update"
                DataGridView1.Columns(8).HeaderText = "DateTime Create"
                DataGridView1.Columns(9).HeaderText = "DateTime Update"
                DataGridView1.Columns(10).HeaderText = "Id Status"
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Do While Rd.Read
                    DataGridView1.Rows.Add()
                    DataGridView1(0, baris).Value = Rd.Item("request_id")
                    DataGridView1(1, baris).Value = Rd.Item("from_divisi")
                    DataGridView1(2, baris).Value = Rd.Item("to_divisi")
                    DataGridView1(3, baris).Value = Rd.Item("subject")
                    DataGridView1(4, baris).Value = Rd.Item("description")
                    DataGridView1(5, baris).Value = Rd.Item("status_name")
                    DataGridView1(6, baris).Value = Rd.Item("user_crt")
                    DataGridView1(7, baris).Value = Rd.Item("user_upd")
                    DataGridView1(8, baris).Value = Rd.Item("dtm_crt")
                    DataGridView1(9, baris).Value = Rd.Item("dtm_upd")
                    DataGridView1(10, baris).Value = Rd.Item("ref_status_id")
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
                    End If
                    baris = baris + 1
                Loop
                'TextBoxHasil.Text = baris
                DataGridView1.Columns(10).Visible = False
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
            If divisiId = Divisi_Id_User Then
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
            statusDictionary.Add(Rd.Item("ref_status_id"), Rd.Item("status_name"))
            ComboBoxStatus.Items.Add(statusDictionary)
        Loop
        ComboBoxStatus.DisplayMember = "Value"
        ComboBoxStatus.ValueMember = "Key"
        ComboBoxStatus.DataSource = New BindingSource(statusDictionary, Nothing)
    End Sub

    Sub resetForm()
        TextBoxTaskId.Text = ""
        TextBoxSubject.Text = ""
        DataGridView1.Columns.Clear()
        LabelTotal.Text = ""
        ComboBoxDivisi.SelectedValue = -1
        ComboBoxStatus.SelectedValue = -1
        ButtonExport.Enabled = False
    End Sub

    Private Sub FormTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setComboBoxValue()
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

    Private Sub SetujuiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetujuiToolStripMenuItem.Click
        Select Case MsgBox("Apakah anda yakin akan menyetujui request ini ?", MsgBoxStyle.YesNo, "MESSAGE")
            Case MsgBoxResult.Yes
                Call Koneksi()
                Cmd = New MySqlCommand("Update request set status=@status, user_upd=@user_upd, dtm_upd=@dtm_upd where request_id = '" & DataGridView1.CurrentRow.Cells(0).Value & "'", Conn)
                Cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 5
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = Nama_User
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()
                MsgBox("Update Status Berhasil", vbOKOnly, "Success Message")
                GetData()
        End Select
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If DataGridView1.CurrentRow.Cells(10).Value = 1 Or DataGridView1.CurrentRow.Cells(10).Value = 2 Then
            SetujuiToolStripMenuItem.Visible = True
            TidakSetujuToolStripMenuItem.Visible = True
        Else
            SetujuiToolStripMenuItem.Visible = False
            TidakSetujuToolStripMenuItem.Visible = False
        End If

        If DataGridView1.CurrentRow.Cells(10).Value = 5 Then
            OnProgressToolStripMenuItem.Visible = True
        Else
            OnProgressToolStripMenuItem.Visible = False
        End If

        If DataGridView1.CurrentRow.Cells(10).Value = 6 Then
            DoneToolStripMenuItem.Visible = True
        Else
            DoneToolStripMenuItem.Visible = False
        End If

    End Sub

    Private Sub TidakSetujuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TidakSetujuToolStripMenuItem.Click
        Select Case MsgBox("Apakah anda yakin tidak menyetujui request ini ?", MsgBoxStyle.YesNo, "MESSAGE")
            Case MsgBoxResult.Yes
                Call Koneksi()
                Cmd = New MySqlCommand("Update request set status=@status, user_upd=@user_upd, dtm_upd=@dtm_upd where request_id = '" & DataGridView1.CurrentRow.Cells(0).Value & "'", Conn)
                Cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 4
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = Nama_User
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()
                MsgBox("Update Status Berhasil", vbOKOnly, "Success Message")
                GetData()
        End Select
    End Sub

    Private Sub OnProgressToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnProgressToolStripMenuItem.Click
        Select Case MsgBox("Apakah anda yakin akan memproses request ini sekarang ?", MsgBoxStyle.YesNo, "MESSAGE")
            Case MsgBoxResult.Yes
                Call Koneksi()
                Cmd = New MySqlCommand("Update request set status=@status, user_upd=@user_upd, dtm_upd=@dtm_upd where request_id = '" & DataGridView1.CurrentRow.Cells(0).Value & "'", Conn)
                Cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 6
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = Nama_User
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()
                MsgBox("Update Status Berhasil", vbOKOnly, "Success Message")
                GetData()
        End Select
    End Sub

    Private Sub DoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoneToolStripMenuItem.Click
        Select Case MsgBox("Apakah anda yakin sudah menyelesaikan request ini ?", MsgBoxStyle.YesNo, "MESSAGE")
            Case MsgBoxResult.Yes
                Call Koneksi()
                Cmd = New MySqlCommand("Update request set status=@status, user_upd=@user_upd, dtm_upd=@dtm_upd where request_id = '" & DataGridView1.CurrentRow.Cells(0).Value & "'", Conn)
                Cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 7
                Cmd.Parameters.Add("@user_upd", MySqlDbType.VarChar).Value = Nama_User
                Cmd.Parameters.Add("@dtm_upd", MySqlDbType.DateTime).Value = DateTime.Now
                Cmd.ExecuteNonQuery()
                MsgBox("Update Status Berhasil", vbOKOnly, "Success Message")
                GetData()
        End Select
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        'Try
        '    Dim web As New WebBrowser
        '    web.Navigate("whatsapp://send?phone=+6281235537927&text=" & TextBoxTaskId.Text.Replace(" ", "+") & "")
        '    Timer1.Start()
        'Catch ex As Exception
        '    Timer1.Stop()
        'End Try
        'send()
        GetData()


    End Sub
    'Dim sec As Integer = 0
    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    sec += 1
    '    If sec = 10 Then
    '        SendKeys.Send("{ENTER}")
    '        Timer1.Stop()
    '        sec = 0
    '    End If

    'End Sub
End Class