<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErroreServer.aspx.cs" Inherits="ErroreServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DAHLIA Study</title>
    <link href="css/style_pagina.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <table align="center" cellpadding="0" cellspacing="0"><tr><td>
    <div id="headerHome">
        <div class="logoleft"></div><div class="logocenter"></div><div class="logoright"></div><div id="titoloStudio"><strong class="strongtitolo2">DAHLIA Study</strong></div>
    
    </div>
    </td></tr>
    <tr>
        <td align="center">
            <div class="contenuto">
                <table align="center"><tr><td>
    
                <div style="text-align:center; font-size:30px; margin-top:50px;color:#FF0000">&nbsp;</div>
                    </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <div id="div1" runat="server" ><a href="login.aspx" style="color:Red;font-weight:bold;font-size:16px">Session has expired!</a></div>
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
