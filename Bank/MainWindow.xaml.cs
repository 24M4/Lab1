using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

namespace Bank
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


        static SqlConnection con; // It is the connection adapter
        static SqlCommand cmd;  // It is the query proceeding adapter



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=MSI;Initial Catalog=master;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            MessageBox.Show("Connection Established");
            con.Close();
        }



        private void save_Input_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // step 1; Is to open the connection
                con.Open();

                // step 2; generate the database query
                string Query = "Insert into bankInfo values (@Balance, @Checks, @Fee)";

                // step 3; Create the command for Database
                cmd = new SqlCommand(Query, con);

                // step 4; Assign valeus to the query valuables
                cmd.Parameters.AddWithValue("@Balance", decimal.Parse(endingBalance.Text));
                cmd.Parameters.AddWithValue("@Checks", int.Parse(numChecks.Text));
                cmd.Parameters.AddWithValue("@Fee", decimal.Parse(Fee.Text));

                // step 5; Execute the Command/Query
                cmd.ExecuteNonQuery();

                // Step 6; Successful Message
                MessageBox.Show("Information has been saved");

                //Step 7; Close the connection
                con.Close();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void show_Input_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // Step 1: Open the connection
                con.Open();

                // Step 2; Create the select Query
                string Query = "Select * from bankInfo";

                // Step 3; Create the command to excecute
                cmd = new SqlCommand(Query, con);

                // Step 4; Prepare the data for datagrid
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Step 5; Update the dataGrid itemSource
                dbGrid.ItemsSource = dt.AsDataView();

                // Step 6; Bind the data inthe wpf frontend
                DataContext = da;

                // Step 7; Close the connection
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calculateFee1()
        {

            // double endingBalance

            double serviceFees = 10; // Base monthly charge

            if (double.Parse(endingBalance.Text) < 400)
            {
                serviceFees += 15; // Extra charge if balance falls below $400
            }

            if (int.Parse(numChecks.Text) < 20)
            {
                serviceFees += int.Parse(numChecks.Text) * 0.10;
            }
            else if (int.Parse(numChecks.Text) >= 20 && int.Parse(numChecks.Text) < 40)
            {
                serviceFees += int.Parse(numChecks.Text) * 0.08;
            }
            else if (int.Parse(numChecks.Text) >= 40 && int.Parse(numChecks.Text) < 60)
            {
                serviceFees += int.Parse(numChecks.Text) * 0.06;
            }
            else
            {
                serviceFees += int.Parse(numChecks.Text) * 0.10;
            }

            {
                MessageBox.Show("The service fees are $ " + serviceFees.ToString());
            }

            Fee.Text = serviceFees.ToString();
            
        }

        private void calculateFee_Click(object sender, RoutedEventArgs e)
        {

            calculateFee1();

        }
    }
}

 
       
    

    

