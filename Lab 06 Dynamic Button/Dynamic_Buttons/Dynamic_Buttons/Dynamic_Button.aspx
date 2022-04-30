<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dynamic_Button.aspx.vb" Inherits="Dynamic_Buttons.Dynamic_Button" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div> <asp:Button ID="CreateView" Text="Create Button And Text Box" runat="server" /></div>
            <asp:Table ID="tble" runat="server">
            </asp:Table>
       </div>
    </form>
</body>
</html>
