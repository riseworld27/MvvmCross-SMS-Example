using Cirrious.MvvmCross.Touch.Views;
using UIKit;
using Foundation;
using Cirrious.MvvmCross.ViewModels;

namespace ISMSPush.iOS
{
	public abstract class BaseMvxViewController<TViewModel> : MvxViewController where TViewModel : MvxViewModel
	{
		protected BaseMvxViewController ()
		{
			Initialise ();
		}

		protected BaseMvxViewController (string nibName, NSBundle bundle)
			: base (nibName, bundle)
		{
			Initialise ();
		}

		public new TViewModel ViewModel {
			get {
				return base.ViewModel as TViewModel;
			}

			set {
				base.ViewModel = value;
			}
		}

		private void Initialise ()
		{
			EdgesForExtendedLayout = UIRectEdge.None;

		}
	}
}

