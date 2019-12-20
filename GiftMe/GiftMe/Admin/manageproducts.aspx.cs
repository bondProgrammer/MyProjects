using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manageproducts : System.Web.UI.Page
{
    Int64 midno = 0;
    Int64 ii = 0;
    Int64 u = 0;
    Int64 d = 0;
    int i = 0;

    private void bg()
    {
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        DataSet ds = new DataSet();

        ob2.CategoryId = Convert.ToInt64(ddlcategorysearch.SelectedValue.ToString());
        ob2.SubCategoryId = Convert.ToInt64(ddlsearch.SelectedValue.ToString());
        ob2.ItemId = Convert.ToInt64(ddlitemsearch.SelectedValue.ToString());

        ds = ob1.sProductDatasearch(ob2); 

        if (ds.Tables[0].Rows.Count > 0)
        {
            grvDetails.DataSource = ds.Tables[0];
            grvDetails.DataBind();
        }
        else
        {
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

    private void insert()
    {
        MasterMaintenanceVars ob1 = new MasterMaintenanceVars();
        MasterMaintenanceCalls ob2 = new MasterMaintenanceCalls();
        
        Label lblitemId = (Label)grvDetails.FooterRow.FindControl("lblitemId");
        TextBox txtitem = (TextBox)grvDetails.FooterRow.FindControl("txtfitem");
        TextBox txtitemPrice = (TextBox)grvDetails.FooterRow.FindControl("txtfitemPrice");
        FileUpload fu = (FileUpload)grvDetails.FooterRow.FindControl("ffu");

        if (string.IsNullOrEmpty(txtitem.Text) || string.IsNullOrWhiteSpace(txtitem.Text) || string.IsNullOrEmpty(ddlcategorysearch.Text) || string.IsNullOrWhiteSpace(ddlcategorysearch.Text) || ddlcategorysearch.SelectedIndex == 0 || ddlcategorysearch.SelectedIndex == -1 || ddlcategorysearch.Text == "--Select--" || string.IsNullOrEmpty(ddlsearch.Text) || string.IsNullOrWhiteSpace(ddlsearch.Text) || ddlsearch.SelectedIndex == 0 || ddlsearch.SelectedIndex == -1 || ddlsearch.Text == "--Select--")
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "Please enter compulsory fields";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            ob1.CategoryId = Convert.ToInt64(ddlcategorysearch.SelectedValue.ToString());
            ob1.SubCategoryId = Convert.ToInt64(ddlsearch.SelectedValue.ToString());
            ob1.ItemName = txtitem.Text;
            ob1.ItemPrice = Convert.ToDecimal(txtitemPrice.Text);
            ob1.ImagePath = Session["imgup"].ToString();
            ob1.ImageName = Session["imgupn"].ToString();
          
            if (ob2.iProductData(ob1) == true)
            {
                lblmsgu.Text = "Item details added successfully";
                lblmsgu1.Text = "";
                lblmsgu.ForeColor = System.Drawing.Color.Green;
                scategory(ddlcategorysearch);
                ssubcategory(ddlsearch, ddlcategorysearch);
                sitem(ddlitemsearch, ddlsearch);
                bg();
            }
            else
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "Error occured during adding item details";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    private int footeruf(FileUpload fu, System.Web.UI.WebControls.Image Image1)
    {
        try
        {
            if (fu.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fu.FileName);
                string ext = extension.ToLower();

                if (ext == ".jpg" || ext == ".png")
                {
                    string fname = "";
                    string fp = "";

                    string ex = Path.GetExtension(fu.PostedFile.FileName);
                    string fn = Path.GetFileName(fu.PostedFile.FileName);

                    string[] split = fn.Split('.');
                    string name = "";
                    int i = 1;
                    foreach (string str in split)
                    {
                        if (i == 1)
                        {
                            name = str;
                        }
                        if (i == 2)
                        {
                            i = 1;
                        }
                        i = i + 1;
                    }
                    Random rnd = new Random();
                    int db = rnd.Next(1000, 2000);
                    int rn = rnd.Next(500, 4000);
                    int rd = rnd.Next(3000, 4000);
                    fname = "d" + db.ToString() + "v" + rn.ToString() + "r" + rd.ToString() + "itemimages";

                    #region file upload

                    string targetPath = Server.MapPath(@"..\itemimages\");
                    Bitmap originalBMP = new Bitmap(fu.FileContent);

                    // Calculate the new image dimensions
                    int origWidth = originalBMP.Width;
                    int origHeight = originalBMP.Height;
                    int sngRatio = origWidth / origHeight;
                    int newWidth = 397;
                    int newHeight = 467;

                    // Create a new bitmap which will hold the previous resized bitmap
                    Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
                    // Create a graphic based on the new bitmap
                    Graphics oGraphics = Graphics.FromImage(newBMP);

                    // Set the properties for the new graphic file
                    oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    // Draw the new graphic based on the resized bitmap
                    oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

                    // Save the new graphic file to the server
                    newBMP.Save(targetPath + fname + ex);

                    // Once finished with the bitmap objects, we deallocate them.


                    #endregion

                    Image1.ImageUrl = "../itemimages/" + fname + ex;
                    string img = "../itemimages/" + fname + ex;
                    Session.Add("imgup", img);
                    Session.Add("imgupn", fname);

                    originalBMP.Dispose();
                    newBMP.Dispose();
                    oGraphics.Dispose();
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "";
                    lblerrormsgfu.Text = "";
                    return 1;
                }
                else
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "";
                    lblerrormsgfu.Text = "ERROR: Upload only JPG or PNG file.";
                    lblerrormsgfu.ForeColor = System.Drawing.Color.Red;
                    Session.Add("imgup", "");
                    Session.Add("imgupn", "");
                    Session.Add("imgup", "");
                    return 0;
                }
            }
            else
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "";
                lblerrormsgfu.Text = "ERROR: File does not exist.";
                lblerrormsgfu.ForeColor = System.Drawing.Color.Red;
                Session.Add("imgup", "");
                Session.Add("imgupn", "");
                Session.Add("imgup", "");
                return 0;
            }
        }
        catch
        {
            Session.Add("imgup", "");
            Session.Add("imgupn", "");
            return 0;
        }
    }

    private int df(string str)
    {
        try
        {
            string comob2tePath = Server.MapPath(str);
            if (System.IO.File.Exists(comob2tePath))
            {
                System.IO.File.Delete(comob2tePath);
                d = 1;
                return 1;
            }
            else
            {
                d = 0;
                return 0;
            }
        }
        catch
        {
            d = 0;
            return 0;
        }
    }

    private void fugrv(GridViewCommandEventArgs e)
    {
        try
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString().Trim());
            FileUpload fu = (FileUpload)grvDetails.Rows[rowIndex].FindControl("fu");
            Label lblip = (Label)grvDetails.Rows[rowIndex].FindControl("lblip");
            Label lblin = (Label)grvDetails.Rows[rowIndex].FindControl("lblin");
            System.Web.UI.WebControls.Image im = (System.Web.UI.WebControls.Image)grvDetails.Rows[rowIndex].FindControl("img1");

            if (fu.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fu.FileName);
                string ext = extension.ToLower();

                if (ext == ".jpg" || ext == ".png")
                {
                    string fname = "";

                    string ex = Path.GetExtension(fu.PostedFile.FileName);
                    string fn = Path.GetFileName(fu.PostedFile.FileName);

                    string[] split = fn.Split('.');
                    string name = "";
                    int i = 1;
                    foreach (string str in split)
                    {
                        if (i == 1)
                        {
                            name = str;
                        }
                        if (i == 2)
                        {
                            i = 1;
                        }
                        i = i + 1;
                    }
                    Random rnd = new Random();
                    int db = rnd.Next(1000, 2000);
                    int rn = rnd.Next(500, 4000);
                    int rd = rnd.Next(3000, 4000);
                    fname = "d" + db.ToString() + "v" + rn.ToString() + "r" + rd.ToString() + "itemimages";
                    Session.Add("up", "../itemimages/" + fname + ex);
                    Session.Add("upn", fname);

                    #region file upload

                    string targetPath = Server.MapPath(@"..\itemimages\");
                    Bitmap originalBMP = new Bitmap(fu.FileContent);

                    // Calculate the new image dimensions
                    int origWidth = originalBMP.Width;
                    int origHeight = originalBMP.Height;
                    int sngRatio = origWidth / origHeight;
                    int newWidth = 397;
                    int newHeight = 467;

                    // Create a new bitmap which will hold the previous resized bitmap
                    Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
                    // Create a graphic based on the new bitmap
                    Graphics oGraphics = Graphics.FromImage(newBMP);

                    // Set the properties for the new graphic file
                    oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    // Draw the new graphic based on the resized bitmap
                    oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

                    // Save the new graphic file to the server
                    newBMP.Save(targetPath + fname + ex);

                    // Once finished with the bitmap objects, we deallocate them.


                    #endregion

                    im.ImageUrl = "../itemimages/" + fname + ex;
                    try
                    {
                        df(lblip.Text);
                    }
                    catch
                    {
                    }
                    originalBMP.Dispose();
                    newBMP.Dispose();
                    oGraphics.Dispose();

                    lblmsgu.Text = "Image uploaded successfully.";
                    lblmsgu1.Text = "";
                    lblerrormsgfu.Text = "";
                    lblmsgu.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Session.Add("up", "");
                    Session.Add("upn", "");
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "";
                    lblerrormsgfu.Text = "ERROR: Upload only JPG or PNG file.";
                    lblerrormsgfu.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Session.Add("up", "");
                Session.Add("upn", "");
                lblmsgu.Text = "";
                lblmsgu1.Text = "";
                lblerrormsgfu.Text = "ERROR: File does not exist.";
                lblerrormsgfu.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch
        {
            lblerrormsgfu.Text = "";
            lblmsgu.Text = "";
            lblmsgu1.Text = "Error occured during uploading image.";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void update(GridViewUpdateEventArgs e)
    {
        MasterMaintenanceVars ob2 = new MasterMaintenanceVars();
        MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();
        string img = string.Empty;
        string simg = string.Empty;

        Label lblitemId = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblitemId");
        TextBox txtitem = (TextBox)grvDetails.Rows[e.RowIndex].FindControl("txtitem");
        TextBox txtitemPrice = (TextBox)grvDetails.Rows[e.RowIndex].FindControl("txtitemPrice");
        Label lblip = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblip");
        Label lblin = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblin");
        FileUpload fu = (FileUpload)grvDetails.Rows[e.RowIndex].FindControl("fu");

        if (string.IsNullOrEmpty(txtitem.Text) || string.IsNullOrWhiteSpace(txtitem.Text) || string.IsNullOrEmpty(ddlcategorysearch.Text) || string.IsNullOrWhiteSpace(ddlcategorysearch.Text) || ddlcategorysearch.SelectedIndex == 0 || ddlcategorysearch.SelectedIndex == -1 || ddlcategorysearch.Text == "--Select--" || string.IsNullOrEmpty(ddlsearch.Text) || string.IsNullOrWhiteSpace(ddlsearch.Text) || ddlsearch.SelectedIndex == 0 || ddlsearch.SelectedIndex == -1 || ddlsearch.Text == "--Select--")
        {

            lblmsgu.Text = "";
            lblmsgu1.Text = "Please enter compulsory fields";

            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            ob2.ItemId = Convert.ToInt64(lblitemId.Text);
            ob2.CategoryId = Convert.ToInt64(ddlcategorysearch.SelectedValue.ToString());
            ob2.SubCategoryId = Convert.ToInt64(ddlsearch.SelectedValue.ToString());
            ob2.ItemName = txtitem.Text;
            ob2.ItemPrice = Convert.ToDecimal(txtitemPrice.Text);
            if (string.IsNullOrEmpty(Session["up"] as string) || string.IsNullOrEmpty(Session["up"].ToString()) || string.IsNullOrWhiteSpace(Session["up"].ToString()))
            {
                ob2.ImagePath = lblip.Text;
                ob2.ImageName = lblin.Text;
            }
            else
            {
                ob2.ImagePath = Session["up"].ToString();
                ob2.ImageName = Session["upn"].ToString();
            }
          
            if (ob1.uProductData(ob2) == true)
            {
                lblmsgu1.Text = "";
                lblmsgu.Text = "Item details updated successfully";
                lblmsgu.ForeColor = System.Drawing.Color.Green;
                Session.Add("imgup1", "");

                scategory(ddlcategorysearch);
                ssubcategory(ddlsearch, ddlcategorysearch);
                sitem(ddlitemsearch, ddlsearch);
                grvDetails.EditIndex = -1;
                bg();
            }
            else
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "Error occured during updating item details";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                scategory(ddlcategorysearch);
                ssubcategory(ddlsearch, ddlcategorysearch);
                sitem(ddlitemsearch, ddlsearch);

                bg();
            }
        }
        catch (SqlException sqlex)
        {
            if (sqlex.Number.Equals(2627))
            {
                if (sqlex.Message.Contains("PRIMARY KEY"))
                {


                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                    if (sqlex.Message.Contains("UNIQUE KEY"))
                    {


                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: Fill correct data";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
            }
            else
                if (sqlex.Message.Contains("datetime"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Incorrect date format(dd/mm/yyyy)..";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Fill correct data";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
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
        catch (SqlException sqlex)
        {
            if (sqlex.Number.Equals(2627))
            {
                if (sqlex.Message.Contains("PRIMARY KEY"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                    if (sqlex.Message.Contains("UNIQUE KEY"))
                    {


                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: Fill correct data";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
            }
            else
                if (sqlex.Message.Contains("datetime"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Incorrect date format(dd/mm/yyyy)..";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Fill correct data";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
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
        catch (SqlException sqlex)
        {
            if (sqlex.Number.Equals(2627))
            {
                if (sqlex.Message.Contains("PRIMARY KEY"))
                {


                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                    if (sqlex.Message.Contains("UNIQUE KEY"))
                    {


                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: Fill correct data";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
            }
            else
                if (sqlex.Message.Contains("datetime"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Incorrect date format(dd/mm/yyyy)..";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Fill correct data";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
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

    protected void AddNew(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Session["imgup"] as string) || string.IsNullOrEmpty(Session["imgup"].ToString()) || string.IsNullOrWhiteSpace(Session["imgup"].ToString()))
            {

                lblmsgu.Text = "";
                lblmsgu1.Text = "Upload file first";

                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                insert();
            }
        }
        catch (SqlException sqlex)
        {
            if (sqlex.Number.Equals(2627))
            {
                if (sqlex.Message.Contains("PRIMARY KEY"))
                {


                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                    if (sqlex.Message.Contains("UNIQUE KEY"))
                    {


                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: Fill correct data";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
            }
            else
                if (sqlex.Message.Contains("datetime"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Incorrect date format(dd/mm/yyyy)..";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Fill correct data";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
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

    protected void grvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            bg();
            grvDetails.PageIndex = e.NewPageIndex;
            grvDetails.DataBind();
        }
        catch (SqlException sqlex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
        catch (Exception ex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void grvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            grvDetails.EditIndex = -1;
            bg();
        }
        catch (SqlException sqlex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
        catch (Exception ex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void grvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "up")
            {
                fugrv(e);
            }
            else if (e.CommandName == "fup")
            {
                FileUpload fu = (FileUpload)grvDetails.FooterRow.FindControl("ffu");
                System.Web.UI.WebControls.Image im = (System.Web.UI.WebControls.Image)grvDetails.FooterRow.FindControl("imgf1");
                int fi = footeruf(fu, im);
                if (fi == 1)
                {

                    lblmsgu.Text = "File uploaded successfully";
                    lblmsgu1.Text = "";

                    lblmsgu.ForeColor = System.Drawing.Color.Green;
                }
                else
                {

                    lblmsgu.Text = "";
                    lblmsgu1.Text = "Error occured during file uploading";

                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (SqlException sqlex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
        catch (Exception ex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void grvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    i = 1;

                    Label lblct = (Label)e.Row.FindControl("lblct");
                    Label lblsct = (Label)e.Row.FindControl("lblsct");

                    scategory(ddlcategorysearch);

                    ddlcategorysearch.SelectedValue = (lblct.Text);

                    ssubcategory(ddlsearch, ddlcategorysearch);

                    ddlsearch.SelectedValue = lblsct.Text;
                }
            }
        }
        catch (SqlException sqlex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
        catch (Exception ex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void grvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label lblid = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblitemId");
            Label lbli = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblip");
            Label lblin = (Label)grvDetails.Rows[e.RowIndex].FindControl("lblin");

            MasterMaintenanceVars dso = new MasterMaintenanceVars();
            MasterMaintenanceCalls ob1 = new MasterMaintenanceCalls();

            dso.ItemId = Convert.ToInt64(lblid.Text);
            try
            {
                df(lbli.Text);
            }
            catch
            {
            }
            if (ob1.dProductData(dso) == true)
            {
                lblmsgu1.Text = "";
                lblmsgu.Text = "Item details deleted successfully";
                lblmsgu.ForeColor = System.Drawing.Color.Green;

                grvDetails.EditIndex = -1;
                bg();
            }
            else
            {
                lblmsgu.Text = "";
                lblmsgu1.Text = "Error occured during updating item details";
                lblmsgu1.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (SqlException sqlex)
        {
            if (sqlex.Number.Equals(2627))
            {
                if (sqlex.Message.Contains("PRIMARY KEY"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                    if (sqlex.Message.Contains("UNIQUE KEY"))
                    {


                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: Fill correct data";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
            }
            else
                if (sqlex.Message.Contains("datetime"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Incorrect date format(dd/mm/yyyy)..";
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

    protected void grvDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session.Add("up", "");
            Session.Add("upn", "");
            grvDetails.EditIndex = e.NewEditIndex;
            bg();
        }
        catch (SqlException sqlex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
        catch (Exception ex)
        {
            lblmsgu.Text = "";
            lblmsgu1.Text = "ERROR: problem in loading data";
            lblmsgu1.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void grvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            update(e);
        }
        catch (SqlException sqlex)
        {
            if (sqlex.Number.Equals(2627))
            {
                if (sqlex.Message.Contains("PRIMARY KEY"))
                {


                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                    if (sqlex.Message.Contains("UNIQUE KEY"))
                    {


                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: Fill correct data";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
            }
            else
                if (sqlex.Message.Contains("datetime"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Incorrect date format(dd/mm/yyyy)..";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Fill correct data";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
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
        catch (SqlException sqlex)
        {
            if (sqlex.Number.Equals(2627))
            {
                if (sqlex.Message.Contains("PRIMARY KEY"))
                {


                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                    if (sqlex.Message.Contains("UNIQUE KEY"))
                    {


                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: You have enterd duplicate value";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblmsgu.Text = "";
                        lblmsgu1.Text = "ERROR: Fill correct data";
                        lblmsgu1.ForeColor = System.Drawing.Color.Red;
                    }
            }
            else
                if (sqlex.Message.Contains("datetime"))
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Incorrect date format(dd/mm/yyyy)..";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblmsgu.Text = "";
                    lblmsgu1.Text = "ERROR: Fill correct data";
                    lblmsgu1.ForeColor = System.Drawing.Color.Red;
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
}