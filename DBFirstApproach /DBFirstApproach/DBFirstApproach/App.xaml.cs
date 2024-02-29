using System;
using DBFirstApproach.SQLIte;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBFirstApproach
{
    public partial class App : Application
    {
        public static SQLiteOperations DBConnection;
        public static string DBName = "sampledb.db";
        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
            try
            {
                DBConnection = new SQLiteOperations(DependencyService.Get<ISQLite>().GetFilePath(DBName));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
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
                    DBConnection = new SQLiteOperations(DependencyService.Get<ISQLite>().GetFilePath(DBName));
                }
                return DBConnection;
            }

        }
    }
}

