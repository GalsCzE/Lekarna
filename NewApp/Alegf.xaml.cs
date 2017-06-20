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
    /// Interakční logika pro Alegf.xaml
    /// </summary>
    public partial class Alegf : Page
    {
        Zakaznik itemss;
        Frame page3;
        ObservableCollection<Slozky> itemsFromDBAl;
        public Alegf(Zakaznik m, Frame ma)
        {
            InitializeComponent();
            itemss = m;
            page3 = ma;

            itemsFromDBAl = new ObservableCollection<Slozky>(Dataslozka.GetItemsAsync3().Result);
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDBAl.Count);
            foreach (Slozky todoItem in itemsFromDBAl)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            ListView.ItemsSource = itemsFromDBAl;
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

        private void ToDoItemsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Slozky todoItem = (Slozky)ListView.SelectedItems[0];
            page8.Navigate(new USEALERGE(todoItem, page8, itemss));
            ListView.Visibility = Visibility.Hidden;
            bi.Visibility = Visibility.Hidden;
        }

        private void bi_Click(object sender, RoutedEventArgs e)
        {
            page8.Navigate(new Edit(itemss, page8));
            ListView.Visibility = Visibility.Hidden;
            bi.Visibility = Visibility.Hidden;
        }
    }
}
