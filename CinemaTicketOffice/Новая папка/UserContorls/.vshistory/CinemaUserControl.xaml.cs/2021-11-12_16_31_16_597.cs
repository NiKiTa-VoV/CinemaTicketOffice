using CinemaTicketOffice.DateBase;
using System.Windows.Controls;

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для CinemaUserControl.xaml
    /// </summary>
    public partial class CinemaUserControl1 : UserControl
    {

        cinemas cinema;
        public string Title { get; set; }
        public string Image { get; set; }

        public CinemaUserControl1()
        {
            InitializeComponent();
        }

        public void InitCinema(cinemas cinema)
        {
            this.cinema = cinema;
            Title = cinema.name;
            Image = "resources/cinema/" + cinema.image;
        }

    }
}
