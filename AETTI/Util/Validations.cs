using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AETTI.Util
{
    public class Validations
    {
        public static bool ValidarCUIT(string cuit)
        {
            if (cuit == null) return true;
            if (cuit.Length < 11 && cuit.Length!=0) return false;

            int d0 = int.Parse(cuit[0].ToString());
            int d1 = int.Parse(cuit[1].ToString());
            int d2 = int.Parse(cuit[2].ToString());
            int d3 = int.Parse(cuit[3].ToString());
            int d4 = int.Parse(cuit[4].ToString());
            int d5 = int.Parse(cuit[5].ToString());
            int d6 = int.Parse(cuit[6].ToString());
            int d7 = int.Parse(cuit[7].ToString());
            int d8 = int.Parse(cuit[8].ToString());
            int d9 = int.Parse(cuit[9].ToString());
            int d10 = int.Parse(cuit[10].ToString());

            var resultado = d0 * 5 + d1 * 4 + d2 * 3 + d3 * 2 + d4 * 7 + d5 * 6 + d6 * 5 + d7 * 4 + d8 * 3 + d9 * 2;

            int mod = 11 - (resultado % 11);

            mod = mod == 11 ? 0 : mod;
            mod = mod == 10 ? 9 : mod;

            if (mod == d10) return true;
            return false;
        }
    }
}