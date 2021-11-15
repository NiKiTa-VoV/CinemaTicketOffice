using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.UserContorls;
using System.Windows.Controls;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для FilmInfoPage.xaml
    /// </summary>
    public partial class FilmInfoPage : Page
    {
        private Film film;

        private DateTime _actualDate;
        public string TitleFilm { get; set; }
        public string ImageFilm { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }

        public FilmInfoPage()
        {
            InitializeComponent();
            DataContext = this;
        }
        public FilmInfoPage(Film film)
        {
            InitializeComponent();
            DataContext = this;
            this.film = film;
            TitleFilm = film.name;
            Rating = film.rating;
            Description = film.description;
            ImageFilm = "/resources/film/" + film.image;
            calendar.DisplayDateStart = DateTime.Today;
            _actualDate = DateTime.Today;
            calendar.DisplayDateEnd = DateTime.Today.AddDays(5);
            foreach (var session in GetActualSessions(_actualDate))
            {
                wpSession.Children.Add(new SessionUserControl(session));
            }
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            _actualDate = calendar.SelectedDate.Value.Date;
        }

        private List<Session> GetActualSessions(DateTime dateTime)
        {
            try
            {
                System.Data.Entity.DbSet<Session> sessions = ModelCinemaHandler.getContext().Sessions1;
                string v = dateTime.Date.ToString().Split(' ')[0];
                System.Data.SqlClient.SqlParameter dateParam = new System.Data.SqlClient.SqlParameter("@date", dateTime.Date.ToString().Split(' ')[0]);
                System.Data.SqlClient.SqlParameter filmParam = new System.Data.SqlClient.SqlParameter("@film_id", film.film_id);
                List<Session> sessions1 = sessions.SqlQuery($"SELECT * FROM sessions WHERE date = @date AND film_id = @film_id", dateParam, filmParam).ToList();
                return sessions1;
            }
            catch
            {
                ;
            }
            return null;
        }
    }
}