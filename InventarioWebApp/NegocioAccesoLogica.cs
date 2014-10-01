using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InventarioWebEntity;
using InventarioWebDao;

namespace InventarioWebApp
{
    public class NegocioAccesoLogica
    {
        public Usuario iniciarSession(string usuario, string contraseña="", int idUsuario=0)
        {
            //declaro variables
            DaoLogin acceso = new DaoLogin();

            //envio datos a la capa de datos metodo iniciarSession, los q almacenare en una tabla (resp)
            Usuario resp = acceso.Loguearse(usuario, contraseña, idUsuario);
       
            
            return resp;
        }
    }
}
