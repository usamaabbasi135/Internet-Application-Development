Public Class QueryString
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Unnamed1_Click(sender As Object, e As EventArgs)
        Dim slctdVal = ListBox1.SelectedValue
        Dim radioButton = RadioButtonList1.SelectedValue
        Response.Redirect(String.Format("~/OtherPage.aspx?CustomerName=" + slctdVal + "&FavouriteSports=" + radioButton))
    End Sub
End Class

