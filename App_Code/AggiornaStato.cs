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
public class AggiornaStato
{
	public AggiornaStato()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public void getAggiornaStato(string pathDb, string subjid, string idtipvis, string formid, string semid)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "";
        string semidprec = "";
        sql = "Select SEMID from PrStat where subjid=" + subjid + " And TIPVISID=" + idtipvis + " And FORMID=" + formid;
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            rdr.Read();
            semidprec = rdr[0].ToString();
        }
        rdr.Close();
        if (semidprec != "3" || formid == "20")
        {
            sql = "Update PrStat set SEMID=" + semid + " where SUBJID=" + subjid + " And TIPVISID=" + idtipvis + " And FORMID=" + formid;
            MySqlCommand cmd = new MySqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
        cn.Close();
    }
}
