<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Vistas.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Home</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1" class="main">
            <div id="div2" class="main_container main_container_2">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/logo.png" CssClass="img" />
                <br />
                <asp:Label ID="lblUsuario" runat="server" Text="Bienvenido,  Usuario" CssClass="cartel"></asp:Label>
                <br />
                <br />
                <div id="buttons" class="buttons">
                    <asp:Button ID="Button1" runat="server" Text="PACIENTES" CssClass="btn btnGestion" PostBackUrl="~/Pacientes.aspx" />
                    <asp:Button ID="Button2" runat="server" Text="MEDICOS" CssClass="btn btnGestion" PostBackUrl="~/Medicos.aspx" />
                    <asp:Button ID="Button3" runat="server" Text="GESTIONAR TURNOS" CssClass="btn btnGestion" PostBackUrl="~/Turnos.aspx" />
                    <asp:Button ID="Button4" runat="server" Text="INFORMES" CssClass="btn btnGestion" PostBackUrl="~/Informes.aspx" />
                </div>
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
