
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class AdminInterface
    Inherits System.Web.UI.Page
    Private ReadOnly connectionString As String = WebConfigurationManager.ConnectionStrings("Quiz_Application_Database").ConnectionString
    Public Shared UserID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Session("UserRole") = "Admin" Then
                'take the user data from the from database And update the userprofile accordingly
                UserID = Session("UserID")
                Dim adminProfilelabel As New Label
                AdminProfile.Controls.Clear()
                adminProfilelabel.ID = "txtLabel_instructorProfile"
                Update_UserProfile(adminProfilelabel)
                AdminProfile.Controls.Add(adminProfilelabel)
            Else
                Response.Redirect("AccessDeniedPage.aspx")
            End If
        End If

    End Sub

    'Function for updating the userProfile from database 
    Private Sub Update_UserProfile(label_UserProfile As Label)
        label_UserProfile.Controls.Clear()
        ' Define ADO.NET objects.
        Dim selectSQL As String
        'general user data
        selectSQL = "SELECT UserID, FullName, Address, Email, PhoneNumber FROM User_Login_Credentials Where userID = " & UserID

        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(selectSQL, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dsQuizDB As New DataSet()
        ' Try to open database and read information.
        Try
            con.Open()
            adapter.Fill(dsQuizDB, "User_Login_Credentials")

            'specific user data
            cmd.CommandText = "SELECT UserID FROM Admin_Table Where userID = " & UserID
            adapter.Fill(dsQuizDB, "Admin_Table")

        Catch err As Exception
            label_UserProfile.Text = "Error 404! The User Account Doesn't found "

        Finally
            con.Close()
        End Try


        Try
            'The first augument, defines the unique name for the relation, while the 2nd and 3rd shows 
            ' the unique parent and child relation in the tables respectivley
            'relation between quiz user and quiz students 
            Dim QuizUsers_QuizAdmins As New DataRelation("QuizUsers_QuizAdmins",
            dsQuizDB.Tables("User_Login_Credentials").Columns("UserID"),
            dsQuizDB.Tables("Admin_Table").Columns("UserID"))

            'Adding the relations
            dsQuizDB.Relations.Add(QuizUsers_QuizAdmins)

            Dim userRow As DataRow
            Dim adminRow As DataRow
            adminRow = dsQuizDB.Tables("Admin_Table").Rows.Item(0)
            userRow = adminRow.GetParentRow(QuizUsers_QuizAdmins)

            'Adding the particular information of the admin to the admin section of page
            InsertLabel("Admin Name: ", userRow("FullName"), "txtlabel_adminfullName")
            InsertLabel("Admin Address: ", userRow("Address"), "txtlabel_adminAdress")
            InsertLabel("Admin Email: ", userRow("Email"), "txtlabel_adminEmail")
            InsertLabel("Admin Phone Number: ", userRow("PhoneNumber"), "txtlabel_adminPhone")

        Catch ex As Exception
            ShowErrorMessages.Text = "<b>Sorry For inconvenience! There are issues with the Admin Account!</b>"
            BtnChangeSetting.Visible = False
            Title.Visible = False
        End Try

    End Sub

    'This subrouting would add the label to the profile section of admin 
    Private Sub InsertLabel(labelText As String, labelValue As String, labelId As String)
        Dim txtLabel As New Label With {
            .ID = labelId,
            .Text = "<br/>" & labelText & "&nbsp &nbsp" & labelValue & "<br/>"
        }
        AdminProfile.Controls.Add(txtLabel)
    End Sub

    Private Sub BtnChangeSetting_Click(sender As Object, e As EventArgs) Handles BtnChangeSetting.Click
        Dim url As String
        url = "Setting.aspx"
        Response.Redirect(url)
    End Sub


End Class