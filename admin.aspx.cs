using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    Model model;

    protected void Page_Load(object sender, EventArgs e)
    {
        /* 
         @author Adrian Roy A Baguio
         @date 08/04/2014
         @description hide both divs when page loads.
         */
        HttpCookie objCookie = Request.Cookies["userInformation"];
        lblHi.Text = objCookie.Values["name"].ToString();
        lblLastLoginTime.Text = objCookie.Values["TimeLoggin"].ToString();
        addMovies.Visible = false;
        addPeople.Visible = false;

    }

    protected void drpDwnListOption_SelectedIndexChanged(object sender, EventArgs e)
    {
         switch (drpDwnListOption.SelectedValue)
        {
            case "addUsers":
            addMovies.Visible = false;
            addPeople.Visible = true;
                break;
            case "addMovies":
            addMovies.Visible = true;
            addPeople.Visible = false;
                break;
            default:
                break;
        }
    }

    protected void btnAddMovie_Click(object sender, EventArgs e)
    {
        model = new Model();

        bool addMovieSuccess = model.addMovie(txtTitle.Text, txtCompany.Text, txtDirector.Text, txtEditor.Text);

        if (addMovieSuccess)
        {
            lblStatus.Text = "Movie Addition Successful!";
            clearMovieFields();
        }
        else
        {
            lblStatus.Text = "Movie Addition Failed! Contact admin for details!";
        }
        addMovies.Visible = true;

    }

    private void clearMovieFields()
    {
        txtTitle.Text = "";
        txtCompany.Text = "";
        txtDirector.Text = "";
        txtEditor.Text = "";
    }

    protected void btnIndex_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
}