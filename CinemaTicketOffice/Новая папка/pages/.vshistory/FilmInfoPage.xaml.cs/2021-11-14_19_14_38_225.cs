using CinemaTicketOffice.DateBase;
using System.Windows.Controls;
using System;
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
            foreach (var session in film.dependentSessions)
            {

            }
            wpSession.Children.Add();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            _actualDate = calendar.SelectedDate.Value.Date;
        }

        private List<Session> GetActualSessions(DateTime dateTime)
        {
            try
            {
                System.Data.Entity.DbSet<Film> films1 = ModelCinemaHandler.getContext().Films1;
                System.Data.SqlClient.SqlParameter dateParam = new System.Data.SqlClient.SqlParameter("@date", dateTime.ToString());
                System.Data.SqlClient.SqlParameter filmParam = new System.Data.SqlClient.SqlParameter("@film_id", film.film_id);
                System.Data.Entity.Infrastructure.DbSqlQuery<Film> films = films1.SqlQuery($"SELECT * FROM sessions WHERE date = @date AND film_id = @film_id", dateParam, filmParam);
                films.T
            }
            catch
            {
                ;
            }
        }
    }
}