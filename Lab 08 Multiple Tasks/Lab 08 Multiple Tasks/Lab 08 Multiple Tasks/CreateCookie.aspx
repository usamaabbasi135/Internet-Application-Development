<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreateCookie.aspx.vb" Inherits="Lab_08_Multiple_Tasks.CreateCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Height="93px" Width="323px"></asp:TextBox>
        </div>
        <p>Please Enter your name:</p>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Create Record" />
    </form>
</body>
</html>
