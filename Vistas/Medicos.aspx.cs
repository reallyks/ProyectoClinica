using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class Medicos : System.Web.UI.Page
    {
        ///ENTIDADES
        
        DiasXHorasXMedicos horario = new DiasXHorasXMedicos();
        ///NEGOCIO
        NegocioProvincia negProvincia = new NegocioProvincia();
        NegocioLocalidades negLocalidades = new NegocioLocalidades();
        NegocioEspecialidades negEspecialidades = new NegocioEspecialidades();
        NegocioMedicos negMedico = new NegocioMedicos();
        NegocioUsuarios negUsuario = new NegocioUsuarios();
        NegocioHorario negocioHorario = new NegocioHorario();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Session["Nombre"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                ListadoMedicosDeAlta();
                HtmlControl modal = (HtmlControl)FindControl("modal");
                HtmlControl modalRegistrar = (HtmlControl)FindControl("formMedico");
                HtmlControl modalHorarios = (HtmlControl)FindControl("formHorarios");
                modal.Style["visibility"] = "hidden";
                modalRegistrar.Style["visibility"] = "hidden";
                modalHorarios.Style["visibility"] = "hidden";
                lblUsuario.Text = Session["Nombre"].ToString();

                ///PROVINCIA
                DdlProvincia.DataSource = negProvincia.ObtenerProvincias();
                DdlProvincia.DataTextField = "Nombre_PR";
                DdlProvincia.DataValueField = "IdProvincia_PR";
                DdlProvincia.DataBind();

                ///LOCALIDAD
                string sv = DdlProvincia.SelectedValue;
                DdlLocalidad.DataSource = negLocalidades.ObtenerLocalidades(sv);
                DdlLocalidad.DataTextField = "Nombre_LO";
                DdlLocalidad.DataValueField = "IdProvincia_LO";
                DdlLocalidad.DataBind();

                ///ESPECIALIDAD
                DdlEspecialidad.DataSource = negEspecialidades.ObtenerEspecialidades();
                DdlEspecialidad.DataTextField = "Nombre_ES";
                DdlEspecialidad.DataValueField = "IdEspecialidad_ES";
                DdlEspecialidad.DataBind();
            }
        }

        public void ListadoMedicosDeAlta()
        {
            grdMedicos.DataSource = negMedico.ListadoMedicos();
            grdMedicos.DataBind();
        }

        public void ListadoMedicosDeBaja()
        {
            grdMedicos.DataSource = negMedico.ListadoMedicosDeBaja();
            grdMedicos.DataBind();
        }

        protected void DdlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sv = DdlProvincia.SelectedValue;
            DdlLocalidad.DataSource = negLocalidades.ObtenerLocalidades(sv);
            DdlLocalidad.DataTextField = "Nombre_LO";
            DdlLocalidad.DataValueField = "IdProvincia_LO";
            DdlLocalidad.DataBind();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            BtnRegistrar.Style["visibility"] = "hidden";
            HtmlControl modalHorarios = (HtmlControl)FindControl("formHorarios");
            HtmlControl modalRegistrar = (HtmlControl)FindControl("formMedico");
            modalHorarios.Style["visibility"] = "hidden";
            modalRegistrar.Style["visibility"] = "hidden";
        }

        protected void BtnRegistrarMedico_Click(object sender, EventArgs e)
        {
            DdlHorarioLunes.SelectedValue = "0";
            DdlHorarioMartes.SelectedValue = "0";
            DdlHorarioMiercoles.SelectedValue = "0";
            DdlHorarioJueves.SelectedValue = "0";
            DdlHorarioViernes.SelectedValue = "0";
            DdlHorarioSabado.SelectedValue = "0";
            TbNombre.Text = "";
            TbApellido.Text = "";
            TbNacionalidad.Text = "";
            TbFechaNac.Text = "";
            TbDireccion.Text = "";
            TbCorreo.Text = "";
            TbTelefono.Text = "";
            TbAsignarUsuario.Text = "";
            TbAsignarContraseña.Text = "";
            HtmlControl modalRegistrar = (HtmlControl)FindControl("formMedico");
            modalRegistrar.Style["visibility"] = modalRegistrar.Style["visibility"] == "hidden" ? "visible" : "hidden";
        }

        protected void BotonRegistrar_Click(object sender, EventArgs e)
        {
            NegocioHorario nh = new NegocioHorario();
            DateTime fechaNacimiento = DateTime.Parse(TbFechaNac.Text);
            Usuarios usuarios = new Usuarios();
            Medico medico = new Medico();
            medico.setIdMedico(negMedico.generarIdMedico());
            medico.setNombre(TbNombre.Text);
            medico.setApellido(TbApellido.Text);
            medico.setSexo(DdlSexo.SelectedItem.ToString());
            medico.setNacionalidad(TbNacionalidad.Text);
            medico.setFechanacimiento(fechaNacimiento);
            medico.setDireccion(TbDireccion.Text);
            medico.setIdLocalidad(Convert.ToInt32(DdlLocalidad.SelectedValue));
            medico.setIdEspecialidad(Convert.ToInt32(DdlEspecialidad.SelectedValue));
            medico.setCorreoElectronico(TbCorreo.Text);
            medico.setTelefono(TbTelefono.Text);
            medico.setEstado(true);
            usuarios.SetNombreUsuario(TbAsignarUsuario.Text);
            usuarios.SetContraseña(TbAsignarContraseña.Text);
            usuarios.SetTipoUsuario("MEDICO");
            LblHorarioAgregado.Text = "";

            string[] dias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };

            int[] Horarios = {0,0,0,0,0,0};
            bool estado = false;

            for (int i = 0; i < 6; i++)
            {
                string nombreDropDownList = "ddlHorario" + dias[i];

                DropDownList ddl = FindControl(nombreDropDownList) as DropDownList;

                if (ddl.SelectedIndex == 0)
                {
                    LblHorarioAgregado.Text = "INGRESE AL MENOS UN DIA DE TRABAJO";
                }
                else
                {
                    estado = true;
                    Horarios[i] = ddl.SelectedIndex;
                    LblHorarioAgregado.Text = "";
                }
            }

            if (estado)
            {
                if (negMedico.AgregarMedico(medico, usuarios))
                {
                    int dia, horario;
                    for(int i = 0; i < 6; i++)
                    {
                        if (Horarios[i] != 0)
                        {
                            dia = i + 1;
                            horario = Horarios[i];
                            nh.AsignarHorario(medico, horario, dia);
                        }
                    }
                    ListadoMedicosDeAlta();
                    LblHorarioAgregado.ForeColor = System.Drawing.Color.Green;
                    LblHorarioAgregado.Text = "AGREGADO CON EXITO";
                    BtnRegistrar.Style["visibility"] = "hidden";
                    BtnCancelarHorario.Text = "SALIR";
                }
                else
                {
                    LblHorarioAgregado.Text = "HUBO UN ERROR";
                }
            }
        }

        protected void GrdMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedicos.PageIndex = e.NewPageIndex;
            this.ListadoMedicosDeAlta();
        }

        protected void BtnMostrarBaja_Click(object sender, EventArgs e)
        {
            if (BtnMostrarBaja.Text == "MOSTRAR MEDICOS DE BAJA")
            {
                BtnMostrarBaja.Text = "MOSTRAR MEDICOS DE ALTA";
                ListadoMedicosDeBaja();
            }
            else
            {
                BtnMostrarBaja.Text = "MOSTRAR MEDICOS DE BAJA";
                ListadoMedicosDeAlta();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = tbBusqueda.Text;
            if (string.IsNullOrEmpty(busqueda))
            {
                ListadoMedicosDeAlta();
            }

            if (BtnMostrarBaja.Text == "MOSTRAR MEDICOS DE ALTA")
            {
                BtnMostrarBaja.Text = "MOSTRAR MEDICOS DE BAJA";
            }

            grdMedicos.DataSource = negMedico.BuscarMedico(busqueda);
            grdMedicos.DataBind();

            if (grdMedicos.Rows.Count == 0)
            {
                lbMensaje.Text = "NO SE HAN ENCONTRADO RESULTADOS";
            }
            else
            {
                lbMensaje.Text = "";
            }
        }

        protected void grdMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = ((Label)grdMedicos.Rows[e.RowIndex].FindControl("lblIdMedico")).Text;

            int IdMedico = Convert.ToInt32(Id);

            if (negMedico.ObtenerEstadoMedico(IdMedico))
            {
                negMedico.DarDeBajaMedico(IdMedico);
                ListadoMedicosDeAlta();
            }
            else
            {
                negMedico.DarDeAltaMedico(IdMedico);
                ListadoMedicosDeBaja();
            }
        }

        protected void grdMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMedicos.EditIndex = -1;
            ListadoMedicosDeAlta();
        }

        protected void grdMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMedicos.EditIndex = e.NewEditIndex;
            ListadoMedicosDeAlta();
        }

        protected void BotonHorarios_Click(object sender, EventArgs e)
        {
            lblConfirmacion.Text = "";
            DateTime fechaNacimiento = DateTime.Parse(TbFechaNac.Text);
            int anioNacimiento = fechaNacimiento.Year;
            string confirmacion = negMedico.ConfirmarMedico(anioNacimiento, TbAsignarContraseña.Text, TbConfirmarContraseña.Text);
            if (confirmacion == "")
            {
                if (!negUsuario.existeUsuario(TbAsignarUsuario.Text))
                {
                    LblHorarioAgregado.Text = "";
                    BtnRegistrar.Style["visibility"] = "visible";
                    BtnCancelarHorario.Text = "CANCELAR";
                    lblConfirmacion.Text = "";
                    HtmlControl modalRegistrar = (HtmlControl)FindControl("formMedico");
                    modalRegistrar.Style["visibility"] = "hidden";
                    HtmlControl modalHorarios = (HtmlControl)FindControl("formHorarios");
                    modalHorarios.Style["visibility"] = "visible";
                }
                else
                {
                    lblConfirmacion.Text = "YA EXISTE UN USUARIO CON ESE NOMBRE";
                    TbAsignarUsuario.Text = "";
                }
            }
            else if(confirmacion == "LAS CONTRASEÑAS NO SON IGUALES" || confirmacion == "LA CONTRASEÑA DEBE CONTENER 8 CARACTERES UN '.' Y UNA MAYUS")
            {
                TbAsignarContraseña.Text = "";
                TbConfirmarContraseña.Text = "";
                lblConfirmacion.Text = confirmacion;
            }
            else
            {
                TbFechaNac.Text = "";
                lblConfirmacion.Text = confirmacion;
            }
        } 

        protected void grdMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(((Label)grdMedicos.Rows[e.RowIndex].FindControl("lblIdMedico")).Text);
            string nombre = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("Tb_eit_Nombre")).Text;
            string apellido = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("Tb_eit_Apellido")).Text;
            string sexo = ((DropDownList)grdMedicos.Rows[e.RowIndex].FindControl("Ddl_eit_Sexo")).SelectedItem.Text;
            string nacionalidad = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("Tb_eit_Nacionalidad")).Text;
            string fecha = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("TbFechaNac")).Text;
            string direccion = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("Tb_eit_Direccion")).Text;
            string correo = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("Tb_eit_Correo")).Text;
            string telefono = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("Tb_eit_Telefono")).Text;
            if(negMedico.ConfirmarActualizacion(nombre,apellido, sexo, nacionalidad, fecha, direccion, correo, telefono))
            {
                DateTime fechaSeleccionada = DateTime.Parse(fecha);
                if (negMedico.VerificarNacimiento(fechaSeleccionada.Year))
                {
                        lbMensaje.Text = "";
                        Medico medico = new Medico();
                        medico.setIdMedico(id);
                        medico.setNombre(nombre);
                        medico.setApellido(apellido);
                        medico.setSexo(sexo);
                        medico.setNacionalidad(nacionalidad);
                        medico.setFechanacimiento(fechaSeleccionada);
                        medico.setDireccion(direccion);
                        medico.setCorreoElectronico(correo);
                        medico.setTelefono(telefono);

                        negMedico.ActualizarMedico(medico);
                        grdMedicos.EditIndex = -1;

                            if (BtnMostrarBaja.Text == "MOSTRAR MEDICOS DE BAJA")
                            {
                                ListadoMedicosDeAlta();
                            }
                            else
                            {
                                ListadoMedicosDeBaja();
                            }
                }
                else
                {
                    lbMensaje.Text = "INGRESE UNA FECHA VALIDA";
                }
            }
            else
            {
                lbMensaje.Text = "INGRESE TODOS LOS DATOS A EDITAR";
            }

        }
    }
}