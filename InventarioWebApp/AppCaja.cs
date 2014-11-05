using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventarioWebDao;
using System.Data;
using System.Collections;

namespace InventarioWebApp
{
    public class AppCaja
    {
        public int AgregarCierre(int idUsuario, int idSucursal, int computador, int devolucion, int ingresos, DataTable egresos, DataTable dtIngresos, DataTable ventaMenor, DataTable creditos, ArrayList detalleDinero)
        {
            DaoCaja daoCaja = new DaoCaja();
            int idCierre = daoCaja.AgregarCaja(idUsuario, idSucursal, computador, ingresos, devolucion);

            foreach (DataRow row in creditos.Rows)
            {
                daoCaja.AgregarCreditos(idCierre,row[0].ToString(),Convert.ToInt32(row[1].ToString()),row[2].ToString());
            }
            foreach (DataRow row1 in dtIngresos.Rows)
            {
                daoCaja.AgregarIngresos(idCierre, row1[0].ToString(), Convert.ToInt32(row1[1].ToString()));
            }
            foreach (DataRow row2 in egresos.Rows)
            {
                daoCaja.AgregarEgresos(idCierre, row2[0].ToString(), Convert.ToInt32(row2[1].ToString()));
            }
            foreach (DataRow row2 in ventaMenor.Rows)
            {
                daoCaja.AgregarVentaMenor(idCierre, row2[0].ToString(), Convert.ToInt32(row2[1].ToString()));
            }

            daoCaja.AgregarDetalleDinero(idCierre, Convert.ToInt32(detalleDinero[0].ToString()), Convert.ToInt32(detalleDinero[1].ToString()), Convert.ToInt32(detalleDinero[2].ToString()), Convert.ToInt32(detalleDinero[3].ToString()), Convert.ToInt32(detalleDinero[4].ToString()), Convert.ToInt32(detalleDinero[5].ToString()), Convert.ToInt32(detalleDinero[6].ToString()), Convert.ToInt32(detalleDinero[7].ToString()), Convert.ToInt32(detalleDinero[8].ToString()), Convert.ToInt32(detalleDinero[9].ToString()));

            return idCierre;
        }
        public DataTable SeleccionaCierre(int idCierre)
        {
            DaoCaja daoCaja = new DaoCaja();
            DataTable dtCaja = new DataTable();

            dtCaja = daoCaja.SeleccionaCierre(idCierre);
            return dtCaja;
        }
        public DataTable SeleccionaCredito(int idCierre)
        {
            DaoCaja daoCaja = new DaoCaja();
            DataTable dtCaja = new DataTable();

            dtCaja = daoCaja.SeleccionaCreditos(idCierre);
            return dtCaja;
        }
        public DataTable SeleccionaEgreso(int idCierre)
        {
            DaoCaja daoCaja = new DaoCaja();
            DataTable dtCaja = new DataTable();

            dtCaja = daoCaja.SeleccionaEgresos(idCierre);
            return dtCaja;
        }

        public DataTable SeleccionaIngreso(int idCierre)
        {
            DaoCaja daoCaja = new DaoCaja();
            DataTable dtCaja = new DataTable();

            dtCaja = daoCaja.SeleccionaIngresos(idCierre);
            return dtCaja;
        }
        public DataTable SeleccionaVentaMenor(int idCierre)
        {
            DaoCaja daoCaja = new DaoCaja();
            DataTable dtCaja = new DataTable();

            dtCaja = daoCaja.SeleccionaVentaMenor(idCierre);
            return dtCaja;
        }
        public ArrayList SeleccionaDetalleDinero(int idCierre)
        {
            DaoCaja daoCaja = new DaoCaja();
            ArrayList dtCaja = new ArrayList();

            dtCaja = daoCaja.SeleccionaDetalleDinero(idCierre);
            return dtCaja;

        }

    }
}