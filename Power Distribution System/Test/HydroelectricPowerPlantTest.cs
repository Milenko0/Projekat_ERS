using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Hydroelectric_Power_Plant;

namespace Test
{
    [TestFixture]
    public class HydroelectricPowerPlantTest
    {
        [Test]
         public void TestUpotrebaHidroelektrane()
        {
            Hydroelectric_Power_Plant.Hydroelectric_Power_Plant hydro_el = new Hydroelectric_Power_Plant.Hydroelectric_Power_Plant();
            hydro_el.UpotrebaHidroelektrane = 10;

            Assert.AreEqual(hydro_el.UpotrebaHidroelektrane, 10);
        }

        [Test]
        public void TestUpotrebaHidroelektraneNotValid()
        {
            Hydroelectric_Power_Plant.Hydroelectric_Power_Plant hydro_el = new Hydroelectric_Power_Plant.Hydroelectric_Power_Plant();
            hydro_el.UpotrebaHidroelektrane = 10;

            Assert.AreNotEqual(hydro_el.UpotrebaHidroelektrane, 15);
        }
    }
}
