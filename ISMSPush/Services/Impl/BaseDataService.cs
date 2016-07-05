using ISMSPush.Data;
using Cirrious.CrossCore;

using SQLite.Net;

namespace ISMSPush
{
	abstract class BaseDataService
	{
		protected SQLiteExecutionContext Context {
			get {
				return _executionContextService.GetContext (); 
			}
		}

		private readonly IExecutionContextService _executionContextService;

		protected BaseDataService (IExecutionContextService contextService)
		{
			_executionContextService = contextService;
		}

		protected ISQLiteConnectionBuilder ConnectionBuilder { get { return Mvx.Resolve<ISQLiteConnectionBuilder> (); } }



	}
}
