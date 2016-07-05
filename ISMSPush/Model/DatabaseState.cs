using Newtonsoft.Json;
using System;

namespace ISMSPush.Model
{
	public class DatabaseState
	{
		public readonly static DateTime DEFAULT_MIN_DATE = DateTime.Parse ("2001-01-01");

		//[JsonProperty]
		//public string ReferencePath { get; private set; }
		public string DBPath { get; private set; }

		public DateTime LastSuccessfulQueryDateTime { get; set; }

		public string SMSServiceBaseURL { get; set; }

		public string AppLocalStoragePath { get; private set; }

		public string AppInstallationPath { get; private set; }

		public string UserDocFileStoragePath { get; private set; }

		public string UserPicturesFileStoragePath { get; private set; }

		public void SetAppLocalStoragePath (string appLocalStoragePath)
		{
			AppLocalStoragePath = appLocalStoragePath;
		}

		public void SetAppInstallationPath (string appInstallationPath)
		{
			AppInstallationPath = appInstallationPath;
		}

		public void SetUserDocFileStoragePath (string userFileStoragePath)
		{
			UserDocFileStoragePath = userFileStoragePath;
		}

		public void SetUserPicturesFileStoragePath (string userPictureFileStoragePath)
		{
			UserPicturesFileStoragePath = userPictureFileStoragePath;
		}


		public void SetDBPath(string path)
		{
			DBPath = path;
		}

		public DatabaseState ()
		{
			LastSuccessfulQueryDateTime = DEFAULT_MIN_DATE;
		}

		public void ResetLastQueryDate ()
		{
			LastSuccessfulQueryDateTime = DEFAULT_MIN_DATE;
		}

	}
}
