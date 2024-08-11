Imports System.Data.SqlClient

Public Class Statistics

    Dim tableno As Integer = 0
    Dim attributeName As String = ""
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text() = "Patient" Then
            tableno = 1
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Count number of Patients")


        ElseIf ComboBox1.Text() = "DEPARTMENT" Then
            tableno = 2
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Count number of Departments")
        ElseIf ComboBox1.Text() = "STAFF" Then
            tableno = 3
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Count number of Employees")
        ElseIf ComboBox1.Text() = "SALARY" Then
            tableno = 4
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Display employee with highest salary")
            ComboBox2.Items.Add("Display employee with Lowest salary")
            ComboBox2.Items.Add("Display average of employees salaries")
        ElseIf ComboBox1.Text() = "TEST_REQ" Then
            tableno = 5
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Count number of Test requests")
            ComboBox2.Items.Add("How many times was each test requested?")

        ElseIf ComboBox1.Text() = "TestResult" Then
            tableno = 6
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Count number of Test results")
            ComboBox2.Items.Add("How many times was each test performed?")
            ComboBox2.Items.Add("Number of tests done by each Employee")
        ElseIf ComboBox1.Text() = "Complaints" Then
            tableno = 7
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Count number of complaints")
        End If
    End Sub

    Private Sub Statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Patient")
        ComboBox1.Items.Add("DEPARTMENT")
        ComboBox1.Items.Add("STAFF")
        ComboBox1.Items.Add("SALARY")
        ComboBox1.Items.Add("TEST_REQ")
        ComboBox1.Items.Add("TestResult")
        ComboBox1.Items.Add("TestPrice")
        ComboBox1.Items.Add("Complaints")
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        database.GetSQLConnection()
        Dim query = ""
        If ComboBox1.Text() = "Patient" And ComboBox2.Text() = "Count number of Patients" Then
            query = "Select COUNT(*) from Patient"
        ElseIf ComboBox1.Text() = "DEPARTMENT" And ComboBox2.Text() = "Count number of Departments" Then
            query = "Select COUNT(*) from DEPARTMENT"
        ElseIf ComboBox1.Text() = "STAFF" And ComboBox2.Text() = "Count number of Employees" Then
            query = "Select COUNT(*) from STAFF"
        ElseIf ComboBox1.Text() = "SALARY" And ComboBox2.Text() = "Display employee with highest salary" Then
            query = "Select TOP 1 * FROM SALARY ORDER BY SALARY DESC"
        ElseIf ComboBox1.Text() = "SALARY" And ComboBox2.Text() = "Display employee with Lowest salary" Then
            query = "Select TOP 1 * FROM SALARY ORDER BY SALARY ASC"
        ElseIf ComboBox1.Text() = "SALARY" And ComboBox2.Text() = "Display average of employees salaries" Then
            query = "Select AVG(SALARY) AS AverageSalary FROM SALARY"
        ElseIf ComboBox1.Text() = "TEST_REQ" And ComboBox2.Text() = "Count number of Test requests" Then
            query = "Select COUNT(*) from TEST_REQ"
        ElseIf ComboBox1.Text() = "TEST_REQ" And ComboBox2.Text() = "How many times was each test requested?" Then
            query = "SELECT TestName, COUNT(*) AS OccurrenceCount FROM TEST_REQ GROUP BY TestName"
        ElseIf ComboBox1.Text() = "TestResult" And ComboBox2.Text() = "Count number of Test results" Then
            query = "Select COUNT(*) from TestResult"
        ElseIf ComboBox1.Text() = "TestResult" And ComboBox2.Text() = "How many times was each test performed?" Then
            query = "SELECT TestName, COUNT(*) AS OccurrenceCount FROM TestResult GROUP BY TestName"
        ElseIf ComboBox1.Text() = "TestResult" And ComboBox2.Text() = "Number of tests done by each Employee" Then

            query = "SELECT Performedby, COUNT(*) AS OccurrenceCount FROM TestResult GROUP BY PerformedBy"

        ElseIf ComboBox1.Text() = "Complaints" And ComboBox2.Text() = "Count number of complaints" Then
            query = "Select COUNT(*) from Complaints"
        Else

        End If
        Dim adapter As New SqlDataAdapter(query, sqlcon)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class