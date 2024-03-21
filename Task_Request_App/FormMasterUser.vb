Imports MySql.Data.MySqlClient
Public Class FormMasterUser
    Dim Cari_Data, Condition As String
    Dim baris As Integer
    Dim divisiDictionary As New Dictionary(Of Integer, String)()
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'FormAddUser.LabelId.Text = ""
        'FormAddUser.ShowDialog()
        Using f As New FormAddUser
            f.ShowDialog()
            GetData()
        End Using
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        GetData()
    End Sub

    Sub resetForm()
        TextBoxNama.Text = ""
        TextBoxUsername.Text = ""
        DataGridView1.Columns.Clear()
        LabelTotal.Text = ""
        ComboBoxDivisi.SelectedValue = -1
        ButtonExport.Enabled = False
    End Sub

    Private Sub FormMasterUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub GetData()
        Try
            Condition = " Where 1=1"
            If TextBoxUsername.Text IsNot "" Then
                Condition = Condition & " and u.username like '%" & TextBoxUsername.Text & "%'"
            End If
            If TextBoxNama.Text IsNot "" Then
                Condition = Condition & " and u.fullname like '%" & TextBoxNama.Text & "%'"
            End If
            If ComboBoxDivisi.SelectedItem IsNot Nothing Then
                If DirectCast(ComboBoxDivisi.SelectedValue, Integer) >= 0 Then
                    Condition = Condition & " and d.divisi_id = '" & DirectCast(ComboBoxDivisi.SelectedValue, Integer) & "'"
                End If
            End If

            Call Koneksi()
            Cari_Data = "SELECT u.user_id as user_id, u.fullname as fullname, u.username as username, u.password as password, d.divisi_name as divisi_name, u.user_crt as user_crt, u.user_upd as user_upd, u.dtm_crt as dtm_crt, u.dtm_upd as dtm_upd 
                         FROM user u 
                           left join divisi d on u.divisi_id = d.divisi_id" & Condition
            Cmd = New MySqlCommand(Cari_Data, Conn)
            Rd = Cmd.ExecuteReader
            DataGridView1.Columns.Clear()

            'Call format_dgv(DataGridView1)
            DataGridView1.ColumnCount = 9
            baris = 0
            If Rd.HasRows Then
                DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("sanserif", 10, FontStyle.Regular)
                DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView1.DefaultCellStyle.Font = New Font("sanserif", 10, FontStyle.Regular)
                DataGridView1.DefaultCellStyle.ForeColor = Color.Black
                DataGridView1.Columns(0).Width = 60
                DataGridView1.Columns(1).Width = 150
                DataGridView1.Columns(2).Width = 150
                DataGridView1.Columns(3).Width = 150
                DataGridView1.Columns(4).Width = 150
                DataGridView1.Columns(5).Width = 100
                DataGridView1.Columns(6).Width = 100
                DataGridView1.Columns(7).Width = 150
                DataGridView1.Columns(8).Width = 150

                DataGridView1.Columns(0).HeaderText = "ID"
                DataGridView1.Columns(1).HeaderText = "Nama Panjang"
                DataGridView1.Columns(2).HeaderText = "Username"
                DataGridView1.Columns(3).HeaderText = "Password"
                DataGridView1.Columns(4).HeaderText = "Divisi"
                DataGridView1.Columns(5).HeaderText = "User Create"
                DataGridView1.Columns(6).HeaderText = "User Update"
                DataGridView1.Columns(7).HeaderText = "DateTime Create"
                DataGridView1.Columns(8).HeaderText = "DateTime Update"
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Do While Rd.Read
                    DataGridView1.Rows.Add()
                    DataGridView1(0, baris).Value = Rd.Item("user_id")
                    DataGridView1(1, baris).Value = Rd.Item("fullname")
                    DataGridView1(2, baris).Value = Rd.Item("username")
                    DataGridView1(3, baris).Value = Rd.Item("password")
                    DataGridView1(4, baris).Value = Rd.Item("divisi_name")
                    DataGridView1(5, baris).Value = Rd.Item("user_crt")
                    DataGridView1(6, baris).Value = Rd.Item("user_upd")
                    DataGridView1(7, baris).Value = Rd.Item("dtm_crt")
                    DataGridView1(8, baris).Value = Rd.Item("dtm_upd")

                    baris = baris + 1
                Loop
                'TextBoxHasil.Text = baris
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

    Sub hapusData()
        Call Koneksi()
        Cmd = New MySqlCommand("delete from user where user_id = '" & DataGridView1.CurrentRow.Cells(0).Value & "'", Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("User " & DataGridView1.CurrentRow.Cells(1).Value & " telah dihapus", vbOKOnly, "Success Message")
        'resetForm()
        GetData()
    End Sub

    Private Sub TextBoxNamaKeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxNama.KeyPress
        If e.KeyChar = Chr(13) Then
            GetData()
        End If
    End Sub

    Private Sub EditDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDataToolStripMenuItem.Click
        'FormAddUser.LabelId.Text = DataGridView1.CurrentRow.Cells(0).Value
        'FormAddUser.ShowDialog()
        Using f As New FormAddUser(DataGridView1.CurrentRow.Cells(0).Value)
            f.ShowDialog(Me)
            GetData()
        End Using
    End Sub

    Private Sub HapusDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusDataToolStripMenuItem.Click
        Select Case MsgBox("Apakah anda yakin ingin menghapus User " & DataGridView1.CurrentRow.Cells(1).Value & " ?", MsgBoxStyle.YesNo, "MESSAGE")
            Case MsgBoxResult.Yes
                hapusData()
        End Select
    End Sub

    Private Sub TextBoxUsernameKeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxUsername.KeyPress
        If e.KeyChar = Chr(13) Then
            GetData()
        End If
    End Sub

End Class