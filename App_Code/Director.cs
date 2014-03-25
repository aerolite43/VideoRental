using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Director
/// </summary>
public class Director
{
    public int DirectorId { get; set; }
    public string DirectorName { get; set; }

	public Director(string name)
	{
        DirectorName = name;
	}
}