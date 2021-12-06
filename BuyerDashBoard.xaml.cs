﻿using MySql.Data.MySqlClient;
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
        DataTable DtMarketPlace = new DataTable();                 // DataTable Defined as a Global variable.
        DataTable DtOrder = new DataTable();                        // DataTable Defined as a Global variable.
        List<object> newList = new List<object>();


        public BuyerDashBoard()
        {

            InitializeComponent();
            Carrier_ComboBox.Items.Add("We Haul");
            Carrier_ComboBox.Items.Add("Planet Express");
            Carrier_ComboBox.Items.Add("Schooner's");
            Carrier_ComboBox.Items.Add("Tillman Transport");
        }



        // ----------------------------------------------------------------------------------------------//
        // ----------------------------------   Sohaib functions   --------------------------------------//
        // ----------------------------------------------------------------------------------------------//

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

                    // Shows Connection Accepted on UI
                    market_status_bar.Content = $"Connected to MySql {conn.ServerVersion}";

                    // SQL Command
                    string sq1 = "SELECT * FROM Contract;";
                    MySqlCommand selectAllContract = new MySqlCommand(sq1, conn);

                    // Create A data Adapter
                    MySqlDataAdapter reader = new MySqlDataAdapter(selectAllContract);

                    // fills Data Table Object with All Contract Rows 
                    reader.Fill(DtMarketPlace);
                    DtOrder = DtMarketPlace.Copy();


                    // Create 2 Columns 
                    DataColumn Order_ID = new DataColumn("Order_ID", typeof(Int32));
                    DataColumn Order_Status = new DataColumn("Order_Status", typeof(Int32));
                    DataColumn Order_Carrier = new DataColumn("Order_Carrier", typeof(string));

                    DtMarketPlace.Columns.Add(Order_ID);
                    DtMarketPlace.Columns.Add(Order_Status);
                    DtMarketPlace.Columns.Add(Order_Carrier);

                    //DtOrder = DtMarketPlace.Copy();

                    // Render the Columns and the rows 
                    Marketplace_datagrid.ItemsSource = DtMarketPlace.DefaultView;



                    conn.Close(); // Close connection
                }
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        /**
        *  \brief   accept_contract_MouseLeftButtonDown -- Gets selected client contracts,
        *  \details  this method fetch customers Contract, Generates a DataGrid of selected Items.
        *  \param    NONE
        *  \returns  NONE
        */
        private void accept_contract_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {



            // Add Selected orders.
            foreach (var selectedItem in Marketplace_datagrid.SelectedItems)
            {

                if (selectedItem != null)
                {

                    newList.Add(selectedItem);


                    ORDER_datagrid.ItemsSource = newList;
                    ORDER_datagrid.Items.Refresh();

                }

            }


        }

        /**
       *  \brief    Button_Add_Carrier -- Selected Orders are added a Carrier Value
       *  \details  this method fetch selected orders, Assigns a carrier only if the fullfil validation rule.
       *  \param    NONE
       *  \returns  NONE
       */
        private void Button_Add_Carrier(object sender, RoutedEventArgs e)
        {
            bool ValidCarrierAssigned = false;
            string Carrier_Error_Message = "";

            foreach (System.Data.DataRowView acceptedRows in ORDER_datagrid.SelectedItems)
            {


                string origin = acceptedRows[3].ToString();
                string carrier = Carrier_ComboBox.SelectedItem.ToString();

                if (carrier == "We Haul")
                {
                    if ((origin == "Ottawa" || origin == "Toronto"))
                    {
                        ValidCarrierAssigned = true;
                    }
                    else
                    {

                        Carrier_Error_Message = "We Haul - operates from Ottawa and Toronto.";
                    }


                }
                else if (carrier == "Planet Express")
                {
                    if ((origin == "Ottawa" || origin == "Hamilton" || origin == "Belleville" || origin == "Oshawa" || origin == "Windsor"))
                    {
                        ValidCarrierAssigned = true;
                    }
                    else
                    {

                        Carrier_Error_Message = "Planet Express - operates from Ottawa, Hamilton, Belleville, Oshawa and Windsor.";
                    }

                }

                else if (carrier == "Schooner's")
                {
                    if ((origin == "London" || origin == "Toronto" || origin == "Kingston"))
                    {
                        ValidCarrierAssigned = true;
                    }
                    else
                    {

                        Carrier_Error_Message = "Schooner's - operates from London,Toronto and Kingston.";
                    }


                }
                else if (carrier == "Tillman Transport")
                {
                    if ((origin == "London" || origin == "Windsor" || origin == "Hamilton"))
                    {
                        ValidCarrierAssigned = true;
                    }
                    else
                    {

                        Carrier_Error_Message = "Tillman Transport - operates from London, Windsor and Hamilton.";
                    }

                }

                if (ValidCarrierAssigned == true)
                {

                    Random randomNumber = new Random();
                    acceptedRows[6] = randomNumber.Next(1, 10000);
                    acceptedRows[7] = 2;
                    acceptedRows[8] = carrier;
                    tms_status_bar.Content = "Order ID:" + acceptedRows[6].ToString() + "has been assigned a Carrier.";


                    // [D] - Hacky solution - fix  
                    Marketplace_datagrid.ItemsSource = DtOrder.DefaultView;

                }
                else
                {
                    tms_status_bar.Content = Carrier_Error_Message;
                }
            }

        }


        private void Button_Update_Order_DB(object sender, RoutedEventArgs e)
        {
            // INSERT INTO ORDER TABLE DB

            // SELECTED Item from ORDER_DataGrid or MarketPlace Table.

            // After rendering all columns and defaulting empty values
        }




        // ----------------------------------------------------------------------------------------------//
        // ----------------------------------   Colby functions   ---------------------------------------//
        // ----------------------------------------------------------------------------------------------//


        // Event for "Generate Invoice"
        private void buyer_menu3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }







        // ----------------------------------------------------------------------------------------------//
        // ---------------------------------- MISC /UI functions   --------------------------------------//
        // ----------------------------------------------------------------------------------------------//


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

        private void Carrier_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ORDER_datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



    }
}
