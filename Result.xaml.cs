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
using System.Windows.Shapes;

namespace finalKursach
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        private readonly bool isComplete;
        public Result(bool isComplete, string finalScore)
        {
            InitializeComponent();
            this.isComplete = isComplete;
            if (isComplete)
            {
                win.Text = "Congratulations!";
            }
            else
            {
                win.Text = "You lost! Try again";
            }
            FinalScore.Text = "Score: " + finalScore;
        }

        private void BackInMenu(object sender, RoutedEventArgs e)
        {
            Menuu menu = new Menuu();
            menu.Show();

            if (Application.Current.MainWindow != null && Application.Current.MainWindow != menu)
            {
                Application.Current.MainWindow.Close();
            }

            Application.Current.MainWindow = menu;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isComplete)
            {
                Next.Content = new Level2();
            }
            else
            {
                MessageBox.Show("You can't go to the next level now\nBut you can restart this level");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Next.Content = new Level1();
        }
    }
}
