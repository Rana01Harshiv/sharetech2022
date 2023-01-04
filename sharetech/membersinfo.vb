Imports System.Data.OleDb
Imports System.Data
Public Class membersinfo
    Dim cn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim adp As New OleDbDataAdapter
    Dim ds As New DataSet
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")

    Public Sub Reset()
        TextBox5.Text = "0"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    

    Sub view()

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from membersinfo", con)
        Dim ds As New DataSet
        adp.Fill(ds, "membersinfo")
        DataGridView1.DataSource = ds.Tables("membersinfo")
        con.Close()

    End Sub

    Public Sub display()
        ds.Clear()
        adp = New OleDbDataAdapter("select * from membersinfo", cn)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub


    Private Sub membersinfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SharetechDataSet2.membersinfo' table. You can move, or remove it, as needed.
        Me.MembersinfoTableAdapter.Fill(Me.SharetechDataSet2.membersinfo)
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01"
        cn.Open()
        display()
        cn.Close()

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim obj_1 As New home
        obj_1.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into membersinfo values (" & TextBox5.Text & ",'" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox(" Record saved succesfully ")
        view()
        Reset()


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        view()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from membersinfo where id = " & TextBox5.Text & ""
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record deleted successfully")
        view()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

           ' Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
            con.Open()
            Dim str As String
            str = " update membersinfo set firstname= '" & TextBox1.Text & "', lastname = '" & TextBox2.Text & "',address = '" & TextBox3.Text & "', bankname = '" & TextBox4.Text & "' where id = " & TextBox5.Text & " "
            cmd = New OleDbCommand(str, cn)
            cmd.ExecuteNonQuery()
            MsgBox("Record Updated Succesfully", MsgBoxStyle.Information, "success")
            view()
            Reset()
            ' con.Close()
            'MsgBox(" Record Updated Successfully ")
            'view()

        Catch ex As Exception
            MsgBox("Missing details...")
        End Try
        con.Close()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim obj_1 As New home
        obj_1.Show()
        Me.Hide()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Reset()
    End Sub
End Class