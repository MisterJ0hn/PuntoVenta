using System;
using System.Collections;
using System.Data;
using InventarioWebDao;
using InventarioWebEntity;

namespace InventarioWebApp
{
    public class AppDocumentos
    {
        public int AgregarDocumento(String rutEmpresa, int tmov, int idUsuarioRegistro)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            ArrayList arrVenta = new ArrayList();
            
            int NumeroDocumento = 0;
            DateTime hoy = DateTime.Today;

            arrVenta = conexion.seleccionaDocumento(tmov, rutEmpresa, 0, true);
            NumeroDocumento = Convert.ToInt32(arrVenta[0].ToString());

            NumeroDocumento++;
            int idDocumento = conexion.Agregar(NumeroDocumento, 0, 35, hoy.ToString(), "00.000.000-0", rutEmpresa, tmov, 1,idUsuarioRegistro);

            return idDocumento;
        }

        public bool AgregarDocumento(int numeroDoc, int monto,String fechaEmision, String RutEmpresa, String RutEmpresaPropia, int idUsuarioRegistro, int formaPago=1, int tmov=1)
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
                if (conexion.Agregar(numeroDoc, monto, 33, fechaEmision, RutEmpresa, RutEmpresaPropia, tmov, formaPago, idUsuarioRegistro) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public int AgregarVenta(String rutEmpresa, int formaPago, int idUsuarioRegistro)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            ArrayList arrVenta = new ArrayList();
            int idDocumento = 0 ;
            int NumeroDocumento = 0;
            DateTime hoy=DateTime.Today;

            arrVenta = conexion.seleccionaDocumento(2, rutEmpresa, 0,true);

            NumeroDocumento = Convert.ToInt32(arrVenta[0].ToString());

            NumeroDocumento++;

            idDocumento=conexion.Agregar(NumeroDocumento, 0, 35, hoy.ToString(), "00.000.000-0", rutEmpresa, 2,formaPago, idUsuarioRegistro);

            return idDocumento;

        }
        public bool AgregarPromocion(String nombre, String codigo, int precio, DataTable dtDetalle)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();

            try
            {
                int idPromo = daoDoc.AgregarPromocion(nombre, codigo, precio);

                foreach (DataRow rdPromo in dtDetalle.Rows)
                {
                    daoDoc.AgregarDetallepromocion(idPromo, Convert.ToInt32(rdPromo[0].ToString()), Convert.ToInt32(rdPromo[3].ToString()));
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool AgregarPromocionVenta(String codigo, int idSucursal, int IdDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            DataTable promo = daoDoc.SeleccionaPromocion(0, codigo);
            int disp=0;
            int idPromo = 0;
            int precio = 0;

            foreach (DataRow RowPromo in promo.Rows)
            {
                idPromo = Convert.ToInt32(RowPromo["IdPromociones"]);
                precio= Convert.ToInt32(RowPromo["PrecioVenta"]);

            }
            DataTable detallePromo = daoDoc.SeleccionaDetallepromocion(idPromo,0);
            foreach (DataRow RowDet in detallePromo.Rows)
            {
                disp = daoDoc.StockDetalleProducto(Convert.ToInt32(RowDet["IdDetalleproducto"]), idSucursal);
                if (disp< Convert.ToInt32(RowDet["CantidadDetalle"]))
                {
                    return false;
                }
            }
            AgregarDetalledocumento(idPromo, IdDocumento, 1, precio, 0, 0, 0,1);
            foreach (DataRow RowDet in detallePromo.Rows)
            {
                 AgregarDertalleVenta(Convert.ToInt32(RowDet["CantidadDetalle"].ToString()), Convert.ToInt32(RowDet["IdDetalleproducto"].ToString()), idSucursal);
            }

            return true;
            
          
        }
        public int AgregaProducto(String Codigo, String Descripcion, int idProducto, int precioCompra , double porcentaje=0, int precioVenta=0)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            DetalleProducto objProd=new DetalleProducto();
            objProd.codigoDetalleproducto=Codigo;
            objProd.descripcionDetalleproducto=Descripcion;
            objProd.idProducto=idProducto;
            objProd.precioCompraDetalleproducto=precioCompra;
            objProd.precioVentaDetalleproducto = precioVenta;

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
        public  void ModificaProducto(int idDetalleproducto, String Codigo, String Descripcion, int idProducto, int precioCompra, double porcentaje = 0, int boleta = 1, int precioVenta=0)
        {
            DaoDocumentos conexion = new DaoDocumentos();
            DetalleProducto objProd = new DetalleProducto();
            objProd.idDetalleproducto = idDetalleproducto;
            objProd.codigoDetalleproducto = Codigo;
            objProd.descripcionDetalleproducto = Descripcion;
            objProd.idProducto = idProducto;
            objProd.precioCompraDetalleproducto = precioCompra;
            objProd.boleta = boleta;
            objProd.precioVentaDetalleproducto = precioVenta;

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
        public void AgregarDetalledocumento(int idDetalleproducto, int idDocumdento, int cantida, int precioVenta, int precioCosto, int utilidad, double ganancia, int esPromocion=0)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
 
            daoDoc.AgregarDetalleDocumento(idDetalleproducto, idDocumdento, cantida, precioVenta, precioCosto, utilidad, ganancia,esPromocion );
            


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
        public ArrayList SeleccionaEmpresa(int idDocumento, int estadoDocumento=2, bool porId=true, int tmov=1, String rutEmpresa="", bool maximo=false)
        {
            DaoDocumentos doc = new DaoDocumentos();
            ArrayList arrDoc = new ArrayList();
            ArrayList arrDocReturn = new ArrayList();
            if (porId)
            {
                arrDoc = doc.seleccionaDocumento(tmov, null, idDocumento, maximo, estadoDocumento);
            }else{

                arrDoc = doc.seleccionaDocumento(tmov, rutEmpresa,0, maximo, estadoDocumento);
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
            if (idDocumento > 0)
            {
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
            ArrayList arrTotal = new ArrayList();
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
        public ArrayList DetalleProductoBuscar(String Codigo, int idSucursal=0)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arrProducto = new ArrayList();
            ArrayList arrProductoReturn = new ArrayList();
            arrProducto = daoDoc.SeleccionaProducto(Codigo); ;

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
                if (idSucursal > 0)
                {
                    arrProductoReturn.Add(daoDoc.StockDetalleProducto(objDP.idDetalleproducto, idSucursal));//8
                }
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
                daoDoc.ModificarEstadoDocumento(idDocumento, 2);

                return true;
            }
            if (totalDocumento == totalDetalle)
            {

                daoDoc.ModificarEstadoDocumento(idDocumento, 2);
                return true;
            }
            if (totalDocumento < totalDetalle)
            {

                daoDoc.ModificarEstadoDocumento(idDocumento, 2);
                return true;
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
                ModificaProducto(objDetalle.idDetalleproducto, objDetalle.codigoDetalleproducto, objDetalle.descripcionDetalleproducto, objDetalle.idProducto, objDetalle.precioCompraDetalleproducto, Convert.ToDouble(objDetalle.porcentajeGanancia), objDetalle.precioVentaDetalleproducto);
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
        public void CerrarVenta(int idSucursal, int idDocumento, int montoTotal)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
       
            daoDoc.ModificarEstadoDocumento(idDocumento, 2, montoTotal);
        }
        public void AgregarDertalleVenta(int cantidad, int idDetalle, int idSucursal)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            daoDoc.AgregarStock('-', cantidad, idDetalle, idSucursal);
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
            int iva = 0;
            int total = 0;
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
            RoundInt roundInt = new RoundInt();
            iva =  roundInt.Round(Convert.ToInt32(Math.Round((neto * 0.19),0)));
            total = roundInt.Round(Convert.ToInt32(iva + neto));

            totales.Add(neto);
            totales.Add(iva);
            totales.Add(neto);
            totales.Add(neto + netoSinBoleta);
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
        public bool ExisteEnDoc(String codigoDetalle, int idDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arr=new ArrayList();
            arr=daoDoc.SeleccionaProducto(codigoDetalle, idDocumento);
            bool existe = false;
            if (arr.Count>0)
            {
                existe = true;
            }
            return existe;

        }
        public int VentasDelDia(String empresa)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arr=new ArrayList();
            int suma = 0;
            arr = daoDoc.seleccionaDocumento(1, empresa, 0, false, 2,0,0);
            foreach (Documentos docObj in arr)
            {
                suma += docObj.montoTotal;
            }
            return suma;

        }
        public int ComprasDelDia(String empresa)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            ArrayList arr = new ArrayList();
            int suma = 0;
            arr = daoDoc.seleccionaDocumento(2, empresa, 0, false, 2,0,0);
            foreach (Documentos docObj in arr)
            {
                suma += docObj.montoTotal;
            }
            return suma;
        }
        public DataTable EntregarDetalleVenta(int IdDocumento)
        {
            DaoDocumentos daoDoc = new DaoDocumentos();
            return daoDoc.PreparaDetalleVenta(IdDocumento);
        }
    }
}