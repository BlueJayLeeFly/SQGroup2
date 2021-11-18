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

namespace Group2
{
    /// <summary>
    /// Interaction logic for AdminDashBoard.xaml
    /// </summary>
    public partial class AdminDashBoard : Page
    {
        public AdminDashBoard()
        {
            InitializeComponent();
        }

        private void menu1_MouseEnter(object sender, MouseEventArgs e)
        {
            menu1.Background = new SolidColorBrush(Color.FromRgb(151,86,217));
            menu1_label.Foreground = new SolidColorBrush(Colors.White);
            eventTest.Text = "Menu1_Enter";
        }

        private void menu1_MouseLeave(object sender, MouseEventArgs e)
        {
            menu1.Background = new SolidColorBrush(Colors.White);
            menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            eventTest.Text = "Menu1_Leave";
        }

        private void menu2_MouseEnter(object sender, MouseEventArgs e)
        {
            menu2.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu2_label.Foreground = new SolidColorBrush(Colors.White);
            eventTest.Text = "Menu2_Enter";
        }

        private void menu2_MouseLeave(object sender, MouseEventArgs e)
        {
            menu2.Background = new SolidColorBrush(Colors.White);
            menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            eventTest.Text = "Menu2_Leave";
        }

        private void menu3_MouseEnter(object sender, MouseEventArgs e)
        {
            menu3.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu3_label.Foreground = new SolidColorBrush(Colors.White);
            eventTest.Text = "Menu3_Enter";
        }

        private void menu3_MouseLeave(object sender, MouseEventArgs e)
        {
            menu3.Background = new SolidColorBrush(Colors.White);
            menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            eventTest.Text = "Menu3_Leave";
        }

        private void AdminBackToMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseRole.xaml", UriKind.Relative));
        }
    }
}
