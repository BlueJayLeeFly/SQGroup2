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
    /// Interaction logic for BuyerSignIn.xaml
    /// </summary>
    public partial class BuyerSignIn : Page
    {

        protected int signInAttemptRemain = 2;

        public BuyerSignIn()
        {
            InitializeComponent();
        }

        private void BuyerSignInButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCount = 0;
            BuyerIdError.Text = "";
            BuyerPasswordError.Text = "";

            if (ForBuyerID.Text != "buyer")
            {
                errorCount++;
                BuyerIdError.Text = "* Incorrect User ID";
            }

            if (ForBuyerPassWord.Password != "buyer")
            {
                errorCount++;
                BuyerPasswordError.Text = "* Incorrect Password";
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
                AdminSingInAttemptMsg.Text = $"Sign In Attempt Remaining {signInAttemptRemain + 1}";
            }
            else
            {
                signInAttemptRemain = 0;
                AdminSingInAttemptMsg.Text = "";
                // If ID and Password match, move to the admin panel - currently it lands on the wrong page. Fix it!
                this.NavigationService.Navigate(new Uri("BuyerDashBoard.xaml", UriKind.Relative));
            }
        }
    }
}
