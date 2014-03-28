using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Linq;

/// @author Adrian Roy A. Baguio
/// @description using MVC model - http://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller
/// This should consists of DATABASE only please =)
/// @date 26/03/2014
public class Model
{
    string conString;
    DataContext db;

    // Constructor
    public Model()
	{
        // Load database connection string
        //conString = WebConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString; // Roy's Database Connetion String
        conString = WebConfigurationManager.ConnectionStrings["DatabaseConnection2"].ConnectionString; 
        db = new DataContext(conString);
	}


    /* 
     @author Adrian Roy A. Baguio
     @description return a list of movies. THIS WILL BE CHANGE LATER =)
     @date 26/03/2014
     */
    public List<allmovies> getMovie()
    {
        var tMovie = db.GetTable<allmovies>();

        var query =
        from movies in tMovie
        select movies;

        // Convert the result into an array
        var list = new List<allmovies>(query);

        return list;
    }

    /* 
     @author Adrian Roy A. Baguio
     @description Login, check for username and password
     @date 27/03/2014
     */
    public bool login(string username, string password)
    {
        // Initialising table
        var tCustomer = db.GetTable<customer>();

        // Make a query
        var query = tCustomer.Where(m => 
            (m.First_name.Equals(username)
            &&
            (m.Last_name.Equals(password)
            )));

        // Convert the result into an array
        var list = new List<customer>(query);        

        if (list.Count == 0)
            return false;   // If there are result
        else
            return true;
    }

    /* 
     @author Andrei Cordova
     @description return me the top 10 rentals.
     @Date 27/03/14
     @TargetDate April 9'th
     */
    public List<allmovies> getTop10Rentals()
    {
        var tTop = db.GetTable<allmovies>();

        //var query2 = from movies in tTop select movies where id = 10;

        var query2 = (from movies in tTop select movies).Take(10);


        var list = new List<allmovies>(query2);

        return list;
    }

    /* 
     @author Andrei Cordova
     @description RETURN me new release movies.
     perhaps check the date when a movie was added.
     @Date 27/03/14
     @TargetDate April 9'th
    */
    public List<allmovies> getNewReleases()
    {
        return null;
    }

    /* 
     @author Hermenegildo Lagniton
     @description register page. make me a layout as well pleashhh
     return true if the registration completes and false if registration fails.
     @Date 27/03/14
     @TargetDate April 9'th
    */
    public bool register(string firstName, string lastName, string etcetc)
    {
        return false;
    }

    /* 
     @author Adrian Roy A. Baguio
     @description return a list of objects depends on what object was on the search
     I'm thinking of using CHAIN OF RESPONSIBILITY here =)
     @Date 27/03/14
     @TargetDate April 9'th
    */
    public bool search(Object obj)
    {
        return false;
    }
}