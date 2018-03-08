<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Confirmar.aspx.vb" Inherits="WebApplication1.ConfirmAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <br /><br /><br />
    <div style="text-align:center">  
    <h2 style="color:Highlight">CONFIRMAR CUENTA</h2>
        <h3 style="color:darkgreen">Enhorabuena, te has registrado satisfactoriamente</h3>
        <h3 style="color: darkgreen">Por favor, revisa tu correo e indica el código que se te ha facilitado</h3>
    <form id="formConfirm" runat="server" ><br /><br />
        <asp:Label ID="lblMail" runat="server" Text="Correo electrónico:" style="font-size:larger;"></asp:Label><br /><br />
        <asp:TextBox ID="txtMail" runat="server" Width="184px" style="text-align:center;border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="*"></asp:RequiredFieldValidator><br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Formato mail incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br /><br />
        <asp:Label ID="lblCode" runat="server" style="font-size:larger;" Text="Código de confirmación:"></asp:Label><br /><br />
        <asp:TextBox ID="txtCod" runat="server" Width="146px" style="text-align:center;border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCod" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="submit" runat="server" Text="Aceptar" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/><br /><br />
        </form>
    <div>
        <br />
         <asp:Label ID="Label1" runat="server"  Text=" Aun sin confirmar"></asp:Label>
        <br /><br />
        <asp:HyperLink ID="hyperPass" runat="server">¿No has recibido ningún código?</asp:HyperLink><br />
    </div>
   </div>
</body>
</html>
