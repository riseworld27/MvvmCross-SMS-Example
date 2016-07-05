using System;
using Cirrious.CrossCore;

namespace ISMSTest
{
	public abstract class DBTestClass
	{
		private ITestHelper _testHelper;

		public DBTestClass ()
		{
			_testHelper = Mvx.Resolve<ITestHelper>();
		}

		protected ITestHelper TestHelper { get {return _testHelper;}}
	}
}

