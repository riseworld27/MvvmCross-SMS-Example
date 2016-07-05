using System;
using SQLite.Net;
using SQLite.Net.Interop;
using System.Collections.Generic;
using ISMSPush.Services;
using ISMSPush.Data;

namespace ISMSPush.iOS
{
	internal class SQLiteConnectionBuilder : ISQLiteConnectionBuilder
	{
		private readonly ISQLitePlatform _platform;
		private SQLiteConnection _connection;

		public SQLiteConnectionBuilder (ISQLitePlatform sqlPlatform)
		{
			_platform = sqlPlatform;
		}

		#region ISQLiteConnectionBuilder implementation

		public ISQLiteConnectionBuilder ConnectTo (SQLiteDB db)
		{
			var builder = new SQLiteConnectionBuilder (_platform);
			//false parameter turn off dateformat as ticks
			builder._connection = new SQLiteConnection (_platform, db.DbPath,false);
			return builder;
		}

		public ISQLiteConnectionBuilder AndAttachWithAlias (ISMSPush.Data.SQLiteDB db)
		{
			_connection.Execute (String.Format ("ATTACH DATABASE '{0}' as '{1}'", db.DbPath, db.DbAlias));
			return this;
		}

		public SQLiteConnection Create ()
		{
			return _connection;
		}

		#endregion
	}
}

