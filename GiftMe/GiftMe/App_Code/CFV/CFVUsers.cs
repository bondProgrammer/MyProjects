using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CFVUsers
/// </summary>
public class CFVUsers
{
    public CFVUsers()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Int64 UserRatingId { get; set; }
    public Int64 UserId { get; set; }
    public Int64 ItemId { get; set; }
    public int UserRating { get; set; }
    public string UserIdS { get; set; }

    public Int64 CategoryId { get; set; }
    public Int64 SubCategoryId { get; set; }
}