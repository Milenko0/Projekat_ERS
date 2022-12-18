using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Power_Distribution_System.Device;

namespace Power_Distribution_System
{
    internal class Program
    {
        static void Main()
        {
            Device uredjaj1 = new Device("Frizider", 1500);
            Device uredjaj2 = new Device("Fen", 500);
            Device uredjaj3 = new Device("Racunar", 430);
            Device uredjaj4 = new Device("TV", 200);
            Console.WriteLine("----------------Power Distribution System----------------");
            Console.WriteLine("Odaberite zeljeni uredjaj:");
            Console.WriteLine("1." + uredjaj1.Name);
            Console.WriteLine("2." + uredjaj2.Name);
            Console.WriteLine("3." + uredjaj3.Name);
            Console.WriteLine("4." + uredjaj4.Name);
            Console.WriteLine("---------------------------------------------------------");
            Console.ReadLine();
        }
    }
}
