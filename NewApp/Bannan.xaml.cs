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
    /// Interakční logika pro Bannan.xaml
    /// </summary>
    public partial class Bannan : Page
    {
        Zakaznik item = new Zakaznik();
        Frame page1;
        public Bannan(Zakaznik i, Frame pa)
        {
            InitializeComponent();
            item = i;
            page1 = pa;
        }

        private static DatabazeZ _data;
        public static DatabazeZ Data
        {
            get
            {
                if (_data == null)
                {
                    var fileHelper = new Helper();
                    _data = new DatabazeZ(fileHelper.GetLocalFilePath("ZakaznikSQLite.db3"));
                }
                return _data;
            }
        }

        private static DatabazeA _dataA;
        public static DatabazeA DataA
        {
            get
            {
                if (_dataA == null)
                {
                    var fileHelper = new Helper();
                    _dataA = new DatabazeA(fileHelper.GetLocalFilePath("AlergenySQLite.db3"));
                }
                return _dataA;
            }
        }

        private static DatabazeZA _dataZA;
        public static DatabazeZA DataZA
        {
            get
            {
                if (_dataZA == null)
                {
                    var fileHelper = new Helper();
                    _dataZA = new DatabazeZA(fileHelper.GetLocalFilePath("VazabaZASQLite.db3"));
                }
                return _dataZA;
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

        private void bak_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new ofiko(item));
        }

        private void news_Click(object sender, RoutedEventArgs e)
        {
            Zakaznik iteme = new Zakaznik();
            iteme.jmeno = t1.Text;
            iteme.prijmeni = t2.Text;
            if (t5.Text != "" || t7.Text != "" || t8.Text != "")
            {
                iteme.heslo = t5.Text;
                iteme.login = t7.Text;
                iteme.opravneni = t8.Text;
                if (male.IsSelected)
                {
                    iteme.pohlavi = 1;

                }
                else
                if (female.IsSelected)
                {
                    iteme.pohlavi = 2;
                }

                int idzaka = iteme.ID;

                Data.SaveItemAsync(iteme);
                page1.Navigate(new ofiko(item));

                /*string value = t3.Text;
                string[] lines = Regex.Split(value, ",");

                foreach (string line in lines)
                {
                    Alergeny itemalergeny = new Alergeny();
                    itemalergeny.alergen = line;
                    DataA.SaveItemAsync5(itemalergeny);
                    //long ID = Datals.GetLastID().Result;
                    /*int idaler = itemalergeny.ID;

                    VazabaZA itemvazbaza = new VazabaZA();
                    itemvazbaza.alergieID = idaler;
                    itemvazbaza.zakaznikID = idzaka;

                    //MessageBox.Show(Convert.ToString(idvazba) + " " + " LEK");

                    // MessageBox.Show(Convert.ToString(idslozeni) + " " + " SLOŽENÍ");
                    DataZA.SaveItemAsync7(itemvazbaza);
                    //MessageBox.Show(line);
                }*/
            }
            else
            {
                MessageBox.Show("Login nebo heslo není vyplněné! Prosím vyplňtě ty do 2 nejdůležitější informace.");
            }
        }
    }
}
