
Imports DevExpress.DashboardWin

Public Class XtraForm1

    Private Sub XtraForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        DashboardViewer1.Dashboard.Parameters("FromDivisiId").Value = 5
        DashboardViewer1.ReloadData()
    End Sub


End Class

