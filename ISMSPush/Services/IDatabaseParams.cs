
namespace ISMSPush.Services
{
	public interface IDatabaseParams
	{
		string AppInstallationPath { get; }

		string AppLocalStoragePath { get; }

		string UserDocFileStoragePath { get; }

		string UserPicturesFileStoragePath { get; }
	}
}

