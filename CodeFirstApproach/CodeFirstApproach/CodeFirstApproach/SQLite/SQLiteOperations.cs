using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using SQLite;
using Xamarin.Forms;
using static CodeFirstApproach.SQLite.Tables;

namespace CodeFirstApproach.SQLite
{
	public class SQLiteOperations
	{
        #region Global Variables 
        private static SQLiteAsyncConnection _sqLiteConnection;
        public static int DBVersionNumber = 1;
        #endregion
        #region Constructor
        public SQLiteOperations()
		{
            try
            {
                _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }
        #endregion
        #region Setup DB
        public static async Task InitializeDB()
        {
            try
            {
                _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
                await SetupDB();
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }
        private static async Task SetupDB()
        {
            try
            {
                List<DBVersion> DBVersion = DBServices.GetDBVersionDetails().Result;
                if (DBVersion != null && DBVersion.Count > 0 && DBVersion[0].DBVersionNumber < DBVersionNumber)
                {
                    await ResetDB();
                }
                else if (DBVersion[0].DBVersionNumber == DBVersionNumber)
                {
                    return;
                }
                else
                {
                    await InitTables();
                }
            }
            catch
            {
                await InitTables();
            }
        }
        #endregion

        #region Resetting DB
        public static async Task ResetDB()
        {
            await DeleteTables();
            await InitTables();
        }
        #endregion

        #region Initialize DB
        private static async Task InitTables()
        {
            await CreateTables();
            await DBServices.InsertDBVersionNumber();
        }
        #endregion
        #region Create Tables
        private static async Task CreateTables()
        {
            // Create Your New Table Here
            await _sqLiteConnection.CreateTableAsync<DBVersion>();
            await _sqLiteConnection.CreateTableAsync<User>();
        }
        #endregion
        #region Deleting Tables
        private static async Task DeleteTables()
        {
            //Drop the created tables here
            await _sqLiteConnection.DropTableAsync<DBVersion>();
            await _sqLiteConnection.DropTableAsync<User>();
        }
        #endregion
        public SQLiteAsyncConnection DBConnection()
        {
            return _sqLiteConnection;
        }
    }
}

