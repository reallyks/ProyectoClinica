<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeMedico.aspx.cs" Inherits="Vistas.HomeMedico" EnableEventValidation="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server">
         <div id="div1" class="main">
    <div id="formInforme" class="form_container" runat="server">
            <div class="form_content">
                <div class="form_header">
                    <asp:Label ID="Label10" runat="server" Text="Label">Ingresar Informe</asp:Label>
                </div>
                    <div class="form_header">
                        <asp:Label ID="LbTurno" runat="server" Text="Label">Turno: </asp:Label>
                        <asp:Label ID="LbIdTurno" runat="server"></asp:Label>
                    </div>
                <div class="form_texts">
                    <br />
                    <div class="form_textsGroup">
                        <asp:Label ID="Label4" runat="server"          Text="Label">PRESENTE</asp:Label>
                        <asp:CheckBox ID="CbPresente" runat="server" />
                    </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="LbObservacion" runat="server" Text="Observacion"></asp:Label>
                    <asp:TextBox ID="TbObservacion" CssClass="form_campos" runat="server" ValidationGroup="1" TabIndex="5"></asp:TextBox>
                        </div>
                    <br />
               </div>
                <div class="form_buttons">
                    <asp:Button ID="btnEnviarInforme" class="modal_button" runat="server" Text="ENVIAR" ValidationGroup="1" OnClick="BtnEnviarInforme_Click" />
                    <asp:Button ID="BtnCancelar" class="modal_button btnCerrar" runat="server" Text="CANCELAR" OnClick="BtnCancelar_Click" />
                    <br />
                <asp:Label ID="lblConfirmacion" runat="server" CssClass="lbConfirmacion"></asp:Label>
                </div>
            </div>
        </div>
        <div id="nav" class="nav">
            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" CssClass="img_nav" ImageUrl="~/img/logo.png" />
            
            <div class="nav_sesion">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="nav_link"></asp:Label>
                <div class="nav_svg">
                    <asp:ImageButton ID="ImageButton2" runat="server" CssClass="svg" ImageUrl="~/img/cerrar.svg" PostBackUrl="~/Login.aspx" />
                </div>
            </div>

        </div>
            <div id="div2" class="main_container main_container_2">
                <asp:Label ID="Label3" runat="server" Text="TURNOS" CssClass="titulo"></asp:Label>
                <br />

                <asp:Label ID="Label8" runat="server" Text="Ingrese un apellido: " style="margin:5px"></asp:Label>
                <asp:TextBox ID="txtboxBuscar" runat="server" style="margin:5px" ValidationGroup="buscar" ></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Turno" style="margin-bottom:10px" OnClick="btnBuscar_Click" ValidationGroup="buscar" Height="26px"/>
                <asp:Label ID="Label9" runat="server" Text="FILTRAR TURNOS PASADOS: " style="margin:5px"></asp:Label>
                <asp:CheckBox ID="cbFiltro" runat="server" style="margin-bottom:25px"/>
                <asp:GridView ID="grdTurnos" runat="server" AutoGenerateColumns="False" DataKeyNames="idturno" OnRowCommand="grdTurnos_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="ID TURNO">
                            <ItemTemplate>
                                <asp:Label ID="LbIdTurno" runat="server" Text='<%# Bind("idturno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DNI PACIENTE">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("dnidelpaciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NOMBRE ">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="APELLIDO">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("apellido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Button" CommandName="eventoEnviar" Text="INGRESAR INFORME" />
                    </Columns>
                </asp:GridView>
                
                <asp:Label ID="lblNoEncontro" runat="server"></asp:Label>
            </div>
            <div id="footer" class="footer">
&nbsp;<div id="footerNav" class="footerNav">
                    <asp:Label ID="Label1" runat="server" Text="All Rights Reserved © "></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Developed by GROUP 9"></asp:Label>
                </div>
            </div>
        </div>
    </form>
    </body>
</html>