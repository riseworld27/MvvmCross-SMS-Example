using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using UIKit;
using ISMSPush;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using Cirrious.MvvmCross.Touch.Views.Presenters;

using Cirrious.CrossCore;
using ISMSPush.Services;

namespace ISMSPush.iOS
{
	

	public class Setup : MvxTouchSetup
	{
		public Setup (MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base (applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new ISMSPush.App ();
		}

		protected override IMvxTrace CreateDebugTrace ()
		{
			return new DebugTrace ();
		}

		protected override IMvxTouchViewPresenter CreatePresenter ()
		{
			return new AppPresenter ((UIApplicationDelegate)ApplicationDelegate, Window);
		}

		protected override void InitializeFirstChance ()
		{
			base.InitializeFirstChance ();

			//Register PCL services
			Mvx.LazyConstructAndRegisterSingleton<IDatabaseParams, DatabaseParams> ();
			Mvx.LazyConstructAndRegisterSingleton<ISQLiteConnectionBuilder, SQLiteConnectionBuilder> ();
		}

		protected override void InitializeLastChance ()
		{	
			//register IOS project services
			//Mvx.LazyConstructAndRegisterSingleton<ISyncValidator, SyncValidator> ();


			base.InitializeLastChance ();
		}
	}
}