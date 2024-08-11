Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO


Public Class Normal_Result
    Private Sub Normal_Result_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        database.GetSQLConnection()
        TextBox12.Text = GlobalVariables.RequestIDResult

        Dim query As String = "SELECT * FROM TestResult WHERE RequestID = " & GlobalVariables.RequestIDResult & ""
        Dim patientID As Integer
        Dim TestID As Integer
        Dim ResultValue As String = ""
        Dim ResultDate As String = ""
        Dim Flag As String = ""
        Dim Notes As String = ""

        ' Use the Using statement for proper resource management
        Using cmd As New SqlCommand(query, sqlcon)
            ' Add the parameter to the command to prevent SQL injection

            Try

                Using readerTestResult As SqlDataReader = cmd.ExecuteReader()
                    If readerTestResult.HasRows Then

                        readerTestResult.Read()
                        patientID = Convert.ToInt32(readerTestResult("PID"))
                        TestID = Convert.ToInt32(readerTestResult("TestID"))
                        ResultValue = readerTestResult("ResultValue")
                        ResultDate = readerTestResult("ResultDate")
                        Flag = readerTestResult("Flag")
                        Notes = readerTestResult("Notes")

                        If readerTestResult.Read() Then

                            MessageBox.Show("Multiple records found with the specified RequestID. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else


                        End If
                    Else

                        MessageBox.Show("No record found with the specified RequestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception

                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        TextBox6.Text() = ResultDate
        TextBox13.Text() = ResultValue
        TextBox15.Text() = Notes
        TextBox17.Text() = Flag

        Dim queryPatient As String = "Select * from Patient where patientID = " & patientID & ""
        Dim Name As String = ""
        Dim DateOfBirth As String = ""
        Dim Gender As String = ""
        Dim Address As String = ""
        Dim phoneNumber As String = ""


        Using cmd As New SqlCommand(queryPatient, sqlcon)
            ' Add the parameter to the command to prevent SQL injection

            Try

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then

                        reader.Read()
                        Name = reader("Name")
                        DateOfBirth = reader("DateOfbirth")
                        Gender = reader("Gender")
                        Address = reader("Address")
                        phoneNumber = reader("PhoneNumber")


                        If reader.Read() Then

                            MessageBox.Show("Multiple records found with the specified PID. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else


                        End If
                    Else

                        MessageBox.Show("No record found with the specified PID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception

                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        TextBox1.Text() = Name
        TextBox2.Text() = Gender
        TextBox10.Text() = DateOfBirth
        TextBox3.Text() = phoneNumber
        TextBox4.Text() = Address

        Dim queryTest_REQ As String = "Select * from TEST_REQ where RequestID = " & GlobalVariables.RequestIDResult & ""
        Dim DateRequested As String = ""
        Dim TestName As String = ""
        Dim labID As Integer

        Using cmd As New SqlCommand(queryTest_REQ, sqlcon)


            Try

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then

                        reader.Read()
                        DateRequested = reader("DateRequested")
                        TestName = reader("TestName")
                        labID = reader("LabID")



                        If reader.Read() Then

                            MessageBox.Show("Multiple records found with the specified RequestID. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else


                        End If
                    Else

                        MessageBox.Show("No record found with the specified RequestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception

                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        TextBox5.Text() = DateRequested
        TextBox9.Text() = TestName

        Dim QueryTestPrice As String = "Select* from TestPrice where testID = " & TestID & ""
        Dim price As String = ""
        Using cmd As New SqlCommand(QueryTestPrice, sqlcon)


            Try

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then

                        reader.Read()
                        price = reader("Price")

                        If reader.Read() Then

                            MessageBox.Show("Multiple records found with the specified RequestID. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else


                        End If
                    Else

                        MessageBox.Show("No record found with the specified RequestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception

                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        TextBox7.Text() = price

        Dim queryReferenceRange As String = "select * from ReferenceRange WHERE (TestName = '" & TestName.Trim() & "' AND Gender = '" & Gender.Trim() & "')"
        Dim Attribute As String = ""
        Dim LowerLimit As String = ""
        Dim UpperLimit As String = ""


        Using cmd As New SqlCommand(queryReferenceRange, sqlcon)


            Try

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then

                        reader.Read()

                        Attribute = reader("Attribute")
                        LowerLimit = reader("LowerLimit")
                        UpperLimit = reader("UpperLimit")

                        If reader.Read() Then

                            MessageBox.Show("Multiple records found with the specified RequestID. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else


                        End If
                    Else

                        MessageBox.Show("No record found with the specified RequestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception

                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        TextBox14.Text() = LowerLimit
        TextBox18.Text() = UpperLimit
        TextBox16.Text() = Attribute


        Dim queryLocation As String = "Select * from Lab_Location Where LabID = " & labID & ""
        Dim Location_Name As String = ""
        Using cmd As New SqlCommand(queryLocation, sqlcon)


            Try

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then

                        reader.Read()
                        Location_Name = reader("Location_Name")

                        If reader.Read() Then

                            MessageBox.Show("Multiple records found with the specified RequestID. ", "Multiple Records Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else


                        End If
                    Else

                        MessageBox.Show("No record found with the specified RequestID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception

                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
        TextBox8.Text() = Location_Name

    End Sub



    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

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
End Class