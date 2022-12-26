using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Center
{
    public class Distribution_Center
    {
        public Hydroelectric_Power_Plant.Hydroelectric_Power_Plant hidroelektrana = new Hydroelectric_Power_Plant.Hydroelectric_Power_Plant();

        static private int maksimalnaProizvodnjaHidroelektrane = 50000;
        public int PrirodnaProizvodnja { get; set; }
        public Distribution_Center()
        {
            PrirodnaProizvodnja = 0;
        }

        public void regulisiHidroelektranu(int potraznja) {
            if(PrirodnaProizvodnja > potraznja)
            {
                hidroelektrana.UpotrebaHidroelektrane = 0;
                Console.WriteLine("Nije potrebna upotreba hidroelektrane.");
                LogRegulacijeHidroElektrane(hidroelektrana.UpotrebaHidroelektrane);
            }
            else if(potraznja - PrirodnaProizvodnja > maksimalnaProizvodnjaHidroelektrane * hidroelektrana.UpotrebaHidroelektrane / 100)
            {
                hidroelektrana.UpotrebaHidroelektrane = (potraznja - PrirodnaProizvodnja) / (maksimalnaProizvodnjaHidroelektrane / 100);
                Console.WriteLine("Potrebno je povecati nivo proizvodnje hidroelektrane.");
                Console.WriteLine("Novi nivo upotrebljenosti hidroelektrane je " + hidroelektrana.UpotrebaHidroelektrane + "%.");
                LogRegulacijeHidroElektrane(hidroelektrana.UpotrebaHidroelektrane);
            }
            else if (potraznja - PrirodnaProizvodnja < maksimalnaProizvodnjaHidroelektrane * hidroelektrana.UpotrebaHidroelektrane / 100)
            {
                hidroelektrana.UpotrebaHidroelektrane = (potraznja - PrirodnaProizvodnja) / (maksimalnaProizvodnjaHidroelektrane / 100);
                Console.WriteLine("Potrebno je smanjiti nivo proizvodnje hidroelektrane.");
                Console.WriteLine("Novi nivo upotrebljenosti hidroelektrane je " + hidroelektrana.UpotrebaHidroelektrane + "%.");
                LogRegulacijeHidroElektrane(hidroelektrana.UpotrebaHidroelektrane);
            }
            else
            {
                Console.WriteLine("Nije potrebno menjati nivo proizvodnje hidroelektrane.");
                Console.WriteLine("Nivo upotrebljenosti hidroelektrane je " + hidroelektrana.UpotrebaHidroelektrane + "%.");
                LogRegulacijeHidroElektrane(hidroelektrana.UpotrebaHidroelektrane);
            }
        }

        private static void LogRegulacijeHidroElektrane(int upotreba)
        {
            string logFilePath = System.IO.Directory.GetCurrentDirectory() + "\\LogRegulacijeHidroElektrane.txt";

            if (!File.Exists(logFilePath))
            {
                using (StreamWriter sw = File.CreateText(logFilePath))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("Nivo upotrebljenosti hidroelektrane je " + upotreba + "%.");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("Nivo upotrebljenosti hidroelektrane je " + upotreba + "%.");
                }
            }
        }

        public double izracunajCenu(int potraznja) 
        {
            double cenaPoKWh;
            
                if (potraznja <= 350)
                {
                    cenaPoKWh = 6.034;
                }
                else
                if (potraznja >= 351 && potraznja <= 1600)
                {
                    cenaPoKWh = 9.051;
                }
                else cenaPoKWh = 18.102;
                return cenaPoKWh;
        }

    }
}
