using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Negocio;
using Entidades;
using System.Data.SqlClient;


namespace Vistas
{
    public partial class HomeMedico : System.Web.UI.Page
    {
        NegocioTurnos nt = new NegocioTurnos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Session["Nombre"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                NegocioTurnos nt = new NegocioTurnos();
                lblUsuario.Text = Session["Nombre"].ToString();
                HtmlControl modalInforme = (HtmlControl)FindControl("formInforme");
                modalInforme.Style["visibility"] = "hidden";
                ListadoTurnos();
            }
        }

        public void ListadoTurnos()
        {
            string idmedico = Session["Id_Usuario"].ToString();
            grdTurnos.DataSource = nt.ListadoTurnos(idmedico);
            grdTurnos.DataBind();
        }

        protected void BtnEnviarInforme_Click(object sender, EventArgs e)
        {

            string observacion = TbObservacion.Text;
            bool presente = false;
            if (CbPresente.Checked) presente = true;
            if (observacion != "" || presente == false)
            {
                int idTurno = Convert.ToInt32(LbIdTurno.Text);
                nt.InformarTurno(idTurno, presente, observacion);
                lblConfirmacion.ForeColor = System.Drawing.Color.Green;
                lblConfirmacion.Text = "INFORME COMPLETADO";
                btnEnviarInforme.Style["visibility"] = "hidden";
                BtnCancelar.Text = "SALIR";
                ListadoTurnos();
            }
            else
            {
                lblConfirmacion.Text = "INGRESE OBSERVACION";
            }

        }

        protected void grdTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eventoEnviar")
            {
                btnEnviarInforme.Style["visibility"] = "visible";
                int fila = Convert.ToInt32(e.CommandArgument);
                string Turno = ((Label)grdTurnos.Rows[fila].FindControl("LbIdTurno")).Text;
                LbIdTurno.Text = Turno;
                lblConfirmacion.Text = "";
                CbPresente.Checked = false;
                HtmlControl modalInforme = (HtmlControl)FindControl("formInforme");
                modalInforme.Style["visibility"] = "visible";

            }
        }
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            btnEnviarInforme.Style["visibility"] = "hidden";
            HtmlControl modalInforme = (HtmlControl)FindControl("formInforme");
            modalInforme.Style["visibility"] = "hidden";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            bool aplicarFiltrosAdicionales = cbFiltro.Checked;

            string busqueda = txtboxBuscar.Text;
            string idmedico = Session["Id_Usuario"].ToString();

            grdTurnos.DataSource = nt.buscarTurnoxPaciente(busqueda, idmedico, aplicarFiltrosAdicionales);
            grdTurnos.DataBind();
            lblNoEncontro.Text = "";

            if (grdTurnos.Rows.Count == 0)
            {
                lblNoEncontro.Text = "NO SE HAN ENCONTRADO RESULTADOS";
            }
        }

    }
}