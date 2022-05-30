<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Quiz.aspx.vb" Inherits="Quiz_Application.Quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            background-color: #26FFE6;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif
        }
        h1
        {

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h1 style="text-align:center">Welcome To the Quiz</h1>
            <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <div align="right">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                        <br />
            <div id="Div1" runat="server"></div>
          <div id="ShowQuestions" runat="server" ></div>
            <asp:Button ID="BtnSubmit" runat="server"  Text="Submit" />
            <asp:Button ID="BtnNext" Visible="False" runat="server" Text="Next" />
            <asp:Label ID="Lbl_showErrorMessages" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
