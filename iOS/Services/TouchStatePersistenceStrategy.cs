using System;
using ISMSPush.Services;
using Foundation;

namespace AuditIT.Touch.Services
{
	internal class TouchStatePersistenceStrategy : IStatePersistanceStrategy
	{
		private readonly NSUserDefaults _localSettings = null;

		public TouchStatePersistenceStrategy ()
		{
			_localSettings = NSUserDefaults.StandardUserDefaults;
		}

		public void SaveState (string stateKey, string stateValue)
		{
			_localSettings.SetString (stateValue, stateKey);
		}

		public string LoadState (string stateKey)
		{
			return _localSettings.StringForKey (stateKey);
		}

	}
}

