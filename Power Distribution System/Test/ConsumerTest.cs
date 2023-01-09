using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class ConsumerTest
    {
        [Test]
        [TestCase("Lampa")]
        public void TestDodaj(string naziv)
        {
            Consumer.Consumer cm = new Consumer.Consumer();
            List<Uredjaj> uredjaji = new List<Uredjaj>();

            uredjaji.Add(new Uredjaj()
            {
                Naziv = "Lampa",
                PotrosnjaEnergije = 40,
                Ukljucen = true
            });

            Assert.AreEqual(uredjaji[0].Naziv, naziv);
        }

        [Test]
        [TestCase("Lampa")]
        public void TestUkloni(string naziv)
        {
            Consumer.Consumer cm = new Consumer.Consumer();
            List<Uredjaj> uredjaji = new List<Uredjaj>();

            uredjaji.Add(new Uredjaj()
            {
                Naziv = "Lampa",
                PotrosnjaEnergije = 40,
                Ukljucen = true
            });

            uredjaji.Remove(uredjaji[0]);

            Assert.IsEmpty(uredjaji);
        }
    }
}
