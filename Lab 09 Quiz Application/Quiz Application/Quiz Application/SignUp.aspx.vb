Imports System.Web.UI.Control
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class SignUp

    Inherits System.Web.UI.Page

    'Getting the string for database connection from configuration file
    Public connectionString As String = WebConfigurationManager.ConnectionStrings("Quiz_Application_Database").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'sub routing for radioButton admin
    Private Sub radiobtnAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles radiobtnAdmin.CheckedChanged

        'these are just line break to keep the user interface good, when radio button checked are changed 
        space11.Visible = True
        space21.Visible = False
        space31.Visible = False
        space41.Visible = False
        departmentNameTitle.Visible = False
        txtboxDepartmentName.Visible = False
        semesterNumberTitle.Visible = False
        txtboxSemesterNumber.Visible = False
        gradeScaleTitle.Visible = False
        txtBoxGradeScale.Visible = False

    End Sub

    Private Sub radiobtnInstructor_CheckedChanged(sender As Object, e As EventArgs) Handles radiobtnInstructor.CheckedChanged

        'these are just line break to keep the user interface good, when radio button checked are changed
        space11.Visible = True
        space21.Visible = True
        space31.Visible = False
        space41.Visible = True
        departmentNameTitle.Visible = True
        txtboxDepartmentName.Visible = True
        semesterNumberTitle.Visible = False
        txtboxSemesterNumber.Visible = False
        gradeScaleTitle.Visible = True
        txtBoxGradeScale.Visible = True

        'Inserting Validation to the dynamically added controls
        insertValidator("*Grade Scale", "Grade Scale is mandatory", "txtBoxGradeScale")
        insertValidator("*Department Name", "Department Name is mandatory", "txtboxDepartmentName")

    End Sub

    Private Sub radiobtnStudent_CheckedChanged(sender As Object, e As EventArgs) Handles radiobtnStudent.CheckedChanged

        space11.Visible = False
        space21.Visible = True
        space31.Visible = True
        space41.Visible = False
        departmentNameTitle.Visible = True
        txtboxDepartmentName.Visible = True
        semesterNumberTitle.Visible = True
        txtboxSemesterNumber.Visible = True
        gradeScaleTitle.Visible = False
        txtBoxGradeScale.Visible = False

        'Inserting Validation to the dynamically added controls
        insertRangeValidator(0, 9, "*Invalid Semester", "Semester No. should be between 0  and 9", "txtboxSemesterNumber")
        insertValidator("*Department Name", "Department Name is mandatory", "txtboxDepartmentName")

    End Sub



    'This subroutine would be used to insert validation dynamically to the controls which were added by the change in
    'radio button selection
    Private Sub insertValidator(validationText As String, ErrorMessage As String, txtboxID As String)
        Dim rqfValidator As RequiredFieldValidator = New RequiredFieldValidator
        rqfValidator.Display = ValidatorDisplay.Dynamic
        rqfValidator.Text = validationText
        rqfValidator.Attributes.Add("runat", "server")
        rqfValidator.ErrorMessage = ErrorMessage
        rqfValidator.ControlToValidate = txtboxID
        Me.Form.Controls.Add(rqfValidator)
    End Sub

    'This subroutine would be used to insert range validation dynamically to the controls which were added by the change in
    'radio button selection

    Private Sub insertRangeValidator(minValue As Integer, maxValue As Integer, RangeValidationText As String, ErrorMessage As String, txtboxID As String)
        Dim rangeValidator As RangeValidator = New RangeValidator
        rangeValidator.MinimumValue = minValue.ToString()
        rangeValidator.MaximumValue = maxValue.ToString()
        rangeValidator.Type = ValidationDataType.Double
        rangeValidator.ErrorMessage = ErrorMessage
        rangeValidator.Text = RangeValidationText
        rangeValidator.Style.Add("position", "absolute")
        rangeValidator.Attributes.Add("runat", "server")
        rangeValidator.ControlToValidate = txtboxID
        rangeValidator.Attributes.Add("runat", "server")
        Me.Form.Controls.Add(rangeValidator)
    End Sub

    'This subroutine is used to get the most recent added user id from User_Login_Credentials table from database
    Public Function GetCurrentUserID() As Integer
        Dim getUserIDSQL As String
        Dim CurrentUserID As Integer
        getUserIDSQL = "SELECT Top 1  UserID from User_Login_Credentials  order by UserID DESC"

        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(getUserIDSQL, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dsQuizDB As New DataSet()
        ' Try to open database and read information.
        Try
            con.Open()
            adapter.Fill(dsQuizDB, "USERID_T")

            CurrentUserID = dsQuizDB.Tables("USERID_T").Rows.Item(0).Field(Of Integer)("UserID")

        Catch err As Exception
            showErrorMessages.Text = "The access Code you entered is invalid!"
            showErrorMessages.Text &= err.Message
            Return -1
        Finally
            con.Close()
        End Try

        If CurrentUserID Then
            Return CurrentUserID
        Else
            Return -1
        End If

    End Function


    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click


        Dim UserRole As String = "NULL"
        If radiobtnAdmin.Checked Then
            UserRole = radiobtnAdmin.Text
        ElseIf radiobtnInstructor.Checked Then
            UserRole = radiobtnInstructor.Text
        ElseIf radiobtnStudent.Checked Then
            UserRole = radiobtnStudent.Text
        End If

        InsertUser(txtboxFullName.Text, txtboxAddress.Text, txtboxEmail.Text, txtboxPassword1.Text, txtboxPhoneNumber.Text, UserRole)

        If UserRole = "Student" Then

            insertStudent(GetCurrentUserID(), Integer.Parse(txtboxSemesterNumber.Text), txtboxDepartmentName.Text)

        ElseIf UserRole = "Admin" Then

            insertAdmin(GetCurrentUserID())


        ElseIf UserRole = "Examiner" Then

            insertExaminer(GetCurrentUserID(), txtBoxGradeScale.Text, txtboxDepartmentName.Text)

        End If
    End Sub

    'This subroutine is responsible for adding the user data into the User_Login_Credentials table which is the parent table
    'to Student, admin, and examiner table. This data would be filled first before other tables
    Private Sub InsertUser(FullName As String, Address As String, Email As String, Password As String,
                           PhoneNumber As String, UserRole As String)
        Dim insertSQL As String
        insertSQL = "INSERT INTO User_Login_Credentials ("
        insertSQL &= "FullName, Address, "
        insertSQL &= "Email, UserPassword, PhoneNumber, UserRole) "
        insertSQL &= "VALUES ("
        insertSQL &= "@FullName, @Address, @Email,"
        insertSQL &= "@Password ,"
        insertSQL &= "@PhoneNumber, @UserRole"
        insertSQL &= ")"



        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(insertSQL, con)

        'Add the parameters 
        cmd.Parameters.AddWithValue("@FullName", FullName)
        cmd.Parameters.AddWithValue("@Address", Address)
        cmd.Parameters.AddWithValue("@Email", Email)
        cmd.Parameters.AddWithValue("@Password", Password)
        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber)
        cmd.Parameters.AddWithValue("@UserRole", UserRole)
        ' Try to open the database and execute the update.

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            showErrorMessages.Text = "<b>You Account is Successfully Created!</b>"

        Catch err As Exception
            showErrorMessages.Text = "<b>The Email you Entered is already Registered!</b> "
        Finally
            con.Close()
        End Try

    End Sub


    'This subroutine is use to insert the data into student table which has foreign key relation with user_credentials table

    Private Sub insertStudent(UserID As Integer, Semester As Integer, Department As String)
        Dim insertSQL As String
        insertSQL = "INSERT INTO Student_Table ("
        insertSQL &= "UserID, Semester, "
        insertSQL &= "Department) "
        insertSQL &= "VALUES ("
        insertSQL &= "@UserID, @Semester, @Department )"



        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(insertSQL, con)

        'Add the parameters 
        cmd.Parameters.AddWithValue("@UserID", UserID)
        cmd.Parameters.AddWithValue("@Semester", Semester)
        cmd.Parameters.AddWithValue("@Department", Department)


        ' Try to open the database and execute the update.

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            showErrorMessages.Text = "<b>You Account is Successfully Created!</b>"

        Catch err As Exception
            showErrorMessages.Text = "<b>The Email you Entered is already Registered!</b> "
            showErrorMessages.Text &= err.Message
        Finally
            con.Close()
        End Try

    End Sub


    'This subroutine is use to insert the data into Admin_Table which has foreign key relation with user_credentials table

    Private Sub insertAdmin(UserID As Integer)
        Dim insertSQL As String
        insertSQL = "INSERT INTO Admin_Table ("
        insertSQL &= "UserID ) "
        insertSQL &= "VALUES ("
        insertSQL &= "@UserID )"



        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(insertSQL, con)

        'Add the parameters 
        cmd.Parameters.AddWithValue("@UserID", UserID)

        ' Try to open the database and execute the update.

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            showErrorMessages.Text = "<b>You Account is Successfully Created!</b>"

        Catch err As Exception
            showErrorMessages.Text = "<b>The Email you Entered is already Registered!</b> "
        Finally
            con.Close()
        End Try

    End Sub

    'This subroutine is use to insert the data into Examiner_Table table which has foreign key relation with user_credentials table
    Private Sub insertExaminer(UserId As Integer, GradeScale As String, Deparment As String)
        Dim insertSQL As String
        insertSQL = "INSERT INTO Examiner_Table ("
        insertSQL &= "UserID, GradeScale, "
        insertSQL &= "Department) "
        insertSQL &= "VALUES ("
        insertSQL &= "@UserID, @GradeScale, @Department )"



        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(insertSQL, con)

        'Add the parameters 
        cmd.Parameters.AddWithValue("@UserID", UserId)
        cmd.Parameters.AddWithValue("@GradeScale", GradeScale)
        cmd.Parameters.AddWithValue("@Department", Deparment)

        ' Try to open the database and execute the update.

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            showErrorMessages.Text = "<b>You Account is Successfully Created!</b>"

        Catch err As Exception
            showErrorMessages.Text = "<b>The Email you Entered is already Registered!</b> "
            showErrorMessages.Text = err.Message
        Finally
            con.Close()
        End Try

    End Sub
End Class