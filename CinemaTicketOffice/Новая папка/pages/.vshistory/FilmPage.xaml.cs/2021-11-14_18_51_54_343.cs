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
using CinemaTicketOffice.UserContorls;
using CinemaTicketOffice.Code;


namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        private readonly Cinema cinema;

        public FilmPage(Cinema cinema)
        {
            InitializeComponent();
            Manager.mainPage.btnBack.Visibility = Visibility.Visible;
            try
            {
                foreach (var session in cinema.dependentSessions)
                {
                    spFilms.Children.Add(new FilmUserControl(session.film));
                }
            }
            catch (Exception)
            {

                throw;
            }

            this.cinema = cinema;
        }
    }
}
