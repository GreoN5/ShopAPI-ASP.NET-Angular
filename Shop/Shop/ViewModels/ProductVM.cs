﻿using Shop.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
	public class ProductVM
	{
		//public int ID { get; set; }

		[Required(ErrorMessage = "Product name is required!")]
		public string Name { get; set; }

		public string Description { get; set; }

		[Required(ErrorMessage = "Product price is required!")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Product quantity is required!")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Product category is required!")]
		public Category Category { get; set; }
	}
}
