using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaTicketOffice.DateBase;

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для SessionUserControl.xaml
    /// </summary>
    /// 
    public partial class SessionUserControl : UserControl
    {

        private Brush _color;
        public string Time { get; set; }

        public SessionUserControl()
        {
            InitializeComponent();
            _color = mainGrid.Background;
            DataContext = this;
        }
        public SessionUserControl(Session session)
        {
            InitializeComponent();
            _color = mainGrid.Background;
            DataContext = this;
            string[] time = session.time.ToString().Split(':');
            Time = $"{time[0]}:{time[1]}";
        }

        private void mainGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#E5F3DFBB");
            }
        }

        private void mainGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = _color;
            }
        }
        private void mainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#E5ECCC93");

            }
        }

        private void mainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#E5F3DFBB");
                //Manager.navigationFrame.Navigate(new FilmInfoPage(film));
            }
        }
    }
}
