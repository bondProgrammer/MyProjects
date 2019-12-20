using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Public_signin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();
            MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            MasterMaintenanceCalls ob4 = new MasterMaintenanceCalls();
            MasterMaintenanceVars ob3 = new MasterMaintenanceVars();

            ob1.UserName = txtusername.Text;
            ob1.UserPassword = txtPassword.Text;
            ds = ob2.sulogin(ob1);

            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblerror1.Text = "Please Enter Compulsary Fields.";
            }
            else
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (txtusername.Text == ds.Tables[0].Rows[0]["UserName"].ToString() && txtPassword.Text == ds.Tables[0].Rows[0]["UserPassword"].ToString())
                    {
                        if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "admin")
                        {
                            Session.Add("Email", "admin");
                            Session.Add("UId", "0");
                            Response.Redirect("../Admin/managecategory.aspx");
                            lblerror1.Text = "";
                        }
                        else
                            if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "user")
                            {
                                ob3.UserEmail = txtusername.Text;
                                ds1 = ob4.sUserDetailsemailwisedata(ob3);
                                Session.Add("Email", ds1.Tables[0].Rows[0]["UserEmail"].ToString());
                                Session.Add("UId", ds1.Tables[0].Rows[0]["UserId"].ToString());
                                Response.Redirect("../User/home.aspx");
                                lblerror1.Text = "";
                            }
                            else
                            {
                                lblerror1.Text = "You have enterd wrong username or password.";
                                Response.Redirect("login.aspx");
                            }
                    }
                    else
                    {
                        lblerror1.Text = "You have enterd wrong username or password.";
                    }
                }
                else
                {
                    lblerror1.Text = "Record(s) not found.";
                }
            }
        }
        catch (Exception ex)
        {
            lblerror1.Text = ex.Message;
        }
    }
}