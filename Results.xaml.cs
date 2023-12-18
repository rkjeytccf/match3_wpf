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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        private readonly bool isComplete;
        private readonly int level;
        public Results(bool isComplete, string finalScore, int level)
        {
            InitializeComponent();
            this.isComplete = isComplete;
            this.level = level;
            if (isComplete )
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
                if (level == 1){
                    Next.Content = new Level2();
                }
                else if (level == 2)
                {
                    Next.Content = new Level3();
                }
                else
                {
                    MessageBox.Show("You passed", "Congratulations");
                }

            }
            else
            {
                MessageBox.Show("You can't go to the next level now\nBut you can restart this level", "Closed level");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (level == 1)
            {
                Next.Content = new Level1();
            }
            else if (level == 2)
            {
                Next.Content = new Level2();
            }
            else if (level == 3)
            {
                Next.Content = new Level3();
            }
        }
    }
}
