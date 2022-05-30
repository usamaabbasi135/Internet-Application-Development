Imports System.Web.UI.Control
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class AddQuestion
    Inherits System.Web.UI.Page
    'Dim connectionString = "Data Source=localhost;Initial Catalog=Quiz_Application_Database;Integrated Security=SSPI"
    Public connectionString As String = WebConfigurationManager.ConnectionStrings("Quiz_Application_Database").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("UserRole") <> "Examiner" Then
                Response.Redirect("AccessDenied.aspx")
            End If
        End If


        InsertValidator("*Question Statement", "Question Statement is mandatory", "txtboxQuestionStatement")
        InsertValidator("*Marks", "Marks is mandatory", "txtboxMarks")
        ShowQuestionsInfo()
    End Sub


    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        Txtbox_OptionA.Text = ""
        Txtbox_OptionB.Text = ""
        Txtbox_OptionC.Text = ""
        Txtbox_OptionD.Text = ""
        Txtbox_CorrectOption.Text = ""
        TxtboxMarks.Text = ""
        TxtboxQuestionStatement.Text = ""
        TxtboxMarks.Text = ""
    End Sub

    Private Sub BtnInsertQuestion_Click(sender As Object, e As EventArgs) Handles BtnInsertQuestion.Click

        Dim QuestionType As String
        Dim TF_isTrue As String
        Dim ComplexityLevel As String

        If RadiobtnDesc.Checked Then
            QuestionType = "DESC"
        ElseIf RadiobtnMCQs.Checked Then
            QuestionType = "MCQ"
        Else
            QuestionType = "TF"
            If Radiobtn_TF_True.Checked Then
                TF_isTrue = "True"
            Else
                TF_isTrue = "False"
            End If
        End If

        If radiobtnEasy.Checked Then
            ComplexityLevel = radiobtnEasy.Text

        ElseIf radiobtnMedium.Checked Then
            ComplexityLevel = radiobtnMedium.Text

        ElseIf radiobtnDifficult.Checked Then
            ComplexityLevel = radiobtnDifficult.Text
        End If

        If Page.IsValid Then
            TxtboxMarks.Controls.Clear()
            TxtboxQuestionStatement.Controls.Clear()
            TxtboxMarks.Controls.Clear()

            If QuestionType = "MCQ" Then
                Txtbox_OptionA.Controls.Clear()
                Txtbox_OptionB.Controls.Clear()
                Txtbox_OptionC.Controls.Clear()
                Txtbox_OptionD.Controls.Clear()
                Txtbox_CorrectOption.Controls.Clear()

            End If

            If (GetTotalNumberOfQuestionsToBeInserted() - GetNumberOfQuestionsInserted()) Then
                If InsertQuestion(TxtboxQuestionStatement.Text, QuestionType, ComplexityLevel, Integer.Parse(TxtboxMarks.Text)) Then
                    If QuestionType = "MCQ" Then
                        InsertMCQsQuestion(GetQuestionNumberID(), Txtbox_OptionA.Text, Txtbox_OptionB.Text,
                                       Txtbox_OptionC.Text, Txtbox_OptionD.Text, Txtbox_CorrectOption.Text)

                    ElseIf QuestionType = "TF" Then
                        InsertTFQuestion(GetQuestionNumberID(), TF_isTrue)

                    End If
                End If
            End If
            ShowQuestionsInfo()
        End If

    End Sub



    Private Sub ShowQuestionsInfo()
        QuestionsInfo.Text = "<b>The Total Question Already Inserted: &nbsp &nbsp </b>"
        QuestionsInfo.Text &= "<b>" & GetNumberOfQuestionsInserted.ToString() & "</b><br/>"
        QuestionsInfo.Text &= "<b>The Total Question To Be Inserted: &nbsp &nbsp </b>"
        QuestionsInfo.Text &= "<b>" & (GetTotalNumberOfQuestionsToBeInserted() - GetNumberOfQuestionsInserted()).ToString() & "</b><br/><br/>"

    End Sub


    Private Sub RadiobtnMCQs_CheckedChanged(sender As Object, e As EventArgs) Handles RadiobtnMCQs.CheckedChanged
        SpaceOptionA.Visible = True
        Txtbox_OptionATitle.Visible = True
        Txtbox_OptionA.Visible = True

        SpaceOptionB.Visible = True
        Txtbox_OptionBTitle.Visible = True
        Txtbox_OptionB.Visible = True

        SpaceOptionC.Visible = True
        Txtbox_OptionCTitle.Visible = True
        Txtbox_OptionC.Visible = True

        SpaceOptionD.Visible = True
        Txtbox_OptionDTitle.Visible = True
        Txtbox_OptionD.Visible = True

        SpaceCorrectOption.Visible = True
        Txtbox_CorrectOptionTitle.Visible = True
        Txtbox_CorrectOption.Visible = True

        SpaceTF.Visible = False
        TFradiobtn_title.Visible = False
        Radiobtn_TF_True.Visible = False
        Radiobtn_TF_False.Visible = False

        InsertValidator("*Option A", "Option A is mandatory", "txtbox_OptionA")
        InsertValidator("*Option B", "Option B is mandatory", "txtbox_OptionB")
        InsertValidator("*Option C", "Option C is mandatory", "txtbox_OptionC")
        InsertValidator("*Option D", "Option D is mandatory", "txtbox_OptionD")
        InsertValidator("*Correct Option", "Correct Option is mandatory", "txtbox_CorrectOption")

    End Sub

    Private Sub RadiobtnTFs_CheckedChanged(sender As Object, e As EventArgs) Handles RadiobtnTFs.CheckedChanged
        SpaceOptionA.Visible = False
        Txtbox_OptionATitle.Visible = False
        Txtbox_OptionA.Visible = False

        SpaceOptionB.Visible = False
        Txtbox_OptionBTitle.Visible = False
        Txtbox_OptionB.Visible = False

        SpaceOptionC.Visible = False
        Txtbox_OptionCTitle.Visible = False
        Txtbox_OptionC.Visible = False

        SpaceOptionD.Visible = False
        Txtbox_OptionDTitle.Visible = False
        Txtbox_OptionD.Visible = False

        SpaceCorrectOption.Visible = False
        Txtbox_CorrectOptionTitle.Visible = False
        Txtbox_CorrectOption.Visible = False

        SpaceTF.Visible = True
        TFradiobtn_title.Visible = True
        Radiobtn_TF_True.Visible = True
        Radiobtn_TF_False.Visible = True

    End Sub

    Private Sub RadiobtnDesc_CheckedChanged(sender As Object, e As EventArgs) Handles RadiobtnDesc.CheckedChanged
        SpaceOptionA.Visible = False
        Txtbox_OptionATitle.Visible = False
        Txtbox_OptionA.Visible = False

        SpaceOptionB.Visible = False
        Txtbox_OptionBTitle.Visible = False
        Txtbox_OptionB.Visible = False

        SpaceOptionC.Visible = False
        Txtbox_OptionCTitle.Visible = False
        Txtbox_OptionC.Visible = False

        SpaceOptionD.Visible = False
        Txtbox_OptionDTitle.Visible = False
        Txtbox_OptionD.Visible = False

        SpaceCorrectOption.Visible = False
        Txtbox_CorrectOptionTitle.Visible = False
        Txtbox_CorrectOption.Visible = False

        SpaceTF.Visible = False
        TFradiobtn_title.Visible = False
        Radiobtn_TF_True.Visible = False
        Radiobtn_TF_False.Visible = False


    End Sub

    Private Sub InsertValidator(validationText As String, ErrorMessage As String, txtboxID As String)
        Dim rqfValidator As New RequiredFieldValidator With {
            .Display = ValidatorDisplay.Dynamic,
            .Text = validationText
        }
        rqfValidator.Attributes.Add("runat", "server")
        rqfValidator.ErrorMessage = ErrorMessage
        rqfValidator.Display = ValidatorDisplay.None
        rqfValidator.ControlToValidate = txtboxID
        Me.Form.Controls.Add(rqfValidator)
    End Sub



    'function for Returning the Total number of questions to be inserted 
    Private Function GetTotalNumberOfQuestionsToBeInserted() As Integer
        Dim SQLStatement As String
        Dim NumberOfQuestionsToBeInserted As Integer
        SQLStatement = "SELECT NoOfQuestions  As NoOfQuestions from QuizSetting_Table"


        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(SQLStatement, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dsQuizDB As New DataSet()
        ' Try to open database and read information.
        Try
            con.Open()
            adapter.Fill(dsQuizDB, "QuizSetting")

            NumberOfQuestionsToBeInserted = dsQuizDB.Tables("QuizSetting").Rows.Item(0).Field(Of Integer)("NoOfQuestions")

        Catch err As Exception
            Lbl_showErrorMessages.Text = err.Message
            Return -1
        Finally
            con.Close()
        End Try

        Return NumberOfQuestionsToBeInserted

    End Function




    'function for Returning the Total number of questions to be inserted 
    Private Function GetNumberOfQuestionsInserted() As Integer
        Dim SQLStatement As String
        Dim NumberOfQuestionsInserted As Integer
        SQLStatement = "SELECT Count(*) as NoOfQuestionsAlreadyInserted from Question_Table"


        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(SQLStatement, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dsQuizDB As New DataSet()
        ' Try to open database and read information.
        Try
            con.Open()
            adapter.Fill(dsQuizDB, "QuizSetting")

            NumberOfQuestionsInserted = dsQuizDB.Tables("QuizSetting").Rows.Item(0).Field(Of Integer)("NoOfQuestionsAlreadyInserted")

        Catch err As Exception
            Lbl_showErrorMessages.Text = err.Message
            Return -1
        Finally
            con.Close()
        End Try

        Return NumberOfQuestionsInserted

    End Function


    Private Function InsertQuestion(QuestionStatement As String, QuestionType As String, ComplexityLevel As String,
                               Marks As Integer) As Boolean

        Dim insertSQL As String
        insertSQL = "Insert into Question_Table(QuestionStatement, QuestionType, ComplexityLevel, Marks) "
        insertSQL &= "VALUES ("
        insertSQL &= "@QuestionStatement, @QuestionType, @ComplexityLevel,"
        insertSQL &= "@Marks"
        insertSQL &= ")"


        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(insertSQL, con)

        'Add the parameters 
        cmd.Parameters.AddWithValue("@QuestionStatement", QuestionStatement)
        cmd.Parameters.AddWithValue("@QuestionType", QuestionType)
        cmd.Parameters.AddWithValue("@ComplexityLevel", ComplexityLevel)
        cmd.Parameters.AddWithValue("@Marks", Marks)
        ' Try to open the database and execute the update.

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Lbl_showErrorMessages.Text = "<b>Question is Successfully Inserted</b>"

            Return True

        Catch err As Exception
            Lbl_showErrorMessages.Text = "<b>The Quiz Setting cannot be inserting at the time!</b> "
            Lbl_showErrorMessages.Text &= err.Message
            Return False
        Finally
            con.Close()
        End Try

    End Function

    Private Sub InsertMCQsQuestion(QuestionNumber As Integer, OptionA As String, OptionB As String,
                                   OptionC As String, OptionD As String, CorrectOption As String)



        Dim insertSQL As String
        insertSQL = "Insert into MCQS_Question_Table(QuestionNumber, OptionA, OptionB, OptionC, OptionD, CorrectOption) "
        insertSQL &= "VALUES ("
        insertSQL &= "@QuestionNumber, @OptionA, @OptionB,"
        insertSQL &= "@OptionC , @OptionD , @CorrectOption"
        insertSQL &= ")"


        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(insertSQL, con)

        'Add the parameters 
        cmd.Parameters.AddWithValue("@QuestionNumber", QuestionNumber)
        cmd.Parameters.AddWithValue("@OptionA", OptionA)
        cmd.Parameters.AddWithValue("@OptionB", OptionB)
        cmd.Parameters.AddWithValue("@OptionC", OptionC)
        cmd.Parameters.AddWithValue("@OptionD", OptionD)
        cmd.Parameters.AddWithValue("@CorrectOption", CorrectOption)
        ' Try to open the database and execute the update.

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Lbl_showErrorMessages.Text = "<b>MCQs Question Successfully Inserted</b>"


        Catch err As Exception
            ' lbl_showErrorMessages.Text = "<b>The Quiz Setting cannot be inserting at the time!</b> "
            Lbl_showErrorMessages.Text &= err.Message
        Finally
            con.Close()
        End Try


    End Sub

    Private Sub InsertTFQuestion(QuestionNumber As Integer, CorrectOption As String)

        ' insert into TF_Question(QuestionNumber, CorrectOption)
        'Values(1, 'True')

        Dim insertSQL As String
        insertSQL = "insert into True_False_Question_Table(QuestionNumber, CorrectOption)"
        insertSQL &= "VALUES ("
        insertSQL &= "@QuestionNumber, @CorrectOption"
        insertSQL &= ")"


        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(insertSQL, con)

        'Add the parameters 
        cmd.Parameters.AddWithValue("@QuestionNumber", QuestionNumber)
        cmd.Parameters.AddWithValue("@CorrectOption", CorrectOption)
        ' Try to open the database and execute the update.

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Lbl_showErrorMessages.Text = "<b>TF Question Successfully Inserted</b>"


        Catch err As Exception
            ' lbl_showErrorMessages.Text = "<b>The Quiz Setting cannot be inserting at the time!</b> "
            Lbl_showErrorMessages.Text &= err.Message
        Finally
            con.Close()
        End Try

    End Sub


    'function for Returning the Total number of questions to be inserted 
    Private Function GetQuestionNumberID() As Integer
        Dim SQLStatement As String
        Dim QuestionNumberID As Integer
        SQLStatement = "SELECT TOP 1 QuestionNumber FROM Question_Table order by QuestionNumber Desc "


        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(SQLStatement, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dsQuizDB As New DataSet()
        ' Try to open database and read information.
        Try
            con.Open()
            adapter.Fill(dsQuizDB, "QuestionID")

            QuestionNumberID = dsQuizDB.Tables("QuestionID").Rows.Item(0).Field(Of Integer)("QuestionNumber")

        Catch err As Exception
            Lbl_showErrorMessages.Text = err.Message
            Return -1
        Finally
            con.Close()
        End Try

        Return QuestionNumberID

    End Function


End Class