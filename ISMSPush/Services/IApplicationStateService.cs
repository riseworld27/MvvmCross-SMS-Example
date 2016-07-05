
using ISMSPush.Model;

namespace ISMSPush.Services
{
	public interface IApplicationStateService
	{

		NavigationState NavigationState { get; }

		DatabaseState DatabaseState { get; }


		void SaveState ();

		void LoadState ();





		void SetDatabaseParams (IDatabaseParams databaseParams);
	}
}
