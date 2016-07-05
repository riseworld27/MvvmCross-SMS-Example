using Newtonsoft.Json;
using ISMSPush.Model;
using ISMSPush.Services;

namespace ISMSPush.Services.Impl
{
	public class ApplicationStateService : IApplicationStateService
	{
		
		private NavigationState _navigationState;
		private DatabaseState _databaseState;

		public ApplicationStateService (IStatePersistanceStrategy statePersistanceStrategy)
		{
			
			_navigationState = new NavigationState ();
			_databaseState = new DatabaseState ();

			_statePersistanceStrategy = statePersistanceStrategy;		
		}

		private IStatePersistanceStrategy _statePersistanceStrategy;

		public NavigationState NavigationState { get { return _navigationState; } }

		public DatabaseState DatabaseState { get { return _databaseState; } }






		public void SaveState ()
		{
			
			SaveObjectState (_navigationState);
			SaveObjectState (_databaseState);

		}

		public void LoadState ()
		{
			
			_navigationState = LoadObjectState<NavigationState> ();
			_databaseState = LoadObjectState<DatabaseState> ();

		}

		public void SetDatabaseParams (IDatabaseParams databaseParams)
		{
			_databaseState.SetAppInstallationPath (databaseParams.AppInstallationPath);
			_databaseState.SetAppLocalStoragePath (databaseParams.AppLocalStoragePath);
			_databaseState.SetUserDocFileStoragePath (databaseParams.UserDocFileStoragePath);
			_databaseState.SetUserPicturesFileStoragePath (databaseParams.UserPicturesFileStoragePath);
		}

		private void SaveObjectState (object state)
		{
			if (state != null) {
				string stateJson = JsonConvert.SerializeObject (state);
				_statePersistanceStrategy.SaveState (state.GetType ().Name, stateJson);
			}
		}

		private T LoadObjectState<T> () where T: new()
		{
			string stateJson = _statePersistanceStrategy.LoadState (typeof(T).Name);
			if (stateJson == null)
				return new T ();

			var state = JsonConvert.DeserializeObject<T> (stateJson);
			return state;
		}

	}
}
