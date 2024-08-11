Imports System.Data.SqlClient

Public Class RequestID
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GlobalVariables.RequestIDResult = TextBox1.Text.Trim()
        Dim query As String = "Select TestID FROM TestResult WHERE RequestID = " & GlobalVariables.RequestIDResult & ""
        Dim TestID As Integer = 0
        While TestID = 0
            Using cmd As New SqlCommand(query, sqlcon)


                Try

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then

                            reader.Read()
                            TestID = Convert.ToInt32(reader("TestID"))
                            If reader.Read() Then

                                MessageBox.Show("Multiple records found with the Request ID. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else


                            End If
                        Else

                            MessageBox.Show("No record found with the specified Request ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                Catch ex As Exception

                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End Using
        End While

        If TestID = 2 Or TestID = 4 Or TestID = 5 Then
            Me.Hide()
            Radiology_Result.Show()
        Else
            Me.Hide()
            Normal_Result.Show()
        End If
    End Sub

    Private Sub RequestID_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class