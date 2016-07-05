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


using ISMSPush.iOS;
using ISMSPush;

namespace ISMSPush.iOS
{
	public partial class HomeViewController : BaseFlyOutMenuMvxViewController<HomeViewModel>
	{
		public HomeViewController () : base ("HomeViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Title = "Message Summary";

			var messagesSource = new MessageTableViewSource (MessageTableView, ViewModel);

			var set = this.CreateBindingSet<HomeViewController, HomeViewModel> ();
			set.Bind (messagesSource).To (vm => vm.Messages);

			MessageTableView.Source = messagesSource;
			MessageTableView.ReloadData ();

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}


