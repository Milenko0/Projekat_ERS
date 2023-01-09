using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Style;
using OfficeOpenXml;

namespace Distribution_Center
{
    public class Distribution_Center
    {
        public Hydroelectric_Power_Plant.Hydroelectric_Power_Plant hidroelektrana = new Hydroelectric_Power_Plant.Hydroelectric_Power_Plant();

        static private int maksimalnaProizvodnjaHidroelektrane = 50000;
        private List<Hidro_Model> output;
        public int PrirodnaProizvodnja { get; set; }
        public Distribution_Center()
        {
            PrirodnaProizvodnja = 0;
            output = new List<Hidro_Model>();
        }

        public void regulisiHidroelektranu(int potraznja) {
            if(PrirodnaProizvodnja > potraznja)
            {
                hidroelektrana.UpotrebaHidroelektrane = 0;
                Console.WriteLine("Nije potrebna upotreba hidroelektrane.");
                dodajNaListu(hidroelektrana.UpotrebaHidroelektrane);
                LogRegulacijeHidroElektrane(hidroelektrana.UpotrebaHidroelektrane);
            }
            else if(potraznja - PrirodnaProizvodnja > maksimalnaProizvodnjaHidroelektrane * hidroelektrana.UpotrebaHidroelektrane / 100)
            {
                hidroelektrana.UpotrebaHidroelektrane = (potraznja - PrirodnaProizvodnja) / (maksimalnaProizvodnjaHidroelektrane / 100);
                Console.WriteLine("Potrebno je povecati nivo proizvodnje hidroelektrane.");
                Console.WriteLine("Novi nivo upotrebljenosti hidroelektrane je " + hidroelektrana.UpotrebaHidroelektrane + "%.");
                dodajNaListu(hidroelektrana.UpotrebaHidroelektrane);
                LogRegulacijeHidroElektrane(hidroelektrana.UpotrebaHidroelektrane);
            }
            else if (potraznja - PrirodnaProizvodnja < maksimalnaProizvodnjaHidroelektrane * hidroelektrana.UpotrebaHidroelektrane / 100)
            {
                hidroelektrana.UpotrebaHidroelektrane = (potraznja - PrirodnaProizvodnja) / (maksimalnaProizvodnjaHidroelektrane / 100);
                Console.WriteLine("Potrebno je smanjiti nivo proizvodnje hidroelektrane.");
                Console.WriteLine("Novi nivo upotrebljenosti hidroelektrane je " + hidroelektrana.UpotrebaHidroelektrane + "%.");
                dodajNaListu(hidroelektrana.UpotrebaHidroelektrane);
                LogRegulacijeHidroElektrane(hidroelektrana.UpotrebaHidroelektrane);
            }
            else
            {
                Console.WriteLine("Nije potrebno menjati nivo proizvodnje hidroelektrane.");
                Console.WriteLine("Nivo upotrebljenosti hidroelektrane je " + hidroelektrana.UpotrebaHidroelektrane + "%.");
                dodajNaListu(hidroelektrana.UpotrebaHidroelektrane);
                LogRegulacijeHidroElektrane(hidroelektrana.UpotrebaHidroelektrane);
            }
        }

        private static void LogRegulacijeHidroElektrane(int upotreba)
        {
            string logFilePath = System.IO.Directory.GetCurrentDirectory() + "\\LogRegulacijeHidroElektrane.txt";

            if (!File.Exists(logFilePath))
            {
                using (StreamWriter sw = File.CreateText(logFilePath))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("Nivo upotrebljenosti hidroelektrane je " + upotreba + "%.");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("Nivo upotrebljenosti hidroelektrane je " + upotreba + "%.");
                }
            }
        }

        public double izracunajCenu(int potraznja) 
        {
            double cenaPoKWh;
            if (potraznja < 0)
            {
                throw new ArgumentException("Ne sme biti negativan broj!");
            }

            if (potraznja <= 350)
            {
              cenaPoKWh = 6.034;
            }
            else
            if (potraznja >= 351 && potraznja <= 1600)
            {
                cenaPoKWh = 9.051;
            }
            else cenaPoKWh = 18.102;
            return cenaPoKWh;
        }

        private void dodajNaListu(int upotreba)
        {
            Hidro_Model model = new Hidro_Model();
            model.time = DateTime.Now;
            model.Iskorscenost = upotreba;
            output.Add(model);
        }

        public void saveToExcel()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {

                var workSheet = excel.Workbook.Worksheets.Add("HidroElektrana");

                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                // Zaglavnje
                workSheet.Cells[1, 1].Value = "No.";
                workSheet.Cells[1, 2].Value = "Time";
                workSheet.Cells[1, 3].Value = "Use in %";
              
                int index = 2;

                foreach (var hidro_Model in output)
                {
                    workSheet.Cells[index, 1].Value = (index - 1).ToString();
                    workSheet.Cells[index, 2].Value = hidro_Model.time.ToString();
                    workSheet.Cells[index, 3].Value = hidro_Model.Iskorscenost;
                    index++;
                }

                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
                workSheet.Column(3).AutoFit();

                string filePath = System.IO.Directory.GetCurrentDirectory() + "\\hidro.xlsx";

                if (File.Exists(filePath))
                    File.Delete(filePath);

                FileStream objFileStrm = File.Create(filePath);
                objFileStrm.Close();

                File.WriteAllBytes(filePath, excel.GetAsByteArray());
            }
        }
    }
}
