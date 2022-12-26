using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer;

namespace Power_Distribution_System
{
    public class Program
    {
        static void Main()
        {
            Uredjaj uredjaj1 = new Uredjaj("Frizider", 1500);
            Uredjaj uredjaj2 = new Uredjaj("Racunar", 450);
            Uredjaj uredjaj3 = new Uredjaj("TV", 250);
            Uredjaj uredjaj4 = new Uredjaj("Lampa", 20);
            Consumer.Consumer korisnik = new Consumer.Consumer();
            korisnik.Dodaj(uredjaj1);
            korisnik.Dodaj(uredjaj2);
            korisnik.Dodaj(uredjaj3);
            korisnik.Dodaj(uredjaj4);
            
            Distribution_Center.Distribution_Center distributivni_Centar = new Distribution_Center.Distribution_Center();
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators paneliITurbine = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            {
                Console.WriteLine("Unesite vrednost snage sunca (u procentima 0-100%):");
                string a = Console.ReadLine();
                bool isParsable = Int32.TryParse(a, out int num);
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
                    Console.WriteLine("Could not be parsed.");
            }
            paneliITurbine.BrojPanela = 1;
            paneliITurbine.BrojTurbina = 1;
            distributivni_Centar.PrirodnaProizvodnja = paneliITurbine.BrojPanela * paneliITurbine.ProizvodnjaPanela + paneliITurbine.BrojTurbina * paneliITurbine.ProizvodnjaTurbina;
            
            Console.WriteLine("----------------Power Distribution System----------------");
            while (true)
            {
                
                Console.WriteLine("Lista uredjaja:");
                Console.WriteLine("1. " + uredjaj1.Naziv);
                Console.WriteLine("2. " + uredjaj2.Naziv);
                Console.WriteLine("3. " + uredjaj3.Naziv);
                Console.WriteLine("4. " + uredjaj4.Naziv);
                Console.Write("Odaberite zeljeni uredjaj: ");
                string odabrano = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("----------------Power Distribution System----------------");
                switch (odabrano)
                {
                    case "0":
                        return;
                    case "1":
                        korisnik.UkljuciUredjaj(uredjaj1);
                        distributivni_Centar.regulisiHidroelektranu(korisnik.trenutnaPotraznja);
                        break;
                    case "2":
                        korisnik.UkljuciUredjaj(uredjaj2);
                        distributivni_Centar.regulisiHidroelektranu(korisnik.trenutnaPotraznja);
                        break;
                    case "3":
                        korisnik.UkljuciUredjaj(uredjaj3);
                        distributivni_Centar.regulisiHidroelektranu(korisnik.trenutnaPotraznja);
                        break;
                    case "4":
                        korisnik.UkljuciUredjaj(uredjaj4);
                        distributivni_Centar.regulisiHidroelektranu(korisnik.trenutnaPotraznja);
                        break;
                    default:
                        Console.WriteLine("Nista od ponudjenog nije izabrano");
                        break;
                }
            }       
        }
    }
}
