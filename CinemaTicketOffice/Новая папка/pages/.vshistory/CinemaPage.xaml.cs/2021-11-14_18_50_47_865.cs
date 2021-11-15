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
using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.Code;
using CinemaTicketOffice.UserContorls;

namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для CinemaPage.xaml
    /// </summary>
    public partial class CinemaPage : Page
    {
        public CinemaPage()
        {
            InitializeComponent();
            Manager.mainPage.btnBack.Visibility = Visibility.Collapsed;
            try
            {
                CinemaEntities cinemaEntities = ModelCinemaHandler.getContext();
                System.Data.Entity.DbSet<Cinema> cinemas = cinemaEntities.Cinemas1;
                foreach (var cinema in cinemas)
                {
                    spCinemas.Children.Add(new CinemaUserControl(cinema));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
