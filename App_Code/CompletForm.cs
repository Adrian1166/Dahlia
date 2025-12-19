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
/// Descrizione di riepilogo per CompletForm
/// </summary>
public class CompletForm
{
	public CompletForm()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public bool getCompletForm(string studio, string subjid, string tipvisid, string pathDb)
    {
        bool d = false;
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "Select SEMID from " + studio + "_PrStat where subjid=" + subjid + " And TIPVISID=" + tipvisid + " And semid not in (1,5,6) and FormId<>0";
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        d= !rdr.HasRows;
        rdr.Close();
        cn.Close();
        return d;
    }
}
