using ISMSPush.Data;


namespace ISMSPush
{
	public interface IExecutionContextService
	{
		SQLiteExecutionContext GetContext ();
	}
}
