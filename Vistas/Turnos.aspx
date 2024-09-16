<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Vistas.Turnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Turnos</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

         <div id="div1" class="main noHeight">
        <div id="nav" class="nav">

            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="img_nav" ImageUrl="/img/logo.png" PostBackUrl="/Home.aspx" />
            <div class="nav_links">

                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="nav_link" NavigateUrl="~/Pacientes.aspx">PACIENTES</asp:HyperLink>
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="nav_link" NavigateUrl="~/Medicos.aspx">MEDICOS</asp:HyperLink>
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="nav_link" NavigateUrl="~/Turnos.aspx">GESTIONAR TURNOS</asp:HyperLink>
                <asp:HyperLink ID="HyperLink5" runat="server" CssClass="nav_link" NavigateUrl="~/Informes.aspx">INFORMES</asp:HyperLink>

            </div>
            <div class="nav_sesion">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="nav_link"></asp:Label>
                <div class="nav_svg">
                    <asp:ImageButton ID="ImageButton2" runat="server" CssClass="svg" ImageUrl="/img/cerrar.svg" PostBackUrl="/Login.aspx" />
                </div>
            </div>

        </div>
            <div id="div2" class="main_container main_container_2">
                <asp:Label ID="Label3" runat="server" Text="TURNOS" CssClass="titulo"></asp:Label>
    <div class="turnos_content">

        
                <asp:Label ID="Label8" runat="server" Text="SELECCIONE UNA ESPECIALIDAD" CssClass="turnos_text"></asp:Label>
                <asp:DropDownList ID="DdlEspecialidad" runat="server" CssClass="turnos_select" AutoPostBack="True" OnSelectedIndexChanged="DdlEspecialidad_SelectedIndexChanged">
                    <asp:ListItem>ESPECIALIDAD</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="Label9" runat="server" Text="SELECCIONE UN PROFESIONAL" CssClass="turnos_text"></asp:Label>
                <asp:DropDownList ID="DdlProfesional" runat="server" CssClass="turnos_select" AutoPostBack="True" OnSelectedIndexChanged="DdlProfesional_SelectedIndexChanged">
                    <asp:ListItem>PROFESIONAL</asp:ListItem>
                </asp:DropDownList>

         
    </div>
                <div class="turnos_disponibles">

                    <asp:Label ID="Label10" runat="server" Text="TURNOS DISPONIBLES" CssClass="turnos_text"></asp:Label>

                            <asp:ListView ID="lvTurnos" runat="server" GroupItemCount="3" OnItemDataBound="lvTurnos_ItemDataBound">
                                <AlternatingItemTemplate>
                                    <td runat="server" style="">
                                        <asp:Label ID="lbNombreCompleto" runat="server" Text='<%# Bind("nombre") %>' />
                                        <br />
                                        <asp:Label ID="lbDia" runat="server" Text='<%# Bind("dia") %>' />
                                        <br />
                                        <asp:Label ID="lbFecha" runat="server" Text='<%# Bind("fecha", "{0:dd/MM/yyyy}") %>' />
                                        <br />
                                        <asp:DropDownList ID="ddlHorarios" runat="server"></asp:DropDownList>
                                        <br />
                                         <asp:Label ID="lblIngreseDni" runat="server" Text="Dni Paciente: "></asp:Label>
                                        <asp:TextBox ID="tbDni" runat="server" TextMode="Number" MaxLength="8" ></asp:TextBox>
                                        <br />
                                        <asp:Button ID="btnAsignar" runat="server" Text="ASIGNAR" CommandName="Asignar" CommandArgument='<%# Eval("id") + "," + Eval("fecha") %>' OnCommand="btnAsignar_Command" />
                                        <br />
                                    </td>
                                </AlternatingItemTemplate>
                                <EditItemTemplate>
                                    <td runat="server" style="">NombreCompleto_ME:
                                        <asp:TextBox ID="NombreCompleto_METextBox" runat="server" Text='<%# Bind("NombreCompleto_ME") %>' />
                                        <br />
                                        HorarioIni_HO:
                                        <asp:TextBox ID="HorarioIni_HOTextBox" runat="server" Text='<%# Bind("HorarioIni_HO") %>' />
                                        <br />
                                        HorarioFin_HO:
                                        <asp:TextBox ID="HorarioFin_HOTextBox" runat="server" Text='<%# Bind("HorarioFin_HO") %>' />
                                        <br />
                                        DiaSemana_HO:
                                        <asp:TextBox ID="DiaSemana_HOTextBox" runat="server" Text='<%# Bind("DiaSemana_HO") %>' />
                                        <br />
                                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                        <br />
                                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                                        <br />
                                    </td>
                                </EditItemTemplate>
                                <EmptyDataTemplate>
                                    <table runat="server" style="">
                                        <tr>
                                            <td>NO HAY HORARIOS DISPONIBLES.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <EmptyItemTemplate>
                                    <td runat="server" />
                                </EmptyItemTemplate>
                                <GroupTemplate>
                                    <tr id="itemPlaceholderContainer" runat="server">
                                        <td id="itemPlaceholder" runat="server"></td>
                                    </tr>
                                </GroupTemplate>
                                <InsertItemTemplate>
                                    <td runat="server" style="">NombreCompleto_ME:
                                        <asp:TextBox ID="NombreCompleto_METextBox" runat="server" Text='<%# Bind("NombreCompleto_ME") %>' />
                                        <br />
                                        HorarioIni_HO:
                                        <asp:TextBox ID="HorarioIni_HOTextBox" runat="server" Text='<%# Bind("HorarioIni_HO") %>' />
                                        <br />
                                        HorarioFin_HO:
                                        <asp:TextBox ID="HorarioFin_HOTextBox" runat="server" Text='<%# Bind("HorarioFin_HO") %>' />
                                        <br />
                                        DiaSemana_HO:
                                        <asp:TextBox ID="DiaSemana_HOTextBox" runat="server" Text='<%# Bind("DiaSemana_HO") %>' />
                                        <br />
                                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                        <br />
                                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                                        <br />
                                    </td>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <td runat="server" style="">
                                       <asp:Label ID="lbNombreCompleto" runat="server" Text='<%# Bind("nombre") %>' />
                                        <br />
                                        <asp:Label ID="lbDia" runat="server" Text='<%# Bind("dia") %>' />
                                        <br />
                                        <asp:Label ID="lbFecha" runat="server" Text='<%# Bind("fecha", "{0:dd/MM/yyyy}") %>' />
                                        <br />
                                        <asp:DropDownList ID="ddlHorarios" runat="server"></asp:DropDownList>
                                        <br />
                                         <asp:Label ID="lblIngreseDni" runat="server" Text="Dni Paciente: "></asp:Label><asp:TextBox ID="tbDni" runat="server" TextMode="Number" MaxLength="8" ></asp:TextBox>
                                        <br />
                                        <asp:Button ID="btnAsignar" runat="server" Text="ASIGNAR" CommandName="Asignar" CommandArgument='<%# Eval("id") + "," + Eval("fecha") %>' OnCommand="btnAsignar_Command" />
                                        <br />
                                    </td>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table runat="server">
                                        <tr runat="server">
                                            <td runat="server">
                                                <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                                    <tr id="groupPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server">
                                            <td runat="server" style="">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvTurnos" PageSize="6" QueryStringField="pagActual">
                                                    <Fields>
                                                        <asp:NumericPagerField ButtonType="Button" ButtonCount="5" />
                                                    </Fields>
                                                </asp:DataPager>
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                <SelectedItemTemplate>
                                    <td runat="server" style="">NombreCompleto_ME:
                                        <asp:Label ID="NombreCompleto_MELabel" runat="server" Text='<%# Eval("NombreCompleto_ME") %>' />
                                        <br />
                                        HorarioIni_HO:
                                        <asp:Label ID="HorarioIni_HOLabel" runat="server" Text='<%# Eval("HorarioIni_HO") %>' />
                                        <br />
                                        HorarioFin_HO:
                                        <asp:Label ID="HorarioFin_HOLabel" runat="server" Text='<%# Eval("HorarioFin_HO") %>' />
                                        <br />
                                        DiaSemana_HO:
                                        <asp:Label ID="DiaSemana_HOLabel" runat="server" Text='<%# Eval("DiaSemana_HO") %>' />
                                        <br />
                                    </td>
                                </SelectedItemTemplate>
                            </asp:ListView>      


<asp:Label ID="lbMensajeError" CssClass="mensajeError" runat="server" Text="HOLA"></asp:Label>

                </div>
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