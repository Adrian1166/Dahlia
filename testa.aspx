<div id="header">
    <div class="logoleft"></div><div class="logocenter"></div><div class="logoright"></div><div id="titoloStudio"><strong class="strongtitolo2">DAHLIA STUDY</strong></div>
     <br />
    <div id="infopanelPaz">
        <ul>
            <li>Centro N.: <strong class="strongInfPaz"><b><% Response.Write(Session["SiteId"].ToString());%> </b></strong></li>
            <li>User: <strong class="strongInfPaz"><b><% Response.Write(Session["Nominativo"].ToString());%> </b></strong></li>
        </ul>
    </div>
    <div class="infopanel">
        <ul>
            <%if (Session["LIVELLOID"].ToString()=="2" || Session["NewLIVELLOID"].ToString()=="2"){ %>
                    <li><asp:LinkButton ID="lnkElencoCentri" Text="CENTER LIST" runat="server" CausesValidation="false" PostBackUrl="~/ssl/elencoCentri.aspx" /></li>
            <%} %>
            
            <%if (Session["LIVELLOID"].ToString()=="3"){ %>
                    <li><asp:LinkButton ID="LinkButton2" Text="ADMIN" runat="server" CausesValidation="false" Width="90" PostBackUrl="areautente/gestioneCentro.aspx" /></li>
            <%} %>
            <%if (Session["LIVELLOID"].ToString()=="2" || Session["LIVELLOID"].ToString()=="4"){ %>
   <li><asp:LinkButton ID="LinkButton3" Text="STATISTICS" runat="server" CausesValidation="false" PostBackUrl="statistiche.aspx" /></li>
<%} %>
            <li><asp:LinkButton ID="lnkElencoPaz" Text="PATIENT LIST" runat="server" CausesValidation="false" PostBackUrl="~/ssl/elencopazienti.aspx" /></li>
            <li><asp:LinkButton ID="lnkGestioneQuery" Text="QUERY" runat="server" CausesValidation="false" /></li>
            <li><asp:LinkButton ID="lnkprotocolDeviation" Text="DEVIATION" runat="server" CausesValidation="false" PostBackUrl="~/ssl/areautente/protocolDeviation.aspx?FormID=0" /></li>             
            <li><asp:LinkButton ID="btnDocuments" Text="DOCUMENTS" runat="server" CausesValidation="false" PostBackUrl="studyDocuments.aspx" /></li>
            <li><asp:LinkButton ID="btnAuditTrial" Text="AUDIT TRAIL" runat="server" CausesValidation="false" PostBackUrl="~/ssl/areautente/auditTrial.aspx" /></li>
            <li style="border-right-style:none;color:Red"><asp:LinkButton ID="lnkLOGOFF" Text="LOGOFF" runat="server" ForeColor="Red" CausesValidation="false" PostBackUrl="Default.aspx?LOGOFF=SI" /></li>
   
        </ul>
    </div>
</div>

