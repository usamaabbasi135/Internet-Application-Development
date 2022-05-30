Public Class FormSubmission
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Marks As Integer
        Marks = Session("Marks")
        showMarks.Text = "Your marks are: " & Marks.ToString
    End Sub

End Class