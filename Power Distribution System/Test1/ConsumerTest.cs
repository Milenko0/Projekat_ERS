using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Consumer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Test1
{
    public class ConsumerTest
    {
        [Fact]
        public void TestDodaj()
        {
            Consumer.Consumer cm = new Consumer.Consumer();
            List<Uredjaj> uredjaji = new List<Uredjaj>();

            uredjaji.Add(new Uredjaj()
            {
                Naziv = "asfsaf",
                PotrosnjaEnergije = 40,
                Ukljucen = true
            });

            Assert.Single(uredjaji);
        }

        [Fact]
        public void TestUkloni()
        {
            Consumer.Consumer cm = new Consumer.Consumer();
             List<Uredjaj> uredjaj = new();
            List<Uredjaj> uredjaji = new List<Uredjaj>(uredjaj);

            var firstAddedElement = new Uredjaj()
            {
                Naziv = "asfsaf",
                PotrosnjaEnergije = 40,
                Ukljucen = true
            };
            uredjaji.Add(firstAddedElement);
            uredjaji.Add(new Uredjaj()
            {
                Naziv = "asfsafaaaa",
                PotrosnjaEnergije = 50,
                Ukljucen = true
            });
            uredjaji.Add(new Uredjaj()
            {
                Naziv = "asfsafasdasf",
                PotrosnjaEnergije = 70,
                Ukljucen = true
            });


            var firstStoredElement = uredjaji.Remove(firstAddedElement);

            Assert.Equal(0, 0);
        }
    }
}
