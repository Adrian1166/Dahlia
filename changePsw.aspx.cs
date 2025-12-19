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

    }

    protected void Ritorna(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool primoCriterio = false;
        bool secondoCriterio = false;
        bool terzoCriterio = false;
        string s = "|,!,£,$,%,&,/,(,),=,?,^,*,°,§,@,#,-,_";
        if (txtPassword1.Text.Length < 10)
        {
            cvdLungPsw.IsValid = false;
        }
        else
        {
            int i = 0;
            for (i = 0; i < txtPassword1.Text.Length; i++)
            {
                int n;
                bool isNumeric = int.TryParse(txtPassword1.Text.Substring(i, 1), out n);
                if (txtPassword1.Text.Substring(i, 1) == txtPassword1.Text.Substring(i, 1).ToUpper() && s.IndexOf(txtPassword1.Text.Substring(i, 1)) == -1
                    && isNumeric==false)
                {
                    primoCriterio = true;
                }
                if (isNumeric == true)
                {
                    secondoCriterio = true;
                }
                if (s.IndexOf(txtPassword1.Text.Substring(i, 1))>-1)
                {
                    terzoCriterio = true;
                }
            }

            if (primoCriterio == false || secondoCriterio == false || terzoCriterio==false)
            {
                cvdLungPsw.IsValid = false;
            }
            else
            {
                Cripta crp = new Cripta();
                bool pswEsistente = false;
                MySqlConnection cn;
                cn = new MySqlConnection(Session["pathDb"].ToString());
                cn.Open();
                string sql = "";
                sql = "Select * from TbUTENTE where Password1='" + crp.getMD5Hash(txtPassword1.Text) + "'";
                MySqlCommand cmd1 = new MySqlCommand(sql, cn);
                MySqlDataReader rdr = cmd1.ExecuteReader();
                if (rdr.HasRows)
                {
                    pswEsistente = true;
                }
                rdr.Close();
                cn.Close();
                if (pswEsistente == false)
                {
                    SqlPsw.UpdateCommand = "UPDATE TbUTENTE set tbUTENTE.Password1='" + crp.getMD5Hash(txtPassword1.Text) + "', DataScadenzaPsw=Now() Where idUtente=" + Session["IdUtente"].ToString();
                    SqlPsw.Update();
                    Response.Redirect("login.aspx");
                }
                else
                {
                    cvdEsitePsw.IsValid = false;
                }
            }
        }
    }

}
