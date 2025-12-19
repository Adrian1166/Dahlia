using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Descrizione di riepilogo per CaricaData
/// </summary>
public class CaricaData
{
	public CaricaData()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public void getCaricaData(FormView fv, string strData)
    {
        DropDownList giorno = fv.FindControl(strData+"DD") as DropDownList;
        DropDownList mese = fv.FindControl(strData+"MM") as DropDownList;
        DropDownList anno = fv.FindControl(strData+"YY") as DropDownList;
        ListItem lst1 = new ListItem();
        lst1.Text = "";
        lst1.Value = "";
        giorno.Items.Add(lst1);
        ListItem lst12 = new ListItem();
        lst12.Text = "UK";
        lst12.Value = "UK";
        giorno.Items.Add(lst12);
        for (int i = 1; i < 32; i++)
        {
            ListItem lst2 = new ListItem();
            lst2.Text = String.Format("{0:0#}", i);
            lst2.Value = String.Format("{0:0#}", i);
            giorno.Items.Add(lst2);
        }
        ListItem lst3 = new ListItem();
        lst3.Text = "";
        lst3.Value = "";
        mese.Items.Add(lst3);
        ListItem lst13 = new ListItem();
        lst13.Text = "UK";
        lst13.Value = "UK";
        mese.Items.Add(lst13);
        for (int i = 1; i < 13; i++)
        {
            DateTime d = new DateTime();
            d = Convert.ToDateTime("01/" + Convert.ToString(i) + "/2008");
            ListItem lst4 = new ListItem();
            lst4.Text = String.Format("{0:0#}", i);
            lst4.Value = String.Format("{0:0#}", i);
            mese.Items.Add(lst4);
        }
        ListItem lst5 = new ListItem();
        lst5.Text = "";
        lst5.Value = "";
        anno.Items.Add(lst5);
        for (int i = DateTime.Now.Year; i >= 1930; i--)
        {
            ListItem lst6 = new ListItem();
            lst6.Text = Convert.ToString(i);
            lst6.Value = Convert.ToString(i);
            anno.Items.Add(lst6);
        }
    }

    public void getScriviData(FormView fv, string data, string strData)
    {
        DropDownList giorno = fv.FindControl(strData + "DD") as DropDownList;
        DropDownList mese = fv.FindControl(strData + "MM") as DropDownList;
        DropDownList anno = fv.FindControl(strData + "YY") as DropDownList;
        TextBox d = fv.FindControl(data) as TextBox;
        d.Text = giorno.SelectedValue + "/" + mese.SelectedValue + "/" + anno.SelectedValue;
        if (d.Text == "/" || d.Text == "//") d.Text = "";
    }

}
