
using System;
using NUnit.Framework;
using Cirrious.CrossCore;
using ISMSPush;
using ISMSPush.iOS;
using ISMSTest;

namespace ISMSTest
{
	[TestFixture]
	public class MesssagesServiceTest : DBTestClass
	{
		

		[Test]
		public void Pass ()
		{
			
			TestHelper.IntitialiseDatabases ();
			IMessagesService service = Mvx.Resolve<IMessagesService> ();
			Message message = new Message {
				MessageText = "Hello World",
				DateTime = DateTime.Now,
				Destination = 61401328025,
				Source = 61416907111,
				From = "Jenny",
				SequenceNumber = 0,
				MessageId = Guid.NewGuid ()
			};
			int insert = service.InsertOrReplaceMessage (message);	
			Assert.True (insert == 1);
		}

		[Test]
		public void Fail ()
		{
			Assert.False (true);
		}

		[Test]
		[Ignore ("another time")]
		public void Ignore ()
		{
			Assert.True (false);
		}
	}
}
