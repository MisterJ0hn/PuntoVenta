﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using InventarioWebEntity;
using System.Data.SqlClient;
using System.Data;
namespace InventarioWebDao
{
    public class DaoDocumentos
    {
        public int Agregar(int numeroDoc, int monto, int tipoDocumento, String fechaEmision, String rutEmpresa, String rutEmpresaPropia,int tmov, int formaPago, int idUsuario)
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
            arrValores.Add(tmov.ToString());
            arrValores.Add("'" + hoy.ToString() + "'");
            arrValores.Add(monto.ToString());
            arrValores.Add("1");
            arrValores.Add(formaPago.ToString());
            arrValores.Add(idUsuario.ToString());
          
            arrCampos.Add("IdTipoDocumento");
            arrCampos.Add("RutproveedorDocumento");
            arrCampos.Add("RutEmpresa");
            arrCampos.Add("NumeroDocumento");
            arrCampos.Add("FechaemisionDocumento");
            arrCampos.Add("IdTipomovimiento");
            arrCampos.Add("FechaingresoDocumento");
            arrCampos.Add("MontototalDocumento");
            arrCampos.Add("EstadoDocumento");
            arrCampos.Add("IdFormapago");
            arrCampos.Add("IdUsuarioRegistro");

            objConexion.AddValue(arrValores);
            int id=objConexion.InsertSql("DOCUMENTO",arrCampos,true);
            return id;
        }
        public int AgregarProducto(DetalleProducto objDP, double pganancia=0)
        {
            DaoConexion objConexion = new DaoConexion();
            SqlDataReader drArreglo;
            ArrayList arrConexion = new ArrayList();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();
            String porcentaje = "";
            DateTime hoy = DateTime.Today;
            if (pganancia > 0)
            {
                porcentaje = pganancia.ToString();
            }
            else
            {
                arrConexion = objConexion.QuerySql("SELECT PorcentajeGananciaProducto FROM PRODUCTO WHERE IdProducto=" + objDP.idProducto.ToString());
                drArreglo = (SqlDataReader)arrConexion[0];
                if (drArreglo.HasRows)
                {
                    while (drArreglo.Read())
                    {
                        porcentaje = drArreglo[0].ToString();
                    }

                }
            }

            arrCampos.Add("CodigoDetalleproducto");
            arrCampos.Add("DescripcionDetalleproducto");
            arrCampos.Add("PreciocompraDetalleproducto");
            //arrCampos.Add("CantidadDetalleproducto");
            arrCampos.Add("PorcentajegananciaDetalleproducto");
            arrCampos.Add("PrecioventaDetalleproducto");
            arrCampos.Add("IdProducto");
            
            arrValores.Add("'" + objDP.codigoDetalleproducto.ToString() + "'");
            arrValores.Add("'" + objDP.descripcionDetalleproducto.ToString() + "'");
            arrValores.Add(objDP.precioCompraDetalleproducto.ToString());
            //arrValores.Add(objDP.cantidadDetalleproducto.ToString());
            arrValores.Add(porcentaje.ToString());
            arrValores.Add("ROUND("+(objDP.precioCompraDetalleproducto+(objDP.precioCompraDetalleproducto * Convert.ToDouble(porcentaje) / 100)).ToString().Replace(',','.')+",-1)");
            arrValores.Add(objDP.idProducto.ToString());
          

            objConexion.AddValue(arrValores);

            int id = objConexion.InsertSql("DETALLEPRODUCTO", arrCampos, true);

            return id;
        }
        
        public int AgregarProductoProducto(Producto objDP)
        {
            DaoConexion objConexion = new DaoConexion();
            SqlDataReader drArreglo;
            ArrayList arrConexion = new ArrayList();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();
            String porcentaje = "";
            DateTime hoy = DateTime.Today;
            if (Convert.ToDouble(objDP.porcentajeGanancia) > 0)
            {
                porcentaje = objDP.porcentajeGanancia;
            }
            else
            {
                arrConexion = objConexion.QuerySql("SELECT PorcentajeGananciaDepartamento FROM DEPARTAMENTO WHERE IdDepartamento=" + objDP.idDepartamento.ToString());
                drArreglo = (SqlDataReader)arrConexion[0];
                if (drArreglo.HasRows)
                {
                    while (drArreglo.Read())
                    {
                        porcentaje = drArreglo[0].ToString();
                    }

                }
            }

            arrCampos.Add("TipoproductoProducto");
            arrCampos.Add("PorcentajegananciaProducto");
            arrCampos.Add("ImpuestoProducto");
            //arrCampos.Add("CantidadDetalleproducto");
            arrCampos.Add("IdDepartamento");


            arrValores.Add("'" + objDP.tipoProducto.ToString() + "'");
            arrValores.Add( porcentaje.ToString().Replace(',','.'));
            arrValores.Add("'" + objDP.impuestoProducto.ToString()+ "'");
            //arrValores.Add(objDP.cantidadDetalleproducto.ToString());
            arrValores.Add(objDP.idDepartamento.ToString());
            


            objConexion.AddValue(arrValores);

            int id = objConexion.InsertSql("PRODUCTO", arrCampos, true);

            return id;
        }



        public int AgregarDepartamento(Departamento objDP)
        {
            DaoConexion objConexion = new DaoConexion();
            
            ArrayList arrConexion = new ArrayList();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();
            
            DateTime hoy = DateTime.Today;
         

           
            arrCampos.Add("PorcentajeGananciaDepartamento");
            arrCampos.Add("TipodepartamentoDepartamento");
            

           
            arrValores.Add(objDP.porcentajeGanancia.ToString().Replace(',','.'));
            arrValores.Add("'" + objDP.tipoDepartamento.ToString() + "'");
            



            objConexion.AddValue(arrValores);

            int id = objConexion.InsertSql("DEPARTAMENTO", arrCampos, true);

            return id;
        }

        public void ModificarProducto(DetalleProducto objDP, double pganancia = 0)
        {
            DaoConexion objConexion = new DaoConexion();
          
            ArrayList arrValores = new ArrayList();
            
            String porcentaje = pganancia.ToString();

            arrValores.Add("CodigoDetalleproducto='" + objDP.codigoDetalleproducto.ToString() + "'");
            arrValores.Add("DescripcionDetalleproducto='" + objDP.descripcionDetalleproducto.ToString() + "'");
            arrValores.Add("PreciocompraDetalleproducto=" + objDP.precioCompraDetalleproducto.ToString());
            //arrValores.Add(objDP.cantidadDetalleproducto.ToString());
            arrValores.Add("PorcentajegananciaDetalleproducto=" + porcentaje.ToString().Replace(',', '.'));
            arrValores.Add("PrecioventaDetalleproducto=" + Convert.ToInt32(objDP.precioCompraDetalleproducto + (objDP.precioCompraDetalleproducto * Convert.ToDouble(porcentaje) / 100)));

            objConexion.UpdateSql("DETALLEPRODUCTO", arrValores, "IdDetalleproducto=" + objDP.idDetalleproducto);
        }
        public void ModificarDepartamento(Departamento objDP)
        {
            DaoConexion objConexion = new DaoConexion();

            ArrayList arrValores = new ArrayList();

            arrValores.Add("PorcentajeGananciaDepartamento=" + objDP.porcentajeGanancia.ToString().Replace(',', '.'));
            arrValores.Add("TipodepartamentoDepartamento='" + objDP.tipoDepartamento.ToString() + "'");

            objConexion.UpdateSql("DEPARTAMENTO", arrValores, "IdDepartamento=" + objDP.idDepartamento);

        }
        public void ModificarProductoProducto(Producto objDP)
        {
            DaoConexion objConexion = new DaoConexion();

            ArrayList arrValores = new ArrayList();

            arrValores.Add("PorcentajeGananciaProducto=" + objDP.porcentajeGanancia.ToString().Replace(',', '.'));
            arrValores.Add("TipoproductoProducto='" + objDP.tipoProducto + "'");
            arrValores.Add("ImpuestoProducto=" + objDP.impuestoProducto.ToString());
            arrValores.Add("IdDepartamento=" + objDP.idDepartamento.ToString());
            


            objConexion.UpdateSql("PRODUCTO", arrValores, "IdProducto=" + objDP.idProducto);

        }
        public void ModificarGananciasRecursivas(int idDepartamento, int idProducto, String porcentajeNuevo, String porcentajeAntiguo, bool cambiarDetalle=false)
        {
            ArrayList arrValores = new ArrayList();
            if (idDepartamento > 0)
            {
                DaoConexion objConP = new DaoConexion();
                arrValores.Clear();

                arrValores.Add("PorcentajeGananciaProducto=" + porcentajeNuevo.Replace(',', '.'));
                objConP.UpdateSql("PRODUCTO", arrValores, "IdDepartamento=" + idDepartamento.ToString() + " AND PorcentajeGananciaProducto=" + porcentajeAntiguo.Replace(',', '.'));

                if (cambiarDetalle)
                {
                    ArrayList arrProd = new ArrayList();
                    arrProd = SeleccionaProducto(0, idDepartamento);

                    foreach (Producto objProd in arrProd)
                    {
                        arrValores.Clear();
                        DaoConexion objConD = new DaoConexion();
                        arrValores.Add("PorcentajegananciaDetalleproducto=" + porcentajeNuevo.Replace(',', '.'));
                        arrValores.Add("PrecioventaDetalleproducto=PreciocompraDetalleproducto+(PreciocompraDetalleproducto*" + porcentajeNuevo.Replace(',', '.') + "/100)");
                        objConD.UpdateSql("DETALLEPRODUCTO", arrValores, " IdProducto=" + objProd.idProducto.ToString() + " And PorcentajegananciaDetalleproducto=" + porcentajeAntiguo.Replace(',', '.'));
                    }

                }
            }
            if (idProducto > 0)
            {
                arrValores.Clear();
                DaoConexion objConD = new DaoConexion();
                arrValores.Add("PorcentajegananciaDetalleproducto=" + porcentajeNuevo.Replace(',', '.'));
                arrValores.Add("PrecioventaDetalleproducto=PreciocompraDetalleproducto+(PreciocompraDetalleproducto*" + porcentajeNuevo.Replace(',', '.') + "/100)");
                objConD.UpdateSql("DETALLEPRODUCTO", arrValores, " IdProducto=" + idProducto.ToString() + " And PorcentajegananciaDetalleproducto=" + porcentajeAntiguo.Replace(',', '.'));
  
            }
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
                    arrValores.Add("CantidadStock=CantidadStock+(" + cantidad + ")");
                }else{
                    arrValores.Add("CantidadStock=CantidadStock-("+cantidad+")");
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
        public int StockDetalleProducto( int idDetalleproducto, int idSucursal)
        {
            DaoConexion objConexion = new DaoConexion();
            SqlDataReader drArreglo;
     
            ArrayList arrConexion = new ArrayList();
            int stock = 0;
            arrConexion = objConexion.QuerySql("select CantidadStock  from STOCK where IdSucursal=" + idSucursal + " and IdDetalleproducto=" + idDetalleproducto);
             drArreglo = (SqlDataReader)arrConexion[0];
             if (drArreglo.HasRows)
             {
                 while (drArreglo.Read())
                 {
                     Producto objProd = new Producto();

                     stock = drArreglo.GetInt32(0);
              
                   
                 }
             }
             return stock;
        }
        public void AgregarDetalleDocumento(int idDetalleproducto, int idDocumdento, int cantida, int precioVenta, int precioCosto, int utilidad, double ganancia)
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
            arrCampos.Add("Ganancia");
               
            arrValores.Add(idDetalleproducto.ToString());
            arrValores.Add(idDocumdento.ToString());
            arrValores.Add(cantida.ToString());
            arrValores.Add(precioVenta.ToString());
            arrValores.Add(precioCosto.ToString());
            arrValores.Add(utilidad.ToString());
            arrValores.Add(ganancia.ToString().Replace(',','.'));
 

            objConexion.AddValue(arrValores);
            objConexion.InsertSql("DETALLEDOCUMENTO", arrCampos);

        }
        public ArrayList seleccionaDocumento(int tMov, String rutEmpresa=null, int idDocumento=0, bool soloMax=false, int estadoDocumento=2, int numeroDocumento=0, int documentoCerrado=2){
            DaoConexion objConexionDao = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrDoc = new ArrayList();
            String sqlCerrado = "";
            if(documentoCerrado!=2){
                sqlCerrado += " and DocumentoCerrado=" + documentoCerrado.ToString();
            }

            if (soloMax)
            {
                String sql = "";
                String select = "max(NumeroDocumento) AS Maximo";
                if (estadoDocumento != 0)
                {
                    sql += " AND EstadoDocumento=" + estadoDocumento;
                    

                }
                if (rutEmpresa != "")
                {
                    sql += " and RutproveedorDocumento like '" + rutEmpresa + "'";
                }
                if (numeroDocumento > 0)
                {
                    sql += " and NumeroDocumento=" + numeroDocumento;
                    select = "NumeroDocumento";
                }
                arrConexion = objConexionDao.QuerySql("SELECT "+select+" FROM DOCUMENTO WHERE EstadoDocumento!=5 AND IdTipomovimiento=" + tMov +sql);

                drArreglo = (SqlDataReader)arrConexion[0];
                if (drArreglo.HasRows)
                {
                    while (drArreglo.Read())
                    {
                        int Maximo=0;
                        try
                        {
                             Maximo= drArreglo.GetInt32(0);
                        }
                        catch
                        {
                             Maximo = 0;
                        }

                        arrDoc.Add(Maximo);

                    }

                }
            }
            else
            {
                if (idDocumento > 0)
                {
                    arrConexion = objConexionDao.QuerySql("SELECT IdDocumento, RutproveedorDocumento, IdTipodocumento,NumeroDocumento, FechaemisionDocumento, MontototalDocumento, EstadoDocumento FROM DOCUMENTO WHERE IdTipomovimiento=" + tMov + " and  IdDocumento = " + idDocumento+sqlCerrado);
                }
                else
                {
                    arrConexion = objConexionDao.QuerySql("SELECT IdDocumento, RutproveedorDocumento, IdTipodocumento,NumeroDocumento, FechaemisionDocumento, MontototalDocumento, EstadoDocumento FROM DOCUMENTO WHERE  IdTipomovimiento=" + tMov + " and RutEmpresa like '" + rutEmpresa + "' and EstadoDocumento=" + estadoDocumento+sqlCerrado);
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
                        objDoc.estadoDocumento = drArreglo.GetInt32(6);
                        arrDoc.Add(objDoc);

                    }

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
                                                    " '' as RutEmpresa, P.IdProducto, P.IdDepartamento, DD.Ganancia,DD.PrecioVenta,ImpuestoProducto " +
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
                                                    "0 as CantidadDetalleproducto,'' as  RutEmpresa, DETALLEPRODUCTO.IdProducto, IdDepartamento, PorcentajegananciaDetalleproducto, PrecioventaDetalleproducto,ImpuestoProducto" +
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
                    objDP.porcentajeGanancia = Convert.ToString(drArreglo.GetDouble(8));
                    objDP.precioVentaDetalleproducto = drArreglo.GetInt32(9);
                    objDP.boleta = drArreglo.GetInt32(10);
                    arr.Add(objDP);
                }

            }
            drArreglo.Close();
            return arr;
        }
        public ArrayList SeleccionaDepartamentos(int idDepartamento)
        {
             DaoConexion conexion = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arr = new ArrayList();


            arrConexion = conexion.QuerySql("SELECT IdDepartamento, TipodepartamentoDepartamento,PorcentajeGananciaDepartamento FROM DEPARTAMENTO WHERE IdDepartamento="+idDepartamento);
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    Departamento objDep = new Departamento();

                    objDep.idDepartamento = drArreglo.GetInt32(0);
                    objDep.tipoDepartamento = drArreglo.GetString(1);
                    objDep.porcentajeGanancia =Convert.ToString(drArreglo.GetDouble(2));

                    arr.Add(objDep);

                }
            }
            drArreglo.Close();

            return arr;

        }
        public ArrayList SeleccionaProducto(int idProducto, int idDepartamento=0)
        {
            DaoConexion conexion = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arr = new ArrayList();
            String sql = "";

            if(idDepartamento>0){
                sql="IdDepartamento="+idDepartamento;
            }else{
                sql="IdProducto="+idProducto;
            }
            arrConexion = conexion.QuerySql("SELECT IdProducto, TipoproductoProducto, PorcentajeGananciaProducto, ImpuestoProducto, IdDepartamento "+
                                            " FROM PRODUCTO WHERE "+sql );
            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    Producto objProd = new Producto();

                    objProd.idProducto = drArreglo.GetInt32(0);
                    objProd.tipoProducto = drArreglo.GetString(1);
                    objProd.porcentajeGanancia = Convert.ToString(drArreglo.GetDouble(2));
                    objProd.impuestoProducto = drArreglo.GetInt32(3);
                    objProd.idDepartamento = drArreglo.GetInt32(4);
                    arr.Add(objProd);
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
        public void ModificarEstadoDocumento(int idDocumento, int estadoDocumento, int montoTotal=0)
        {
            DaoConexion conn = new DaoConexion();
            ArrayList arr = new ArrayList();

            arr.Add("EstadoDocumento=" + estadoDocumento.ToString());
            if (montoTotal > 0)
            {
                arr.Add("MontototalDocumento=" + montoTotal.ToString());
            }

            conn.UpdateSql("DOCUMENTO", arr, "IdDocumento=" + idDocumento);

        }
        public String ProductoPorcentaje(int idProducto)
        {
            DaoConexion conexion = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            String porcentaje = "";
            
            arrConexion = conexion.QuerySql("SELECT P.PorcentajeGananciaProducto " +
                                           "FROM PRODUCTO P " +
                                           "WHERE P.IdProducto= " + idProducto);

            drArreglo = (SqlDataReader)arrConexion[0];
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                    porcentaje = drArreglo.GetDouble(0).ToString();
                }
            }
            return porcentaje;
        }
        public void EliminarCantidadStock(int idDetalleproducto, int idSucursal)
        {
            DaoConexion conexion = new DaoConexion();
           
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            ArrayList arrValores = new ArrayList();

            arrValores.Add("CantidadStock=0");
            conexion.UpdateSql("STOCK", arrValores, "IdDetalleproducto=" + idDetalleproducto + " and IdSucursal=" + idSucursal);
        }
        public int AgregarPromocion(String nombre, String codigo,int precio )
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();


            arrCampos.Add("Descripcion");
            arrCampos.Add("CodigoPromocion");
            arrCampos.Add("PrecioVenta");
            
            arrValores.Add(nombre);
            arrValores.Add(codigo);
            arrValores.Add(precio.ToString());
          

            objConexion.AddValue(arrValores);
            int id=objConexion.InsertSql("PROMOCIONES", arrCampos, true);

            return id;
        }
        public void AgregarDetallepromocion(int idPromocion, int idDetalleproducto, int cantidad)
        {
            DaoConexion objConexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();


            arrCampos.Add("IdPromociones");
            arrCampos.Add("IdDetalleproducto");
            arrCampos.Add("CantidadDetallepromociones");

            arrValores.Add(idPromocion.ToString());
            arrValores.Add(idDetalleproducto.ToString());
            arrValores.Add(cantidad.ToString());


            objConexion.AddValue(arrValores);
           objConexion.InsertSql("DETALLEPROMOCIONES", arrCampos);
        }
        public DataTable SeleccionaDetallepromocion(int idPromocion, int idDetallepromocion)
        {
            DaoConexion conexion = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            DataTable arr = new DataTable();
            String sql = "";

            if (idPromocion > 0)
            {
                sql += " IdPromociones=" + idPromocion;
            }
            if (idDetallepromocion > 0)
            {
                if (idPromocion > 0)
                {
                    sql += " AND";
                }
                sql += " IdDetallepromociones=" + idDetallepromocion;
            }
            arrConexion = conexion.QuerySql("SELECT IdDetallepromociones, IdPromociones, IdDetalleproducto, CantidadDetallepromociones Where "+sql);
            drArreglo = (SqlDataReader)arrConexion[0];


            arr.Columns.Add("IdDetalle");
            arr.Columns.Add("IdPromociones");
            arr.Columns.Add("IdDetalleproducto");
            arr.Columns.Add("CantidadDetalle");
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {
                   
                    DataRow Row1;
                    Row1 = arr.NewRow();
                    Row1["IdDetalle"] = drArreglo.GetInt32(0);
                    Row1["IdPromociones"] = drArreglo.GetInt32(1);
                    Row1["IdDetalleproducto"] = drArreglo.GetInt32(2);
                    Row1["CantidadDetalle"] = drArreglo.GetInt32(3);

                    arr.Rows.Add(Row1); 
                   
                }
            }
            drArreglo.Close();

            return arr;

        }
        public DataTable SeleccionaPromocion(int idPromocion, int idsucursal = 0)
        {
            DaoConexion conexion = new DaoConexion();
            SqlDataReader drArreglo;
            SqlConnection conConexion = new SqlConnection();
            ArrayList arrConexion = new ArrayList();
            DataTable arr = new DataTable();
            String sql = "";

            if (idPromocion > 0)
            {
                sql += " IdPromociones=" + idPromocion;
            }
            arrConexion = conexion.QuerySql("SELECT IdPromociones, CodigoPromocion, Descripcion, PrecioVenta Where " + sql);
            drArreglo = (SqlDataReader)arrConexion[0];


            arr.Columns.Add("IdPromociones");
            arr.Columns.Add("CodigoPromocion");
            arr.Columns.Add("Descripcion");
            arr.Columns.Add("PrecioVenta");
            if (drArreglo.HasRows)
            {
                while (drArreglo.Read())
                {

                    DataRow Row1;
                    Row1 = arr.NewRow();
                    Row1["IdPromociones"] = drArreglo.GetInt32(0);
                    Row1["CodigoPromocion"] = drArreglo.GetInt32(1);
                    Row1["Descripcion"] = drArreglo.GetInt32(2);
                    Row1["PrecioVenta"] = drArreglo.GetInt32(3);

                    arr.Rows.Add(Row1);

                }
            }
            drArreglo.Close();

            return arr;
        }
        
    }
}