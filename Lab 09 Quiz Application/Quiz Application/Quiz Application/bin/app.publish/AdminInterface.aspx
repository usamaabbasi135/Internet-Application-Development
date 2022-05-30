<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminInterface.aspx.vb" Inherits="Quiz_Application.AdminInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h1 id="Title" style="text-align:center" runat="server">Admin Portal</h1>
            <br />
            <div id="AdminProfile" runat="server"></div>
          <div align="center">
           <asp:Button  ID="BtnChangeSetting" Text="Change Settings" runat="server" /> <br /> <br />
            <asp:Label ID="ShowErrorMessages" runat="server"></asp:Label>
          </div>
        </div>
    </form>
</body>
</html>
