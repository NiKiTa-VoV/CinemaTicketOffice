using CinemaTicketOffice.pages;
using CinemaTicketOffice.Code;
using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.UserContorls;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для PlaceUserControl.xaml
    /// </summary>
    public partial class PlaceUserControl : UserControl
    {
        private Brush _color;
        private readonly HallPage page;

        public int Place { get; set; }
        public int Row { get; set; }
        public PlaceUserControl()
        {
            InitializeComponent();
            _color = border.Background;
            DataContext = this;
        }

        public PlaceUserControl(int place, int row, HallPage page)
        {
            InitializeComponent();
            _color = border.Background;
            DataContext = this;
            Place = place;
            Row = row;
            this.page = page;
        }

        private void border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)new BrushConverter().ConvertFrom("#E5F3DFBB");
            }
        }

        private void border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = _color;
            }
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)new BrushConverter().ConvertFrom("#E5ECCC93");

            }
        }

        private void border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)new BrushConverter().ConvertFrom("#E5F3DFBB");
                Manager.session = Session;
                Manager.navigationFrame.Navigate(new HallPage(Session));
            }
        }
    }
}
