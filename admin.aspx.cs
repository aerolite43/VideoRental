using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /* 
         @author Adrian Roy A Baguio
         @date 08/04/2014
         @description hide both divs when page loads.
         */
        addMovies.Visible = false;
        addPeople.Visible = false;

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

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
}