using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Admin_graphratingwiseproductrating : System.Web.UI.Page
{
    private void bg()
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet ds = new DataSet();

        ob2.UserRating = Convert.ToInt32(ddlratingsearch.SelectedValue.ToString());

        ds = ob1.sratingwiseitemratinggraph(ob2);

        if (ds.Tables[0].Rows.Count > 0)
        {
            grvDetails.Visible = true;
            grvDetails.DataSource = ds.Tables[0];
            grvDetails.DataBind();
        }
        else
        {
            grvDetails.Visible = false;
        }
    }

    private void bindrating(DropDownList ddl)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        list.Add("--Select Rating--", "--Select Rating--");
        list.Add("0", "0");
        list.Add("1", "1");
        list.Add("2", "2");
        list.Add("3", "3");
        list.Add("4", "4");
        list.Add("5", "5");

        ddl.DataSource = list;
        ddl.DataTextField = "Key";
        ddl.DataValueField = "Value";
        ddl.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                bindrating(ddlratingsearch);
            }
        }
        catch (Exception ex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: Fill correct data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
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
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: Fill correct data";
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
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
    }
}