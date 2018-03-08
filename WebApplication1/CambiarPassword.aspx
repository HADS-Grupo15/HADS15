<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CambiarPassword.aspx.vb" Inherits="WebApplication1.PassChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <br /><br /><br />
    <div style="text-align:center">  
    <h2 style="color:Highlight">¿HAS OLVIDADO TU CONTRASEÑA?</h2>
        <h3>Introduce el correo que utilizaste al crear la cuenta,</h3>
        <h3>te mandaremos un código para proceder con el cambio de contraseña</h3>
    <form id="formPassChange1" runat="server" ><br /><br />
        <asp:Label ID="lblMail" runat="server" Text="Correo electrónico:" style="font-size:larger;"></asp:Label><br /><br />
        <asp:TextBox ID="txtMail" runat="server" Width="186px" style="text-align:center;border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Formato mail incorrecto"></asp:RegularExpressionValidator>
        <br /><br />
        <br /><br />
        <asp:Button ID="submit" runat="server" Text="Aceptar" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/><br /><br />
        </form>
    <div>
        <asp:HyperLink ID="hyperPass" runat="server">¿No recuerdas el correo?</asp:HyperLink><br /><br />
        <asp:HyperLink ID="hyperRegister" runat="server">¿Aún no te has registrado?</asp:HyperLink><br />
    </div>
   </div>
</body>
</html>
