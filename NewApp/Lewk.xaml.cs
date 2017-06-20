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
    /// Interakční logika pro Lewk.xaml
    /// </summary>
    public partial class Lewk : Page
    {
        Zakaznik itemzz;
        Frame page2;
        ObservableCollection<Leky> itemsFromDBLe;
        public Lewk(Zakaznik a, Frame fa)
        {
            InitializeComponent();

            itemzz = a;
            page2 = fa;

            itemsFromDBLe = new ObservableCollection<Leky>(Datal.GetItemsAsync2().Result);
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDBLe.Count);
            foreach (Leky todoItem in itemsFromDBLe)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            ListView.ItemsSource = itemsFromDBLe;
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

        private void ToDoItemsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Leky todoItem = (Leky)ListView.SelectedItems[0];
            page6.Navigate(new USELEK(todoItem, page6, itemzz));
            ListView.Visibility = Visibility.Hidden;
            be.Visibility = Visibility.Hidden;
        }

        private void be_Click(object sender, RoutedEventArgs e)
        {
            page6.Navigate(new Edit(itemzz,page6));
            ListView.Visibility = Visibility.Hidden;
            be.Visibility = Visibility.Hidden;
        }
    }
}
