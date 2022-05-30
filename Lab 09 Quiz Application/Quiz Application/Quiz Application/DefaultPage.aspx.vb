Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class DefaultPage
    Inherits System.Web.UI.Page
    'connection string
    Private ReadOnly connectionString As String = WebConfigurationManager.ConnectionStrings("Quiz_Application_Database").ConnectionString

    'Global varialble Accessible to all the functions 
    Public Shared _UserID As Integer

    'this subrouting would run when the user would click on login button after entering all the data
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Lbl_showErrorMessages.Controls.Clear()
        Dim UserRole, UserEmail, UserPassword As String
        'Storing the radio button info which is checked
        If RadiobtnAdmin.Checked Then
            UserRole = RadiobtnAdmin.Text
        ElseIf RadiobtnExaminer.Checked Then
            UserRole = RadiobtnExaminer.Text
        ElseIf RadiobtnStudent.Checked Then
            UserRole = RadiobtnStudent.Text
        End If

        'storing the user email and password entered by the user
        UserEmail = TxtboxEmail.Text
        UserPassword = TxtboxPassword.Text




        'Validating the user by ValidateUser function this would return 0 or 1 depending upon the success or failure
        If ValidateUser(UserEmail, UserRole, UserPassword) Then

            Dim url As String
            'Transferring the user to the page according to it's role
            If String.Compare(UserRole, "Admin") = 0 Then
                Session("UserRole") = "Admin"
                url = "AdminInterface.aspx"
                Response.Redirect(url)
            ElseIf String.Compare(UserRole, "Examiner") = 0 Then
                Session("UserRole") = "Examiner"
                url = "ExaminerInterface.aspx"
                Response.Redirect(url)
            ElseIf String.Compare(UserRole, "Student") = 0 Then
                Session("UserRole") = "Student"
                url = "student.aspx"
                Response.Redirect(url)
            End If
        End If

    End Sub

    'This function is used to validate the user. It would take user email, password and role as parameters
    Private Function ValidateUser(UserEmail As String, UserRole As String, UserPassword As String) As Boolean
        Dim selectSQL As String
        Dim IsPasswordCorrect As Boolean
        'Get the data from database according to the email entered by the user
        selectSQL = "SELECT email, userRole, UserID FROM User_Login_Credentials Where email = '" & UserEmail.ToString() & " '"
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(selectSQL, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dsQuizDB As New DataSet()
        ' Try to open database and read information.
        Try
            con.Open()

            adapter.Fill(dsQuizDB, "User_Login_Credentials")

            '
            cmd.CommandText = "Select CASE WHEN '" & UserPassword.ToString() & "' = "
            cmd.CommandText &= "(SELECT UserPassword from User_Login_Credentials where Email = '" & UserEmail.ToString & "') THEN '1' ELSE '0' END as condition"
            adapter.Fill(dsQuizDB, "Condition")

            'This will return 1 if password matches otherwise 0
            IsPasswordCorrect = Integer.Parse(dsQuizDB.Tables("Condition").Rows.Item(0).Field(Of String)("condition"))

            'Checking whether, the Role and Password Entered by the user is valid 
            If UserRole = dsQuizDB.Tables("User_Login_Credentials").Rows.Item(0).Field(Of String)("UserRole") Then
                If IsPasswordCorrect Then
                    _UserID = dsQuizDB.Tables("User_Login_Credentials").Rows.Item(0)("userID")
                    Session("UserID") = _UserID
                    Return True
                Else
                    Lbl_showErrorMessages.Text = "The Password You Entered is incorrect!"
                    Return False
                End If
            Else
                Lbl_showErrorMessages.Text = "The User Role you Entered Doesn't Match!"
                Return False
            End If

        Catch err As Exception
            Lbl_showErrorMessages.Text = "The Email address you entered is not registered!"
            Return False
            'label_UserProfile.Text &= err.Message
        Finally
            con.Close()
        End Try

    End Function


End Class