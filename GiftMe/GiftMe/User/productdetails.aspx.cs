using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_productdetails : System.Web.UI.Page
{
    Int64 id = 0;

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

    private void details()
    {
        JaccardVars ob1 = new JaccardVars();
        JaccardF ob2 = new JaccardF();
        DataSet ds = new DataSet();

        if (string.IsNullOrEmpty(Request.QueryString[0].ToString()) || string.IsNullOrWhiteSpace(Request.QueryString[0].ToString()))
        {
            lblitemid.Text = "0";
        }
        else
        {
            lblitemid.Text = Request.QueryString[0].ToString();
        }
        ob1.ItemId = Convert.ToInt64(lblitemid.Text);
        ds = ob2.productidwise(ob1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            imgitem.ImageUrl = ds.Tables[0].Rows[0]["ImagePath"].ToString();
            lblitemname.InnerText = ds.Tables[0].Rows[0]["ItemName"].ToString();
            lblitemprice.InnerText = ds.Tables[0].Rows[0]["ItemPrice"].ToString();
        }
        else
        {
            imgitem.ImageUrl = null;
            lblitemname.InnerText = string.Empty;
            lblitemprice.InnerText = string.Empty;
        }
    }

    private void bg()
    {
        JaccardVars ob1 = new JaccardVars();
        JaccardF ob2 = new JaccardF();
        DataSet ds = new DataSet();

        ob1.ItemId = Convert.ToInt64(lblitemid.Text);
        ob1.UserId = Convert.ToInt64(Session["UId"].ToString());
        ds = ob2.jaccardcoefficientforuser(ob1);

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
            details();
            bg();
            bindrating(ddlrating);
        }
    }

    protected void btnrating_Click(object sender, EventArgs e)
    {
        try
        {
            MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
            MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();

            if (string.IsNullOrEmpty(ddlrating.Text) || string.IsNullOrWhiteSpace(ddlrating.Text) || ddlrating.SelectedIndex == 0 || ddlrating.SelectedIndex == -1)
            {
                lblMessage.Text = "Please select valid rating.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ob1.UserId = Convert.ToInt64(Session["UId"].ToString());
                ob1.ItemId = Convert.ToInt64(lblitemid.Text);
                ob1.UserRating = Convert.ToInt32(ddlrating.SelectedValue.ToString());

                if (ob2.iratings(ob1) == true)
                {
                    lblMessage.Text = "You have rated successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Please try again..";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }
}