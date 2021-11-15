using CinemaTicketOffice.DateBase;
using System.Windows.Controls;

namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для FilmInfoPage.xaml
    /// </summary>
    public partial class FilmInfoPage : Page
    {
        private film film;
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
        }
    }
}
