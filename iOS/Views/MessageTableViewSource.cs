using System;

using UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Foundation;

namespace ISMSPush.iOS
{
	public partial class MessageTableViewSource : MvxTableViewSource
	{
		private readonly HomeViewModel _viewModel;

		public MessageTableViewSource (UITableView tableView, HomeViewModel viewModel) : base (tableView)
		{
			_viewModel = viewModel;
			tableView.RegisterNibForCellReuse (MessageTableViewCell.Nib, MessageTableViewCell.Key);
		}

		protected override UITableViewCell GetOrCreateCellFor (UITableView tableView, NSIndexPath indexPath, object item)
		{
			var cell = tableView.DequeueReusableCell (MessageTableViewCell.Key, indexPath);
			return cell;
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 88f;
		}
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			_viewModel.SelectedPushMessage = _viewModel.Messages [indexPath.Row];
			_viewModel.GotoSenders.Execute ();
		}
	}
}


