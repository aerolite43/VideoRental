using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblTest.Text = "Movie title<br>Movie company<br>Summary";
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtBoxUsername.Text == "username" && txtBoxPassword.Text == "Newpassword")
            lblResult.Text = "Password accepted.";
        else
            lblResult.Text = "Incorrect credential.";
    }
}