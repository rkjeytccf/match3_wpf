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
    /// Логика взаимодействия для Rules.xaml
    /// </summary>
    public partial class Rules : Page
    {
        public int n;
        public Rules(int n)
        {
            InitializeComponent();
            this.n = n;
        }

        private void BackImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            switch (n)
            {
                case 1:
                    MainFrame.Content = new Level1();
                    break;
                case 2:
                    MainFrame.Content = new Level2();
                    break;
                case 3:
                    MainFrame.Content = new Level3();
                    break;
            }
        }
    }
}
