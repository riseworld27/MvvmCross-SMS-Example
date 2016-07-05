using Foundation;
using UIKit;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using ISMSPush.Messages;
using Cirrious.MvvmCross.ViewModels;
using System;

namespace ISMSPush.iOS
{
	public abstract class BaseFlyOutMenuMvxViewController<TViewModel> : BaseMvxViewController<TViewModel> where TViewModel : MvxViewModel
	{
		protected BaseFlyOutMenuMvxViewController ()
		{
		}

		protected BaseFlyOutMenuMvxViewController (string nibName, NSBundle bundle)
			: base (nibName, bundle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var hamburgerIcon = UIImage.FromBundle ("Images/hamburger.png").ImageWithRenderingMode (UIImageRenderingMode.AlwaysOriginal);
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem (hamburgerIcon, UIBarButtonItemStyle.Plain, OnHamburgerButtonPress);
		}

		private void OnHamburgerButtonPress (object sender, EventArgs e)
		{
			var messenger = Mvx.Resolve<IMvxMessenger> ();
			messenger.Publish (new ToggleFlyoutMenuMessage (this));
		}
	}
}

