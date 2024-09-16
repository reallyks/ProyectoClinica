<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Vistas.Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Medicos</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager3" runat="server"></asp:ScriptManager>
        <div id="modal" class="modal_container" runat="server">
            <div class="modal_content">
                <div class="modal_header">
                    <span class="modal_title">DESEA CERRAR SESION?</span>
                </div>
                <div class="modal_buttons">
                    <asp:Button ID="Button1" class="modal_button btnCerrar" runat="server" Text="Cerrar sesion" PostBackUrl="~/Login.aspx" />
                    <asp:Button ID="Button2" class="modal_button" runat="server" Text="Cancelar"/>
                </div>
            </div>
        </div>

        <div id="formMedico" class="form_container" runat="server">
            <div class="form_content">
                <div class="form_header">
                    <asp:Label ID="Label10" runat="server" Text="Label">REGISTRAR MEDICO</asp:Label>
                </div>
                <div class="form_texts">
                    <div class="form_textsGroup">
                        <asp:Label ID="Label9" runat="server"          Text="Label">NOMBRE</asp:Label>
                        <asp:TextBox ID="TbNombre"                      runat="server" CssClass="form_campos" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TbNombre" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label11" runat="server" Text="APELLIDO"></asp:Label>
                    <asp:TextBox ID="TbApellido" CssClass="form_campos" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TbApellido" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label12" runat="server" Text="SEXO"></asp:Label>
                    <asp:DropDownList ID="DdlSexo" CssClass="form_campos" runat="server">
                        <asp:ListItem>MASCULINO</asp:ListItem>
                        <asp:ListItem>FEMENINO</asp:ListItem>
                        <asp:ListItem>PREFIERO NO CONTESTAR</asp:ListItem>
                    </asp:DropDownList>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label13" runat="server" Text="NACIONALIDAD"></asp:Label>
                    <asp:TextBox ID="TbNacionalidad" CssClass="form_campos" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TbNacionalidad" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label14" runat="server" Text="FECHA DE NACIMIENTO"></asp:Label>
                    <asp:TextBox ID="TbFechaNac" runat="server" CssClass="form_campos" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TbFechaNac" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label15" runat="server" Text="DIRECCION"></asp:Label>
                    <asp:TextBox ID="TbDireccion" runat="server" CssClass="form_campos" MaxLength="25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TbDireccion" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label16" runat="server" Text="PROVINCIA"></asp:Label>
                    <asp:DropDownList ID="DdlProvincia" CssClass="form_campos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlProvincia_SelectedIndexChanged">
                        <asp:ListItem>SELECCIONE UNA PROVINCIA</asp:ListItem>
                    </asp:DropDownList>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label17" runat="server" Text="LOCALIDAD"></asp:Label>
                    <asp:DropDownList ID="DdlLocalidad" CssClass="form_campos" runat="server">
                        <asp:ListItem>SELECCIONE UNA LOCALIDAD</asp:ListItem>
                    </asp:DropDownList>
                        <br />
                        </div>
                    <br />
                    <div class="form_textsGroup">
                    <asp:Label ID="Label18" runat="server" Text="CORREO ELECTRONICO"></asp:Label>
                    <asp:TextBox ID="TbCorreo" runat="server" CssClass="form_campos" TextMode="Email" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TbCorreo" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                        </div>
                    <br />
                    <div class="form_textsGroup">
                        <asp:Label ID="Label19" runat="server" Text="TELEFONO"></asp:Label>
                        <asp:TextBox ID="TbTelefono" runat="server" CssClass="form_campos" TextMode="Number" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TbTelefono" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="form_textsGroup">
                        <asp:Label ID="Label20" runat="server" Text="ESPECIALIDAD"></asp:Label>
                    <asp:DropDownList ID="DdlEspecialidad" CssClass="form_campos" runat="server">
                        <asp:ListItem>SELECCIONE UNA ESPECIALIDAD</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    <br />
                    <div class="form_textsGroup">
                        <asp:Label ID="Label23" runat="server" Text="ASIGNAR USUARIO"></asp:Label>
                        <asp:TextBox ID="TbAsignarUsuario" runat="server" CssClass="form_campos" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TbAsignarUsuario" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="form_textsGroup">
                        <asp:Label ID="Label24" runat="server" Text="ASIGNAR CONTRASENA"></asp:Label>
                        <asp:TextBox ID="TbAsignarContraseña" runat="server" CssClass="form_campos" MaxLength="15"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TbAsignarContraseña" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="form_textsGroup">
                        <asp:Label ID="Label25" runat="server" Text="CONFIRMAR CONTRASENA"></asp:Label>
                        <asp:TextBox ID="TbConfirmarContraseña" runat="server" CssClass="form_campos" TextMode="Password" MaxLength="15"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TbConfirmarContraseña" ErrorMessage="RequiredFieldValidator" ValidationGroup="1">INGRESAR</asp:RequiredFieldValidator>
                    </div>
                    <br />
               </div>

                <div class="form_buttons">
                    <asp:Button ID="btnCargarHorarios" class="modal_button" runat="server" Text="CARGAR HORARIOS" ValidationGroup="1" OnClick="BotonHorarios_Click" />
                    <asp:Button ID="BtnCancelar" class="modal_button btnCerrar" runat="server" Text="CANCELAR" OnClick="BtnCancelar_Click" />
                    <br />
                <asp:Label ID="lblConfirmacion" runat="server" CssClass="lbConfirmacion"></asp:Label>
                </div>
            </div>
        </div>
        <div id="formHorarios" class="form_container2" runat="server">
            <div id="formContent" class="form_content">
                <div class="form_header">
                    <asp:Label ID="lblDias" runat="server" Text="Label">DIAS</asp:Label>
                </div>
            <div class="form_texts">
                    <div class="form_textsGroup">
                        </div>
                <br />
                <div id="DiaLunes" class="form_textsGroup">
                        <asp:Label ID="LblLunes" runat="server" Text="Horario Lunes"></asp:Label>
                        <asp:DropDownList ID="DdlHorarioLunes" CssClass="form_campos" runat="server">
                        <asp:ListItem Value="0">SELECCIONE UN HORARIO</asp:ListItem>
                            <asp:ListItem Value="1">08:00 / 16:00</asp:ListItem>
                            <asp:ListItem Value="3">10:00 / 18:00</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                <br />
                <div id="DiaMartes" class="form_textsGroup" >
                        <asp:Label ID="LblMartes" runat="server" Text="Horario Martes"></asp:Label>
                        <asp:DropDownList ID="DdlHorarioMartes" CssClass="form_campos" runat="server">
                        <asp:ListItem Value="0">SELECCIONE UN HORARIO</asp:ListItem>
                            <asp:ListItem Value="1">08:00 / 16:00</asp:ListItem>
                            <asp:ListItem Value="3">10:00 / 18:00</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                <br />
                <div class="form_textsGroup" id="DiaMiercoles">
                        <asp:Label ID="LblMiercoles" runat="server" Text="Horario Miercoles"></asp:Label>
                        <asp:DropDownList ID="DdlHorarioMiercoles" CssClass="form_campos" runat="server">
                        <asp:ListItem Value="0">SELECCIONE UN HORARIO</asp:ListItem>
                            <asp:ListItem Value="1">08:00 / 16:00</asp:ListItem>
                            <asp:ListItem Value="3">10:00 / 18:00</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                <br />
                <div class="form_textsGroup" id="DiaJueves">
                        <asp:Label ID="LblJueves" runat="server" Text="Horario Jueves"></asp:Label>
                        <asp:DropDownList ID="DdlHorarioJueves" CssClass="form_campos" runat="server">
                        <asp:ListItem Value="0">SELECCIONE UN HORARIO</asp:ListItem>
                            <asp:ListItem Value="1">08:00 / 16:00</asp:ListItem>
                            <asp:ListItem Value="3">10:00 / 18:00</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                <br />
                <div class="form_textsGroup" id="DiaViernes">
                        <asp:Label ID="LblViernes" runat="server" Text="Horario Viernes"></asp:Label>
                        <asp:DropDownList ID="DdlHorarioViernes" CssClass="form_campos" runat="server">
                        <asp:ListItem Value="0">SELECCIONE UN HORARIO</asp:ListItem>
                            <asp:ListItem Value="1">08:00 / 16:00</asp:ListItem>
                            <asp:ListItem Value="3">10:00 / 18:00</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                <br />
                <div class="form_textsGroup" id="DiaSabado">
                        <asp:Label ID="LblSabado" runat="server" Text="Horario Sabado"></asp:Label>
                        <asp:DropDownList ID="DdlHorarioSabado" CssClass="form_campos" runat="server">
                        <asp:ListItem Value="0">SELECCIONE UN HORARIO</asp:ListItem>
                            <asp:ListItem Value="1">08:00 / 16:00</asp:ListItem>
                            <asp:ListItem Value="3">10:00 / 18:00</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                <div class="form_textsGroup">
                        </div>
                </div>
                <div class="form_buttons">
                    <asp:Button ID="BtnRegistrar" class="modal_button" runat="server" Text="REGISTRAR" OnClick="BotonRegistrar_Click" />
                    <asp:Button ID="BtnCancelarHorario" class="modal_button btnCerrar" runat="server" Text="CANCELAR" OnClick="BtnCancelar_Click" />
                    <br />
                <asp:Label ID="LblHorarioAgregado" runat="server" CssClass="lbConfirmacion"></asp:Label>
                </div>
        </div>
        </div>
       <div id="div1" class="main">

        <div id="nav" class="nav">

            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="img_nav" ImageUrl="~/img/logo.png" PostBackUrl="~/Home.aspx" />
            <div class="nav_links">

                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="nav_link" NavigateUrl="~/Pacientes.aspx">PACIENTES</asp:HyperLink>
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="nav_link" NavigateUrl="~/Medicos.aspx">MEDICOS</asp:HyperLink>
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="nav_link" NavigateUrl="~/Turnos.aspx">GESTIONAR TURNOS</asp:HyperLink>
                <asp:HyperLink ID="HyperLink5" runat="server" CssClass="nav_link" NavigateUrl="~/Informes.aspx">INFORMES</asp:HyperLink>

            </div>
            <div class="nav_sesion">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="nav_link"></asp:Label>
                <div class="nav_svg">
                    <asp:ImageButton ID="imgCerrar" runat="server" CssClass="svg" ImageUrl="~/img/cerrar.svg"  />
                </div>
            </div>


        </div>
            <div id="div2" class="main_container main_container_2">
                <asp:Label ID="Label3" runat="server" Text="MEDICOS" CssClass="titulo"></asp:Label>
&nbsp;
                <div class="busqueda_container">
                    <asp:Label ID="Label8" runat="server" Text="BUSCAR MEDICO POR NOMBRE:"></asp:Label>
                    <asp:TextBox ID="tbBusqueda" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnBuscar" runat="server" CssClass="btnBuscar" Text="BUSCAR" OnClick="BtnBuscar_Click" />
                    <asp:Button ID="BtnMostrarBaja" runat="server" CssClass="btnBuscar" Text="MOSTRAR MEDICOS DE BAJA" OnClick="BtnMostrarBaja_Click" />
                    <br />
                </div>
                
&nbsp;
                <asp:GridView ID="grdMedicos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="gridview" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" PageSize="5" OnPageIndexChanging="GrdMedicos_PageIndexChanging" OnRowDeleting="grdMedicos_RowDeleting" OnRowCancelingEdit="grdMedicos_RowCancelingEdit" OnRowEditing="grdMedicos_RowEditing" OnRowUpdating="grdMedicos_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="ID Medico">
                            <ItemTemplate>
                                <asp:Label ID="lblIdMedico" runat="server" Text='<%# Bind("IdMedico_ME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="Tb_eit_Nombre" runat="server" Text='<%# Bind("Nombre_ME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre_ME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="Tb_eit_Apellido" runat="server" Text='<%# Bind("Apellido_ME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("Apellido_ME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:DropDownList ID="Ddl_eit_Sexo" runat="server">
                                    <asp:ListItem>MASCULINO</asp:ListItem>
                                    <asp:ListItem>FEMENINO</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("Sexo_ME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="Tb_eit_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad_ME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNacionalidad" runat="server" Text='<%# Bind("Nacionalidad_ME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fec. Nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="TbFechaNac" runat="server" Text='<%# Bind("FechaNac_ME") %>' TextMode="Date"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFechanacimiento" runat="server" Text='<%# Bind("FechaNac_ME", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion">
                            <EditItemTemplate>
                                <asp:TextBox ID="Tb_eit_Direccion" runat="server" Text='<%# Bind("Direccion_ME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("Direccion_ME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo">
                            <EditItemTemplate>
                                <asp:TextBox ID="Tb_eit_Correo" runat="server" Text='<%# Bind("CorreoElectronico_ME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCorreoEle" runat="server" Text='<%# Bind("CorreoElectronico_ME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="Tb_eit_Telefono" runat="server" Text='<%# Bind("Telefono_ME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("Telefono_ME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:Label ID="lbMensaje" runat="server"></asp:Label>
                <br />

                <asp:Button ID="BtnRegistrarMedico" CssClass="btnAgregar" runat="server" Text="REGISTRAR MEDICO" OnClick="BtnRegistrarMedico_Click" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="volver" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
            </div>
            <div id="footer" class="footer">&nbsp;
                <div id="footerNav" class="footerNav">
                    <asp:Label ID="Label1" runat="server" Text="All Rights Reserved © "></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Developed by GROUP 9"></asp:Label>
                </div>
            </div>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString %>" SelectCommand="SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal] FROM [Sucursal]"></asp:SqlDataSource>
    </form>
</body>
</html>
