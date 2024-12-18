<%@ Page Language="VB" CodeFile="Default.aspx.vb" Inherits="_Default" %>

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
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Convert this page to PDF" />
        <br />
        <br />
        Table:<br />
        <table width="200" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td style="background-color: #00CC00">a</td>
            <td style="border: solid 2px red">b</td>
          </tr>
          <tr>
            <td style="border: solid 2px red">c</td>
            <td style="background-color: #00CC00">d</td>
          </tr>
        </table>
        <p><br />
            Image 1:<br />
        <img src="logo_green.jpg" alt="" /></p>        
            
        <p>Bullets:</p>
        <ul>
          <li>Line 1
		  <ul>
        <li>Line 1.1</li>
		</ul>
          </li>
          <li>Line 2 </li>
        </ul>
        <asp:Label ID="Result" runat="server"></asp:Label></div>
    </form>
</body>
</html>
