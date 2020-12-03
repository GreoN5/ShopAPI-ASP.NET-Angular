using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Repositories;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly AdminRepository _adminRepository;

		public AdminController(AdminRepository repository)
		{
			_adminRepository = repository;
		}

		[Route("Users")]
		[HttpGet]
		public IActionResult GetAllRegisteredUsers()
		{
			return Ok(_adminRepository.GetAllUsers());
		}

		[Route("Products")]
		[HttpGet]
		public IActionResult GetAllProducts()
		{
			return Ok(_adminRepository.GetAllProducts());
		}

		[Route("CreateProduct")]
		[HttpPost]
		public IActionResult CreateNewProduct([FromBody] ProductVM product)
		{
			if (_adminRepository.CreateNewProduct(product))
			{
				return Ok(product);
			}

			return NotFound("Product already exists!");
		}

		[Route("ChangeQuantity/{productName}/{quantity}")]
		[HttpPut]
		public IActionResult ChangeQuantityOfProduct(string productName, int quantity)
		{
			if (_adminRepository.ChangeQuantityOfProduct(productName, quantity))
			{
				return Ok($"Quantity of {productName} changed to {quantity}!");
			}

			return NotFound("Product not found!");
		}

		[Route("RemoveProduct/{productName}")]
		[HttpDelete]
		public IActionResult RemoveProduct(string productName)
		{
			if (_adminRepository.RemoveProduct(productName))
			{
				return Ok($"Product {productName} successfully deleted!");
			}

			return NotFound("Product not found!");
		}
	}
}
