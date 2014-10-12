﻿using System;
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

            if (conexion.Agregar(numeroDoc, monto, 1, fechaEmision, RutEmpresa, RutEmpresaPropia) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int AgregaProducto(String Codigo, String Descripcion, int idProducto, int precioCompra )
        {
            DaoDocumentos conexion = new DaoDocumentos();
            DetalleProducto objProd=new DetalleProducto();
            objProd.codigoDetalleproducto=Codigo;
            objProd.descripcionDetalleproducto=Descripcion;
            objProd.idProducto=idProducto;
            objProd.precioCompraDetalleproducto=precioCompra;

            int id=conexion.AgregarProducto(objProd);
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
            String sql = " RutEmpresaPropia='" + rutEmpresa+"' ";
          
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
            arrDoc = doc.seleccionaDocumento(null, idDocumento);
            foreach (Documentos objDoc in arrDoc)
            {
                arrDoc.Add(objDoc.idDocumento);//0
                arrDoc.Add(objDoc.rutEmpresa);//1
                arrDoc.Add(objDoc.tipoDocumento);//2
                arrDoc.Add(objDoc.numeroDocumento);//3
                arrDoc.Add(objDoc.fechaEmision);//4
                arrDoc.Add(objDoc.montoTotal);//5
            }

            return arrDoc;


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
                
            }

            return arrProductoReturn;

        }

    }
}