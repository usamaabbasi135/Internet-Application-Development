Imports System.Data.SqlClient

Public Class RegisterPage
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim userId As String = TextBox4.Text
        Dim userName As String = TextBox1.Text
        Dim email As String = TextBox2.Text

        Dim password As String = Password1.Value
        Dim conStr As String = "Data Source=haier-pc;Initial Catalog=EcommercePVFC;Integrated Security=True"
        Dim con As New SqlConnection()
        con.ConnectionString = conStr
        Dim cmd As New SqlCommand()
        cmd.Connection = con
        cmd.CommandText = "Insert into Registration_T(Id, UserName, Email , Password ) values('" + userId + "', '" + userName + "', '" + email + "', '" + password + "' )"

        If userId <> "" Or userName <> "" Or email <> "" Or password <> "" Then
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Else
            TextBox3.Text = "Enter all details"
        End If





    End Sub
End Class