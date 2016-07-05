using System;
using System.Collections.Generic;
using SQLite.Net;
using System.Linq;

namespace ISMSPush
{
	class MessagesService : BaseDataService, IMessagesService
	{
		public MessagesService (IExecutionContextService executionContextService): base (executionContextService)
		{
		}

		public List<Message> GetMessages()
		{
			using (SQLiteConnection connection = ConnectionBuilder.ConnectTo (Context.TransDb).Create ()) {
			
				return connection.Query<Message> (@"Select m1.* from Message m1 
				Left Join Message m2 on (m1.DateTime = m2.DateTime AND m1.DATETIME < m2.DATETIME) 
				Where m2.DATETIME is NULL and From <> 'Me'").ToList();
			}
		}

		public List<Message> GetMessagesFromSender(int senderMobile)
		{
			using (SQLiteConnection connection = ConnectionBuilder.ConnectTo (Context.TransDb).Create ()) {
				return connection.Query<Message> (@"Select * from Message 
				Where Source = ?", senderMobile).ToList ();
			}
		}

		public int InsertOrReplaceMessage(Message message){
			using (SQLiteConnection connection = ConnectionBuilder.ConnectTo (Context.TransDb).Create ()) {
				return connection.InsertOrReplace (message);
			}
		}

		public int DeleteMessage(Guid id)
		{
			using (SQLiteConnection connection = ConnectionBuilder.ConnectTo (Context.TransDb).Create ()) {
				return connection.Delete<Message> (id);
			}
		}

		public int DeleteMessages(long sender){
			using (SQLiteConnection connection = ConnectionBuilder.ConnectTo (Context.TransDb).Create ()) {
				if (sender == 0) {
					connection.Query<Message>(@"Delete From Message");
					return 1;
				}
				connection.Query<Message> (@"Delete From Message Where Sender = ?", sender);
				return 1;
			}
		}

	}
}

