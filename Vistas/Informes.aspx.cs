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
    public partial class Informes : System.Web.UI.Page
    {
        NegocioTurnos nt = new NegocioTurnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            lblUsuario.Text = Session["Nombre"].ToString();
            if (!IsPostBack)
            {
                if (nt.cantRegistrosTurnos() > 0)
                {
                    MostrarPorMes();
                    MostrarPorAnio();
                }
                else
                {
                    return;
                }
            }
        }

        void MostrarPorMes()
        {
            List<float> listaPresencia = new List<float>();
            int mesSeleccionado = ddlMes.SelectedIndex + 1;
            string mesSeleccionadoText = ddlMes.SelectedItem.ToString();
            int anioSeleccionado = Convert.ToInt32(ddlAnio.SelectedItem.Text);

            nt.ObtenerPorcentajePresenciaMes(listaPresencia, mesSeleccionado, anioSeleccionado);

            float presentes = listaPresencia[0];
            float ausentes = listaPresencia[1];

            string nuevoFragmento =
                 "<div class='barras_group'>" +
                 "<div class='barras'>" +
                 "<div class='barra' style='height: " + Math.Round(presentes) + "%;'>" + presentes + "%</div>" +
                 "<div class='barra alter' style='height: " + Math.Round(ausentes) + "%;'>" + ausentes + "%</div>" +
                 "</div><asp:Label ID='lblBarraMes' style='margin-top:15px;font-size: 20px;font-weight: 400;' runat='server' Text='" + mesSeleccionadoText + "'>" + mesSeleccionadoText + "</asp:Label>" +
                 "</div>";

            HtmlGenericControl barrasContainerMes = (HtmlGenericControl)FindControl("barrascontainermes");

            barrasContainerMes.InnerHtml = nuevoFragmento;
        }

        void MostrarPorAnio()
        {
            string[] meses = { "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };

            float[,] porcentajeAnioMatriz = new float[2, 12];
            int anio = Convert.ToInt32(ddlAnio.SelectedItem.ToString());
            nt.ObtenerPorcentajePresenciaAnio(porcentajeAnioMatriz, anio);

            HtmlGenericControl barrasContainerAnio = (HtmlGenericControl)FindControl("barrascontaineranio");
            barrasContainerAnio.InnerHtml = "";

            for (int i = 0; i < 12; i++)
            {
                float presentes = porcentajeAnioMatriz[0, i];
                float ausentes = porcentajeAnioMatriz[1, i];

                string nuevoFragmento =
                "<div class='barras_group'>" +
                "<div class='barras'>" +
                "<div class='barra' style='height: " + Math.Round(presentes) + "%;'>" + presentes + "%</div>" +
                "<div class='barra alter' style='height: " + Math.Round(ausentes) + "%;'>" + ausentes + "%</div>" +
                "</div><asp:Label ID='lblBarraMes' style='margin-top:15px;font-size: 20px;font-weight: 400;' runat='server' Text='" + meses[i].ToUpper() + "'>" + meses[i].ToUpper() + "</asp:Label>" +
                "</div>";

                barrasContainerAnio.InnerHtml += nuevoFragmento;
            }
        }

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nt.cantRegistrosTurnos() > 0)
            {
                MostrarPorMes();
            }
            else
            {
                return;
            }
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nt.cantRegistrosTurnos() > 0)
            {
                MostrarPorAnio();
                MostrarPorMes();
            }
            else
            {
                return;
            }
        }
    }
}