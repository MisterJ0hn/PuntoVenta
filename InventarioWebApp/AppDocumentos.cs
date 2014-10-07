using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventarioWebDao;
using System.Data;
using System.Collections;

namespace InventarioWebApp
{
    public class AppDocumentos
    {

        public bool AgregarDocumento(int numeroDoc, int monto,String fechaEmision, String RutEmpresa, String RutEmpresaPropia)
        {
            DaoDocumentos conexion =new DaoDocumentos();

            if (conexion.Agregar(numeroDoc, monto, 1, fechaEmision, RutEmpresa, RutEmpresaPropia) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public DataTable Seleccionafacturas(String rutEmpresa, int idSucursal=0)
        {
            DaoEmpresas conexion = new DaoEmpresas();
            DataTable arrFactura = new DataTable();
            ArrayList arr = new ArrayList();
            String sql = " RutEmpresaPropia='" + rutEmpresa+"' ";
          
            if (idSucursal > 0)
            {
                
            }

            arrFactura = conexion.LlenaCombos("IdDocumento", "NumeroDocumento", "DOCUMENTO", sql);

            return arrFactura;
        }
    }
}