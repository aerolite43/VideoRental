<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: Arial;
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        <strong>Register Credentials<br />
        </strong>
&nbsp;&nbsp;
        <div style="height: 345px; width: 257px; font-size: small">
            <asp:Label ID="lblFirst" runat="server" Text="First Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFirst" runat="server" Width="116px"></asp:TextBox>
            <br />
            <asp:Label ID="lblLast" runat="server" Text="Last Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtLast" runat="server" Width="116px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAddr1" runat="server" Text="Address Line 1:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddr1" runat="server" Width="206px"></asp:TextBox>
            <br />
            <asp:Label ID="lblAddr2" runat="server" Text="Address Line 2:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddr2" runat="server" Width="206px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCity" runat="server" Width="161px"></asp:TextBox>
            <br />
            <asp:Label ID="lblProv" runat="server" Text="Province:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProv" runat="server" Width="128px"></asp:TextBox>
            <br />
            <asp:Label ID="lblPostal" runat="server" Text="Postal Code:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPostal" runat="server" Width="108px"></asp:TextBox>
            <br />
            <asp:Label ID="lblPhone" runat="server" Text="Phone Number:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPhone" runat="server" Width="89px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" 
                onclick="btnRegister_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="Back" />
            <br />
            <br />
            <asp:Label ID="lblRegStatus" runat="server"></asp:Label>
        </div>
        <br />
    
    </div>
    </form>
</body>
</html>
