<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Coordinate_Finder_Shape.aspx.vb" Inherits="Coordinate_Finder_Shape.Coordinate_Finder_Shape" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>Click on the Image </h1>
      <input type="image"
             src="button.png" 
             ID="ImgButton"
             runat="server" />
      <br />
      <p ID="Result" runat="server"/>
    </div>
    </form>
</body>
</html>
