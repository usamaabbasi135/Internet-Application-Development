Public Class Page245
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblCount.InnerText = 0
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim counter As Integer
        If Me.ViewState("counter") Is Nothing Then
            counter = 1
        Else
            counter = CType(Me.ViewState("counter"), Integer) + 2

        End If
        ViewState("counter") = counter
        lblCount.InnerText = counter




    End Sub
End Class