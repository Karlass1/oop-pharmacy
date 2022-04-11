using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ViewModel()
        {
            ImportCommand = new RelayCommand(ImportCSV);

            ExportCommand = new RelayCommand(ExportCSV);
        }
        
    }
}
