using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ECS_LoginSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminStaffList : Page
    {
        public AdminStaffList()
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tashm.DESKTOP-I7K0SHQ\Documents\Staff.mdf;Integrated Security=True;Connect Timeout=30";
            this.InitializeComponent();
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Staff";
            SqlDataReader dr = command.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ListViewItem lvItem = new ListViewItem();
                    
                }
            }
            
        }

        private void addStaff_Click(object sender, RoutedEventArgs e)
        {


        }



        private void deleteStaff_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
