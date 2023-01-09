using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Solar_Panels_and_Wind_Generators
{
    public class Solar_Panels_and_Wind_Generators
    {
        private static int pocetnaProizvodnjaPanela = 10000;
        private static int pocetnaProizvodnjaTurbina = 10000;
        public int JacinaSunca { get; set; }
        public int JacinaVetra { get; set; }
        public int BrojPanela { get; set; }
        public int BrojTurbina { get; set; }
        private List<Solar_Wind_Model> output;

        public Solar_Panels_and_Wind_Generators()
        {
            JacinaSunca = 50;
            JacinaVetra = 50;
            BrojPanela = 0;
            BrojTurbina = 0;
            output = new List<Solar_Wind_Model>();
        }

        public int ProizvodnjaPanela
        {
            get
            {
                return pocetnaProizvodnjaPanela * JacinaSunca / 100;
            }

        }

        public int ProizvodnjaTurbina
        {
            get
            {
                return pocetnaProizvodnjaTurbina * JacinaVetra / 100;
            }

        }
        public void generisiJacinuSunca()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;

            void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                JacinaSunca = rand.Next(0, 100);
                dodajNaListu();
            }

        }
        public void generisiJacinuVetra()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 6000;
            aTimer.Enabled = true;

            void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                JacinaVetra = rand.Next(0, 100);
                dodajNaListu();
            }
        }
        private void dodajNaListu()
        {
            Solar_Wind_Model model = new Solar_Wind_Model();
            model.time = DateTime.Now;
            model.jacinaSunca = ProizvodnjaPanela;
            model.jacinaVetra = ProizvodnjaTurbina;
            output.Add(model);
        }

        public void saveToExcel()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {

                var workSheet = excel.Workbook.Worksheets.Add("Snaga Sunca i Vetra");

                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                // Zaglavnje
                workSheet.Cells[1, 1].Value = "No.";
                workSheet.Cells[1, 2].Value = "Time";
                workSheet.Cells[1, 3].Value = "snaga sunca";
                workSheet.Cells[1, 4].Value = "snaga vetra";

                int index = 2;

                foreach (var solar_Wind_Model in output)
                {
                    workSheet.Cells[index, 1].Value = (index - 1).ToString();
                    workSheet.Cells[index, 2].Value = solar_Wind_Model.time.ToString();
                    workSheet.Cells[index, 3].Value = solar_Wind_Model.jacinaSunca;
                    workSheet.Cells[index, 4].Value = solar_Wind_Model.jacinaVetra;
                    index++;
                }

                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
                workSheet.Column(3).AutoFit();
                workSheet.Column(4).AutoFit();

                string filePath = System.IO.Directory.GetCurrentDirectory() + "\\soalarwind.xlsx";

                if (File.Exists(filePath))
                    File.Delete(filePath);

                FileStream objFileStrm = File.Create(filePath);
                objFileStrm.Close();

                File.WriteAllBytes(filePath, excel.GetAsByteArray());
            }
        }
    }
}
