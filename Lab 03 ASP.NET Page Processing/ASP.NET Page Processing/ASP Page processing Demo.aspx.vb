Public Class ASP_Page_processing_Demo
    Inherits System.Web.UI.Page

    Private Sub Page_PreInit(ByVal poSender As Object, ByVal poArguments As System.EventArgs) Handles Me.PreInit
        Response.Write("<br /> 1) The control is in PreInit Method ")
    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Response.Write("<br /> 4) The control is in PreLoad Method ")
    End Sub


    Private Sub Page_Init(ByVal poSender As Object, ByVal poArguments As System.EventArgs) Handles Me.Init
        Response.Write("<br /> 2) The control is in Init Method ")
    End Sub

    Private Sub Page_InitComplete(ByVal poSender As Object, ByVal poArguments As System.EventArgs) Handles Me.InitComplete
        Response.Write("<br /> 3) The control is in InitComplete Method ")
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<br /> 5) The control is in Load Method ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Write("<br /> 6) The button is clicked")
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Response.Write("<br /> 7) The control is in LoadComplete Method ")
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete

        Response.Write("<br /> 8) The control is in PreRender Method ")
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        TextBox1.Text = "This text is written in the unload event"

    End Sub

End Class