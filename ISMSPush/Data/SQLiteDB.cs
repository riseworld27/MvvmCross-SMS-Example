
namespace ISMSPush.Data
{
	public class SQLiteDB
	{
		public string DbPath { get; private set; }

		public string DbAlias { get; private set; }

		public SQLiteDB (string dbPath, string dbAlias)
		{
			DbPath = dbPath;
			DbAlias = dbAlias;
		}

	}
}

