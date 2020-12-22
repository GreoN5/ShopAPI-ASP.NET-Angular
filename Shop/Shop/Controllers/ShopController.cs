using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models.Products;
using Shop.Repositories;
using System.Collections.Generic;

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
		[HttpGet]
		public IActionResult GetAllProducts()
		{
			return Ok(_shopRepository.ShowAllProducts());
		}

		[Route("ProductCategories")]
		[HttpGet]
		public IActionResult GetAllProductCategories()
		{
			return Ok(_shopRepository.ShowAllProductCategories());
		}

		[Route("Products/{category}")]
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

		[Route("{username}/Cart")]
		[Authorize(Roles = "User")]
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

			return Unauthorized("You must logged in in order to access your cart!");
		}

		[Route("{username}/Cart/FinalPrice")]
		[Authorize(Roles = "User")]
		[HttpGet]
		public IActionResult GetFinalPriceOfCart(string username)
		{
			decimal finalPrice = _shopRepository.GetFinalPrice(username);

			if (finalPrice != -1)
			{
				return Ok(finalPrice);
			}

			return NotFound("User not found!");
		}

		[Route("{username}/Cart/AddProduct/{productName}")]
		[Authorize(Roles = "User")]
		[HttpPost]
		public IActionResult AddProductToCart(string username, string productName)
		{
			if (_shopRepository.AddProductToCart(username, productName))
			{
				return Ok($"Product {productName} added successfully to your cart!");
			}

			return NotFound();
		}

		[Route("{username}/Cart/{productName}/ChangeQuantity")]
		[Authorize(Roles = "User")]
		[HttpPut]
		public IActionResult ChangeQuantityOfProduct(string username, string productName, [FromBody] int quantity)
		{
			if (_shopRepository.ChangeQuantityOfProduct(username, productName, quantity))
			{
				return Ok($"Change quatity of {productName} to {quantity}!");
			}

			return NotFound();
		}

		[Route("{username}/Cart/RemoveProduct/{productName}")]
		[Authorize(Roles = "User")]
		[HttpDelete]
		public IActionResult RemoveProductFromCart(string username, string productName)
		{
			if (_shopRepository.RemoveProductFromCart(username, productName))
			{
				return Ok($"Product {productName} removed successfuly from your cart!");
			}

			return NotFound();
		}

		[Route("{username}/Cart")]
		[Authorize(Roles = "User")]
		[HttpDelete]
		public IActionResult ClearCart(string username)
		{
			if (_shopRepository.ClearCart(username))
			{
				return Ok("Your cart is successfully cleared!");
			}

			return NotFound();
		}
	}
}
