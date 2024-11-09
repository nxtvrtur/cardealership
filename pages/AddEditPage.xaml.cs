using cardealership.data;
using cardealership.helpers;
using Microsoft.Win32;
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

namespace cardealership.pages
{
    /// <summary>
    /// Interaction logic for AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Автомобили _currentCar = new Автомобили();
        public AddEditPage(Автомобили car)
        {
            InitializeComponent();
            if (car != null)
            {
                _currentCar = car;
            }

            DataContext = _currentCar;

            List<string> brands = new List<string>();
            List<string> categories = new List<string>();
            brands.Add("-");

            categories.Add("-");
            categories.AddRange(CarDealershipEntities.GetContext().Категории_автомобилей.Select(x => x.Название));
            brands.AddRange(CarDealershipEntities.GetContext().Марки_автомобилей.Select(x => x.Название_марки));
            CarBrand.ItemsSource = brands;
            Category.ItemsSource = categories;
        }

        private void Picture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Model.Text))
            {
                errors.AppendLine("Введите модель");
            }
            if (Year.Text == "0")
            {
                errors.AppendLine("Введите год");
            }
            if (string.IsNullOrWhiteSpace(Color.Text))
            {
                errors.AppendLine("Введите цвет");
            }
            if (string.IsNullOrWhiteSpace(Price.Text))
            {
                errors.AppendLine("Введите цену");
            }
            if (CarBrand.SelectedIndex == 0)
            {
                errors.AppendLine("Выберите марку");
            }
            if (Category.SelectedIndex == 0)
            {
                errors.AppendLine("Выберите категорию");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            _currentCar.Марка = CarBrand.SelectedIndex;
            _currentCar.Категория = Category.SelectedIndex;


            if (_currentCar.Номер_автомобиля == 0)
            {
                CarDealershipEntities.GetContext().Автомобили.Add(_currentCar);
            }
            try
            {
                CarDealershipEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно!");
                manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _currentCar.Фото = openFileDialog.FileName;
                Photo.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            helpers.manager.MainFrame.Navigate(new car_page());
        }
    }
}
