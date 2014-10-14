﻿using System;
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
           // arrValores.Add("'" + hoy.ToString() + "'");
            arrValores.Add(monto.ToString());
            arrValores.Add("1");
          
            arrCampos.Add("IdTipoDocumento");
            arrCampos.Add("RutEmpresa");
            arrCampos.Add("RutEmpresaPropia");
            arrCampos.Add("NumeroDocumento");
            arrCampos.Add("FechaemisionDocumento");
            //arrCampos.Add("FechaIngreso");
            arrCampos.Add("MontototalDocumento");
            arrCampos.Add("EstadoDocumento");

            objConexion.AddValue(arrValores);
            int id=objConexion.InsertSql("DOCUMENTO",arrCampos,true);
            return id;
        }
        public int AgregarProducto(DetalleProducto objDP)
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();
            DateTime hoy = DateTime.Today;

            arrCampos.Add("CodigoDetalleproducto");
            arrCampos.Add("DescripcionDetalleproducto");
            arrCampos.Add("PreciocompraDetalleproducto");
            //arrCampos.Add("CantidadDetalleproducto");
            arrCampos.Add("IdProducto");

            arrValores.Add("'" + objDP.codigoDetalleproducto.ToString() + "'");
            arrValores.Add("'" + objDP.descripcionDetalleproducto.ToString() + "'");
            arrValores.Add(objDP.precioCompraDetalleproducto.ToString());
            //arrValores.Add(objDP.cantidadDetalleproducto.ToString());
            arrValores.Add(objDP.idProducto.ToString());

            objConexion.AddValue(arrValores);

            int id = objConexion.InsertSql("DETALLEPRODUCTO", arrCampos, true);

            return id;
        }
        public void AgregarStock(char signo,int cantidad, int idDetalleproducto, int idSucursal)
        {
            DaoConexion objConexion = new DaoConexion();
            SqlDataReader drArreglo;
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();
            ArrayList arrConexion = new ArrayList();

            arrConexion = objConexion.QuerySql("select * from STOCK where IdSucursal=" + idSucursal + " and IdDetalleproducto=" + idDetalleproducto);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                if(signo=='+'){
                    arrValores.Add("CantidadStock=CantidadStock+"+cantidad);
                }else{
                    arrValores.Add("CantidadStock=CantidadStock-"+cantidad);
                }
                

                objConexion.UpdateSql("STOCK",arrValores,"IdSucursal=" + idSucursal + " and IdDetalleproducto=" + idDetalleproducto);
            }else{
                
                arrCampos.Add("IdSucursal");
                arrCampos.Add("CantidadStock");
                arrCampos.Add("IdDetalleproducto");

                arrValores.Add(idSucursal.ToString());
                if (signo == '+')
                {
                    arrValores.Add(cantidad.ToString());
                }
                else
                {
                    arrValores.Add("-"+cantidad.ToString());
                }
                
                arrValores.Add(idDetalleproducto.ToString());

                objConexion.AddValue(arrValores);
                objConexion.InsertSql("STOCK",arrCampos);
            }

        }
        public void AgregarDetalleDocumento(int idDetalleproducto, int idDocumdento, int cantida, int precioVenta, int precioCosto, int utilidad)
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();

            arrCampos.Add("IdDetalleproducto");
            arrCampos.Add("IdDocumento");
            arrCampos.Add("Cantidad");
            arrCampos.Add("PrecioVenta");
            arrCampos.Add("PrecioCosto");
            arrCampos.Add("Utilidad");
            
            arrValores.Add(idDetalleproducto.ToString());
            arrValores.Add(idDocumdento.ToString());
            arrValores.Add(cantida.ToString());
            arrValores.Add(precioVenta.ToString());
            arrValores.Add(precioCosto.ToString());
            arrValores.Add(utilidad.ToString());

            objConexion.AddValue(arrValores);
            objConexion.InsertSql("DETALLEDOCUMENTO", arrCampos);

        }
        public ArrayList seleccionaDocumento(String rutEmpresa=null, int idDocumento=0){
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrDoc = new ArrayList();

            if (idDocumento > 0)
            {
                arrConexion = objConexionDao.QuerySql("SELECT IdDocumento, RutEmpresa, IdTipodocumento,NumeroDocumento, FechaemisionDocumento, MontototalDocumento FROM DOCUMENTO WHERE IdDocumento = " + idDocumento );
            }
            else
            {
                arrConexion = objConexionDao.QuerySql("SELECT IdDocumento, RutEmpresa, IdTipodocumento,NumeroDocumento, FechaemisionDocumento, MontototalDocumento FROM DOCUMENTO WHERE RutEmpresa like '" + rutEmpresa + "'");
            }
           
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    Documentos objDoc = new Documentos();
                    objDoc.idDocumento = drArreglo.GetInt32(0);
                    objDoc.rutEmpresa = drArreglo.GetString(1);
                    objDoc.tipoDocumento = drArreglo.GetInt32(2);
                    objDoc.numeroDocumento = drArreglo.GetInt32(3);
                    objDoc.fechaEmision = drArreglo.GetDateTime(4).ToString();
                    objDoc.montoTotal = drArreglo.GetInt32(5);

                    arrDoc.Add(objDoc);

                }

            }
            drArreglo.Close();
            return arrDoc;
        }
        public ArrayList SeleccionaProducto(String codigo="",  int idDocumento=0)
        {
            DaoConexion conexion = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arr = new ArrayList();
            String sql = "";

          

                if (idDocumento> 0)
                {
                    if (codigo != "")
                    {
                        sql = " and CodigoDetalleproducto= '" + codigo + "'";
                    }
                    arrConexion = conexion.QuerySql("SELECT DD.IdDetalleproducto ,CodigoDetalleproducto, DescripcionDetalleproducto,DD.PrecioCosto,DD.Cantidad,  " +
                                                    " '' as RutEmpresa, P.IdProducto, P.IdDepartamento, P.PorcentajeGanancia " +
                                                    " FROM DETALLEDOCUMENTO DD, DOCUMENTO D, DETALLEPRODUCTO DP, PRODUCTO P" +
                                                    " WHERE DD.IdDocumento=D.IdDocumento " +
                                                    " AND DD.IdDetalleproducto=DP.IdDetalleproducto " +
                                                    "AND P.IdProducto=DP.IdProducto "+
                                                    " AND D.IdDocumento= "+ idDocumento +
                                                    sql);

                }
                else
                {
                    if (codigo != "")
                    {
                        sql = "and CodigoDetalleproducto= '" + codigo + "'";
                    }
                    arrConexion = conexion.QuerySql("SELECT IdDetalleproducto, CodigoDetalleproducto, DescripcionDetalleproducto, PreciocompraDetalleproducto, " +
                                                    "0 as CantidadDetalleproducto, RutEmpresa, DETALLEPRODUCTO.IdProducto, IdDepartamento, PorcentajeGanancia" +
                                                    " FROM DETALLEPRODUCTO, PRODUCTO " +
                                                    " WHERE DETALLEPRODUCTO.IdProducto= PRODUCTO.IdProducto " + sql);
                }
           
            
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    DetalleProducto objDP = new DetalleProducto();
                    objDP.idDetalleproducto = drArreglo.GetInt32(0);
                    objDP.codigoDetalleproducto = drArreglo.GetString(1);
                    objDP.descripcionDetalleproducto = drArreglo.GetString(2);
                    objDP.precioCompraDetalleproducto = drArreglo.GetInt32(3);
                    objDP.cantidadDetalleproducto = drArreglo.GetInt32(4);
                    objDP.rutEmpresa = drArreglo.GetString(5);
                    objDP.idProducto = drArreglo.GetInt32(6);
                    objDP.idDepartamento = drArreglo.GetInt32(7);
                    objDP.porcentajeGanancia = drArreglo.GetString(8);
                    arr.Add(objDP);
                }

            }
            drArreglo.Close();
            return arr;
        }
        public int MontoTotal(int IdDocumento)
        {
            DaoConexion conexion = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            int Total = 0;
            arrConexion = conexion.QuerySql("SELECT sum((DD.Cantidad*DD.PrecioCosto)) as Total " +
                                           "FROM DETALLEDOCUMENTO DD " +
                                           "WHERE DD.IdDocumento= "+IdDocumento);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    try
                    {
                        Total = drArreglo.GetInt32(0);
                    }
                    catch
                    {
                        Total = 0;
                    }
                }
            }
            return Total;
        }
        public void ModificarEstadoDocumento(int idDocumento, int estadoDocumento)
        {
            DaoConexion conn = new DaoConexion();
            ArrayList arr = new ArrayList();

            arr.Add("EstadoDocumento=" + estadoDocumento);

            conn.UpdateSql("DOCUMENTO", arr, "IdDocumento=" + idDocumento);

        }
    }
}