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

namespace Velic.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddTovarPage.xaml
    /// </summary>
    public partial class AddTovarPage : Page
    {
        public AddTovarPage()
        {
            InitializeComponent();
            PostavshicCombo.ItemsSource = DataBaseConection.db.PostavshicTovar_.ToList();
            PostavshicCombo.DisplayMemberPath = "NamePostavshik";
            PostavshicCombo.SelectedValuePath = "IdPostavShik";

            KatCombo.ItemsSource = DataBaseConection.db.KategoriaTovara_.ToList();
            KatCombo.DisplayMemberPath = "NameKategorii";
            KatCombo.SelectedValuePath = "IdKategorii";
        }

        private void AddNewTovarButton(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase.Tovar_ tovar = new DataBase.Tovar_
                {
                    Articul = ArtTxt.Text,
                    NameTovara = NameTxt.Text,
                    EdIzmerenia = EdIzmerTxt.Text,
                    Cena = Decimal.Parse(CenaTxt.Text),
                    IdPostavshik = (int) PostavshicCombo.SelectedValue,
                    Proizvoditel = ProizvodTxt.Text,
                    IdKategoriaTovara = (int) KatCombo.SelectedValue,
                    DeistvSkidka = int.Parse(ScidkaTxt.Text),
                    KolvoNaSclade = int.Parse(KolVoTxt.Text),
                    OpisanieTovara = DescTxt.Text,
                    Photo = PhotoPathTxt.Text
                };
                if(PhotoPathTxt.Text == null)
                {
                    PhotoPathTxt.Text = "/Resources/picture.png";
                    MessageBox.Show($"Товар успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                DataBaseConection.db.Tovar_.Add(tovar);
                DataBaseConection.db.SaveChanges();

                ArtTxt.Clear();
                NameTxt.Clear();
                EdIzmerTxt.Clear();
                CenaTxt.Clear();
                ProizvodTxt.Clear();
                ScidkaTxt.Clear();
                KolVoTxt.Clear();
                DescTxt.Clear();
                PhotoPathTxt.Clear();

                MessageBox.Show($"Товар успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TovarMainPage());
        }
    }
}
