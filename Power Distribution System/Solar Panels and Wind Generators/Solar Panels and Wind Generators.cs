using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
            JacinaSunca = 50;
            JacinaVetra = 50;
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
        public void generisiJacinuSunca()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;

            void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                JacinaSunca = rand.Next(0, 100);
            }

        }
        public void generisiJacinuVetra()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;

            void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                JacinaVetra = rand.Next(0, 100);
            }
        }
    }
}
