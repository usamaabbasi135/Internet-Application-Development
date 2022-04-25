Public Class Dynamic_Button
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CreateView_Click(sender As Object, e As EventArgs) Handles CreateView.Click
        'creating the row object and setting its properties                        
        Dim firstRow As New TableRow
        'added the row to table
        tble.Controls.Add(firstRow)

        'creating the cell, setting its properities and added the cell to the table row
        Dim cell1 As New TableCell
        firstRow.Controls.Add(cell1)


        Dim label1 As New Label
        label1.Text = "Type something here"
        cell1.Controls.Add(label1)

        Dim cell2 As New TableCell
        firstRow.Controls.Add(cell2)
        'adding the text area into the cell1 of row
        Dim textArea As New TextBox
        textArea.ID = "text_Area"
        textArea.TextMode = TextBoxMode.MultiLine
        cell2.Controls.Add(textArea)

        'creating the second row object and setting its properties                        
        Dim secondRow As New TableRow
        'added the row to table
        tble.Controls.Add(secondRow)

        'creating the cell, setting its properities and added the cell to the table row
        Dim cell12 As New TableCell
        secondRow.Controls.Add(cell12)

        Dim button1 As New Button
        button1.Text = "Button_One"
        button1.ID = "button1"
        AddHandler button1.Click, AddressOf Me.Button_Click

        cell12.Controls.Add(button1)

        'creating the cell, setting its properities and added the cell to the table row
        Dim cell22 As New TableCell
        secondRow.Controls.Add(cell22)

        Dim button2 As New Button
        button2.Text = "Button_Two"
        button2.ID = "button2"
        AddHandler button2.Click, AddressOf Me.Button_Click
        cell22.Controls.Add(button2)





    End Sub


    Protected Sub Button_Click(sender As System.Object, e As System.EventArgs)
        Dim selectedBtn As Button = sender
        MsgBox("you have clicked button " & selectedBtn.Text)
    End Sub
End Class