using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.User
{
	public enum UserRole
	{
		[Description("User")]
		User = 1,

		[Description("Admin")]
		Admin = 2
	}
}
