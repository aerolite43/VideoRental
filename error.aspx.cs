using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie objCookie = Request.Cookies["ERROR"];
        string errorMessage;
        string time;

        if (objCookie != null)
        {
            errorMessage = objCookie.Values["message"].ToString();
            time = objCookie.Values["time"].ToString();
        }
        else
        {
            errorMessage = "Unidentified";
            time = "No time specificed.";
        }
        
        

        errorMessageText.InnerText = errorMessage;
        timeText.InnerText += time;
    }
}