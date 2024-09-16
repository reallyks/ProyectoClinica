<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="Styles.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
        <div id="div1" class="main">
            <div id="login" class="main_container">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/logo.png" CssClass="img_logo" />
                <br />
                <input id="InputUser" runat="server" class="input" placeholder="Ingrese Usuario" type="text"  /><asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="InputUser" ForeColor="Red">INGRESE USUARIO</asp:RequiredFieldValidator>
                <br />
                <input id="InputPassword" runat="server" type="password" placeholder ="Ingrese su contraseña" class="input" /><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="InputPassword" ForeColor="Red">INGRESE CONTRASENA</asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btnIniciarSesion" runat="server" CssClass="btn" Text="INICIAR SESION" OnClick="btnIniciarSesion_Click" />
                <br />
                <asp:Label ID="lbMensaje" runat="server"></asp:Label>
                <br />
            </div>
            <div id="footer" class="footer">
&nbsp;
                <div id="footerNav" class="footerNav">
                    <asp:Label ID="Label1" runat="server" Text="All Rights Reserved © "></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Developed by GROUP 9"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
