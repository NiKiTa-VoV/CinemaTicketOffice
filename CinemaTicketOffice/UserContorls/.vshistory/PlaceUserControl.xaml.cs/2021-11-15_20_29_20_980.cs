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

namespace CinemaTicketOffice.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для PlaceUserControl.xaml
    /// </summary>
    public partial class PlaceUserControl : UserControl
    {
        private Brush _color;
        public int Place { get; set; }
        public int Row { get; set; }
        public PlaceUserControl()
        {
            InitializeComponent();
            _color = border.Background;
            DataContext = this;
        }

        public PlaceUserControl(int place, int row)
        {
            InitializeComponent();
            _color = border.Background;
            DataContext = this;
            Place = place;
            Row = row;
        }
    }
}
