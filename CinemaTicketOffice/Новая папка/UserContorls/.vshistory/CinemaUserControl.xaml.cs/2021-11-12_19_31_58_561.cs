using CinemaTicketOffice.DateBase;
using System.Windows.Controls;
using System.Windows;

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для CinemaUserControl.xaml
    /// </summary>
    public partial class CinemaUserControl : UserControl
    {

        public cinemas cinema;
        public string Title { get; set; }
        public string ImageCinema { get; set; }

        public CinemaUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        public CinemaUserControl(cinemas cinema)
        {
            InitializeComponent();
            DataContext = this;
            this.cinema = cinema;
            Title = cinema.name;
            ImageCinema = "/resources/cinema/" + cinema.image;
        }

        public void InitCinema(cinemas cinema)
        {
            this.cinema = cinema;
            Title = cinema.name;
            ImageCinema = "resources/cinema/" + cinema.image;
        }

        private void mainGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Height =0;
            }
            
        }

        private void mainGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void mainGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
