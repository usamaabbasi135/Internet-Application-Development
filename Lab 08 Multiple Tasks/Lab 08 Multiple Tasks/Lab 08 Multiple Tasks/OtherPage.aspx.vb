Public Class OtherPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CustomerName As String = Request.QueryString("CustomerName")
        Dim FavouriteSports As String = Request.QueryString("FavouriteSports")
        Label1.Text = "Welcome to new Page " + CustomerName + " Your favourite sports is: " + FavouriteSports

    End Sub

End Class