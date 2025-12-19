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
public class TrovaQuery
{
    public TrovaQuery()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public bool getTrovaQuery(string pathDb, string subjid, string idtipvis, string formid)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "";
        bool queryEsiste = false;
        sql = "Select * from tbquery where IdPaziente=" + subjid + " And IDTIPVIS=" + idtipvis + " And IdForm=" + formid+" and Statoquery=1";
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            queryEsiste = true;
        }
        rdr.Close();
        cn.Close();
        return queryEsiste;
    }
}
