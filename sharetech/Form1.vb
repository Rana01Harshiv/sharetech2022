Imports System.Data.OleDb
Public Class Form1
    Dim cn As New OleDbConnection
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Username")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter Password")
        Else
            cn.Open()
            Dim str As String
            str = "select * from login where username ='" & TextBox1.Text & "' and password ='" & TextBox2.Text & "' "
            Dim cmd = New OleDbCommand(str, cn)
            Dim adp = New OleDbDataAdapter(cmd)
            Dim ds = New DataSet()
            adp.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("Wrong username or password")
            Else
                Dim obj = New home
                obj.Show()
                Me.Hide()
            End If
            cn.Close()

        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
