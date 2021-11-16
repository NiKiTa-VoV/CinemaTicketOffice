using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using CinemaTicketOffice.DateBase;
using CinemaTicketOffice.Code;
using System.Collections.Generic;

namespace CinemaTicketOffice.pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private bool IsWarning = false;
        private string password = "";
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pbPassword.Visibility == Visibility.Visible)
            {
                tbPassword.Visibility = Visibility.Visible;
                pbPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbPassword.Visibility = Visibility.Collapsed;
                pbPassword.Visibility = Visibility.Visible;
            }
        }

        private void Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (pbPassword.Visibility == Visibility.Visible)
            {
                tbPassword.Text = pbPassword.Password;
                password = pbPassword.Password;
            }
            else
            {
                pbPassword.Password = tbPassword.Text;
                password = tbPassword.Text;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Data.Entity.DbSet<Client> clients = ModelCinemaHandler.getContext().clients;
                System.Data.SqlClient.SqlParameter loginParam = new System.Data.SqlClient.SqlParameter("@login", tbLogin.Text);
                System.Data.SqlClient.SqlParameter passwordParam = new System.Data.SqlClient.SqlParameter("@password", password);
                List<Client> clientsSelect = clients.SqlQuery($"SELECT * FROM clients WHERE login = @login AND password = @password", loginParam, passwordParam).ToList();
                if (clientsSelect.Count == 0)
                {
                    IsWarning = true;
                }
                else
                {

                    Manager.client = clientsSelect.ElementAt(0);
                    Manager.mainFrame.Navigate(new MainPage());
                }
                if (IsWarning)
                {
                    tbWarn.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                ;
            }
        }
    }
}
