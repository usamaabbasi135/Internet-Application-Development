<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CrossPagePosting.aspx.vb" Inherits="Lab_08_Multiple_Tasks.CrossPagePosting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cross Page 1</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            First Name:
                       <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                       <br />
            Last Name:
                      <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                      <br />
                      <br />
           <asp:Button runat="server" ID="cmdPost" PostBackUrl="CrossPage2.aspx" Text="Cross-Page Postback" /><br />
        </div>
    </form>
</body>
</html>
