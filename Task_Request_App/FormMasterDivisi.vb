Imports MySql.Data.MySqlClient
Public Class FormMasterDivisi
    Dim Cari_Data, Condition As String
    Dim baris As Integer
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FormAddDivisi.LabelId.Text = ""
        FormAddDivisi.ShowDialog()
    End Sub

    Private Sub GetData()
        Try
            Condition = " Where 1=1"
            If TextBoxNamaDivisi.Text IsNot "" Then
                Condition = Condition & " and divisi_name like '%" & TextBoxNamaDivisi.Text & "%'"
            End If
            If TextBoxIdDivisi.Text IsNot "" Then
                Condition = Condition & " and divisi_id = '" & TextBoxIdDivisi.Text & "'"
            End If

            Call Koneksi()
            Cari_Data = "SELECT divisi_id, divisi_name, user_crt, user_upd, dtm_crt,dtm_upd FROM divisi" & Condition
            Cmd = New MySqlCommand(Cari_Data, Conn)
            Rd = Cmd.ExecuteReader
            DataGridView1.Columns.Clear()

            'Call format_dgv(DataGridView1)
            DataGridView1.ColumnCount = 6
            baris = 0
            If Rd.HasRows Then
                DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("sanserif", 10, FontStyle.Regular)
                DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView1.DefaultCellStyle.Font = New Font("sanserif", 10, FontStyle.Regular)
                DataGridView1.DefaultCellStyle.ForeColor = Color.Black
                DataGridView1.Columns(0).Width = 120
                DataGridView1.Columns(1).Width = 300
                DataGridView1.Columns(2).Width = 150
                DataGridView1.Columns(3).Width = 150
                DataGridView1.Columns(4).Width = 150
                DataGridView1.Columns(5).Width = 150
                DataGridView1.Columns(0).HeaderText = "ID Divisi"
                DataGridView1.Columns(1).HeaderText = "Nama Divisi"
                DataGridView1.Columns(2).HeaderText = "User Create"
                DataGridView1.Columns(3).HeaderText = "User Update"
                DataGridView1.Columns(4).HeaderText = "DateTime Create"
                DataGridView1.Columns(5).HeaderText = "DateTime Update"
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Do While Rd.Read
                    DataGridView1.Rows.Add()
                    DataGridView1(0, baris).Value = Rd.Item("divisi_id")
                    DataGridView1(1, baris).Value = Rd.Item("divisi_name")
                    DataGridView1(2, baris).Value = Rd.Item("user_crt")
                    DataGridView1(3, baris).Value = Rd.Item("user_upd")
                    DataGridView1(4, baris).Value = Rd.Item("dtm_crt")
                    DataGridView1(5, baris).Value = Rd.Item("dtm_upd")

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

    Sub resetForm()
        TextBoxIdDivisi.Text = ""
        TextBoxNamaDivisi.Text = ""
        DataGridView1.Columns.Clear()
        LabelTotal.Text = ""
        ButtonExport.Enabled = False
    End Sub

    Private Sub TextBoxNamaDivisi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxNamaDivisi.KeyPress
        If e.KeyChar = Chr(13) Then
            GetData()
        End If
    End Sub
    Private Sub TextBoxIdDivisi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxIdDivisi.KeyPress
        If e.KeyChar = Chr(13) Then
            GetData()
        End If
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

    Private Sub FormMasterDivisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetForm()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        FormAddDivisi.LabelId.Text = DataGridView1.CurrentRow.Cells(0).Value
        FormAddDivisi.TextBoxNamaDivisi.Text = DataGridView1.CurrentRow.Cells(1).Value
        FormAddDivisi.ShowDialog()
    End Sub
    Sub hapusData()
        Call Koneksi()
        Cmd = New MySqlCommand("delete from divisi where divisi_id = '" & DataGridView1.CurrentRow.Cells(0).Value & "'", Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Divisi " & DataGridView1.CurrentRow.Cells(1).Value & " telah dihapus", vbOKOnly, "Success Message")
        resetForm()
    End Sub
    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        Select Case MsgBox("Apakah anda yakin ingin menghapus Divisi " & DataGridView1.CurrentRow.Cells(1).Value & " ?", MsgBoxStyle.YesNo, "MESSAGE")
            Case MsgBoxResult.Yes
                hapusData()
        End Select
    End Sub


    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        GetData()
    End Sub
End Class