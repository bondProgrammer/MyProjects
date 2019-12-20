using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Admin_graphuserwiseproductratings : System.Web.UI.Page
{
    private void bg()
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet ds = new DataSet();

        ob2.UserEmail = (ddlusersearch.SelectedValue.ToString());

        ds = ob1.suseremailwiseitemratinggraph(ob2);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Chart1.Visible = true;
            foreach (Series s in Chart1.Series)
            {
                s.ToolTip = "Product: #VALX\nRating: #VALY";
            }
            Chart1.DataSource = ds.Tables[0];
            Chart1.Series["Series1"].XValueMember = "ItemName";
            Chart1.Series["Series1"].YValueMembers = "ratings";
            Chart1.DataBind();
        }
        else
        {
            Chart1.Visible = false;
        }
    }

    private void selectblank(DropDownList ddl)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        list.Add("--Select--", "--Select--");

        ddl.DataSource = list;
        ddl.DataTextField = "Key";
        ddl.DataValueField = "Value";
        ddl.DataBind();
    }

    private void suser(DropDownList ddl)
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet objds = new DataSet();

        objds = ob1.sUserDetails();

        if (objds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = objds.Tables[0];
            ddl.DataTextField = "UserEmail";
            ddl.DataValueField = "UserEmail";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "--Select--"));
        }
        else
        {
            selectblank(ddl);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                suser(ddlusersearch);
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
}