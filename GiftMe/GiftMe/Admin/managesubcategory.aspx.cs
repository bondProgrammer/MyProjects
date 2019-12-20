using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_managesubcategory : System.Web.UI.Page
{
    int i = 0;
    private void bg()
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet ds = new DataSet();

        ob2.CategoryId = 0;
        ob2.SubCategoryId = 0;
        ds = ob1.ssubcategorydatasearch(ob2);

        if (ds.Tables[0].Rows.Count > 0)
        {
            grvDetails.DataSource = ds.Tables[0];
            grvDetails.DataBind();
        }
        else
        {

        }
    }

    private void scategory(DropDownList ddl)
    {
        MasterMaintenanceCalls pll = new MasterMaintenanceCalls();
        MasterMaintenanceVars ple = new MasterMaintenanceVars();
        DataSet objds = new DataSet();

        objds = pll.scategorydata();

        if (objds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = objds.Tables[0];
            ddl.DataTextField = "CategoryName";
            ddl.DataValueField = "CategoryId";
            ddl.DataBind();
            //ddl.Items.Insert(0, new ListItem("--Select Category--", "0"));
        }
        else
        {
            selectblank(ddl);
        }
    }

    private void selectblank(DropDownList ddl)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        list.Add("--Select--", "0");

        ddl.DataSource = list;
        ddl.DataTextField = "Key";
        ddl.DataValueField = "Value";
        ddl.DataBind();
    }

    private void insert()
    {
        MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
        MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();

        if (string.IsNullOrEmpty(txtsubcategory.Text) || string.IsNullOrWhiteSpace(txtsubcategory.Text) || string.IsNullOrEmpty(ddlcategoryi.Text) || string.IsNullOrWhiteSpace(ddlcategoryi.Text) || ddlcategoryi.SelectedIndex == -1 || ddlcategoryi.Text == "--Select Category--")
        {
            lblMessage.Text = "Please enter compulsory fields";
        }
        else
        {
            ob1.CategoryId = Convert.ToInt64(ddlcategoryi.SelectedValue.ToString());
            ob1.SubCategory = txtsubcategory.Text;

            if (ob2.isubcategorydata(ob1) == true)
            {
                lblMessage.Text = "Sub category details added successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                bg();
                clearFields();
            }
            else
            {
                lblMessage.Text = "Sub category data not added successfully";
            }
        }
    }

    private void clearFields()
    {
        ddlcategoryi.SelectedIndex = 0;
        txtsubcategory.Text = "";
    }

    private void update(GridViewUpdateEventArgs e)
    {
        MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
        MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();

        Label lblscdid = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblsubCategoryId");
        TextBox txtscd = (TextBox)grvDetails.Rows[e.RowIndex].FindControl("txtsubCategory");
        DropDownList ddlc = (DropDownList)grvDetails.Rows[e.RowIndex].FindControl("ddlcategory");

        if (string.IsNullOrEmpty(txtscd.Text) || string.IsNullOrWhiteSpace(txtscd.Text) || string.IsNullOrEmpty(ddlc.Text) || string.IsNullOrWhiteSpace(ddlc.Text) || ddlc.SelectedIndex == -1 || ddlc.Text == "--Select Category--")
        {
            lblMessage.Text = "Please enter compulsory fields";
        }
        else
        {
            ob1.SubCategoryId = Convert.ToInt64(lblscdid.Text);
            ob1.CategoryId = Convert.ToInt64(ddlc.SelectedValue.ToString());
            ob1.SubCategory = txtscd.Text;

            if (ob2.usubcategorydata(ob1) == true)
            {
                lblMessage.Text = "Sub category details updated successfully";

                grvDetails.EditIndex = -1;
                bg();
            }
            else
            {
                lblMessage.Text = "Error occured during updating sub category details";
            }
        }
    }

    private void delete(GridViewDeleteEventArgs e)
    {
        Label lblscdId = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblsubCategoryId");
        MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
        MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();

        ob1.SubCategoryId = Convert.ToInt64(lblscdId.Text);

        if (ob2.dsubcategorydata(ob1) == true)
        {
            lblMessage.Text = "Sub category details deleted successfully";

            grvDetails.EditIndex = -1;
            bg();
        }
        else
        {
            lblMessage.Text = "Error occured during deleting sub category details";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                scategory(ddlcategoryi);
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

    protected void grvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (i == 0)
                {

                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    i = 1;
                    DropDownList ddl = (DropDownList)e.Row.FindControl("ddlcategory");

                    scategory(ddl);
                    ddl.SelectedValue = ((DataRowView)e.Row.DataItem)["cid"].ToString();
                }
            }
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