Public Class CreateCookie
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Dim nameCookie As HttpCookie = Request.Cookies("Name")
            Dim name As String = nameCookie.Value
            TextBox1.Text = "Welcome Back " + nameCookie.Value
        Else
            Dim nameCookie As HttpCookie = Request.Cookies("Name")
            Dim name As String = nameCookie.Value
            TextBox1.Text = "Welcome Back " + nameCookie.Value
        End If
    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nameCookie As New HttpCookie("Name")

        'Set the Cookie value.
        nameCookie.Value = TextBox2.Text

        'Set the Expiry date.
        nameCookie.Expires = DateTime.Now.AddDays(30)

        'Add the Cookie to Browser.
        Response.Cookies.Add(nameCookie)
    End Sub
End Class