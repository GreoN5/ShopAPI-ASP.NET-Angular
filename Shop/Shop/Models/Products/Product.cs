using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Products
{
	public class Product
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string Name { get; set; }

		[Column(TypeName = "varchar(500)")]
		public string Description { get; set; }

		[Column(TypeName = "decimal(5, 2)")]
		public decimal Price { get; set; }

		[Column(TypeName = "int")]
		public int Quantity { get; set; }

		[Column(TypeName = "varchar(20)")]
		public Status Status { get; set; }

		[Column(TypeName = "varchar(50)")]
		public Category Category { get; set; }
	}
}
