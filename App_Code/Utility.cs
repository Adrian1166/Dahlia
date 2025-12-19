using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Descrizione di riepilogo per Utility
/// </summary>
public class Utility
{
	public Utility()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public string getStringConnection(string PathWebConfig)
    {
        // recupero Stringa di connessione dal web.config
        Configuration config = WebConfigurationManager.OpenWebConfiguration(PathWebConfig);
        ConnectionStringsSection csSection = config.ConnectionStrings;
        return csSection.ConnectionStrings["DAHLIADataConnectionString"].ConnectionString.ToString();
    }

    public string getStringConnectionAcc(string PathWebConfig)
    {
        // recupero Stringa di connessione dal web.config
        Configuration config = WebConfigurationManager.OpenWebConfiguration(PathWebConfig);
        ConnectionStringsSection csSection = config.ConnectionStrings;
        return csSection.ConnectionStrings["DAHLIADataConnectionString"].ConnectionString.ToString();
    }

}
