using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using InventarioWebEntity;
using System.Collections;

namespace InventarioWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            

            //declaro variables
            NegocioAccesoLogica negocio = new NegocioAccesoLogica();
            AppGestionU gestionU = new AppGestionU();
            string usuario = txtUsuario.Text;
            string contraseña = txtClave.Text;

            //envio datos a la capa de negocios metodo iniciarSession
            Usuario usuarioEncontrado = negocio.iniciarSession(usuario, contraseña);
            String nombre = usuarioEncontrado.Nombre;
            if (nombre != null)
            {
                Session["nombrelogeado"] = nombre;
                Session["idEmpresa"] = usuarioEncontrado.cliente1;
                Session["idPerfil"] = usuarioEncontrado.TipoPerfil;
                Session["idUsuario"] = usuarioEncontrado.IdUsuario;
                Session["idMaestra"] = usuarioEncontrado.cliente1;

                ArrayList arrSession = gestionU.AppSeleccionaUsuario(usuarioEncontrado.IdUsuario.ToString());

                Session["IdSucursal"] = arrSession[9];
                Session["rutEmpresa"] = arrSession[8];
                //Response.Redirect("/MenuPrincipal.aspx");

                Console.WriteLine("nombre " + nombre);
                Console.WriteLine("TipoPerfil "+usuarioEncontrado.TipoPerfil);
                switch (usuarioEncontrado.TipoPerfil)
                {
                    case 2:
                        Response.Redirect("/admin/Welcome.aspx");
                        break;
                    case 3:
                        Response.Redirect("/bodega/productos.aspx");
                        break;
                    case 4:
                        Response.Redirect("/admin/Welcome.aspx");
                        break;
                }
                
            }
            else
            {
                Response.Redirect("/MensajeLogin.aspx");
            }
        }
    }
}