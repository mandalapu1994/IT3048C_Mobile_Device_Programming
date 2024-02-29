using System;
using CodeFirstApproach.SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeFirstApproach
{
    public partial class App : Application
    {
        public static SQLiteOperations DBConnection;
        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
        public static SQLiteOperations Database
        {
            get
            {
                if (DBConnection == null)
                {
                    DBConnection = new SQLiteOperations();
                }
                return DBConnection;
            }

        }
    }
}

