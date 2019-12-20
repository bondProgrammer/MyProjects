using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for Jaccarddata
/// </summary>
public class Jaccarddata
{
	public Jaccarddata()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public SqlConnection sqlcon = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

    public DataSet productdetails(JaccardVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"if(@CategoryId!=0 and @SubCategoryId!=0 and @ItemId!=0)
begin
select distinct ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName,
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.CategoryId=@CategoryId
      and ProductDetails.SubCategoryId=@SubCategoryId
      and ProductDetails.ItemId=@ItemId
order by ProductDetails.ItemId asc     
end
else
if(@CategoryId!=0 and @SubCategoryId!=0 and @ItemId=0)
begin
select distinct ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName,
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.CategoryId=@CategoryId
      and ProductDetails.SubCategoryId=@SubCategoryId
order by ProductDetails.ItemId asc     
end
else
if(@CategoryId=0 and @SubCategoryId!=0 and @ItemId!=0)
begin
select distinct ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName,
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.SubCategoryId=@SubCategoryId     
      and ProductDetails.ItemId=@ItemId
order by ProductDetails.ItemId asc     
end
else
if(@CategoryId!=0 and @SubCategoryId=0 and @ItemId!=0)
begin
select distinct ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName,
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.CategoryId=@CategoryId     
      and ProductDetails.ItemId=@ItemId
order by ProductDetails.ItemId asc     
end
else
if(@CategoryId!=0 and @SubCategoryId=0 and @ItemId=0)
begin
select distinct ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName,
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.CategoryId=@CategoryId  
order by ProductDetails.ItemId asc     
end
else
if(@CategoryId=0 and @SubCategoryId!=0 and @ItemId=0)
begin
select distinct ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName,
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where  ProductDetails.SubCategoryId=@SubCategoryId
order by ProductDetails.ItemId asc     
end
else
if(@CategoryId=0 and @SubCategoryId=0 and @ItemId!=0)
begin
select distinct ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName,
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.ItemId=@ItemId
order by ProductDetails.ItemId asc     
end
else
begin
select distinct ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName,
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId  
       
order by ProductDetails.ItemId asc     
end";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

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

    public DataSet subcategorydetails()
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select distinct 
       SubCategory.SubCategoryId,
       SubCategory.CategoryId,
       SubCategory.SubCategory
from SubCategory";

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

    public DataSet productidwisedetails(JaccardVars ob) 
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
           sqlcon.Open();

           string q = @"select distinct ProductDetails.ItemId,  
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice,  ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryId as ccid, 
                Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid, 
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.ItemId=@ItemId   
order by ProductDetails.ItemId asc";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

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

    public DataSet jaccardcoe(JaccardVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"DECLARE @CategoryIdJ bigint
DECLARE @SubCategoryJ bigint 
DECLARE @ItemIdJ bigint

declare @jaccard table
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

DECLARE jaccardalgo CURSOR FOR   
select distinct  
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemId
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ItemId=@ItemId1
OPEN jaccardalgo   
FETCH NEXT FROM jaccardalgo INTO @CategoryIdJ,@SubCategoryJ,@ItemIdJ
WHILE @@FETCH_STATUS = 0   
BEGIN   
insert into @jaccard(ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory)
       select  ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryName,
                SubCategory.SubCategory
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
	   where ProductDetails.CategoryId=@CategoryIdJ and ProductDetails.ItemId!=@ItemIdJ

       FETCH NEXT FROM jaccardalgo INTO @CategoryIdJ,@SubCategoryJ,@ItemIdJ 
END   
CLOSE jaccardalgo   
DEALLOCATE jaccardalgo
   
select ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory
from @jaccard";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@ItemId1", ob.ItemId);

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

    public DataSet jaccardcoeforuser(JaccardVars ob)  
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"DECLARE @CategoryIdJ bigint
DECLARE @SubCategoryJ bigint 
DECLARE @ItemIdJ bigint
DECLARE @UIDC bigint

DECLARE @AgeJ nvarchar(50)
DECLARE @EducationJ nvarchar(50)
DECLARE @ProfessionJ nvarchar(50)

declare @jaccard table
(
ItemId bigint, 
CategoryId bigint, 
SubCategoryId bigint, 
ItemName nvarchar(150), 
ItemPrice decimal(18,3), 
ImagePath nvarchar(max), 
ImageName nvarchar(150),
CategoryName nvarchar(150),
SubCategory nvarchar(150),
UserRatings int
)

declare @jaccardf table
(
ItemIdf bigint, 
CategoryIdf bigint, 
SubCategoryIdf bigint, 
ItemNamef nvarchar(150), 
ItemPricef decimal(18,3), 
ImagePathf nvarchar(max), 
ImageNamef nvarchar(150),
CategoryNamef nvarchar(150),
SubCategoryf nvarchar(150),
UserRatingsf int
)

select @AgeJ=UserAge,@EducationJ=UserEducation,@ProfessionJ=UserProfession 
from UserDetails where UserId=@UserIdIP

DECLARE jaccardalgo CURSOR FOR   
select distinct UserDetails.UserId                
from UserDetails inner join UserRatings 
on UserRatings.UserId=UserDetails.UserId
where UserAge=@AgeJ and UserEducation=@EducationJ and UserProfession=@ProfessionJ
OPEN jaccardalgo   
FETCH NEXT FROM jaccardalgo INTO @UIDC
WHILE @@FETCH_STATUS = 0   
BEGIN   
insert into @jaccard(ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory,UserRatings)
       select  ProductDetails.ItemId, 
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemName, 
                ProductDetails.ItemPrice, ProductDetails.ImagePath, 
                ProductDetails.ImageName,
                Category.CategoryName,
                SubCategory.SubCategory,UserRatings.UserRating
from ProductDetails inner join UserRatings
on UserRatings.ItemId=ProductDetails.ItemId
inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
	   where UserRatings.UserId=@UIDC and ProductDetails.ItemId!=@ItemIP

       FETCH NEXT FROM jaccardalgo INTO @UIDC 
END   
CLOSE jaccardalgo   
DEALLOCATE jaccardalgo

DECLARE jaccardc CURSOR FOR   
select distinct  
                ProductDetails.CategoryId, ProductDetails.SubCategoryId, ProductDetails.ItemId
from ProductDetails inner join Category
     on Category.CategoryId=ProductDetails.CategoryId
     inner join SubCategory 
     on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ItemId=@ItemIP 
OPEN jaccardc   
FETCH NEXT FROM jaccardc INTO @CategoryIdJ,@SubCategoryJ,@ItemIdJ
WHILE @@FETCH_STATUS = 0   
BEGIN   
insert into @jaccardf(ItemIdf,CategoryIdf,SubCategoryIdf,ItemNamef,
ItemPricef,ImagePathf,ImageNamef,CategoryNamef,SubCategoryf,UserRatingsf)
       select  ItemId,CategoryId,SubCategoryId,ItemName,
ItemPrice,ImagePath,ImageName,CategoryName,SubCategory,UserRatings
from @jaccard
where CategoryId=@CategoryIdJ

       FETCH NEXT FROM jaccardc INTO @CategoryIdJ,@SubCategoryJ,@ItemIdJ 
END   
CLOSE jaccardc   
DEALLOCATE jaccardc
   
select ItemIdf,ItemNamef,
ItemPricef,ImagePathf,ImageNamef,max(UserRatingsf) as UserRatingsf
from @jaccardf group by ItemIdf,ItemNamef,
ItemPricef,ImagePathf,ImageNamef
";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserIdIP", ob.UserId);
            sqlcmd.Parameters.AddWithValue("@ItemIP", ob.ItemId);

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

