using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Interakční logika pro ofiko.xaml
    /// </summary>
    public partial class ofiko : Page
    {
        ObservableCollection<Zakaznik> itemsFromDB;
        ObservableCollection<Leky> itemsFromDBL;
        ObservableCollection<VazbaZL> itemsFromDBZL;
        Zakaznik item = new Zakaznik();
        Zakaznik itempp;
        Leky iteml = new Leky();
        List<Zakaznik> userk = new List<Zakaznik>();
        public int lel;
        int ib;
        string oprav2;
        int bbe;
        public ofiko(Leky iteml)
        {
            InitializeComponent();
            medik.IsSelected = true;
            clovek.IsEnabled = false;
        }
        public ofiko(Zakaznik item)
        {
            InitializeComponent();
            medik.IsSelected = true;
            clovek.IsEnabled = false;
        }
        public ofiko(List<Zakaznik> j, Zakaznik u)
        {
            InitializeComponent();
            itempp = u;
            userk = j;
            //int x = Int32.Parse(u.opravneni);
            if (u.opravneni == "1")
            {
                clovek.IsSelected = true;
                medik.IsEnabled = false;
                ib = u.ID;
                t1.Text = u.jmeno;
                t2.Text = u.prijmeni;
                t5.Text = u.login;
                if (u.pohlavi == 1)
                {
                    male.IsSelected = true;
                }
                if (u.pohlavi == 2)
                {
                    female.IsSelected = true;
                }
                t6.Text = u.heslo;
                oprav2 = u.opravneni;

                itemsFromDBZL = new ObservableCollection<VazbaZL>(DataZL.GetItemsNotDoneAsync6(ib).Result);
                Debug.WriteLine(itemsFromDBZL.Count);
                foreach (VazbaZL todoItema in itemsFromDBZL)
                {
                    if (todoItema.zakaznikID == ib)
                    {
                        bbe = todoItema.lekID;
                        Debug.WriteLine(todoItema);
                    }
                }

                ListView.ItemsSource = itemsFromDBL;

            }
            else if (u.opravneni == "2")
            {
                medik.IsSelected = true;
                clovek.IsEnabled = false;
            }
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

        private static DatabazeZL _dataZL;
        public static DatabazeZL DataZL
        {
            get
            {
                if (_dataZL == null)
                {
                    var fileHelper = new Helper();
                    _dataZL = new DatabazeZL(fileHelper.GetLocalFilePath("VazabaZLSQLite.db3"));
                }
                return _dataZL;
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

        private void ToDoItemsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lel == 1)
            {
                if (ListView.SelectedItems.Count > 0)
                {

                    Zakaznik todoItem = (Zakaznik)ListView.SelectedItems[0];
                    page1.Navigate(new Edit(todoItem, page1));
                    medik.Visibility = Visibility.Hidden;
                    clovek.Visibility = Visibility.Hidden;
                    ListView.Visibility = Visibility.Hidden;
                    entry1.Visibility = Visibility.Hidden;
                    entry2.Visibility = Visibility.Hidden;
                    user.Visibility = Visibility.Hidden;
                    lekk.Visibility = Visibility.Hidden;
                }
            }
            else if (lel == 2)
            {
                Leky todoItem = (Leky)ListView.SelectedItems[0];
                page1.Navigate(new EditL(todoItem, page1));
                medik.Visibility = Visibility.Hidden;
                clovek.Visibility = Visibility.Hidden;
                ListView.Visibility = Visibility.Hidden;
                entry1.Visibility = Visibility.Hidden;
                entry2.Visibility = Visibility.Hidden;
                user.Visibility = Visibility.Hidden;
                lekk.Visibility = Visibility.Hidden;
            }

        }


        private void entry1_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new Bannan(item, page1));
            medik.Visibility = Visibility.Hidden;
            clovek.Visibility = Visibility.Hidden;
            ListView.Visibility = Visibility.Hidden;
            entry1.Visibility = Visibility.Hidden;
            entry2.Visibility = Visibility.Hidden;
            user.Visibility = Visibility.Hidden;
            lekk.Visibility = Visibility.Hidden;
        }

        private void entry2_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new Newlek(iteml, page1));
            medik.Visibility = Visibility.Hidden;
            clovek.Visibility = Visibility.Hidden;
            ListView.Visibility = Visibility.Hidden;
            entry1.Visibility = Visibility.Hidden;
            entry2.Visibility = Visibility.Hidden;
            user.Visibility = Visibility.Hidden;
            lekk.Visibility = Visibility.Hidden;
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            itemsFromDB = new ObservableCollection<Zakaznik>(Data.GetItemsAsync().Result);
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDB.Count);
            foreach (Zakaznik todoItem in itemsFromDB)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            ListView.ItemsSource = itemsFromDB;
            lel = 1;
    }

        private void lekk_Click(object sender, RoutedEventArgs e)
        {
            itemsFromDBL = new ObservableCollection<Leky>(Datal.GetItemsAsync2().Result);
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDBL.Count);
            foreach (Leky todoItem in itemsFromDBL)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            ListView.ItemsSource = itemsFromDBL;
            lel = 2;
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

        private void updates_Click(object sender, RoutedEventArgs e)
        {
            itemsFromDB = new ObservableCollection<Zakaznik>(Data.GetItemsAsync().Result);
            Zakaznik kek = new Zakaznik();
            kek.ID = ib;
            kek.jmeno = t1.Text;
            kek.prijmeni = t2.Text;
            kek.heslo = t6.Text;
            kek.login = t5.Text;
            //kek.lekek = t7.Text;
            kek.opravneni = oprav2;
            if (male.IsSelected)
            {
                kek.pohlavi = 1;

            }
            else
            if (female.IsSelected)
            {
                kek.pohlavi = 2;
            }

            Data.SaveItemAsync(kek);
            MessageBox.Show("Údaje aktualizovány!");
        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new Lewk(itempp,page1));
            stack1.Visibility = Visibility.Hidden;
            stack2.Visibility = Visibility.Hidden;
            clovek.Visibility = Visibility.Hidden;
            medik.Visibility = Visibility.Hidden;
        }

        private void ToDoItemsListView2_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Leky todoItema = (Leky)ListViews.SelectedItems[0];
            page1.Navigate(new USELEK(itempp, page1));
        }

        private void alerge_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new Alegf(itempp, page1));
        }
    }
}
