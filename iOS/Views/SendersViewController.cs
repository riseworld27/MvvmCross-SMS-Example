using MonoTouch.Dialog;
using UIKit;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using System.Linq;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.CrossCore;
using Cirrious.CrossCore.UI;
using System;using Cirrious.MvvmCross.Plugins.Messenger;


namespace ISMSPush.iOS
{
	public partial class SendersViewController : BaseFlyOutMenuMvxViewController<SendersViewModel>
	{
		public SendersViewController () : base ("SendersViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


