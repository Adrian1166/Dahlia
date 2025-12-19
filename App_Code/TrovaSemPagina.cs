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
/// Descrizione di riepilogo per TrovaSemPagina
/// </summary>
public class TrovaSemPagina
{
	public TrovaSemPagina()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public string getTrovaSemPagina(string pathDb, string tabella, string idpaziente, string idtipvis)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string tmpSemPag = "1";
        string sql = "Select * FROM " + tabella + " where idpaziente=" + idpaziente + " and idtipvis=" + idtipvis;

        MySqlCommand cmd = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.HasRows)
        {
            while (rdr.Read())
            {
                if (rdr["SemId"].ToString() == "6")
                {
                    tmpSemPag = "2";
                    break;
                }
                if (rdr["SemId"].ToString() == "2" && tmpSemPag == "1")
                {
                    tmpSemPag = "2";
                }
                if (rdr["SemId"].ToString() == "3" && tmpSemPag == "1")
                {
                    tmpSemPag = "3";
                }
                if ((rdr["SemId"].ToString() == "2" && tmpSemPag == "3") || (rdr["SemId"].ToString() == "3" && tmpSemPag == "2"))
                {
                    tmpSemPag = "6";
                    break;
                }
                tmpSemPag = rdr["SemId"].ToString();
            }
            rdr.Close();
            cn.Close();
            return tmpSemPag;
        }
        else
        {
            rdr.Close();
            cn.Close();
            return "";
        }
        
        
    }
}
