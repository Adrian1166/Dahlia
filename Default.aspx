<%@ Page Language="C#" ResponseEncoding="utf-8"  AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%Response.Write(Session["TitoloPrg"].ToString());%></title>
    <link href="css/style_pagina.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <table align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <div id="headerHome">
                <div class="logoleft"></div><div class="logocenter"></div><div class="logoright"></div><div id="titoloStudio"><strong class="strongtitolo2">DAHLIA Study</strong></div>
            <br /><div class="versione">CRF version 1.0 of 12/06/2025</div>
            </div>
        </td>
    </tr>
    <tr>
        <td align="center">
            <div class="contenuto">
                <table align="center" width="90%" style="margin-top:50px">
                    <tr>
                        <td align="center" colspan="2">
                            <span style="margin-top:20px;text-align:center;font-size:20px; width:100%;text-shadow: 0 1px 1px rgba(0,0,0,.3); color: #FF0000;"><b>Protocol DAHLIA</b></span><br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="margin-top:20px;text-align:center;font-size:17px;width:100%;text-shadow: 0 1px 1px rgba(0,0,0,.3);">Achievement of low level of disease activity with a dose of corticosteroids less than or equal to 5 mg (LLDAS5): a real-life study with anifrolumab on patients with systemic lupus erythematosus in Italy</div>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td> 
                            <div style="margin-top:30px">
                                <asp:Button PostBackUrl="~/login.aspx" ID="btnLogin" CssClass="button" runat="server" Text="e-CRF" Width="90px" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="border-width: 0px; border-color: #C0C0C0; position:absolute; bottom:10px; width:100%; left:0px; border-top-style: solid; padding-top:15px">
                                Copyright © 2025 FULLCRO S.R.L. - TUTTI I DIRITTI RISERVATI<br />
                                per contatti riguardanti lo Studio DAHLIA <a href="mailto:DAHLIA@FULLCRO.ORG" target="_blank">DAHLIA@fullcro.org</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    </table>

    </form>
</body>
</html>

