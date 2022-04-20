<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Coordinate_Finder_Circle.aspx.vb" Inherits="Coordinate_Finder_Shape.Coordinate_Finder_Circle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="image" id="ImgButton" src="circle.PNG" runat="server" onServerClick="ImgButton_ServerClick"  />
            <p id="Result" runat="server"></p>
            <p id="P1" runat="server"></p>
        </div>
    </form>
</body>
</html>
