<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%Response.Write(Session["TitoloPrg"].ToString());%></title>
    <link href="css/style_pagina.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="txtUtente">
   <table align="center" cellpadding="0" cellspacing="0"><tr><td>
    <div id="headerHome">
        <div class="logoleft"></div><div class="logocenter"></div><div class="logoright"></div><div id="titoloStudio"><strong class="strongtitolo2">DAHLIA STUDY</strong></div>
    <br />
    </div>
    </td></tr>
      <tr><td align="center">
    <div class="contenuto">
        <table align="center" style="margin-top:50px"><tr><td>
        <div class="group"><table align="center" width="80%">
            
            <tr><td colspan="2"><br /><h2>Log in with your ID</h2></td></tr>
            <tr>
                <td align="center" colspan="2"><asp:TextBox ID="txtUtente"  runat="server" style="height:30px;width:80%;padding-left:10px;padding-right:10px;color:#000;font-size:14px;margin-bottom:10px;border: 1px solid #ccc;" placeholder="Username"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" style="height:30px;width:80%;padding-left:10px;padding-right:10px;color:#000;font-size:14px;margin-bottom:10px;background-color:#fff;border: 1px solid #ccc;" placeholder="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <a href="recuperaPsw.aspx">Did you forget your password?</a><br /><br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button onclick="btnLogin_Click" ID="btnLogin" CssClass="button" runat="server" Text="Login" />
                    <asp:Button onclick="btnChangePsw_Click" ID="LinkButton1" CssClass="button" runat="server" Text="Change password"  />
                </td>
            </tr>
                <tr>
                    <td colspan="2" align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ControlToValidate="txtUtente" runat="server" ErrorMessage="The field <b>Username</b> is required"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" ControlToValidate="txtPassword" runat="server" ErrorMessage="The field <b>Password</b> is required"></asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
                        <div id="divMsg" runat="server" style="color:Red" visible="false">Warning: <b>Username</b> or <b>Password</b> is wrong.</div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left">
                        <div id="divSess" runat="server" style="color:Red" visible="false"> 
                            <asp:Label ID="lblSess" runat="server" Text=""></asp:Label></div>
                    </td>
                </tr>
            </table>
        </div>
        </td></tr></table>
        </div>
    </td></tr></table>
 <asp:HiddenField ID="SchermoWidth" runat="server" />
 <script language="javascript">
     var SchermoWidth = document.getElementById("SchermoWidth");
     SchermoWidth.value = screen.width;
</script>
    </form>
</body>
</html>
