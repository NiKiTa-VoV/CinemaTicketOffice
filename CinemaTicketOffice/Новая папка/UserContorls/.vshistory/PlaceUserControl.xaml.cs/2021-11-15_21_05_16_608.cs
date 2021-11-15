using CinemaTicketOffice.pages;
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
        private bool selected;


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
                if (selected)
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FFBA8BBD");
                }
                else
                {

                }
            }
        }

        private void border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                if (selected)
                {
                    border.Background = _color;
                }
                else
                {

                }
            }
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                if (selected)
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FF9B709E");
                }
                else
                {

                }
            }
        }

        private void border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {if (selected)
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FFBA8BBD");
                    selected = false;
                }
                else
                {
                    selected = true;
                }
            }
        }
    }
}
