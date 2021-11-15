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
                IEnumerable<Session> sessionsSelect = cinema.dependentSessions.Distinct();

                //System.Data.Entity.DbSet<Session> sessions = ModelCinemaHandler.getContext().Sessions1;
                //System.Data.SqlClient.SqlParameter cinemaParam = new System.Data.SqlClient.SqlParameter("@cinema_id", cinema.cinema_id);
                //List<Session> sessionsSelect = sessions.SqlQuery($"SELECT * FROM sessions WHERE cinema_id = @cinema_id", cinemaParam).ToList();
                foreach (var session in sessionsSelect)
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
