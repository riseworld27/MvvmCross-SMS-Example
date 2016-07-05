using System;
using ISMSPush.Services;
using System.Threading.Tasks;
using UIKit;

namespace iOS.Services
{
	public class DialogService : IDialogService
	{
		public Task ShowError (string message, string title, string buttonText, Action afterHideCallback)
		{
			return ShowMessage (message, title, null, buttonText, b => afterHideCallback ());
		}

		public Task ShowError (Exception error, string title, string buttonText, Action afterHideCallback)
		{
			return ShowMessage (error.Message, title, null, buttonText, b => afterHideCallback ());
		}

		public Task ShowMessage (string message, string title)
		{
			return ShowMessage (message, title, null, "Ok", null);
		}

		public Task ShowMessage (string message, string title, string buttonText, Action afterHideCallback)
		{
			return ShowMessage (message, title, null, buttonText, b => afterHideCallback ());
		}

		public Task<bool> ShowMessage (string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
		{
			string[] stringList;
			if (buttonConfirmText != null)
				stringList = new[]{buttonConfirmText};
			else
				stringList = null;
			var tcs = new TaskCompletionSource<bool> ();		
			var view = new UIAlertView (title, message, null, buttonCancelText, stringList);
			view.Dismissed += (sender, e) => { 
				if (afterHideCallback != null) {
					afterHideCallback (e.ButtonIndex > 0);
				}

				tcs.SetResult (e.ButtonIndex > 0);
			};
				
			view.Show ();
			return tcs.Task;
		}

		public Task ShowMessageBox (string message, string title)
		{
			return ShowMessage (message, title);
		}
	}
}

