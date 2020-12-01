using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models.Products;
using Shop.Models.User;
using Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[AllowAnonymous]
	public class ShopController : Controller
	{
		private ShopRepository _shopRepository;

		public ShopController(ShopRepository repository)
		{
			_shopRepository = repository;
		}

		[Route("Products")]
		[AllowAnonymous]
		[HttpGet]
		public IActionResult GetAllProducts()
		{
			return Ok(_shopRepository.ShowAllProducts());
		}

		[Route("ProductCategories")]
		[AllowAnonymous]
		[HttpGet]
		public IActionResult GetAllProductCategories()
		{
			return Ok(_shopRepository.ShowAllProductCategories());
		}

		[Route("ProductsByCategory")]
		[AllowAnonymous]
		[HttpGet]
		public IActionResult GetProductsByCategory(string category)
		{
			List<Product> products = _shopRepository.ShowProductsByCategory(category);

			if (products != null)
			{
				return Ok(products);
			}

			if (products.Count == 0)
			{
				return Ok("There are currently no products in this category!");
			}

			return NotFound("Invalid category!");
		}

		[Route("Cart/{username}")]
		[Authorize(Roles = "User")]
		[Authorize(Roles = "Admin")]
		[HttpGet]
		public IActionResult ShowProductInCart(string username)
		{
			List<Product> productsInCart = _shopRepository.ShowProductsInCart(username);

			if (productsInCart != null)
			{
				return Ok(productsInCart);
			}

			if (productsInCart.Count == 0)
			{
				return Ok("There are currently no products in your cart!");
			}

			return Unauthorized("You must have an account in order to access your cart!");
		}

		[Route("Cart/{username}/AddProduct/{productName}")]
		[Authorize(Roles = "User")]
		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult AddProductToCart(string username, string productName)
		{
			if (_shopRepository.AddProductToCart(username, productName))
			{
				return Ok($"Product {productName} added successfully to your cart!");
			}

			return NotFound();
		}

		[Route("Cart/{username}/RemoveProduct/{productName}")]
		[Authorize(Roles = "User")]
		[Authorize(Roles = "Admin")]
		[HttpDelete]
		public IActionResult RemoveProductFromCart(string username, string productName)
		{
			if (_shopRepository.RemoveProductFromCart(username, productName))
			{
				return Ok($"Product {productName} removed successfuly from your cart!");
			}

			return NotFound();
		}
	}
}
