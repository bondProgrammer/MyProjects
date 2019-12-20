using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CFFUsers
/// </summary>
public class CFFUsers
{
	public CFFUsers()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    CFDUser obj = new CFDUser();

    public DataSet allusersrating()
    {
        return obj.allusersratings();
    }

    public DataSet alluser()
    {
        return obj.allusers();
    }

    public DataSet alluserswiseproduct(CFVUsers ob) 
    {
        return obj.alluserswiseproducts(ob);
    }

    public DataSet collaborativefiltering(CFVUsers ob)
    {
        return obj.collaborativefilterings(ob);
    }
}