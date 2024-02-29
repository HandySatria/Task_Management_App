﻿Public Class UserData
    Private divisionId As Integer
    Private divisionName As String
    Private userId As Integer
    Private userName As String
    Private fullName As String
    Private isAdmin As Boolean

    Sub New(ByVal divId As Integer, ByVal divName As String, ByVal uId As Integer, ByVal uName As String, ByVal fName As String, ByVal isAdm As Boolean)
        divisionId = divId
        divisionName = divName
        userId = uId
        userName = uName
        fullName = fName
        isAdmin = isAdm
    End Sub

    Function getUserId() As Integer
        Return userId
    End Function

    Function getUserName() As String
        Return userName
    End Function

    Function getFullName() As String
        Return fullName
    End Function

    Function getDivisionId() As Integer
        Return divisionId
    End Function

    Function getIsAdmin() As Integer
        Return isAdmin
    End Function

    Function getDivisionName() As String
        Return divisionName
    End Function
End Class
