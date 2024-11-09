using cardealership.helpers;
using cardealership.pages;
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

namespace cardealership
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new car_page());
            helpers.manager.MainFrame = MainFrame;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            helpers.manager.MainFrame.Navigate(new car_page());
        }
    }
}
