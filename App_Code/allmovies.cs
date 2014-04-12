using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

// note, you will have to add the System.Dat.Linq reference
// in the projects property manager 
[Table]
public class allmovies
{
    [Column(IsPrimaryKey = true/*, IsDbGenerated = true*/)]
    public int Id { get; set; }

    [Column]
    public string Company { get; set; }

    [Column]
    public string Title { get; set; }

    [Column]
    public string Director { get; set; }

    [Column]
    public string Editor { get; set; }
}
