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

namespace Velic.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        public MainAdminPage()
        {
            InitializeComponent();
        }

        private void TovarPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TovarMainPage());
        }

        private void ZakazPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZakazMainPage());
        }
    }
}
