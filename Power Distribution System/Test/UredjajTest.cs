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
            var uredjaj = new Uredjaj();
            uredjaj.Naziv = "naziv";
            Assert.AreEqual(uredjaj.Naziv, "naziv");
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
        public void TestUkljuciValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();

            Assert.AreEqual(uredjaj.Ukljucen, false);
        }

        [Test]
        public void TestUkljuciNotValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();

            Assert.AreNotEqual(uredjaj.Ukljucen, true);
        }

        [Test]
        public void TestIskljuciValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();

            Assert.AreEqual(uredjaj.Ukljucen, false);
        }

        [Test]
        public void TestIskljuciNotValid()
        {
            Consumer.Uredjaj uredjaj = new Consumer.Uredjaj();

            Assert.AreNotEqual(uredjaj.Ukljucen, true);
        }
    }
}
