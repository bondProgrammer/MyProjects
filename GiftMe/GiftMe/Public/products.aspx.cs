using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Public_products : System.Web.UI.Page
{
    private void selectblank(DropDownList ddl)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        list.Add("--Select--", "0");

        ddl.DataSource = list;
        ddl.DataTextField = "Key";
        ddl.DataValueField = "Value";
        ddl.DataBind();
    }

    private void scategory(DropDownList ddl)
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet objds = new DataSet();

        objds = ob1.scategorydata();

        if (objds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = objds.Tables[0];
            ddl.DataTextField = "CategoryName";
            ddl.DataValueField = "CategoryId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            selectblank(ddl);
        }
    }

    private void ssubcategory(DropDownList ddl, DropDownList ddlcat)
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet objds = new DataSet();

        ob2.CategoryId = Convert.ToInt64(ddlcat.SelectedValue.ToString());
        objds = ob1.ssubcategorydatacidwise(ob2);

        if (objds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = objds.Tables[0];
            ddl.DataTextField = "SubCategory";
            ddl.DataValueField = "SubCategoryId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            selectblank(ddl);
        }
    }

    private void sitem(DropDownList ddl, DropDownList ddlscat)
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet objds = new DataSet();

        ob2.SubCategoryId = Convert.ToInt64(ddlscat.SelectedValue.ToString());
        objds = ob1.sProductDatascatidwise(ob2);

        if (objds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = objds.Tables[0];
            ddl.DataTextField = "ItemName";
            ddl.DataValueField = "ItemId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            selectblank(ddl);
        }
    }

    private void bg()
    {
        JaccardVars ob1 = new JaccardVars();
        JaccardF ob2 = new JaccardF();
        DataSet ds = new DataSet();


        ob1.CategoryId = Convert.ToInt64(ddlcategorysearch.SelectedValue.ToString());
        ob1.SubCategoryId = Convert.ToInt64(ddlsearch.SelectedValue.ToString());
        ob1.ItemId = Convert.ToInt64(ddlitemsearch.SelectedValue.ToString());
        ds = ob2.products(ob1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataList1.Visible = true;
            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();
        }
        else
        {
            DataList1.Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            scategory(ddlcategorysearch);
            ssubcategory(ddlsearch, ddlcategorysearch);
            sitem(ddlitemsearch, ddlsearch);
            bg();
        }
    }

    protected void ddlcategorysearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlcategorysearch.SelectedIndex == 0)
            {
                selectblank(ddlsearch);
                selectblank(ddlitemsearch);
            }
            else
            {
                ssubcategory(ddlsearch, ddlcategorysearch);
                selectblank(ddlitemsearch);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("String was not recognized as a valid DateTime."))
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "ERROR: Please enter correct date format(dd/mm/yyyy)";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "ERROR: Fill correct data";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void ddlsearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlsearch.SelectedIndex == 0)
            {
                selectblank(ddlitemsearch);
            }
            else
            {
                sitem(ddlitemsearch, ddlsearch);
            }
        }        
        catch (Exception ex)
        {
            if (ex.Message.Contains("String was not recognized as a valid DateTime."))
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "ERROR: Please enter correct date format(dd/mm/yyyy)";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "ERROR: Fill correct data";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
           
            bg();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("String was not recognized as a valid DateTime."))
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "ERROR: Please enter correct date format(dd/mm/yyyy)";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "ERROR: Fill correct data";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}