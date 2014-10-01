using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebEntity
{
    public class Empresa
    {
        private String RutEmpresa;
        private String NombreEmpresa;
        private String RazonSocial;
        private int IdTipoempresa;
        private int IdMaestra;
        public Empresa() { }
        public Empresa(String RutEmpresa, String NombreEmpresa, String RazonSocial, int IdTipoempresa,int IdMaestra)
        {
            this.RutEmpresa = RutEmpresa;
            this.NombreEmpresa = NombreEmpresa;
            this.RazonSocial = RazonSocial;
            this.IdTipoempresa = IdTipoempresa;
            this.IdMaestra = IdMaestra;
        }

        public String rutEmpresa
        {
            get{ return RutEmpresa;}
            set{ RutEmpresa = value;}
        }
        public String nombreEmpresa
        {
            get { return NombreEmpresa; }
            set { NombreEmpresa = value; }
        }
        public String razonSocial
        {
            get { return RazonSocial; }
            set { RazonSocial = value; }
        }
        public int idTipoEmpresa
        {
            get { return IdTipoempresa; }
            set { IdTipoempresa = value; }
        }
        public int idMaestra
        {
            get { return IdMaestra; }
            set { IdMaestra = value; }
        }

    }
}