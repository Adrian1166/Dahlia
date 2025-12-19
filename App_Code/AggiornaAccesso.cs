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
/// Descrizione di riepilogo per AggiornaAccesso
/// </summary>
public class AggiornaAccesso
{
	public AggiornaAccesso()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public void getAggiornaAccesso(string pathDb, string IdUtente, string logOff)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "";
        if (logOff == "SI")
        {
            sql = "Update tbutente set DataAccUtente=null where IdUtente=" + IdUtente;
        }
        else
        {
            sql = "Update tbutente set DataAccUtente=Now() where IdUtente=" + IdUtente;
        }
        MySqlCommand cmd = new MySqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}
