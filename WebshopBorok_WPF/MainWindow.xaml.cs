using System;
using System.Collections.Generic;
using System.IO;
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
using WebshopBorok_WPF;


namespace WebshopBorok_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<WebshopBorok_WPF.MainWindow> adatok;
        
        public MainWindow()
        {
            InitializeComponent();
            Borok_adatok.ItemsSource = adatok;
        }

        private void BTN_Hozzaad_Click(object sender, RoutedEventArgs e)
        {
            //List<Borok> borok = new List<Borok>();
            Borok_adatok.Items.Add(Borok_adatok.SelectedValue);
        }

        private void BTN_Modosit_Click(object sender, RoutedEventArgs e)
        {
            Borok_adatok.Items.Clear();
            Borok_adatok.Items.Add(Borok_adatok.SelectedValue);
            
        }

        private void BTN_Torol_Click(object sender, RoutedEventArgs e)
        {
            adatok.RemoveAt(Borok_adatok.SelectedIndex);
            Borok_adatok.Items.Refresh();
        }

        private void BTN_Mentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter writer = new StreamWriter("borok.txt");
            foreach (Borok_adatok boradatok in adatok)
            {
                writer.WriteLine($"{boradatok.neve} {boradatok.evjarat} {boradatok.urtarltalom_liter} {boradatok.fajta}");
            }
            writer.Close();
            MessageBox.Show("Sikeres mentés!");
        }

    }
}
