using System;
using SQLite;

namespace CodeFirstApproach.SQLite
{
	public class Tables
	{
        #region Tables required for Application Information
        public class DBVersion
        {
            [PrimaryKey]
            [AutoIncrement]
            public int SNo { get; set; }
            public int DBVersionNumber { get; set; }
        }
        #endregion
        #region User Tables
        public class User
        {
            [PrimaryKey,]
            [AutoIncrement]
            public int ID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        #endregion
    }
}

