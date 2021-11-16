using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.Code;
using CinemaTicketOffice.UserContorls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для HallPage.xaml
    /// </summary>


    public partial class HallPage : Page
    {
        private List<PlaceUserControl> _places = new List<PlaceUserControl>();

        private bool[,] _placesArrayBooked = new bool[8, 13];
        private bool[,] _placesArraySelected = new bool[8, 13];

        public const int MaxCount = 3;
        private readonly Session session;

        public String FilmName { get; set; }
        public String CinemaName { get; set; }
        public String DateTimeText { get; set; }
        public String TypeSession { get; set; }
        public int Count { get => _places.Count; }



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
            TypeSession = session.type_sessions.name;
            DateTimeText = session.date.ToString("dd MMMM, ddd, ");
            int minutesTemp = session.time.Minutes;
            String minutes = minutesTemp < 10 ? "0" + minutesTemp : "" + minutesTemp;
            DateTimeText += $"{session.time.Hours}:{minutes}";
            this.session = session;
            InitSelectedPlaces();
            InitBookedPlaces();
            InitPlaces();
            RefreshInfo();
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
                    stackPanel.Children.Add(new PlaceUserControl(j, i, _placesArraySelected[i - 1, j - 1], _placesArrayBooked[i - 1, j - 1], this));
                }
            }
        }

        public void AddPlace(PlaceUserControl place)
        {
            _places.Add(place);
            RefreshInfo();
        }

        public void RemovePlace(PlaceUserControl place)
        {
            _places.Remove(place);
            RefreshInfo();
        }

        public void RefreshInfo()
        {
            tbCount.Text = $"({Count}/{MaxCount})";
            tbListTicket.Text = "";
            List<String> list = new List<String>();
            foreach (var place in _places)
            {
                list.Add($"{place.Row}:{place.Place}; ");
            }
            list.Sort();
            foreach (var place in list)
            {
                tbListTicket.Text += place;
            }
        }

        private void InitBookedPlaces()
        {
            try
            {
                var reservations = ModelCinemaHandler.getContext().Reservations1;
                SqlParameter sessionParam = new SqlParameter("@session_id", session.session_id);
                System.Data.Entity.Infrastructure.DbSqlQuery<Reservation> reservationsSelect = reservations.SqlQuery("SELECT * FROM reservations WHERE session_id = @session_id", sessionParam);
                foreach (var reservation in reservationsSelect)
                {
                    _placesArrayBooked[reservation.row - 1, reservation.place - 1] = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void InitSelectedPlaces()
        {
            try
            {
                var reservations = ModelCinemaHandler.getContext().Reservations1;
                SqlParameter sessionParam = new SqlParameter("@session_id", session.session_id);
                SqlParameter clientParam = new SqlParameter("@client_id", Manager.client.user_id);
                System.Data.Entity.Infrastructure.DbSqlQuery<Reservation> reservationsSelect = reservations.SqlQuery("SELECT * FROM reservations WHERE session_id = @session_id AND client_id = @client_id", sessionParam, clientParam);
                foreach (var reservation in reservationsSelect)
                {
                    _placesArraySelected[reservation.row - 1, reservation.place - 1] = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
