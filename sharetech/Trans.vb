Imports System.Data.OleDb
Imports System.Data
Public Class Trans

    Sub view()

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from trans", con)
        Dim ds As New DataSet
        adp.Fill(ds, "membersinfo")
        DataGridView1.DataSource = ds.Tables("membersinfo")
        con.Close()

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim obj_1 As New home
        obj_1.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from trans where id = " & TextBox5.Text & ""
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record deleted successfully")
        view()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim obj_1 As New home
        obj_1.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into trans values (" & TextBox5.Text & ",'" & TextBox6.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox(" Record Inserted succesfully ")
        view()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\sharetech\sharetech.accdb;Jet OLEDB:Database Password=01")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " update trans set chqno = " & TextBox6.Text & ", debit = " & TextBox2.Text & ",credit = " & TextBox3.Text & " where id = " & TextBox5.Text & " "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox(" Record Updated Successfully ")
        view()
    End Sub
End Class