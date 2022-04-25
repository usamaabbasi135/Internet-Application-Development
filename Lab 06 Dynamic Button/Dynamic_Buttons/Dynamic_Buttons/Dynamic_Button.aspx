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
                
            <%--<asp:TableRow ID = "row" runat="server">
             <asp:TableCell ID = "cell" runat="server">
                 <asp:TextBox runat="server"></asp:TextBox>
             </asp:TableCell>
             <asp:TableCell ID = "TableCell1" runat="server">
                 <asp:Button runat="server" text ="button1"/>
             </asp:TableCell>
             <asp:TableCell ID = "TableCell2" runat="server">
                 <asp:Button runat="server" text ="button1"/>
             </asp:TableCell>
             </asp:TableRow>--%> 
        </asp:Table>
            
        </div>
    </form>
</body>
</html>
