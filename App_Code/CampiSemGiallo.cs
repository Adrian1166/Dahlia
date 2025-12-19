using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Descrizione di riepilogo per CampiSemGiallo
/// </summary>
public class CampiSemGiallo
{
	public CampiSemGiallo()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public string getCampiSemGiallo(FormView fv, string s, int tipocampo)
    {
        string SemId = "1";
        string[] campi = s.Split(',');
        for (int i = 0; i < campi.Length; i++)
        {
            switch (tipocampo)
            {
                case 1://campo text box
                    TextBox txt = fv.FindControl(campi[i]) as TextBox;
                    if (txt.Text.Trim() == "") SemId = "2";
                    break;
                case 2://campo radiobuttonlist
                    RadioButtonList rbl = fv.FindControl(campi[i]) as RadioButtonList;
                    if (rbl.SelectedValue == "") SemId = "2";
                    break;
                case 3://campo dropdawnlist
                    DropDownList ddl = fv.FindControl(campi[i]) as DropDownList;
                    if (ddl.SelectedValue == "" || ddl.SelectedValue == "0") SemId = "2";
                    break;
            }
        }
        return SemId;
    }
}