using System;
using SQLite;

namespace DBFirstApproach.SQLIte
{
	public interface ISQLite
	{
        string GetFilePath(string filenmae);
    }
}

