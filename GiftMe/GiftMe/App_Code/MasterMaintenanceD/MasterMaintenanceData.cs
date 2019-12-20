using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for MasterMaintenanceData
/// </summary>
public class MasterMaintenanceData
{
    public MasterMaintenanceData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlConnection sqlcon = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

    public bool icategorydetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();
            string q = @"insert into Category(CategoryName)
                  values(@CategoryName)";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@CategoryName", ob.CategoryName);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public bool ucategorydetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();

            string q = @"update Category set
                        CategoryName=@CategoryName
where CategoryId=@CategoryId  ";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);
            sqlcmd.Parameters.AddWithValue("@CategoryName", ob.CategoryName);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public bool dcategorydetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();

            string q = @"delete from Category
                         where CategoryId=@CategoryId";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public DataSet scategorydetails()
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select distinct 
       Category.CategoryId,
       Category.CategoryName
from Category";

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

    public DataSet scategorydetailssearch(MasterMaintenanceVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"if(@CategoryId=0)
begin
select Category.CategoryId,
       Category.CategoryName
from Category
order by CategoryId asc
end
else
begin
select Category.CategoryId,
       Category.CategoryName 
from Category
where Category.CategoryId=@CategoryId
order by CategoryId asc
end";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);

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

    public bool isubcategorydetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();

            string q = @"insert into SubCategory(CategoryId, 
                           SubCategory)
                     values(@CategoryId, 
                            @SubCategory)";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);
            sqlcmd.Parameters.AddWithValue("@SubCategory", ob.SubCategory);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public bool usubcategorydetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();

            string q = @"update SubCategory set CategoryId=@CategoryId,
                           SubCategory=@SubCategory
where SubCategoryId=@SubCategoryId  ";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@SubCategoryId", ob.SubCategoryId);
            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);
            sqlcmd.Parameters.AddWithValue("@SubCategory", ob.SubCategory);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public bool dsubcategorydetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();

            string q = @"delete from SubCategory
where SubCategoryId=@SubCategoryId";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@SubCategoryId", ob.SubCategoryId);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public DataSet ssubcategorydetails()
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select distinct 
       SubCategory.SubCategoryId,
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

    public DataSet ssubcategorydetailssearch(MasterMaintenanceVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"if(@CategoryId=0 and @SubCategoryId=0)
begin
select distinct
Category.CategoryId as cid, 
       Category.CategoryName, 
       SubCategory.SubCategoryId, 
       SubCategory.SubCategory
from Category inner join SubCategory
     on SubCategory.CategoryId=Category.CategoryId  
order by Category.CategoryId asc
end
else
if(@CategoryId!=0 and @SubCategoryId=0)
begin
select distinct
      Category.CategoryId as cid, 
       Category.CategoryName, 
       SubCategory.SubCategoryId, 
       SubCategory.SubCategory
from Category inner join SubCategory
     on SubCategory.CategoryId=Category.CategoryId 
where SubCategory.CategoryId=@CategoryId     
order by Category.CategoryId asc
end
else
if(@CategoryId=0 and @SubCategoryId!=0)
begin
select distinct
       Category.CategoryId as cid, 
       Category.CategoryName, 
       SubCategory.SubCategoryId, 
       SubCategory.SubCategory
from Category inner join SubCategory
     on SubCategory.CategoryId=Category.CategoryId 
where SubCategory.SubCategoryId=@SubCategoryId     
order by Category.CategoryId asc
end
else
if(@CategoryId!=0 and @SubCategoryId!=0)
begin
select distinct
      Category.CategoryId as cid, 
       Category.CategoryName, 
       SubCategory.SubCategoryId, 
       SubCategory.SubCategory
from Category inner join SubCategory
     on SubCategory.CategoryId=Category.CategoryId 
where SubCategory.CategoryId=@CategoryId
      and SubCategory.SubCategoryId=@SubCategoryId     
order by Category.CategoryId asc
end
else
begin
select distinct
      Category.CategoryId as cid, 
       Category.CategoryName, 
       SubCategory.SubCategoryId, 
       SubCategory.SubCategory
from Category inner join SubCategory
     on SubCategory.CategoryId=Category.CategoryId  
order by Category.CategoryId asc
end";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);
            sqlcmd.Parameters.AddWithValue("@SubCategoryId", ob.SubCategoryId);

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

    public DataSet ssubcategorydetailscidwise(MasterMaintenanceVars ob)
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
from SubCategory
where SubCategory.CategoryId=@CategoryId";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);

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

    public bool iProductDetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();

            string q = @"insert into ProductDetails(CategoryId, SubCategoryId, ItemName, 
                     ItemPrice, ImagePath, ImageName)
              values(@CategoryId, @SubCategoryId, @ItemName, 
                     @ItemPrice, @ImagePath, @ImageName)";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);
            sqlcmd.Parameters.AddWithValue("@SubCategoryId", ob.SubCategoryId);
            sqlcmd.Parameters.AddWithValue("@ItemName", ob.ItemName);
            sqlcmd.Parameters.AddWithValue("@ItemPrice", ob.ItemPrice);
            sqlcmd.Parameters.AddWithValue("@ImagePath", ob.ImagePath);
            sqlcmd.Parameters.AddWithValue("@ImageName", ob.ImageName);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public bool uProductDetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();

            string q = @"update ProductDetails set CategoryId=@CategoryId, 
                    SubCategoryId=@SubCategoryId, 
                    ItemName=@ItemName, 
                    ItemPrice=@ItemPrice, 
                    ImagePath=@ImagePath, 
                    ImageName=@ImageName
where ItemId=@ItemId";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@ItemId", ob.ItemId);
            sqlcmd.Parameters.AddWithValue("@CategoryId", ob.CategoryId);
            sqlcmd.Parameters.AddWithValue("@SubCategoryId", ob.SubCategoryId);
            sqlcmd.Parameters.AddWithValue("@ItemName", ob.ItemName);
            sqlcmd.Parameters.AddWithValue("@ItemPrice", ob.ItemPrice);
            sqlcmd.Parameters.AddWithValue("@ImagePath", ob.ImagePath);
            sqlcmd.Parameters.AddWithValue("@ImageName", ob.ImageName);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public bool dProductDetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();

            string q = @"delete from ProductDetails 
where ItemId=@ItemId";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@ItemId", ob.ItemId);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public DataSet sProductDetails()
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
on Category.CategoryId=ProductDetails.CategoryId
inner join SubCategory
on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
order by ProductDetails.ItemId asc";

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

    public DataSet sProductDetailssearch(MasterMaintenanceVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"if(@CategoryId!=0 and @SubCategoryId!=0 and @ItemId!=0)
begin
select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
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
select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
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
select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
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
select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
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
select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
on Category.CategoryId=ProductDetails.CategoryId
inner join SubCategory
on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.CategoryId=@CategoryId  
order by ProductDetails.ItemId asc     
end
else
if(@CategoryId=0 and @SubCategoryId!=0 and @ItemId=0)
begin
select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
on Category.CategoryId=ProductDetails.CategoryId
inner join SubCategory
on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.SubCategoryId=@SubCategoryId
order by ProductDetails.ItemId asc     
end
else
if(@CategoryId=0 and @SubCategoryId=0 and @ItemId!=0)
begin
select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
on Category.CategoryId=ProductDetails.CategoryId
inner join SubCategory
on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.ItemId=@ItemId
order by ProductDetails.ItemId asc     
end
else
begin
select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
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

    public DataSet sProductDetailsscatidwise(MasterMaintenanceVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
on Category.CategoryId=ProductDetails.CategoryId
inner join SubCategory
on SubCategory.SubCategoryId=ProductDetails.SubCategoryId     
where ProductDetails.SubCategoryId=@SubCategoryId   
order by ProductDetails.ItemId asc";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@SubCategoryId", ob.SubCategoryId);

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

    public DataSet sProductDetailssitemidwise(MasterMaintenanceVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
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

    public DataSet sProductDetailsscatidmcatwise(MasterMaintenanceVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select distinct ProductDetails.ItemId, ProductDetails.CategoryId, ProductDetails.SubCategoryId, 
                ProductDetails.ItemName, ProductDetails.ItemPrice, 
			    ProductDetails.ImagePath, ProductDetails.ImageName,
                Category.CategoryId as ccid, Category.CategoryName, 
                SubCategory.SubCategoryId as scscid, 
                SubCategory.CategoryId as sccid,
                SubCategory.SubCategory
from ProductDetails 
inner join Category
on Category.CategoryId=ProductDetails.CategoryId
inner join SubCategory
on SubCategory.SubCategoryId=ProductDetails.SubCategoryId
where ProductDetails.SubCategoryId=@SubCategoryId ";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@SubCategoryId", ob.SubCategoryId);

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

    public bool iUserDetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();
            string q = @"insert into UserDetails(UserName, UserMobile, UserEmail, 
                        UserState, UserCity, UserGender, 
						UserEducation, UserProfession, UserAge)
				values(@UserName, @UserMobile, @UserEmail, 
                       @UserState, @UserCity, @UserGender, 
					   @UserEducation, @UserProfession, @UserAge)
insert into Login(UserName, UserPassword, UserRole)
values(@UserEmail,@UserPassword,@UserRole)";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserName", ob.UserName);
            sqlcmd.Parameters.AddWithValue("@UserMobile", ob.UserMobile);
            sqlcmd.Parameters.AddWithValue("@UserEmail", ob.UserEmail);
            sqlcmd.Parameters.AddWithValue("@UserState", ob.UserState);
            sqlcmd.Parameters.AddWithValue("@UserCity", ob.UserCity);
            sqlcmd.Parameters.AddWithValue("@UserGender", ob.UserGender);
            sqlcmd.Parameters.AddWithValue("@UserEducation", ob.UserEducation);
            sqlcmd.Parameters.AddWithValue("@UserProfession", ob.UserProfession);
            sqlcmd.Parameters.AddWithValue("@UserAge", ob.UserAge);
            sqlcmd.Parameters.AddWithValue("@UserRole", ob.UserRole);
            sqlcmd.Parameters.AddWithValue("@UserPassword", ob.UserPassword);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public bool uUserDetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();
            string q = @"declare @UserEmail1 nvarchar(50)
declare @UserName1 nvarchar(50)
declare @UserPassword1 nvarchar(50)
declare @UserRole1 nvarchar(50)

select @UserEmail1=UserEmail
from UserDetails
where UserId=@UserId

select @UserName1=UserName,
       @UserPassword1=UserPassword,
	   @UserRole1=UserRole 
from Login
where UserName=@UserEmail1

update UserDetails set UserName=@UserName,
                       UserMobile=@UserMobile,
					   UserEmail=@UserEmail,
					   UserState=@UserState,
					   UserCity=@UserCity,
					   UserGender=@UserGender,
					   UserEducation=@UserEducation,
					   UserProfession=@UserProfession,
					   UserAge=@UserAge
where UserId=@UserId

update Login set UserName=@UserEmail
where UserName=@UserName1";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserId", ob.UserId);
            sqlcmd.Parameters.AddWithValue("@UserName", ob.UserName);
            sqlcmd.Parameters.AddWithValue("@UserMobile", ob.UserMobile);
            sqlcmd.Parameters.AddWithValue("@UserEmail", ob.UserEmail);
            sqlcmd.Parameters.AddWithValue("@UserState", ob.UserState);
            sqlcmd.Parameters.AddWithValue("@UserCity", ob.UserCity);
            sqlcmd.Parameters.AddWithValue("@UserGender", ob.UserGender);
            sqlcmd.Parameters.AddWithValue("@UserEducation", ob.UserEducation);
            sqlcmd.Parameters.AddWithValue("@UserProfession", ob.UserProfession);
            sqlcmd.Parameters.AddWithValue("@UserAge", ob.UserAge);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public bool dUserDetails(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();
            string q = @"delete from UserDetails where UserId=@UserId";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserId", ob.UserId);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public DataSet sUserDetails()
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select UserId, UserName, UserMobile, UserEmail, 
       UserState, UserCity, UserGender, 
	   UserEducation, UserProfession, UserAge
from UserDetails";

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

    public DataSet sUserDetailsidwise(MasterMaintenanceVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"if(@UserId!=0)
begin
select UserId, UserName, UserMobile, UserEmail, 
       UserState, UserCity, UserGender, 
	   UserEducation, UserProfession, UserAge
from UserDetails
where UserId=@UserId
end
else
begin
select UserId, UserName, UserMobile, UserEmail, 
       UserState, UserCity, UserGender, 
	   UserEducation, UserProfession, UserAge
from UserDetails
end";

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

    public DataSet suserlogin(MasterMaintenanceVars ob) 
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select Login.UserName, Login.UserPassword,Login.UserRole
                         from Login where UserName=@UserName and userpassword=@userpassword";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserName", ob.UserName);
            sqlcmd.Parameters.AddWithValue("@UserPassword", ob.UserPassword);

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

    public DataSet sUserDetailsmobnowise(MasterMaintenanceVars ob)
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select UserId, UserName, UserMobile, UserEmail, 
       UserState, UserCity, UserGender, 
	   UserEducation, UserProfession, UserAge
from UserDetails
where UserMobile=@UserMobile";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserMobile", ob.UserMobile);

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

    public DataSet sUserDetailsemailwise(MasterMaintenanceVars ob) 
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select UserId, UserName, UserMobile, UserEmail, 
       UserState, UserCity, UserGender, 
	   UserEducation, UserProfession, UserAge
from UserDetails
where UserEmail=@UserEmail";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserEmail", ob.UserEmail);

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

    public bool iuserrating(MasterMaintenanceVars ob)
    {
        bool flag = false;

        try
        {
            sqlcon.Open();
            string q = @"if exists (select UserRatingId, UserId, ItemId, UserRating 
from UserRatings where UserId=@UserId and ItemId=@ItemId)
begin
update UserRatings set UserRating=@UserRating where UserId=@UserId and ItemId=@ItemId 
end
else
begin
insert into UserRatings(UserId, ItemId, UserRating) 
                 values(@UserId, @ItemId, @UserRating)
end";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserId", ob.UserId);
            sqlcmd.Parameters.AddWithValue("@ItemId", ob.ItemId);
            sqlcmd.Parameters.AddWithValue("@UserRating", ob.UserRating);

            if (sqlcmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }

        return flag;
    }

    public DataSet suseremailwiseitemratingsgraph(MasterMaintenanceVars ob)  
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"select UserDetails.UserEmail, ProductDetails.ItemName,
isnull(sum(UserRatings.UserRating),0) as ratings
from UserRatings inner join UserDetails
on UserDetails.UserId=UserRatings.UserId
inner join ProductDetails
on ProductDetails.ItemId=UserRatings.ItemId
where UserDetails.UserEmail=@UserEmail
group by UserDetails.UserEmail,ProductDetails.ItemName";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserEmail", ob.UserEmail);

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

    public DataSet sratingwiseitemratingsgraph(MasterMaintenanceVars ob)  
    {
        DataSet objds = new DataSet();
        SqlDataAdapter sda;
        try
        {
            sqlcon.Open();

            string q = @"declare @tbl table
(
ItemName nvarchar(40),
ratings int
)
insert into @tbl(ItemName,ratings)
select distinct ProductDetails.ItemName,
isnull(UserRatings.UserRating,0) as ratings
from UserRatings
right join ProductDetails
on ProductDetails.ItemId=UserRatings.ItemId

select ItemName,ratings
from @tbl
where ratings=@UserRating";

            SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.Parameters.AddWithValue("@UserRating", ob.UserRating);

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