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
        private bool booked;

        public int Place { get; set; }
        public int Row { get; set; }
        public PlaceUserControl()
        {
            InitializeComponent();
            _color = border.Background;
            DataContext = this;
        }

        public PlaceUserControl(int place, int row, bool selected, bool booked, HallPage page)
        {
            InitializeComponent();
            _color = border.Background;
            if (selected)
            {
                border.Background = (Brush)new BrushConverter().ConvertFrom("#FF948BBD");
                page.AddPlace(this);
            }
            if (booked && !selected)
            {
                border.Background = (Brush)new BrushConverter().ConvertFrom("#FFA7A1A7");
            }
            DataContext = this;
            Place = place;
            Row = row;
            this.selected = selected;
            this.booked = booked && !selected;
            this.page = page;
        }

        private void border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                if (booked)
                {
                    return;
                }
                if (!selected)
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FFA475A7");
                }
                else
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FFC4B9F4");
                }
            }
        }

        private void border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                if (booked)
                {
                    return;
                }
                if (!selected)
                {
                    border.Background = _color;
                }
                else
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FF948BBD");
                }
            }
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                if (booked)
                {
                    return;
                }
                if (!selected)
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FF9B709E");
                }
                else
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FF8E83C3");
                }
            }
        }

        private void border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                if (booked)
                {
                    return;
                }
                if (!selected)
                {
                    if (page.Count >= HallPage.MaxCount)
                    {
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFA475A7");
                    }
                    else
                    {
                        page.AddPlace(this);
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFC4B9F4");
                        selected = !selected;
                    }
                }
                else
                {
                    page.RemovePlace(this);
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FFA475A7");
                    selected = !selected;
                }
            }
        }
    }
}
