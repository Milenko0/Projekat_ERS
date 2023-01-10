using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer;
using Distribution_Center;
using OfficeOpenXml;

namespace Power_Distribution_System
{
    public class Program
    {
        static void Main()
        {
            ciscenjeLogova();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Uredjaj uredjaj1 = new Uredjaj("Elektricni Motor", 1500);
            Uredjaj uredjaj2 = new Uredjaj("Racunar", 100);
            Uredjaj uredjaj3 = new Uredjaj("TV", 50);
            Uredjaj uredjaj4 = new Uredjaj("Lampa", 20);
            Consumer.Consumer korisnik = new Consumer.Consumer();
            korisnik.Dodaj(uredjaj1);
            korisnik.Dodaj(uredjaj2);
            korisnik.Dodaj(uredjaj3);
            korisnik.Dodaj(uredjaj4);
            
            Distribution_Center.Distribution_Center distributivni_Centar = new Distribution_Center.Distribution_Center();
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators paneliITurbine = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
           {
                Console.WriteLine("Unesite broj solarnih panela koji su ukljuceni u sistem:");
                string a = Console.ReadLine();
                bool isParsable = Int32.TryParse(a, out int num);
                if (isParsable)
                    paneliITurbine.BrojPanela = num;
                else
                    Console.WriteLine("Could not be parsed.");

                Console.WriteLine("Unesite broj vetrogeneratora koji su ukljuceni u sistem:");
                a = Console.ReadLine();
                isParsable = Int32.TryParse(a, out num);
                if (isParsable)
                    paneliITurbine.BrojTurbina = num;
                else
                    Console.WriteLine("Could not be parsed.");

                /*Console.WriteLine("Unesite vrednost snage sunca (u procentima 0-100%):");
                a = Console.ReadLine();
                isParsable = Int32.TryParse(a, out num);
                if (isParsable)
                    paneliITurbine.JacinaSunca = num;
                else
                    Console.WriteLine("Could not be parsed.");

                Console.WriteLine("Unesite vrednost snage vetra (u procentima 0-100%):");
                a = Console.ReadLine();
                isParsable = Int32.TryParse(a, out num);
                if (isParsable)
                    paneliITurbine.JacinaVetra = num;
                else
                    Console.WriteLine("Could not be parsed.");*/
                paneliITurbine.generisiJacinuSunca();
                paneliITurbine.generisiJacinuVetra();
                //Console.WriteLine("Solarni paneli rade na " + paneliITurbine.JacinaSunca + "% svog maksimalnog potencijala.");
                //Console.WriteLine("Vetrogeneratori rade na " + paneliITurbine.JacinaVetra + "% svog maksimalnog potencijala.");
            }
            distributivni_Centar.PrirodnaProizvodnja = paneliITurbine.BrojPanela * paneliITurbine.ProizvodnjaPanela + paneliITurbine.BrojTurbina * paneliITurbine.ProizvodnjaTurbina;
            
            Console.WriteLine("----------------Power Distribution System----------------");
            while (true)
            {
                distributivni_Centar.PrirodnaProizvodnja = paneliITurbine.BrojPanela * paneliITurbine.ProizvodnjaPanela + paneliITurbine.BrojTurbina * paneliITurbine.ProizvodnjaTurbina;
                
                Console.WriteLine("Lista uredjaja:");
                
                Console.WriteLine("1. " + uredjaj1.Naziv);
                Console.WriteLine("2. " + uredjaj2.Naziv);
                Console.WriteLine("3. " + uredjaj3.Naziv);
                Console.WriteLine("4. " + uredjaj4.Naziv);
                Console.WriteLine("----------------------");
                Console.WriteLine("0. Izdji i sacuvaj");
                Console.Write("Odaberite zeljeni uredjaj: ");
                string odabrano = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("----------------Power Distribution System----------------");
                switch (odabrano)
                {
                    case "0":
                        distributivni_Centar.saveToExcel();
                        paneliITurbine.saveToExcel();
                        return;
                    case "1":
                        korisnik.UkljuciUredjaj(uredjaj1);
                        distributivni_Centar.regulisiHidroelektranu(korisnik.trenutnaPotraznja);
                        korisnik.Energija(distributivni_Centar.izracunajCenu(korisnik.trenutnaPotraznja));
                        distributivni_Centar.posaljiRacun(korisnik.trenutnaPotraznja, distributivni_Centar.izracunajCenu(korisnik.trenutnaPotraznja));
                        break;
                    case "2":
                        korisnik.UkljuciUredjaj(uredjaj2);
                        distributivni_Centar.regulisiHidroelektranu(korisnik.trenutnaPotraznja);
                        korisnik.Energija(distributivni_Centar.izracunajCenu(korisnik.trenutnaPotraznja));
                        distributivni_Centar.posaljiRacun(korisnik.trenutnaPotraznja, distributivni_Centar.izracunajCenu(korisnik.trenutnaPotraznja));
                        break;
                    case "3":
                        korisnik.UkljuciUredjaj(uredjaj3);
                        distributivni_Centar.regulisiHidroelektranu(korisnik.trenutnaPotraznja);
                        korisnik.Energija(distributivni_Centar.izracunajCenu(korisnik.trenutnaPotraznja));
                        distributivni_Centar.posaljiRacun(korisnik.trenutnaPotraznja, distributivni_Centar.izracunajCenu(korisnik.trenutnaPotraznja));
                        break;
                    case "4":
                        korisnik.UkljuciUredjaj(uredjaj4);
                        distributivni_Centar.regulisiHidroelektranu(korisnik.trenutnaPotraznja);
                        korisnik.Energija(distributivni_Centar.izracunajCenu(korisnik.trenutnaPotraznja));
                        distributivni_Centar.posaljiRacun(korisnik.trenutnaPotraznja, distributivni_Centar.izracunajCenu(korisnik.trenutnaPotraznja));
                        break;
                    default:
                        Console.WriteLine("Nista od ponudjenog nije izabrano");
                        break;
                }
            }
        }

        private static void ciscenjeLogova() 
        {
            string log1 = System.IO.Directory.GetCurrentDirectory() + "\\logDogadjaja.txt";
            string log2 = System.IO.Directory.GetCurrentDirectory() + "\\LogRegulacijeHidroElektrane.txt";
            if (File.Exists(log1))
                File.Delete(log1);
            if (File.Exists(log2))
                File.Delete(log2);
        }
    }
}
