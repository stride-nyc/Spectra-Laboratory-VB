Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Radiology_Result
    Private Sub Radiology_Result_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        database.GetSQLConnection()
        TextBox12.Text = GlobalVariables.RequestIDResult

        Dim requestID As Integer = Convert.ToInt32(GlobalVariables.RequestIDResult)
        Dim patientID As Integer
        Dim TestID As Integer
        Dim ResultValue As String = ""
        Dim ResultDate As String = ""
        Dim Flag As String = ""
        Dim Notes As String = ""

        ' Query to retrieve the image URL from the Images table
        Dim imageQuery As String = "SELECT Image_Path FROM Images WHERE Request_ID = @RequestID"
        Dim imagePath As String = ""

        Using cmd As New SqlCommand(imageQuery, sqlcon)
            cmd.Parameters.AddWithValue("@RequestID", requestID)

            Try
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        imagePath = reader("Image_Path").ToString()

                        If reader.Read() Then
                            MessageBox.Show("Multiple records found with the specified RequestID.", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No record found with the specified RequestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

        ' Load the image from the URL into the PictureBox
        If Not String.IsNullOrEmpty(imagePath) Then
            Try
                PictureBox1.ImageLocation = imagePath
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading the image: " & ex.Message)
            End Try
        End If

        ' Query to retrieve the TestResult
        Dim resultQuery As String = "SELECT * FROM TestResult WHERE RequestID = @RequestID"

        Using cmd As New SqlCommand(resultQuery, sqlcon)
            cmd.Parameters.AddWithValue("@RequestID", requestID)

            Try
                Using readerTestResult As SqlDataReader = cmd.ExecuteReader()
                    If readerTestResult.HasRows Then
                        readerTestResult.Read()
                        patientID = Convert.ToInt32(readerTestResult("PID"))
                        TestID = Convert.ToInt32(readerTestResult("TestID"))
                        ResultValue = readerTestResult("ResultValue").ToString()
                        ResultDate = readerTestResult("ResultDate").ToString()
                        Flag = readerTestResult("Flag").ToString()
                        Notes = readerTestResult("Notes").ToString()

                        TextBox6.Text = ResultDate
                        TextBox15.Text = Flag
                        TextBox17.Text = Notes

                        If readerTestResult.Read() Then
                            MessageBox.Show("Multiple records found with the specified RequestID.", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No record found with the specified RequestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

        ' Query to retrieve the TestName
        Dim testNameQuery As String = "SELECT TestName FROM Test WHERE TestID = @TestID"
        Using cmdTest As New SqlCommand(testNameQuery, sqlcon)
            cmdTest.Parameters.AddWithValue("@TestID", TestID)

            Try
                Using readerTest As SqlDataReader = cmdTest.ExecuteReader()
                    If readerTest.HasRows Then
                        readerTest.Read()
                        TextBox16.Text = readerTest("TestName").ToString()

                        If readerTest.Read() Then
                            MessageBox.Show("Multiple records found with the specified TestID.", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No record found with the specified TestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

        ' Query to retrieve the Patient details
        Dim queryPatient As String = "SELECT * FROM Patient WHERE patientID = @patientID"
        Using cmdPatient As New SqlCommand(queryPatient, sqlcon)
            cmdPatient.Parameters.AddWithValue("@patientID", patientID)
            Try
                Using reader As SqlDataReader = cmdPatient.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        TextBox1.Text = reader("Name").ToString()
                        TextBox2.Text = reader("Gender").ToString()
                        TextBox10.Text = reader("DateOfbirth").ToString()
                        TextBox3.Text = reader("PhoneNumber").ToString()
                        TextBox4.Text = reader("Address").ToString()

                        If reader.Read() Then
                            MessageBox.Show("Multiple records found with the specified PID.", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No record found with the specified PID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

        ' Query to retrieve the TEST_REQ details
        Dim queryTest_REQ As String = "SELECT * FROM TEST_REQ WHERE RequestID = @requestID"
        Dim DateRequested As String = ""
        Dim TestName As String = ""
        Dim labID As Integer

        Using cmdTestReq As New SqlCommand(queryTest_REQ, sqlcon)
            cmdTestReq.Parameters.AddWithValue("@requestID", requestID)
            Try
                Using reader As SqlDataReader = cmdTestReq.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        DateRequested = reader("DateRequested").ToString()
                        TestName = reader("TestName").ToString()
                        labID = Convert.ToInt32(reader("LabID"))

                        If reader.Read() Then
                            MessageBox.Show("Multiple records found with the specified RequestID.", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No record found with the specified RequestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        TextBox5.Text = DateRequested
        TextBox9.Text = TestName

        ' Query to retrieve the TestPrice details
        Dim queryTestPrice As String = "SELECT Price FROM TestPrice WHERE testID = @TestID"
        Using cmdTestPrice As New SqlCommand(queryTestPrice, sqlcon)
            cmdTestPrice.Parameters.AddWithValue("@TestID", TestID)
            Try
                Using reader As SqlDataReader = cmdTestPrice.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        TextBox7.Text = reader("Price").ToString()

                        If reader.Read() Then
                            MessageBox.Show("Multiple records found with the specified TestID.", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No record found with the specified TestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

        ' Query to retrieve the Lab_Location details
        Dim queryLocation As String = "SELECT Location_Name FROM Lab_Location WHERE LabID = @LabID"
        Using cmdLocation As New SqlCommand(queryLocation, sqlcon)
            cmdLocation.Parameters.AddWithValue("@LabID", labID)
            Try
                Using reader As SqlDataReader = cmdLocation.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        TextBox8.Text = reader("Location_Name").ToString()

                        If reader.Read() Then
                            MessageBox.Show("Multiple records found with the specified LabID.", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No record found with the specified LabID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg|BMP Files (*.bmp)|*.bmp|All Files (*.*)|*.*"
        SaveFileDialog1.Title = "Save Screenshot"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                ' Create a bitmap with the size of the form
                Dim bmp As New Bitmap(Me.Width, Me.Height)
                ' Draw the form onto the bitmap
                Me.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Width, Me.Height))
                ' Save the bitmap to the selected file
                Dim filePath As String = SaveFileDialog1.FileName
                Dim fileExtension As String = Path.GetExtension(filePath).ToLower()

                Select Case fileExtension
                    Case ".jpg"
                        bmp.Save(filePath, ImageFormat.Jpeg)
                    Case ".bmp"
                        bmp.Save(filePath, ImageFormat.Bmp)
                    Case Else
                        bmp.Save(filePath, ImageFormat.Png)
                End Select

                MessageBox.Show("Screenshot saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error saving screenshot: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
