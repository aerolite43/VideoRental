using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.Linq;

public partial class register : System.Web.UI.Page
{

    Model model;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        model = new Model();

        bool registerPass = model.register(txtFirst.Text, txtLast.Text, txtAddr1.Text, txtAddr2.Text,
            txtCity.Text, txtProv.Text, txtPostal.Text, txtPhone.Text);
        if (registerPass)
        {
            lblRegStatus.Text = "Registration Successful! Press back to login.";
            clearFields();
        }
        else
        {
            lblRegStatus.Text = "Registration Failed! Contact admin for details.";
        }
    }

    private void clearFields()
    {
        txtFirst.Text = "";
        txtLast.Text = "";
        txtAddr1.Text = "";
        txtAddr2.Text = "";
        txtCity.Text = "";
        txtProv.Text = "";
        txtPostal.Text = "";
        txtPhone.Text = "";
    }
}