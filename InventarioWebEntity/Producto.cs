using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebEntity
{
    public class Producto
    {
        private int IdProducto;
        private String TipoProducto;
        private String PorcentajeGanancia;
        private int ImpuestoProducto;
        private int IdDepartamento;



        public int idProducto
        {
            get { return IdProducto; }
            set { IdProducto = value; }
        }
        public String tipoProducto
        {
            get { return TipoProducto; }
            set { TipoProducto = value; }

        }
        public String porcentajeGanancia
        {
            get { return PorcentajeGanancia; }
            set { PorcentajeGanancia = value; }
        }
        public int impuestoProducto
        {
            get { return ImpuestoProducto; }
            set { ImpuestoProducto = value; }
        }
        public int idDepartamento
        {
            get { return IdDepartamento; }
            set { IdDepartamento = value; }
        }
    }
}