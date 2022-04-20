using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace oop_pharmacy
{
    public class ViewModel : ObservableObject
    {
        public IEnumerable<Medication> Array => _array;
        private ObservableCollection<Medication> _array = new ObservableCollection<Medication>();
        public ICommand ImportCommand { get; protected set; }
        public ICommand ExportCommand { get; protected set; }
        public ICommand AddCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        public Medication.MedDoseType DoseType { get; set; }

        public Medication.MedPackingType PackingType { get; set; }

        public int Dose { get; set; }

        public string Name { get; set; }

        public string ActiveSubstance { get; set; }

        public int ActiveSubstanceAmount { get; set; }

        public int PackingAmount { get; set; }

        public string Manufacturer { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool OverTheCounter { get; set; }

        private void ImportCSV()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "csv file (*.csv)|*.csv";
            openFileDialog1.ShowDialog();
            Pharmacy.GetPharmacy().ImportData(openFileDialog1.FileName);
            _array = new ObservableCollection<Medication>(Pharmacy.GetPharmacy().MedList);
            OnPropertyChanged("Array");
        }
        private void ExportCSV()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "csv file (*.csv)|*.csv";
            saveFileDialog1.ShowDialog();
            Pharmacy.GetPharmacy().ExportData(saveFileDialog1.FileName);
        }
        private void AddMedication()
        {
            Guid Id = Guid.NewGuid();
            Medication newMed = new Medication(Id, Dose, Name, ActiveSubstance, ActiveSubstanceAmount, PackingAmount, Manufacturer, ExpirationDate, OverTheCounter, DoseType, PackingType);
            Pharmacy.GetPharmacy().MedList.Add(newMed);
            _array = new ObservableCollection<Medication>(Pharmacy.GetPharmacy().MedList);
            OnPropertyChanged("Array");

        }
        private void DeleteMedication(object o)
        {
            Pharmacy.GetPharmacy().MedList.Remove((Medication)o);
            _array = new ObservableCollection<Medication>(Pharmacy.GetPharmacy().MedList);
            OnPropertyChanged("Array");
        }
        public ViewModel()
        {
            ImportCommand = new RelayCommand(ImportCSV);

            ExportCommand = new RelayCommand(ExportCSV);

            AddCommand = new RelayCommand(AddMedication);

            DeleteCommand = new RelayCommand<object>(DeleteMedication);
        }
        
    }
}
