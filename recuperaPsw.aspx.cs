using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MySql.Data.MySqlClient;

public partial class changePsw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Test Michele 20160926 1647MA
        divSess.Visible = false;
    }

    protected void Ritorna(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        string ConnString = utility.getStringConnection(Request.ApplicationPath);
        Session["pathDb"] = ConnString;
        MySqlConnection cn;
        cn = new MySqlConnection(Session["pathDb"].ToString());
        cn.Open();
        string sql = "Select * from TbUTENTE Where Email='" + txtEmail.Text + "' And IdStato=1";
        MySqlCommand cmd1 = new MySqlCommand(sql, cn);
        MySqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            rdr.Read();
            string nomeutente = rdr["Utente"].ToString();
            rdr.Close();
            cn.Close();
            Cripta crp = new Cripta();
            SqlPsw.UpdateCommand = "UPDATE TbUTENTE set tbUTENTE.Password1='" + crp.getMD5Hash("DAHLIA_2025") + "' Where Email='" + txtEmail.Text + "'";
            SqlPsw.Update();
            bool resultEmai = false;
            string subjectEmail = "";
            string bodyEmail = "";
            InviaEmailAbbott invem = new InviaEmailAbbott();
            subjectEmail = "Studio DAHLIA - Modalità di accesso CRF elettronica";
            bodyEmail = "Gentile Utente,\n" +
                    "di seguito trova le credenziali di accesso alla CRF elettronica dello stydio \"DAHLIA\",\n" +
                    "Utente: " + nomeutente + "\n\n" +
                    "La password sarà inviata di seguito." + "\n\n" +
                    "L'indirizzo della pagina iniziale dell'applicazione e' \n https:\\DAHLIA.fullcro.org \ninserisca le credenziali indicate" +
                    " riportando le lettere maiuscole, minuscole, i numeri e gli spazi esattamente come descritto.\n" +
                    "Al primo accesso e' necessario cambiare la password che arriverà di seguito con una personale al fine di mantenere l'accesso confidenziale.\n" +
                "Si ricorda che il nome Utente e la password sono strettamente personali e non cedibili a terzi: i singoli utenti che hanno ottenuto " +
                "l'accesso all'applicazione sono i soli responsabili dei dati inseriti nelle schede-paziente.\n" +
                "Per problematiche inerenti l'applicazione, si prega di contattare l'amministratore del sistema mediante l'indirizzo e-mail: info@FULLCRO.it \nCordiali saluti";
            resultEmai = invem.sendMail("info@FULLCRO.it", txtEmail.Text, "", "", subjectEmail, bodyEmail);

            subjectEmail = "DAHLIA - Modalità di accesso CRF elettronica";
            bodyEmail = "DAHLIA_2025";
            resultEmai = invem.sendMail("info@FULLCRO.it", txtEmail.Text, "", "", subjectEmail, bodyEmail);

            lblSess.Text = "At the specified address will be sent an email with your credentials";
            divSess.Visible = true;
            divSess.Style.Add("color", "Blue");
        }
        else
        {
            lblSess.Text = "Unknown e-mail address or user not enabled!";
            divSess.Visible = true;
            divSess.Style.Add("color", "Red");
            rdr.Close();
            cn.Close();
        }
    }
}
