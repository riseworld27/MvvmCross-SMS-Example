using System;
using ISMSPush;
using FlyoutNavigation;
using UIKit;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using System.Linq;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using ISMSPush.Messages;
using ISMSPush.iOS;
using MonoTouch.Dialog;

namespace ISMSPush.iOS
{
	public class MainViewController : BaseMvxViewController<MainViewModel>
	{ 
		// flyout menu definition
		private readonly string[] _menuItemTitles = { "Home", "Senders",};
		private readonly Type[] _viewModelTypes = {
			typeof(HomeViewModel),
			typeof(SendersViewModel),
			//typeof(LogonViewModel),
			//typeof(RouteAppointmentViewModel)
		};

		private FlyoutNavigationController _flyOut;
		private MvxSubscriptionToken _messageToken;

		public UIViewController[] ViewControllers {
			get {
				return _flyOut.ViewControllers;
			}
		}

		public nint SelectedIndex {
			get {
				return _flyOut.SelectedIndex;
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (NavigationController != null) {
				NavigationController.NavigationBarHidden = true;
			}

			Title = "Audit IT";

			_flyOut = new FlyoutNavigationController ();

			View.AddSubview (_flyOut.View);
			AddChildViewController (_flyOut);

			// view controllers for the flyout menu items
			var flyoutViewControllers = _viewModelTypes.Select (x => CreateMenuItemViewController (x)).ToArray ();
			_flyOut.ViewControllers = flyoutViewControllers;

			// flyout menu items
			var flyOutMenuItems = new Section ();
			flyOutMenuItems.AddAll (_menuItemTitles.Select (x => new StringElement (x)));
			var rootElement = new RootElement ("") { flyOutMenuItems };
			_flyOut.NavigationRoot = rootElement;

			_flyOut.AlwaysShowLandscapeMenu = false;
			_flyOut.HideShadow = false;
			_flyOut.ShadowViewColor = UIColor.White;

			var messenger = Mvx.Resolve<IMvxMessenger> ();
			_messageToken = messenger.SubscribeOnMainThread<ToggleFlyoutMenuMessage> (OnToggleMenu);
		}

		protected override void Dispose (bool disposing)
		{
			if (disposing) {
				if (_flyOut != null) {
					_flyOut.Dispose ();
					_flyOut = null;
				}
			}

			base.Dispose (disposing);
		}

		private UIViewController CreateMenuItemViewController (Type viewModel)
		{
			var request = new MvxViewModelRequest { ViewModelType = viewModel };
			var navController = new UINavigationController ();
			var view = this.CreateViewControllerFor (request) as UIViewController;

			navController.PushViewController (view, false);
			return navController;
		}

		private void OnToggleMenu (ToggleFlyoutMenuMessage message)
		{
			_flyOut.ToggleMenu ();
		}
	}
}

