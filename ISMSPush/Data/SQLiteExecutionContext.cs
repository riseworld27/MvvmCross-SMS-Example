using ISMSPush.Data;

namespace ISMSPush
{
	public class SQLiteExecutionContext
	{
		public SQLiteDB TransDb { get; private set; }
	

		public SQLiteExecutionContext (SQLiteDB transDb)
		{
			TransDb = transDb;
		}
	}
}

