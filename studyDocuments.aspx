<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studyDocuments.aspx.cs" Inherits="studyDocuments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DAHLIA</title>
    <link href="css/style_pagina.css" rel="stylesheet" type="text/css" />
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
        
        <li><span>Documents &hellip;</span></li>
    </ul>
</div>
<div class="titolo"><div class="fontTitolo">Documents</div></div><br />
     <table align="center" style="margin-top:30px">
     <tr><td>
    
         <table align="center" width="100%">
            <tr>
                <td align="center">
                    <br />
                    <a href="document/Study Protocol_DAHLIA_final_v1.0_270125 - signed.pdf">Protocol version 1.0 27.01.2025</a><br />
                   
                </td>
            </tr>
             <tr>
                <td align="center">
                    <br />
                    <a href="document/DAHLIA_eCRF_Guidelines_Vers._1.0_16-06-2025.pdf">eCRF Guidelines 1.0 16.06.2025</a><br />
       
                </td>
            </tr>
        </table>
    </td></tr></table></div>
    </form>
</body>
</html>
