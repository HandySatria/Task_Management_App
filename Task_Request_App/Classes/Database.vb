Imports MySql.Data.MySqlClient

Public Class Database
    Private connectionString As String

    Sub New(ByVal mysqlConnectionString As String)
        connectionString = mysqlConnectionString
    End Sub

    ''' <summary>
    ''' Mendapatkan data dari query yang diberikan, lalu menambahkan datatable ke dataset dengan nama tabel yang diinginkan.
    ''' Akan mengembalikan data dengan parameter isSuccess yang menentukan sukses atau tidaknya proses
    ''' Kemudian mengembalikan dataset yang belum berubah jika gagal, disertai errorMessage yang berisi pesan error jika ditemukan error
    ''' </summary>
    ''' <param name="sqlQuery">Query yang akan dijalankan untuk mendapatkan data</param>
    ''' <param name="dataset">Dataset yang akan menampung datatable berisi hasil dari query </param>
    ''' <param name="tableName">Nama tabel yang digunakan untuk hasil query ini</param>
    ''' <param name="queryParams">(Optional) Parameter yang digunakan ketika query dijalankan. Disarankan menggunakan parameter untuk meningkatkan keamanan</param>
    ''' <returns></returns>
    Public Function query(ByVal sqlQuery As String, ByVal dataset As DataSet, ByVal tableName As String, Optional ByVal queryParams As Dictionary(Of String, Object) = Nothing) As DatasetResult
        Dim result As New DatasetResult(dataset)

        Using conn = New MySqlConnection(connectionString)
            Try
                Dim dataAdapter As New MySqlDataAdapter(sqlQuery, conn)

                'Jika ada parameter untuk query, maka tambahkan parameter ke data adapter
                If queryParams IsNot Nothing Then
                    For Each kvp As KeyValuePair(Of String, Object) In queryParams
                        dataAdapter.SelectCommand.Parameters.AddWithValue(kvp.Key, kvp.Value)
                    Next
                End If

                'Set timeout 30 detik
                dataAdapter.SelectCommand.CommandTimeout = 30
                dataAdapter.Fill(dataset, tableName)

                dataAdapter.Dispose()

                result.isSuccess = True
                result.dataset = dataset
            Catch ex As Exception
                result.errorMessage = ReadException(ex)
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Dispose()
            End Try
        End Using

        Return result
    End Function

    Public Function executeQuery(ByVal sqlQuery As String, Optional ByVal queryParams As Dictionary(Of String, Object) = Nothing) As StringResult
        Dim command As MySqlCommand = Nothing
        Dim result As New StringResult

        Using conn = New MySqlConnection(connectionString)
            Try
                command = New MySqlCommand(sqlQuery, conn)
                conn.Open()

                'Jika ada parameter untuk query, maka tambahkan parameter ke data adapter
                If queryParams IsNot Nothing Then
                    For Each kvp As KeyValuePair(Of String, Object) In queryParams
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value)
                    Next
                End If

                command.ExecuteNonQuery()

                result.isSuccess = True
                result.value = command.LastInsertedId.ToString
            Catch ex As Exception
                result.errorMessage = ReadException(ex)
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
                command.Dispose()
            End Try
        End Using

        Return result
    End Function
End Class
