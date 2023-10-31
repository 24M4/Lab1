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

namespace Population
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

        private void CalcDailyPopulation_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(PopulationInput.Text) <= 2 || double.Parse(avgDailyIncrease.Text) <= 0 || int.Parse(nbDaysMultiply.Text) <= 1)
            {
                MessageBox.Show("Invalid input!");
                return;
            }

            double population = double.Parse(PopulationInput.Text);


            for (int day = 2; day <= double.Parse(nbDaysMultiply.Text); day++)
            {
                population += population * (double.Parse(avgDailyIncrease.Text) / 100);
                MessageBox.Show("Day " + day + ": " + population);

            }

        }

    }
    public class PopulationCalc
    {
        private int PopulationInput;
        private double avgDailyIncrease;
        private int nbDaysMultiply;

        public PopulationCalc(int PopulationInput, double avgDailyIncrease, int nbDaysMultiply)
        {
            this.PopulationInput = PopulationInput;
            this.avgDailyIncrease = avgDailyIncrease;
            this.nbDaysMultiply = nbDaysMultiply;
        }
   
    }
}

