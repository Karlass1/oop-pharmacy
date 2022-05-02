using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace oop_pharmacy
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ViewModel SharedModel { get; protected set; }

        public MainWindow()
        {
            InitializeComponent();
            ComboDose.ItemsSource = Enum.GetValues(typeof(Medication.MedDoseType));
            ComboPacking.ItemsSource = Enum.GetValues(typeof(Medication.MedPackingType));
            SharedModel = new ViewModel();
            this.DataContext = SharedModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CreateMedWindow createWin = new CreateMedWindow();
            createWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            createWin.Show();
        }

    }
}
