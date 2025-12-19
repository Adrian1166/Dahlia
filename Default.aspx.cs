using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdUtente"] != null)
        {
            AggiornaAccesso aggacc = new AggiornaAccesso();
            aggacc.getAggiornaAccesso(Session["pathDb"].ToString(), Session["IdUtente"].ToString(), "SI");
        }
        Session.Abandon();
        Server.ClearError();
        //Utility utility = new Utility();
        //string ConnString = utility.getStringConnection(Request.ApplicationPath);
        //Session["pathDb"] = ConnString;
        Session["TitoloPrg"] = "DAHLIA";
    }
}