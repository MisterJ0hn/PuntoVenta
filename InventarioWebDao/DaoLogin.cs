using InventarioWebEntity;
using System.Data.SqlClient;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebDao
{
    public class DaoLogin
    {
        public Usuario Loguearse(String usuarioPersona, String clavePersona="", int idUsuario=0) 
        {
            Usuario objPersona = new Usuario();
            DaoConexion objConexionDao=new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion= new ArrayList();

            if (clavePersona != "")
            {
                arrConexion = objConexionDao.QuerySql("Select IdUsuario, IdRol, NombreUsuario, IdMaestra from USUARIO where UsuarioUsuario='" +
                    usuarioPersona + "' and ClaveUsuario='" + clavePersona + "' and ActivoUsuario=1");
                drArreglo =(SqlDataReader)arrConexion[0];
            conConexion = (SqlConnection)arrConexion[1];
                if (drArreglo.HasRows)
            {

                while (drArreglo.Read())
                {
                    objPersona.Nombre = drArreglo.GetString(2);
                    objPersona.IdUsuario = drArreglo.GetInt32(0);
                    objPersona.TipoPerfil = drArreglo.GetInt32(1);
                    objPersona.cliente1 = drArreglo.GetInt32(3);
                }
            }
            }
            else
            {
                if (idUsuario > 0)
                {
                    arrConexion = objConexionDao.QuerySql("Select UsuarioUsuario from USUARIO where UsuarioUsuario='" +
                       usuarioPersona + "' and IdUsuario!="+idUsuario+" group by UsuarioUsuario");
                }
                else
                {
                    arrConexion = objConexionDao.QuerySql("Select UsuarioUsuario from USUARIO where UsuarioUsuario='" +
                        usuarioPersona + "' group by UsuarioUsuario");
                    
                }
                conConexion = (SqlConnection)arrConexion[1];
                drArreglo = (SqlDataReader)arrConexion[0];
                if (drArreglo.HasRows)
                {

                    while (drArreglo.Read())
                    {
                        objPersona.Usuario1 = drArreglo.GetString(0);

                    }
                }
            }
            

            

            conConexion.Close();
            return objPersona;
        }
        
    }
}