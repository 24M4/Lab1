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

namespace FFS
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


        private double CalculateFee(double weight1, double Distance)
        {
            double rate = 0.0;

            if (weight1 <= 2)
            {
                rate = 1.10;
            }
            else if (weight1 <= 6)
            {
                rate = 2.20;
            }
            else if (weight1 <= 10)
            {
                rate = 3.70;
            }
            else
            {
                rate = 4.80;
            }

           
            double charges = rate * (Distance / 500);

            return charges;
        }
        private void Button_Click(object sender, RoutedEventArgs e)

        {
            double weight = double.Parse(weight1.Text);
            double distance = double.Parse(Distance.Text);


            double charges = CalculateFee(weight, double.Parse(Distance.Text));

            MessageBox.Show("The shipping fees are $" + charges);

            cost.Text = charges.ToString();
        }
    }
}





