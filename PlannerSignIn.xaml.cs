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
    /// Interaction logic for PlannerSignIn.xaml
    /// </summary>
    public partial class PlannerSignIn : Page
    {

        protected int signInAttemptRemain = 2;

        public PlannerSignIn()
        {
            InitializeComponent();
        }

        private void PlannerSignInButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCount = 0;
            PlannerIdError.Text = "";
            PlannerPasswordError.Text = "";

            if (ForPlannerID.Text != "planner")
            {
                errorCount++;
                PlannerIdError.Text = "* Incorrect User ID";
            }

            if (ForPlannerPassWord.Password != "planner")
            {
                errorCount++;
                PlannerPasswordError.Text = "* Incorrect Password";
            }

            if (errorCount > 0)
            {
                if (signInAttemptRemain == 0)
                {
                    PlannerSignInButton.Visibility = Visibility.Collapsed;
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
                this.NavigationService.Navigate(new Uri("PlannerDashBoard.xaml", UriKind.Relative));
            }
        }
    }
}
