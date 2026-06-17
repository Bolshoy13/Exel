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
using Velic.DataBase;
using Velic.Scripts;

namespace Velic.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для TovarMainPage.xaml
    /// </summary>
    public partial class TovarMainPage : Page
    {
        public TovarMainPage()
        {
            InitializeComponent();
            TovarList.ItemsSource = DataBaseConection.db.Tovar_.ToList();
        }

        private void AddTovarPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTovarPage());
        }

        private void DeletTovarButton(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var curItem = TovarList.SelectedItem as Tovar_;
                var itemToDelet = DataBaseConection.db.Tovar_.FirstOrDefault(t => t.IdTovar ==  curItem.IdTovar);
                if(itemToDelet != null)
                {
                    DataBaseConection.db.Tovar_.Remove(itemToDelet);
                    DataBaseConection.db.SaveChanges();
                }
                TovarList.ItemsSource = DataBaseConection.db.Tovar_.ToList();
                MessageBox.Show("Удалено", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RedTovarPageButton(object sender, RoutedEventArgs e)
        {
            var selectTovar = TovarList.SelectedItem as Tovar_;
            if(selectTovar == null)
            {
                MessageBox.Show("Выберите товар для редактирования!");
                return;
            }
            NavigationService.Navigate(new RedTovarPage(selectTovar));
        }

        private void BackPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainAdminPage());
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
