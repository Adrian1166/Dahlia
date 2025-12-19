using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
/// <summary>
/// Descrizione di riepilogo per utente
/// </summary>
public class Utente
{
    string tmpNome;
    string tmpCognome;
    string tmpUserID;
    string tmpPsw;
    string tmpIdCentro;
    string tmpSiteID;
    string tmpDescSite;
    string tmpCitta;
    string tmpIdStato;
    string tmpPrimario;
    string tmpDataAccUtente;
    string tmpDataPrimoAcc;
    string tmpPricipalInvest;
	public Utente()
	{
        
	}

    public string getUtente(string user,string psw, string pathDb)
    {
        Cripta crp = new Cripta();
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "Select *" +
        " FROM TBUTENTE Inner join TBCENTRI on TBUTENTE.IdCentro=TBCENTRI.IdCentro where Utente='" + user.Replace("'", "''") + "' and Password1='" + crp.getMD5Hash(psw.Replace("'", "''")) + "'";

        MySqlCommand cmd = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.HasRows)
        {
            rdr.Read();
            tmpNome = rdr["NOME"].ToString();
            tmpCognome = rdr["COGNOME"].ToString();
            tmpUserID = rdr["IdUtente"].ToString();
            tmpPsw = rdr["Password1"].ToString();
            tmpIdCentro = rdr["IdCentro"].ToString();
            tmpSiteID = rdr["NumCentro"].ToString();
            tmpDescSite = rdr["Descrizione"].ToString();
            tmpCitta = rdr["Citta"].ToString();
            tmpIdStato = rdr["IdStato"].ToString();
            tmpPrimario = rdr["Primario"].ToString();
            tmpDataAccUtente = rdr["DataAccUtente"].ToString();
            tmpDataPrimoAcc = rdr["DataScadenzaPsw"].ToString();
            tmpPricipalInvest = rdr["PricipalInvest"].ToString();
            string livelliid = rdr["IdLivello"].ToString();
            rdr.Close();
            cn.Close();
            return livelliid;
        }
        else
        {
            rdr.Close();
            cn.Close();
            return "";
        }
    }


    public string Nominativo
    {
        get
        {
            return tmpNome + " " + tmpCognome;
        }
        set { Nominativo = value; }
    }

    public string UserID
    {
        get
        {
            return tmpUserID;
        }
        set { UserID = value; }
    }

    public string PswUte
    {
        get
        {
            return tmpPsw;
        }
        set { PswUte = value; }
    }

    public string IdCentro
    {
        get
        {
            return tmpIdCentro;
        }
        set { IdCentro = value; }
    }
    public string SiteID
    {
        get
        {
            return tmpSiteID;
        }
        set { SiteID = value; }
    }

    public string IdStato
    {
        get
        {
            return tmpIdStato;
        }
        set { IdStato = value; }
    }

    public string DescSite
    {
        get
        {
            return tmpDescSite;
        }
        set { DescSite = value; }
    }

    public string Primario
    {
        get
        {
            return tmpPrimario;
        }
        set { Primario = value; }
    }

    public string Citta
    {
        get
        {
            return tmpCitta;
        }
        set { Citta = value; }
    }

    public string DataAccUtente
    {
        get
        {
            return tmpDataAccUtente;
        }
        set { DataAccUtente = value; }
    }

    public string DataPrimoAcc
    {
        get
        {
            return tmpDataPrimoAcc;
        }
        set { DataPrimoAcc = value; }
    }

    public string PricipalInvest
    {
        get
        {
            return tmpPricipalInvest;
        }
        set { PricipalInvest = value; }
    }
    
}
