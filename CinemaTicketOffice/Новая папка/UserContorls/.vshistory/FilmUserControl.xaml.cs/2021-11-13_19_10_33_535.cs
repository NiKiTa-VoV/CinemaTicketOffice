using CinemaTicketOffice.DateBase;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System;

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для FilmUserControl.xaml
    /// </summary>
    public partial class FilmUserControl : UserControl
    {
        private Brush _color;
        public film film;
        public decimal Rating { get; set; } 
        public int Duration { get; set; } 
        public string Date { get; set; } 
        public string Title { get; set; }
        public string ImageFilm { get; set; }
        public FilmUserControl()
        {
            InitializeComponent();
            _color = mainGrid.Background;
            DataContext = this;
        }

        public FilmUserControl(film film)
        {
            InitializeComponent();
            _color = mainGrid.Background;
            DataContext = this;
            this.film = film;
            Title = film.name;
            Rating = film.rating;
            Duration = film.duration;
            Date = film.release_date.ToString("d");
            ImageFilm = "/resources/film/" + film.image;
        }

        private void mainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#CCD0D0D0");
            }
        }

        private void mainGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#7FD0D0D0");
            }
        }

        private void mainGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = _color;
            }
        }

        private void mainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#7FD0D0D0");
            }
        }
    }
}
