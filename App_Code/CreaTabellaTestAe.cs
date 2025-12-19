using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
/// <summary>
/// Descrizione di riepilogo per CreaTabellaTerapie
/// </summary>
public class CreaTabellaTestAe
{
    public CreaTabellaTestAe()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public DataTable setCreaTabellaTestAe()
    {
        DataSet ds = new DataSet();
        DataTable dt = ds.Tables.Add("TestAe");
        DataColumn column;

        // Create first column and add to the DataTable.
        column = new DataColumn();
        column.DataType= System.Type.GetType("System.Int32");
        column.ColumnName = "IdTestAe";
        column.AutoIncrement = true;
        column.ReadOnly = true;
        column.Unique = true;
        dt.Columns.Add(column);
        dt.Columns.Add("IdCentro");
        dt.Columns.Add("IdPaziente");
        dt.Columns.Add("DataTest");
        dt.Columns.Add("Test");
        dt.Columns.Add("Result");
        dt.Columns.Add("RangeUnit");
        dt.Columns.Add("IdAe");
        return dt;
    }
}