using System;
using ISMSPush.Services;
using System.IO;
using Foundation;

namespace ISMSPush.iOS
{
	public class DatabaseParams : IDatabaseParams
	{
		public static string DocPath {
			get {
				return NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User) [0].Path;
			}
		}

		public string AppInstallationPath {
			get {
				return Path.Combine (NSBundle.MainBundle.BundlePath, "Data");
			}
		}

		public string AppLocalStoragePath {
			get {
				return DocPath;
			}
		}

		public string UserDocFileStoragePath {
			get {
				return Path.Combine (DocPath, "docs");
			}
		}

		public string UserPicturesFileStoragePath {
			get {
				return Path.Combine (DocPath, "pics");
			}
		}
	}
}

