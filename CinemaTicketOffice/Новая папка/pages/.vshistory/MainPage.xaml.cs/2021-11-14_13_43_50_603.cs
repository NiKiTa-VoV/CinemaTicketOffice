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
using CinemaTicketOffice.UserContorls;
using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.Code;
using CinemaTicketOffice.pages;

namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Manager.mainPage = this;
            Manager.navigationFrame = navigationFrame;
            Manager.navigationFrame.Navigate(new CinemaPage());
            btnBack.Visibility = Visibility.Collapsed;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (navigationFrame.CanGoBack)
            {
                navigationFrame.NavigationService.GoBack();
                if (!navigationFrame.CanGoBack)
                {
                    btnBack.Visibility = Visibility.Collapsed;
                }
            }
        }
        
        public Button GetBtnBack()
        {
            return btnBack;
        }
    }
}
