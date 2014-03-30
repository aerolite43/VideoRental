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

    Model model2;

    protected void Page_Load(object sender, EventArgs e)
    {
        model = new Model();

        if (!IsPostBack)
        {
            //lblTest.Text = "Movie title<br>Movie company<br>Summary";
            

            model2 = new Model();

            setMovieTitle();
            setTop10();
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
        var listMovies = model.getMovie();


        lblMovieTitle1.Text = listMovies[0].Company;
        lblMovieSummary1.Text = listMovies[0].Director;
        lblMovieCompany1.Text = listMovies[0].Editor;

        lblMovieTitle2.Text = listMovies[1].Company;
        lblMovieSummary2.Text = listMovies[1].Director;
        lblMovieCompany2.Text = listMovies[1].Editor;

    }

    public void setTop10()
     {

         var listTop = model2.getTop10Rentals();
         string top10 = "";
         int counter = 1;
        foreach(allmovies movie in listTop){
            top10 += counter + ". " + movie.Title + "<br>";
            counter++;
        }
        lblTop10.Text = top10;
         //lblTop10.Text = listTop[0].Company;
      }


    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void txtBoxSearch_TextChanged(object sender, EventArgs e)
    {
    }
    protected void txtBoxSearch_TextChanged1(object sender, EventArgs e)
    {
        List<allmovies> moviesFound = model.search(DropDownList1.SelectedValue, txtBoxSearch.Text);

        if (moviesFound != null)
        {
            if (moviesFound.Count != 0)
            {
                string moviesText = "";
                foreach (allmovies movie in moviesFound)
                {
                    moviesText += movie.Title + "<br/>";
                }
                lblTop10.Text = moviesText;
            }
            else
            {
                lblTop10.Text = "No result..";
            }


        }
        moviesFound = null;
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
}
