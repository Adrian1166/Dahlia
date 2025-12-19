using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
/// <summary>
/// Descrizione di riepilogo per CreaTabellaTerapie
/// </summary>
public class CreaTabellaTerapie
{
	public CreaTabellaTerapie()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public DataTable setCreaTabellaTerapie()
    {
        DataSet ds = new DataSet();
        DataTable dt = ds.Tables.Add("Terapia");
        DataColumn column;

        // Create first column and add to the DataTable.
        column = new DataColumn();
        column.DataType= System.Type.GetType("System.Int32");
        column.ColumnName = "IdTratFarmac";
        column.AutoIncrement = true;
        column.ReadOnly = true;
        column.Unique = true;
        dt.Columns.Add(column);
        dt.Columns.Add("IdCentro");
        dt.Columns.Add("IdPaziente");
        dt.Columns.Add("NomeCommerc");
        dt.Columns.Add("AltroFarmaco");
        dt.Columns.Add("Dose");
        dt.Columns.Add("UnitaMisura");
        dt.Columns.Add("ViaSomminis");
        dt.Columns.Add("Frequenza");
        dt.Columns.Add("IdFrequenza");
        dt.Columns.Add("DataInizioDD");
        dt.Columns.Add("DataInizioMM");
        dt.Columns.Add("DataInizioYY");
        dt.Columns.Add("DataFineDD");
        dt.Columns.Add("DataFineMM");
        dt.Columns.Add("DataFineYY");
        dt.Columns.Add("Incorso");
        dt.Columns.Add("Indicazione");
        dt.Columns.Add("newNomeCommerc");
        dt.Columns.Add("newIncorso");
        dt.Columns.Add("DataInizio");
        dt.Columns.Add("DataFine");
        dt.Columns.Add("IdAe");
        return dt;
    }
}