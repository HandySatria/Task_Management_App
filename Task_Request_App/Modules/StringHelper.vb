Module StringHelper

    Public Function ReadException(ByVal ex As Exception) As String
        Dim errorMessage As String = ex.Message

        If ex.InnerException IsNot Nothing Then errorMessage &= vbCrLf & ReadException(ex.InnerException)

        Return errorMessage
    End Function
End Module
