using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
/// <summary>
/// Descrizione di riepilogo per dataVisita
/// </summary>
public class dataVisita
{
	public dataVisita()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public string getDataVisita(string subjid, string tipvisid, string pathDb)
    {
        string d = "";
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "Select DATVIS from TbVisita where IdPaziente=" + subjid + " And IDTIPVIS=" + tipvisid;
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            rdr.Read();
            d = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(rdr[0].ToString()));
        }
        rdr.Close();
        cn.Close();
        return d;
    }
}
