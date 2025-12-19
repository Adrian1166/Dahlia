<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dataExport.aspx.cs" Inherits="DataExport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%Response.Write(Session["TitoloPrg"].ToString());%></title>
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
            <li><span>Data export&hellip;</span></li>
        </ul>
    </div>

    <div class="titolo"><div class="fontTitolo">Data export</div></div><br />
        <div style="position:absolute;text-align:right;width:90%"><a href="document/DAHLIA CRF annotata versione 1.0 del 06-05-2024.pdf" target="_blank"><b>DAHLIA - CRF annotated</b></a></div>
          <table cellspacing="0" style="border: 1px solid #FF9933;width:800px;margin-top:30px" align="center" cellpadding="0">
            <tr>
                <td align="left" class="TD1" colspan="2">
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlForm">
                        <HeaderTemplate>
                             <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li style="padding:2px"><asp:LinkButton ID="lnkElencoPaz" Text='<%# Eval("newdesc") %>' runat="server" CausesValidation="false" OnCommand="btnExport_Click" CommandName='<%# Eval("Tabella") %>' CommandArgument='<%# Eval("newdesc") %>' />
                                <div id="div2" runat="server" visible='<%# Eval("FormId").ToString()=="4" %>'>
                                    <ul>
                                        <li style="padding:2px"><asp:LinkButton ID="LinkButton11" Text="Concomitant disease" runat="server" CausesValidation="false" OnCommand="btnExport_Click" CommandName='tbPatologConc' CommandArgument='Concomitant disease' />
                                    </ul>
                                </div>
                                <div id="div1" runat="server" visible='<%# Eval("FormId").ToString()=="22" %>'>
                                    <ul>
                                        <li style="padding:2px"><asp:LinkButton ID="LinkButton1" Text="Surgery" runat="server" CausesValidation="false" OnCommand="btnExport_Click" CommandName='tbsurgeryinfodet' CommandArgument='Surgery' />
                                    </ul>
                                </div>
                                <div id="div3" runat="server" visible='<%# Eval("FormId").ToString()=="16" %>'>
                                    <ul>
                                        <li style="padding:2px"><asp:LinkButton ID="LinkButton2" Text="Surgery" runat="server" CausesValidation="false" OnCommand="btnExport_Click" CommandName='tbsurgeryInfoOthDet' CommandArgument='Surgery' />
                                    </ul>
                                </div>
                            </li>
                        </ItemTemplate>
                       <FooterTemplate>    
                        </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                   
                 
                </td>
            </tr>

        </table>
        <asp:SqlDataSource ID="SqlForm" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>"
            SelectCommand="Select Tabella,PrForm.desc as newdesc,orderform,FormId from PrForm where formid<>0 order by orderform"></asp:SqlDataSource>
        <br /><br />
        <%if (Session["PricipalInvest"].ToString() == "1")
      { %>
    <asp:GridView ID="grwTutte" AllowPaging="False" runat="server" Visible="true"
            AutoGenerateColumns="true"
            DataSourceID="SqlTutte" BackColor="White" BorderColor="#999999" 
                BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                GridLines="Both"  RowStyle-BorderStyle="Solid" PagerStyle-BorderStyle="Solid" HeaderStyle-BorderStyle="Solid">
             </asp:GridView>
            <asp:SqlDataSource ID="SqlTutte" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>" SelectCommand=""
                >
            </asp:SqlDataSource> 
            <asp:GridView ID="grwSottoTabella" AllowPaging="False" runat="server" Visible="true"
            AutoGenerateColumns="true"
            DataSourceID="SqlInicialDiagnosis" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Width="100%">
             </asp:GridView>
            <asp:SqlDataSource ID="SqlInicialDiagnosis" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>" SelectCommand=""
                >
            </asp:SqlDataSource> 
        <%} %>
    </div><br /><br />
   
    </form>
</body>
</html>