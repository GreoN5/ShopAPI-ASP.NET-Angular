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

		[Description("Alcoholic beverage")]
		AlcoholicBeverage = 2,

		[Description("Carbonated drink")]
		CarbonatedDrink = 3,

		[Description("Non-carbonated drink")]
		NonCarbonatedDrink = 4,

		[Description("Pizza")]
		Pizza = 5,

		[Description("Salad")]
		Salad = 6,

		[Description("Sauce")]
		Sauces = 7,

		[Description("Dessert")]
		Dessert = 8,
	}
}
