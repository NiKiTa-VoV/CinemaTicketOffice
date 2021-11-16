using CinemaTicketOffice.Code;
using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.UserContorls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


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
                System.Data.Entity.DbSet<Film> films = ModelCinemaHandler.getContext().films;
                System.Data.SqlClient.SqlParameter cinemaParam = new System.Data.SqlClient.SqlParameter("@cinema_id", cinema.cinema_id);
                List<Film> filmsSelect = films.SqlQuery("SELECT * FROM films WHERE film_id IN (SELECT DISTINCT film_id FROM sessions WHERE cinema_id = @cinema_id)", cinemaParam).ToList();
                foreach (var film in filmsSelect)
                {
                    spFilms.Children.Add(new FilmUserControl(film));
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
