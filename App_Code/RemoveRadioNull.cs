using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
/// <summary>
/// Descrizione di riepilogo per removeRadioNull
/// </summary>
public class RemoveRadioNull
{
	public RemoveRadioNull()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public void getRemoveRadioNull(FormView fv, string s, int itemR)
    {
        string[] campi = s.Split(',');
        for (int i = 0; i < campi.Length; i++)
        {
            RadioButtonList opt = fv.FindControl(campi[i]) as RadioButtonList;
            opt.Items.RemoveAt(itemR);
        }
    }

    public void getRemoveCheckNull(FormView fv, string s, int itemR)
    {
        string[] campi = s.Split(',');
        for (int i = 0; i < campi.Length; i++)
        {
            CheckBoxList opt = fv.FindControl(campi[i]) as CheckBoxList;
            opt.Items.RemoveAt(itemR);
        }
    }
}