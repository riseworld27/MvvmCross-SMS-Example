using System;
using Cirrious.MvvmCross.ViewModels;

namespace ISMSPush
{
	public class HomeViewModel : ViewModelBase
	{
		
			IMessagesService _messagesService;


			public HomeViewModel (IMessagesService messagesService)
			{
				_messagesService = messagesService;

				Messages = new RangeObservableCollection<Message> ();
			}

			public RangeObservableCollection<Message> Messages
			{
				get;
				private set;
			}


			/// <summary>
			/// The <see cref="SelectedPushMessage" /> property's name.
			/// </summary>
			public const string SelectedPushMessagePropertyName = "SelectedPushMessage";
			private Message _selectedPushMessage = new Message();
			/// <summary>
			/// Sets and gets the AuxlabelTextBoxVisable property.  
			/// Changes to that property's value raise the PropertyChanged event. 
			/// </summary>
			public Message SelectedPushMessage
			{
				get
				{
					return _selectedPushMessage;

				}
				set
				{
					Set(SelectedPushMessagePropertyName, ref _selectedPushMessage, value);
				}
			}

			private MvxCommand<Message> _goToConversation;
			public MvxCommand<Message> GoToConverstation
			{
				get
				{
					return _goToConversation
						?? (_goToConversation = new MvxCommand<Message>(
							message =>
							{
								ShowViewModel<ConverstationViewModel>(message.Source);
							}));
				}
			}

			private IMvxCommand _goToSenders;
			public IMvxCommand GotoSenders
			{
				get {
					return _goToSenders 
					?? (_goToSenders = new MvxCommand (
						() => 
						{
							ShowViewModel<SendersViewModel>(SelectedPushMessage.MessageId);
						}));
				}
			}

			private MvxCommand<Message> _deleteMessage;
			public MvxCommand<Message> DeleteMessage
			{
				get {
					return _deleteMessage ?? (_deleteMessage = new MvxCommand<Message>(
						message =>
						{
							_messagesService.DeleteMessages(message.Source);
						}));
				}
			}



			public void RefreshMessages()
			{
				Messages.Reset(_messagesService.GetMessages ());
			}

			protected override void InitFromBundle (IMvxBundle parameters)
			{
				base.InitFromBundle (parameters);
				RefreshMessages ();
			}
		}

}

