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
using System.Globalization;

namespace Group2
{
    /// <summary>
    /// Interaction logic for ReviewLogFile.xaml
    /// </summary>
    public partial class ReviewLogFile : Page
    {

        public static string tmsLog;

        public ReviewLogFile()
        {
            InitializeComponent();
        }

        private void menu1_MouseEnter(object sender, MouseEventArgs e)
        {
            menu1.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(247, 239, 255));
        }

        private void menu1_MouseLeave(object sender, MouseEventArgs e)
        {
            menu1.Background = new SolidColorBrush(Color.FromRgb(247, 239, 255));
            menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
        }

        private void menu2_MouseEnter(object sender, MouseEventArgs e)
        {
            menu2.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(247, 239, 255));
        }

        private void menu2_MouseLeave(object sender, MouseEventArgs e)
        {
            menu2.Background = new SolidColorBrush(Color.FromRgb(247, 239, 255));
            menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
        }

        private void menu3_MouseEnter(object sender, MouseEventArgs e)
        {
            menu3.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(247, 239, 255));
        }

        private void menu3_MouseLeave(object sender, MouseEventArgs e)
        {
            menu3.Background = new SolidColorBrush(Color.FromRgb(247, 239, 255));
            menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
        }

        private void AdminBackToMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseRole.xaml", UriKind.Relative));
        }

        private void menu3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminController.addLog("Refresh Log");
            Log.Text = AdminController.Record;     

        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {

            AdminController.addLog("Review Log Status");

            Log.Text = AdminController.Record;
        }

        private void AdminDashboard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AdminDashBoard.xaml", UriKind.Relative));
        }
    }
}
