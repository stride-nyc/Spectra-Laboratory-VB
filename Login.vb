Imports System.Data.SqlClient

Public Class Login

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        database.GetSQLConnection()
        sqlcon.Open()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles adminbtn.Click
        admin_page.Show()
        'Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles userbtn.Click
        User_HomePage.Show()
        'Me.Hide()
    End Sub
End Class
