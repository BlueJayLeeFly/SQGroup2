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
    /// Interaction logic for PlannerDashBoard.xaml
    /// </summary>
    public partial class PlannerDashBoard : Page
    {

        /**
        *  \brief   PlannerDashBoard -- initialize components
        *  \details this method initialize components of PlannerDashBoard.xaml
        *  \param   NONE
        *  \returns NONE
        */

        public PlannerDashBoard()
        {
            InitializeComponent();
        }


        /**
        *  \brief   planner_menu1_MouseEnter -- event handling of menu item mouse enter
        *  \details this method handlesmenu item mouse enter event and change the background and text color to accent colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void planner_menu1_MouseEnter(object sender, MouseEventArgs e)
        {
            planner_menu1.Background = new SolidColorBrush(Color.FromRgb(69, 177, 107));
            planner_menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(236, 255, 243));
        }


        /**
        *  \brief   planner_menu1_MouseLeave -- event handling of menu item mouse leave
        *  \details this method handlesmenu item mouse leave event and change the background and text color to original colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void planner_menu1_MouseLeave(object sender, MouseEventArgs e)
        {
            planner_menu1.Background = new SolidColorBrush(Color.FromRgb(236, 255, 243));
            planner_menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(69, 177, 107));
        }


        /**
        *  \brief   planner_menu2_MouseEnter -- event handling of menu item mouse enter
        *  \details this method handlesmenu item mouse enter event and change the background and text color to accent colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void planner_menu2_MouseEnter(object sender, MouseEventArgs e)
        {
            planner_menu2.Background = new SolidColorBrush(Color.FromRgb(69, 177, 107));
            planner_menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(236, 255, 243));
        }


        /**
        *  \brief   planner_menu2_MouseLeave -- event handling of menu item mouse leave
        *  \details this method handlesmenu item mouse leave event and change the background and text color to original colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void planner_menu2_MouseLeave(object sender, MouseEventArgs e)
        {
            planner_menu2.Background = new SolidColorBrush(Color.FromRgb(236, 255, 243));
            planner_menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(69, 177, 107));
        }


        /**
        *  \brief   planner_menu3_MouseEnter -- event handling of menu item mouse enter
        *  \details this method handlesmenu item mouse enter event and change the background and text color to accent colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void planner_menu3_MouseEnter(object sender, MouseEventArgs e)
        {
            planner_menu3.Background = new SolidColorBrush(Color.FromRgb(69, 177, 107));
            planner_menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(236, 255, 243));
        }


        /**
        *  \brief   planner_menu3_MouseLeave -- event handling of menu item mouse leave
        *  \details this method handlesmenu item mouse leave event and change the background and text color to original colors
        *  \param   sender object
        *  \param   MouseEventArgs e
        *  \returns NONE
        */

        private void planner_menu3_MouseLeave(object sender, MouseEventArgs e)
        {
            planner_menu3.Background = new SolidColorBrush(Color.FromRgb(236, 255, 243));
            planner_menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(69, 177, 107));
        }


        /**
        *  \brief   PlannerBackToMain_MouseLeftButtonDown -- event handling of menu item mouse click
        *  \details this method handles menu item mouse click event and lead to ChooseRole.xaml
        *  \param   sender object
        *  \param   MouseButtonEventArgs e
        *  \returns NONE
        */

        private void PlannerBackToMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseRole.xaml", UriKind.Relative));
        }

    }
}
