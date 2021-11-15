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
        public string Time { get; set; }

        public SessionUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        public SessionUserControl(Session session)
        {
            InitializeComponent();
            DataContext = this;
            string[] times = session.time.ToString().Split(':');
            Time = session.time.ToString();
        }
    }
}
