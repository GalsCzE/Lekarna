using System;
using System.Collections.Generic;
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
    /// Interakční logika pro USEALERGE.xaml
    /// </summary>
    public partial class USEALERGE : Page
    {
        Zakaznik itemss2;
        Frame page3;
        Slozky itempp = new Slozky();
        public USEALERGE(Slozky a, Frame b, Zakaznik c)
        {
            InitializeComponent();
            itemss2 = c;
            page3 = b;
            itempp = a;
            q1.Text = itempp.slozenileku;
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

        private void saves_Click(object sender, RoutedEventArgs e)
        {
            VazabaZA itemve = new VazabaZA();
            itemve.alergieID = itempp.ID;
            itemve.zakaznikID = itemss2.ID;
            DataZA.SaveItemAsync7(itemve);
            page3.Navigate(new Lewk(itemss2, page3));
        }

        private void bao_Click(object sender, RoutedEventArgs e)
        {
            page3.Navigate(new Lewk(itemss2, page3));
        }
    }
}
