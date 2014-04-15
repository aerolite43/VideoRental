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
        if (movie != null)
        {
            titleText.InnerText += " " + movie.Title;
            directorText.InnerText += " " + movie.Director;
            editorText.InnerText += " " + movie.Editor;
            companyText.InnerText += " " + movie.Company;
            titleText2.InnerText += " " + movie.Title;
            titleText3.InnerText += " " + movie.Title;
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
        

    }
}