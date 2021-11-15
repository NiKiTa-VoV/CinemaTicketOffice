using CinemaTicketOffice.DateBase;
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
            DateTimeText = session.date.ToString("dd MMMM, ddd, HH:mm");
        }
    }
}
