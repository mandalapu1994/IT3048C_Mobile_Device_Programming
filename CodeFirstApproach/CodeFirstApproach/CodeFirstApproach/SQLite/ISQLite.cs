using System;
using SQLite;

namespace CodeFirstApproach.SQLite
{
	public interface ISQLite
	{
        SQLiteAsyncConnection GetConnection();
    }
}

