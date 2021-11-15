using CinemaTicketOffice.DateBase;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для CinemaUserControl.xaml
    /// </summary>
    public partial class CinemaUserControl : UserControl
    {

        public cinemas cinema;
        public string Title { get; set; }
        public Image ImageCinema { get; set; }
        public ImageSource Source { get; set; }

        public CinemaUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        public CinemaUserControl(cinemas cinema)
        {
            InitializeComponent();
            DataContext = this;
            InitCinema(cinema);
        }

        public void InitCinema(cinemas cinema)
        {
            this.cinema = cinema;
            Title = cinema.name;
            InitImage(cinema.image);
        }

        private void InitImage(string nameCinema)
        {
            Source = new BitmapImage(new Uri("/resources/cinema/" + nameCinema, UriKind.Relative));
        }

    }
}
