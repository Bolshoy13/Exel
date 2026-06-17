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
using Velic.DataBase;
using Velic.Scripts;
using System.Data.Entity;

namespace Velic.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для RedTovarPage.xaml
    /// </summary>
    public partial class RedTovarPage : Page
    {
        public Tovar_ curTovar;
        public RedTovarPage(Tovar_ selItem)
        {
            InitializeComponent();

            PostavshicCombo.ItemsSource = DataBaseConection.db.PostavshicTovar_.ToList();
            PostavshicCombo.DisplayMemberPath = "NamePostavshik";
            PostavshicCombo.SelectedValuePath = "IdPostavShik";

            KatCombo.ItemsSource = DataBaseConection.db.KategoriaTovara_.ToList();
            KatCombo.DisplayMemberPath = "NameKategorii";
            KatCombo.SelectedValuePath = "IdKategorii";

            curTovar = selItem;

            ArtTxt.Text = curTovar.Articul;
            NameTxt.Text = curTovar.NameTovara;
            EdIzmerTxt.Text = curTovar.EdIzmerenia;
            CenaTxt.Text = curTovar.Cena.ToString();
            PostavshicCombo.SelectedValue = curTovar.IdKategoriaTovara;
            ProizvodTxt.Text = curTovar.Proizvoditel;
            KatCombo.SelectedValue = curTovar.IdKategoriaTovara;
            ScidkaTxt.Text = curTovar.DeistvSkidka.ToString();
            KolVoTxt.Text = curTovar.KolvoNaSclade.ToString();
            DescTxt.Text = curTovar.OpisanieTovara;
            PhotoPathTxt.Text = curTovar.Photo;
        }

        private void AddNewTovarButton(object sender, RoutedEventArgs e)
        {
            try
            {
                curTovar.Articul = ArtTxt.Text;
                curTovar.NameTovara = NameTxt.Text;
                curTovar.EdIzmerenia = EdIzmerTxt.Text;
                curTovar.Cena = Decimal.Parse(CenaTxt.Text);
                curTovar.IdPostavshik = (int)PostavshicCombo.SelectedValue;
                curTovar.Proizvoditel = ProizvodTxt.Text;
                curTovar.IdKategoriaTovara = (int)KatCombo.SelectedValue;
                curTovar.DeistvSkidka = int.Parse(ScidkaTxt.Text);
                curTovar.KolvoNaSclade = int.Parse(KolVoTxt.Text);
                curTovar.OpisanieTovara = DescTxt.Text;
                curTovar.Photo = PhotoPathTxt.Text;

                DataBaseConection.db.Entry(curTovar).State = EntityState.Modified;
                DataBaseConection.db.SaveChanges();

                MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void BackPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TovarMainPage());
        }
    }
}
