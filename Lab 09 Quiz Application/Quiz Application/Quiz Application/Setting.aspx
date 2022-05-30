<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Setting.aspx.vb" Inherits="Quiz_Application.Setting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtbox_startingTime.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> Quiz Setting</h1>
            <span>Number of Question:</span>
            <asp:TextBox ID="txtboxNumberOfQuestion" runat="server" TextMode="Number"></asp:TextBox>
            <br /><br/>
            <span>Shuffling Questions: </span>
            <asp:RadioButton ID="radiobtn_isQuestionShuffleTrue" Text="Yes" Checked="true" GroupName="IsQuestionShuffleOptions" runat="server"/>
            <asp:RadioButton ID="radiobtn_isQuestionShuffleFalse" Text="No" GroupName="IsQuestionShuffleOptions" runat="server"/>
            <br /><br/>
            <span>Shuffling Answers</span>
            <asp:RadioButton ID="radiobtn_isAnswerShuffleTrue" Text="Yes" Checked="true" GroupName="IsAnswerShuffleOptions" runat="server"/>
            <asp:RadioButton ID="radiobtn_isAnswerShuffleFalse" Text="No" GroupName="IsAnswerShuffleOptions" runat="server"/>
            <br /><br/>
            <span>starting time</span>
            <asp:TextBox ID="txtbox_startingTime" runat="server" TextMode="DateTime"></asp:TextBox> <img src="calender.png" />
        
            
            
            <br/><br/>
            <span>Quiz Duration(in minutes): </span>
            <asp:TextBox ID="txtbox_QuizDuration" runat="server" TextMode="Number" ></asp:TextBox>
            <br/> <br/>
            <span>Number of Question to be shown: </span>
            <asp:TextBox ID="txtbox_NoOfQuestionToBeShown" runat="server" TextMode="Number" ></asp:TextBox>
            <br/> <br/>
            <span>Negative Markings: </span>
             <asp:RadioButton ID="radiobtn_isNegativeMarkingTrue" Text="Yes" GroupName="IsNegativeMarkingOptions" runat="server"/>
            <asp:RadioButton ID="radiobtn_isNegativeMarkingFalse" Text="No"  Checked="true" GroupName="IsNegativeMarkingOptions" runat="server"/>
            <br /> <br />
            <asp:Button id="cmd_SaveSetting" Text="SaveSettings" runat="server"/>
            <asp:ValidationSummary ID="ValidationSummary1"  runat="server" Style="color:red;text-align:left;" />
            <asp:Label ID="lbl_showErrorMessages" runat="server"></asp:Label>
        </div>
       
    </form>
</body>
</html>
