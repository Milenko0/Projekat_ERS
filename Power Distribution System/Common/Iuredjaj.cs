using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface Iuredjaj
    {
        string Naziv { get; set; }
        int PotrosnjaEnergije { get; set; }
        bool Ukljucen { get; set; }
        void Ukljuci();
        void Iskljuci();
    }
}
