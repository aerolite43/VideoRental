using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.Linq;
using model;




public partial class index : System.Web.UI.Page
{
    Model model;

    Model model2;
    HttpCookie objCookie;

    protected void Page_Load(object sender, EventArgs e)
    {
        model = new Model();
	    HttpCookie objCookieUserInfo = Request.Cookies["userInformation"];
        // // // // // // //
        //  Guest View    //
        // // // // // // //
        if (objCookieUserInfo == null)
        {
            login.Visible = true;
            LogoutbuttonDiv.Visible = false;
        }
        // // // // // // //
        // Logged in view //
        // // // // // // //
        else
        {
            greetingsText.InnerText += " " + objCookieUserInfo.Values["name"].ToString() + "!";
            greetingsText.Visible = true;

            login.Visible = false;
            LogoutbuttonDiv.Visible = true;
        }

        if (!IsPostBack)
        {
            //lblTest.Text = "Movie title<br>Movie company<br>Summary";
	    HttpCookie objCookie = Request.Cookies["ERROR"];
            

            model2 = new Model();

            setMovieTitle();
            setTop10();
            setNewRelease1();
            setNewRelease2();
            setPromo();
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["userInformation"] != null)
        {
            HttpCookie myCookie = new HttpCookie("userInformation");
            myCookie.Expires = DateTime.Now.AddDays(-10);
            myCookie.Value = null;
            HttpContext.Current.Response.SetCookie(myCookie);
            Response.Redirect("index.aspx");
            //Response.Cookies.Add(myCookie);

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

        customer customerUserInfo = model.login(txtBoxUsername.Text, txtBoxPassword.Text);
        if (customerUserInfo != null)
        { // Account does exsist
            objCookie = new HttpCookie("accountInformation");
            DateTime now;
            // // // // // // //
            //  Admin account //
            // // // // // // //
            if (customerUserInfo.IsAdmin == true)
            {
                objCookie = new HttpCookie("userInformation");
                now = DateTime.Now;

                objCookie.Values.Add("name", customerUserInfo.First_name + " " + customerUserInfo.Last_name);  // Add First Name
                objCookie.Values.Add("TimeLoggin", now.ToString());         // Add time when they login
		        objCookie.Values.Add("isAdmin", "true");  
                Response.Cookies.Add(objCookie);
                Response.Redirect("admin.aspx");
            }
            // // // // // // //
            // Normal account //
            // // // // // // //
            else if (customerUserInfo.IsAdmin == false)
            {
		objCookie = new HttpCookie("userInformation");
                now = DateTime.Now;

                objCookie.Values.Add("name", customerUserInfo.First_name + " " + customerUserInfo.Last_name);  // Add First Name
                objCookie.Values.Add("TimeLoggin", now.ToString());         // Add time when they login
                objCookie.Values.Add("isAdmin", "false");   
                Response.Cookies.Add(objCookie);
                Response.Redirect("index.aspx");
                lblResult.Text = "Cool dudes! your in!";
            }
            // HARD 
            //Response.Redirect("register.aspx");
        }

        else
            // Make cookie
            lblResult.Text = "Invalid credential. Please try again.";
    }

    
    public void sql()
    {
        string conString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
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


        lblMovieTitle1.Text = listMovies[0].Title;
        lblMovieSummary1.Text = listMovies[0].Director;
        lblMovieCompany1.Text = listMovies[0].Editor;
	downloadLabel.Text = "<a href=\"movie.aspx?id="+listMovies[0].Id+"\">Order now</a>";

        lblMovieTitle2.Text = listMovies[1].Title;
        lblMovieSummary2.Text = listMovies[1].Director;
        lblMovieCompany2.Text = listMovies[1].Editor;
	downloadLabel2.Text = "<a href=\"movie.aspx?id=" + listMovies[1].Id + "\">Order now</a>";
	
        lblMovieTitle3.Text = listMovies[2].Title;
        lblMovieSummary3.Text = listMovies[2].Director;
        lblMovieCompany3.Text = listMovies[2].Editor;
        downloadLabel3.Text = "<a href=\"movie.aspx?id=" + listMovies[2].Id + "\">Order now</a>";

    }

    
    public void setTop10()
     {
         var listTop = model2.getTop10Rentals();
         string top10 = "";
         int counter = 1;
        foreach(allmovies movie in listTop){
            top10 += counter + ". <a href=\"movie.aspx?id=" + movie.Id + "\">" + movie.Title + "</a><br>";
            counter++;
        }

        lblTop10.Text = top10;
         //lblTop10.Text = listTop[0].Company;
      }

    public void setNewRelease1()
    {

        var listTop = model2.NewRelesae1();
        string top10 = "";
        //string release2 = "";
        //int counter = 1;
        foreach (allmovies movie in listTop)
        {
            top10 += ". <a href=\"movie.aspx?id=" + movie.Id + "\">" + movie.Title + "</a><br>";
            //release2 += ". " + movie.Title + "<br>";
            // counter++;
        }
        lblNew1.Text = top10;
        //lblNew2.Text = release2;
    }



    public void setNewRelease2()
    {

        var listTop2 = model2.NewRelesae2();
        string release2 = "";

        foreach (allmovies movie in listTop2)
        {
            release2 += ". <a href=\"movie.aspx?id="+movie.Id+"\">" + movie.Title + "</a><br>";

        }
        lblNew2.Text = release2;
    }

    public void setPromo()
    {

        var listTop2 = model2.Promo();
        string release2 = "";
        string release3 = "";

        var listMovies = model.getMovie();

        string movieId = "";

        foreach (allmovies movie in listTop2)
        {
            release2 += "* " + movie.Title + "<br>";

            release3 += " "+ " "+ movie.Editor + "<br>";
            movieId = Convert.ToString(movie.Id);
        }
        lblPromo1.Text = release2;
        lblPromo2.Text = release3;
        lblPromo2.Text += "<br /><a href=\"movie.aspx?id=" + movieId + "\">Order Now</a>";
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
        //moviesFound = null;
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        topTenandNewReleases.Visible = false;
        searchResultDiv.Visible = true;
        List<allmovies> moviesFound = model.search(DropDownList1.SelectedValue, txtBoxSearch.Text);
        

        if (moviesFound.Count != 0)
        {
            string moviesText = "";
            foreach (allmovies movie in moviesFound)
            {
                moviesText += "<a href=\"movie.aspx?id="+movie.Id+"\">" + movie.Title + "</a><br />";

            }
            if (moviesFound.Count == 1)
            {
                moviesText += "<br><br>" + moviesFound.Count + " movie found";
            }
            else
            {
                moviesText += "<br><br>" + moviesFound.Count + " movies found";
            }

            searchResultDiv.InnerHtml = moviesText;
        }
        else
        {
            searchResultDiv.InnerHtml = "No result..";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        Response.Redirect("order.aspx");
    }
}
