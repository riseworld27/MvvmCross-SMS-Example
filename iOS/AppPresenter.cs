using Cirrious.MvvmCross.Touch.Views.Presenters;
using UIKit;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.CrossCore.Exceptions;

namespace ISMSPush.iOS
{
	public class AppPresenter : MvxModalNavSupportTouchViewPresenter
	{
		private MainViewController _main;

		public AppPresenter (UIApplicationDelegate appDelegate, UIWindow window) : base (appDelegate, window)
		{			
		}

		public override void Show (IMvxTouchView view)
		{
			if (_main != null) {
				// open view as Model
				//if (view is StartAdhocAuditViewController || view is SelectComponentViewController) {
				//	var nav = new UINavigationController (view as UIViewController);
				//	nav.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
				//	nav.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
				//	_main.PresentViewController (nav, true, null);
				//	return;
				//}

				base.Show (view);
			} else {
				_main = view as MainViewController;
				SetWindowRootViewController (_main);
			}
		}

		public override UINavigationController MasterNavigationController {
			get { 
				var navController = _main.ViewControllers [_main.SelectedIndex];
				return (UINavigationController)navController;
			}
		}

		protected override UIViewController CurrentTopViewController {
			get { return MasterNavigationController.TopViewController; }
		}
	}
}

