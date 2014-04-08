using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

/// <summary>
/// Summary description for customer
/// </summary>
[Table]
public class customer
{
    [Column(IsPrimaryKey = true/*, IsDbGenerated = true*/)]
    public int Customer_id { get; set; }

    [Column]
    public string First_name { get; set; }

    [Column]
    public string Last_name { get; set; }

    [Column]
    public string Address1 { get; set; }

    [Column]
    public string Address2 { get; set; }

    [Column]
    public string City { get; set; }

    [Column]
    public string Province { get; set; }

    [Column]
    public string Pcode { get; set; }

    [Column]
    public string Phone { get; set; }

    [Column]
    public string Login { get; set; }

    [Column]
    public string Password { get; set; }

    [Column]
    public Boolean IsAdmin { get; set; }
}