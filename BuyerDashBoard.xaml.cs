using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for BuyerDashBoard.xaml
    /// </summary>
    /// 
    
    public partial class BuyerDashBoard : Page
    {

        /**
        *  \brief   BuyerDashBoard -- initialize components
        *  \details this method initialize components of PlannerDashBoard.xaml
        *  \param   NONE
        *  \returns NONE
        */

        public BuyerDashBoard()
        {
            InitializeComponent();
        }


        /**
        *  \brief   buyer_menu1_MouseEnter -- event handling of menu item mouse enter
        *  \details this method handlesmenu item mouse enter event and change the background and text color to accent colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void buyer_menu1_MouseEnter(object sender, MouseEventArgs e)
        {
            buyer_menu1.Background = new SolidColorBrush(Color.FromRgb(239, 70, 111));
            buyer_menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(233, 224, 226));
        }


        /**
        *  \brief   buyer_menu1_MouseLeave -- event handling of menu item mouse leave
        *  \details this method handlesmenu item mouse leave event and change the background and text color to original colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void buyer_menu1_MouseLeave(object sender, MouseEventArgs e)
        {
            buyer_menu1.Background = new SolidColorBrush(Color.FromRgb(233, 224, 226));
            buyer_menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(239, 70, 111));
        }


        /**
        *  \brief   buyer_menu2_MouseEnter -- event handling of menu item mouse enter
        *  \details this method handlesmenu item mouse enter event and change the background and text color to accent colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void buyer_menu2_MouseEnter(object sender, MouseEventArgs e)
        {
            buyer_menu2.Background = new SolidColorBrush(Color.FromRgb(239, 70, 111));
            buyer_menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(233, 224, 226));
        }


        /**
        *  \brief   buyer_menu2_MouseLeave -- event handling of menu item mouse leave
        *  \details this method handlesmenu item mouse leave event and change the background and text color to original colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void buyer_menu2_MouseLeave(object sender, MouseEventArgs e)
        {
            buyer_menu2.Background = new SolidColorBrush(Color.FromRgb(233, 224, 226));
            buyer_menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(239, 70, 111));
        }


        /**
        *  \brief   buyer_menu3_MouseEnter -- event handling of menu item mouse enter
        *  \details this method handlesmenu item mouse enter event and change the background and text color to accent colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void buyer_menu3_MouseEnter(object sender, MouseEventArgs e)
        {
            buyer_menu3.Background = new SolidColorBrush(Color.FromRgb(239, 70, 111));
            buyer_menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(233, 224, 226));
        }


        /**
        *  \brief   buyer_menu3_MouseLeave -- event handling of menu item mouse leave
        *  \details this method handlesmenu item mouse leave event and change the background and text color to original colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void buyer_menu3_MouseLeave(object sender, MouseEventArgs e)
        {
            buyer_menu3.Background = new SolidColorBrush(Color.FromRgb(233, 224, 226));
            buyer_menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(239, 70, 111));
        }


        /**
        *  \brief   BuyerBackToMain_MouseLeftButtonDown -- event handling of menu item mouse click
        *  \details this method handles menu item mouse click event and lead to ChooseRole.xaml
        *  \param   sender object
        *  \param   MouseButtonEventArgs e
        *  \returns NONE
        */

        private void BuyerBackToMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseRole.xaml", UriKind.Relative));
        }


        /**
        *  \brief   buyer_menu1_MouseLeftButtonDown -- event handling of menu item mouse click
        *  \details this method handles menu item mouse click event, display content of the menu which is main dashboard page and hide non-related content
        *  \param   sender object
        *  \param   MouseButtonEventArgs e
        *  \returns NONE
        */

        private void buyer_menu1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //
        }


        /**
        *  \brief   Label_MouseLeftButtonDown -- event handling of menu item mouse click
        *  \details this method handles menu item mouse click event, display content of the menu which is main dashboard page and hide non-related content
        *  \param   sender object
        *  \param   MouseButtonEventArgs e
        *  \returns NONE
        */

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("BuyerDashBoard.xaml", UriKind.Relative));
        }




        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            
            buyer_market_db_signin.Visibility = Visibility.Visible;

            

        }


        private void buyer_market_signin_close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            buyer_market_db_signin.Visibility = Visibility.Collapsed;
        }


        private void buyer_dashboard_market_button_Click(object sender, RoutedEventArgs e)
        {
            buyer_market_db_signin.Visibility = Visibility.Collapsed;

            // MySql
            try
            {
                // Connection String - Test version. Missing ip address
                var connstr = $"Server={buyer_dashboard_market_ip.Text};Uid={buyer_dashboard_market_id.Text};Pwd={buyer_dashboard_market_password.Password};database={buyer_dashboard_market_ip_dbName.Text}";

                using (var conn = new MySqlConnection(connstr))
                {
                    // Open connection
                    conn.Open();

                    // MySqal commands here

                    market_status_bar.Content = $"Connected to MySql {conn.ServerVersion}";

                    string sq1 = "SELECT * FROM Contract;";
                    MySqlCommand selectAllContract = new MySqlCommand(sq1, conn);
                    MySqlDataReader rdr = selectAllContract.ExecuteReader();

                    while (rdr.Read())
                    {

                        // DataTable Dt = new DataTable();

                        // Render data to datagrid
                        // TEST
                        Marketplace_datagrid.Items.Add(new contractParams
                        {

                            clientName = rdr[0].ToString(),
                            jobType = int.Parse(rdr[1].ToString()),
                            quantity = int.Parse(rdr[2].ToString()),
                            origin = rdr[3].ToString(),
                            destination = rdr[4].ToString(),
                            vanType = int.Parse(rdr[5].ToString())
                        });
                        //market_status_bar.Content = rdr[1].ToString();

                    }
                    rdr.Close();


                    conn.Close(); // Close connection
                }
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }


        // ------------------ future functions 



        /**
        *  \brief    getContract -- fetch customers data
        *  \details  this method fetch customers data
        *  \param    NONE
        *  \returns  NONE
        */

        private void getContract()
        {

        }


        /**
        *  \brief    reviewCust -- review existing customers
        *  \details  this method review existing customer
        *  \param    NONE
        *  \returns  NONE
        */

        private void reviewCust()
        {

        }


        /**
        *  \brief    acceptNewCust -- accept new customers
        *  \details  this method accepts new customers and update DB
        *  \param    NONE
        *  \returns  NONE
        */

        private void acceptNewCust()
        {

        }


        /**
        *  \brief    startOrder -- accept new customers
        *  \details  this method accepts new customers and update DB
        *  \param    NONE
        *  \returns  NONE
        */

        private void startOrder()
        {

        }


        private void selectCity()
        {

        }


        private void createInvoice()
        {

        }


        // Event for "Accept Contract" button
        private void accept_contract_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }








        //buyer methods
        //getContract() -> 4.5.2.2.1
        //reviewCust() -> 4.5.2.2.2
        //acceptNewCust() -> 4.5.2.2.2
        //startOrder() -> 4.5.2.2.3
        //selectCity() -> 4.5.2.2.4
        //createInvoice()-> 4.5.2.2.5
        //create invoice generates invoice in a file and updates TMS database

    }
}
