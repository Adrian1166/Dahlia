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
/// Descrizione di riepilogo per MaxID
/// </summary>
public class ChiaveID
{
	public ChiaveID()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public string getChiaveID(string tabella, string id, string pathDb)
    {
        MySqlConnection cn = new MySqlConnection(pathDb);
        cn.Open();
        //MySqlConnection oleDb = new MySqlConnection();
        //oleDb.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Programmi/Tibotec/tibotecx/App_Data/Tibotec.mdb";
        //oleDb.Open();
        string sql = "Select max(" + id + ") as maxid from " + tabella;
        MySqlCommand cmd = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd.ExecuteReader();
        string maxidval = "0";
        if (rdr.HasRows)
        {
            rdr.Read();
            maxidval = rdr["maxid"].ToString();
        }
        rdr.Close();
        cn.Close();
        return maxidval;
    }
}
