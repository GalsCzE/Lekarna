using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using SQLite;

namespace NewApp
{
    /// <summary>
    /// Interaction logic for Newlek.xaml
    /// </summary>
    public partial class Newlek : Page
    {
        Leky iteml = new Leky();
        Frame page1;
        Slozky itemslozky = new Slozky();
        public Newlek(Leky l, Frame pl)
        {
            InitializeComponent();
            iteml = l;
            page1 = pl;
        }

        private static DatabazeL _datal;
        public static DatabazeL Datal
        {
            get
            {
                if (_datal == null)
                {
                    var fileHelper = new Helper();
                    _datal = new DatabazeL(fileHelper.GetLocalFilePath("LekySQLite.db3"));
                }
                return _datal;
            }
        }

        private static DatabazeS _dataslozka;
        public static DatabazeS Dataslozka
        {
            get
            {
                if (_dataslozka == null)
                {
                    var fileHelper = new Helper();
                    _dataslozka = new DatabazeS(fileHelper.GetLocalFilePath("SlozkySQLite.db3"));
                }
                return _dataslozka;
            }
        }

        private void pre(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void prf(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Ža-ž]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void bakl_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new ofiko(iteml));
        }

        private void newsl_Click(object sender, RoutedEventArgs e)
        {
            Leky itemle = new Leky();
            itemle.nazev = m1.Text;
            itemle.firma = m2.Text;
            Datal.SaveItemAsync2(itemle);

            string value = m3.Text;
            // Split the string on line breaks.
            // ... The return value from Split is a string array.
            string[] lines = Regex.Split(value, ",");

            foreach (string line in lines)
            {
                itemslozky.slozenileku = line;
                MessageBox.Show(line);
                Dataslozka.SaveItemAsync3(itemslozky);
            }
            page1.Navigate(new ofiko(iteml));
        }
    }
}
