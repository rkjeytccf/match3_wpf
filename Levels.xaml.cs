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

namespace finalKursach
{
    /// <summary>
    /// Логика взаимодействия для Levels.xaml
    /// </summary>
    public partial class Levels : Page
    {
        public Levels()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Level1 page = new Level1();
            Level.Content = page;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Menuu menu = new Menuu();
            menu.Show();

            if (Application.Current.MainWindow != null && Application.Current.MainWindow != menu)
            {
                Application.Current.MainWindow.Close();
            }

            Application.Current.MainWindow = menu;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Level3 page = new Level3();
            Level.Content = page;
        }
    }
}
