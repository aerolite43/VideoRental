using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Movie
/// </summary>
public class Movie
{
    public int MoveId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }

	public Movie(string title, string genre)
	{
        Title = title;
        Genre = genre;
	}
}