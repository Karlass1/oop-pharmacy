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
        }

        private void CloseWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == tb.Tag.ToString())
            {
                tb.Foreground = Brushes.LightGray;
            }
            else
            {
                tb.Foreground = Brushes.Black;
            }            
        }
    }
}
