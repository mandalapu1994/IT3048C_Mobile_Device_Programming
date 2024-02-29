using System;
using System.IO;
using SQLite;
using CodeFirstApproach.iOS.SQLite;
using Xamarin.Forms;
using CodeFirstApproach.SQLite;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace CodeFirstApproach.iOS.SQLite
{
	public class SQLite_iOS : ISQLite
    {
		public SQLite_iOS()
		{
		}
        public SQLiteAsyncConnection GetConnection()
        {
            var sqlitename = "SampleDB.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);// Documents folder
            var libraryPath = Path.Combine(documentsPath, "..", "Library");// Library folder
            var path = Path.Combine(libraryPath, sqlitename);
            // Create the connection
            var connection = new SQLiteAsyncConnection(path);
            // Return the database connection
            return connection;
        }
    }
}

