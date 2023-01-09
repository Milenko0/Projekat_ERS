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
        private int upotrebaHidroelektrane;
        public int UpotrebaHidroelektrane {
            get { return upotrebaHidroelektrane; }
            set
            {
                try
                {
                    if (value <= 100)
                        upotrebaHidroelektrane = value;
                    else throw new ArgumentException("Ne sme biti upotreba hidroelektrane preko 100%!");
                }
                catch (Exception e) 
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    Environment.Exit(1);
                }
            }
        }

        public Hydroelectric_Power_Plant()
        {
            UpotrebaHidroelektrane = 50;
        }

    }
}
