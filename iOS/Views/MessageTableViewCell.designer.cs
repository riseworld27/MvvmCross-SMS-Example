// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ISMSPush.iOS
{
	[Register ("MessageTableViewCell")]
	partial class MessageTableViewCell
	{
		[Outlet]
		UIKit.UILabel From { get; set; }

		[Outlet]
		UIKit.UILabel Mesage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (From != null) {
				From.Dispose ();
				From = null;
			}

			if (Mesage != null) {
				Mesage.Dispose ();
				Mesage = null;
			}
		}
	}
}
