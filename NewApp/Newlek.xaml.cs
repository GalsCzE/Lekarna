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

        private static DatabazeLS _datals;
        public static DatabazeLS Datals
        {
            get
            {
                if (_datals == null)
                {
                    var fileHelper = new Helper();
                    _datals = new DatabazeLS(fileHelper.GetLocalFilePath("VazabaLSSQLite.db3"));
                }
                return _datals;
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

            int idvazba = itemle.ID;

            string value = m3.Text;
            string[] lines = Regex.Split(value, ",");

            foreach (string line in lines)
            {
                Slozky itemslozky = new Slozky();                
                itemslozky.slozenileku = line;
                Dataslozka.SaveItemAsync3(itemslozky);
                //long ID = Datals.GetLastID().Result;
                /*int idslozeni = itemslozky.ID;

                VazbaLS itemvazba = new VazbaLS();
                itemvazba.slozeniID = idslozeni;
                itemvazba.lekyID = idvazba;

                //MessageBox.Show(Convert.ToString(idvazba) + " " + " LEK");

               // MessageBox.Show(Convert.ToString(idslozeni) + " " + " SLOŽENÍ");
                Datals.SaveItemAsync4(itemvazba);*/
                //MessageBox.Show(line);
            }

            page1.Navigate(new ofiko(iteml));
        }
    }
}
