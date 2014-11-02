using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace InventarioWebDao
{
    public class DaoCaja
    {
        public int AgregarCaja(int idUsuarioCierre,int idSucursal, int computador, int ingresos, int devolucion){
            DaoConexion daoCon = new DaoConexion();
            ArrayList arrayValores = new ArrayList();
            ArrayList arrayCampos = new ArrayList();

            DateTime hoy = DateTime.Today;

            arrayCampos.Add("UsuarioCierre");
            arrayCampos.Add("FechaCierre");
            arrayCampos.Add("IdSucursalCierre");
            arrayCampos.Add("Computador");
            arrayCampos.Add("Ingresos");
            arrayCampos.Add("Devolucion");

            arrayValores.Add(idUsuarioCierre.ToString());
            arrayValores.Add("'" + hoy.ToString()+"'");
            arrayValores.Add(idSucursal.ToString());
            arrayValores.Add(computador.ToString());
            arrayValores.Add(ingresos.ToString());
            arrayValores.Add(devolucion.ToString());

            daoCon.AddValue(arrayValores);

            int id = daoCon.InsertSql("CIERRECAJA", arrayCampos, true);

            return id;
        }
        public void AgregarEgresos(int idCierrecaja, String detalleEgreso, int montoEgreso) {
            DaoConexion daoCon = new DaoConexion();
            ArrayList arrayValores = new ArrayList();
            ArrayList arrayCampos = new ArrayList();

            arrayCampos.Add("IdCierrecaja");
            arrayCampos.Add("DetalleEgreso");
            arrayCampos.Add("MontoEgreso");

            arrayValores.Add(idCierrecaja.ToString());
            arrayValores.Add("'" + detalleEgreso + "'");
            arrayValores.Add(montoEgreso.ToString());

            daoCon.AddValue(arrayValores);
            daoCon.InsertSql("EGRESOS", arrayCampos);
        }
        public void AgregarIngresos(int idCierrecaja, String detalleIngreso, int montoIngreso)
        {
            DaoConexion daoCon = new DaoConexion();
            ArrayList arrayValores = new ArrayList();
            ArrayList arrayCampos = new ArrayList();

            arrayCampos.Add("IdCierrecaja");
            arrayCampos.Add("DetalleIngreso");
            arrayCampos.Add("MontoIngreso");

            arrayValores.Add(idCierrecaja.ToString());
            arrayValores.Add("'" + detalleIngreso + "'");
            arrayValores.Add(montoIngreso.ToString());

            daoCon.AddValue(arrayValores);
            daoCon.InsertSql("INGRESOS", arrayCampos);
        }
        public void AgregarCreditos(int idCierrecaja, String detalleCredito, int montoCredito, String fechaCredito)
        {
            DaoConexion daoCon = new DaoConexion();
            ArrayList arrayValores = new ArrayList();
            ArrayList arrayCampos = new ArrayList();

            arrayCampos.Add("IdCierrecaja");
            arrayCampos.Add("DetalleCreditos");
            arrayCampos.Add("DeudaCreditos");
            arrayCampos.Add("FechaCreditos");

            arrayValores.Add(idCierrecaja.ToString());
            arrayValores.Add("'" + detalleCredito + "'");
            arrayValores.Add(montoCredito.ToString());
            arrayValores.Add("'"+fechaCredito.ToString()+"'");

            daoCon.AddValue(arrayValores);
            daoCon.InsertSql("CREDITOS", arrayCampos);
        }
        public void AgregarVentaMenor(int idCierrecaja, String detalleVentamenor, int montoVentamenor)
        {
            DaoConexion daoCon = new DaoConexion();
            ArrayList arrayValores = new ArrayList();
            ArrayList arrayCampos = new ArrayList();

            arrayCampos.Add("IdCierrecaja");
            arrayCampos.Add("DetalleVentamenor");
            arrayCampos.Add("MontoVentamenor");

            arrayValores.Add(idCierrecaja.ToString());
            arrayValores.Add("'" + detalleVentamenor + "'");
            arrayValores.Add(montoVentamenor.ToString());

            daoCon.AddValue(arrayValores);
            daoCon.InsertSql("VENTAMENOR", arrayCampos);
        }
        public void AgregarDetalleDinero(int idCierrecaja,int d20000, int d10000, int d5000, int d2000, int d1000, int d500, int d100, int d50, int d10, int cheque)
        {
            DaoConexion daoCon = new DaoConexion();
            ArrayList arrayValores = new ArrayList();
            ArrayList arrayCampos = new ArrayList();

            arrayCampos.Add("IdCierrecaja");
            arrayCampos.Add("D20000");
            arrayCampos.Add("D10000");
            arrayCampos.Add("D5000");
            arrayCampos.Add("D2000");
            arrayCampos.Add("D1000");
            arrayCampos.Add("D500");
            arrayCampos.Add("D100");
            arrayCampos.Add("D50");
            arrayCampos.Add("D10");
            arrayCampos.Add("Cheque");

            arrayValores.Add(idCierrecaja.ToString());
            arrayValores.Add(d20000.ToString());
            arrayValores.Add(d10000.ToString());
            arrayValores.Add(d5000.ToString());
            arrayValores.Add(d2000.ToString());
            arrayValores.Add(d1000.ToString());
            arrayValores.Add(d500.ToString());
            arrayValores.Add(d100.ToString());
            arrayValores.Add(d50.ToString());
            arrayValores.Add(d10.ToString());
            arrayValores.Add(cheque.ToString());

            daoCon.AddValue(arrayValores);
            daoCon.InsertSql("DETALLEDINERO", arrayCampos);
        }
        public DataTable SeleccionaCierre(int idCierre, int idSucursal = 0, String Fecha = "")
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            DataTable arrCierre = new DataTable();
            String sqlQuery = "";
            arrCierre.Columns.Add("FechaCierre",typeof(String));
            arrCierre.Columns.Add("UsuarioCierre",typeof(Int32));
            arrCierre.Columns.Add("idSucursal",typeof(Int32));
            arrCierre.Columns.Add("Computador",typeof(Int32));
            arrCierre.Columns.Add("Devolucion",typeof(Int32));
            arrCierre.Columns.Add("Ingresos",typeof(Int32));

            
            if (idSucursal > 0)
            {
                sqlQuery = " idSucursalCierre=" + idSucursal;

            }
            if (idCierre > 0)
            {
                sqlQuery = " idCierre=" + idCierre;
            }
            arrConexion = objConexionDao.QuerySql("SELECT FechaCierre, UsuarioCierre, IdSucursalCierre, Computador, Devolucion, Ingresos FROM CIERRECAJA WHERE " + sqlQuery);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    DataRow dt = arrCierre.NewRow();
                    dt["FechaCierre"] = drArreglo.GetDateTime(0).ToString();
                    dt["UsuarioCierre"] = drArreglo.GetInt32(1);
                    dt["idSucursal"] = drArreglo.GetInt32(2);
                    dt["Computador"] = drArreglo.GetInt32(3);
                    dt["Devolucion"] = drArreglo.GetInt32(4);
                    dt["Ingresos"] = drArreglo.GetInt32(5);

                    arrCierre.Rows.Add(dt);
                }

            }

            return arrCierre;
        }
        public DataTable SeleccionaEgresos(int idCierre)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            DataTable arrEgresos = new DataTable();
            String sqlQuery = "";
            arrEgresos.Columns.Add("Detalle", typeof(String));
            arrEgresos.Columns.Add("Cantidad", typeof(Int32));
            

            
            arrConexion = objConexionDao.QuerySql("SELECT DetalleEgreso, CantidadEgreso FROM EGRESOS WHERE IdCierrecaja="+idCierre);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    DataRow dt = arrEgresos.NewRow();
                    dt["Detalle"] = drArreglo.GetString(0);
                    dt["Cantidad"] = drArreglo.GetInt32(1);

                    arrEgresos.Rows.Add(dt);
                }
            }

            return arrEgresos;
        }

        public DataTable SeleccionaIngresos(int idCierre)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            DataTable arrIngresos = new DataTable();
            
            arrIngresos.Columns.Add("Detalle", typeof(String));
            arrIngresos.Columns.Add("Cantidad", typeof(Int32));



            arrConexion = objConexionDao.QuerySql("SELECT DetalleIngreso, CantidadIngreso FROM INGRESOS WHERE IdCierrecaja=" + idCierre);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    DataRow dt = arrIngresos.NewRow();
                    dt["Detalle"] = drArreglo.GetString(0);
                    dt["Cantidad"] = drArreglo.GetInt32(1);

                    arrIngresos.Rows.Add(dt);
                }
            }

            return arrIngresos;
        }
        public DataTable SeleccionaCreditos(int idCierre)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            DataTable arrIngresos = new DataTable();

            arrIngresos.Columns.Add("Detalle", typeof(String));
            arrIngresos.Columns.Add("Cantidad", typeof(Int32));
            arrIngresos.Columns.Add("Fecha", typeof(Int32));


            arrConexion = objConexionDao.QuerySql("SELECT DetalleCreditos, DeudaCreditos, FechaCreditos FROM INGRESOS WHERE IdCierrecaja=" + idCierre);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    DataRow dt = arrIngresos.NewRow();
                    dt["Detalle"] = drArreglo.GetString(0);
                    dt["Cantidad"] = drArreglo.GetInt32(1);
                    dt["Fecha"] = drArreglo.GetInt32(2);
                    arrIngresos.Rows.Add(dt);
                }
            }

            return arrIngresos;
        }
        public DataTable SeleccionaVentaMenor(int idCierre)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            DataTable arrVenta = new DataTable();

            arrVenta.Columns.Add("Detalle", typeof(String));
            arrVenta.Columns.Add("Cantidad", typeof(Int32));



            arrConexion = objConexionDao.QuerySql("SELECT DetalleVentamenor, MontoVentamenor FROM VENTAMENOR WHERE IdCierrecaja=" + idCierre);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    DataRow dt = arrVenta.NewRow();
                    dt["Detalle"] = drArreglo.GetString(0);
                    dt["Cantidad"] = drArreglo.GetInt32(1);

                    arrVenta.Rows.Add(dt);
                }
            }

            return arrVenta;
        }


        public ArrayList SeleccionaDetalleDinero(int idCierre)
        {
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrDetalle = new ArrayList();

           
            arrConexion = objConexionDao.QuerySql("SELECT D20000, D10000, D5000, D2000, D1000, D500, D100, D50, D10, Cheque FROM DETALLEDINERO WHERE IdCierrecaja=" + idCierre);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {

                    arrDetalle.Add(drArreglo.GetString(0));
                    arrDetalle.Add(drArreglo.GetInt32(1));
                    arrDetalle.Add(drArreglo.GetInt32(2));
                    arrDetalle.Add(drArreglo.GetInt32(3));
                    arrDetalle.Add(drArreglo.GetInt32(4));
                    arrDetalle.Add(drArreglo.GetInt32(5));
                    arrDetalle.Add(drArreglo.GetInt32(6));
                    arrDetalle.Add(drArreglo.GetInt32(7));
                    arrDetalle.Add(drArreglo.GetInt32(8));
                    arrDetalle.Add(drArreglo.GetInt32(9));

                }
            }

            return arrDetalle;
        }
    }
}