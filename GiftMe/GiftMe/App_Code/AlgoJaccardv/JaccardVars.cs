using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JaccardVars
/// </summary>
public class JaccardVars
{
	public JaccardVars()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 UserId { get; set; } 
    public Int64 ItemId { get; set; }
    public Int64 CategoryId { get; set; }
    public Int64 SubCategoryId { get; set; }
    public string ItemName { get; set; }
    public decimal ItemPrice { get; set; }
    public string ImagePath { get; set; }
    public string ImageName { get; set; }
}