Imports System.Data.SqlClient

Public Class Insert_Results
    Dim image_Path As String
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        database.GetSQLConnection()

        Dim query As String = "SELECT tr.ResultID, tr.PID, tr.RequestID, tr.TestID, tr.ResultValue, tr.ResultDate, tr.PerformedBy, tr.Flag, tr.Notes, img.Image_Path " &
                             "FROM TestResult tr " &
                             "LEFT JOIN Images img ON tr.RequestID = img.Request_ID"


        ' Create a SqlDataAdapter to execute the query and fill the DataTable
        Using adapter As New SqlDataAdapter(query, sqlcon)
            ' Create a DataTable to hold the query results
            Dim dataTable As New DataTable()

            Try
                ' Fill the DataTable with the query results
                adapter.Fill(dataTable)

                ' Bind the DataTable to the DataGridView
                DataGridView1.DataSource = dataTable
            Catch ex As Exception
                ' Handle any errors that occur
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim query As String = "SELECT tr.ResultID, tr.PID, tr.RequestID, tr.TestID, tr.ResultValue, tr.ResultDate, tr.PerformedBy, tr.Flag, tr.Notes, img.Image_Path " &
                            "FROM TestResult tr " &
                            "LEFT JOIN Images img ON tr.RequestID = img.Request_ID Where ResultID = " & TextBox1.Text.Trim() & ""


        ' Create a SqlDataAdapter to execute the query and fill the DataTable
        Using adapter As New SqlDataAdapter(query, sqlcon)
            ' Create a DataTable to hold the query results
            Dim dataTable As New DataTable()

            Try
                ' Fill the DataTable with the query results
                adapter.Fill(dataTable)
                image_Path = dataTable.Rows(0)("Image_Path").ToString()

                ' Bind the DataTable to the DataGridView
                DataGridView1.DataSource = dataTable
            Catch ex As Exception
                ' Handle any errors that occur
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        If Not String.IsNullOrEmpty(image_Path) Then
            Try
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox1.ImageLocation = image_Path

            Catch ex As Exception
                MessageBox.Show("An error occurred while loading the image: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim query As String = "SELECT tr.ResultID, tr.PID, tr.RequestID, tr.TestID, tr.ResultValue, tr.ResultDate, tr.PerformedBy, tr.Flag, tr.Notes, img.Image_Path " &
                            "FROM TestResult tr " &
                            "LEFT JOIN Images img ON tr.RequestID = img.Request_ID Where PID = " & TextBox2.Text.Trim() & ""


        ' Create a SqlDataAdapter to execute the query and fill the DataTable
        Using adapter As New SqlDataAdapter(query, sqlcon)
            ' Create a DataTable to hold the query results
            Dim dataTable As New DataTable()

            Try
                ' Fill the DataTable with the query results
                adapter.Fill(dataTable)
                image_Path = dataTable.Rows(0)("Image_Path").ToString()
                ' Bind the DataTable to the DataGridView
                DataGridView1.DataSource = dataTable
            Catch ex As Exception
                ' Handle any errors that occur
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        If Not String.IsNullOrEmpty(image_Path) Then
            Try
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox1.ImageLocation = image_Path
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading the image: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Insert_Results_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim queryTestResult As String = "INSERT INTO TestResult (PID, RequestID, TestID, ResultValue, ResultDate, PerformedBy, Flag, Notes) VALUES ('" & TextBox4.Text.ToString.Trim() & "', '" & TextBox5.Text.ToString.Trim() & "', '" & TextBox6.Text.ToString.Trim() & "', '" & TextBox7.Text.ToString.Trim() & "', '" & TextBox8.Text.ToString.Trim() & "', '" & TextBox14.Text.ToString.Trim() & "', '" & TextBox16.Text.ToString.Trim() & "', '" & TextBox17.Text.ToString.Trim() & "')"

        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(queryTestResult, sqlcon)
            ' Add parameters to the query and set their values from TextBoxes

            Try
                ' Open the connection and execute the query

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

            End Try
        End Using

        Dim queryImages As String = "Insert INTO Images (Request_ID, Image_path) Values (" & TextBox5.Text.Trim() & ", '" & image_Path & "')"

        Using command As New SqlCommand(queryImages, sqlcon)
            ' Add parameters to the query and set their values from TextBoxes

            Try
                ' Open the connection and execute the query

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

            End Try
        End Using
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Using openFileDialog As New OpenFileDialog
            openFileDialog.InitialDirectory = "c:\"
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            openFileDialog.FilterIndex = 1
            openFileDialog.RestoreDirectory = True

            ' Show the dialog and check if the user selected a file
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ' Get the selected file's path
                image_Path = openFileDialog.FileName

                ' Display the selected image in the PictureBox
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox1.Image = Image.FromFile(image_Path)
            End If
        End Using
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim query As String = "UPDATE TestResult SET "


        Dim ResultID As String = TextBox3.Text.Trim()


        ' Check if TextBox2 has a value
        If TextBox4.Text.Trim() <> "" Then
            query &= "PID = '" & TextBox4.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox3 has a value
        If TextBox5.Text.Trim() <> "" Then
            query &= "RequestID = '" & TextBox5.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox4 has a value
        If TextBox6.Text.Trim() <> "" Then
            query &= "TestID = '" & TextBox6.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox5 has a value
        If TextBox7.Text.Trim() <> "" Then
            query &= "ResultValue = '" & TextBox7.Text.ToString.Trim() & "', "
        End If
        If TextBox8.Text.Trim() <> "" Then
            query &= "ResultDate = '" & TextBox8.Text.ToString.Trim() & "', "
        End If
        If TextBox14.Text.Trim() <> "" Then
            query &= "PerformedBy = '" & TextBox14.Text.ToString.Trim() & "', "
        End If
        If TextBox16.Text.Trim() <> "" Then
            query &= "Flag = '" & TextBox16.Text.ToString.Trim() & "', "
        End If
        If TextBox17.Text.Trim() <> "" Then
            query &= "Notes = '" & TextBox17.Text.ToString.Trim() & "', "
        End If



        If query.EndsWith(", ") Then
            query = query.Substring(0, query.Length - 2)
        End If

        ' Append the WHERE clause to identify the record to be updated
        query &= " WHERE ResultID = " & TextBox3.Text.Trim() & ""




        Using command As New SqlCommand(query, sqlcon)


            Try

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

            End Try
        End Using

        Dim queryImage As String = "UPDATE Images SET "


        Dim requestID As String = TextBox5.Text.Trim()


        ' Check if TextBox2 has a value
        If TextBox5.Text.Trim() <> "" Then
            queryImage &= "Request_ID = '" & TextBox5.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox3 has a value
        If TextBox5.Text.Trim() <> "" Then
            queryImage &= "Image_Path = '" & image_Path & "', "
        End If




        If queryImage.EndsWith(", ") Then
            queryImage = queryImage.Substring(0, queryImage.Length - 2)
        End If

        ' Append the WHERE clause to identify the record to be updated
        queryImage &= " WHERE Request_ID = " & requestID & ""




        Using command As New SqlCommand(query, sqlcon)


            Try

                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Check if the query was successful
                If rowsAffected > 0 Then

                Else

                End If
            Catch ex As Exception
                ' Handle any exceptions here
                MessageBox.Show("Error updating record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Using

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim query As String = "Delete From TestResult WHERE ResultID =" & TextBox3.Text() & ""
        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, sqlcon)


            Try

                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Check if the query was successful
                If rowsAffected > 0 Then
                    MessageBox.Show("Data Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No rows were affected. Data Deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                ' Handle any exceptions here
                MessageBox.Show("Error deleting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Using

        '' Trying to delete the image from images but failed

        'Dim queryImages As String = "Delete From Images WHERE requestID =" & TextBox5.Text() & ""
        '' Create a SqlCommand object with the query and connection
        'Using command As New SqlCommand(query, sqlcon)
        '
        '
        '    Try
        '
        '        Dim rowsAffected As Integer = command.ExecuteNonQuery()
        '
        '        ' Check if the query was successful
        '        If rowsAffected > 0 Then
        '        Else
        '            MessageBox.Show("No rows were affected. Data Deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '    Catch ex As Exception
        '        ' Handle any exceptions here
        '        MessageBox.Show("Error deleting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '
        '    End Try
        ' End Using
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim queryTestResult As String = "INSERT INTO TestResult (PID, RequestID, TestID, ResultValue, ResultDate, PerformedBy, Flag, Notes) VALUES ('" & TextBox10.Text.ToString.Trim() & "', '" & TextBox11.Text.ToString.Trim() & "', '" & TextBox12.Text.ToString.Trim() & "', '" & TextBox13.Text.ToString.Trim() & "', '" & TextBox18.Text.ToString.Trim() & "', '" & TextBox15.Text.ToString.Trim() & "', '" & TextBox19.Text.ToString.Trim() & "', '" & TextBox20.Text.ToString.Trim() & "')"

        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(queryTestResult, sqlcon)
            ' Add parameters to the query and set their values from TextBoxes

            Try
                ' Open the connection and execute the query

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

            End Try
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "UPDATE TestResult SET "


        Dim ResultID As String = TextBox9.Text.Trim()


        ' Check if TextBox2 has a value
        If TextBox10.Text.Trim() <> "" Then
            query &= "PID = '" & TextBox10.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox3 has a value
        If TextBox11.Text.Trim() <> "" Then
            query &= "RequestID = '" & TextBox11.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox4 has a value
        If TextBox12.Text.Trim() <> "" Then
            query &= "TestID = '" & TextBox12.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox5 has a value
        If TextBox13.Text.Trim() <> "" Then
            query &= "ResultValue = '" & TextBox13.Text.ToString.Trim() & "', "
        End If
        If TextBox18.Text.Trim() <> "" Then
            query &= "ResultDate = '" & TextBox15.Text.ToString.Trim() & "', "
        End If
        If TextBox15.Text.Trim() <> "" Then
            query &= "PerformedBy = '" & TextBox14.Text.ToString.Trim() & "', "
        End If
        If TextBox19.Text.Trim() <> "" Then
            query &= "Flag = '" & TextBox16.Text.ToString.Trim() & "', "
        End If
        If TextBox20.Text.Trim() <> "" Then
            query &= "Notes = '" & TextBox20.Text.ToString.Trim() & "', "
        End If



        If query.EndsWith(", ") Then
            query = query.Substring(0, query.Length - 2)
        End If

        ' Append the WHERE clause to identify the record to be updated
        query &= " WHERE ResultID = " & TextBox9.Text.Trim() & ""

        Using command As New SqlCommand(query, sqlcon)


            Try

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

            End Try
        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query As String = "Delete From TestResult WHERE ResultID =" & TextBox9.Text() & ""
        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, sqlcon)


            Try

                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Check if the query was successful
                If rowsAffected > 0 Then
                    MessageBox.Show("Data Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No rows were affected. Data Deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                ' Handle any exceptions here
                MessageBox.Show("Error deleting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Using
    End Sub
End Class