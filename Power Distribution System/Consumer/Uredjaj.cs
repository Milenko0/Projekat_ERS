using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Consumer
{
    public class Uredjaj : Iuredjaj
    {
        public string Naziv { get; set; }
        public int PotrosnjaEnergije { get; set; }
        public bool Ukljucen { get; set; }

        public Uredjaj(string naziv, int potrosnjaEnergije)
        {
            Naziv = naziv;
            PotrosnjaEnergije = potrosnjaEnergije;
            Ukljucen = false;
        }

        public void Ukljuci()
        {
            Ukljucen = true;
        }

        public void Iskljuci()
        {
            Ukljucen = false;
        }
    }
}
