using System;
namespace GCASS_EventConnect_User.Models
{
	public class UserDetail
	{
		public Guid id { get; set; }
		public String firstName { get; set; }
		public String lastName { get; set; }
		public String affiliate { get; set; }

		public UserDetail()
		{
		}
	}
}

