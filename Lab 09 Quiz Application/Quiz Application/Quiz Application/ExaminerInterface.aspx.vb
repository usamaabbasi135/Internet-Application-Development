Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ExaminerInterface
    Inherits System.Web.UI.Page
    Private connectionString As String = WebConfigurationManager.ConnectionStrings("Quiz_Application_Database").ConnectionString
    Public Shared UserID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("UserRole") = "Examiner" Then

                'take the user data from the from database And update the userprofile accordingly
                UserID = Session("UserID")
                Dim InstructorProfilelabel As New Label
                InstructorProfile.Controls.Clear()
                InstructorProfilelabel.ID = "txtLabel_instructorProfile"
                Update_UserProfile(InstructorProfilelabel)
                InstructorProfile.Controls.Add(InstructorProfilelabel)
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
            cmd.CommandText = "SELECT ExaminerID, UserID, GradeScale, Department FROM Examiner_Table Where userID = " & UserID
            adapter.Fill(dsQuizDB, "Examiner_Table")

        Catch err As Exception
            label_UserProfile.Text = "Error 404! The User Account Doesn't found"
            'label_UserProfile.Text &= err.Message
        Finally
            con.Close()
        End Try

        Try
            'The first augument, defines the unique name for the relation, while the 2nd and 3rd shows 
            ' the unique parent and child relation in the tables respectivley
            'relation between quiz user and quiz students 
            Dim QuizUser_QuizExaminer As New DataRelation("QuizUser_QuizExaminer",
            dsQuizDB.Tables("User_Login_Credentials").Columns("UserID"),
            dsQuizDB.Tables("Examiner_Table").Columns("UserID"))

            'add relations
            dsQuizDB.Relations.Add(QuizUser_QuizExaminer)


            Dim userRow As DataRow
            Dim instructorRow As DataRow
            instructorRow = dsQuizDB.Tables("Examiner_Table").Rows.Item(0)
            userRow = instructorRow.GetParentRow(QuizUser_QuizExaminer)

            InsertLabel("Instructor Name: ", userRow("FullName"), "txtlabel_studentfullName")
            InsertLabel("Instructor Address: ", userRow("Address"), "txtlabel_studentAdress")
            InsertLabel("Instructor Email: ", userRow("Email"), "txtlabel_studentEmail")
            InsertLabel("Instructor Phone Number: ", userRow("PhoneNumber"), "txtlabel_studentPhone")

            InsertLabel("Instructor  ID: ", instructorRow("ExaminerID"), "txtlabel_instructorID")
            InsertLabel("Instructor Grade Scale : ", instructorRow("GradeScale"), "txtlabel_instructormarks")
            InsertLabel("Department : ", instructorRow("Department"), "txtlabel_instructordepartment")
        Catch ex As Exception
            ShowErrorMessages.Text = "<b>Sorry For inconvenience! There are issues with the Examiner Account!</b>"
            BtnInsertQuestion.Visible = False
            Title.Visible = False
        End Try

    End Sub


    Private Sub InsertLabel(labelText As String, labelValue As String, labelId As String)
        Dim txtLabel As New Label With {
            .ID = labelId,
            .Text = "<br/>" & labelText & "&nbsp &nbsp" & labelValue & "<br/>"
        }
        InstructorProfile.Controls.Add(txtLabel)
    End Sub

    Private Sub BtnInsertQuestion_Click(sender As Object, e As EventArgs) Handles BtnInsertQuestion.Click
        Dim url As String
        url = "AddQuestion.aspx"
        Response.Redirect(url)
    End Sub


End Class