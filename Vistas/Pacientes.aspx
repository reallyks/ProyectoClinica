<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Vistas.Pacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>PACIENTES</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div id="modal" class="modal_container" runat="server">
            <div class="modal_content">
                <div class="modal_header">
                    <span class="modal_title">DESEA CERRAR SESION?</span>
                </div>
                <div class="modal_buttons">
                    <asp:Button ID="btnCerrarSesion" class="modal_button btnCerrar" runat="server" Text="Cerrar sesion" OnClick="btnCerrarSesion_Click" />
                    <asp:Button ID="Button2" class="modal_button" runat="server" Text="Cancelar" OnClick="Button2_Click" />
                </div>
            </div>
        </div>

        <div id="formPaciente" class="form_container" runat="server">
            <div id="formContent" class="form_content">
                <div class="form_header">
                    <asp:Label ID="Label10" runat="server" Text="Label">REGISTRAR PACIENTE</asp:Label>
                </div>
                <div class="form_texts">
                    <div class="form_textsGroup">
                    <asp:Label ID="Label4" runat="server" Text="DNI"></asp:Label>
                    <asp:TextBox ID="tbDni" CssClass="form_campos" runat="server" MaxLength="8"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDni" ErrorMessage="RequiredFieldValidator" ValidationGroup="registrar">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                        <asp:Label ID="Label9" runat="server"          Text="Label">NOMBRE</asp:Label>
                        <asp:TextBox ID="tbNombre"                      runat="server" CssClass="form_campos" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbApellido" ErrorMessage="RequiredFieldValidator" ValidationGroup="registrar">INGRESAR</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label11" runat="server" Text="APELLIDO"></asp:Label>
                    <asp:TextBox ID="tbApellido" CssClass="form_campos" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbApellido" ErrorMessage="RequiredFieldValidator" ValidationGroup="registrar">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label12" runat="server" Text="SEXO"></asp:Label>
                    <asp:DropDownList ID="ddlSexo" CssClass="form_campos" runat="server">
                        <asp:ListItem>MASCULINO</asp:ListItem>
                        <asp:ListItem>FEMENINO</asp:ListItem>
                        <asp:ListItem>PREFIERO NO CONTESTAR</asp:ListItem>
                    </asp:DropDownList>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label13" runat="server" Text="NACIONALIDAD"></asp:Label>
                    <asp:TextBox ID="tbNacionalidad" CssClass="form_campos" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbNacionalidad" ErrorMessage="RequiredFieldValidator" ValidationGroup="registrar">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="lblNacionalidad" runat="server" Text="FECHA DE NACIMIENTO"></asp:Label>
                    <asp:TextBox ID="tbFechaNac" runat="server" CssClass="form_campos" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbFechaNac" ErrorMessage="RequiredFieldValidator" ValidationGroup="registrar">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label15" runat="server" Text="DIRECCION"></asp:Label>
                    <asp:TextBox ID="tbDireccion" runat="server" CssClass="form_campos" MaxLength="25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbDireccion" ErrorMessage="RequiredFieldValidator" ValidationGroup="registrar">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label16" runat="server" Text="PROVINCIA"></asp:Label>
                    <asp:DropDownList ID="ddlProvincia" CssClass="form_campos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                        <asp:ListItem>SELECCIONE UNA PROVINCIA</asp:ListItem>
                    </asp:DropDownList>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label17" runat="server" Text="LOCALIDAD"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidad" CssClass="form_campos" runat="server">
                        <asp:ListItem>SELECCIONE UNA LOCALIDAD</asp:ListItem>
                    </asp:DropDownList>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label18" runat="server" Text="CORREO ELECTRONICO"></asp:Label>
                    <asp:TextBox ID="tbCorreo" runat="server" CssClass="form_campos" TextMode="Email" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbCorreo" ErrorMessage="RequiredFieldValidator" ValidationGroup="registrar">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                        <asp:Label ID="Label19" runat="server" Text="TELEFONO"></asp:Label>
                        <asp:TextBox ID="tbTelefono" runat="server" CssClass="form_campos" TextMode="Number" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbTelefono" ErrorMessage="RequiredFieldValidator" ValidationGroup="registrar">INGRESAR</asp:RequiredFieldValidator>
                    </div>
               </div>

                <div class="form_buttons">
                    <asp:Button ID="BtnRegistrarPaciente" class="modal_button" runat="server" Text="REGISTRAR" OnClick="BtnRegistrarPaciente_Click" ValidationGroup="registrar"/>
                    <asp:Button ID="BtnCancelar" class="modal_button btnCerrar" runat="server" Text="CERRAR" OnClick="BtnCancelar_Click" />
                    <br />
                <asp:Label ID="lblConfirmacion" runat="server" CssClass="lbConfirmacion"></asp:Label>
                </div>
            </div>
        </div>

       <div id="div1" class="main">

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
                    <asp:ImageButton ID="imgCerrar" runat="server" CssClass="svg" ImageUrl="~/img/cerrar.svg" OnClick="ImageButton2_Click" />
                </div>
            </div>


        </div>
            <div id="div2" class="main_container main_container_2">
                <asp:Label ID="Label3" runat="server" Text="PACIENTES" CssClass="titulo"></asp:Label>
&nbsp;
                <div class="busqueda_container">
                    <asp:Label ID="Label8" runat="server" Text="BUSCAR PACIENTE POR NOMBRE:"></asp:Label>
                    <asp:TextBox ID="tbBusqueda" runat="server" ValidationGroup="buscar"></asp:TextBox>
                    <asp:Button ID="btnBuscarPaciente" runat="server" CssClass="btnBuscar" Text="BUSCAR" OnClick="btnBuscarPaciente_Click" ValidationGroup="buscar" />
                    <asp:Button ID="btnMostrarBaja" runat="server" CssClass="btnBuscar" Text="MOSTRAR PACIENTES DE BAJA" OnClick="btnMostrarBaja_Click" />
                    <br />
                </div>
                
&nbsp;
                <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" CssClass="gridview" AutoGenerateEditButton="True" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" AutoGenerateDeleteButton="True" PageSize="5" OnRowDeleting="gvPacientes_RowDeleting" OnRowCancelingEdit="gvPacientes_RowCancelingEdit" OnRowEditing="gvPacientes_RowEditing" OnRowUpdating="gvPacientes_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="DNI">
                            <ItemTemplate>
                                <asp:Label ID="lblDni" runat="server" Text='<%# Bind("Dni_PA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbNombre" runat="server" MaxLength="10" Text='<%# Bind("Nombre_PA") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre_PA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbApellido" runat="server" CssClass="auto-style1" MaxLength="10" Text='<%# Bind("Apellido_PA") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("apellido_PA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlSexo" runat="server">
                                    <asp:ListItem>MASCULINO</asp:ListItem>
                                    <asp:ListItem>FEMENINO</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("Sexo_PA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbNacionalidad" runat="server" Text='<%# Bind("Nacionalidad_PA") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNacionalidad" runat="server" Text='<%# Bind("nacionalidad_PA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fec. Nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbFechaNac" runat="server" TextMode="Date"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFechaNac" runat="server" Text='<%# Bind("fechanac_PA", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbDireccion" runat="server" Text='<%# Bind("Direccion_PA") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("direccion_PA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbCorreo" runat="server" MaxLength="30" TextMode="Email" Text='<%# Bind("CorreoElectronico_PA") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCorreo" runat="server" Text='<%# Bind("correoElectronico_PA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbTelefono" runat="server" MaxLength="10" TextMode="Phone" Text='<%# Bind("Telefono_PA") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("telefono_PA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lbMensaje" runat="server"></asp:Label>
                <br />
                <asp:Button ID="BtnRegistrar" CssClass="btnAgregar" runat="server" Text="REGISTRAR PACIENTE" OnClick="BtnRegistrar_Click" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="volver" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
            </div>
            <div id="footer" class="footer">&nbsp;
                <div id="footerNav" class="footerNav">
                    <asp:Label ID="Label1" runat="server" Text="All Rights Reserved © "></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Developed by GROUP 9"></asp:Label>
                </div>
            </div>
        </div>

        

    </form>
</body>
</html>