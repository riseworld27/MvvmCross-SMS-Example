using System;
using ISMSPush;
using ISMSPush.Services;

namespace ISMSTest
{
	public class TestHelper : ITestHelper
	{
		IDatabaseFileManager _databaseFileManager;
		IApplicationStateService _applicationStateService;
		IAppPlatformSpecificData _appPlatformSpecData;
	

		public TestHelper (IDatabaseFileManager databaseFileManager, IApplicationStateService appStateService, IAppPlatformSpecificData appPlatformSpeicficData)
		{
			_databaseFileManager = databaseFileManager;
			_applicationStateService = appStateService;
			_appPlatformSpecData = appPlatformSpeicficData;
		}

		public void IntitialiseDatabases()
		{
			SeedDatabase ();
		}

		private void SeedDatabase()
		{
			string dbPath = _appPlatformSpecData.GetAppInstallationPath ();
			_applicationStateService.DatabaseState.SetAppInstallationPath (dbPath);
			_databaseFileManager.SeedDb (string.Empty,"test-message.db");
		}
	}
}

