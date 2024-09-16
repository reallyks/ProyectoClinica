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
    public partial class Pacientes : System.Web.UI.Page
    {
        NegocioPacientes np = new NegocioPacientes();
        NegocioProvincia negp = new NegocioProvincia();
        NegocioLocalidades negl = new NegocioLocalidades();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Session["Nombre"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                HtmlControl modal = (HtmlControl)FindControl("modal");
                HtmlControl modalRegistrar = (HtmlControl)FindControl("formPaciente");
                modal.Style["visibility"] = "hidden";
                modalRegistrar.Style["visibility"] = "hidden";
                ListadoPacientesDeAlta();
                lblUsuario.Text = Session["Nombre"].ToString();

                ///PROVINCIA
                ddlProvincia.DataSource = negp.ObtenerProvincias();
                ddlProvincia.DataTextField = "Nombre_PR";
                ddlProvincia.DataValueField = "IdProvincia_PR";
                ddlProvincia.DataBind();

                ///LOCALIDAD
                string sv = ddlProvincia.SelectedValue;
                ddlLocalidad.DataSource = negl.ObtenerLocalidades(sv);
                ddlLocalidad.DataTextField = "Nombre_LO";
                ddlLocalidad.DataValueField = "IdProvincia_LO";
                ddlLocalidad.DataBind();
            }
        }

        public void ListadoPacientesDeAlta()
        {
            gvPacientes.DataSource = np.ListadoPacientes();
            gvPacientes.DataBind();
        }

        public void ListadoPacientesDeBaja()
        {
            gvPacientes.DataSource = np.ListadoPacientesDeBaja();
            gvPacientes.DataBind();
        }


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            modal.Style["visibility"] = modal.Style["visibility"] == "hidden" ? "visible" : "hidden";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            modal.Style["visibility"] = "hidden";
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;
            this.ListadoPacientesDeAlta();
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            HtmlControl modalRegistrar = (HtmlControl)FindControl("formPaciente");
            modalRegistrar.Style["visibility"] = modalRegistrar.Style["visibility"] == "hidden" ? "visible" : "hidden";
            lblConfirmacion.Text = "";

            tbDni.Text = "";
            tbNombre.Text = "";
            tbApellido.Text = "";
            tbNacionalidad.Text = "";
            tbFechaNac.Text = "";
            tbDireccion.Text = "";
            tbCorreo.Text = "";
            tbTelefono.Text = "";
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            HtmlControl modalRegistrar = (HtmlControl)FindControl("formPaciente");
            modalRegistrar.Style["visibility"] = "hidden";
        }

        protected void BtnRegistrarPaciente_Click(object sender, EventArgs e)
        {
            DateTime fechaNacimiento = DateTime.Parse(tbFechaNac.Text);
            Paciente paciente = new Paciente();
            NegocioPacientes negocioPac = new NegocioPacientes();
            int anioNacimiento = fechaNacimiento.Year;
            if (negocioPac.VerificarNacimiento(anioNacimiento))
            {
            paciente.setDni(tbDni.Text);
            paciente.setNombre(tbNombre.Text);
            paciente.setApellido(tbApellido.Text);
            paciente.setSexo(ddlSexo.SelectedItem.ToString());
            paciente.setNacionalidad(tbNacionalidad.Text);
            paciente.setFechaNac(fechaNacimiento);
            paciente.setDireccion(tbDireccion.Text);
            paciente.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
            paciente.setCorreoElectronico(tbCorreo.Text);
            paciente.setTelefono(tbTelefono.Text);
            paciente.setEstado(true);
            if (np.ExistePaciente(paciente.getDni()))
            {
                if (np.ExistePacienteDadoDeBaja(paciente.getDni()))
                {
                    lblConfirmacion.Text = "EL PACIENTE YA EXISTE PERO ESTA DADO DE BAJA";
                }
                else
                {
                        
                    lblConfirmacion.Text = "YA EXISTE UN PACIENTE CON ESE DNI";
                }
            }
            else if (np.AgregarPaciente(paciente))
            {
                ListadoPacientesDeAlta();
                lblConfirmacion.ForeColor = System.Drawing.Color.Green;
                lblConfirmacion.Text = "AGREGADO CON EXITO";

                tbDni.Text = "";
                tbNombre.Text = "";
                tbApellido.Text = "";
                tbNacionalidad.Text = "";
                tbFechaNac.Text = "";
                tbDireccion.Text = "";
                tbCorreo.Text = "";
                tbTelefono.Text = "";
            }
            }
            else
            {
                lblConfirmacion.Text = "INGRESE UNA FECHA VALIDA";
                tbFechaNac.Text = "";
            }

        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sv = ddlProvincia.SelectedValue;
            ddlLocalidad.DataSource = negl.ObtenerLocalidades(sv);
            ddlLocalidad.DataTextField = "Nombre_LO";
            ddlLocalidad.DataValueField = "IdProvincia_LO";
            ddlLocalidad.DataBind();
        }

        protected void btnMostrarBaja_Click(object sender, EventArgs e)
        {
            if (btnMostrarBaja.Text == "MOSTRAR PACIENTES DE BAJA")
            {
                btnMostrarBaja.Text = "MOSTRAR PACIENTES DE ALTA";
                ListadoPacientesDeBaja();
            }
            else
            {
                btnMostrarBaja.Text = "MOSTRAR PACIENTES DE BAJA";
                ListadoPacientesDeAlta();
            }
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            string busqueda = tbBusqueda.Text;
            if (string.IsNullOrEmpty(busqueda))
            {
                ListadoPacientesDeAlta();
            }

            if (btnMostrarBaja.Text == "MOSTRAR PACIENTES DE ALTA")
            {
                btnMostrarBaja.Text = "MOSTRAR PACIENTES DE BAJA";
            }

            gvPacientes.DataSource = np.BuscarPaciente(busqueda);
            gvPacientes.DataBind();

            if (gvPacientes.Rows.Count == 0)
            {
                lbMensaje.Text = "NO SE HAN ENCONTRADO RESULTADOS";
            }
            else
            {
                lbMensaje.Text = "";
            }
        }

        protected void gvPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string DniPaciente = ((Label)gvPacientes.Rows[e.RowIndex].FindControl("lblDni")).Text;

            if (np.ObtenerEstadoPaciente(DniPaciente))
            {
                np.DarDeBajaPaciente(DniPaciente);
                ListadoPacientesDeAlta();
            }
            else
            {
                np.DarDeAltaPaciente(DniPaciente);
                ListadoPacientesDeBaja();
            }
        }
        protected void gvPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string dni = ((Label)gvPacientes.Rows[e.RowIndex].FindControl("lblDni")).Text;
            string nombre = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("tbNombre")).Text;
            string apellido = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("tbApellido")).Text;
            string sexo = ((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddlSexo")).SelectedItem.Text;
            string nacionalidad = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("tbNacionalidad")).Text;
            string fecha = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("tbFechaNac")).Text;
            string direccion = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("tbDireccion")).Text;
            string correo = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("tbCorreo")).Text;
            string telefono = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("tbTelefono")).Text;

            if (np.ConfirmarActualizacion(nombre, apellido, sexo, nacionalidad, fecha, direccion, correo, telefono))
            {
                DateTime fechaSeleccionada = DateTime.Parse(fecha);
                if (np.VerificarNacimiento(fechaSeleccionada.Year))
                {
                lbMensaje.Text = "";
                Paciente paciente = new Paciente();
                paciente.setDni(dni);
                paciente.setNombre(nombre);
                paciente.setApellido(apellido);
                paciente.setSexo(sexo);
                paciente.setNacionalidad(nacionalidad);
                paciente.setFechaNac(fechaSeleccionada);
                paciente.setDireccion(direccion);
                paciente.setCorreoElectronico(correo);
                paciente.setTelefono(telefono);

                np.ActualizarPaciente(paciente);
                gvPacientes.EditIndex = -1;

                    if (btnMostrarBaja.Text == "MOSTRAR PACIENTES DE BAJA")
                    {
                        ListadoPacientesDeAlta();
                    }
                    else
                    {
                        ListadoPacientesDeBaja();
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


        protected void gvPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPacientes.EditIndex = -1;
            ListadoPacientesDeAlta();
        }

        protected void gvPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPacientes.EditIndex = e.NewEditIndex;
            ListadoPacientesDeAlta();
        }


    }
}