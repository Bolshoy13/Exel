using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Velic.Scripts;

namespace Velic.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ZakazMainPage.xaml
    /// </summary>
    public partial class ZakazMainPage : Page
    {
        public ZakazMainPage()
        {
            InitializeComponent();
            ZakazList.ItemsSource = DataBaseConection.db.Check_.ToList();
        }

        private void AddZakazPageButton(object sender, RoutedEventArgs e)
        {

        }

        private void DeletTovarButton(object sender, RoutedEventArgs e)
        {

        }

        private void RedTovarPageButton(object sender, RoutedEventArgs e)
        {

        }

        private void BackPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainAdminPage());
        }

        private void SortVozrastButton(object sender, RoutedEventArgs e)
        {
            ZakazList.Items.SortDescriptions.Clear();
            ZakazList.Items.SortDescriptions.Add(new SortDescription("DataZakaza", ListSortDirection.Descending));
        }

        private void SortUbivButton(object sender, RoutedEventArgs e)
        {
            ZakazList.Items.SortDescriptions.Clear();
            ZakazList.Items.SortDescriptions.Add(new SortDescription("DataZakaza", ListSortDirection.Ascending));
        }
    }
}
