using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Distribution_Center
{
    public class Distribution_Center
    {
        
        static int maksimalnaProizvodnjaHidroelektrane = 10000;
        public int PrirodnaProizvodnja { get; set; }
        public int UpotrebaHidroelektrane { get; set; }
        public Distribution_Center()
        {
            PrirodnaProizvodnja = 0;
            UpotrebaHidroelektrane = 50;
        }

        public void regulisiHidroelektranu(int potraznja) {
            if(PrirodnaProizvodnja > potraznja)
            {
                Console.WriteLine("Nije potrebna upotreba hidroelektrane.");
            }
            else if(potraznja - PrirodnaProizvodnja > maksimalnaProizvodnjaHidroelektrane * UpotrebaHidroelektrane / 100)
            {
                Console.WriteLine("Potrebno je povecati nivo proizvodnje hidroelektrane.");
            }
            else if (potraznja - PrirodnaProizvodnja < maksimalnaProizvodnjaHidroelektrane * UpotrebaHidroelektrane / 100)
            {
                Console.WriteLine("Potrebno je smanjiti nivo proizvodnje hidroelektrane.");
            }
            else
            {
                Console.WriteLine("Nije potrebno menjati nivo proizvodnje hidroelektrane.");
            }
        }

    }
}
