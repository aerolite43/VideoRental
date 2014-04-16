<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <title></title>
</head>
<body>
        
        <!-- Header -->
<div id="top-nav" class="navbar navbar-inverse navbar-static-top">
  <div class="container">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
          <span class="icon-toggle"></span>
      </button>
      <a class="navbar-brand" href="#">Order Confirmation</a>
    </div>
    <div class="navbar-collapse collapse">
      <ul class="nav navbar-nav navbar-right">
        
        <li class="dropdown">
          <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
            <i class="glyphicon glyphicon-user"></i> Admin <span class="caret"></span></a>
          <ul id="g-account-menu" class="dropdown-menu" role="menu">
            <li><a href="#">My Profile</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-lock"></i> Logout</a></li>
          </ul>
        </li>
      </ul>
    </div>
  </div><!-- /container -->
</div>
<!-- /Header -->

<!-- Main -->
<div class="container">
  
  <!-- upper section -->
  <div class="row">
	<div class="col-md-3">
      <!-- left -->
      <a href="#"><strong><i class="glyphicon glyphicon-briefcase"></i> Toolbox</strong></a>
      <hr>
      
      <ul class="nav nav-pills nav-stacked">
        <li><a href="#"><i class="glyphicon glyphicon-flash"></i> Home</a></li>
        <li><a href="#"><i class="glyphicon glyphicon-plus"></i> Add More Orders</a></li>
      </ul>
      
      <hr>
      
  	</div><!-- /span-3 -->
    <div class="col-md-9">
      	
      <!-- column 2 -->	
      
     
       <a href="#"><strong><i class="glyphicon glyphicon-dashboard"></i> My Orders</strong></a>  
            
       <hr>
       <form runat="server">
	   <div class="row">
             <table class="table table-striped">
        <thead>
          <tr><th>Order#</th><th>Title</th><th>Price</th><th></th></tr>
        </thead>
        <tbody runat="server" id="tableOrder">
          <tr><td>45</td><td>2.45%</td><td>$100</td><td><span class="glyphicon glyphicon-remove"></span></td></tr>
          <tr><td>289</td><td>56.2%</td><td>$100</td><td><span class="glyphicon glyphicon-remove"></span></td></tr>
          <tr><td>98</td><td>25%</td><td>$100</td><td><span class="glyphicon glyphicon-remove"></span></td></tr>
          <tr><td>109</td><td>8%</td><td>$100</td><td><span class="glyphicon glyphicon-remove"></span></td></tr>
          <tr><td>34</td><td>14%</td><td>$100</td><td><span class="glyphicon glyphicon-remove"></span></td></tr>
          <tr><td></td><td></td><td></td><td>Total: $500 <asp:Button ID="Button1" runat="server" Text="Confirmed" />
         </td></tr>
        </tbody>
      </table>
      <p runat="server" id="cookiesText"></p>
     
       </div><!--/row-->
       </form>
  	</div><!--/col-span-9-->
    
  </div><!--/row-->
  <!-- /upper section -->
  
  
</div><!--/container-->
<!-- /Main -->

  
        
        <script type='text/javascript' src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>


        <script type='text/javascript' src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>





        
        <!-- JavaScript jQuery code from Bootply.com editor -->
        
        <script type='text/javascript'>

            $(document).ready(function () {



            });
        
        </script>
</body>
</html>
