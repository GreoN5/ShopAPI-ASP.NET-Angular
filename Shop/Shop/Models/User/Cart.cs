using Shop.Models.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.User
{
	public class Cart
	{
		[Key]
		public int ID { get; set; }

		[Column(TypeName = "decimal(6, 2)")]
		public decimal FinalPrice { get; set; }

		public List<Product> Products { get; set; } = new List<Product>();
	}
}
