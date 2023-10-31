using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ChooseProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (bankCheckBox.IsChecked == true)
            {
                Process.Start("C:\\Users\\Almir\\source\\repos\\ChooseProgram\\MainWindow.xaml");
            }
            else if (ShippingCheckBox.IsChecked == true)
            {
                Process.Start("C:\\Users\\Almir\\source\\repos\\FFS\\MainWindow.xaml");
            }
            else if (PopulationCheckBox.IsChecked == true)
            {
                Process.Start("C:\\Users\\Almir\\source\\repos\\Population.sln");
            }
            else
            {
                MessageBox.Show("Please select a program to execute.");
            }

            
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (bankCheckBox.IsChecked == true)
            {
                Process.Start("C:\\Users\\Almir\\source\\repos\\ChooseProgram\\MainWindow.xaml");
            }
            else if (ShippingCheckBox.IsChecked == true)
            {
                Process.Start("C:\\Users\\Almir\\source\\repos\\FFS\\MainWindow.xaml");
            }
            else if (PopulationCheckBox.IsChecked == true)
            {
                
            }
            else
            {
                MessageBox.Show("Please select a program to execute.");
            }
        }
    }
}