using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_pharmacy
{
    public class ViewModel : ObservableObject
    {
        public IEnumerable<Medication> Array => Pharmacy.GetPharmacy().MedList;
        public ViewModel()
        {
            Pharmacy.GetPharmacy().MedList.Add(new Medication(15, "aa", "bb", 15, 15, "ab", new DateTime(2005,6,7), true, Medication.MedDoseType.ml, Medication.MedPackingType.pcs));
        }
        
    }
}
