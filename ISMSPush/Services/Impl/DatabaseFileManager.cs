using ISMSPush.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using ISMSPush.Model;

using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.File;

namespace ISMSPush.Services.Impl
{
	
	internal class DatabaseFileManager : IDatabaseFileManager
	{
		#if DEBUG
		public const string DB_NAME = "message.db";
		public const string DEFAULT_DB_NAME = "message-blank.db";
		#else
		public const string DEFAULT_DB_NAME = "message-blank.db";
		public const string DB_NAME = "message.db";
#endif
		public string Prefix { get; set; }
		private readonly IApplicationStateService _appStateService;
		private readonly IMvxFileStore _fileStore;

		public DatabaseFileManager (IApplicationStateService appStateService, IMvxFileStore fileStore)
			: this (string.Empty)
		{
			_appStateService = appStateService;
			_fileStore = fileStore;
		}

		public DatabaseFileManager (string prefix)
		{
			Prefix = prefix;
		}



		public String SeedDb (string databaseName, string newDatabaseName)
		{
			var iniDatabasePath = Path.Combine (_appStateService.DatabaseState.AppInstallationPath, databaseName);
			var newDatabasePath = Path.Combine (_appStateService.DatabaseState.AppLocalStoragePath, newDatabaseName);
			if (_fileStore.Exists (iniDatabasePath)) {
				CopyFile (iniDatabasePath, newDatabasePath);
				return newDatabasePath;
			} else {return "ERROR";
			}
		}

		private String SeedDb (string databaseName)
		{
			return SeedDb (databaseName, databaseName);
		}

		public void AttachDatabases (DatabaseState databaseState)
		{
			var transFileNotExists = string.IsNullOrEmpty (databaseState.DBPath) || _fileStore.Exists (databaseState.DBPath);

			if (transFileNotExists) {
				Debug.WriteLine ("Database not available, attaching blank one");
				AttachInitialDatabase (databaseState);
			} else {
				Debug.WriteLine (
					"Databases exist and are available, reattaching:\ntrans: {0}\nref: {1}",
					databaseState.DBPath);
			}
		}

		private void AttachInitialDatabase (DatabaseState databaseState)
		{
			databaseState.SetDBPath (SeedDb (DEFAULT_DB_NAME, DB_NAME));

			_appStateService.SaveState ();
		}







		private void CopyFile (string exitingFilePath, string newFilePath)
		{
			using(MemoryStream ms = new MemoryStream ())
			{
				using (Stream file = _fileStore.OpenRead (exitingFilePath)) {
					file.CopyTo (ms);
				}
				ms.Position = 0;
				byte[] fileBytes = ms.ToArray();
				_fileStore.WriteFile (newFilePath, fileBytes); 
			}
		}

		private MemoryStream GetMemoryStreamFromPath(string path)
		{
			MemoryStream ms = new MemoryStream ();
			using (Stream file = _fileStore.OpenRead (path)) {
				file.CopyTo (ms);
			
			}
			return ms;
		}

		private byte[] GetArrayFromPath(string path)
		{

			Byte[] array = new byte[]{ };
			if (IfFileExist (path)) {
				using (MemoryStream ms = new MemoryStream ()) {
					using (Stream file = _fileStore.OpenRead (path)) {
						file.CopyTo (ms);
					}
					array = ms.ToArray ();
				}
			}
			return array;
		}
			
		private void SaveMemoryStreamToFile(string path, MemoryStream ms)
		{
				ms.Position = 0;
				byte[] fileBytes = ms.ToArray();
				_fileStore.WriteFile (path, fileBytes);
		}
		private Stream AddDBToFileStore(string newDbName, out string newDbPath)
		{
			newDbPath = _fileStore.PathCombine(_appStateService.DatabaseState.AppLocalStoragePath, newDbName);

			if (_fileStore.Exists (newDbPath))
				_fileStore.DeleteFile (newDbPath);

			return _fileStore.OpenWrite(newDbPath);
		}

		private bool IfFileExist(string path)
		{
			return _fileStore.Exists (path);
		}

	}
}