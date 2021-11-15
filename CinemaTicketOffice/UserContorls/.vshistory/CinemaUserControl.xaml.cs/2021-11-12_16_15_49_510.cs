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

        public CinemaUserControl(cinemas cinema)
        {
            this.cinema = cinema;
            Title = cinema.name;
            Image = "resources/cinema/" + cinema.image;
            InitializeComponent();
        }
    }
}
