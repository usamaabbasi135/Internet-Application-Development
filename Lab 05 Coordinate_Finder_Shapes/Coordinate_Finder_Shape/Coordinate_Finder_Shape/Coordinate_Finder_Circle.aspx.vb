Imports System.Math

Public Class Coordinate_Finder_Circle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ImgButton_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) _
     Handles ImgButton.ServerClick

        Dim height As Integer = 200
        Dim width As Integer = 200
        Dim eventX As Integer = e.X
        Dim eventY As Integer = e.Y



        Dim cartesianX As Integer = e.X - (width / 2)
        Dim cartesianY As Integer = (height / 2) - e.Y
        Dim radius As Integer = Sqrt((cartesianX * cartesianX) + (cartesianY * cartesianY))
        P1.InnerText = radius
        If (radius > 100) Then
            Result.InnerText = "You clicked outside the circle"
        ElseIf (cartesianX > 0) And (cartesianY > 0) Then
            Result.InnerText = "You clicked the first quadrant (Dark Blue)"
        ElseIf (cartesianX < 0) And (cartesianY > 0) Then
            Result.InnerText = "You clicked the second quadrant (Red)"
        ElseIf (cartesianX < 0) And (cartesianY < 0) Then
            Result.InnerText = "You clicked the third quadrant (Green)"
        ElseIf (cartesianX > 0) And (cartesianY < 0) Then
            Result.InnerText = "You clicked the fourth quadrant(Yellow)"
        Else
            Result.InnerText = ""
        End If















    End Sub
End Class