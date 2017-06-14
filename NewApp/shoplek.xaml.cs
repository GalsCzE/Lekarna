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
    /// Interakční logika pro shoplek.xaml
    /// </summary>
    public partial class shoplek : Page
    {
        Leky itemlek = new Leky();
        int idl;
        Frame shop;
        Zakaznik itemzakaznik = new Zakaznik();
        List<Zakaznik> userseer = new List<Zakaznik>();
        public shoplek(Leky lek, Frame pq)
        {
            InitializeComponent();
            idl = lek.ID;
            itemlek = lek;
            shop = pq;
            h1.Text = itemlek.nazev;
            h2.Text = itemlek.firma;
            h3.Text = itemlek.slozeni;
        }

        private void addlek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backlek_Click(object sender, RoutedEventArgs e)
        {
            shop.Navigate(new Shop(shop,userseer,itemzakaznik));
        }
    }
}
