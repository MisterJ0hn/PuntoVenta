using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebEntity
{
    public class DetalleProducto
    {
        private int IdDetalleproducto;
        private String CodigoDetalleproducto;
        private String DescripcionDetalleproducto;
        private int PrecioCompraDetalleproducto;
        private int PrecioVentaDetalleproducto;
        private int CantidadDetalleProducto;
        private String RutEmpresa;
        private int IdProducto;
        private int IdDepartamento;
        private String PorcentajeGanancia;
        private int Boleta;

        public DetalleProducto()
        {
        }

        public int idDetalleproducto
        {
            get { return IdDetalleproducto; }
            set { IdDetalleproducto = value; }
        }
        public String codigoDetalleproducto
        {
            get { return CodigoDetalleproducto; }
            set { CodigoDetalleproducto = value; }

        }
        public String descripcionDetalleproducto
        {
            get { return DescripcionDetalleproducto; }
            set { DescripcionDetalleproducto = value; }
        }
        public int precioCompraDetalleproducto
        {
            get { return PrecioCompraDetalleproducto; }
            set { PrecioCompraDetalleproducto = value; }
        }
        public int precioVentaDetalleproducto
        {
            get { return PrecioVentaDetalleproducto; }
            set { PrecioVentaDetalleproducto = value; }
        }
        public int cantidadDetalleproducto
        {
            get { return CantidadDetalleProducto; }
            set { CantidadDetalleProducto = value; }
        }
        public String rutEmpresa
        {
            get { return RutEmpresa; }
            set { RutEmpresa = value; }
        }
        public int idProducto
        {
            get { return IdProducto; }
            set { IdProducto = value; }
        }
        public int idDepartamento
        {
            get { return IdDepartamento; }
            set { IdDepartamento = value; }
        }
        public String porcentajeGanancia
        {
            get { return PorcentajeGanancia; }
            set { PorcentajeGanancia = value; }
        }
        public int boleta
        {
            get { return Boleta; }
            set { Boleta = value; }
        }
    }
}