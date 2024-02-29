using System;
using System.IO;
using DBFirstApproach.iOS.SQLite;
using Foundation;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace DBFirstApproach.iOS.SQLite
{
	public class SQLite_iOS
	{
        public string GetFilePath(String fileName)
        {
            string libFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Documents", "Database");
            Console.WriteLine(libFolder);
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            string _dbpath = Path.Combine(libFolder, fileName);
            CopyDatabaseIfNotExists(_dbpath);
            return _dbpath;
        }
        private static void CopyDatabaseIfNotExists(string dbPath)
        {
            Console.WriteLine("The database path is ", dbPath);
            if (!File.Exists(dbPath))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("sampledb", "db");
                File.Copy(existingDb, dbPath);
            }
        }
    }
}

