using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for CFDUser
/// </summary>
public class CFDUser
{
	public CFDUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public SqlConnection sqlcon = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

    public DataSet allusersratings() 
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select UserRatingId, UserId, ItemId, UserRating
from UserRatings";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sda = new SqlDataAdapter(sqlcmd);
            sqlcmd.Connection = sqlcon;

            sda.Fill(objds);
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }
        return objds;
    }

    public DataSet allusers()
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select distinct UserId
from UserRatings";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sda = new SqlDataAdapter(sqlcmd);
            sqlcmd.Connection = sqlcon;

            sda.Fill(objds);
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }
        return objds;
    }

    public DataSet alluserswiseproducts(CFVUsers ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select UserRatingId, UserId, ItemId, UserRating
from UserRatings where UserId=@UserId order by UserId asc";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserId", ob.UserId);

            sda = new SqlDataAdapter(sqlcmd);
            sqlcmd.Connection = sqlcon;

            sda.Fill(objds);
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }
        return objds;
    }

    public DataSet collaborativefilterings(CFVUsers ob) 
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"DECLARE @UIDC bigint
declare @tbl table
(
ItemId bigint, 
CategoryId bigint, 
SubCategoryId bigint, 
ItemName nvarchar(150), 
ItemPrice decimal(18,3), 
ImagePath nvarchar(max), 
ImageName nvarchar(150),
CategoryName nvarchar(150),
SubCategory nvarchar(150)
)

declare @tbl1 table
(
UserIdC bigint
)

insert into @tbl1(UserIdC)
SELECT UserIdCF
FROM dbo.SplitString(@UserId, ',')

DECLARE CF CURSOR FOR   
select distinct  UserId
from UserRatings 
OPEN CF   
FETCH NEXT FROM CF INTO @UIDC
WHILE @@FETCH_STATUS = 0   
BEGIN   
insert into @tbl(ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory)
       select  ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryName,
                SubCategory.SubCategory
from ProductDetails inner join
UserRatings on UserRatings.ItemId=ProductDetails.ItemId
     inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
	   where UserRatings.UserId=@UIDC

       FETCH NEXT FROM CF INTO @UIDC
END   
CLOSE CF   
DEALLOCATE CF
   
if(@CategoryId!=0 and @SubCategoryId!=0 and @ItemId!=0)
begin
select distinct ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @tbl
where CategoryId=@CategoryId
  and SubCategoryId=@SubCategoryId
  and ItemId=@ItemId
order by ItemId asc     
end
else
if(@CategoryId!=0 and @SubCategoryId!=0 and @ItemId=0)
begin
select distinct ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @tbl
where CategoryId=@CategoryId
      and SubCategoryId=@SubCategoryId
order by ItemId asc     
end
else
if(@CategoryId=0 and @SubCategoryId!=0 and @ItemId!=0)
begin
select distinct ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @tbl
where SubCategoryId=@SubCategoryId     
      and ItemId=@ItemId
order by ItemId asc     
end
else
if(@CategoryId!=0 and @SubCategoryId=0 and @ItemId!=0)
begin
select distinct ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @tbl
where CategoryId=@CategoryId     
      and ItemId=@ItemId
order by ItemId asc     
end
else
if(@CategoryId!=0 and @SubCategoryId=0 and @ItemId=0)
begin
select distinct ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @tbl
where CategoryId=@CategoryId  
order by ItemId asc     
end
else
if(@CategoryId=0 and @SubCategoryId!=0 and @ItemId=0)
begin
select distinct ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @tbl
where  SubCategoryId=@SubCategoryId
order by ItemId asc     
end
else
if(@CategoryId=0 and @SubCategoryId=0 and @ItemId!=0)
begin
select distinct ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @tbl
where ItemId=@ItemId
order by ItemId asc     
end
else
begin
select distinct ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @tbl       
order by ItemId asc     
end";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserId", ob.UserId);
            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);
            sqlcmd.Parameters.AddWithValue("@SubCategoryId", ob.SubCategoryId);
            sqlcmd.Parameters.AddWithValue("@ItemId", ob.ItemId);

            sda = new SqlDataAdapter(sqlcmd);
            sqlcmd.Connection = sqlcon;

            sda.Fill(objds);
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }
        return objds;
    }
}