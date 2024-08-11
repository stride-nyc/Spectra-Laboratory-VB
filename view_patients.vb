Imports System.Data.SqlClient

Public Class view_patients
    Private Sub view_patients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        database.GetSQLConnection()
        'sqlcon.Open()

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text.Trim() <> "" Then
            ' Define the SQL query to select the record based on patientID
            Dim query As String = "SELECT * FROM patient WHERE patientID =" & TextBox1.Text.Trim() & ""


            Using command As New SqlCommand(query, sqlcon)

                ' Create a DataTable to store the result of the query
                Dim dataTable As New DataTable()

                Try
                    ' Execute the query and fill the DataTable with the result
                    Dim adapter As New SqlDataAdapter(command)
                    adapter.Fill(dataTable)

                    ' Check if any rows were returned
                    If dataTable.Rows.Count > 0 Then
                        ' Bind the DataTable to the DataGridView
                        DataGridView1.DataSource = dataTable
                    Else
                        ' If no record is found, display a message
                        MessageBox.Show("No record found with the specified patientID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    ' Handle any exceptions here
                    MessageBox.Show("Error retrieving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Else
            ' If TextBox1 is empty, display a message
            MessageBox.Show("Please enter a patientID.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox2.Text.Trim() <> "" Then
            ' Define the SQL query to select the record based on patientID
            Dim query As String = "SELECT * FROM patient WHERE Name like '%" & TextBox2.Text.Trim() & "%'"

            ' Create a SqlCommand object with the query and connection
            Using command As New SqlCommand(query, sqlcon)

                ' Create a DataTable to store the result of the query
                Dim dataTable As New DataTable()

                Try
                    ' Execute the query and fill the DataTable with the result
                    Dim adapter As New SqlDataAdapter(command)
                    adapter.Fill(dataTable)

                    ' Check if any rows were returned
                    If dataTable.Rows.Count > 0 Then
                        ' Bind the DataTable to the DataGridView
                        DataGridView1.DataSource = dataTable
                    Else
                        ' If no record is found, display a message
                        MessageBox.Show("No record found with the specified Name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    ' Handle any exceptions here
                    MessageBox.Show("Error retrieving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Else
            ' If TextBox2 is empty, display a message
            MessageBox.Show("Please enter a Name.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = "INSERT INTO patient (Name, DateofBirth, Gender, Address, PhoneNumber, MedicalHistory, EmergencyContactName, EmergencyContactPhone) VALUES ('" & TextBox2.Text.ToString.Trim() & "', '" & TextBox3.Text.ToString.Trim() & "', '" & TextBox4.Text.ToString.Trim() & "', '" & TextBox5.Text.ToString.Trim() & "', '" & TextBox6.Text.ToString.Trim() & "', '" & TextBox7.Text.ToString.Trim() & "', '" & TextBox8.Text.ToString.Trim() & "', '" & TextBox9.Text.ToString.Trim() & "')"

        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, sqlcon)
            ' Add parameters to the query and set their values from TextBoxes

            Try
                ' Open the connection and execute the query
                'sqlcon.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Check if the query was successful
                If rowsAffected > 0 Then
                    MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No rows were affected. Data insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                ' Handle any exceptions here
                MessageBox.Show("Error inserting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Close the connection
                'sqlcon.Close()
            End Try
        End Using
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "Delete From Patient WHERE PatientID =" & TextBox1.Text() & ""
        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, sqlcon)


            Try
                ' Open the connection and execute the query
                'sqlcon.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Check if the query was successful
                If rowsAffected > 0 Then
                    MessageBox.Show("Data Delted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No rows were affected. Data Deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                ' Handle any exceptions here
                MessageBox.Show("Error deleting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Close the connection
                'sqlcon.Close()
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query As String = "UPDATE patient SET "

        ' Get the patientID from TextBox1
        Dim patientID As String = TextBox1.Text.Trim()

        ' Check if TextBox2 has a value
        If TextBox2.Text.Trim() <> "" Then
            query &= "Name = '" & TextBox2.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox3 has a value
        If TextBox3.Text.Trim() <> "" Then
            query &= "DateofBirth = '" & TextBox3.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox4 has a value
        If TextBox4.Text.Trim() <> "" Then
            query &= "Gender = '" & TextBox4.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox5 has a value
        If TextBox5.Text.Trim() <> "" Then
            query &= "Address = '" & TextBox5.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox6 has a value
        If TextBox6.Text.Trim() <> "" Then
            query &= "PhoneNumber = '" & TextBox6.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox7 has a value
        If TextBox7.Text.Trim() <> "" Then
            query &= "MedicalHistory = '" & TextBox7.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox8 has a value
        If TextBox8.Text.Trim() <> "" Then
            query &= "EmergencyContactName = '" & TextBox8.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox9 has a value
        If TextBox9.Text.Trim() <> "" Then
            query &= "EmergencyContactPhone = '" & TextBox9.Text.ToString.Trim() & "', "
        End If

        ' Remove the trailing comma and space if values have been added to the query
        If query.EndsWith(", ") Then
            query = query.Substring(0, query.Length - 2)
        End If

        ' Append the WHERE clause to identify the record to be updated
        query &= " WHERE PatientID = " & TextBox1.Text.Trim() & ""


        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, sqlcon)
            ' Add parameters to the query and set their values from TextBoxes
            'command.Parameters.AddWithValue("@PatientID", patientID)
            '
            'If TextBox2.Text.Trim() <> "" Then
            '    command.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
            'End If
            '
            'If TextBox3.Text.Trim() <> "" Then
            '    command.Parameters.AddWithValue("@DateofBirth", TextBox3.Text.Trim())
            'End If
            '
            'If TextBox4.Text.Trim() <> "" Then
            '    command.Parameters.AddWithValue("@Gender", TextBox4.Text.Trim())
            'End If
            '
            'If TextBox5.Text.Trim() <> "" Then
            '    command.Parameters.AddWithValue("@Address", TextBox5.Text.Trim())
            'End If
            '
            'If TextBox6.Text.Trim() <> "" Then
            '    command.Parameters.AddWithValue("@PhoneNumber", TextBox6.Text.Trim())
            'End If
            '
            'If TextBox7.Text.Trim() <> "" Then
            '    command.Parameters.AddWithValue("@MedicalHistory", TextBox7.Text.Trim())
            'End If
            '
            'If TextBox8.Text.Trim() <> "" Then
            '    command.Parameters.AddWithValue("@EmergencyContactName", TextBox8.Text.Trim())
            'End If
            '
            'If TextBox9.Text.Trim() <> "" Then
            '    command.Parameters.AddWithValue("@EmergencyContactPhone", TextBox9.Text.Trim())
            'End If

            Try
                ' Open the connection and execute the query
                'sqlcon.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Check if the query was successful
                If rowsAffected > 0 Then
                    MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No record was updated. No matching record found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                ' Handle any exceptions here
                MessageBox.Show("Error updating record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Close the connection
                'sqlcon.Close()
            End Try
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        admin_page.Show()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class