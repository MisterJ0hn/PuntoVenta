using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using InventarioWebEntity;
using System.Data.SqlClient;
using System.Data;

namespace InventarioWebDao
{
    public class DaoGestionU
    {
        

        public ArrayList UsuariosTodos(String filtro="", String idUsuario="")
        {
            DaoConexion objConexionDao = new DaoConexion();
            
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrUsuario = new ArrayList();
            if (filtro != "")
            {
                objConexionDao.AddOr("NombreUsuario LIKE '%" + filtro + "%' ");
                objConexionDao.AddOr("ApellidoUsuario LIKE '%" + filtro + "%' ");
                objConexionDao.AddOr("CorreoUsuario LIKE '%" + filtro + "%' ");
                objConexionDao.AddOr("UsuarioUsuario LIKE '%" + filtro + "%' ");
            }
            if (idUsuario != "")
            {

                arrConexion = objConexionDao.QuerySql("Select IdUsuario, IdRol, NombreUsuario, ApellidoUsuario, CorreoUsuario, UsuarioUsuario, ClaveUsuario, ActivoUsuario, FechaRegistroUsuario, IdMaestra from USUARIO where IdUsuario="+idUsuario);

            }
            else
            {
                arrConexion = objConexionDao.QuerySql("Select IdUsuario, IdRol, NombreUsuario, ApellidoUsuario, CorreoUsuario, UsuarioUsuario, ClaveUsuario, ActivoUsuario, FechaRegistroUsuario, IdMaestra from USUARIO ");
            }
            /*arrConexion = objConexionDao.QuerySql("select USU.IdUSuario,USU.NombreUsuario, USU.Apellido, ROL.TipoRol, SUC.NombreSucursal, EMP.NombreEmpresa" +
                                                    " from USUARIO USU, ROL, SucursalUsuario SU, SUCURSAL SUC, EMPRESA EMP " +
                                                " where USU.IdRol = ROL.IdRol and " +
                                                    "USU.IdUsuario = SU.IdUsuario and " +
                                                     "SU.IdSucursal = SUC.IdSucursal and " +
                                                    "SUC.RutEmpresa = EMP.RutEmpresa ");*/
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Nombre = drArreglo.GetString(2);
                    objUsuario.IdUsuario = drArreglo.GetInt32(0);
                    objUsuario.TipoPerfil = drArreglo.GetInt32(1);
                    objUsuario.Apellido = drArreglo.GetString(3);
                    objUsuario.Mail = drArreglo.GetString(4);
                    objUsuario.Usuario1 = drArreglo.GetString(5);
                    objUsuario.Pass = drArreglo.GetString(6);
                    objUsuario.Activo = drArreglo.GetInt32(7);
                    objUsuario.FechaRegistro = drArreglo.GetDateTime(8).ToString();
                    objUsuario.cliente1 = drArreglo.GetInt32(9);
                    arrUsuario.Add(objUsuario);
                }


            }
            drArreglo.Close();
            return arrUsuario;
        }
       

        public ArrayList EmpresasPorMaestra(int IdMaestra, int TipoEmpresa=1)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrEmpresa = new ArrayList();

           
                arrConexion = objConexionDao.QuerySql("SELECT E.RutEmpresa,E.NombreEmpresa, '' as RazonSocial, E.IdTipoempresa, E.IdMaestra FROM EMPRESA E WHERE E.IdTipoempresa="+TipoEmpresa+" AND E.IdMaestra="+IdMaestra);

            
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    Empresa objEmpresa = new Empresa();
                    objEmpresa.rutEmpresa = drArreglo.GetString(0);
                    objEmpresa.nombreEmpresa = drArreglo.GetString(1);
                    objEmpresa.razonSocial = drArreglo.GetString(2);
                    objEmpresa.idTipoEmpresa = drArreglo.GetInt32(3);
                    objEmpresa.idMaestra = drArreglo.GetInt32(4);
                    arrEmpresa.Add(objEmpresa);
                }
            }
            drArreglo.Close();
            return arrEmpresa;
        }

        public ArrayList SucursalPorUsuario(int IdUsuario)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrSucursal = new ArrayList();


            arrConexion = objConexionDao.QuerySql("SELECT S.IdSucursal, S.RutEmpresa  FROM  SUCURSAL S, SucursalUsuario SU WHERE SU.IdUsuario=" + IdUsuario + "  and S.IdSucursal=SU.IdSucursal");


            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    Sucursal objSucursal = new Sucursal();
                    objSucursal.idSucursal = drArreglo.GetInt32(0);
                    objSucursal.rutEmpresa = drArreglo.GetString(1);
                    arrSucursal.Add(objSucursal);
                }
            }
            drArreglo.Close();
            return arrSucursal;
        }
        public ArrayList Roles()
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrRol = new ArrayList();

            arrConexion = objConexionDao.QuerySql("SELECT IdRol, TipoRol FROM ROL");
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    Rol objRol = new Rol();
                    objRol.idRol = drArreglo.GetInt32(0);
                    objRol.nombre = drArreglo.GetString(1);                   
                    arrRol.Add(objRol);
                }

            }
            drArreglo.Close();
            return arrRol;
        }

        public ArrayList SucursalesPorMaestra(String rutEmpresa)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrSuc = new ArrayList();

            arrConexion = objConexionDao.QuerySql("SELECT IdSucursal, RutEmpresa, NombreSucursal, DireccionSucursal, TelefonoSucursal, IdComuna,IdMaestra FROM SUCURSAL WHERE RutEmpresa like '"+rutEmpresa+"'");
            /*arrConexion = objConexionDao.QuerySql("select	USU.NombreUsuario, USU.Apellido, ROL.TipoRol, SUC.NombreSucursal, EMP.NombreEmpresa"+
                                                    "from	USUARIO USU, ROL, SucursalUsuario SU, SUCURSAL SUC, EMPRESA EMP "+
	                                            "where  USU.IdRol = ROL.IdRol and "+
		                                            "USU.IdUsuario = SU.IdUsuario and "+
		                                             "SU.IdSucursal = SUC.IdSucursal and "+
		                                            "SUC.RutEmpresa = EMP.RutEmpresa and "+
                                                      "USU.IdMaestra '"+rutEmpresa+"'");*/
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    Sucursal objSuc = new Sucursal();
                    objSuc.idSucursal = drArreglo.GetInt32(0);
                    objSuc.rutEmpresa= drArreglo.GetString(1);
                    objSuc.nombreSucursal = drArreglo.GetString(2);
                    objSuc.direccionSucursal = drArreglo.GetString(3);
                    objSuc.telefonoSucursal = drArreglo.GetString(4);
                    objSuc.idCOmuna = drArreglo.GetInt32(5);
                    objSuc.idMaestra = drArreglo.GetInt32(6);
                    arrSuc.Add(objSuc);
                }

            }
            drArreglo.Close();
            return arrSuc;
        }

        public int  AgregarUsuario(Usuario objUsuario){
            DaoConexion objConexionDao = new DaoConexion();
            ArrayList arrValue = new ArrayList();
            ArrayList arrCampos = new ArrayList(); 
            DateTime hoy=DateTime.Today;

            arrCampos.Add("IdRol");
            arrCampos.Add("NombreUsuario");
            arrCampos.Add("Apellido");
            arrCampos.Add("Correo");
            arrCampos.Add("Usuario");
            arrCampos.Add("Clave");
            arrCampos.Add("Activo");
            arrCampos.Add("FechaRegistro");
            arrCampos.Add("IdMaestra");

            arrValue.Add(objUsuario.TipoPerfil.ToString());
            arrValue.Add("'"+objUsuario.Nombre+"'");
            arrValue.Add("'" + objUsuario.Apellido + "'");
            arrValue.Add("'" + objUsuario.Mail + "'");
            arrValue.Add("'" + objUsuario.Usuario1 + "'");
            arrValue.Add("'"+objUsuario.Pass+"'");
            arrValue.Add("'1'");
            arrValue.Add("'"+hoy.ToString()+"'");
            arrValue.Add(objUsuario.cliente1.ToString());
            objConexionDao.AddValue(arrValue);
            int idUsuario = objConexionDao.InsertSql("USUARIO", arrCampos, true);

            return idUsuario;
        }

        public void ModificarUsuario(Usuario objUsuario)
        {
            DaoConexion objConexionDao = new DaoConexion();
            ArrayList arrValue = new ArrayList();
           

            arrValue.Add(" IdRol = "+objUsuario.TipoPerfil.ToString());
            arrValue.Add("NombreUsuario='" + objUsuario.Nombre + "'");
            arrValue.Add("Apellido='" + objUsuario.Apellido + "'");
            arrValue.Add("Correo='" + objUsuario.Mail + "'");
            arrValue.Add("Usuario='" + objUsuario.Usuario1 + "'");
            arrValue.Add("Clave='" + objUsuario.Pass + "'");
          
           
            objConexionDao.UpdateSql("USUARIO", arrValue,"IdUsuario="+objUsuario.IdUsuario);

            
        }
        public void ModificarSucursalUsuario(int idUsuario, int idSucursal)
        {
            DaoConexion objConexionDao = new DaoConexion();
            ArrayList arrValue = new ArrayList();

            arrValue.Add("IdSucursal=" + idSucursal);
            String where = "IdUsuario=" + idUsuario;
            objConexionDao.UpdateSql("SucursalUsuario", arrValue, where);


        }
        public void AgregarUsuarioSucursal(int idUsuario, int idSucursal)
        {
            DaoConexion objConexionDao = new DaoConexion();
            ArrayList arrValue = new ArrayList();
            arrValue.Add(idSucursal.ToString());
            arrValue.Add(idUsuario.ToString());

            objConexionDao.AddValue(arrValue);
            int status = objConexionDao.InsertSql("SucursalUsuario");
        }

        
    }
}