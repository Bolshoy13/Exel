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
using Velic.Scripts;
using Velic.DataBase;
using Velic.Pages.AdminPages;
using Velic.Pages.MenegerPages;
using Velic.Pages.ClientPages;

namespace Velic.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            DataBaseConection.db = new DataBase.DataBaseVelosipedEntities();
        }

        private void LoginClientButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DataBaseConection.db.Users_.FirstOrDefault(X => X.Login == LoginTxt.Text && X.Password == PasswordTxt.Password);
                if(user == null)
                {
                    MessageBox.Show("Такого пользователя не существует!!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    switch(user.IdRoleUser)
                    {
                        case 1:
                            MessageBox.Show($"Добро пожаловать администратор {user.Familia} {user.Ima}", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new MainAdminPage());
                            break;
                        case 2:
                            MessageBox.Show($"Добро пожаловать менеджер {user.Familia} {user.Ima}", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new MainMenegerPage());
                            break;
                        case 3:
                            MessageBox.Show($"Добро пожаловать клиент {user.Familia} {user.Ima}", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new TovarPageClient());
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoginGostButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
