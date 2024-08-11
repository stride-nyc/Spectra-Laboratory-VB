Public Class admin_page
    Private images As List(Of Image)
    Private currentIndex As Integer = 0
    Private Sub Hi_Click(sender As Object, e As EventArgs)
        view_patients.Show()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Staff_Click(sender As Object, e As EventArgs)
        staff.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Utilities.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Statistics.Show()
    End Sub

    Private Sub admin_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        images = New List(Of Image) From {
            My.Resources.applying_gel_for_an_ultrasound_exam_examination_scan_scanner_image,
            My.Resources.iStock_491322891,
            My.Resources.shutterstock_414452563_ecg2,
            My.Resources.lab
        }
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel4.BackgroundImage = images(currentIndex)
        Panel4.BackgroundImageLayout = ImageLayout.Zoom

        currentIndex = (currentIndex + 1) Mod images.Count
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Insert_Results.Show()
    End Sub
End Class