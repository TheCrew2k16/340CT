using System;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
namespace CoursworkPart2
{
    public sealed partial class MainPage : Page
    {
        private String connect;
        private SqlConnection connection;
        public MainPage()
        {
            this.InitializeComponent();
        }


        private bool validate(string user, string pass, string staffRole)
        {
            SqlConnection connect = new SqlConnection("Data Source=340-server.database.windows.net;Initial Catalog=TestDatabase;Integrated Security=False;User ID=test;Password=340-server;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connect.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Select * from LoginTable where username=@username and password=@password and role=@role";
            sqlCommand.Parameters.AddWithValue("@username", user);
            sqlCommand.Parameters.AddWithValue("@password", pass);
            sqlCommand.Parameters.AddWithValue("@role", staffRole);
            sqlCommand.Connection = connection;
            SqlDataReader login = sqlCommand.ExecuteReader();
            if (login.Read())
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            string staffRole = "staff";
            string studentRole = "student";
            if (user == "" || pass == "")
            {
                return;
            }
            bool r = validate(user, pass, staffRole);
            if (r)
            {
                var frame = new Frame();
                frame.Navigate(typeof(StaffPage), null);
                Window.Current.Content = frame;
                Window.Current.Activate();
            }
            else
            {
                var frame = new Frame();
                frame.Navigate(typeof(StudentPage), null);
                Window.Current.Content = frame;
                Window.Current.Activate();
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void studentDebug_Click(object sender, RoutedEventArgs e)
        {
            var frame = new Frame();
            frame.Navigate(typeof(StudentPage), null);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }

        private void staffDebug_Click(object sender, RoutedEventArgs e)
        {
            var frame = new Frame();
            frame.Navigate(typeof(StaffPage), null);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }

       
    }
}
