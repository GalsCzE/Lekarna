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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Zakaznik items = new Zakaznik();
        List<Zakaznik> users = new List<Zakaznik>();
        public Login(Zakaznik items)
        {
            InitializeComponent();
        }

        private void conf_Click(object sender, RoutedEventArgs e)
        {
            users = ofiko.Data.GetItemsAsync().Result;
            foreach (Zakaznik i in users)
            {
                if (i.login == log.Text && i.heslo == pass.Text)
                {
                    MessageBox.Show("Jste přihlášen");
                    pageLogin.Navigate(new ofiko(users, i));
                    log.Visibility = Visibility.Hidden;
                    pass.Visibility = Visibility.Hidden;
                    conf.Visibility = Visibility.Hidden;
                    oh.Visibility = Visibility.Hidden;
                    ass.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
