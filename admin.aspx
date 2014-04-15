<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1><asp:Label ID="lblHi" runat="server"></asp:Label></h1>
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
        <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblCompany" runat="server" Text="Company:"></asp:Label>
        <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDirector" runat="server" Text="Director:"></asp:Label>
        <asp:TextBox ID="txtDirector" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblEditor" runat="server" Text="Editor:"></asp:Label>
        <asp:TextBox ID="txtEditor" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAddMovie" runat="server" onclick="btnAddMovie_Click" 
            Text="Add Movie" />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    
    </div>
        <div id="addPeople" runat="server">
        <h1>Add Users</h1>
        <asp:Label ID="Label1" runat="server"> First Name:</asp:Label>
    
            <asp:TextBox ID="txtBoxFirstName" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="txtBoxLastName" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Address 1:"></asp:Label>
            <asp:TextBox ID="txtBoxAddress1" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Address 2:"></asp:Label>
            <asp:TextBox ID="txtBoxAddress2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="City:"></asp:Label>
            <asp:TextBox ID="txtBoxCity" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Province: "></asp:Label>
            <asp:TextBox ID="txtBoxProvince" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Postal Code:"></asp:Label>
            <asp:TextBox ID="txtBoxPostalCode" runat="server"></asp:TextBox>
            <asp:Label ID="Label10" runat="server" Text="Phone:"></asp:Label>
            <asp:TextBox ID="txtBoxPhone" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label12" runat="server" Text="Login:"></asp:Label>
            <asp:TextBox ID="txtBoxLogin" runat="server"></asp:TextBox>
            <asp:Label ID="Label13" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtBoxPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAdminStatus" runat="server" Text="Admin Account?"></asp:Label>
            <asp:DropDownList ID="drpDwnListIsAdmin" runat="server">
                <asp:ListItem Value="true">Yes</asp:ListItem>
                <asp:ListItem Value="false">No</asp:ListItem>
            </asp:DropDownList>
    
            <br />
            <br />
        <asp:Button ID="btnAddUser" runat="server" onclick="btnAddUser_Click" 
            Text="Add User" />
            <br />
        <asp:Label ID="lblStatus2" runat="server"></asp:Label>
    
    </div>
    <div>



    </div>
        <asp:Label ID="lblLastLoginTime" runat="server"></asp:Label>
        <br />
        <p>
            <asp:Button ID="btnIndex" runat="server" onclick="btnIndex_Click" 
                Text="Back to Index" />
        </p>
       <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    </form>
       </body>
</html>
