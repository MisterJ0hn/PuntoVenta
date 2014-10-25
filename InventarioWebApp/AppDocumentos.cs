﻿using System;
using System.Collections;
using System.Data;
using InventarioWebDao;
using InventarioWebEntity;

namespace InventarioWebApp
{
    public class AppDocumentos
    {
        public int AgregarDocumento(String rutEmpresa, int tmov)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            ArrayList arrVenta = new ArrayList();
            
            int NumeroDocumento = 0;
            DateTime hoy = DateTime.Today;

            arrVenta = conexion.seleccionaDocumento(tmov, rutEmpresa, 0, true);
            NumeroDocumento = Convert.ToInt32(arrVenta[0].ToString());

            NumeroDocumento++;
            int idDocumento = conexion.Agregar(NumeroDocumento, 0, 35, hoy.ToString(), "00.000.000-0", rutEmpresa, tmov, 1);

            return idDocumento;
        }

        public bool AgregarDocumento(int numeroDoc, int monto,String fechaEmision, String RutEmpresa, String RutEmpresaPropia, int formaPago=1, int tmov=1)
        {
            DaoDocumentos conexion =new DaoDocumentos();
            ArrayList arr=new ArrayList();
            arr = conexion.seleccionaDocumento(1, RutEmpresa, 0, true, 0, numeroDoc);

            if (arr.Count > 0)
            {
                return false;
            }
            else
            {
                if (conexion.Agregar(numeroDoc, monto, 33, fechaEmision, RutEmpresa, RutEmpresaPropia, tmov, formaPago) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public int AgregarVenta(String rutEmpresa, int formaPago)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            ArrayList arrVenta = new ArrayList();
            int idDocumento = 0 ;
            int NumeroDocumento = 0;
            DateTime hoy=DateTime.Today;

            arrVenta = conexion.seleccionaDocumento(2, rutEmpresa, 0,true);

            NumeroDocumento = Convert.ToInt32(arrVenta[0].ToString());

            NumeroDocumento++;

            idDocumento=conexion.Agregar(NumeroDocumento, 0, 35, hoy.ToString(), "00.000.000-0", rutEmpresa, 2,formaPago);

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
        public int AgregarProductoProducto(String tipoProducto, int impuesto, String ganancia, int idDepartamento)
        {
            Producto objProd = new Producto();
            DaoDocumentos conexion = new DaoDocumentos();
            
            objProd.tipoProducto = tipoProducto;
            objProd.porcentajeGanancia = ganancia;
            objProd.impuestoProducto = impuesto;
            objProd.idDepartamento = idDepartamento;

            int id=conexion.AgregarProductoProducto(objProd);
           
            return id;
        }
        public int AgregarDepartamento(String porcentajeGanancia, String tipoDepartamento)
        {
            Departamento objDep = new Departamento();
            DaoDocumentos conexion = new DaoDocumentos();

            objDep.porcentajeGanancia = porcentajeGanancia;
            objDep.tipoDepartamento = tipoDepartamento;

            int id = conexion.AgregarDepartamento(objDep);
            return id;
        }
        public  void ModificaProducto(int idDetalleproducto, String Codigo, String Descripcion, int idProducto, int precioCompra, double porcentaje = 0, int boleta = 1)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            DetalleProducto objProd = new DetalleProducto();
            objProd.idDetalleproducto = idDetalleproducto;
            objProd.codigoDetalleproducto = Codigo;
            objProd.descripcionDetalleproducto = Descripcion;
            objProd.idProducto = idProducto;
            objProd.precioCompraDetalleproducto = precioCompra;
            objProd.boleta = boleta;

            conexion.ModificarProducto(objProd, porcentaje);
           
        }
        public void ModificaDepartamento(int idDepartamento, String ganancia, String tipoDepartamento, bool gananciaProducto = false, bool gananciaDetalle = false)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            String gananciaAntigua = "";
            Departamento dpto=new Departamento();
            ArrayList arr=new ArrayList();
            arr = daoDoc.SeleccionaDepartamentos(idDepartamento);
            foreach (Departamento objDep in arr)
            {
                gananciaAntigua = objDep.porcentajeGanancia;
            }

            dpto.idDepartamento=idDepartamento;
            dpto.porcentajeGanancia=ganancia;
            dpto.tipoDepartamento=tipoDepartamento;

            daoDoc.ModificarDepartamento(dpto);

            if (gananciaProducto)
            {
                daoDoc.ModificarGananciasRecursivas(idDepartamento, 0, ganancia, gananciaAntigua, gananciaDetalle);
            }

        }
        public void ModificaProductoProducto(int idProducto, String tipoProducto, String ganancia, int impuesto, int idDepartamento, bool gananciaDetalle = false)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            Producto objProd = new Producto();
            String gananciaAntigua = "";
            ArrayList arr = new ArrayList();

            arr = conexion.SeleccionaProducto(idProducto);
            foreach (Producto objPd in arr)
            {
                gananciaAntigua = objPd.porcentajeGanancia; 
            }

            objProd.idProducto = idProducto;
            objProd.tipoProducto = tipoProducto;
            objProd.porcentajeGanancia = ganancia;
            objProd.impuestoProducto = impuesto;
            objProd.idDepartamento = idDepartamento;



            conexion.ModificarProductoProducto(objProd);
            if (gananciaDetalle)
            {
                conexion.ModificarGananciasRecursivas(0, idProducto, ganancia, gananciaAntigua, gananciaDetalle);
            }

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
            String sql = " RutEmpresa='" + rutEmpresa + "' AND (EstadoDocumento=1 OR EstadoDocumento=3) and IdTipomovimiento=1";
          
            if (idSucursal > 0)
            {
                
            }

            arrFactura = conexion.LlenaCombos("IdDocumento", "NumeroDocumento", "DOCUMENTO", sql);

            return arrFactura;
        }
        public ArrayList SeleccionaEmpresa(int idDocumento, int estadoDocumento=2, bool porId=true, int tmov=1, String rutEmpresa="")
        {
            DaoDocumentos doc = new DaoDocumentos();
            ArrayList arrDoc = new ArrayList();
            ArrayList arrDocReturn = new ArrayList();
            if (porId)
            {
                arrDoc = doc.seleccionaDocumento(tmov, null, idDocumento, false, estadoDocumento);
            }else{

                arrDoc = doc.seleccionaDocumento(tmov, rutEmpresa,0, false, estadoDocumento);
            }
            foreach (Documentos objDoc in arrDoc)
            {
                arrDocReturn.Add(objDoc.idDocumento);//0
                arrDocReturn.Add(objDoc.rutEmpresa);//1
                arrDocReturn.Add(objDoc.tipoDocumento);//2
                arrDocReturn.Add(objDoc.numeroDocumento);//3
                arrDocReturn.Add(objDoc.fechaEmision);//4
                arrDocReturn.Add(objDoc.montoTotal);//5
                arrDocReturn.Add(objDoc.estadoDocumento);//6
            }

            return arrDocReturn;


        }
        public ArrayList SeleccionaVenta(int idDocumento)
        {
            DaoDocumentos doc = new DaoDocumentos();
            ArrayList arrDoc = new ArrayList();
            ArrayList arrDocReturn = new ArrayList();
            arrDoc = doc.seleccionaDocumento(2, null, idDocumento);
            foreach (Documentos objDoc in arrDoc)
            {
                arrDocReturn.Add(objDoc.idDocumento);//0
                arrDocReturn.Add(objDoc.rutEmpresa);//1
                arrDocReturn.Add(objDoc.tipoDocumento);//2
                arrDocReturn.Add(objDoc.numeroDocumento);//3
                arrDocReturn.Add(objDoc.fechaEmision);//4
                arrDocReturn.Add(objDoc.montoTotal);//5
                arrDocReturn.Add(objDoc.estadoDocumento);//6
            }

            return arrDocReturn;


        }
        public ArrayList SeleccionaDepartamento(int idDepartamento)
        {
            DaoDocumentos doc = new DaoDocumentos();
            ArrayList arrDoc = new ArrayList();
            ArrayList arrDocReturn = new ArrayList();
            arrDoc = doc.SeleccionaDepartamentos(idDepartamento);
            foreach (Departamento objDoc in arrDoc)
            {
                arrDocReturn.Add(objDoc.idDepartamento);//0
                arrDocReturn.Add(objDoc.porcentajeGanancia);//1
                arrDocReturn.Add(objDoc.tipoDepartamento);//2
                
            }

            return arrDocReturn;


        }
        public ArrayList SeleccionaProducto(int idProducto)
        {
            DaoDocumentos doc = new DaoDocumentos();
            ArrayList arrDoc = new ArrayList();
            ArrayList arrDocReturn = new ArrayList();
            arrDoc = doc.SeleccionaProducto(idProducto);
            foreach (Producto objDoc in arrDoc)
            {
                arrDocReturn.Add(objDoc.idProducto);//0
                arrDocReturn.Add(objDoc.tipoProducto);//1
                arrDocReturn.Add(objDoc.porcentajeGanancia);//2
                arrDocReturn.Add(objDoc.impuestoProducto);//3
                arrDocReturn.Add(objDoc.idDepartamento);//4


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
        public DataTable cboFormapago()
        {
            DaoEmpresas daoEmpresa = new DaoEmpresas();
            DataTable arrPago = new DataTable();

            arrPago = daoEmpresa.LlenaCombos("IdFormapago", "FormaPago", "FORMAPAGO");
            return arrPago;
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
                arrProductoReturn.Add(objDP.boleta);//7

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
        public void CerrarInicial(int idSucursal, int idDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arrDetalle = new ArrayList();
            arrDetalle = daoDoc.SeleccionaProducto("", idDocumento);

            foreach (DetalleProducto objDetalle in arrDetalle)
            {
                daoDoc.EliminarCantidadStock(objDetalle.idDetalleproducto, idSucursal);
                daoDoc.AgregarStock('+', objDetalle.cantidadDetalleproducto, objDetalle.idDetalleproducto, idSucursal);
            }
            daoDoc.ModificarEstadoDocumento(idDocumento, 2);
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
        public String PorcentajeProducto(int idProducto)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();

            String porcentaje = daoDoc.ProductoPorcentaje(idProducto);

            return porcentaje;
        }
        
        public int AgregarDepartamento(String nombre)
        {
            DaoConexion daoCon = new DaoConexion();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();

            arrValores.Add("'" + nombre + "'");


            arrCampos.Add("TipodepartamentoDepartamento");
           
            daoCon.AddValue(arrValores);

            int id = daoCon.InsertSql("DEPARTAMENTO", arrCampos, true);
            return id;
        }
    }
}