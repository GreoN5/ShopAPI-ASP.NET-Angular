using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Products
{
	public enum Status
	{
		[Description("Available")]
		Available = 1,

		[Description("Small amount")]
		SmallAmount = 2,

		[Description("Unavailable")]
		Unavaible = 3
	}
}
