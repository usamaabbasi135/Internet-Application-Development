<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExaminerInterface.aspx.vb" Inherits="Quiz_Application.ExaminerInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 id="Title" style="text-align:center" runat="server">Examiner Portal</h1>
            <br />
            <div id="InstructorProfile" runat="server"></div>
          <div align="center">
           <asp:Button  ID="BtnInsertQuestion" Text="Insert Question" runat="server" />
            <asp:Label ID="ShowErrorMessages" runat="server"></asp:Label>
          </div>
        </div>
    </form>
</body>
</html>
