using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterMaintenanceCalls
/// </summary>
public class MasterMaintenanceCalls
{
	public MasterMaintenanceCalls()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    MasterMaintenanceData obj = new MasterMaintenanceData();

    public bool icategorydata(MasterMaintenanceVars ob)
    {
        return obj.icategorydetails(ob);
    }

    public bool ucategorydata(MasterMaintenanceVars ob)
    {
        return obj.ucategorydetails(ob);
    }

    public bool dcategorydata(MasterMaintenanceVars ob)
    {
        return obj.dcategorydetails(ob);
    }

    public DataSet scategorydata()
    {
        return obj.scategorydetails();
    }

    public DataSet scategorydatasearch(MasterMaintenanceVars ob)
    {
        return obj.scategorydetailssearch(ob);
    }

    public bool isubcategorydata(MasterMaintenanceVars ob)
    {
        return obj.isubcategorydetails(ob);
    }

    public bool usubcategorydata(MasterMaintenanceVars ob)
    {
        return obj.usubcategorydetails(ob);
    }

    public bool dsubcategorydata(MasterMaintenanceVars ob)
    {
        return obj.dsubcategorydetails(ob);
    }

    public DataSet ssubcategorydata()
    {
        return obj.ssubcategorydetails();
    }

    public DataSet ssubcategorydatasearch(MasterMaintenanceVars ob)
    {
        return obj.ssubcategorydetailssearch(ob);
    }

    public DataSet ssubcategorydatacidwise(MasterMaintenanceVars ob)
    {
        return obj.ssubcategorydetailscidwise(ob);
    }

    public bool iProductData(MasterMaintenanceVars ob)
    {
        return obj.iProductDetails(ob);
    }

    public bool uProductData(MasterMaintenanceVars ob)
    {
        return obj.uProductDetails(ob);
    }

    public bool dProductData(MasterMaintenanceVars ob)
    {
        return obj.dProductDetails(ob);
    }

    public DataSet sProductData()
    {
        return obj.sProductDetails();
    }

    public DataSet sProductDatasearch(MasterMaintenanceVars ob)
    {
        return obj.sProductDetailssearch(ob);
    }

    public DataSet sProductDatascatidwise(MasterMaintenanceVars ob)
    {
        return obj.sProductDetailsscatidwise(ob);
    }

    public DataSet sProductDatasitemidwise(MasterMaintenanceVars ob)
    {
        return obj.sProductDetailssitemidwise(ob);
    }

    public DataSet sProductDatascatidmcatwise(MasterMaintenanceVars ob)
    {
        return obj.sProductDetailsscatidmcatwise(ob);
    }

    public bool iUserDetails(MasterMaintenanceVars ob)
    {
        return obj.iUserDetails(ob);
    }

    public bool uUserDetails(MasterMaintenanceVars ob)
    {
        return obj.uUserDetails(ob);
    }

    public bool dUserDetails(MasterMaintenanceVars ob)
    {
        return obj.dUserDetails(ob);
    }

    public DataSet sUserDetails()
    {
        return obj.sUserDetails();
    }

    public DataSet sUserDetailsidwisedata(MasterMaintenanceVars ob)
    {
        return obj.sUserDetailsidwise(ob);
    }

    public DataSet sulogin(MasterMaintenanceVars ob)
    {
        return obj.suserlogin(ob);
    }

    public DataSet sUserDetailsmobnowisedata(MasterMaintenanceVars ob)
    {
        return obj.sUserDetailsmobnowise(ob);
    }

    public DataSet sUserDetailsemailwisedata(MasterMaintenanceVars ob)
    {
        return obj.sUserDetailsemailwise(ob); 
    }

    public bool iratings(MasterMaintenanceVars ob)
    {
        return obj.iuserrating(ob);
    }

    public DataSet suseremailwiseitemratinggraph(MasterMaintenanceVars ob) 
    {
        return obj.suseremailwiseitemratingsgraph(ob);
    }

    public DataSet sratingwiseitemratinggraph(MasterMaintenanceVars ob)
    {
        return obj.sratingwiseitemratingsgraph(ob);
    }
}