<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Page</title>
        <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="css/cover.css" rel="stylesheet">
</head>
<body>
    <div class="site-wrapper">

      <div class="site-wrapper-inner">

        <div class="cover-container">

          <div class="masthead clearfix">
            <div class="inner">
              <h3 class="masthead-brand">Error</h3>
              <ul class="nav masthead-nav">
                <li><a href="index.aspx">Home</a></li>
              </ul>
            </div>
          </div>

          <div class="inner cover">
            <h1 class="cover-heading">Something went wrong Jim!</h1>
            <p class="lead" runat="server" id="errorMessageText">Error message is this this this and that that that</p>
            <p>Please contact the administrator ASAP.</p> <p runat="server" id="timeText">Error happend at exactly: </p>
            <p class="lead">
              <a href="#" class="btn btn-lg btn-default">Get help now.</a>
            </p>
          </div>

          <div class="mastfoot">
            <div class="inner">
              <p>How do you like watching over 200,000 movies for free? | Letmewatchthis.com</p>
            </div>
          </div>

        </div>

      </div>

    </div>
</body>
</html>
