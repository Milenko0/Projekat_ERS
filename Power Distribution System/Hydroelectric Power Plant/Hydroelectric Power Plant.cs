using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydroelectric_Power_Plant
{
    public class Hydroelectric_Power_Plant
    {
        public static int maksimalnaProizvodnjaHidroelektrane = 100000;
        public int UpotrebaHidroelektrane { get; set; }

        public Hydroelectric_Power_Plant()
        {
            UpotrebaHidroelektrane = 50;
        }

    }
}
