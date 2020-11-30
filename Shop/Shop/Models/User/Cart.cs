using Shop.Models.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.User
{
	public class Cart
	{
		[Key]
		public int ID { get; set; }

		public List<Product> Products { get; set; } = new List<Product>();
	}
}
