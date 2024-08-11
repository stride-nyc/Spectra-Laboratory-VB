Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Utilities
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim flag As Integer = 0
        While flag < 1

            If RadioButton1.Checked Then
                flag = 1 ' Lab equipments
            ElseIf RadioButton2.Checked Then
                flag = 2    'Lab supplies

            Else
                MessageBox.Show("Please choose searching method!")
                Return
            End If
        End While
        ' displaying data
        Dim labEquipments As String = "select * from LabEquipment where EquipmentID = " & TextBox1.Text.Trim() & ""
        Dim labSupplies As String = "SELECT * from LabSupplies where SupplyID = " & TextBox1.Text.Trim() & ""

        If flag = 1 Then
            Dim adapter As New SqlDataAdapter(labEquipments, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 2 Then
            Dim adapter As New SqlDataAdapter(labSupplies, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        End If



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim flag As Integer = 0
        While flag < 1

            If RadioButton1.Checked Then
                flag = 1 ' Lab equipments
            ElseIf RadioButton2.Checked Then
                flag = 2    'Lab supplies

            Else
                MessageBox.Show("Please choose searching method!")
                Return
            End If
        End While
        ' displaying data
        Dim labEquipments As String = "select * from LabEquipment where EquipmentName LIKE  '%" & TextBox2.Text.Trim() & "%'"
        Dim labSupplies As String = "SELECT * from LabSupplies where SupplyName LIKE'%" & TextBox2.Text.Trim() & "%'"

        If flag = 1 Then
            Dim adapter As New SqlDataAdapter(labEquipments, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 2 Then
            Dim adapter As New SqlDataAdapter(labSupplies, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim flag As Integer = 0
        While flag < 1

            If RadioButton1.Checked Then
                flag = 1 ' Lab equipments
            ElseIf RadioButton2.Checked Then
                flag = 2    'Lab supplies

            Else
                MessageBox.Show("Please choose searching method!")
                Return
            End If
        End While
        ' displaying data
        Dim labEquipments As String = "select * from LabEquipment "
        Dim labSupplies As String = "SELECT * from LabSupplies "

        If flag = 1 Then
            Dim adapter As New SqlDataAdapter(labEquipments, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 2 Then
            Dim adapter As New SqlDataAdapter(labSupplies, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        End If

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim query As String = "INSERT INTO LabEquipment ( EquipmentName, Description, AcquisitionDate, LastMaintenanceDate,Status, MaintainedBy ) VALUES ('" & TextBox4.Text.ToString.Trim() & "', '" & TextBox5.Text.ToString.Trim() & "', '" & TextBox6.Text.ToString.Trim() & "', '" & TextBox7.Text.ToString.Trim() & "', '" & TextBox8.Text.Trim() & "'," & TextBox14.Text.Trim() & ")"

        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, sqlcon)
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim query As String = "UPDATE LabEquipment SET "

        ' Get the patientID from TextBox1
        Dim EquipmentID As String = TextBox3.Text.Trim()

        ' Check if TextBox2 has a value
        If TextBox4.Text.Trim() <> "" Then
            query &= "EquipmentName = '" & TextBox4.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox3 has a value
        If TextBox5.Text.Trim() <> "" Then
            query &= "Description = '" & TextBox5.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox4 has a value
        If TextBox6.Text.Trim() <> "" Then
            query &= "AcquisitionDate = '" & TextBox6.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox5 has a value
        If TextBox7.Text.Trim() <> "" Then
            query &= "LastMaintenanceDate = '" & TextBox7.Text.ToString.Trim() & "', "
        End If
        If TextBox8.Text.Trim() <> "" Then
            query &= "Status = '" & TextBox8.Text.ToString.Trim() & "', "
        End If
        If TextBox14.Text.Trim() <> "" Then
            query &= "MaintainedBy = '" & TextBox14.Text.ToString.Trim() & "', "
        End If


        ' Remove the trailing comma and space if values have been added to the query
        If query.EndsWith(", ") Then
            query = query.Substring(0, query.Length - 2)
        End If

        ' Append the WHERE clause to identify the record to be updated
        query &= " WHERE EquipmentID = " & TextBox3.Text.Trim() & ""



        ' Create a SqlCommand object with the query and connection
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim query As String = "Delete From Labequipment WHERE EquipmentID =" & TextBox3.Text() & ""
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim query As String = "INSERT INTO LabSupplies ( SupplyName, Description, Unit, StockLevel, SuppliedBy ) VALUES ('" & TextBox10.Text.ToString.Trim() & "', '" & TextBox11.Text.ToString.Trim() & "', '" & TextBox12.Text.ToString.Trim() & "','" & TextBox13.Text.Trim() & "'," & TextBox15.Text.Trim() & ")"

        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, sqlcon)
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

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "UPDATE LabSupplies SET "

        ' Get the patientID from TextBox1
        Dim SupplyID As String = TextBox9.Text.Trim()

        ' Check if TextBox2 has a value
        If TextBox10.Text.Trim() <> "" Then
            query &= "SupplyName = '" & TextBox10.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox3 has a value
        If TextBox11.Text.Trim() <> "" Then
            query &= "Description = '" & TextBox11.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox4 has a value
        If TextBox12.Text.Trim() <> "" Then
            query &= "Unit = '" & TextBox12.Text.ToString.Trim() & "', "
        End If
        If TextBox13.Text.Trim() <> "" Then
            query &= "StockLevel = '" & TextBox13.Text.ToString.Trim() & "', "
        End If
        If TextBox15.Text.Trim() <> "" Then
            query &= "SuppliedBy = '" & TextBox15.Text.ToString.Trim() & "', "
        End If




        ' Remove the trailing comma and space if values have been added to the query
        If query.EndsWith(", ") Then
            query = query.Substring(0, query.Length - 2)
        End If

        ' Append the WHERE clause to identify the record to be updated
        query &= " WHERE SupplyID = " & TextBox9.Text.Trim() & ""



        ' Create a SqlCommand object with the query and connection
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
        Dim query As String = "Delete From labSupplies WHERE SupplyID =" & TextBox9.Text() & ""
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

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Utilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class