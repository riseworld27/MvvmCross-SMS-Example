
namespace ISMSPush.Model
{
	public class NavigationState
	{
		public string PageName { get; set; }

		public object InitializeParameter { get; set; }

		public void Update (string pageName, object initializeParameter)
		{
			PageName = pageName;
			InitializeParameter = initializeParameter;
		}
	}
}
