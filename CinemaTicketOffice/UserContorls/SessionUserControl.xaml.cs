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
using CinemaTicketOffice.Code;
using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.pages;

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
        public Session Session { get; }

        public SessionUserControl()
        {
            InitializeComponent();
            _color = border.Background;
            DataContext = this;
        }
        public SessionUserControl(Session session)
        {
            InitializeComponent();
            _color = border.Background;
            DataContext = this;
            string[] time = session.time.ToString().Split(':');
            Time = $"{time[0]}:{time[1]}";
            Session = session;
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

        private void border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)new BrushConverter().ConvertFrom("#E5F3DFBB");
                Manager.session = Session;
                Manager.navigationFrame.Navigate(new HallPage(Session));
            }
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)new BrushConverter().ConvertFrom("#E5ECCC93");

            }
        }
    }
}
