<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DefaultPage.aspx.vb" Inherits="Quiz_Application.DefaultPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Log into Account</h1>
            <br /> <br />
             <span >Email: </span>
            <asp:TextBox ID="TxtboxEmail"  runat="server" TextMode="Email"></asp:TextBox>
             <br /> <br />
             <span >Password</span> 
             <asp:TextBox ID="TxtboxPassword"  runat="server" TextMode="Password"></asp:TextBox>
            <br /> <br />
            <span>Select Role:</span>
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnAdmin" Text="Admin" GroupName="UserRole" runat="server" Checked="True" />
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnExaminer" Text="Examiner" GroupName="UserRole" runat="server" />
            &nbsp &nbsp &nbsp
            <asp:RadioButton ID="RadiobtnStudent" Text="Student" GroupName="UserRole" runat="server" />
            <br /> <br />
            <asp:Button ID="LoginBtn"  runat="server" Text="Login"/>
             &nbsp &nbsp
            <asp:Button ID="BtnClear" runat="server" Text="Clear"/>
            <br /> <br /> 
            <asp:Label ID="Lbl_showErrorMessages" runat="server"></asp:Label>
            <div>Create New Account</div>
            <a href="SignUp.aspx"> Sign Up </a> 
        </div>
    </form>
</body>
</html>
