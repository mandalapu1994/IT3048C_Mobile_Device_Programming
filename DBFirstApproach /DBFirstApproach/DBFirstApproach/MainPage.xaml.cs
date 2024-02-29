using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFirstApproach.SQLIte;
using Xamarin.Forms;

namespace DBFirstApproach
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
            List<User> _usersList = App.Database.GetUserDetails().Result;
            UsersList.ItemsSource = null;
            UsersList.ItemsSource = _usersList;
            UsersList.IsRefreshing = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadUsers();
        }

        async void RegisterUser_Clicked(System.Object sender, System.EventArgs e)
        {
            await App.Database.InsertUserDetails(UserName.Text, Password.Text);
            UserName.Text = "";
            Password.Text = "";
            LoadUsers();

        }
    }
}

