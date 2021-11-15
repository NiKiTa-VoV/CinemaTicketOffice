using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.UserContorls;
using System;
using System.Windows.Controls;

namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для HallPage.xaml
    /// </summary>


    public partial class HallPage : Page
    {

        public String FilmName { get; set; }
        public String CinemaName { get; set; }
        public String DateTimeText { get; set; }


        public HallPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        public HallPage(Session session)
        {
            InitializeComponent();
            DataContext = this;
            FilmName = session.film.name;
            CinemaName = session.cinema.name;
            DateTimeText = session.date.ToString("dd MMMM, ddd, ");
            int minutesTemp = session.time.Minutes;
            String minutes = minutesTemp < 10 ? "0" + minutesTemp : "" + minutesTemp;
            DateTimeText += $"{session.time.Hours}:{minutes}";
            InitPlaces();
        }

        private void InitPlaces()
        {
            for (int i = 1; i <= 8; i++)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                spHall.Children.Add(stackPanel);
                for (int j = 1; j <= 13; j++)
                {
                    stackPanel.Children.Add(new PlaceUserControl(j, i, this));
                }
            }
        }
    }
}
