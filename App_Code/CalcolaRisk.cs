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
/// Descrizione di riepilogo per CalcolaRisk
/// </summary>
public class CalcolaRisk
{
	public CalcolaRisk()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}
    public string getCalcolaRisk(string IdPaziente, string pathDb)
    {
        MySqlConnection cn;
        cn = new MySqlConnection(pathDb);
        cn.Open();
        string sql = "";
        string Sesso = "0";
        string Tabagismo = "0";
        string Eta = "0";
        string Sitting1_M = "";
        string RatioCol = "";
        string risk = "";
        sql = "SELECT tbpazienti.Sesso, tbpazienti.Eta, tbpressione.Sitting1_M," +
                    "tbesamilab.RatioCol, tbanamnesi.Tabagismo FROM tbpazienti" +
                     " INNER JOIN tbpressione ON (tbpazienti.IdPaziente = tbpressione.IdPaziente)" +
                     " INNER JOIN tbesamilab ON (tbpazienti.IdPaziente = tbesamilab.IdPaziente)" +
                     " INNER JOIN tbanamnesi ON (tbpazienti.IdPaziente = tbanamnesi.IdPaziente)" +
                     " Where tbpazienti.IdPaziente=" + IdPaziente;
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            rdr.Read();
            Sesso = rdr["Sesso"].ToString();
            Tabagismo = rdr["Tabagismo"].ToString();
            Eta = rdr["Eta"].ToString();
            Sitting1_M = rdr["Sitting1_M"].ToString();
            RatioCol = rdr["RatioCol"].ToString();
            if (Sesso != "0" && Tabagismo != "0" && Eta != "0" && Sitting1_M != "" && RatioCol != "")
            {
                string campo = "M";
                if (Sesso == "2")
                {
                    campo = "D";
                }
                if (Tabagismo == "1")
                {
                    campo = campo + "_F";
                }
                else
                {
                    campo = campo + "_N";
                }
                if (Convert.ToInt16(RatioCol) > 7)
                {
                    RatioCol = "7";
                }
                if (Convert.ToInt16(RatioCol) < 3)
                {
                    RatioCol = "3";
                }
                campo = campo + "_" + RatioCol;
                if (Convert.ToInt16(Sitting1_M) < 140)
                {
                    Sitting1_M = "120";
                }
                if (Convert.ToInt16(Sitting1_M) >= 140 && Convert.ToInt16(Sitting1_M) < 160)
                {
                    Sitting1_M = "140";
                }
                if (Convert.ToInt16(Sitting1_M) >= 160 && Convert.ToInt16(Sitting1_M) < 180)
                {
                    Sitting1_M = "160";
                }
                if (Convert.ToInt16(Sitting1_M) >= 180)
                {
                    Sitting1_M = "180";
                }
                if (Convert.ToInt16(Eta) < 50)
                {
                    Eta = "40";
                }
                if (Convert.ToInt16(Eta) >= 50 && Convert.ToInt16(Eta) < 55)
                {
                    Eta = "50";
                }
                if (Convert.ToInt16(Eta) >= 55 && Convert.ToInt16(Eta) < 60)
                {
                    Eta = "55";
                }
                if (Convert.ToInt16(Eta) >= 60 && Convert.ToInt16(Eta) < 65)
                {
                    Eta = "60";
                }
                if (Convert.ToInt16(Eta) >= 65)
                {
                    Eta = "65";
                }
                rdr.Close();
                sql = "Select " + campo + " from lsrisk where eta=" + Eta + " And Pressione=" + Sitting1_M;
                MySqlCommand cmd2 = new MySqlCommand(sql, cn);
                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                rdr2.Read();
                risk = rdr2[campo].ToString();
                switch (risk)
                {
                    case "0":
                        risk = "7";
                        break;
                    case "1":
                        risk = "6";
                        break;
                    case "2":
                        risk = "5";
                        break;
                    case "3":
                    case "4":
                        risk = "4";
                        break;
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        risk = "3";
                        break;
                    case "10":
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                        risk = "2";
                        break;
                    default:
                        risk = "1";
                        break;
                }
                rdr2.Close();
            }
            else
            {
                rdr.Close();
            }
        }
        else
        {
            rdr.Close();
        }
        cn.Close();
        return risk;
    }
}
