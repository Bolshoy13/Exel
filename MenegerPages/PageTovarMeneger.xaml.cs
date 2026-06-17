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
    /// Логика взаимодействия для PageTovarMeneger.xaml
    /// </summary>
    public partial class PageTovarMeneger : Page
    {
        public PageTovarMeneger()
        {
            InitializeComponent();
            TovarList.ItemsSource = DataBaseConection.db.Tovar_.ToList();
        }

        private void BackPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenegerPage());
        }

        private void SortVozrastButton(object sender, RoutedEventArgs e)
        {
            TovarList.Items.SortDescriptions.Clear();
            TovarList.Items.SortDescriptions.Add(new SortDescription("KolvoNaSclade", ListSortDirection.Descending));
        }

        private void SortUbivButton(object sender, RoutedEventArgs e)
        {
            TovarList.Items.SortDescriptions.Clear();
            TovarList.Items.SortDescriptions.Add(new SortDescription("KolvoNaSclade", ListSortDirection.Ascending));
        }
    }
}
