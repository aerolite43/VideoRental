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
        conString = WebConfigurationManager.ConnectionStrings["DatabaseConnection3"].ConnectionString;
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
     @description return a list of movies. THIS WILL BE CHANGE LATER =)
     @date 15/04/2014
 */
    public allmovies getMovieById(int id)
    {
        var tMovie = db.GetTable<allmovies>();

        // Make a query
        var query = tMovie.Where(m =>
            (m.Id.Equals(id)));

        // Convert the result into an array
        var list = new List<allmovies>(query);

        if (list.Count == 0)
            return null;   // If there are result
        else
            return list[0]; // Return movie info
    }

     public List<cast> getCharactersById(int moveId)
   {
        var tCast = db.GetTable<cast>();

        var query =
        from cast in tCast
        where cast.Id.Equals(moveId)
        select cast;
        var list = new List<cast>(query);



        return list;
        }
    // Actor
    /* 
     @author Adrian Roy A. Baguio
     @description Login, check for username and password
     @date 27/03/2014
     */
    public customer login(string username, string password)
    {

        // Initialising table
        var tCustomer = db.GetTable<customer>();

        // Make a query
        var query = tCustomer.Where(m => 
            (m.Login.Equals(username)
            &&
            (m.Password.Equals(password)
            )));

        // Convert the result into an array
        var list = new List<customer>(query);        

        if (list.Count == 0)
            return null;   // If there are result
        else
            return list[0]; // Return customer
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

    public List<allmovies> NewRelesae1()
    {
        var tTop = db.GetTable<allmovies>();

        //displays new release 1
        //news=est movies from database are from 1995
        var query2 = (from movies in tTop where movies.Title.Contains("1995") select movies).Take(1);

        //var query2 = from movies in tTop where movies.Id == 2 select movies;


        var list = new List<allmovies>(query2);

        return list;
    }


    public List<allmovies> NewRelesae2()
    {
        var tTop = db.GetTable<allmovies>();

        //displays new release

        var query3 = (from movies in tTop where movies.Title.Contains("1995") orderby movies.Director select movies).Take(1);

        var list = new List<allmovies>(query3);

        return list;
    }

    public List<allmovies> Promo()
    {
        var tTop = db.GetTable<allmovies>();

        //displays new release

        var query3 = (from movies in tTop where movies.Title.Contains("1994") orderby movies.Director select movies).Take(1);

        var list = new List<allmovies>(query3);

        return list;
    }

    /* 
     @author Hermenegildo Lagniton
     @description: Takes data from register page after button click. Saves new customer to database.
     Returns true if customer data is saved to database, otherwise returns false.
     @Date 30/03/14
     @TargetDate April 9'th
    */
    public bool register(string firstName, string lastName, string addr1, string addr2,
        string city, string prov, string postal, string phone,
        string username, string pass, bool status)
    {   
        var custTable = db.GetTable<customer>();

        int maxIDquery = (int) (from cust in custTable select cust.Customer_id).Max() + 1;

        var newUser = new customer
        {
            Customer_id = maxIDquery,
            First_name = firstName,
            Last_name = lastName,
            Address1 = addr1,
            Address2 = addr2,
            City = city,
            Province = prov,
            Pcode = postal,
            Phone = phone,
            Login = username,
            Password = pass,
            IsAdmin = status
        };

        custTable.InsertOnSubmit(newUser);

        try
        {
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;

    }
    
    /* 
     @author Hermenegildo Lagniton
     @description: Takes data from admin add movies page
     Returns true if movie data is saved to database, otherwise returns false.
     @Date 30/03/14
     @TargetDate April 9'th
    */
    public bool addMovie(string mTitle, string mCompany, string mDirector, string mEditor)
    {
        var movieTable = db.GetTable<allmovies>();

        int maxIDquery = (int)(from movie in movieTable select movie.Id).Max() + 1;

        var newMovie = new allmovies
        {
            Id = maxIDquery,
            Title = mTitle,
            Company = mCompany,
            Director = mDirector,
            Editor = mEditor
        };

        movieTable.InsertOnSubmit(newMovie);

        try
        {
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;

    }

    /* 
     @author Adrian Roy A. Baguio
     @description return a list of objects depends on what object was on the search
     I'm thinking of using CHAIN OF RESPONSIBILITY here =)
     @Date 27/03/14
     @TargetDate April 9'th
    */
    /* 
     @author Adrian Roy A. Baguio
     @description return a list of objects depends on what object was on the search
     I'm thinking of using CHAIN OF RESPONSIBILITY here =)
     @Date 27/03/14
     @TargetDate April 9'th
     @DateCompletion 28/03/14
    */
    public List<allmovies> search(string searchtype, string searchText)
    {
        var tMovie = db.GetTable<allmovies>();
        var tCast = db.GetTable<cast>();
        var tDirector = db.GetTable<director>();

        if (searchtype == "director")
        {
            var query =
            from movies in tMovie
            join d in tDirector on movies.Id equals d.Id
            where d.name == searchText
            select movies;

            var list = new List<allmovies>(query);
            return list;
        }
        else if (searchtype == "actor")
        {
            var query =
            from movies in tMovie
            join c in tCast on movies.Id equals c.Id
            where c.castname == searchText
            select movies;

            var list = new List<allmovies>(query);
            return list;
        }
        else if (searchtype == "character")
        {
            var query =
            from movies in tMovie
            join c in tCast on movies.Id equals c.Id
            where c.castrole == searchText
            select movies;

            var list = new List<allmovies>(query);
            return list;
        }
        else if (searchtype == "title")
        {
            var query =
            from movies in tMovie
            where movies.Title.Contains(searchText)
            select movies;

            var list = new List<allmovies>(query);
            return list;

        }
        else if (searchtype == "keyword")
        {
            // Director
            var query =
            from movies in tMovie
            join d in tDirector on movies.Id equals d.Id
            where d.name == searchText
            select movies;

            var list = new List<allmovies>(query);

            // Actor
            query =
            from movies in tMovie
            join c in tCast on movies.Id equals c.Id
            where c.castname == searchText
            select movies;
            list.AddRange(query);

            // Character
            query =
            from movies in tMovie
            join c in tCast on movies.Id equals c.Id
            where c.castrole == searchText
            select movies;
            // Append the new query to that list.
            list.AddRange(query);

            // Title
            query =
            from movies in tMovie
            where movies.Title.Contains(searchText)
            select movies;
            list.AddRange(query);

            return list;

        }
        else
        {

        }


        return null;

    }
}