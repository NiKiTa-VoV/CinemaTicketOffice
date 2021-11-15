using CinemaTicketOffice.Code;
using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.pages;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для CinemaUserControl.xaml
    /// </summary>
    public partial class CinemaUserControl : UserControl
    {

        private Brush _color;
        public Cinema cinema;
        public string Title { get; set; }
        public string ImageCinema { get; set; }

        public CinemaUserControl()
        {
            InitializeComponent();
            _color = mainGrid.Background;
            DataContext = this;
        }
        public CinemaUserControl(Cinema cinema)
        {
            InitializeComponent();
            _color = mainGrid.Background;
            DataContext = this;
            this.cinema = cinema;
            Title = cinema.name;
            ImageCinema = "/resources/cinema/" + cinema.image;

        }

        private void mainGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#7FD0D0D0");
            }

        }

        private void mainGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = _color;
            }
        }


        private void mainGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#7FD0D0D0");
                Manager.cinema = cinema;
                Manager.navigationFrame.Navigate(new FilmPage(cinema));
            }
        }

        private void mainGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#CCD0D0D0");
            }
        }
    }
}
