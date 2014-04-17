<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <title></title>
</head>
<body style="width:1000px; top: -1px; left: 17px;">
    <form id="form1" runat="server">
    <div id="leftDiv">
        <div style="padding-left:25px;">
            <asp:Button ID="Button1" runat="server" Text="Specials" Font-Size="Smaller" />    
            &nbsp;<asp:Button ID="Button2" runat="server" Text="Classics" 
                Font-Size="Smaller" style="height: 21px" />
            &nbsp;<asp:Button ID="Button3" runat="server" Text="Oscars" 
                Font-Size="Smaller" />
        </div>
    

        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/banner.jpg" />
        <br />

        <asp:Image ID="ImageA" runat="server" ImageUrl="~/images/OrderThisNow.jpg" />
        <br />


        <div class="movieInfo" style="margin-left:20px; width: 241px;">
        <asp:Label ID="lblMovieTitle1" runat="server" Text="Movie title"></asp:Label>
        <br />
        <asp:Label ID="lblMovieCompany1" runat="server" Text="Movie company"></asp:Label>
        <br />
        <asp:Label ID="lblMovieSummary1" runat="server" Text="Movie summary"></asp:Label>
	<br />
            <asp:Label ID="downloadLabel" runat="server" Text="Download Now"></asp:Label>
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/line.jpg" />
        </div>
                <div class="movieInfo" style="margin-left:20px; width: 240px;">
        <asp:Label ID="lblMovieTitle2" runat="server" Text="Movie title"></asp:Label>
        <br />
        <asp:Label ID="lblMovieCompany2" runat="server" Text="Movie company"></asp:Label>
        <br />
        <asp:Label ID="lblMovieSummary2" runat="server" Text="Movie summary"></asp:Label>
                    <br />
                    <asp:Label ID="downloadLabel2" runat="server" Text="Download Now"></asp:Label>
        <br />
        <br />
        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/line.jpg" />
        </div>

                <div class="movieInfo" style="margin-left:20px; width: 241px;">
        <asp:Label ID="lblMovieTitle3" runat="server" Text="Movie title"></asp:Label>
        <br />
        <asp:Label ID="lblMovieCompany3" runat="server" Text="Movie company"></asp:Label>
        <br />
        <asp:Label ID="lblMovieSummary3" runat="server" Text="Movie summary"></asp:Label>
                    <br />
                    <asp:Label ID="downloadLabel3" runat="server" Text="Download Now"></asp:Label>
        <br />
        <br />
        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/line.jpg" />
        </div>
    

        
    </div>
    <div id="centerDiv">
            <div style="margin-top:20px">
            <asp:TextBox ID="txtBoxSearch" runat="server" 
                    ontextchanged="txtBoxSearch_TextChanged1" AutoPostBack="True" 
                    style="height: 25px"></asp:TextBox>
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="director">Director</asp:ListItem>
                <asp:ListItem Value="actor">Actor</asp:ListItem>
                <asp:ListItem Value="character">Character</asp:ListItem>
                <asp:ListItem Value="title">Title</asp:ListItem>
                <asp:ListItem Value="keyword">Keyword</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                    Text="Search" />
                <br />
                <br />

            </div>
                        <div runat="server" id="topTenandNewReleases">
                    <asp:Image ID="ImageB" runat="server" style="margin-top:5x;" ImageUrl="~/images/comedy.jpg" />
                    <br />
                        

        
        <asp:Image ID="ImageC" runat="server" ImageUrl="~/images/rentals.jpg" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="ImageD" runat="server" ImageUrl="~/images/releases.jpg" />
       
    
            <br />

            <div style="position:relative; top: -2px; left: -15px;">
            <div style="width:228px; position:absolute;">
            
            <asp:Label ID="lblTop10" runat="server" Text="Top10"></asp:Label> 
                
            </div>

            <div style="width:228px; float:right;">
       &nbsp;<asp:Label 
                    ID="Label4" runat="server" Font-Bold="True" Font-Underline="True" 
                    Text="New Release One"></asp:Label>
                <br />
                <br />
       <asp:Label ID="lblNew1" runat="server" Text="New1" Font-Italic="True"></asp:Label>
                <br />
                <br />
&nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" 
                    Text="New Release Two"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblNew2" runat="server" Font-Italic="True" Text="New2"></asp:Label>
       </div>
       </div>
       </div>
       <div id="searchResultDiv" runat="server" visible="false">
       </div>
       

    
    </div>
        <div id="rightDiv" runat="server">
            <div id="login" runat="server">
            &nbsp;<br />
            <asp:Label ID="signInlbl" runat="server" Text="Sign in"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
                :
            <asp:TextBox ID="txtBoxUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                :&nbsp;<asp:TextBox ID="txtBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" />
                &nbsp;
                <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                    Text="Register" />
                <br />
                <asp:Label ID="lblResult" runat="server"></asp:Label>
                <br />

                <asp:Label ID="lblPromo" runat="server" BorderStyle="Dotted" 
                    style="margin-left: 54px" Text="Promo Film" Width="95px"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblPromo1" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="lblPromo2" runat="server" Text="Label"></asp:Label>

            </div>
            <div id="LogoutbuttonDiv" runat="server">
            <h1 runat="server" visible="false" id="greetingsText">Hi</h1>
                <asp:Button ID="btnLogout" runat="server" Text="Log Out" 
                    onclick="btnLogout_Click" />
            &nbsp;<asp:Button ID="btnCheckout" runat="server" onclick="btnCheckout_Click" 
                    Text="Checkout" />
                <br />
                
                <br />
            </div>
    </div>





    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DatabaseConnection2 %>" 
        SelectCommand="SELECT * FROM [allmovies]"></asp:SqlDataSource>
    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False">
    </asp:GridView>



    </form>
</body>
</html>
