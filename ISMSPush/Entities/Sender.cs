using System;
using SQLite.Net.Attributes;

namespace ISMSPush
{
	public class Sender
	{
		public int SourceAddress { get; set;}
		public string Name { get; set; }
		public string Company { get; set; }

		[PrimaryKey]
		[AutoIncrement]
		public int SenderId { get; set; }
	}
}

