using CinemaTicketOffice.DateBase;
using System.Windows.Controls;
using System;

namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для FilmInfoPage.xaml
    /// </summary>
    public partial class FilmInfoPage : Page
    {
        private film film;

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
        public FilmInfoPage(film film)
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
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            _actualDate = calendar.SelectedDate.Value.Date;
        }
    }
}
