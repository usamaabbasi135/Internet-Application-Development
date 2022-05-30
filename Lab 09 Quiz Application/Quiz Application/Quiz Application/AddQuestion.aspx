<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddQuestion.aspx.vb" Inherits="Quiz_Application.AddQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label id="QuestionsInfo" runat="server" align="center"></asp:Label>
           <h2>Insert a Question</h2>

            <br />
            <span>Confirm Question Type:</span>
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnDesc" Text="Descriptive" Checked="true" AutoPostBack="true" GroupName="QuestionType" runat="server" />
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnMCQs" Text="MCQs" AutoPostBack="true"   GroupName="QuestionType" runat="server" />
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnTFs" Text="True/False" AutoPostBack="true"  GroupName="QuestionType" runat="server" />

            <br /> <br />
            <span >Question Statement: </span> &nbsp &nbsp 
            <asp:TextBox ID="TxtboxQuestionStatement"  TextMode="MultiLine" runat="server"> </asp:TextBox>
            <br /> <br />
            <span>Complexity Level</span>
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnEasy" Text="Easy" Checked="true" GroupName="ComplexityLevel" runat="server" />
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnMedium" Text="Medium" GroupName="ComplexityLevel" runat="server" />
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnDifficult" Text="Difficult" GroupName="ComplexityLevel" runat="server" />
            <br /> <br />
            <span>Marks</span>
            <asp:TextBox ID="TxtboxMarks" runat="server" CausesValidation="False" TextMode="SingleLine"></asp:TextBox>

            <br id="SpaceOptionA" visible="false" runat="server"/> 
            <span id="Txtbox_OptionATitle" visible="false" runat="server">Enter Option A</span>
            <asp:TextBox ID="Txtbox_OptionA" visible="false" runat="server"></asp:TextBox>

            <br  id="SpaceOptionB" visible="false" runat="server"/> 
            <span id="Txtbox_OptionBTitle" visible="false" runat="server">Enter Option B</span>
            <asp:TextBox ID="Txtbox_OptionB" visible="false" runat="server"></asp:TextBox>

            <br  id="SpaceOptionC" visible="false" runat="server"/> 
            <span id="Txtbox_OptionCTitle" visible="false" runat="server">Enter Option C</span>
            <asp:TextBox ID="Txtbox_OptionC" visible="false" runat="server"></asp:TextBox>

            <br  id="SpaceOptionD" visible="false" runat="server"/> 
            <span id="Txtbox_OptionDTitle" visible="false" runat="server">Enter Option D</span>
            <asp:TextBox ID="Txtbox_OptionD" visible="false" runat="server"></asp:TextBox>

            <br  id="SpaceCorrectOption" visible="false" runat="server"/> 
            <span id="Txtbox_CorrectOptionTitle" visible="false" runat="server" >Enter the Correct Option</span>
            <asp:TextBox ID="Txtbox_CorrectOption" visible="false" runat="server"></asp:TextBox>
           
            <br id="SpaceTF" visible="false" runat="server" />
            <span  id="TFradiobtn_title" visible="false" runat="server" >Select Correct Option</span>
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="Radiobtn_TF_True" visible="false" Text="True" Checked="true" GroupName="TFOptions" runat="server" />
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="Radiobtn_TF_False" visible="false" Text="False" GroupName="TFOptions" runat="server" />


            <br /> <br />
            <asp:Button ID="BtnInsertQuestion" runat="server" Text="Insert Question"/>
             &nbsp &nbsp
            <asp:Button ID="BtnClear" runat="server" Text="Clear"/>

             <!-- Validation Summary -->
            <asp:ValidationSummary ID="ValidationSummary1"  runat="server" Style="color:red;text-align:left;" />
            <asp:Label id="Lbl_showErrorMessages" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
