using System;
using SQLite.Net.Attributes;

namespace ISMSPush
{
	public class Message
	{
		
		[PrimaryKey]
		public Guid MessageId {get;set;}

		public int SequenceNumber { get; set; }

		public DateTime? DateTime { get; set;}

		public long Destination { get; set; }

		public long Source { get; set; }

		public string From { get; set; }

		public string MessageText { get ; set; }

		 
		 
	}
}

