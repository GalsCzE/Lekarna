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

namespace NewApp
{
    /// <summary>
    /// Interaction logic for EditL.xaml
    /// </summary>
    public partial class EditL : Page
    {
        ObservableCollection<Leky> itemsFromDbs;
        Leky iteml = new Leky();
        int idl;
        Frame page1;

        public EditL(Leky le, Frame pq)
        {
            InitializeComponent();
            idl = le.ID;
            iteml = le;
            page1 = pq;
            h1.Text = iteml.nazev;
            h2.Text = iteml.firma;
            h3.Text = iteml.slozeni;
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

        private void editle_Click(object sender, RoutedEventArgs e)
        {
            itemsFromDbs = new ObservableCollection<Leky>(Datal.GetItemsAsync2().Result);
            Leky lekyqw = new Leky();
            lekyqw.ID = idl;
            lekyqw.nazev = h1.Text;
            lekyqw.firma = h2.Text;
            lekyqw.slozeni = h3.Text;

            Datal.SaveItemAsync2(lekyqw);
            page1.Navigate(new ofiko(iteml));
        }

        private void deletele_Click(object sender, RoutedEventArgs e)
        {
            Datal.DeleteItemAsync2(idl);
            page1.Navigate(new ofiko(iteml));
        }

        private void bacle_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new ofiko(iteml));
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
    }
}
