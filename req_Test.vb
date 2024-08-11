Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class req_Test
    Private patientID As Integer
    Private images As List(Of Image)
    Private currentIndex As Integer = 0



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        database.GetSQLConnection()
    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click_1(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim requestID As Integer
        Dim PolicyText As String = ""
        Dim getLabID As String = "Select LabID from Lab_location where Location_Name ='" & ComboBox2.Text.Trim() & "'"
        Dim labID As Integer

        ' Insert into Test_REQ
        Dim reqdate = Format(DateTimePicker1.Value, "yyyy-MM-dd")


        Dim queryPolicy As String = "SELECT Description FROM LabPolicies WHERE PolicyName ='" & ComboBox1.Text.Trim() & "'"
        Using cmd2 As New SqlCommand(getLabID, sqlcon)

            Try
                ' Execute the command and read the result
                Using reader As SqlDataReader = cmd2.ExecuteReader()
                    If reader.HasRows Then

                        reader.Read()
                        LabID = reader("LabID")
                        If reader.Read() Then
                            '
                            MessageBox.Show("Multiple policies found with the specified test name. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            reader.Close()
                        End If


                    End If
                End Using
            Catch ex As Exception
                ' Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        Dim query As String = "INSERT into Test_REQ (PID, DateRequested, TestName,LabID) VALUES (" & patientID & ",'" & reqdate.Trim.ToString() & "', '" & ComboBox1.Text.Trim() & "'," & labID & ")"
        Using cmd As New SqlCommand(queryPolicy, sqlcon)

            Try
                ' Execute the command and read the result
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then

                        reader.Read()
                        PolicyText = reader("Description")
                        If reader.Read() Then
                            ' If another record is found, handle the ambiguity
                            MessageBox.Show("Multiple policies found with the specified test name. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            reader.Close()
                        End If


                    End If
                End Using ' Automatically closes and disposes the reader
            Catch ex As Exception
                ' Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using


        Dim result As DialogResult = MessageBox.Show(PolicyText, "Precautions Before your Test", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)


        If result = DialogResult.Cancel Then
            Me.Hide()
        Else


            Using command As New SqlCommand(query, sqlcon)
                Try
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
                End Try
            End Using

            Dim query2 As String = "select top 1 requestID from TEST_REQ order by RequestID desc"
            Using cmd As New SqlCommand(query2, sqlcon)
                Try
                    Dim yourID As SqlDataReader = cmd.ExecuteReader()
                    yourID.Read()
                    requestID = Convert.ToInt32(yourID("RequestID"))
                    yourID.Close()


                Catch ex As Exception
                    MessageBox.Show("Error getting requestID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

            MessageBox.Show("Thanks for choosing our lab <3" & vbCrLf & "your request ID is: " & requestID & "", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        database.GetSQLConnection()

        Dim cmd As New SqlCommand("SELECT Price FROM TestPrice WHERE TestID = (SELECT TestID FROM Test WHERE TestName = '" & ComboBox1.Text.Trim() & "')", sqlcon)


        Try
            Using reader As SqlDataReader = cmd.ExecuteReader()
                reader.Read() ' Move to the first (and only) row
                TextBox1.Text = reader("Price").ToString()
                ' Reader is automatically closed here by Using statement
            End Using
        Catch ex As Exception
            ' Handle any errors that may have occurred
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub


    Private Sub req_Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        images = New List(Of Image) From {
            My.Resources.applying_gel_for_an_ultrasound_exam_examination_scan_scanner_image, ' Assuming you added Image1 to project resources
            My.Resources.iStock_491322891, ' Assuming you added Image2 to project resources
            My.Resources.shutterstock_414452563_ecg2  ' Assuming you added Image3 to project resources
        }
        database.GetSQLConnection()
        Dim command1 As New SqlCommand("SELECT TestName FROM Test", sqlcon)
        Dim command2 As New SqlCommand("SELECT Location_Name FROM Lab_Location", sqlcon)

        Try
            ' Execute the command for ComboBox1
            Using reader1 As SqlDataReader = command1.ExecuteReader()
                ' Loop through the data and add each item to the ComboBox
                While reader1.Read()
                    ComboBox1.Items.Add(reader1("TestName").ToString())
                End While
                ' Reader is automatically closed here by Using statement
            End Using

            ' Execute the command for ComboBox2
            Using reader2 As SqlDataReader = command2.ExecuteReader()
                ' Loop through the data and add each item to the ComboBox
                While reader2.Read()
                    ComboBox2.Items.Add(reader2("Location_Name").ToString())
                End While
                ' Reader is automatically closed here by Using statement
            End Using
        Catch ex As Exception
            ' Handle any errors that may have occurred
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub TextBoxPhoneNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPhoneNumber.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim query1 As String = "INSERT INTO patient (Name, DateofBirth, Gender, Address, PhoneNumber, MedicalHistory, EmergencyContactName, EmergencyContactPhone) VALUES ('" & TextBox2.Text.ToString.Trim() & "', '" & TextBox3.Text.ToString.Trim() & "', '" & TextBox4.Text.ToString.Trim() & "', '" & TextBox5.Text.ToString.Trim() & "', '" & TextBoxPhoneNumber.Text.ToString.Trim() & "', '" & TextBox7.Text.ToString.Trim() & "', '" & TextBox8.Text.ToString.Trim() & "', '" & TextBox9.Text.ToString.Trim() & "')"
        MessageBox.Show(query1)
        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query1, sqlcon)
            Try
                ' Execute the query
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
            End Try
        End Using
        ' Getting the new patientID

        ' Define the SQL query to select the record based on patientID
        Dim query As String = "SELECT patientID FROM patient WHERE Name like '%" & TextBox2.Text.Trim() & "%'"
        Using command As New SqlCommand(query, sqlcon)
            Try
                ' Create a SqlCommand object with the query and connection
                Using reader As SqlDataReader = command.ExecuteReader()

                    reader.Read()
                    patientID = Convert.ToInt32(reader("PatientID"))
                End Using
            Catch ex As Exception
                ' Handle any exceptions here
                MessageBox.Show("Error retrieving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim phoneNumber As String = TextBoxPhoneNumber.Text.ToString()

        ' Open the database connection
        database.GetSQLConnection()

        ' Define the SQL query
        Dim querysearch As String = "SELECT PatientID FROM Patient WHERE PhoneNumber = @PhoneNumber"

        ' Use the Using statement for proper resource management
        Using cmd As New SqlCommand(querysearch, sqlcon)
            ' Add the parameter to the command to prevent SQL injection
            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber)

            Try

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then

                        reader.Read()
                        patientID = Convert.ToInt32(reader("PatientID"))
                        If reader.Read() Then

                            MessageBox.Show("Multiple records found with the specified Phone no. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else

                            MessageBox.Show("Record found. Patient ID: " & patientID, "Record Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else

                        MessageBox.Show("No record found with the specified phone number.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception

                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel3.BackgroundImage = images(currentIndex)
        Panel3.BackgroundImageLayout = ImageLayout.Zoom

        currentIndex = (currentIndex + 1) Mod images.Count
    End Sub
End Class