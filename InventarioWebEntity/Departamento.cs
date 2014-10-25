using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebEntity
{
    public class Departamento
    {
        private int IdDepartamento;
        private String PorcentajeGanancia;
        private String TipoDepartamento;

        public int idDepartamento
        {
            get
            {
                return IdDepartamento;
            }
            set { IdDepartamento = value; }

        }
        public String porcentajeGanancia
        {
            get { return PorcentajeGanancia; }
            set { PorcentajeGanancia = value; }

        }
        public String tipoDepartamento
        {
            get { return TipoDepartamento; }
            set { TipoDepartamento = value; }
        }

    }
}