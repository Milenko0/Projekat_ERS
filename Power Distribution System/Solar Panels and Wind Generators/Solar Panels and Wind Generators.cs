using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Panels_and_Wind_Generators
{
    public class Solar_Panels_and_Wind_Generators
    {
        private static int pocetnaProizvodnjaPanela = 10000;
        private static int pocetnaProizvodnjaTurbina = 10000;
        public int JacinaSunca { get; set; }
        public int JacinaVetra { get; set; }
        public int BrojPanela { get; set; }
        public int BrojTurbina { get; set; }

        public Solar_Panels_and_Wind_Generators()
        {
            JacinaSunca = 100;
            JacinaVetra = 100;
            BrojPanela = 0;
            BrojTurbina = 0;
        }

        public int ProizvodnjaPanela
        {
            get
            {
                return pocetnaProizvodnjaPanela * JacinaSunca / 100;
            }
            
        }

        public int ProizvodnjaTurbina
        {
            get
            {
                return pocetnaProizvodnjaTurbina * JacinaVetra / 100;
            }

        }

    }
}
