Public Class HiddenField
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim M As String = "3689"
            HiddenField1.Value = M
            TextBox1.Text = HiddenField1.Value
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = HiddenField1.Value
    End Sub


End Class