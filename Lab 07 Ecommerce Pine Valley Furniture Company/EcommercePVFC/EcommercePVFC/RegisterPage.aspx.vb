Public Class RegisterPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userName As String = TextBox1.Text
        Dim email As String = TextBox2.Text
        Dim password As String = Password1.Value

        Console.WriteLine(userName, email)



    End Sub
End Class