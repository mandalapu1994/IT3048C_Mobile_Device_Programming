using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using SQLite;
using Xamarin.Forms;

namespace DBFirstApproach.SQLIte
{
	public class SQLiteOperations
	{
        #region Global Variables 
        readonly SQLiteAsyncConnection database;
        public static int DBVersionNumber = 1;
        #endregion

        public SQLiteOperations(string dbpath)
		{
            database = GetAsyncConnection(dbpath);
        }
        public SQLiteAsyncConnection GetAsyncConnection(string path)
        {
            try
            {
                var conn = new SQLiteAsyncConnection(path);
                return conn;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        #region DB Operations

        #region Application Information Table Info Related Services
        #region Operations for DBVersion Table
        //Insert or Update Version Number
        public async Task<bool> InsertDBVersionNumber()
        {
            bool result = false;

            DBVersion DBVersion = new DBVersion();
            DBVersion.SNo = 1;
            DBVersion.DBVersionNumber = SQLiteOperations.DBVersionNumber;
            try
            {
                await database.InsertAsync(DBVersion);
                result = true;
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
                try
                {
                    await database.UpdateAsync(DBVersion);
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message.ToString());
                    result = false;
                }
            }
            return result;
        }
        #endregion
        #region Getting Version Number
        public Task<List<DBVersion>> GetDBVersionDetails()
        {
            Task<List<DBVersion>> DBVersionDetails = null;
            try
            {
                DBVersionDetails = database.Table<DBVersion>().Where(x => x.SNo == 1).ToListAsync();
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return DBVersionDetails;
        }
        #endregion
        #endregion

        #region User Related
        public async Task<bool> InsertUserDetails(string UserName, string Password)
        {
            bool result = false;
            User NewUser = new User();
            NewUser.UserName = UserName;
            NewUser.Password = Password;
            try
            {
                await database.InsertAsync(NewUser);
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return result;
        }
        public Task<List<User>> GetUserDetails()
        {
            Task<List<User>> StudentsDetails = null;
            try
            {
                StudentsDetails = database.Table<User>().OrderBy(x => x.UserName).ToListAsync();
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return StudentsDetails;
        }
        #endregion
        #endregion
    }
}

