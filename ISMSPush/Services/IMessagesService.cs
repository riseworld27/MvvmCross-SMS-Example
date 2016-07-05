using System;
using System.Collections.Generic;


namespace ISMSPush
{
	public interface IMessagesService
	{
		List<Message> GetMessages();
		List<Message> GetMessagesFromSender (int senderMobile);
		int InsertOrReplaceMessage(Message message);
		int DeleteMessage (Guid id);
		int DeleteMessages (long sender);

	}
}

