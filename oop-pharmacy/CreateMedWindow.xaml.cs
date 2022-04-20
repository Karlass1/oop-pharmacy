using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace oop_pharmacy
{
    /// <summary>
    /// Interakční logika pro CreateMedWindow.xaml
    /// </summary>
    public partial class CreateMedWindow : Window
    {
        public CreateMedWindow()
        {
            InitializeComponent();
            ComboDose.ItemsSource = Enum.GetValues(typeof(Medication.MedDoseType));
            ComboPacking.ItemsSource = Enum.GetValues(typeof(Medication.MedPackingType));
            this.DataContext = MainWindow.SharedModel;
        }

        private void CloseWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
