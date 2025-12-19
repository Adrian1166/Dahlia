<%@ Page Language="C#" AutoEventWireup="true" CodeFile="statistiche.aspx.cs" Inherits="statistiche" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DAHLIA</title>
    <link href="css/style_pagina.css" rel="stylesheet" type="text/css" />
    <script src="script/FusionCharts.js" type="text/javascript"></script>

</head>
<body>
    <form id="form2" runat="server">
   <!--#INCLUDE FILE="testa.aspx"-->
<div class="contenuto">
    <div id="navigazione">
    <ul>
        <li>You are in:</li>
        <%if (Session["LIVELLOID"].ToString() == "2" || (Session["LIVELLOID"].ToString()=="1" && Session["NewLIVELLOID"].ToString()=="2"))
        { %>
        <li>
            <a href="ssl/elencoCentri.aspx">
                <span>Center list</span>
            </a>/
        </li>
        <%} %>
        <li>
            <a href="ssl/elencoPazienti.aspx">
                <span>Patient list</span>
            </a>/
        </li>
        
        <li><span>Statistics &hellip;</span></li>
    </ul>
</div>

        <%if (Session["LIVELLOID"].ToString() == "2"|| Session["LIVELLOID"].ToString() == "4")
      { %>
        <div style="text-align:right;right:10px;position:absolute;top:5px; font-size:14px">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="CreaTabelleTotali"><b>Patient Visit Status</b></asp:LinkButton><br />
            <asp:LinkButton ID="lnkCRSwNP" runat="server" OnClick="CreaTabellaCRSwNP"><b>Patient comorbid CRSwNP Status</b></asp:LinkButton><br />
        </div>
    <%} %>
        <div class="titolo"><div class="fontTitolo">Statistics</div></div><br />
   
        <table cellspacing="0" style="width:810px" align="center" cellpadding="0">
            <tr><td style="font-size:16px;color:#0066CC; font-weight:bold">Total enrolled:&nbsp;<asp:Label ID="lblTotale" runat="server" ForeColor="Red" /></td></tr>
            <tr >
                <td style="z-index:0">
                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlCentro">
                        <HeaderTemplate>
                            <table width="100%" cellspacing="1" cellpadding="1" style="background-color: #333333;color:Black; margin-top:10px">
                            <tr>
                                <td align="center" style="background-color: #00CC00; height:22px"><b>Center N°</b></td>
                                <td align="center" style="background-color: #00CC00"><b>City</b></td>
                                <td align="center" style="background-color: #00CC00"><b>Hospital structure</b></td>
                                <td align="center" style="background-color: #00CC00"><b>No. of patients</b></td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                        <tr>
                            <td align="center" class="TD1" style="background-color: #ffffff">
                                <asp:Label ID="IdLocation" runat="server" Text='<%# Eval("NumCentro")%>' />
                            </td>
                            <td align="center" class="TD1" style="background-color: #ffffff">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Citta")%>' />
                            </td>
                            <td align="left" class="TD1" style="background-color: #ffffff">
                                <asp:Label ID="Label2" runat="server" style="text-align:left" Text='<%# Eval("Descrizione")%>' />
                            </td>
                            <td align="center" class="TD1" style="background-color: #ffffff">
                                <asp:Label ID="lblTotPaz" runat="server" Text='<%# Eval("totpaz")%>' />
                            </td>
                        </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table><br />
   
     <asp:SqlDataSource ID="SqlCentro" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
        ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>" SelectCommand="">
    </asp:SqlDataSource> 
<%if (Session["LIVELLOID"].ToString() == "12")
      { %>
    <asp:GridView ID="grwTotale" AllowPaging="False" runat="server" Visible="true"
        AutoGenerateColumns="false"
        DataSourceID="SqlTotale" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Both" Width="100%" RowStyle-BorderStyle="Solid" PagerStyle-BorderStyle="Solid" HeaderStyle-BorderStyle="Solid">
        <Columns>
            <asp:BoundField DataField="Primario" HeaderText="PI" ReadOnly="True" ItemStyle-HorizontalAlign="Left">
            </asp:BoundField>
            <asp:BoundField DataField="NumPaz" HeaderText="Sbj N" ReadOnly="True" ItemStyle-HorizontalAlign="Center">
            </asp:BoundField>
            <asp:BoundField DataField="V1" HeaderText="Index Date" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="True" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#3399FF">
            </asp:BoundField>
            <asp:TemplateField>
                 <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                 <HeaderTemplate>Status entry</HeaderTemplate>
                 <ItemTemplate>
                     <asp:Label ID="img1" runat="server" Text='<%# TrovaSemVisita(Convert.ToString(Eval("V1")),Convert.ToString(Eval("IdPaziente")),"2") %>' ></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
            <asp:TemplateField>
                 <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                 <HeaderTemplate>10 mesi</HeaderTemplate>
                 <ItemTemplate>
                     <asp:Label ID="lblV1_10" runat="server" Text='<%# Eval("V1_10") %>' ForeColor='<%# Eval("V1_Rosso").ToString()=="1" ? System.Drawing.Color.Red : System.Drawing.Color.Black %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                <HeaderTemplate>12 mesi</HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblV2" runat="server" Text='<%# Eval("V2").ToString().Substring(0,10) %>' ForeColor='<%# Eval("V1_Rosso").ToString()=="1" ? System.Drawing.Color.Red : System.Drawing.Color.Black %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                <HeaderTemplate>14 mesi</HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblV1_14" runat="server" Text='<%# Eval("V1_14") %>' ForeColor='<%# Eval("V1_Rosso").ToString()=="1" ? System.Drawing.Color.Red : System.Drawing.Color.Black %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                 <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                 <HeaderTemplate>Status entry</HeaderTemplate>
                 <ItemTemplate>
                     <asp:Label ID="img2" runat="server" Text='<%# TrovaSemVisita(Convert.ToString(Eval("V2")),Convert.ToString(Eval("IdPaziente")),"3") %>' ></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                 <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                 <HeaderTemplate>22 mesi</HeaderTemplate>
                 <ItemTemplate>
                     <asp:Label ID="lblV2_22" runat="server" Text='<%# Eval("V2_22") %>' ForeColor='<%# Eval("V2_Rosso").ToString()=="1" ? System.Drawing.Color.Red : System.Drawing.Color.Black %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                <HeaderTemplate>24 mesi</HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblV3" runat="server" Text='<%# Eval("V3").ToString().Substring(0,10) %>' ForeColor='<%# Eval("V2_Rosso").ToString()=="1" ? System.Drawing.Color.Red : System.Drawing.Color.Black %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                <HeaderTemplate>26 mesi</HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblV2_26" runat="server" Text='<%# Eval("V2_26") %>' ForeColor='<%# Eval("V2_Rosso").ToString()=="1" ? System.Drawing.Color.Red : System.Drawing.Color.Black %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                 <HeaderStyle CssClass="headerGRW" BackColor="#E0E0E0" />
                 <HeaderTemplate>Status entry</HeaderTemplate>
                 <ItemTemplate>
                     <asp:Label ID="img3" runat="server" Text='<%# TrovaSemVisita(Convert.ToString(Eval("V3")),Convert.ToString(Eval("IdPaziente")),"4") %>' ></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlTotale" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>" SelectCommand=""
            >
        </asp:SqlDataSource> 

        <asp:GridView ID="grwAE" AllowPaging="False" runat="server" Visible="true"
            AutoGenerateColumns="false"
            DataSourceID="SqlAE" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Both" Width="100%" RowStyle-BorderStyle="Solid" PagerStyle-BorderStyle="Solid" HeaderStyle-BorderStyle="Solid">
            <Columns>
                <asp:BoundField DataField="newNumCentro" HeaderText="Numero centro" ReadOnly="True" ItemStyle-HorizontalAlign="Left">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Citta" HeaderText="Citta" ItemStyle-HorizontalAlign="Left">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" ItemStyle-HorizontalAlign="Left">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Primario" HeaderText="Primario" ReadOnly="True" ItemStyle-HorizontalAlign="Left">
                </asp:BoundField>
                <asp:BoundField DataField="NumPaz" HeaderText="N° paziente" ReadOnly="True" ItemStyle-HorizontalAlign="Center">
                </asp:BoundField>
                <asp:BoundField DataField="NrEA" HeaderStyle-Font-Bold="true" HeaderText="N° AE" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                </asp:BoundField>
                <asp:BoundField DataField="newDesc" HeaderStyle-Font-Bold="true" HeaderText="AE Descrizione in eCRF" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                </asp:BoundField> 
                <asp:BoundField DataField="DataInizio" HeaderStyle-Font-Bold="true" HeaderText="Data inizio" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField>
                <asp:BoundField DataField="DataFine" HeaderStyle-Font-Bold="true" HeaderText="Data fine" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField>
                <asp:BoundField DataField="Classificazione" HeaderStyle-Font-Bold="true" HeaderText="Classificazione" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField> 
                <asp:BoundField DataField="Intensita" HeaderStyle-Font-Bold="true" HeaderText="Intensità" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField> 
            
                <asp:BoundField DataField="Esito" HeaderStyle-Font-Bold="true" HeaderText="Esito" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField> 
                <asp:BoundField DataField="Trattamento" HeaderStyle-Font-Bold="true" HeaderText="Azioni intraprese" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField> 
                <asp:BoundField DataField="Correlazione" HeaderStyle-Font-Bold="true" HeaderText="Relazione col farmaco" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField> 
                <asp:BoundField DataField="MotivoRelazione" HeaderStyle-Font-Bold="true" HeaderText="Razionale per la correlazione" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField>
                <asp:BoundField DataField="Commenti" HeaderStyle-Font-Bold="true" HeaderText="Commenti inseriti dal centro" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField>
            
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlAE" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>" SelectCommand=""
            >
        </asp:SqlDataSource> 

        <asp:GridView ID="grwCS" AllowPaging="False" runat="server" Visible="true"
            AutoGenerateColumns="false"
            DataSourceID="SqlCS" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Both" Width="100%" RowStyle-BorderStyle="Solid" PagerStyle-BorderStyle="Solid" HeaderStyle-BorderStyle="Solid">
            <Columns>
                <asp:BoundField DataField="newNumCentro" HeaderText="Numero centro" ReadOnly="True" ItemStyle-HorizontalAlign="Left">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Citta" HeaderText="Citta" ItemStyle-HorizontalAlign="Left">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" ItemStyle-HorizontalAlign="Left">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Primario" HeaderText="Primario" ReadOnly="True" ItemStyle-HorizontalAlign="Left">
                </asp:BoundField>
                <asp:BoundField DataField="NumPaz" HeaderText="N° paziente" ReadOnly="True" ItemStyle-HorizontalAlign="Center">
                </asp:BoundField>
                <asp:BoundField DataField="DropOut" HeaderStyle-Font-Bold="true" HeaderText="Drop out SI/NO" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                </asp:BoundField> 
                <asp:BoundField DataField="DataConclusione" HeaderStyle-Font-Bold="true" HeaderText="Data  conclusione dello studio" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField>
                <asp:BoundField DataField="MotivoUscita" HeaderStyle-Font-Bold="true" HeaderText="Studio interrotto per " ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
                </asp:BoundField> 
                
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlCS" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>" SelectCommand=""
            >
        </asp:SqlDataSource> 
    <asp:GridView ID="grwCRSwNP" AllowPaging="False" runat="server" Visible="true"
    AutoGenerateColumns="false"
    DataSourceID="SqlCRSwNP" BackColor="White" BorderColor="#999999" 
   BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Both" Width="100%" RowStyle-BorderStyle="Solid" PagerStyle-BorderStyle="Solid" HeaderStyle-BorderStyle="Solid">
    <Columns>
        <asp:BoundField DataField="Primario" HeaderText="Primario" ReadOnly="True" ItemStyle-HorizontalAlign="Left">
        </asp:BoundField>
        <asp:BoundField DataField="NumPaz" HeaderText="N° paziente" ReadOnly="True" ItemStyle-HorizontalAlign="Center">
        </asp:BoundField>
        <asp:BoundField DataField="Comorbid1" HeaderStyle-Font-Bold="true" HeaderText="Index date - Is the patient affected by comorbid CRSwNP?" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
        </asp:BoundField> 
        <asp:BoundField DataField="Comorbid2" HeaderStyle-Font-Bold="true" HeaderText="visit 1 - Is the patient affected by comorbid CRSwNP?" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" >
        </asp:BoundField>
        <asp:BoundField DataField="Comorbid3" HeaderStyle-Font-Bold="true" HeaderText="Visit 2 - Is the patient affected by comorbid CRSwNP?" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" >
        </asp:BoundField> 
        
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlCRSwNP" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
    ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>" SelectCommand=""
    >
</asp:SqlDataSource> 
    <%} %>
        
</div>

    </form>
</body>
</html>