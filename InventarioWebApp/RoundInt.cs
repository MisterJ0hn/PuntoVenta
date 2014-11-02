using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioWebApp
{
    public class RoundInt
    {
        public int Round(int entero)
        {
            String strEntero = entero.ToString();
            int enteroReturn = 0;
            String unidad = strEntero.Substring((strEntero.Length - 1),1 );
            String resto = strEntero.Substring(0,(strEntero.Length - 1));

            if (Convert.ToInt32(unidad) >= 5)
            {
                enteroReturn = Convert.ToInt32(((Convert.ToInt32(resto) + 1) + "0").ToString());
            }
            if (Convert.ToInt32(unidad) < 5)
            {
                enteroReturn = Convert.ToInt32(resto + "0");
            }
            return enteroReturn;
        }
    }
}