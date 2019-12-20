using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JaccardF
/// </summary>
public class JaccardF
{
	public JaccardF()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    Jaccarddata obj = new Jaccarddata();

    public DataSet products(JaccardVars ob)
    {
        return obj.productdetails(ob);
    }

    public DataSet subcats()
    {
        return obj.subcategorydetails();
    }

    public DataSet productidwise(JaccardVars ob)
    {
        return obj.productidwisedetails(ob);
    }

    public DataSet jaccardcoefficient(JaccardVars ob) 
    {
        return obj.jaccardcoe(ob);
    }

    public DataSet jaccardcoefficientforuser(JaccardVars ob)
    {
        return obj.jaccardcoeforuser(ob);
    }
}