using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MySql.Data.MySqlClient;
/// <summary>
/// Descrizione di riepilogo per AggiornaStato
/// </summary>
public class AggiornaStatoMonitor
{
    public AggiornaStatoMonitor()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public void getAggiornaStatoMonitor(string pathDb, string subjid, string idtipvis, string formid, string nometb)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "";
        string semidprec = "1";
        sql = "Select * from tbquery where IdPaziente=" + subjid + " And IdTipVis=" + idtipvis + " And IdForm=" + formid + " And StatoQuery=1 And TipoQuery=2";
        MySqlCommand cmd2 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr1 = cmd2.ExecuteReader();
        if (!rdr1.HasRows)
        {
            rdr1.Close();
            sql = "Select max(SEMID) from " + nometb + " where idpaziente=" + subjid + " And IDTIPVIS=" + idtipvis+" And SemID is not null";
            MySqlCommand cmd1 = new MySqlCommand(sql, cn);
            MySqlDataReader rdr = cmd1.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                semidprec = rdr[0].ToString();
            }
            rdr.Close();

            sql = "Update PrStat set SEMID=" + (semidprec == "" ? "0" : semidprec) + " where SUBJID=" + subjid + " And TIPVISID=" + idtipvis + " And FORMID=" + formid;
            MySqlCommand cmd = new MySqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
        else
        {
            rdr1.Close();
        }
        cn.Close();
    }
}
