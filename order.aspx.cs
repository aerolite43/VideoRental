using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Model model = new Model();
        string cookies = "";
        string htmlResult = "";
        HttpCookie objCookie = Request.Cookies["cartInformation"];

        string deleteItem = HttpContext.Current.Request.QueryString["delete"];
        if(deleteItem != null){
            deleteItemInCart(Convert.ToInt32(deleteItem));
        }
        

        // No cart so send them an error
        if (objCookie == null)
        {
            HttpCookie errorCookie;
            errorCookie = new HttpCookie("ERROR");
            DateTime now;
            now = DateTime.Now;

            errorCookie.Values.Add("message", "You don't have anything from your cart.");
            errorCookie.Values.Add("time", now.ToString());

            Response.Cookies.Add(errorCookie);
            Response.Redirect("error.aspx");
        }

        cookies += objCookie.Values.ToString();
        string[] delims = { "=&", "=" };

        string[] results = cookies.Split(delims, StringSplitOptions.RemoveEmptyEntries);

        int counter = 1;

        foreach(string result in results){
            allmovies movie = model.getMovieById(Convert.ToInt32(result));

            Random rand = new Random((int)DateTime.Now.Ticks);
            var numIterations = rand.Next(100, 500); // GET RANDOM NUMBER
            htmlResult += "<tr><td>" + counter + "</td><td>" + movie.Title + "</td><td>$" + numIterations.ToString() + "</td><td><span class=\"glyphicon glyphicon-remove\"></span></td></tr>";
            counter++;
            // <tr><td>45</td><td>2.45%</td><td>$100</td><td><span class="glyphicon glyphicon-remove"></span></td></tr>
        }

        tableOrder.InnerHtml = htmlResult;
        

    }

    public void deleteItemInCart(int id)
    {
        string cookies = "";
        HttpCookie objCookie = Request.Cookies["cartInformation"];

        cookies += objCookie.Values.ToString();
        string[] delims = { "=&", "=" };

        string[] results = cookies.Split(delims, StringSplitOptions.RemoveEmptyEntries);

        // If there is one result left
        if (results.Length == 1)
        {
            objCookie = new HttpCookie("cartInformation");
            objCookie.Expires = DateTime.Now.AddDays(-10);
            objCookie.Value = null;
            HttpContext.Current.Response.SetCookie(objCookie);
            Response.Redirect("order.aspx");
        }

        // Remove item
        int counter = 0;
        // Make a new cookie
        objCookie = new HttpCookie("cartInformation");
        foreach (string result in results)
        {
            // Don't add the removed item
            if (counter == Convert.ToInt32(id))
            {
                counter++;
                continue;
            }

            objCookie.Values.Add(result[0].ToString(), "");
            Response.Cookies.Add(objCookie);
            counter++;
        }
        Response.Redirect("order.aspx");


        
    }

    public void deleteItem(int id){
        HttpCookie objCookie = Request.Cookies["cartInformation"];
        // LOL HOW CAN WE DELETE ITEMS IN THIS FRIDGING COOKIE LMFAO.
    }


}