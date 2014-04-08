<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1><asp:Label ID="Label2" runat="server" Text="Hi Admin!"></asp:Label></h1>
        Options:<asp:DropDownList ID="drpDwnListOption" runat="server" 
            AutoPostBack="True" 
            onselectedindexchanged="drpDwnListOption_SelectedIndexChanged">
        <asp:ListItem Value="addUsers">AddUsers</asp:ListItem>
        <asp:ListItem Value="addMovies">AddMovies</asp:ListItem>
    </asp:DropDownList>
    <div id="addMovies" runat="server">
        <h1>

        </h1>
        <h1>Add Movies</h1>
        <asp:Label ID="lblHello" runat="server"></asp:Label>
    
    </div>
        <div id="addPeople" runat="server">
        <h1>Add Users</h1>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    
    </div>
    <div>

    </div>
    </form>
</body>
</html>
