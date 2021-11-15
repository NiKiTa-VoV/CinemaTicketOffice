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
    /// Логика взаимодействия для FilmUserControl.xaml
    /// </summary>
    public partial class FilmUserControl : UserControl
    {
        private Brush _color;
        public films film;
        public string Title { get; set; }
        public string ImageCinema { get; set; }
        public FilmUserControl()
        {
            InitializeComponent();
            _color = mainGrid.Background;
            DataContext = this;
        }
    }
}
