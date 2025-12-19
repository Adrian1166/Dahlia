using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class studyDocuments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lnkGestioneQuery.PostBackUrl = "~/ssl/gestioneQuery.aspx?FormID=2&Form=elencoPazienti.aspx&IDTIPVIS=0&nomeVisit=&Pagina=&SemId=";
    }
}
