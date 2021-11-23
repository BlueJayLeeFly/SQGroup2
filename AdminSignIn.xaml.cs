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
    /// Interaction logic for AdminSignIn.xaml
    /// </summary>
    public partial class AdminSignIn : Page
    {

        protected int signInAttemptRemain = 2;

        public AdminSignIn()
        {
            InitializeComponent();
        }

        private void AdminSignInButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCount = 0;
            AdminIdError.Text = "";
            AdminiPasswordError.Text = "";

            if (ForAdminID.Text != "admin")
            {
                errorCount++;
                AdminIdError.Text = "* Incorrect User ID";
            }

            if (ForAdminPassWord.Password != "admin")
            {
                errorCount++;
                AdminiPasswordError.Text = "* Incorrect Password";
            } 

            if (errorCount > 0)
            {
                if (signInAttemptRemain == 0)
                {
                    AdminSignInButton.Visibility = Visibility.Collapsed;
                    adminWarning.Visibility = Visibility.Visible;
                    adminLock.Visibility = Visibility.Visible;
                    adminSignInFail.Visibility = Visibility.Visible;
                }
                signInAttemptRemain--;
                AdminSingInAttemptMsg.Text = $"Sign In Attempt Remaining {signInAttemptRemain+1}";
            } 
            else
            {
                signInAttemptRemain = 0;
                AdminSingInAttemptMsg.Text = "";                

                AdminController.addLog("Sign in Success!");

                this.NavigationService.Navigate(new Uri("AdminDashBoard.xaml", UriKind.Relative));
            }         

          

        }
    }
}
