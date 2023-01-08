using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Solar_Panels_and_Wind_Generators;

namespace Test
{
    [TestFixture]
    public class SolarPanelsandWindGeneratorsTest
    {
        [Test]
        public void TestJacinaSunca()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.JacinaSunca = 90;

            Assert.AreEqual(solar.JacinaSunca, 90);
        }

        [Test]
        public void TestJacinaSuncaNotValid()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.JacinaSunca = 90;

            Assert.AreNotEqual(solar.JacinaSunca, 91);
        }

        [Test]
        public void TestJacinaVetra()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.JacinaVetra = 80;

            Assert.AreEqual(solar.JacinaVetra, 80);
        }

        [Test]
        public void TestJacinaVetraNotValid()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.JacinaVetra = 80;

            Assert.AreNotEqual(solar.JacinaVetra, 82);
        }

        [Test]
        public void TestBrojPanela()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.BrojPanela = 5;

            Assert.AreEqual(solar.BrojPanela, 5);
        }

        [Test]
        public void TestBrojPanelaNotValid()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.BrojPanela = 5;

            Assert.AreNotEqual(solar.BrojPanela, 2);
        }

        [Test]
        public void TestBrojTurbina()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.BrojTurbina = 4;

            Assert.AreEqual(solar.BrojTurbina, 4);
        }

        [Test]
        public void TestBrojTurbinaNotValid()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.BrojTurbina = 4;

            Assert.AreNotEqual(solar.BrojTurbina, 6);
        }

        [Test]
        public void TestProizvodnjaPanela()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.JacinaSunca = 90;

            Assert.AreEqual(solar.ProizvodnjaPanela, 9000);
        }


        [Test]
        public void TestProizvodnjaTurbina()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.JacinaVetra = 80;

            Assert.AreEqual(solar.ProizvodnjaTurbina, 8000);
        }


        [Test]
        public void TestProizvodnjaPanelaNotValid()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.JacinaSunca = 90;

            Assert.AreNotEqual(solar.ProizvodnjaPanela, 6);
        }


        [Test]
        public void TestProizvodnjaTurbinaNotValid()
        {
            Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators solar = new Solar_Panels_and_Wind_Generators.Solar_Panels_and_Wind_Generators();
            solar.JacinaVetra = 80;

            Assert.AreNotEqual(solar.ProizvodnjaTurbina, 6);
        }
    }
}
