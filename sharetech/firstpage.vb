Public Class firstpage

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label4.Text = ProgressBar1.Value & "%"
        ProgressBar1.Value += 1

        ' It's load the progressbar
        ProgressBar1.Increment(1)
        Label4.Text = ProgressBar1.Value & "% Loading....."
        If ProgressBar1.Value = 100 Then
            Me.Hide()

            Dim l = New Form1
            l.Show()

            Timer1.Enabled = False

        End If
    End Sub
    Private Sub firstpage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class