using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MySql.Data.MySqlClient;
/// <summary>
/// Descrizione di riepilogo per MotivoCambio
/// </summary>
public class MotivoCambio
{
	public MotivoCambio()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}
    public void getMotivoCambio(Repeater rpt, SqlDataSource SqlInsMot,HtmlContainerControl divContenuto, string strSel, string valPrec, string valCorr)
    {
        strSel = strSel + "'0'";
        SqlInsMot.SelectCommand = "SELECT PrForm.DESC, PrForm.TABELLA, RlFormCampo.Campo, RlFormCampo.Descrizione, RlFormCampo.IdForm" +
            " FROM PrForm LEFT JOIN RlFormCampo ON PrForm.FORMID = RlFormCampo.IdForm Where IdForm=17 And Campo in (" + strSel + ")";
        SqlInsMot.DataBind();
        rpt.DataBind();
        string s = valPrec.Substring(0, valPrec.Length - 1);
        string[] campi = s.Split(',');
        string s1 = valCorr.Substring(0, valCorr.Length - 1);
        string[] campi1 = s1.Split(',');
        for (int i = 0; i < rpt.Items.Count; i++)
        {
            Label lblValPrec = rpt.Items[i].FindControl("lblValPrec") as Label;
            lblValPrec.Text = campi[i];
            Label lblValCorr = rpt.Items[i].FindControl("lblValCorr") as Label;
            lblValCorr.Text = campi1[i];
        }
        divContenuto.Visible = true;
    }
}
