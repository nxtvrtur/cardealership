using cardealership.data;
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
    /// Interaction logic for car_page.xaml
    /// </summary>
    public partial class car_page : Page
    {
        private int CountRecords = 0;
        private int AllRecords = CarDealershipEntities.GetContext().Автомобили.Count();
        public car_page()
        {
            InitializeComponent();
            cars_listview.ItemsSource = CarDealershipEntities.GetContext().Автомобили.ToList();
            ManySort_CB.SelectedIndex = 0;
            AllRecords = CarDealershipEntities.GetContext().Автомобили.Count();
            var categories = new List<string>();
            categories.Add("Все");
            categories.AddRange(CarDealershipEntities.GetContext().Категории_автомобилей.Select(x => x.Название).ToList());
            Category.ItemsSource = categories;
            Category.SelectedIndex = 0;
            RecordsCount.Text = $"количество записей: {CountRecords} из {AllRecords}";
        }

        void UpdateCars()
        {
            var cars = CarDealershipEntities.GetContext().Автомобили.ToList();

            cars = cars.Where(c => c.Модель.ToLower().Contains(Search.Text.ToLower()) || c.Марки_автомобилей.Название_марки.ToLower().Contains(Search.Text.ToLower()) || c.Год_производства.ToString().Contains(Search.Text.ToLower())).ToList();

            if (ManySort_CB.SelectedIndex == 1)
            {
                cars = cars.OrderBy(c => c.Цена).ToList();
            }
            if (ManySort_CB.SelectedIndex == 2)
            {
                cars = cars.OrderByDescending(c => c.Цена).ToList();
            }

            if (Category.SelectedIndex == 1)
            {
                cars = cars.Where(c => c.Категория == 1).ToList();
            }
            if (Category.SelectedIndex == 2)
            {
                cars = cars.Where(c => c.Категория == 2).ToList();
            }
            if (Category.SelectedIndex == 3)
            {
                cars = cars.Where(c => c.Категория == 3).ToList();
            }
            if (Category.SelectedIndex == 4)
            {
                cars = cars.Where(c => c.Категория == 4).ToList();
            }
            if (Category.SelectedIndex == 5)
            {
                cars = cars.Where(c => c.Категория == 5).ToList();
            }
            if (Category.SelectedIndex == 6)
            {
                cars = cars.Where(c => c.Категория == 6).ToList();
            }
            if (Category.SelectedIndex == 7)
            {
                cars = cars.Where(c => c.Категория == 7).ToList();
            }
            if (Category.SelectedIndex == 8)
            {
                cars = cars.Where(c => c.Категория == 8).ToList();
            }

            cars_listview.ItemsSource = cars;
            CountRecords = cars.Count;
            RecordsCount.Text = $"количество записей: {CountRecords} из {AllRecords}";


        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCars();
        }

        private void ManySort_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCars();
        }

        private void Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCars();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            helpers.manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                cars_listview.ItemsSource = CarDealershipEntities.GetContext().Автомобили.ToList();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            helpers.manager.MainFrame.Navigate(new AddEditPage(null));

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var car = (sender as Button).DataContext as Автомобили;
            helpers.manager.MainFrame.Navigate(new AddEditPage(car));
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(((sender as Button).DataContext as Автомобили).Цена == 0)
            {
                if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    CarDealershipEntities.GetContext().Автомобили.Remove((sender as Button).DataContext as Автомобили);
                    CarDealershipEntities.GetContext().SaveChanges();

                    cars_listview.ItemsSource = CarDealershipEntities.GetContext().Автомобили.ToList();
                    CountRecords -= 1;
                    AllRecords -= 1;
                    UpdateCars();
                }

            }
            else
            {
                MessageBox.Show("Невозможно удалить", "Ошибка");
            }
        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
            var car = (sender as Button).DataContext as Автомобили;
            string url = $"https://www.google.com/search?q={car.Марки_автомобилей.Название_марки}+{car.Модель}";
            System.Diagnostics.Process.Start(url);
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            ManySort_CB.SelectedIndex = 0;
            Category.SelectedIndex = 0;
            UpdateCars();
        }
    }
}

