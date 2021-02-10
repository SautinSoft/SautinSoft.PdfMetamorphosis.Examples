<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This is a very simple ASPX page.<br />
        <br />
        Choose PDF files to merge:<br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <asp:FileUpload ID="FileUpload2" runat="server" /><br />
        <asp:FileUpload ID="FileUpload3" runat="server" /><br />
        <br />
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create and show single PDF" />
        <br />
        <br />
        <asp:Label ID="Result" runat="server"></asp:Label></div>
    </form>
</body>
</html>
