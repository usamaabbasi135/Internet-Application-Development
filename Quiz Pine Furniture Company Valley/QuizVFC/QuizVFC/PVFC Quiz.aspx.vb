Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Configuration


Public Class PVFC_Quiz
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Populating a DataTable from database.
            Dim dt As DataTable = Me.GetData()

            'Building an HTML string.
            Dim html As New StringBuilder()

            'Table start.
            html.Append("<table border = '1'>")

            'Building the Header row.
            html.Append("<tr>")
            For Each column As DataColumn In dt.Columns
                html.Append("<th>")
                html.Append(column.ColumnName)
                html.Append("</th>")
            Next
            html.Append("</tr>")

            'Building the Data rows.
            For Each row As DataRow In dt.Rows
                html.Append("<tr>")
                For Each column As DataColumn In dt.Columns
                    html.Append("<td>")
                    html.Append(row(column.ColumnName))
                    html.Append("</td>")
                Next
                html.Append("</tr>")
            Next

            'Table end.
            html.Append("</table>")

            'Append the HTML string to Placeholder.
            tableHolder.Controls.Add(New Literal() With {
               .Text = html.ToString()
             })
        End If
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAddRecord.Click
        If custId.Text = "" Or custNme.Text = "" Or custAdrs.Text = "" Or custState.Text = "" Or custPstlCde.Text = "" Then

            lblResults.Text = "Records require an CustomerID, Customer Name, Customer Address, Customer State, Cutomer Postal Code"
            Return
        End If


        Dim conStr As String = "Data Source=localHost;Initial Catalog=test;Integrated Security=True"
        Dim insertSQL As String
        insertSQL = "SET IDENTITY_INSERT Customer_T ON SET ANSI_WARNINGS OFF "
        insertSQL &= "INSERT INTO [Customer_T]("
        insertSQL &= "[CustomerID], [CustomerName], [CustomerAddress], [CustomerCity], "
        insertSQL &= "[CustomerState], [CustomerPostalCode]) "
        insertSQL &= "VALUES('"
        insertSQL &= custId.Text & "', '"
        insertSQL &= custNme.Text & "', '"
        insertSQL &= custAdrs.Text & "', '"
        insertSQL &= custCty.Text & "', '"
        insertSQL &= custState.Text & "', '"
        insertSQL &= custPstlCde.Text & "')"


        Dim con As New SqlConnection(conStr)
        Dim cmd As New SqlCommand(insertSQL, con)
        ' Try to open the database and execute the update.
        Dim added As Integer = 0
        Try
            con.Open()
            added = cmd.ExecuteNonQuery()
            lblResults.Text = added.ToString() & " records inserted."
        Catch err As Exception
            lblResults.Text = "Error inserting record. "
            lblResults.Text &= err.Message
        Finally
            con.Close()
        End Try
        ' If the insert succeeded, refresh the author list.
        If added > 0 Then
            Dim html As New StringBuilder()
            html = ShowData()
            'Append the HTML string to Placeholder.
            tableHolder.Controls.Add(New Literal() With {
               .Text = html.ToString()
             })
        End If



    End Sub



    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnRemoveRecord.Click
        Dim conStr As String = "Data Source=localHost;Initial Catalog=test;Integrated Security=True"
        ' Define ADO.NET objects.
        Dim deleteSQL As String
        deleteSQL = "SET IDENTITY_INSERT Customer_T ON SET ANSI_WARNINGS OFF "
        deleteSQL &= "DELETE From Customer_T WHERE CustomerID=@CustomerID"

        Dim con As New SqlConnection(conStr)
        Dim cmd As New SqlCommand(deleteSQL, con)

        ' Add the parameters.
        cmd.Parameters.AddWithValue("@CustomerID", custId.Text)
        ' Try to open the database and delete the record.
        Dim deleted As Integer = 0
        Try
            con.Open()
            deleted = cmd.ExecuteNonQuery()
            lblResults.Text &= "Record deleted."
        Catch err As Exception
            lblResults.Text = "Error deleting author. "
            lblResults.Text &= err.Message
        Finally
            con.Close()
        End Try
        ' If the delete succeeded, refresh the author list.
        If deleted > 0 Then
            'lblResults.Text = ""
            Dim html As New StringBuilder()
            html = ShowData()
            'Append the HTML string to Placeholder.
            tableHolder.Controls.Add(New Literal() With {
               .Text = html.ToString()
             })
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles btnUpdateRecord.Click
        Dim conStr As String = "Data Source=localHost;Initial Catalog=test;Integrated Security=True"
        ' Define ADO.NET objects.
        Dim updateSQL As String
        updateSQL = "SET IDENTITY_INSERT Customer_T ON SET ANSI_WARNINGS OFF "
        updateSQL &= "UPDATE Customer_T SET "
        updateSQL &= "CustomerName=@CustomerName, CustomerAddress=@CustomerAddress, CustomerCity=@CustomerCity, CustomerState=@CustomerState, CustomerPostalCode=@CustomerPostalCode "
        updateSQL &= "WHERE CustomerID=@CustomerID"
        Dim con As New SqlConnection(conStr)
        Dim cmd As New SqlCommand(updateSQL, con)
        ' Add the parameters.
        cmd.Parameters.AddWithValue("@CustomerID", custId.Text)
        cmd.Parameters.AddWithValue("@CustomerName", custNme.Text)

        cmd.Parameters.AddWithValue("@CustomerAddress", custAdrs.Text)
        cmd.Parameters.AddWithValue("@CustomerCity", custCty.Text)
        cmd.Parameters.AddWithValue("@CustomerState", custState.Text)
        cmd.Parameters.AddWithValue("@CustomerPostalCode", custPstlCde.Text)
        ' Try to open database and execute the update.
        Dim updated As Integer = 0
        Try
            con.Open()
            updated = cmd.ExecuteNonQuery()
            lblResults.Text = updated.ToString() & " record updated."
        Catch err As Exception
            lblResults.Text = "Error updating author. "
            lblResults.Text &= err.Message
        Finally
            con.Close()
        End Try
        ' If the update succeeded, refresh the author list.
        If updated > 0 Then
            Dim html As New StringBuilder()
            html = ShowData()
            'Append the HTML string to Placeholder.
            tableHolder.Controls.Add(New Literal() With {
               .Text = html.ToString()
             })
        End If
    End Sub

    Private Function GetData() As DataTable
        Dim constr As String = "Data Source=localHost;Initial Catalog=test;Integrated Security=True"
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT * FROM [test].[dbo].[Customer_T]")
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        Return dt
                    End Using
                End Using
            End Using
        End Using
    End Function

    Private Function ShowData()
        'Populating a DataTable from database.
        Dim dt As DataTable = Me.GetData()

        'Building an HTML string.
        Dim html As New StringBuilder()

        'Table start.
        html.Append("<table border = '1'>")

        'Building the Header row.
        html.Append("<tr>")
        For Each column As DataColumn In dt.Columns
            html.Append("<th>")
            html.Append(column.ColumnName)
            html.Append("</th>")
        Next
        html.Append("</tr>")

        'Building the Data rows.
        For Each row As DataRow In dt.Rows
            html.Append("<tr>")
            For Each column As DataColumn In dt.Columns
                html.Append("<td>")
                html.Append(row(column.ColumnName))
                html.Append("</td>")
            Next
            html.Append("</tr>")
        Next

        'Table end.
        html.Append("</table>")

        Return html

    End Function
End Class

