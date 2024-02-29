using System;
using System.IO;
using Android.OS;
using DBFirstApproach.Droid.SQLite;
using DBFirstApproach.SQLIte;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLIte_Android))]
namespace DBFirstApproach.Droid.SQLite
{
	public class SQLIte_Android : ISQLite
    {
        public string GetFilePath(string filenmae)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filenmae);
            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(filenmae)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            return path;
        }
    }
}

