using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribution_Center;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class DistributionCenterTest
    {
        [Test]
        public void TestPrirodnaProizvodnja()
        {
            Distribution_Center.Distribution_Center dc = new Distribution_Center.Distribution_Center();
            dc.PrirodnaProizvodnja = 100;

            Assert.AreEqual(dc.PrirodnaProizvodnja, 100);
        }

        [Test]
        public void TestPrirodnaProizvodnjaNotValid()
        {
            Distribution_Center.Distribution_Center dc = new Distribution_Center.Distribution_Center();
            dc.PrirodnaProizvodnja = 100;

            Assert.AreNotEqual(dc.PrirodnaProizvodnja, 60);
        }

        [Test]
        [TestCase(23)]
        public void TestizracunajCenu(int potraznja)
        {
            Distribution_Center.Distribution_Center dc = new Distribution_Center.Distribution_Center();
            Assert.AreEqual(dc.izracunajCenu(potraznja), 6.034);
        }

        [Test]
        [TestCase(-23)]
        public void TestizracunajCenuNotValid(int potraznja)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Distribution_Center.Distribution_Center dc = new Distribution_Center.Distribution_Center();
                    dc.izracunajCenu(potraznja);
                });
        }

    }
}
