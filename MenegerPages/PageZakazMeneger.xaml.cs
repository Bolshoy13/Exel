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

namespace Velic.Pages.MenegerPages
{
    /// <summary>
    /// Логика взаимодействия для PageZakazMeneger.xaml
    /// </summary>
    public partial class PageZakazMeneger : Page
    {
        public PageZakazMeneger()
        {
            InitializeComponent();
            ZakazList.ItemsSource = DataBaseConection.db.Check_.ToList();
        }

        private void BackPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenegerPage());
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
