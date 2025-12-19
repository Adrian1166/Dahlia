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
/// Descrizione di riepilogo per ScriviQuery
/// </summary>
public class ScriviQuery
{
	public ScriviQuery()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public void getPulisciQuery(string pathDb, string subjid, string idtipvis, string formid, string idmsg)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "";

        sql = "update TBQuery set StatoQuery=2,ChiusoDa=1 where IdPaziente=" + subjid + " and IdForm=" + formid + " and IdTipVis=" + idtipvis + " and TipoQuery=1 and StatoQuery=1";
        if (idmsg != "")
        {
            sql = sql + " And IdTxtQry=" + idmsg;
        }
        MySqlCommand cmd = new MySqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        cn.Close();
    }

    public void getScriviQuery(string pathDb, string subjid, string idtipvis, string formid, string idcentro, string campo, string idmsg)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "";
        string testoQuery = "";


        sql = "Select msg from lsmsg where MsgId=" + idmsg;
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            rdr.Read();
            testoQuery = rdr[0].ToString();
        }
        rdr.Close();
        
        sql = "INSERT INTO TBQuery (IdCentro, IdPaziente, IdTipVis, IdForm, Campo, DataQuery, TipoQuery, StatoQuery, IdTxtQry, TestoQuery, IdChiave)" +
                    " Values (" + idcentro + ", " + subjid + ", " + idtipvis + ", " + formid + ", '" + campo + "', NOW(), 1, 1, " + idmsg + ", '" + testoQuery.Replace("'", "''") + "', 0)";
        MySqlCommand cmd = new MySqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        cn.Close();
    }

    public bool getEsisteQuery(string pathDb, string subjid, string idtipvis, string formid, string idmsg)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        bool EsisteQuery = false;

        string sql = "Select * from TBQuery where IdPaziente=" + subjid + " and IdForm=" + formid + " and IdTipVis=" + idtipvis + " and TipoQuery=1 and IdTxtQry=" + idmsg + " And StatoQuery=1";
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            EsisteQuery = true;
        }
        rdr.Close();
        cn.Close();
        return EsisteQuery;
    }
}
