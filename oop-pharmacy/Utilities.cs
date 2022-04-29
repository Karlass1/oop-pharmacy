using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_pharmacy
{
    public static class Utilities
    {
        public static List<Medication> ImportData(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<Medication>().ToList();

            }
        }
        public static void ExportData(string path, IEnumerable<Medication> collection)
        {

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(collection);
            }

        }
    }
}
