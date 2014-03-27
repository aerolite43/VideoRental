using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.Linq;


public partial class index : System.Web.UI.Page
{
    Model model;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //lblTest.Text = "Movie title<br>Movie company<br>Summary";
            model = new Model();
            setMovieTitle();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        /*
        string conString = WebConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        DataContext db = new DataContext(conString);
        var tMovie = db.GetTable<Allmovies>();

        grdView.DataSource = tMovie.Where(m => m.Director.Contains(txtDirector.Text));
        grdView.DataBind();
         */

        model = new Model();

        bool isLoggin = model.login(txtBoxUsername.Text, txtBoxPassword.Text);
        if (isLoggin)
            lblResult.Text = "Password accepted.";
        else
            lblResult.Text = "Incorrect credential.";
    }

    public void sql()
    {
        string conString = WebConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        DataContext db = new DataContext(conString);
        var tMovie = db.GetTable<allmovies>();

        //var query = tMovie.Where(m => m.Id.Contains("woody"));
        var query = tMovie.Where(m => m.Id.Equals(1));

        foreach (var cust in query)
            lblResult.Text = cust.Company;
        //Console.WriteLine("id = {0}, City = {1}", cust.CustomerID, cust.City);



        //grdView.DataSource = tMovie.Where(m => m.Director.Contains("woody"));
        grdView.DataBind();

    }

    public void setMovieTitle()
    {
        var list = model.getMovie();
        

        lblMovieTitle1.Text = list[0].Company;
        lblMovieSummary1.Text = list[0].Director;
        lblMovieCompany1.Text = list[0].Editor;

    }
}