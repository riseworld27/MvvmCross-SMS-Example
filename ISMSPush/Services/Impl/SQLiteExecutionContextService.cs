using ISMSPush.Data;
using ISMSPush.Services;

namespace ISMSPush
{
	class SQLiteExecutionContextService : IExecutionContextService
	{
		private const string DB_ALIAS = "TRANSDB";


		private IApplicationStateService _applicationStateService;

		public SQLiteExecutionContextService (IApplicationStateService applicationStateService)
		{
			_applicationStateService = applicationStateService;
		}

		public SQLiteExecutionContext GetContext ()
		{
			return new SQLiteExecutionContext (
				new SQLiteDB (_applicationStateService.DatabaseState.DBPath, DB_ALIAS)
				);
		}
	}
}
