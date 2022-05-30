Public Class Page249
    Inherits System.Web.UI.Page
    Private Contents As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            ' Restore variables.
            Contents = CType(ViewState("Contents"), String)
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object,
ByVal e As EventArgs) Handles Me.PreRender
        ' Persist variables.
        ViewState("Contents") = Contents
    End Sub
    Protected Sub cmdSave_Click(ByVal sender As Object,
    ByVal e As EventArgs) Handles cmdSave.Click
        ' Transfer contents of text box to member variable.
        Contents = txtValue.Text
        txtValue.Text = ""
    End Sub
    Protected Sub cmdLoad_Click(ByVal sender As Object,
    ByVal e As EventArgs) Handles cmdLoad.Click
        ' Restore contents of member variable to text box.
        txtValue.Text = Contents
    End Sub



End Class