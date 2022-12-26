using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Consumer.Uredjaj;

namespace Consumer
{
    public class Consumer
    {
        private List<Uredjaj> uredjaji;
        public int trenutnaPotraznja;
        public double cenaZaKorisnika;

        public Consumer()
        {
            uredjaji = new List<Uredjaj>();
            trenutnaPotraznja = 0;
            cenaZaKorisnika= 0;
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
            LogDogadjaja(trenutnaPotraznja, cenaZaKorisnika);
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
            LogDogadjaja(trenutnaPotraznja, cenaZaKorisnika);
        }

        public void Energija(double cenakWh)
        {
            cenaZaKorisnika = cenakWh;
            Console.WriteLine("Trenutna cena po kWh:"  + cenakWh);
            LogDogadjaja(trenutnaPotraznja, cenakWh);
        }

        private static void LogDogadjaja(double ePotraznja, double cena)
        {
             string logFilePath = System.IO.Directory.GetCurrentDirectory() + "\\logDogadjaja.txt";

            if (!File.Exists(logFilePath))
            {
                using (StreamWriter sw = File.CreateText(logFilePath))
                {
                    sw.WriteLine("Energy demand logging started at " + DateTime.Now);
                }
            }
            else 
            {
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("Potraznja energije: " + ePotraznja + " kWh");
                    sw.WriteLine("Cena po kWh: " + cena + " RSD");
                }
            }         
        }
    }
}
