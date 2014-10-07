using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using InventarioWebEntity;
using System.Data.SqlClient;
namespace InventarioWebDao
{
    public class DaoDocumentos
    {
        public int Agregar(int numeroDoc, int monto, int tipoDocumento, String fechaEmision, String rutEmpresa, String rutEmpresaPropia)
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();
            DateTime hoy=DateTime.Today;

            arrValores.Add(tipoDocumento.ToString());
            arrValores.Add("'" + rutEmpresa.ToString() + "'");
            arrValores.Add("'" + rutEmpresaPropia.ToString() + "'");
            arrValores.Add("'" + numeroDoc.ToString() + "'");
            arrValores.Add("'" + fechaEmision.ToString() + "'");
            arrValores.Add("'" + hoy.ToString() + "'");
            arrValores.Add(monto.ToString());
            arrValores.Add("1");
          
            arrCampos.Add("TipoDocumento");
            arrCampos.Add("RutEmpresa");
            arrCampos.Add("RutEmpresaPropia");
            arrCampos.Add("NumeroDocumento");
            arrCampos.Add("FechaEmision");
            arrCampos.Add("FechaIngreso");
            arrCampos.Add("MontoTotal");
            arrCampos.Add("EstadoDocumento");

            objConexion.AddValue(arrValores);
            int id=objConexion.InsertSql("DOCUMENTO",arrCampos,true);
            return id;
        }
        public Documentos seleccionaDocumento(){
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrEmp = new ArrayList();

            arrConexion = objConexionDao.QuerySql("SELECT IdDocumento FROM EMPRESA WHERE RutEmpresa like '" + rutEmpresa + "'");
           
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

                    Documentos objDocumento = new Documentos();

                    arrEmp.Add(objEmp);

                }

            }
            drArreglo.Close();
            return arrEmp;
        }
    }
}