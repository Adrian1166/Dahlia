<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recuperaPsw.aspx.cs" Inherits="changePsw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DAHLIA</title>
    <link href="css/style_pagina.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="headerHome">
        <div class="logoleft"></div><div class="logocenter"></div><div class="logoright"></div><div id="titoloStudio"><strong class="strongtitolo2">DAHLIA Study</strong></div>
    <br />
    </div>
 <div class="contenuto">
    <table align="center" style="margin-top:50px">
        <tr><td>
        <div class="group"><br /><h2>Credentials recovery</h2>
            <table align="center" width="90%">
            
            <tr>
                <td align="center" style="font-size:15px">Enter the email address you provided when registering:<br /><br /></td>
            </tr>
            <tr>
                <td align="center"><asp:TextBox ID="txtEmail" runat="server" Width="300px" CssClass="textbox" style="height:40px;width:80%;padding-left:10px;padding-right:10px;color:#ffffff;font-size:14px;margin-bottom:10px;background-color:#424243;border:0;outline:0" placeholder="Email address"></asp:TextBox><br /><br /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button onclick="btnSave_Click" ID="btnSave" CssClass="button" runat="server" Text="Send" Width="70px" />
                    <asp:Button ID="LinkButton1" CssClass="button" runat="server" Text="Back" Width="70px" OnClick="Ritorna" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ControlToValidate="txtEmail" runat="server" ErrorMessage="<b>Email</b> is required"></asp:RequiredFieldValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <div id="divSess" runat="server" style="color:Blue" visible="false"> 
                        <asp:Label ID="lblSess" runat="server" Text=""></asp:Label></div>
                </td>
            </tr>
        </table>
        </div>
    </td></tr></table></div>
    <asp:SqlDataSource ID="SqlPsw" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
        ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>"
       ></asp:SqlDataSource>
    </form>
</body>
</html>
