using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_pharmacy
{
    public class Medication
    {

        public enum MedDoseType
        {
            ml,
            pcs
        }
        public enum MedPackingType
        {
            ml,
            pcs
        }

        [Index(9)]
        public MedDoseType DoseType { get; set; }

        [Index(10)]
        public MedPackingType PackingType { get; set; }

        [Index(0)]
        public int Id { get; set; }

        [Index(1)]
        public int Dose { get; set; }

        [Index(2)]
        public string Name { get; set; }

        [Index(3)]
        public string ActiveSubstance { get; set; }

        [Index(4)]
        public int ActiveSubstanceAmount { get; set; }

        [Index(5)]
        public int PackingAmount { get; set; }

        [Index(6)]
        public string Manufacturer { get; set; }

        [Index(7)]
        public DateTime ExpirationDate { get; set; }

        [Index(8)]
        public bool OverTheCounter { get; set; }

        public Medication(int id, int dose, string name, string activeSubstance,
            int activeSubstanceAmount, int packingAmount, string manufacturer,
            DateTime expirationDate, bool overTheCounter,
            MedDoseType doseType, MedPackingType packingType)
        {
            Id = id;
            Dose = dose;
            Name = name;
            ActiveSubstance = activeSubstance;
            ActiveSubstanceAmount = activeSubstanceAmount;
            PackingAmount = packingAmount;
            Manufacturer = manufacturer;
            ExpirationDate = expirationDate;
            OverTheCounter = overTheCounter;
            PackingType = packingType;
            DoseType = doseType;
        }
    }
}
