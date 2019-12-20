using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Public_signup : System.Web.UI.Page
{
    private void selectblank(DropDownList ddl)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        list.Add("--Select--", "--Select--");

        ddl.DataSource = list;
        ddl.DataTextField = "Key";
        ddl.DataValueField = "Value";
        ddl.DataBind();
    }

    private void bindage(DropDownList ddl)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        list.Add("--Select Age--", "--Select Age--");
        list.Add("0-5", "0-5");
        list.Add("6-10", "6-10");
        list.Add("11-15", "11-15");
        list.Add("16-20", "16-20");
        list.Add("21-25", "21-25");
        list.Add("26-30", "26-30");
        list.Add("31-35", "31-35");
        list.Add("36-40", "36-40");
        list.Add("41-45", "41-45");
        list.Add("46-50", "46-50");
        list.Add("51-55", "51-55");
        list.Add("56-60", "56-60");
        list.Add("61-65", "61-65");
        list.Add("66-70", "66-70");
        list.Add("71-75", "71-75");
        list.Add("76-80", "76-80");
        list.Add("81-85", "81-85");
        list.Add("86-90", "86-90");
        list.Add("91-95", "91-95");
        list.Add("96-100", "96-100");
       
        ddl.DataSource = list;
        ddl.DataTextField = "Key";
        ddl.DataValueField = "Value";
        ddl.DataBind();
    }

    private void bindeducation(DropDownList ddl)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        list.Add("--Select Education--", "--Select Education--");
        list.Add("10th", "10th");
        list.Add("12th", "12th");
        list.Add("BA", "BA");
        list.Add("BCOM", "BCOM");
        list.Add("BCA", "BCA");
        list.Add("BCS", "BCS");
        list.Add("BSC", "BSC");
        list.Add("BTECH", "BTECH");
        list.Add("BPHARM", "BPHARM");
        list.Add("BE", "BE");

        ddl.DataSource = list;
        ddl.DataTextField = "Key";
        ddl.DataValueField = "Value";
        ddl.DataBind();
    }

    private void bindprofession(DropDownList ddl)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        list.Add("--Select Profession--", "--Select Profession--");
        list.Add("Student", "Student");
        list.Add("Teacher", "Teacher");

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
                bindage(ddlage);
                bindeducation(ddleducation);
                bindprofession(ddlprofession);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void insert()
    {
        MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob1 = new MasterMaintenanceVars();

        if (string.IsNullOrEmpty(ddlage.Text) || string.IsNullOrWhiteSpace(ddlage.Text) || ddlage.SelectedIndex == 0 || ddlage.SelectedIndex == -1 || string.IsNullOrEmpty(ddleducation.Text) || string.IsNullOrWhiteSpace(ddleducation.Text) || ddleducation.SelectedIndex == 0 || ddleducation.SelectedIndex == -1 || string.IsNullOrEmpty(ddlprofession.Text) || string.IsNullOrWhiteSpace(ddlprofession.Text) || ddlprofession.SelectedIndex == 0 || ddlprofession.SelectedIndex == -1)
        {
            lblMessage.Text = "Please select compulsory fields";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            ob1.UserName = txtName.Text;
            ob1.UserMobile = txtMobile.Text;
            ob1.UserEmail = txtEmail.Text;
            ob1.UserState = "";
            ob1.UserCity = "";
            if (rbtnfemale.Checked)
            {
                ob1.UserGender = "Female";
            }
            else
            {
                ob1.UserGender = "Male";
            }
            ob1.UserEducation = ddleducation.SelectedValue.ToString();
            ob1.UserProfession = ddlprofession.SelectedValue.ToString();
            ob1.UserAge = ddlage.SelectedValue.ToString();
            ob1.UserRole = "user";
            ob1.UserPassword = txtpassword.Text;

            if (ob2.iUserDetails(ob1) == true)
            {
                lblMessage.Text = "You have registered successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Your registration failed.Please try again..";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
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
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}