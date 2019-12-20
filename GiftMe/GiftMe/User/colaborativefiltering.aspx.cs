using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_colaborativefiltering : System.Web.UI.Page
{
    public string itmid = "";
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

    public class Recommendation
    {
        public string Name { get; set; }
        public double Rating { get; set; }
    }

    static Dictionary<string, List<Recommendation>> productRecommendations = new Dictionary<string, List<Recommendation>>();

    static void Init()
    {
        List<Recommendation> list = new List<Recommendation>();
        list.Clear();
        productRecommendations.Clear();
        CFFUsers ob2 = new CFFUsers();
        DataSet ds1 = new DataSet();
        ds1 = ob2.alluser();

        CFVUsers ob3 = new CFVUsers();
        CFFUsers ob4 = new CFFUsers();
        DataSet ds2 = new DataSet();

        for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
        {
            ob3.UserId = Convert.ToInt32(ds1.Tables[0].Rows[i]["UserId"].ToString());
            ds2 = ob4.alluserswiseproduct(ob3);
            list = new List<Recommendation>();
            for (int j = 0; j <= ds2.Tables[0].Rows.Count - 1; j++)
            {
                list.Add(new Recommendation() { Name = ds2.Tables[0].Rows[j]["ItemId"].ToString(), Rating = Convert.ToInt32(ds2.Tables[0].Rows[j]["UserRating"].ToString()) });
            }
            productRecommendations.Add(ds1.Tables[0].Rows[i]["UserId"].ToString(), list);
        }
    }

    static IList<Recommendation> TopMatches(string name)
    {
        // grab of list of products that *excludes* the item we're searching for
        var sortedList = productRecommendations.Where(x => x.Key != name);

        sortedList.OrderByDescending(x => x.Key);

        List<Recommendation> recommendations = new List<Recommendation>();

        // go through the list and calculate the Pearson score for each product
        foreach (var entry in sortedList)
        {
            recommendations.Add(new Recommendation() { Name = entry.Key, Rating = CalculatePearsonCorrelation(name, entry.Key) });
        }

        return recommendations;
    }

    static double CalculatePearsonCorrelation(string product1, string product2)
    {
        
        List<Recommendation> shared_items = new List<Recommendation>();

        // collect a list of products have have reviews in common
        foreach (var item in productRecommendations[product1])
        {
            if (productRecommendations[product2].Where(x => x.Name == item.Name).Count() != 0)
            {
                shared_items.Add(item);
            }
        }


        if (shared_items.Count == 0)
        {
            // they have nothing in common exit with a zero
            return 0;
        }

        // sum up all the preferences
        double product1_review_sum = 0.00f;
        foreach (Recommendation item in shared_items)
        {
            product1_review_sum += productRecommendations[product1].Where(x => x.Name == item.Name).FirstOrDefault().Rating;
        }

        double product2_review_sum = 0.00f;
        foreach (Recommendation item in shared_items)
        {
            product2_review_sum += productRecommendations[product2].Where(x => x.Name == item.Name).FirstOrDefault().Rating;
        }

        // sum up the squares
        double product1_rating = 0f;
        double product2_rating = 0f;
        foreach (Recommendation item in shared_items)
        {
            product1_rating += Math.Pow(productRecommendations[product1].Where(x => x.Name == item.Name).FirstOrDefault().Rating, 2);
            product2_rating += Math.Pow(productRecommendations[product2].Where(x => x.Name == item.Name).FirstOrDefault().Rating, 2);
        }

        //sum up the products
        double critics_sum = 0f;
        foreach (Recommendation item in shared_items)
        {
            critics_sum += productRecommendations[product1].Where(x => x.Name == item.Name).FirstOrDefault().Rating *
                            productRecommendations[product2].Where(x => x.Name == item.Name).FirstOrDefault().Rating;

        }

        //calculate pearson score
        double num = critics_sum - (product1_review_sum * product2_review_sum / shared_items.Count);

        double density = (double)Math.Sqrt((product1_rating - Math.Pow(product1_review_sum, 2) / shared_items.Count) * ((product2_rating - Math.Pow(product2_review_sum, 2) / shared_items.Count)));

        if (density == 0)
            return 0;

        return num / density;
    }

    private void bg(string uid)
    {
        CFVUsers ob1 = new CFVUsers();
        CFFUsers ob2 = new CFFUsers();
        DataSet ds = new DataSet();

        ob1.CategoryId = Convert.ToInt64(ddlcategorysearch.SelectedValue.ToString());
        ob1.SubCategoryId = Convert.ToInt64(ddlsearch.SelectedValue.ToString());
        ob1.ItemId = Convert.ToInt64(ddlitemsearch.SelectedValue.ToString());
        ob1.UserIdS = uid;
        ds = ob2.collaborativefiltering(ob1);

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

    private void bg1()
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
            Init();
            string product = Session["UId"].ToString();
            CFVUsers ob1 = new CFVUsers();
            CFFUsers ob2 = new CFFUsers();
            DataSet ds1 = new DataSet();
            ob1.UserId = Convert.ToInt32(product);
            ds1 = ob2.alluserswiseproduct(ob1);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                itmid = "";
                var matches = TopMatches(product);
                foreach (var item in matches)
                {
                    if (item.Rating >= 0)
                    {
                        itmid = itmid + item.Name + ",";
                    }
                    else
                    {
                    }
                }

                bg(itmid);
            }
            else
            {
                bg1();
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
            Init();
            string product = "1";
            CFVUsers ob1 = new CFVUsers();
            CFFUsers ob2 = new CFFUsers();
            DataSet ds1 = new DataSet();
            ob1.UserId = Convert.ToInt32(product);
            ds1 = ob2.alluserswiseproduct(ob1);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                itmid = "";
                var matches = TopMatches(product);
                foreach (var item in matches)
                {
                    if (item.Rating >= 0)
                    {
                        itmid = itmid + item.Name + ",";
                    }
                    else
                    {
                    }
                }

                bg(itmid);
            }
            else
            {
                bg1();
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