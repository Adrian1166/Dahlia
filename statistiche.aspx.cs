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


public partial class statistiche : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AggiornaAccesso aggacc = new AggiornaAccesso();
        aggacc.getAggiornaAccesso(Session["pathDb"].ToString(), Session["IdUtente"].ToString(), "NO");
        //lnkComments.PostBackUrl = "ssl/areautente/scambioInfo.aspx?FormID=0&Form=studyDocuments.aspx&Pagina=Documenti&nomeTbVisita=&IDTIPVIS=0&SemId=";
        //btnQuestionario.Visible = false;
        CreateChart();
        lnkGestioneQuery.PostBackUrl = "~/ssl/gestioneQuery.aspx?FormID=2&Form=elencoPazienti.aspx&IDTIPVIS=0&nomeVisit=&Pagina=&SemId=";
    }

    public void CreateChart()
    {
         SqlCentro.SelectCommand = "SELECT count(idPaziente) as totpaz, tbCentri.* from tbCentri" +
                            " LEFT JOIN TbPazienti on tbCentri.idCentro=TbPazienti.idCentro where NumCentro not in ('00','99') group by tbCentri.idCentro order by NumCentro";
        SqlCentro.DataBind();
        Repeater3.DataBind();
        double totarru = 0;
        for (int i = 0; i < Repeater3.Items.Count; i++)
        {
            RepeaterItem r = Repeater3.Items[i];
            Label lblTotPaz = r.FindControl("lblTotPaz") as Label;
            if (lblTotPaz.Text != "")
            {
                totarru = totarru + Convert.ToDouble(lblTotPaz.Text);
            }
        }
        lblTotale.Text = totarru.ToString();

    }
    protected void CreaTabelleTotali(object sender, EventArgs e)
    {
        string sql = "SELECT tbpazienti.IdPaziente,Primario, NumPaz, " +
                  "tbvisita1.DatVis as V1, " +
                  "if(tbvisita2.DatVis is not null,'', Date_ADD(tbvisita1.DatVis,INTERVAL 10 MONTH)) as V1_10, if(tbvisita2.DatVis is not null,'', Date_ADD(tbvisita1.DatVis,INTERVAL 14 MONTH)) as V1_14," +
                  "if(tbvisita2.DatVis is null, Date_ADD(tbvisita1.DatVis,INTERVAL 12 MONTH), tbvisita2.DatVis) as V2, if(tbvisita3.DatVis is not null,'',Date_ADD(tbvisita1.DatVis,INTERVAL 22 MONTH)) as V2_22, " +
                  "if(tbvisita3.DatVis is not null,'',Date_ADD(tbvisita1.DatVis,INTERVAL 26 MONTH)) as V2_26, if(tbvisita3.DatVis is null, Date_ADD(tbvisita1.DatVis,INTERVAL 2 YEAR), tbvisita3.DatVis) as V3,"+
                  "if(tbvisita2.DatVis is null And Now()>Date_ADD(tbvisita1.DatVis,INTERVAL 1 YEAR),1,0) as V1_Rosso,"+
                  "if(tbvisita3.DatVis is null And Now()>Date_ADD(tbvisita1.DatVis,INTERVAL 2 YEAR),1,0) as V2_Rosso";
        sql = sql + " FROM tbcentri " +
        " inner JOIN tbpazienti ON (tbcentri.IdCentro = tbpazienti.IdCentro)" +
        " left JOIN tbvisita ON (tbpazienti.IdPaziente = tbvisita.IdPaziente And tbvisita.idtipvis=1)" +
        " left JOIN tbvisita tbvisita1 ON (tbpazienti.IdPaziente = tbvisita1.IdPaziente And tbvisita1.idtipvis=2)" +
        " left JOIN tbvisita tbvisita2 ON (tbpazienti.IdPaziente = tbvisita2.IdPaziente And tbvisita2.idtipvis=3 and tbvisita2.Presentato=1)" +
        " left JOIN tbvisita tbvisita3 ON (tbpazienti.IdPaziente = tbvisita3.IdPaziente And tbvisita3.idtipvis=4)" +
        " where tbcentri.NumCentro not in ('00','99')" +
        " Order BY NumPaz";
        SqlTotale.SelectCommand = sql;
        SqlTotale.DataBind();
        grwTotale.DataBind();
        for (int i = 0; i < grwTotale.Rows.Count; i++)
        {
            GridViewRow gvr = grwTotale.Rows[i];
            Label img1 = new Label();
            for (int j = 1; j < 4; j++)
            {
                int g = 1;
                switch (j)
                {
                    case 1:
                        g = 3;
                        break;
                    case 2:
                        g = 7;
                        break;
                    case 3:
                        g = 11;
                        break;
                }
                img1 = gvr.Cells[g].FindControl("img" + j) as Label;

                if (img1.Text.IndexOf("Non effettuata") > -1)
                {
                    img1.Text = "";
                }
                if (img1.Text.IndexOf("Completa") > -1)
                {
                    gvr.Cells[g].BackColor = System.Drawing.Color.FromArgb(0,146, 208, 80);
                    img1.Text = "";
                }
                if (img1.Text.IndexOf("Incompleta") > -1)
                {
                    if (img1.Text.IndexOf("0/") > -1 && img1.Text.IndexOf("10/") == -1)
                    {
                        gvr.Cells[g].BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        gvr.Cells[g].BackColor = System.Drawing.Color.Yellow;
                        
                    }
                }
                if (img1.Text.IndexOf("Frezze") > -1)
                {
                    img1.ForeColor = System.Drawing.Color.Blue;
                }
                if (img1.Text.IndexOf("Visita lock") > -1)
                {
                    img1.ForeColor = System.Drawing.Color.OrangeRed;
                }
                Label lblV1_10 = gvr.Cells[4].FindControl("lblV1_10") as Label;
                Label lblV2 = gvr.Cells[5].FindControl("lblV2") as Label;
                //Response.Write(lblV1_10.Text+"-"+lblV2.Text+"<br>");
                if (lblV1_10.Text == "" && lblV2.Text != "" && g == 7)
                {
                    if (img1.Text.IndexOf("Incompleta") > -1 && g == 7)
                    {
                        lblV2.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblV2.ForeColor = System.Drawing.Color.Blue;
                    }
                }
                Label lblV2_22 = gvr.Cells[8].FindControl("lblV2_22") as Label;
                Label lblV3 = gvr.Cells[9].FindControl("lblV3") as Label;
                //Response.Write(lblV1_10.Text+"-"+lblV2.Text+"<br>");
                if (lblV2_22.Text == "" && lblV3.Text != "" && g == 11)
                {
                    if (img1.Text.IndexOf("Incompleta") > -1 && g == 11)
                    {
                        lblV3.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblV3.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }

        }
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Export1.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        htmlWrite.WriteLine();
        //calcolo il totale dei pazienti
        //htmlWrite.WriteLine("<strong><font size='4'>Studio Test&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Totale pazienti: " + TotalePaz + "</font></strong>");
        // viene reindirizzato il rendering verso la stringa in uscita 
        grwTotale.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected string TrovaSemVisita(string visita, string idpaz, string tipvis)
    {
        string pathSem = "Non effettuata";
        if (visita != "" && idpaz != "")
        {
            MySqlConnection cn;
            cn = new MySqlConnection(Session["pathDb"].ToString());
            cn.Open();
            string sql = "";
            if (tipvis != "99")
            {
                sql = "Select PrStat.SEMID,Presentato from PrStat inner join tbvisita on (tbvisita.idpaziente=PrStat.subjid" +
                    " and tbvisita.IDTIPVIS=PrStat.TIPVISID) where subjid=" + idpaz + " And (PrStat.semid=2 or PrStat.semid=0) and FormId<>0 and TIPVISID=" + tipvis;
            }
            else
            {
                sql = "Select PrStat.SEMID,1 as Presentato from PrStat where subjid=" + idpaz + " And (PrStat.semid=2 or PrStat.semid=0) and FormId<>0 and TIPVISID=" + tipvis;
            }
            MySqlCommand cmd1 = new MySqlCommand(sql, cn);
            MySqlDataReader rdr = cmd1.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                if (rdr["Presentato"].ToString() != "1" && tipvis != "2" && tipvis != "1")
                {
                    pathSem = "Non effettuata";
                }
                else
                {
                    pathSem = "Incompleta";
                }
                rdr.Close();
            }
            else
            {
                rdr.Close();
                sql = "Select * from tbvisita where IdPaziente=" + idpaz + " And IdTipVis=" + tipvis;
                MySqlCommand cmdV = new MySqlCommand(sql, cn);
                MySqlDataReader rdrV = cmdV.ExecuteReader();
                if (rdrV.HasRows)
                {
                    pathSem = "Completa";
                }
                rdrV.Close();
            }
            
            if (pathSem != "Non effettuata")
            {
                sql = "Select SEMID from PrStat where subjid=" + idpaz + " and FormId=0 and TIPVISID=" + tipvis;
                MySqlCommand cmd2 = new MySqlCommand(sql, cn);
                MySqlDataReader rdr1 = cmd2.ExecuteReader();
                if (rdr1.HasRows)
                {
                    rdr1.Read();
                    if (rdr1[0].ToString() == "5")
                    {
                        pathSem = "Frozen";
                    }
                    if (rdr1[0].ToString() == "6")
                    {
                        pathSem = "Visita lock";
                    }
                }
                rdr1.Close();

            }
            sql = "Select count(PrStat.SEMID) from PrStat where subjid=" + idpaz + " And PrStat.semid in (1,5,6) and FormId<>0 and FormId<>20 and TIPVISID=" + tipvis;
            MySqlCommand cmdF = new MySqlCommand(sql, cn);
            MySqlDataReader rdrF = cmdF.ExecuteReader();
            rdrF.Read();
            switch (tipvis)
            {
                case "2":
                    pathSem = pathSem + " (" + rdrF[0].ToString() + "/12)";
                    break;
                case "3":
                    pathSem = pathSem + " (" + rdrF[0].ToString() + "/10)";
                    break;
                case "4":
                    pathSem = pathSem + " (" + rdrF[0].ToString() + "/10)";
                    break;
            }
            rdrF.Close();
            cn.Close();
        }
        else
        {
            pathSem = "";
        }
        return pathSem;
    }
    protected System.Drawing.Color TrovaColore(string V1_Rosso, string idpaz)
    {
        System.Drawing.Color pathSem= System.Drawing.Color.Black;
        if (V1_Rosso == "0")
        {
            for (int i = 0; i < grwTotale.Rows.Count; i++)
            {
                Response.Write(grwTotale.DataKeys[i].Value.ToString() + "-" + idpaz+"<br>");
                if (grwTotale.DataKeys[i].Value.ToString() == idpaz)
                {
                    
                    Label img2 = grwTotale.Rows[i].Cells[5].FindControl("img2") as Label;
                    if (img2.Text.IndexOf("Completa") == -1)
                    {
                        pathSem = System.Drawing.Color.Blue;
                    }
                    break;
                }
            }
        }
        return pathSem;
    }
    protected void CreaTabelleAE(object sender, EventArgs e)
    {
        SqlAE.SelectCommand = "SELECT Primario, concat('\"',NumCentro,'\"') as newNumCentro, TbCentri.Descrizione, Citta, NumPaz, " +
                  "if(IdCorrelazione=1,'non correlato','correlato') as Correlazione,Trattamento,Classificazione,esito,intensita,TbAe.Descrizione as newDesc, TbAE.*" +
        " FROM ((((((TbCentri " +
        " inner JOIN TbPazienti ON TbCentri.IdCentro = TbPazienti.IdCentro)" +
        " inner JOIN TbAE ON TbPazienti.IdPaziente = TbAE.IdPaziente)" +
        " left join ae_lsClassificazione on TbAE.idClassificazione=ae_lsClassificazione.IdClassificazione)" +
        " left JOIN ae_lstrattamento ON TbAE.IdTrattamento = ae_lstrattamento.IdTrattamento)" +
        " left JOIN ae_lsesito ON TbAE.Idesito = ae_lsesito.Idesito)" +
       " left JOIN ae_lsintensita ON TbAE.Idintensita = ae_lsintensita.Idintensita)" +
        " Order BY TbCentri.NumCentro, TbCentri.Descrizione, Citta, NumPaz";
        SqlAE.DataBind();
        grwAE.DataBind();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Export1.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        htmlWrite.WriteLine();
        //calcolo il totale dei pazienti

        htmlWrite.WriteLine("<strong><font size='4'>Studio Test - Tracking safety event " + String.Format("{0:MMMM}", DateTime.Today) + " " + DateTime.Today.Year + "</font></strong>");
        // viene reindirizzato il rendering verso la stringa in uscita 
        grwAE.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void CreaTabellaCRSwNP(object sender, EventArgs e)
    {
        SqlCRSwNP.SelectCommand = "SELECT Primario, NumPaz, " +
                  " if(tbCRSwNP.Comorbid=1,'Yes',if(tbCRSwNP.Comorbid=2,'No','')) as Comorbid1," +
                  "if(tbCRSwNP2.Comorbid=1,'Yes',if(tbCRSwNP2.Comorbid=2,'No','')) as Comorbid2,"+
                  "if(tbCRSwNP3.Comorbid=1,'Yes',if(tbCRSwNP3.Comorbid=2,'No','')) as Comorbid3"+
        " FROM TbCentri " +
        " inner JOIN TbPazienti ON TbCentri.IdCentro = TbPazienti.IdCentro" +
        " left JOIN tbCRSwNP ON (TbPazienti.IdPaziente = tbCRSwNP.IdPaziente And tbCRSwNP.IdTipVis=2)" +
        " left JOIN tbCRSwNP as tbCRSwNP2 ON (TbPazienti.IdPaziente = tbCRSwNP2.IdPaziente And tbCRSwNP2.IdTipVis=3)" +
        " left JOIN tbCRSwNP as tbCRSwNP3 ON (TbPazienti.IdPaziente = tbCRSwNP3.IdPaziente And tbCRSwNP3.IdTipVis=4)" +
        " where tbcentri.NumCentro not in ('00','99')" +
        " Order BY NumPaz";
        SqlCRSwNP.DataBind();
        grwCRSwNP.DataBind();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Export1.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        htmlWrite.WriteLine();
        //calcolo il totale dei pazienti

        // viene reindirizzato il rendering verso la stringa in uscita 
        grwCRSwNP.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void CreaTabelleUscita(object sender, EventArgs e)
    {
        SqlCS.SelectCommand = "SELECT Primario, concat('\"',NumCentro,'\"')  as newNumCentro, Descrizione, Citta, NumPaz, " +
                  " MotivoUscita,if(StudioCompletato=2,'Si','No') as DropOut,tbuscitastudio.*" +
        " FROM (((TbCentri " +
        " inner JOIN TbPazienti ON TbCentri.IdCentro = TbPazienti.IdCentro)" +
        " inner JOIN tbuscitastudio ON TbPazienti.IdPaziente = tbuscitastudio.IdPaziente)" +
        " left JOIN lsmotivouscita ON tbuscitastudio.IdMotivoUscita = lsmotivouscita.IdMotivoUscita)" +
        " Order BY TbCentri.NumCentro, Descrizione, Citta, NumPaz";
        SqlCS.DataBind();
        grwCS.DataBind();
        Response.Clear();
         Response.AddHeader("content-disposition", "attachment;filename=Export1.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        htmlWrite.WriteLine();
        //calcolo il totale dei pazienti

        htmlWrite.WriteLine("<strong><font size='4'>Studio Test - Conclusione dello studio " + String.Format("{0:MMMM}", DateTime.Today) + " " + DateTime.Today.Year + "</font></strong>");
        // viene reindirizzato il rendering verso la stringa in uscita 
        grwCS.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
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
