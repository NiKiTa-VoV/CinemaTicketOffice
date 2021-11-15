﻿using CinemaTicketOffice.DateBase;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private void mainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#CCD0D0D0");
            }
        }

        private void mainGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#7FD0D0D0");
            }
        }

        private void mainGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = _color;
            }
        }

        private void mainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.Background = (Brush)new BrushConverter().ConvertFrom("#7FD0D0D0");
            }
        }
    }
}
