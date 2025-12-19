using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descrizione di riepilogo per AuditTrial
/// </summary>
public class AuditTrial
{
	public AuditTrial()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public void getAuditTrial(string tabella, string pathDb, string IdUtente, string chiave, string chiaveVal, string typeoper, string valMotivo)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "Select * from tb" + tabella;
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        string str = "";
        for (int i = 0; i < rdr.FieldCount; i++)
        {
            str = str + "," + rdr.GetName(i).ToString();
        }
        rdr.Close();
        str = str.Substring(1);
        sql = "Insert into lg" + tabella + "(DataModifica,IdUtente, Operazione," + str + ",MotivoModifica) Select now()," + IdUtente + ",'" + typeoper + "'," + str + ",'" + valMotivo.Replace("'", "''") + "' from tb" + tabella + " Where " + chiave + "=" + chiaveVal;
        MySqlCommand cmd = new MySqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}
