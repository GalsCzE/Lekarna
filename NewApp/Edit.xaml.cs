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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        ObservableCollection<Zakaznik> itemsFromDb;
        Zakaznik item = new Zakaznik();
        int id;
        string oprav;
        Frame page1;
        public Edit(Zakaznik p, Frame po)
        {
            InitializeComponent();
            id = p.ID;
            item = p;
            page1 = po;
            y1.Text = item.jmeno;
            y2.Text = item.prijmeni;
            y3.Text = item.alergie;
            y5.Text = item.heslo;
            y7.Text = item.login;

            if (item.pohlavi == 1)
            {
                male.IsSelected = true;
            }
            if (item.pohlavi == 2)
            {
                female.IsSelected = true;
            }

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

        private void edit_Click(object sender, RoutedEventArgs e)
        {

            itemsFromDb = new ObservableCollection<Zakaznik>(Data.GetItemsAsync().Result);
            Zakaznik itemqw = new Zakaznik();
            itemqw.ID = id;
            itemqw.jmeno = y1.Text;
            itemqw.prijmeni = y2.Text;
            itemqw.alergie = y3.Text;
            itemqw.heslo = y5.Text;
            itemqw.login = y7.Text;
            itemqw.opravneni = oprav;
            if (male.IsSelected)
            {
                itemqw.pohlavi = 1;

            }
            else
            if (female.IsSelected)
            {
                itemqw.pohlavi = 2;
            }

            Data.SaveItemAsync(itemqw);
            page1.Navigate(new ofiko(item));

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
           /* Zakaznik itemqw = new Zakaznik();
            itemqw.ID = id;*/
            Data.DeleteItemAsync(id);
            page1.Navigate(new ofiko(item));
        }

        private void bac_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new ofiko(item));
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

        private void lekw_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new Lewk(item, editpage));
        }

        private void alerg_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new Alegf(item, editpage));
        }
    }
}
