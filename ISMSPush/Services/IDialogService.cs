using System;
using System.Threading.Tasks;

namespace ISMSPush.Services
{
	[Flags]
	public enum DialogActionType
	{
		Default,
		Cancel,
		Normal

	}

	public class DialogAction
	{
		private const string OK_BUTTON_TEXT = "OK";
		private const string CANCEL_BUTTON_TEXT = "Cancel";

		public String ButtonText { get; set; }

		public Action DialogCallback { get; set; }

		public DialogActionType ActionType { get; set; }

		public DialogAction ()
		{
			ActionType = DialogActionType.Normal;
		}

		public static DialogAction DefaultOK (Action dialogCallback)
		{
			return new DialogAction () { 
				ButtonText = OK_BUTTON_TEXT, 
				ActionType = DialogActionType.Default,
				DialogCallback = dialogCallback
			};
		}

		public static DialogAction DefaultCancel ()
		{
			return new DialogAction () {
				ButtonText = CANCEL_BUTTON_TEXT,
				ActionType = DialogActionType.Cancel,
				DialogCallback = null
			};
		}
	}

	public interface IDialogService
	{
		Task ShowError (string message, string title, string buttonText, Action afterHideCallback);

		Task ShowError (Exception error, string title, string buttonText, Action afterHideCallback);

		Task ShowMessage (string message, string title);

		Task ShowMessage (string message, string title, string buttonText, Action afterHideCallback);

		Task<bool> ShowMessage (string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback);

		Task ShowMessageBox (string message, string title);
	}

	public interface IDialogService2
	{
		Task ShowError (
			string message,
			string title,
			params DialogAction[] dialogActions);

		Task ShowError (
			Exception error,
			string title,
			params DialogAction[] dialogActions);

		Task ShowMessage (
			string message,
			string title,
			params DialogAction[] dialogActions);
	}
}