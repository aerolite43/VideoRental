using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Actor
/// </summary>
public class Actor
{
    public int ActorId { get; set; }
    public string ActorName { get; set; }
	public Actor(string name)
	{
        ActorName = name;
	}
}