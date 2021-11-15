﻿using CinemaTicketOffice.Code;
using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.UserContorls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        private readonly Cinema cinema;

        public FilmPage(Cinema cinema)
        {
            InitializeComponent();
            Manager.mainPage.btnBack.Visibility = Visibility.Visible;
            try
            {
                System.Data.Entity.DbSet<Film> films = ModelCinemaHandler.getContext().Films1;
                System.Data.SqlClient.SqlParameter cinemaParam = new System.Data.SqlClient.SqlParameter("@cinema_id", cinema.cinema_id);
                List<Film> filmsSelect = films.SqlQuery("SELECT * FROM films WHERE film_id IN (SELECT DISTINCT film_id FROM sessions WHERE cinema_id = 2);", cinemaParam).ToList();
                foreach (var session in filmsSelect)
                {
                    spFilms.Children.Add(new FilmUserControl(session.film));
                }
            }
            catch (Exception)
            {

                throw;
            }

            this.cinema = cinema;
        }
    }
}
