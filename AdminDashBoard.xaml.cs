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
using Microsoft.Win32;
using System.IO;
using Path = System.IO.Path;

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


        // ------------------------- These are for hover effect.

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
        // ------------------------- These are for hover effect.



        private void AdminBackToMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseRole.xaml", UriKind.Relative));
        }

        private void menu3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ReviewLogFile.xaml", UriKind.Relative));
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminDashBoardMain.Visibility = Visibility.Visible;

            // Hide the other parts
            AdminDashBoardDirectory.Visibility = Visibility.Collapsed;
            AdminDashBoardIpPort.Visibility = Visibility.Collapsed;

            // log
            AdminController.addLog("Admin dashboard home button clicked");
        }

        private void ChangeLogFilePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            bool? result = ofd.ShowDialog();

            if (result == true)
            {
                LogFilePath.Text = Path.GetDirectoryName(ofd.FileName);
                AdminController.LogFileDirectory = LogFilePath.Text;
            }

            // log
            AdminController.addLog("Change directory button clicked");

        }

        private void menu1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminDashBoardDirectory.Visibility = Visibility.Visible;

            // Hide the other parts
            AdminDashBoardMain.Visibility = Visibility.Collapsed;
            AdminDashBoardIpPort.Visibility = Visibility.Collapsed;

            // log
            AdminController.addLog("Directory setting menu clicked");
        }        

        private void TmsConnect_Click(object sender, RoutedEventArgs e)
        {
            AdminController.ConnectionStringForTMS = $"Server={TmsIpAddress.Text};Port={TmsPortNum.Text};Database=TmsDatabase;Uid={TmsUserName.Text};Pwd={TmsDbPassword};";

            // log
            AdminController.addLog("TMS database connection button clicked");
        }

        private void menu2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminDashBoardIpPort.Visibility = Visibility.Visible;
            
            // Hide the other parts
            AdminDashBoardMain.Visibility = Visibility.Collapsed;
            AdminDashBoardDirectory.Visibility = Visibility.Collapsed;

            // log
            AdminController.addLog("DB Connection setting button clicked");
        }
    }
}
