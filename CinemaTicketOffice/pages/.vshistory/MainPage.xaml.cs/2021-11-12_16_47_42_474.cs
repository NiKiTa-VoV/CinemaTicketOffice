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
            try
            {
                CinemaEntities cinemaEntities = ModelCinemaHandler.getContext();
                System.Data.Entity.DbSet<cinemas> cinemas = cinemaEntities.cinemas;
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
