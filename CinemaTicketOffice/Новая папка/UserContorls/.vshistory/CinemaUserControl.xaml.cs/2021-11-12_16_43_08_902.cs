using CinemaTicketOffice.DateBase;
using System.Windows.Controls;

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для CinemaUserControl.xaml
    /// </summary>
    public partial class CinemaUserControl : UserControl
    {

        cinemas cinema;
        public string Title { get; set; }
        public string Image { get; set; }

        public CinemaUserControl()
        {
            InitializeComponent();
        }
        public CinemaUserControl(cinemas cinema)
        {
            InitializeComponent();
            this.cinema = cinema;
            Title = cinema.name;
            Image = "resources/cinema/" + cinema.image;
        }

        public void InitCinema(cinemas cinema)
        {
            this.cinema = cinema;
            Title = cinema.name;
            Image = "resources/cinema/" + cinema.image;
        }

    }
}
