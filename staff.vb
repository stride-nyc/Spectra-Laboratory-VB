Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class staff
    Private Sub staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        database.GetSQLConnection()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim flag As Integer = 0
        While flag < 1

            If RadioButton1.Checked Then
                flag = 1 ' Staff info only
            ElseIf RadioButton2.Checked Then
                flag = 2    'Staff + salaries
            ElseIf RadioButton3.Checked Then
                flag = 3    'staff + department
            ElseIf RadioButton4.Checked Then
                flag = 4    'all info
            Else
                MessageBox.Show("Please choose searching method!")
                Return
            End If
        End While
        ' displaying data
        Dim staffonly As String = "select * from STAFF where Staff_ID = " & TextBox1.Text.Trim() & ""
        Dim staffandsalary As String = "SELECT s.NAME, s.PHONE_NUMBER, s.ADDRESS, s.DNO, sa.SALARY, sa.EFFECTIVE_DATE
                                        FROM 
                                            STAFF s
                                            INNER JOIN 
                                            SALARY sa ON s.Staff_ID = sa.EMPLOYEE_ID
                                        WHERE 
                                        s.Staff_ID = " & TextBox1.Text.Trim() & ""
        Dim staffanddepartment As String = "SELECT s.NAME, s.PHONE_NUMBER, s.ADDRESS, d.Dnmae as Department_Name, s.DNO 
                                        FROM 
                                            STAFF s
                                            INNER JOIN 
                                            Department d ON s.Dno = d.dno
                                        WHERE 
                                        s.Staff_ID = " & TextBox1.Text.Trim() & ""
        Dim all As String = "SELECT 
                                s.Staff_ID,
                                s.NAME,
                                s.PHONE_NUMBER,
                                s.ADDRESS,
                                sa.SALARY,
                                sa.EFFECTIVE_DATE,
                                d.DNMAE AS Department_Name
                            FROM 
                                STAFF s
                            INNER JOIN 
                                SALARY sa ON s.Staff_ID = sa.EMPLOYEE_ID
                            INNER JOIN 
                                DEPARTMENT d ON s.DNO = d.DNO
                            WHERE s.Staff_ID = " & TextBox1.Text.Trim() & ""


        If flag = 1 Then
            Dim adapter As New SqlDataAdapter(staffonly, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 2 Then
            Dim adapter As New SqlDataAdapter(staffandsalary, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 3 Then
            Dim adapter As New SqlDataAdapter(staffanddepartment, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 4 Then
            Dim adapter As New SqlDataAdapter(all, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        End If





    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim flag As Integer = 0
        While flag < 1

            If RadioButton1.Checked Then
                flag = 1 ' Staff info only
            ElseIf RadioButton2.Checked Then
                flag = 2    'Staff + salaries
            ElseIf RadioButton3.Checked Then
                flag = 3    'staff + department
            ElseIf RadioButton4.Checked Then
                flag = 4    'all info
            Else
                MessageBox.Show("Please choose searching method!")
                Return
            End If
        End While
        ' displaying data
        Dim staffonly As String = "select * from STAFF where  Name LIKE '%" & TextBox2.Text.Trim() & "%'"
        Dim staffandsalary As String = "SELECT s.NAME, s.PHONE_NUMBER, s.ADDRESS, s.DNO, sa.SALARY, sa.EFFECTIVE_DATE
                                        FROM 
                                            STAFF s
                                            INNER JOIN 
                                            SALARY sa ON s.Staff_ID = sa.EMPLOYEE_ID
                                        WHERE 
                                        s.Name LIKE '%" & TextBox2.Text.Trim() & "%'"
        Dim staffanddepartment As String = "SELECT s.NAME, s.PHONE_NUMBER, s.ADDRESS, d.Dnmae as Department_Name, s.DNO 
                                        FROM 
                                            STAFF s
                                            INNER JOIN 
                                            Department d ON s.Dno = d.dno
                                        WHERE 
                                        s.Name LIKE '%" & TextBox2.Text.Trim() & "%'"
        Dim all As String = "SELECT 
                                s.Staff_ID,
                                s.NAME,
                                s.PHONE_NUMBER,
                                s.ADDRESS,
                                sa.SALARY,
                                sa.EFFECTIVE_DATE,
                                d.DNMAE AS Department_Name
                            FROM 
                                STAFF s
                            INNER JOIN 
                                SALARY sa ON s.Staff_ID = sa.EMPLOYEE_ID
                            INNER JOIN 
                                DEPARTMENT d ON s.DNO = d.DNO
                            WHERE s.Name LIKE '%" & TextBox2.Text.Trim() & "%'"


        If flag = 1 Then
            Dim adapter As New SqlDataAdapter(staffonly, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 2 Then
            Dim adapter As New SqlDataAdapter(staffandsalary, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 3 Then
            Dim adapter As New SqlDataAdapter(staffanddepartment, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 4 Then
            Dim adapter As New SqlDataAdapter(all, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim flag As Integer = 0
        While flag < 1

            If RadioButton1.Checked Then
                flag = 1 ' Staff info only
            ElseIf RadioButton2.Checked Then
                flag = 2    'Staff + salaries
            ElseIf RadioButton3.Checked Then
                flag = 3    'staff + department
            ElseIf RadioButton4.Checked Then
                flag = 4    'all info
            Else
                MessageBox.Show("Please choose searching method!")
                Return
            End If
        End While
        ' displaying data
        Dim staffonly As String = "select * from STAFF "
        Dim staffandsalary As String = "SELECT s.NAME, s.PHONE_NUMBER, s.ADDRESS, s.DNO, sa.SALARY, sa.EFFECTIVE_DATE
                                        FROM 
                                            STAFF s
                                            INNER JOIN 
                                            SALARY sa ON s.Staff_ID = sa.EMPLOYEE_ID
                                        "
        Dim staffanddepartment As String = "SELECT s.NAME, s.PHONE_NUMBER, s.ADDRESS, d.Dnmae as Department_Name, s.DNO 
                                        FROM 
                                            STAFF s
                                            INNER JOIN 
                                            Department d ON s.Dno = d.dno
                                       "
        Dim all As String = "SELECT 
                                s.Staff_ID,
                                s.NAME,
                                s.PHONE_NUMBER,
                                s.ADDRESS,
                                sa.SALARY,
                                sa.EFFECTIVE_DATE,
                                d.DNMAE AS Department_Name
                            FROM 
                                STAFF s
                            INNER JOIN 
                                SALARY sa ON s.Staff_ID = sa.EMPLOYEE_ID
                            INNER JOIN 
                                DEPARTMENT d ON s.DNO = d.DNO
                            "
        If flag = 1 Then
            Dim adapter As New SqlDataAdapter(staffonly, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 2 Then
            Dim adapter As New SqlDataAdapter(staffandsalary, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 3 Then
            Dim adapter As New SqlDataAdapter(staffanddepartment, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf flag = 4 Then
            Dim adapter As New SqlDataAdapter(all, sqlcon)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim query As String = "INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES ('" & TextBox3.Text.ToString.Trim() & "', '" & TextBox4.Text.ToString.Trim() & "', '" & TextBox5.Text.ToString.Trim() & "', '" & TextBox6.Text.ToString.Trim() & "', '" & TextBox7.Text.ToString.Trim() & "')"

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
        Dim query As String = "UPDATE staff SET "

        ' Get the patientID from TextBox1
        Dim staffID As String = TextBox3.Text.Trim()

        ' Check if TextBox2 has a value
        If TextBox4.Text.Trim() <> "" Then
            query &= "Name = '" & TextBox4.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox3 has a value
        If TextBox5.Text.Trim() <> "" Then
            query &= "Phone_Number = '" & TextBox5.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox4 has a value
        If TextBox6.Text.Trim() <> "" Then
            query &= "Address = '" & TextBox6.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox5 has a value
        If TextBox7.Text.Trim() <> "" Then
            query &= "DNO = '" & TextBox7.Text.ToString.Trim() & "', "
        End If

        ' Remove the trailing comma and space if values have been added to the query
        If query.EndsWith(", ") Then
            query = query.Substring(0, query.Length - 2)
        End If

        ' Append the WHERE clause to identify the record to be updated
        query &= " WHERE Staff_ID = " & TextBox3.Text.Trim() & ""



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
        Dim query As String = "Delete From staff WHERE staff_ID =" & TextBox3.Text() & ""
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

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim query As String = "INSERT INTO Salary (EMPLOYEE_ID, SALARY, DNO, EFFECTIVE_DATE) VALUES ('" & TextBox9.Text.ToString.Trim() & "', '" & TextBox10.Text.ToString.Trim() & "', '" & TextBox11.Text.ToString.Trim() & "', '" & TextBox12.Text.ToString.Trim() & "')"

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

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim query As String = "UPDATE salary SET "

        ' Get the patientID from TextBox1
        Dim Employee_ID As String = TextBox9.Text.Trim()

        ' Check if TextBox2 has a value
        If TextBox10.Text.Trim() <> "" Then
            query &= "Salary = '" & TextBox10.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox3 has a value
        If TextBox11.Text.Trim() <> "" Then
            query &= "DNO = '" & TextBox11.Text.ToString.Trim() & "', "
        End If

        ' Check if TextBox4 has a value
        If TextBox12.Text.Trim() <> "" Then
            query &= "EFFECTIVE_DATE = '" & TextBox12.Text.ToString.Trim() & "', "
        End If




        ' Remove the trailing comma and space if values have been added to the query
        If query.EndsWith(", ") Then
            query = query.Substring(0, query.Length - 2)
        End If

        ' Append the WHERE clause to identify the record to be updated
        query &= " WHERE Employee_ID = " & TextBox9.Text.Trim() & ""



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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim query As String = "Delete From salary WHERE Employee_ID =" & TextBox9.Text() & ""
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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub
End Class