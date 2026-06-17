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

namespace Velic.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для TovarPageClient.xaml
    /// </summary>
    public partial class TovarPageClient : Page
    {
        public TovarPageClient()
        {
            InitializeComponent();
            TovarList.ItemsSource = DataBaseConection.db.Tovar_.ToList();
        }
    }
}
