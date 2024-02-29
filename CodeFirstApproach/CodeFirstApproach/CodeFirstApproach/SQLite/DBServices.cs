
using System;
using static CodeFirstApproach.SQLite.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApproach.SQLite
{
	public class DBServices
	{
        #region Application Information Table Info Related Services
        #region Operations for DBVersion Table
        //Insert or Update Version Number
        public static async Task<bool> InsertDBVersionNumber()
        {
            bool result = false;

            DBVersion DBVersion = new DBVersion();
            DBVersion.SNo = 1;
            DBVersion.DBVersionNumber = SQLiteOperations.DBVersionNumber;
            try
            {
                await App.Database.DBConnection().InsertAsync(DBVersion);
                result = true;
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
                try
                {
                    await App.Database.DBConnection().UpdateAsync(DBVersion);
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
        public static Task<List<DBVersion>> GetDBVersionDetails()
        {
            Task<List<DBVersion>> DBVersionDetails = null;
            try
            {
                DBVersionDetails = App.Database.DBConnection().Table<DBVersion>().Where(x => x.SNo == 1).ToListAsync();
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
        public static async Task<bool> InsertUserDetails(string UserName, string Password)
        {
            bool result = false;
            User NewUser = new User();
            NewUser.UserName = UserName;
            NewUser.Password = Password;
            try
            {
                await App.Database.DBConnection().InsertAsync(NewUser);
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return result;
        }
        public static Task<List<User>> GetUserDetails()
        {
            Task<List<User>> StudentsDetails = null;
            try
            {
                StudentsDetails = App.Database.DBConnection().Table<User>().OrderBy(x => x.UserName).ToListAsync();
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return StudentsDetails;
        }
        #endregion
    }
}

