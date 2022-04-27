using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics;

namespace oop_pharmacy
{
    public class Pharmacy
    {
        static Pharmacy pharmacy;

        public static Pharmacy GetPharmacy() //singleton
        {
            if (pharmacy == null)
            {
                return pharmacy = new Pharmacy();
            }
            return pharmacy;
        }

        public readonly List<Medication> MedList = new List<Medication>();

        public void ImportData(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Medication>();
                foreach (var item in records)
                {
                    MedList.Add(item);
                }
            }

        }
        public void ExportData(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(MedList);
            }
        }


        public void FilterData(string filterName)
        {
            var filteredData = MedList.Where(Medication => Medication.Name.ToLower().Contains("filterName"));
            //dgMedication.ItemsSource = null;
            //dgMedication.ItemsSource = filteredData.ToList();

        }
    }
}
