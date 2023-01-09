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

        public Uredjaj()
        {
        }

         public Uredjaj(string naziv, int potrosnjaEnergije)
        {
            if (naziv == null)
            {
                throw new ArgumentNullException("Ne sme biti null!");
            }
            if (naziv.Trim() == "")
            {
                throw new ArgumentException("Naziv mora sadrzati karaktere!");
            }
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
