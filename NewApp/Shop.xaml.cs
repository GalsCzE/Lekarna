using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace NewApp
{
    /// <summary>
    /// Interakční logika pro Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        ObservableCollection<Leky> itemsFromDBLek;
        Frame page1;
        Zakaznik itemzakaznik;
        List<Zakaznik> userseer;
        public Shop(Frame sh,List<Zakaznik> kamil, Zakaznik l)
        {
            InitializeComponent();
            page1 = sh;
            itemzakaznik = l;
            userseer = kamil;

            itemsFromDBLek = new ObservableCollection<Leky>(Datalek.GetItemsAsync2().Result);
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDBLek.Count);
            foreach (Leky todoItem in itemsFromDBLek)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            ListView2.ItemsSource = itemsFromDBLek;
        }

        private void ToDoItemsListView2_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Leky todoItem = (Leky)ListView2.SelectedItems[0];
            shop.Navigate(new shoplek(todoItem, page1));
            bb.Visibility = Visibility.Hidden;
            ListView2.Visibility = Visibility.Hidden;
        }

        private static DatabazeL _datalek;
        public static DatabazeL Datalek
        {
            get
            {
                if (_datalek == null)
                {
                    var fileHelper = new Helper();
                    _datalek = new DatabazeL(fileHelper.GetLocalFilePath("LekySQLite.db3"));
                }
                return _datalek;
            }
        }

        private void bb_Click(object sender, RoutedEventArgs e)
        {
            page1.Navigate(new ofiko(userseer,itemzakaznik));
        }
    }
}
