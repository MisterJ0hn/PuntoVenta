using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventarioWebDao;
using System.Data;
using System.Collections;
using InventarioWebEntity;

namespace InventarioWebApp
{
    public class AppDocumentos
    {

        public bool AgregarDocumento(int numeroDoc, int monto,String fechaEmision, String RutEmpresa, String RutEmpresaPropia)
        {
            DaoDocumentos conexion =new DaoDocumentos();

            if (conexion.Agregar(numeroDoc, monto, 33, fechaEmision, RutEmpresa, RutEmpresaPropia,1) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int AgregarVenta(String rutEmpresa)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            ArrayList arrVenta = new ArrayList();
            int idDocumento = 0 ;
            int NumeroDocumento = 0;
            DateTime hoy=DateTime.Today;

            arrVenta = conexion.seleccionaDocumento(2, rutEmpresa, 0,true);

            NumeroDocumento = Convert.ToInt32(arrVenta[0].ToString());

            NumeroDocumento++;

            idDocumento=conexion.Agregar(NumeroDocumento, 0, 35, hoy.ToString(), "00.000.000-0", rutEmpresa, 2);

            return idDocumento;

        }
        public int AgregaProducto(String Codigo, String Descripcion, int idProducto, int precioCompra , double porcentaje=0)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            DetalleProducto objProd=new DetalleProducto();
            objProd.codigoDetalleproducto=Codigo;
            objProd.descripcionDetalleproducto=Descripcion;
            objProd.idProducto=idProducto;
            objProd.precioCompraDetalleproducto=precioCompra;

            int id=conexion.AgregarProducto(objProd, porcentaje);
            return id;

        }
        public void AgregarDetalledocumento(int idDetalleproducto, int idDocumdento, int cantida, int precioVenta, int precioCosto, int utilidad)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();

            daoDoc.AgregarDetalleDocumento(idDetalleproducto, idDocumdento, cantida, precioVenta, precioCosto, utilidad);

        }
        public DataTable Seleccionafacturas(String rutEmpresa, int idSucursal=0)
        {
            DaoEmpresas conexion = new DaoEmpresas();
            DataTable arrFactura = new DataTable();
            ArrayList arr = new ArrayList();
            String sql = " RutEmpresaPropia='" + rutEmpresa + "' AND (EstadoDocumento=1 OR EstadoDocumento=3) and IdTipomovimiento=1";
          
            if (idSucursal > 0)
            {
                
            }

            arrFactura = conexion.LlenaCombos("IdDocumento", "NumeroDocumento", "DOCUMENTO", sql);

            return arrFactura;
        }
        public ArrayList SeleccionaEmpresa(int idDocumento)
        {
            DaoDocumentos doc = new DaoDocumentos();
            ArrayList arrDoc = new ArrayList();
            ArrayList arrDocReturn = new ArrayList();
            arrDoc = doc.seleccionaDocumento(1, null, idDocumento);
            foreach (Documentos objDoc in arrDoc)
            {
                arrDocReturn.Add(objDoc.idDocumento);//0
                arrDocReturn.Add(objDoc.rutEmpresa);//1
                arrDocReturn.Add(objDoc.tipoDocumento);//2
                arrDocReturn.Add(objDoc.numeroDocumento);//3
                arrDocReturn.Add(objDoc.fechaEmision);//4
                arrDocReturn.Add(objDoc.montoTotal);//5
            }

            return arrDocReturn;


        }
        public DataTable cboProductos(int Departamento=0)
        {
            DaoEmpresas daoEmpresa = new DaoEmpresas();
            DataTable arrProductos = new DataTable();
            String sql = "";
            if (Departamento > 0)
            {
                sql = "IdDepartamento=" + Departamento;
            }
            arrProductos = daoEmpresa.LlenaCombos("IdProducto", "TipoproductoProducto", "PRODUCTO", sql);

            return arrProductos;


        }
        public DataTable cboDepartamento()
        {
            DaoEmpresas daoEmpresa = new DaoEmpresas();
            DataTable arrDepto = new DataTable();

            arrDepto = daoEmpresa.LlenaCombos("IdDepartamento", "TipodepartamentoDepartamento", "DEPARTAMENTO");
            return arrDepto;
        }
        public ArrayList DetalleProductoBuscar(String Codigo)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arrProducto = new ArrayList();
            ArrayList arrProductoReturn = new ArrayList();
            arrProducto = daoDoc.SeleccionaProducto(Codigo);

            foreach (DetalleProducto objDP in arrProducto)
            {
                arrProductoReturn.Add(objDP.idDetalleproducto);//0
                arrProductoReturn.Add(objDP.descripcionDetalleproducto);//1
                arrProductoReturn.Add(objDP.idProducto);//2
                arrProductoReturn.Add(objDP.idDepartamento);//3
                arrProductoReturn.Add(objDP.precioCompraDetalleproducto);//4
                arrProductoReturn.Add(objDP.porcentajeGanancia);//5
                arrProductoReturn.Add(objDP.precioVentaDetalleproducto); //6
                
            }

            return arrProductoReturn;

        }
        public int MontoTotal(int IdDocumento)
        {
            DaoDocumentos appDoc = new DaoDocumentos();
            int Total = appDoc.MontoTotal(IdDocumento);

            return Total;
        }

        public bool ComparaTotales(int totalDocumento, int totalDetalle, int idDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();



            if (totalDocumento > totalDetalle)
            {
                daoDoc.ModificarEstadoDocumento(idDocumento, 1);

                return false;
            }
            if (totalDocumento == totalDetalle)
            {

                daoDoc.ModificarEstadoDocumento(idDocumento, 2);
                return true;
            }
            if (totalDocumento < totalDetalle)
            {

                daoDoc.ModificarEstadoDocumento(idDocumento, 3);
                return false;
            }
            return false;
        }

        public void CerrarDocumento(int idSucursal,int idDocumento, int cantidad, String codigoDetalle)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arrDetalle=new ArrayList();
            arrDetalle=daoDoc.SeleccionaProducto(codigoDetalle, idDocumento);

            foreach(DetalleProducto objDetalle in arrDetalle){
                daoDoc.AgregarStock('+', cantidad, objDetalle.idDetalleproducto, idSucursal);
            }
            
        }
        public void CerrarVenta(int idSucursal, int idDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arrDetalle = new ArrayList();
            arrDetalle = daoDoc.SeleccionaProducto("", idDocumento);

            foreach (DetalleProducto objDetalle in arrDetalle)
            {
                daoDoc.AgregarStock('-', objDetalle.cantidadDetalleproducto, objDetalle.idDetalleproducto, idSucursal);
            }
            daoDoc.ModificarEstadoDocumento(idDocumento, 2);
        }
        public void EliminarDetalleIngreso(int idSucursal,  int idDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arrDetalle = new ArrayList();
            arrDetalle = daoDoc.SeleccionaProducto("",idDocumento);

            foreach (DetalleProducto objDetalle in arrDetalle)
            {
                daoDoc.AgregarStock('-', objDetalle.cantidadDetalleproducto, objDetalle.idDetalleproducto, idSucursal);
            }
            daoDoc.ModificarEstadoDocumento(idDocumento, 5);
        }
        public void EliminarDetalleEgreso(int idSucursal, int idDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arrDetalle = new ArrayList();
            arrDetalle = daoDoc.SeleccionaProducto("", idDocumento);

            foreach (DetalleProducto objDetalle in arrDetalle)
            {
                daoDoc.AgregarStock('+', objDetalle.cantidadDetalleproducto, objDetalle.idDetalleproducto, idSucursal);
            }
            daoDoc.ModificarEstadoDocumento(idDocumento, 5);
        }
        public ArrayList GenerarTotales(int idDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList totales = new ArrayList();
            ArrayList arr = new ArrayList();
            int neto = 0;
            double iva = 0;
            double total = 0;
            int netoSinBoleta = 0;
            arr = daoDoc.SeleccionaProducto("", idDocumento);
            foreach (DetalleProducto objDet in arr)
            {
                if (objDet.boleta == 1)
                {
                    neto = neto + (objDet.precioVentaDetalleproducto*objDet.cantidadDetalleproducto);
                }
                else
                {
                    netoSinBoleta = netoSinBoleta + (objDet.precioVentaDetalleproducto*objDet.cantidadDetalleproducto);
                }
            }
            iva = neto * 0.19;
            total = iva + neto;

            totales.Add(neto);
            totales.Add(iva);
            totales.Add(total);
            totales.Add(total + netoSinBoleta);
            return totales;

        }
    }
}