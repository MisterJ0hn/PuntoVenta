using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using InventarioWebEntity;
using System.Data.SqlClient;
using System.Data;

namespace InventarioWebDao
{
    public class DaoEmpresas
    {
        public void AgregarEmpresa(Empresa objEmpresa, int idMaestra, int tipoEmpresa)
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();

            arrValores.Add("'"+objEmpresa.rutEmpresa+"'");
            arrValores.Add("'" + objEmpresa.nombreEmpresa + "'");
            arrValores.Add("'" + objEmpresa.razonSocial + "'");
            arrValores.Add(tipoEmpresa.ToString());
            arrValores.Add(idMaestra.ToString());
            
            objConexion.AddValue(arrValores);
            objConexion.InsertSql("EMPRESA");
        }
        public void ModificarEmpresa(Empresa objEmpresa, int idMaestra, int tipoEmpresa)
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();

            //arrValores.Add("'" + objEmpresa.rutEmpresa + "'");
            arrValores.Add("NombreEmpresa='" + objEmpresa.nombreEmpresa + "'");
            arrValores.Add("RazonSocial='" + objEmpresa.razonSocial + "'");
           

            
            objConexion.UpdateSql("EMPRESA",arrValores,"  RutEmpresa='"+objEmpresa.rutEmpresa+"'");
        }
        public void ModificarSucursal(Sucursal objSucursal)
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();

            //arrValores.Add("'" + objEmpresa.rutEmpresa + "'");
            
            arrValores.Add("RutEmpresa='" + objSucursal.rutEmpresa + "'");
            arrValores.Add("NombreSucursal='" + objSucursal.nombreSucursal + "'");
            arrValores.Add("DireccionSucursal='" + objSucursal.direccionSucursal + "'");
            arrValores.Add("TelefonoSucursal='" + objSucursal.telefonoSucursal + "'");
            arrValores.Add("IdComuna="+objSucursal.idCOmuna.ToString());
            arrValores.Add("IdMaestra="+objSucursal.idMaestra.ToString());



            objConexion.UpdateSql("SUSCURSAL", arrValores, "  IdSucursal=" + objSucursal.idSucursal );
        }
        public int AgregarSucursal(Sucursal objSucursal, int idMaestra)
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();
            arrValores.Add("'Default'");
            arrValores.Add("'" + objSucursal.rutEmpresa + "'");
            arrValores.Add("'" + objSucursal.nombreSucursal + "'");
            arrValores.Add("'" + objSucursal.direccionSucursal + "'");
            arrValores.Add("'" + objSucursal.telefonoSucursal + "'");
            arrValores.Add(objSucursal.idCOmuna.ToString());
            arrValores.Add(idMaestra);
            objConexion.AddValue(arrValores);
            int idSucursal = objConexion.InsertSql("SUCURSAL", null, true);

            return idSucursal;

        }
        public ArrayList seleccionaEmpresa(String rutEmpresa)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrEmp = new ArrayList();

            arrConexion = objConexionDao.QuerySql("SELECT RutEmpresa, NombreEmpresa, RazonSocial, IdTipoempresa FROM EMPRESA WHERE RutEmpresa like '" + rutEmpresa + "'");
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
                    Empresa objEmp = new Empresa();
                    objEmp.rutEmpresa = drArreglo.GetString(0);
                    objEmp.nombreEmpresa = drArreglo.GetString(1);
                    objEmp.razonSocial = drArreglo.GetString(2);
                    objEmp.idTipoEmpresa = drArreglo.GetInt32(3);
                    arrEmp.Add(objEmp);

                }

            }
            drArreglo.Close();
            return arrEmp;
        }
        public ArrayList seleccionaSucursal(int idSucursal)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrSuc = new ArrayList();

            arrConexion = objConexionDao.QuerySql("SELECT NombreSucursal,DireccionSucursal, TelefonoSucursal, IdComuna FROM SUCURSAL WHERE IdSucursal =" + idSucursal.ToString() );
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
                    objSuc.nombreSucursal = drArreglo.GetString(0);
                    objSuc.direccionSucursal = drArreglo.GetString(1);
                    objSuc.telefonoSucursal = drArreglo.GetString(2);
                    objSuc.idCOmuna = drArreglo.GetInt32(3);
                    arrSuc.Add(objSuc);

                }

            }
            drArreglo.Close();
            return arrSuc;
        }

              
        public DataTable LlenaCombos(String campoId,String campoNombre, String tabla,String condicion="")
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            DataTable arr = new DataTable();
            String condSql="";

            arr.Columns.Add("Id", typeof(Int32));
            arr.Columns.Add("Nombre", typeof(String));

            if(condicion!=""){
                condSql = " WHERE " + condicion;
            }
            arrConexion = objConexionDao.QuerySql("SELECT "+campoId+", "+campoNombre+" FROM "+tabla+condSql );
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {

                    arr.Rows.Add(drArreglo.GetInt32(0), drArreglo.GetString(1));
                }

            }
            drArreglo.Close();
            return arr;
        }
        /// <summary>Indices Ciudad Region
        /// <para>Nos entrega un ArrayList con los indices de cada una de las entidades (Ciudad,Region). Solo con colocar uno de los indices, el metodo entregara todos los id relacionados.</para>
        /// <param name="tipo">Tiene 2 estados: C para buscar por Comuna; CI para buscar por CIudad</param>
        /// <param name="indice">El indice sera el id de la comuna o ciudad a la cual queremos encontrar los indices</param>
        /// </summary>
        public ArrayList IndicesCR(int indice, String tipo)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arr = new ArrayList();
            String sql = "";
            if (tipo == "C")
            {
                sql = "SELECT CI.IdCiudad, R.IdRegion From  COMUNA C, CIUDAD CI, REGION R WHERE C.IdCiudad = CI.IdCiudad and CI.IdRegion=R.IdRegion and C.IdComuna="+indice;

            }
            if (tipo == "CI")
            {
                sql = "SELECT 0 as IdCiudad , R.IdRegion From CIUDAD CI, REGION R WHERE CI.IdRegion=R.IdRegion and CI.IdCiudad=" + indice;

            }
           
            arrConexion = objConexionDao.QuerySql(sql);
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    arr.Add(drArreglo.GetInt32(0));
                    arr.Add(drArreglo.GetInt32(1));

                }
            }
            return arr;
        }

    }
}