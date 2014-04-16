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

        cookies += objCookie.Values.ToString();
        string[] delims = { "=&", "=" };

        string[] results = cookies.Split(delims, StringSplitOptions.RemoveEmptyEntries);

        int counter = 1;

        foreach(string result in results){
            allmovies movie = model.getMovieById(Convert.ToInt32(result));

            htmlResult += "<tr><td>"+counter+"</td><td>"+movie.Title+"</td><td>$200</td><td><span class=\"glyphicon glyphicon-remove\"></span></td></tr>";
            counter++;
            // <tr><td>45</td><td>2.45%</td><td>$100</td><td><span class="glyphicon glyphicon-remove"></span></td></tr>
        }

        tableOrder.InnerHtml = htmlResult;
        

    }


}