using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Consumer;

namespace Test
{
    [TestFixture]
    public class UredjajTest
    {

        [Test]
        public void TestNaziv()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.Naziv = "naziv";
            Assert.AreEqual(uredjaj.Naziv, "naziv");
        }

        [Test]
        public void TestNazivNotValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.Naziv = "naziv";
            Assert.AreNotEqual(uredjaj.Naziv, "naziv1");
        }

        [Test]
        public void TestPotrosnjaEnergije()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.PotrosnjaEnergije = 200;
            Assert.AreEqual(uredjaj.PotrosnjaEnergije, 200);
        }

        [Test]
        public void TestPotrosnjaEnergijeNotValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.PotrosnjaEnergije = 200;
            Assert.AreNotEqual(uredjaj.PotrosnjaEnergije, 20);
        }

        [Test]
        public void TestUkljucen()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.Ukljucen = true;
            Assert.AreEqual(uredjaj.Ukljucen, true);
        }

        [Test]
        public void TestUkljucenNotValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.Ukljucen = true;
            Assert.AreNotEqual(uredjaj.Ukljucen, false);
        }

        [Test]
        [TestCase("Racunar", "100")]
        [TestCase("Lampa", "20")]
        [TestCase("TV", "50")]
        public void TestUredjajKonstruktor(string naziv, int potrosnjaEnergije)
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj(naziv, potrosnjaEnergije);
            uredjaj.Ukljucen = true;

            Assert.AreEqual(uredjaj.Naziv, naziv);
            Assert.AreEqual(uredjaj.PotrosnjaEnergije, potrosnjaEnergije);
            Assert.AreEqual(uredjaj.Ukljucen, true);
        }

        [Test]
        [TestCase("", 100)]
        [TestCase("", 0)]
        public void TestUredjajKonstruktorNotValid(string naziv, int potrosnjaEnergije)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Consumer.Uredjaj uredjaj = new Consumer.Uredjaj(naziv, potrosnjaEnergije);
                });
        }

        [Test]
        [TestCase(null, 100)]
        public void TestUredjajKonstruktorNULLValue(string naziv, int potrosnjaEnergije)
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    Consumer.Uredjaj uredjaj = new Consumer.Uredjaj(naziv, potrosnjaEnergije);
                });
        }
     
        [Test]
        public void TestUkljuci()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.Ukljucen = true;

            Assert.AreEqual(uredjaj.Ukljucen, true);
        }

        [Test]
        public void TestUkljuciNotValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.Ukljucen = true;

            Assert.AreNotEqual(uredjaj.Ukljucen, false);
        }

        [Test]
        public void TestIskljuci()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.Ukljucen = false;

            Assert.AreEqual(uredjaj.Ukljucen, false);
        }

        [Test]
        public void TestIskljuciNotValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();
            uredjaj.Ukljucen = false;

            Assert.AreNotEqual(uredjaj.Ukljucen, true);
        }
    }
}
