<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QueryString.aspx.vb" Inherits="Lab_08_Multiple_Tasks.QueryString" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ListBox ID="ListBox1" runat="server" Height="241px" Width="233px">
            <asp:ListItem ID="Cust1" Value ="Usama Bin Hafeez Abbasi"></asp:ListItem>
            <asp:ListItem ID="Cust2" Value ="Abdullah Abbasi"></asp:ListItem>
            <asp:ListItem ID="Cust3" Value ="Danish Abbasi"></asp:ListItem>
            <asp:ListItem ID="Cust4" Value ="Kainat Meer Ahmed"></asp:ListItem>
            <asp:ListItem ID="Cust5" Value ="Salman Iqbal"></asp:ListItem>
            <asp:ListItem ID="Cust6" Value ="Murad Saeed"></asp:ListItem>
            <asp:ListItem ID="Cust7" Value ="Imran Khan"></asp:ListItem>
            <asp:ListItem ID="Cust8" Value ="Asad Umer"></asp:ListItem>
            <asp:ListItem ID="Cust9" Value ="Narendar Modi"></asp:ListItem>
            <asp:ListItem ID="Cust10" Value ="Babar Azam"></asp:ListItem>
            <asp:ListItem ID="Cust11" Value ="Virat Kohli"></asp:ListItem>
            <asp:ListItem ID="Cust12" Value ="Shoaib Akhter"></asp:ListItem>
            
        </asp:ListBox>

        <br />
        <br />

        <asp:Button runat="server" Text="Next Page" OnClick="Unnamed1_Click" />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Cricket</asp:ListItem>
            <asp:ListItem>FootBall</asp:ListItem>
            <asp:ListItem>Tennis</asp:ListItem>
            <asp:ListItem>Wrestling</asp:ListItem>
            <asp:ListItem>Cycling</asp:ListItem>
        </asp:RadioButtonList>
    </form>
</body>
</html>
