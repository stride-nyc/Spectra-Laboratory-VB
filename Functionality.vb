Imports System.Data.SqlClient

Module Functionality
    ' Connection string to connect to the SQL Server database
    Private connectionString As String = "server = Legion-5\SQLEXPRESS ; database = lab; Integrated security = True"

    ' Function to execute a SELECT query
    Public Function SelectQuery(query As String, parameters As List(Of SqlParameter)) As DataTable
        Dim dt As New DataTable()

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters.ToArray())
                End If

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    ' Function to execute an INSERT query
    Public Function InsertQuery(query As String, parameters As List(Of SqlParameter)) As Integer
        Return ExecuteNonQuery(query, parameters)
    End Function

    ' Function to execute an UPDATE query
    Public Function UpdateQuery(query As String, parameters As List(Of SqlParameter)) As Integer
        Return ExecuteNonQuery(query, parameters)
    End Function

    ' Function to execute a DELETE query
    Public Function DeleteQuery(query As String, parameters As List(Of SqlParameter)) As Integer
        Return ExecuteNonQuery(query, parameters)
    End Function

    ' Helper function to execute non-query commands (INSERT, UPDATE, DELETE)
    Private Function ExecuteNonQuery(query As String, parameters As List(Of SqlParameter)) As Integer
        Dim result As Integer

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters.ToArray())
                End If

                con.Open()
                result = cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        Return result
    End Function

    ' Function to build a parameterized SELECT query
    Public Function BuildSelectQuery(table As String, columns As List(Of String), condition As String, parameters As List(Of SqlParameter)) As String
        Dim columnList As String = String.Join(", ", columns)
        Dim query As String = $"SELECT {columnList} FROM {table}"

        If Not String.IsNullOrEmpty(condition) Then
            query &= " WHERE " & condition
        End If

        Return query
    End Function

    ' Function to build a parameterized INSERT query
    Public Function BuildInsertQuery(table As String, columns As List(Of String), values As List(Of String)) As String
        Dim columnList As String = String.Join(", ", columns)
        Dim valuePlaceholders As String = String.Join(", ", values.Select(Function(v, i) "@param" & i))
        Dim query As String = $"INSERT INTO {table} ({columnList}) VALUES ({valuePlaceholders})"
        MessageBox.Show(query)
        Return query
    End Function


    ' Function to build a parameterized UPDATE query
    Public Function BuildUpdateQuery(table As String, updates As List(Of String), condition As String, parameters As List(Of SqlParameter)) As String
        Dim updateList As String = String.Join(", ", updates)
        Dim query As String = $"UPDATE {table} SET {updateList}"

        If Not String.IsNullOrEmpty(condition) Then
            query &= " WHERE " & condition
        End If

        Return query
    End Function

    ' Function to build a parameterized DELETE query
    Public Function BuildDeleteQuery(table As String, condition As String, parameters As List(Of SqlParameter)) As String
        Dim query As String = $"DELETE FROM {table}"

        If Not String.IsNullOrEmpty(condition) Then
            query &= " WHERE " & condition
        End If

        Return query
    End Function

End Module
