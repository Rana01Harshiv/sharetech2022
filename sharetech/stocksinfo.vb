Imports System.Data.OleDb
Imports System.Data
Public Class stocksinfo
    Public Sub Reset()
        TextBox6.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub
    Sub view()

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from stocksinfo", con)
        Dim ds As New DataSet
        adp.Fill(ds, "stocksinfo")
        DataGridView1.DataSource = ds.Tables("stocksinfo")
        con.Close()

    End Sub
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Dim obj_1 As New home
        obj_1.Show()
        Me.Hide()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into stocksinfo values (" & TextBox6.Text & ",'" & TextBox1.Text & "','" & TextBox2.Text & "'," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text & ")"
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox(" Record saved succesfully ")
        view()
    End Sub
    Private Sub stocksinfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SharetechDataSet2.stocksinfo' table. You can move, or remove it, as needed.
        Me.StocksinfoTableAdapter.Fill(Me.SharetechDataSet2.stocksinfo)

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from membersinfo where id = " & TextBox6.Text & ""
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record deleted successfully")
        view()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim obj_1 As New home
        obj_1.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        view()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Reset()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update membersinfo set (stockname.companyname,aveargeprice,highprice,lowprice) values where id = " & TextBox6.Text & ""
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Updated  successfully")
        view()
    End Sub
End Class