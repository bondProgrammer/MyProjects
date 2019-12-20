using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterMaintenanceVars
/// </summary>
public class MasterMaintenanceVars
{
    public MasterMaintenanceVars()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 CategoryId { get; set; }
    public string CategoryName { get; set; }

    public Int64 SubCategoryId { get; set; }
    public string SubCategory { get; set; }

    public Int64 ItemId { get; set; }
    public string ItemName { get; set; }
    public decimal ItemPrice { get; set; }
    public string ImagePath { get; set; }
    public string ImageName { get; set; }

    public Int64 UserId { get; set; } 
    public string UserName { get; set; } 
    public string UserMobile { get; set; } 
    public string UserEmail { get; set; } 
    public string UserState { get; set; } 
    public string UserCity { get; set; } 
    public string UserGender { get; set; } 
    public string UserEducation { get; set; } 
    public string UserProfession { get; set; }
    public string UserAge { get; set; }

    public string UserName1 { get; set; }
    public string UserPassword { get; set; }
    public string UserRole { get; set; }

    public int UserRating { get; set; }

}