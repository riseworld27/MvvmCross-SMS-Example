using System;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace ISMSPush.iOS
{
	public partial class MessageTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString ("MessageTableViewCell");
		public static readonly UINib Nib;

		static MessageTableViewCell ()
		{
			Nib = UINib.FromName ("MessageTableViewCell", NSBundle.MainBundle);
		}

		public MessageTableViewCell (IntPtr handle) : base (handle)
		{
			this.DelayBind (() => {
				var set = this.CreateBindingSet<MessageTableViewCell, Message> ();
				set.Bind (From).To (vm => vm.From);
				set.Bind (Mesage).To (vm => vm.MessageText);
				set.Apply (); 
			});
		}
	}
}
