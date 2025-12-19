<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changePsw.aspx.cs" Inherits="changePsw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%Response.Write(Session["TitoloPrg"].ToString());%></title>
    <link href="css/style_pagina.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <table align="center" cellpadding="0" cellspacing="0"><tr><td>
   <div id="headerHome">
        <div class="logoleft"></div><div class="logocenter"></div><div class="logoright"></div><div id="titoloStudio"><strong class="strongtitolo2">DAHLIA STUDY</strong></div>
    <br />
    </div>
    </td></tr>
    <tr><td align="center">
     <div class="contenuto">
      <table align="center" style="margin-top:50px"><tr><td>
     <div class="group"><h2>CHANGE PASSWORD</h2>
        <table align="center" >
            
            
             <% if (Request["PswScaduto"] != null)
               { %>
                <tr>
                <td align="center" style="font-size:17px;color:Red" colspan="2"><b>Warning:</b><br />The password has expired. Enter new password.<br /></td>
            </tr>
            <%} %>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td align="right" style="font-size:15px">Username:</td>
                <td align="left"><b><% Response.Write(Request["Utente"].ToString());%></b></td>
            </tr>
            <tr>
                <td align="right" style="font-size:15px">New password:</td>
                <td align="left"><asp:TextBox ID="txtPassword1" runat="server" TextMode="Password" Width="200px" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="font-size:15px">Confirm new password:</td>
                <td align="left"><asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="200px" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button onclick="btnSave_Click" ID="btnSave" CssClass="button" runat="server" Text="Save" Width="70px" />
                    <asp:Button ID="LinkButton1" CssClass="button" runat="server" Text="Back" Width="70px" OnClick="Ritorna" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ControlToValidate="txtPassword1" runat="server" ErrorMessage="<b>New password</b> is required"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" ControlToValidate="txtPassword2" runat="server" ErrorMessage="<b>Confirm new password</b> is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="The <b>New password</b> is different from <b>Confirm new password</b>" ControlToValidate="txtPassword1" ControlToCompare="txtPassword2" Display="None" ></asp:CompareValidator>
                    <asp:CustomValidator ID="cvdLungPsw" runat="server" ErrorMessage="Warning:<br/>The <b>New password</b> must contain at least 10 characters, an uppercase letter, a number and a special character." ControlToValidate="txtPassword1" Display="None"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvdEsitePsw" runat="server" ErrorMessage="Warning:<br/>The <b>New password</b> already exists." ControlToValidate="txtPassword1" Display="None"></asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
                    <div id="divMsg" runat="server" style="color:Red" visible="false">Warning: <b>Username</b> or <b>Password</b> is wrong.</div>
                </td>
            </tr>
        </table></div></td></tr></table>
        </div></td></tr></table>
  
    <asp:SqlDataSource ID="SqlPsw" runat="server" ConnectionString="<%$ ConnectionStrings:DAHLIADataConnectionString %>"
        ProviderName="<%$ ConnectionStrings:DAHLIADataConnectionString.ProviderName %>"
       ></asp:SqlDataSource>
    </form>
</body>
</html>
