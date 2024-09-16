<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <div id="div1" class="main noHeight">
            <div id="nav" class="nav">

                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="img_nav" ImageUrl="~/img/logo.png" PostBackUrl="~/Home.aspx" />
                <div class="nav_links">

                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="nav_link" NavigateUrl="~/Pacientes.aspx">PACIENTES</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="nav_link" NavigateUrl="~/Medicos.aspx">MEDICOS</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="nav_link" NavigateUrl="~/Turnos.aspx">GESTIONAR TURNOS</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="nav_link" NavigateUrl="~/Informes.aspx">INFORMES</asp:HyperLink>

                </div>
                <div class="nav_sesion">
                    <asp:Label ID="lblUsuario" runat="server" Text="" CssClass="nav_link"></asp:Label>
                    <div class="nav_svg">
                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="svg" ImageUrl="~/img/cerrar.svg" PostBackUrl="~/Login.aspx" />
                    </div>
                </div>
            </div>
            <div id="div2" class="main_container main_container_2">
                <asp:Label ID="Label3" runat="server" Text="INFORMES" CssClass="titulo titulo_informes_modif"></asp:Label>

                <%-- GRAFICO POR ANIO --%>

                <asp:UpdatePanel ID="UpdatePanelBarrasAnio" runat="server">
                    <ContentTemplate>

                        <div class="barras_main">
                            <div class='barras_porcentaje'>
                                <div>0%</div>
                                <div>25%</div>
                                <div>50%</div>
                                <div>75%</div>
                                <div>100%</div>
                            </div>
                            <div id="barrascontaineranio" runat="server" class="barras_container">
                            </div>
                        </div>

                        <div class="barras_indicador"> 
                            <div class="circulo"></div>
                            <asp:Label ID="Label8" cssClass="circulo_nombre" runat="server" Text="PRESENTES"></asp:Label>
                            <div class="circulo alter"></div>
                            <asp:Label ID="Label9" runat="server" Text="AUSENTES"></asp:Label>
                        </div>

                        <div class="opciones_container">
                            <asp:Label ID="Label4" CssClass="opcion_text" runat="server" Text="ELEGIR AÑO: "></asp:Label>
                            <asp:DropDownList ID="ddlAnio" CssClass="opcion_visualizacion" runat="server" Height="16px" Width="83px" AutoPostBack="True" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" >
                                <asp:ListItem>2024</asp:ListItem>
                                <asp:ListItem>2023</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <%-- GRAFICO POR MES --%>

                <asp:UpdatePanel ID="UpdatePanelBarrasMes" runat="server">
                    <ContentTemplate>
                        <div class="barras_main">
                            <div class='barras_porcentaje'>
                                    <div>0%</div>
                                    <div>25%</div>
                                    <div>50%</div>
                                    <div>75%</div>
                                    <div>100%</div>
                                </div>
                            <div id="barrascontainermes" runat="server" class="barras_container">
                            </div>
                        </div>
                        <div class="barras_indicador"> 
                            <div class="circulo"></div>
                            <asp:Label ID="circuloNombre" cssClass="circulo_nombre" runat="server" Text="PRESENTES"></asp:Label>
                            <div class="circulo alter"></div>
                            <asp:Label ID="Label6" runat="server" Text="AUSENTES"></asp:Label>
                        </div>
                        <div class="opciones_container">
                            <asp:Label ID="Label5" CssClass="opcion_text" runat="server" Text="ELEGIR MES: "></asp:Label>
                            <asp:DropDownList ID="ddlMes" CssClass="opcion_visualizacion" runat="server" Height="17px" Width="111px" AutoPostBack="true" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">
                            <asp:ListItem>ENERO</asp:ListItem>
                            <asp:ListItem>FEBRERO</asp:ListItem>
                            <asp:ListItem>MARZO</asp:ListItem>
                            <asp:ListItem>ABRIL</asp:ListItem>
                            <asp:ListItem>MAYO</asp:ListItem>
                            <asp:ListItem>JUNIO</asp:ListItem>
                            <asp:ListItem>JULIO</asp:ListItem>
                            <asp:ListItem>AGOSTO</asp:ListItem>
                            <asp:ListItem>SEPTIEMBRE</asp:ListItem>
                            <asp:ListItem>OCTUBRE</asp:ListItem>
                            <asp:ListItem>NOVIEMBRE</asp:ListItem>
                            <asp:ListItem>DICIEMBRE</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="volver" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
            </div>
            <div id="footer" class="footer">
                <div id="footerNav" class="footerNav">
                    <asp:Label ID="Label1" runat="server" Text="All Rights Reserved © "></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Developed by GROUP 9"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
