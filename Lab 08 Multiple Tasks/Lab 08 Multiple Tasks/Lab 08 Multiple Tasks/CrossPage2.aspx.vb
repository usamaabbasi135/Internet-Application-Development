Public Class CrossPage2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If PreviousPage IsNot Nothing Then
            Label1.Text = "You came from a page titled " & PreviousPage.Title

        End If
    End Sub

End Class