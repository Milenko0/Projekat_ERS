using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Consumer.Uredjaj;

namespace Consumer
{
    internal class Consumer
    {
        private List<Uredjaj> uredjaji;
        private int trenutnaPotraznja;

        public Consumer()
        {
            uredjaji = new List<Uredjaj>();
            trenutnaPotraznja = 0;
        }

        public void Dodaj(Uredjaj uredjaj)
        {
            uredjaji.Add(uredjaj);
        }

        public void Ukloni(Uredjaj uredjaj)
        {
            uredjaji.Remove(uredjaj);
        }

        public void UkljuciUredjaj(Uredjaj uredjaj)
        {
            if (!uredjaji.Contains(uredjaj))
            {
                Console.WriteLine("Uredjaj nije pronadjen na listi!");
                return;
            }

            trenutnaPotraznja += uredjaj.PotrosnjaEnergije;
            uredjaj.Ukljuci();

            Console.WriteLine("Uredjaj je ukljucen i potraznja je: " + trenutnaPotraznja + " kWh.");
            // LogDogadjaja(ePotraznja, cenaPokWh);
        }

        public void IskljuciUredjaj(Uredjaj uredjaj)
        {
            if (!uredjaji.Contains(uredjaj))
            {
                Console.WriteLine("Uredjaj nije pronadjen na listi!");
                return;
            }

            trenutnaPotraznja -= uredjaj.PotrosnjaEnergije;
            uredjaj.Iskljuci();

            Console.WriteLine("Uredjaj je iskljucen i potraznja je: " + trenutnaPotraznja + " kWh.");
            //LogDogadjaja(ePotraznja, cenaPokWh);
        }

        public void Energija(int potraznja, out int primljenaEnergija, out int cenakWh)
        {
            // Send request for energy to distribution center and receive energy and price information
            primljenaEnergija = potraznja;
            cenakWh = 0; // placehoder value, replace with actual price received from distribution center

            Console.WriteLine("Primljeno " + primljenaEnergija + " kWh energije po ceni od " + cenakWh + " po kWh.");
            // LogDogadjaja(ePotraznja, cenaPokWh);
        }

        /* private static void LogDogadjaja(double ePotraznja, double cenaPokWh)
         {
             string logFilePath = "C:\\logs\\logDogadjaja.txt";

             if (!File.Exists(logFilePath))
             {
                 using (StreamWriter sw = File.CreateText(logFilePath))
                 {
                     sw.WriteLine("Energy demand logging started at " + DateTime.Now);
                 }
             }


             using (StreamWriter sw = File.AppendText(logFilePath))
             {
                 sw.WriteLine("Potraznja energije: " + potraznja + " kWh");
                 sw.WriteLine("Cena po kWh: " + cenakWh + " EUR");
             }
         }*/
    }
}

