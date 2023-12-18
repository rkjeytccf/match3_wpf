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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Menuu : Window
    {
        public Menuu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Levels.Content = new Levels(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Levels.Content = new Settings();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
