using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebEntity
{
    public class Documentos
    {
        private int IdDocumento;
        private int TipoDocumento;

        private int TipoMovimiento;
        private String RutEmpresa;
        private String RutEmpresaPropia;
        private int NumeroDocumento;
        private String FechaEmision;
        private String FechaIngreso;
        private int MontoTotal;
        private int EstadoDocumento;

        public Documentos() { }
        public Documentos(int idDocumento, int tipoDocumento, String rutEmpresa, String rutEmpresaPropia, int numeroDocumento, String fechaEmision, String fechaIngreso, int montoTotal, int estadoDocumento, int tipoMovimiento)
        {
            this.IdDocumento = idDocumento;
            this.TipoDocumento = tipoDocumento;
            this.RutEmpresa = rutEmpresa;
            this.RutEmpresaPropia = rutEmpresaPropia;
            this.NumeroDocumento = numeroDocumento;
            this.FechaEmision = fechaEmision;
            this.FechaIngreso = fechaIngreso;
            this.MontoTotal = montoTotal;
            this.EstadoDocumento = estadoDocumento;
            this.TipoMovimiento = tipoMovimiento;
        }

        public int idDocumento
        {
            get
            {
                return IdDocumento;
            }
            set
            {
                IdDocumento = value;
            }
        }

        public int tipoDocumento
        {
            get { return TipoDocumento; }
            set { TipoDocumento = value; }
        }
        public String rutEmpresa {
            get { return RutEmpresa; }
            set { RutEmpresa = value; }
        }
        public String rutEmpresaPropia
        {
            get { return RutEmpresaPropia; }
            set { RutEmpresaPropia = value; }
        }
        public int numeroDocumento
        {
            get { return NumeroDocumento; }
            set { NumeroDocumento = value; }
        }
        public String fechaEmision
        {
            get { return FechaEmision; }
            set { FechaEmision = value; }
        }
        public String fechaIngreso
        {
            get { return FechaIngreso; }
            set { FechaIngreso = value; }
        }
        public int montoTotal
        {
            get { return MontoTotal; }
            set { MontoTotal = value; }
        }
        public int estadoDocumento
        {
            get { return EstadoDocumento; }
            set { EstadoDocumento = value; }
        }
        public int tipoMovimiento
        {
            get { return TipoMovimiento; }
            set { TipoMovimiento = value; }
        }
    }
}