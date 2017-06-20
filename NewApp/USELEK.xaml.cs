using System;
using System.Collections.Generic;
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
    /// Interakční logika pro USELEK.xaml
    /// </summary>
    public partial class USELEK : Page
    {
        Zakaznik itemzz2;
        Frame page2;
        Leky itemll = new Leky();
        public USELEK(Leky itemle,Frame aa, Zakaznik l)
        {
            InitializeComponent();
            itemzz2 = l;
            page2 = aa;
            itemll = itemle;
            m1.Text = itemll.nazev;
            m2.Text = itemll.firma;
        }

        public USELEK(Zakaznik we,Frame ve)
        {
            InitializeComponent();
            itemzz2 = we;
            page2 = ve;
            m1.Text = itemll.nazev;
            m2.Text = itemll.firma;
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

        private void savel_Click(object sender, RoutedEventArgs e)
        {
            VazbaZL itemv = new VazbaZL();
            itemv.lekID = itemll.ID;
            itemv.zakaznikID = itemzz2.ID;
            DataZL.SaveItemAsync6(itemv);
            page2.Navigate(new Lewk(itemzz2, page2));
        }

        private void bal_Click(object sender, RoutedEventArgs e)
        {
            page2.Navigate(new Lewk(itemzz2,page2));
        }
    }
}
