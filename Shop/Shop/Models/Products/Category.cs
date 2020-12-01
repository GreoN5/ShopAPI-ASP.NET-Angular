using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Products
{
	public enum Category
	{
		[Description("Meat")]
		Meat = 1,

		[Description("Drinks")]
		Drinks = 2,

		[Description("Pizza")]
		Pizza = 3,

		[Description("Salad")]
		Salad = 4,

		[Description("Sauce")]
		Sauces = 5,

		[Description("Dessert")]
		Dessert = 6,
	}
}
