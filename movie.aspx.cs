using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Movie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string movieId = HttpContext.Current.Request.QueryString["id"];
        Model model = new Model();
        allmovies movie = model.getMovieById(Convert.ToInt32(movieId));
	List<cast> casts = model.getCharactersById(Convert.ToInt32(movieId));
        if (movie != null)
        {
            movieIdText.InnerText = movie.Id.ToString();
            titleText.InnerText += " " + movie.Title;
            directorText.InnerText += " " + movie.Director;
            editorText.InnerText += " " + movie.Editor;
            companyText.InnerText += " " + movie.Company;
            titleText2.InnerText += " " + movie.Title;
            titleText3.InnerText += " " + movie.Title;
            movieTitle.Text = movie.Title;
            foreach(cast cast in casts){
                actorText.InnerHtml += "<br> " + cast.castname;
            }
        }
        else
        {
            HttpCookie objCookie;
            objCookie = new HttpCookie("ERROR");
            DateTime now;
            now = DateTime.Now;

            objCookie.Values.Add("message", "Invalid Movie.");         
            objCookie.Values.Add("time", now.ToString());

            Response.Cookies.Add(objCookie);
            Response.Redirect("error.aspx");
        }
        // Check if the user is logged in or not
        HttpCookie userInformationCookie = Request.Cookies["userInformation"];
        /*********************
         * *******************
         User is not logged in
         * *******************
         *********************/
        if (userInformationCookie == null)
        {
            registerButton.Visible = true;
        }

         /*********************
         * *******************
         User is logged in
         * *******************
         *********************/
        else
        {
            btnAddToCart.Visible = true;
        }
        
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        // If cookie does not exsist
        HttpCookie cartCookie = Request.Cookies.Get("cartInformation");
        if (cartCookie == null)
        {
            cartCookie = new HttpCookie("cartInformation");
            cartCookie.Values.Add(movieIdText.InnerText, "");
            HttpContext.Current.Response.SetCookie(cartCookie);
        }
        // If it exsist just add additional movie son!
        else
        {
            cartCookie.Values.Add(movieIdText.InnerText, "");
            HttpContext.Current.Response.SetCookie(cartCookie);
        }
        Response.Redirect("index.aspx");
    }
}