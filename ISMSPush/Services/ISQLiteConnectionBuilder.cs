using ISMSPush.Data;
using SQLite.Net;


namespace ISMSPush
{
	public interface ISQLiteConnectionBuilder
	{
		ISQLiteConnectionBuilder ConnectTo (SQLiteDB db);

		ISQLiteConnectionBuilder AndAttachWithAlias (SQLiteDB db);

		SQLiteConnection Create ();
	}
}
