Public Class DatasetResult
    Public isSuccess As Boolean
    Public dataset As DataSet
    Public errorMessage As String

    Sub New(ByVal dset As DataSet)
        isSuccess = False
        dataset = dset
        errorMessage = ""
    End Sub
End Class

Public Class StringResult
    Public isSuccess As Boolean
    Public value As String
    Public errorMessage As String

    Sub New()
        isSuccess = False
        value = ""
        errorMessage = ""
    End Sub
End Class

Public Class paramWorker
    Public db As Database
    Public queries As New Dictionary(Of String, String)
    Public parameters As New Dictionary(Of String, Dictionary(Of String, Object))

    Sub New(ByVal dbase As Database)
        db = dbase
    End Sub
End Class
