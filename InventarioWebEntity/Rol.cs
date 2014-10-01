using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebEntity
{
    public class Rol
    {
        private int IdRol;
        private String Nombre;

        public Rol()
        {
        }

        public Rol(int IdRol, String Nombre)
        {
            this.IdRol = IdRol;
            this.Nombre = Nombre;
        }

        public int idRol
        {
            get { return IdRol; }
            set { IdRol = value; }
        }
        public String nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

    }
}