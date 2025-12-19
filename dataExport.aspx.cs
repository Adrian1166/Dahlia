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
using InfoSoftGlobal;
using Utilities;
using MySql.Data.MySqlClient;
using System.Text;


public partial class DataExport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AggiornaAccesso aggacc = new AggiornaAccesso();
        aggacc.getAggiornaAccesso(Session["pathDb"].ToString(), Session["IdUtente"].ToString(), "NO");
        lnkGestioneQuery.PostBackUrl = "~/ssl/gestioneQuery.aspx?FormID=0&Form=DataExport.aspx&Pagina=Data Export&nomeVisit=&IDTIPVIS=0&SemId=";
        //btnQuestionario.Visible = false;

        if (IsPostBack) return;
    }

    protected void btnExport_Click(object sender, CommandEventArgs e)
    {
        DownloadTabella(e.CommandName, e.CommandArgument.ToString());
    }

    protected void DownloadTabella(string Tabella, string descrizione)
    {
        SqlTutte.SelectCommand = "Select * from " + Tabella + " where IdCentro<>1";
        SqlTutte.DataBind();
        grwTutte.DataBind();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=" + Tabella + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        htmlWrite.WriteLine("<strong><font size='4'>" + descrizione + "</font></strong>");
        // viene reindirizzato il rendering verso la stringa in uscita 
        grwTutte.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void btnExportLabIni_Click(object sender, CommandEventArgs e)
    {
        SqlTutte.SelectCommand = "SELECT IdEsame,Esame,tbLABORTUMOR.* FROM  tbLABORTUMOR" +
            " right JOIN lsesame ON (tbLABORTUMOR.TLABTUMOR_MATERIAL_ID = lsesame.IdEsame) where IdCentro=" + Session["IdCentro"].ToString() + " And tbLABORTUMOR.IdInicialDiagnosis is not null";
        SqlTutte.DataBind();
        grwTutte.DataBind();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=tbLABORTUMOR_InicialDiagnosis.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        htmlWrite.WriteLine("<strong><font size='4'>" + e.CommandArgument.ToString() + " - Inicial Diagnosis</font></strong>");
        // viene reindirizzato il rendering verso la stringa in uscita 
        grwTutte.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void btnExportLabFU_Click(object sender, CommandEventArgs e)
    {
        SqlTutte.SelectCommand = "SELECT IdEsame,Esame,tbLABORTUMOR.* FROM  tbLABORTUMOR" +
            " right JOIN lsesame ON (tbLABORTUMOR.TLABTUMOR_MATERIAL_ID = lsesame.IdEsame) where IdCentro=" + Session["IdCentro"].ToString() + " And  tbLABORTUMOR.IdFUVisit is not null";
        SqlTutte.DataBind();
        grwTutte.DataBind();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=tbLABORTUMOR_FUVisit.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        htmlWrite.WriteLine("<strong><font size='4'>" + e.CommandArgument.ToString() + " - FU Visit</font></strong>");
        // viene reindirizzato il rendering verso la stringa in uscita 
        grwTutte.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void SelezionaCentro(object sender, EventArgs e)
    {
        CheckBox chk = sender as CheckBox;
        //for (int i = 0; i < chkForm.Items.Count; i++)
        //{
        //    chkForm.Items[i].Selected = (chk.Checked);
        //}
    }

    protected override void Render(HtmlTextWriter writer)
    {
        // Ensure that the control is nested in a server form.
        if (Page != null)
        {
            Page.VerifyRenderingInServerForm(this);
        }
        base.Render(writer);
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        //Do nothing
    }
}
