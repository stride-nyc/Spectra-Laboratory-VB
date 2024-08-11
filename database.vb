Imports System.Data.SqlClient

Module database
    Public sqlcon As New SqlConnection("server = Legion-5\SQLEXPRESS; database = lab3; Integrated security = True")
    Public Function GetSQLConnection() As SqlConnection
        Return sqlcon
    End Function
End Module
