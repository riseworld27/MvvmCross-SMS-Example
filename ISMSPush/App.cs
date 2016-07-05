using Cirrious.CrossCore;
using System.Threading.Tasks;
using ISMSPush.Services;
using ISMSPush.Services.Impl;


namespace ISMSPush
{
	public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
	{
		public override void Initialize ()
		{
			RegisterServices ();
			PostInitialise ();
			RegisterAppStart<MainViewModel> ();
		}

		private void RegisterServices ()
		{
			Mvx.LazyConstructAndRegisterSingleton<IApplicationStateService, ApplicationStateService> ();
			Mvx.LazyConstructAndRegisterSingleton<IExecutionContextService, SQLiteExecutionContextService> ();
		}

		private void PostInitialise()
		{
			var stateService = Mvx.Resolve<IApplicationStateService> ();
			stateService.LoadState ();
			stateService.SetDatabaseParams (Mvx.Resolve<IDatabaseParams> ());

			var dbManager = Mvx.Resolve<IDatabaseFileManager> ();
			dbManager.AttachDatabases (stateService.DatabaseState);
		}
	}
}