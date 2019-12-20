using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manageuser : System.Web.UI.Page
{
    private void bg()
    {
        MasterMaintenanceData ob1 = new MasterMaintenanceData();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet ds = new DataSet();

        ds = ob1.sUserDetails();

        if (ds.Tables[0].Rows.Count > 0)
        {
            grvDetails.DataSource = ds.Tables[0];
            grvDetails.DataBind();
        }
        else
        {
        }
    }

    private void delete(GridViewDeleteEventArgs e)
    {
        Label lblUserId = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblUserId");
        MasterMaintenanceData ob1 = new MasterMaintenanceData();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();

        ob2.UserId = Convert.ToInt64(lblUserId.Text);

        if (ob1.dUserDetails(ob2) == true)
        {
            lblmsgu1.Text = "";
            lblmsgu.Text = "User deleted successfully";
            lblmsgu.ForeColor = System.Drawing.Color.Green;

            grvDetails.EditIndex = -1;
            bg();
        }
        else
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "User not deleted successfully";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
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
            lblmsgu.Text = "";
            lblmsgu1.Text = ex.Message;
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
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
            lblmsgu.Text = "";
            lblmsgu1.Text = ex.Message;
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
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
            lblmsgu.Text = "";
            lblmsgu1.Text = ex.Message;
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }

    }
}