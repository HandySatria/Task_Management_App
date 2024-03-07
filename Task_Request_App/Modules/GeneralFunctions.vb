Imports System.ComponentModel

Module GeneralFunctions

    Public db As Database
    ' Public activeUserData As UserData = Nothing

    Public Sub mainFunction()
        Dim connectionString As String = "server=localhost;user id=root;password=;port=3306;database=taskman;"
        db = New Database(connectionString)
    End Sub

    Public Sub processPullData(send As Object, e As DoWorkEventArgs)
        Dim param As paramWorker = CType(e.Argument, paramWorker)

        Dim db As Database = param.db
        Dim queries As Dictionary(Of String, String) = param.queries
        Dim params As Dictionary(Of String, Dictionary(Of String, Object)) = param.parameters
        Dim respond As New Dictionary(Of String, DatasetResult)

        Dim ds(queries.Count) As DataSet
        Dim i As Integer = 0

        For Each kvp As KeyValuePair(Of String, String) In queries
            ds(i) = New DataSet

            If params.ContainsKey(kvp.Key) Then
                respond.Add(kvp.Key, db.query(kvp.Value, ds(i), kvp.Key, params(kvp.Key)))
            Else
                respond.Add(kvp.Key, db.query(kvp.Value, ds(i), kvp.Key))
            End If
            i += 1
        Next
        e.Result = respond
    End Sub

    Public Function getRequestStatus(ByVal nilai As Integer) As String
        Dim statuses As New Dictionary(Of Integer, String)
        With statuses
            .Add(0, "Belum ada respon")
            .Add(1, "Disetujui")
            .Add(2, "Ditolak")
            .Add(3, "Diproses")
            .Add(4, "Selesai")
            .Add(5, "Finish by Client")
        End With
        Return statuses(nilai)
    End Function
End Module
