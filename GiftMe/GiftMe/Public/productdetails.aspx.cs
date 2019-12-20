using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Public_productdetails : System.Web.UI.Page
{
    Int64 id = 0;
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
        ds = ob2.jaccardcoefficient(ob1);

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
        }
    }
}