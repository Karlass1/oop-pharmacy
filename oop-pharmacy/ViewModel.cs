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
using System.Windows;
using System.Windows.Input;

namespace oop_pharmacy
{
    public class ViewModel : ObservableObject
    {
        public IEnumerable<Medication> Array => _array;
        private ObservableCollection<Medication> _array = new ObservableCollection<Medication>();
        public ICommand ImportCommand { get; protected set; }
        public ICommand ExportCommand { get; protected set; }
        public ICommand ExportFilterCommand { get; protected set; }
        public ICommand AddCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        private string _FilterText = "";
        public string FilterText { get => _FilterText; set { _FilterText = value; GetFilterData(); } }

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
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "csv file (*.csv)|*.csv";
                openFileDialog1.ShowDialog();
                Pharmacy.GetPharmacy().MedList = Utilities.ImportData(openFileDialog1.FileName);
                _array = new ObservableCollection<Medication>(Pharmacy.GetPharmacy().MedList);
                OnPropertyChanged("Array");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ExportCSV()
        {

            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = "c:\\";
                saveFileDialog1.Filter = "csv file (*.csv)|*.csv";
                saveFileDialog1.ShowDialog();
                Utilities.ExportData(saveFileDialog1.FileName, Pharmacy.GetPharmacy().MedList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddMedication()
        {
            Guid Id = Guid.NewGuid();
            Medication newMed = new Medication(Id, Dose, Name, ActiveSubstance, ActiveSubstanceAmount, PackingAmount, Manufacturer, ExpirationDate, OverTheCounter, DoseType, PackingType);
            Pharmacy.GetPharmacy().MedList.Add(newMed);
            Dose = 0;
            Name = "";
            ActiveSubstance = "";
            ActiveSubstanceAmount = 0;
            PackingAmount = 0;
            Manufacturer = "";
            OverTheCounter = false;
            ExpirationDate = DateTime.Today;
            DoseType = Medication.MedDoseType.ml;
            PackingType = Medication.MedPackingType.ml;
            GetFilterData();

        }
        private void DeleteMedication(object o)
        {
            Pharmacy.GetPharmacy().MedList.Remove((Medication)o);
            GetFilterData();

        }
        private void GetFilterData()
        {
            if (FilterText == "")
            {
                _array = new ObservableCollection<Medication>(Pharmacy.GetPharmacy().MedList);
            }
            else
            {
                var filterList = Pharmacy.GetPharmacy().MedList;
                var filterList2 = filterList.Where(x => x.Name.Contains(FilterText) || x.Manufacturer.Contains(FilterText) || x.ActiveSubstance.Contains(FilterText)).ToArray();
                _array = new ObservableCollection<Medication>(filterList2);
            }
            OnPropertyChanged("Array");
        }
        private void ExportFilter()
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = "c:\\";
                saveFileDialog1.Filter = "csv file (*.csv)|*.csv";
                saveFileDialog1.ShowDialog();
                Utilities.ExportData(saveFileDialog1.FileName, _array);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public ViewModel()
        {
            ImportCommand = new RelayCommand(ImportCSV);

            ExportCommand = new RelayCommand(ExportCSV);

            AddCommand = new RelayCommand(AddMedication);

            DeleteCommand = new RelayCommand<object>(DeleteMedication);

            ExportFilterCommand = new RelayCommand(ExportFilter);
        }

    }
}
