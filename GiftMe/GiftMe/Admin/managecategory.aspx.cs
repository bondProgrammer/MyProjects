using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_managecategory : System.Web.UI.Page
{
    private void bg()
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet ds = new DataSet();

        ob2.CategoryId = 0;
        ds = ob1.scategorydatasearch(ob2);

        if (ds.Tables[0].Rows.Count > 0)
        {
            grvDetails.DataSource = ds.Tables[0];
            grvDetails.DataBind();
        }
        else
        {
            
        }
    }

    private void insert()
    {
        MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
        MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();
       
        if (string.IsNullOrEmpty(txtcategory.Text) || string.IsNullOrWhiteSpace(txtcategory.Text))
        {
             lblMessage.Text=" Please enter compulsory fields";
        }
        else
        {
            ob1.CategoryName = txtcategory.Text;
            
            if (ob2.icategorydata(ob1) == true)
            {
                lblMessage.Text="Category details added successfully";
                bg();
                txtcategory.Text = "";
            }
            else
            {
                lblMessage.Text="Category not added successfully";
            }
        }
    }

    private void update(GridViewUpdateEventArgs e)
    {
        MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
        MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();

        Label lblcdid = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblcategoryId");
        TextBox txtcd = (TextBox)grvDetails.Rows[e.RowIndex].FindControl("txtcategory");

        if (string.IsNullOrEmpty(txtcd.Text) || string.IsNullOrWhiteSpace(txtcd.Text))
        {
            lblMessage.Text="Please enter compulsory fields";
        }
        else
        {
            ob1.CategoryId = Convert.ToInt64(lblcdid.Text);
            ob1.CategoryName = txtcd.Text;
          
            if (ob2.ucategorydata(ob1) == true)
            {
                lblMessage.Text="Category details updated successfully";
              
                grvDetails.EditIndex = -1;
                bg();
            }
            else
            {
                lblMessage.Text="Category data not updated successfully";
            }
        }
    }

    private void delete(GridViewDeleteEventArgs e)
    {
        Label lblcdId = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblcategoryId");
        MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
        MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();

        ob1.CategoryId = Convert.ToInt64(lblcdId.Text);

        if (ob2.dcategorydata(ob1) == true)
        {
            lblMessage.Text="Category details deleted successfully";
            
            grvDetails.EditIndex = -1;
            bg();
        }
        else
        {
            lblMessage.Text="Category data not deleted successfully";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                bg();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            insert();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void grvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            bg();
            grvDetails.PageIndex = e.NewPageIndex;
            grvDetails.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void grvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            grvDetails.EditIndex = -1;
            bg();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void grvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            delete(e);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void grvDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            grvDetails.EditIndex = e.NewEditIndex;
            bg();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void grvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            update(e);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}