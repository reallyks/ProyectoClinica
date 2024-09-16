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
    public partial class Turnos : System.Web.UI.Page
    {
        NegocioEspecialidades negEsp = new NegocioEspecialidades();
        NegocioMedicos negm = new NegocioMedicos();
        NegocioTurnos negt = new NegocioTurnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["Nombre"].ToString();

                // ESPECIALIDADES
                ListadoEspecialidades();

                // MEDICOS
                ListadoMedicoPorEspecialidad();

                ListadoTurnosDisponibles();
            }
        }

        public void ListadoTurnosDisponibles()
        {
            int idMedico = Convert.ToInt32(DdlProfesional.SelectedValue);
            lvTurnos.DataSource = negt.ObtenerTablaTurnosDisponibles(idMedico);
            lvTurnos.DataBind();
        }

        public void ListadoEspecialidades()
        {
            DdlEspecialidad.DataSource = negEsp.ObtenerEspecialidades();
            DdlEspecialidad.DataTextField = "Nombre_ES";
            DdlEspecialidad.DataValueField = "IdEspecialidad_ES";
            DdlEspecialidad.DataBind();
        }

        public void ListadoMedicoPorEspecialidad()
        {
            string svm = DdlEspecialidad.SelectedValue;
            DdlProfesional.DataSource = negm.buscarMedicoPorEspecialidad(svm);
            DdlProfesional.DataTextField = "NombreCompleto_ME";
            DdlProfesional.DataValueField = "IdMedico_ME";
            DdlProfesional.DataBind();
        }

        protected void DdlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListadoMedicoPorEspecialidad();
        }

        protected void DdlProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListadoTurnosDisponibles();
        }

        protected void lvTurnos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                DropDownList ddlHorarios = (DropDownList)e.Item.FindControl("ddlHorarios");
                Label lblDia = (Label)e.Item.FindControl("lbDia");

                if (ddlHorarios != null && lblDia != null)
                {
                    int idMedico = Convert.ToInt32(DdlProfesional.SelectedValue);
                    string dia = lblDia.Text;
                    dia = negt.traducirDiasEspanol(dia);
                    DataTable horarios = negt.ObtenerHorarioMedico(idMedico, dia);

                    if (horarios != null && horarios.Rows.Count > 0)
                    {
                        ddlHorarios.DataSource = horarios;
                        ddlHorarios.DataTextField = "HORARIOS";
                        ddlHorarios.DataValueField = "DIAS";
                        ddlHorarios.DataBind();
                    }
                }
            }
        }

        protected void btnAsignar_Command(object sender, CommandEventArgs e)
        {
            
            NegocioPacientes negp = new NegocioPacientes();
            Entidades.Turnos turno = new Entidades.Turnos();
            ListViewItem item = (sender as Button).NamingContainer as ListViewItem;
            TextBox tbDni = (TextBox)item.FindControl("tbDni");
            DropDownList ddlHorarios = (DropDownList)item.FindControl("ddlHorarios");

            string commandName = e.CommandName;
            string commandArgument = e.CommandArgument.ToString();

            if (commandName == "Asignar")
            {
                string[] args = commandArgument.Split(',');
                string id = args[0];
                string fecha = args[1];
                string dni = tbDni.Text;
                string horario = ddlHorarios.SelectedItem.ToString();


                if (negp.ExistePaciente(dni))
                {
                    turno.setIdMedico(Convert.ToInt32(id));
                    turno.setDniPac(dni);
                    turno.setFechaTurno(fecha);
                    turno.setHorario(horario);
                    if (negt.AgregarTurno(turno))
                    {
                        lbMensajeError.Text = "AGENDADO CON EXITO";
                    }
                    else
                    {
                        lbMensajeError.Text = "ERROR";
                    }
                    
                }
                else
                {
                    lbMensajeError.Text = "NO SE ENCUENTRA PACIENTE CON ESE DNI";
                }
            }
        }

    }
}
