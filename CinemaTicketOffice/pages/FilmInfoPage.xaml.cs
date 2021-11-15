using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.UserContorls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

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
            RefreshSessions();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            _actualDate = calendar.SelectedDate.Value.Date;
            RefreshSessions();
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

        private void RefreshSessions()
        {
            wp2d.Children.Clear();
            wp3d.Children.Clear();
            wpImax2d.Children.Clear();
            wpImax3d.Children.Clear();
            foreach (var session in GetActualSessions(_actualDate))
            {
                switch (session.type_session_id)
                {
                    case 1:
                        wp2d.Children.Add(new SessionUserControl(session));
                        break;
                    case 2:
                        wp3d.Children.Add(new SessionUserControl(session));
                        break;
                    case 3:
                        wpImax2d.Children.Add(new SessionUserControl(session));
                        break;
                    case 4:
                        wpImax3d.Children.Add(new SessionUserControl(session));
                        break;
                }
            }
            if (wp2d.Children.Count > 0)
            {
                tb2d.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                tb2d.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (wp3d.Children.Count > 0)
            {
                tb3d.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                tb3d.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (wpImax2d.Children.Count > 0)
            {
                tbImax2d.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                tbImax2d.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (wpImax3d.Children.Count > 0)
            {
                tbImax3d.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                tbImax3d.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}