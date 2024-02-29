using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstApproach.SQLite;
using Xamarin.Forms;
using static CodeFirstApproach.SQLite.Tables;

namespace CodeFirstApproach
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void LoadUsers()
        {
            UsersList.IsRefreshing = true;
            List<User> _usersList = DBServices.GetUserDetails().Result;
            UsersList.ItemsSource = null;
            UsersList.ItemsSource = _usersList;
            UsersList.IsRefreshing = false;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await SQLiteOperations.InitializeDB();
            LoadUsers();
        }

        async void RegisterUser_Clicked(System.Object sender, System.EventArgs e)
        {
            await DBServices.InsertUserDetails(UserName.Text, Password.Text);
            UserName.Text = "";
            Password.Text = "";
            LoadUsers();
        }
    }
}

