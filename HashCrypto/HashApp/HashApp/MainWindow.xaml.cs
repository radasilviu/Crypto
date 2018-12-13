using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace HashApp
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

        //citire
        string source="";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Scrie.Text = "";
            Citeste.Text = "";

            try
            {

                StreamReader sr = new StreamReader(@"../../TextFile1.txt");

                string rl;
                while ((rl = sr.ReadLine()) != null)
                {
                    String line = rl;
                    Citeste.Text += line + "\n";
                }
                source = Citeste.Text;
            }
            catch (Exception exc)
            {
                Citeste.Text = ("The file could not be read");
                Citeste.Text = (exc.Message);
            }
        }
        //afisare
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = await Task.Run(() => CalculateHash());
            Scrie.Text = "Hash result is : " + str;
        }


        private string CalculateHash()
        {
            string hashResult = "";
            try
            {
                using (HashAlgorithm algHash = HashAlgorithm.Create(algoritm))
                {
                    hashResult = GetHashAlgo(algHash, source);
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Must choose a Hash algotihm");

            }
            return hashResult;


        }

        private string GetHashAlgo(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        string algoritm;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            algoritm = (string)((ComboBoxItem)((ComboBox)sender).SelectedValue).Content;

        }
    }
}
