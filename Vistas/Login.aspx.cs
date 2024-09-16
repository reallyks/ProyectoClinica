using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        NegocioUsuarios ns = new NegocioUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.SetNombreUsuario(InputUser.Value.ToString());
            usuario.SetContraseña(InputPassword.Value.ToString());
            usuario = ns.ObtenerUsuario(usuario);
            if (usuario == null)
            {
                lbMensaje.Text = "USUARIO Y/O CONTRASENA INCORRECTOS";
            }
            else
            {
                if (usuario.GetTipoUsuario()=="ADMIN")
                {
                    Session["Nombre"] = ns.ObtenerNombre(usuario.GetIdUsuario());
                    Response.Redirect("~/Home.aspx");
                }
                else if(usuario.GetTipoUsuario() == "MEDICO")
                {
                    Session["Nombre"] = ns.ObtenerNombre(usuario.GetIdUsuario());
                    Session["Id_Usuario"] = usuario.GetIdMedico();
                    Response.Redirect("~/HomeMedico.aspx");
                }
            }
        }
    }
}
