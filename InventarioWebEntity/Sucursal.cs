using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebEntity
{
    public class Sucursal
    {
        private int IdSucursal;
        private String RutEmpresa;
        private String NombreSucursal;
        private String DireccionSucursal;
        private String TelefonoSucursal;
        private int IdComuna;
        private int IdMaestra;

        public Sucursal() 
        { 
        }
        public Sucursal(int IdSucursal, String RutEmpresa, String NombreSucursal, String DireccionSucursal, String TelefonoSucursal, int IdComuna, int IdMaestra)
        {
            this.IdSucursal = IdSucursal;
            this.RutEmpresa = RutEmpresa;
            this.NombreSucursal = NombreSucursal;
            this.DireccionSucursal = DireccionSucursal;
            this.TelefonoSucursal = TelefonoSucursal;
            this.IdComuna = IdComuna;
            this.IdMaestra = IdMaestra;
        }

        public int idSucursal
        {
            get { return IdSucursal; }
            set { IdSucursal = value; }

        }
        public String rutEmpresa
        {
            get{return RutEmpresa;}
            set{RutEmpresa=value;}

        }
        public String nombreSucursal
        {
            get{return NombreSucursal;}
            set{NombreSucursal=value;}
        }
        public String direccionSucursal
        {
            get{return DireccionSucursal;}
            set{DireccionSucursal = value;}
        }
        public String telefonoSucursal
        {
            get{return TelefonoSucursal;}
            set{TelefonoSucursal=value;}
        }
        public int idCOmuna
        {
            get{return IdComuna;}
            set{IdComuna=value;}
        }
        public int idMaestra
        {
            get{return IdMaestra;}
            set{IdMaestra=value;}
        }
    }

}