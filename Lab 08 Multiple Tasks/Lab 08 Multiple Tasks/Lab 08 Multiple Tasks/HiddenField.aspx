<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HiddenField.aspx.vb" Inherits="Lab_08_Multiple_Tasks.HiddenField" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type ="text/javascript">
        function changeHiddenFieldValue()
        {
            console.log("Enter Function")
            var currentValue = document.getElementById("<%=TextBox1.ClientID%>")
            currentValue.value = "12345"
            document.getElementById("<%=HiddenField1.ClientID%>").value = "ABCD"
            
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Show M Value" />
&nbsp;</p>
        <input type="button"  id="Button2" name ="Change M" value ="Change M Value" onclick ="changeHiddenFieldValue()" />
    </form>
</body>
</html>
