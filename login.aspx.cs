using System;
using System.Collections;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MySql.Data.MySqlClient;
using DateDiffFunc;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        Server.ClearError();
        Session.Abandon();
        //Session["pathDb"] = ConnString;
        Session["TitoloPrg"] = "DAHLIA";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        string ConnString = utility.getStringConnection(Request.ApplicationPath);
        //Response.Write(Server.HtmlEncode(Request.PhysicalApplicationPath));
        //Response.Write(Server.HtmlEncode(Request.PhysicalPath));
        //Response.Write(Server.HtmlEncode(Request.RawUrl));
        Session["pathDb"] = ConnString;
        Session["TitoloPrg"] = "DAHLIA";
        Session["SchermoWidth"] = SchermoWidth.Value;
        divMsg.Visible = false;
        divSess.Visible = false;
        
        if (Session["IdUtente"] == null)
        {
            PrendiUtente();
        }
        else
        {
            if (Session["UtenteiQOS"].ToString() != txtUtente.Text)
            {
                divSess.Visible = true;
                lblSess.Text = "Already you connected as the user: " + Session["Nominativo"] + ".<br />If you want to connect as another user, you must first close the Open tab. ";
            }
            else
            {
                PrendiUtente();
            }
        }
    }


    protected void PrendiUtente()
    {
        Utente u = new Utente();
        string livello = u.getUtente(txtUtente.Text, txtPassword.Text, Session["pathDb"].ToString());
        if (livello == "")
        {
            divMsg.Visible = true;
        }
        else
        {
            Session["IdCentro"] = u.IdCentro;
            Session["SiteID"] = u.SiteID;
            Session["UtenteiQOS"] = txtUtente.Text;
            Session["IdUtente"] = u.UserID;
            Session["DescSite"] = u.DescSite;
            Session["Citta"] = u.Citta;
            Session["Primario"] = u.Primario;
            Session["PricipalInvest"] = u.PricipalInvest;
            Cripta crp = new Cripta();
            //Response.Write(crp.getMD5Hash("Admincrf_01"));
            if (u.PswUte == crp.getMD5Hash("DAHLIA_2025"))
            {
                Response.Redirect("changePsw.aspx?Utente=" + txtUtente.Text);
            }
            else
            {
                Session["LIVELLOID"] = livello;
                Session["Nominativo"] = u.Nominativo;
                Session["NewLIVELLOID"] = "1";
                
                if (u.IdStato == "2")
                {
                    divSess.Visible = true;
                    lblSess.Text = "Your user is disabled.<br/>Contact the project administrator.";
                }
                else
                {
                    bool PermessoAccesso = false;
                    long minRimanenti = 0;
                    string DataAccUtente = u.DataAccUtente;
                    if (DataAccUtente == "" || txtUtente.Text.ToUpper() == "B" || txtUtente.Text.ToUpper() == "MONITOR" || txtUtente.Text.ToUpper() == "D" || txtUtente.Text.ToUpper() == "A")
                    {
                        PermessoAccesso = true;
                    }
                    else
                    {
                        minRimanenti = DateDiffFunc.DateAndTime.DateDiff(DateDiffFunc.DateInterval.Minute, Convert.ToDateTime(DataAccUtente), DateTime.Now);
                        if (minRimanenti >= Session.Timeout) PermessoAccesso = true;
                    }
                    
                    if (PermessoAccesso == true)
                    {
                        bool PermessoPrimoAccesso = true;
                        string DataPrimoAcc = u.DataPrimoAcc;
                        long intervalPrimoAcc = DateAndTime.DateDiff(DateInterval.Day, Convert.ToDateTime(DataPrimoAcc), DateTime.Today);
                        if (intervalPrimoAcc > 90)
                        {
                            PermessoPrimoAccesso = false;
                        }
                        if (PermessoPrimoAccesso == false && Session["IdCentro"].ToString() != "1")
                        {
                            Response.Redirect("changePsw.aspx?Utente=" + txtUtente.Text + "&PswScaduto=SI");
                        }
                        else
                        {
                            MySqlConnection cn;
                            cn = new MySqlConnection(Session["pathDb"].ToString());
                            cn.Open();
                            string sql = "Select * from rlcentreuser where idutente=" + Session["IdUtente"];
                            MySqlCommand cmd1 = new MySqlCommand(sql, cn);
                            MySqlDataReader rdr = cmd1.ExecuteReader();
                            if (rdr.HasRows && livello != "5")
                            {
                                livello = "2";
                                Session["NewLIVELLOID"] = "2";
                            }
                            rdr.Close();
				            sql = "Select * from lsopzioni";
                            MySqlCommand cmdO = new MySqlCommand(sql, cn);
                            MySqlDataReader rdrO = cmdO.ExecuteReader();
                            rdrO.Read();
                            Session["acronimocrf"] = rdrO["acronimocrf"].ToString();
                            Session["emailcrf"] = rdrO["emailcrf"].ToString();
                            Session["titolocrf"] = rdrO["titolocrf"].ToString();
                            Session["indirizzocrf"] = rdrO["indirizzocrf"].ToString();
                            rdrO.Close();
                            cn.Close();

                            switch (livello)
                            {
                                case "1":
				
                                    Response.Redirect("ssl/elencoPazienti.aspx");
                                    break;
                                case "2":
                                case "4":
                                    Response.Redirect("ssl/elencoCentri.aspx");
                                    break;
                                case "3":
                                    Response.Redirect("ssl/areautente/gestioneCentro.aspx");
                                    break;
                                case "5":
                                    Response.Redirect("ssl/questionario/elencoCentri.aspx");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        divSess.Visible = true;
                        lblSess.Text = "<b>Warning:</b><br/>This user is already connected.<br/>" +
                            "It may have occurred:<br/>1) that the application has been abandoned by the user without making Logoff;" +
                            " in which case you can fall between <b>" + (Session.Timeout - minRimanenti) + "</b> minutes.<br>" +
                            "2) that another user is currently logged in with the credentials you typed; the system<br/>" +
                            "ensures that this does not occur.";
                    }
                }
            }
        }
    }

    protected void btnChangePsw_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        string ConnString = utility.getStringConnection(Request.ApplicationPath);
        Session["pathDb"] = ConnString;
        Session["TitoloPrg"] = "DAHLIA";
        Utente u = new Utente();
        string livello = u.getUtente(txtUtente.Text, txtPassword.Text, Session["pathDb"].ToString());
        if (livello == "")
        {
            divMsg.Visible = true;
        }
        else
        {
            Session["IdUtente"] = u.UserID;
            Response.Redirect("changePsw.aspx?Utente=" + txtUtente.Text);
        }
    }
}
