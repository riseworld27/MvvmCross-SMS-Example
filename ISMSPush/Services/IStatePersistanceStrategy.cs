
namespace ISMSPush.Services
{
	public interface IStatePersistanceStrategy
	{
		void SaveState (string stateKey, string stateValue);

		string LoadState (string stateKey);
	}
}
