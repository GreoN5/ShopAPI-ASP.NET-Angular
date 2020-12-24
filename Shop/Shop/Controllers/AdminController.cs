using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models.Admin;
using Shop.Models.User;
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

		[Route("AddNewUser")]
		[HttpPost]
		public IActionResult AddNewUser([FromBody] UserRegistrationVM newUser)
		{
			User user = _adminRepository.AddNewUser(newUser);

			if (user.Username == null)
			{
				return StatusCode(409, $"Already existing user with username \"{newUser.Username}\"!");
			}

			if (user.EmailAddress == null)
			{
				return StatusCode(410, $"Already existing user with email \"{newUser.EmailAddress}\"!");
			}

			if (user.BankAccountNumber == null)
			{
				return StatusCode(411, $"Already existing user with bank account \"{newUser.BankAccountNumber}\"!");
			}

			return Ok(user);
		}

		[Route("AddNewAdmin")]
		[HttpPost]
		public IActionResult AddNewAdmin([FromBody] AdminVM newAdmin)
		{
			Admin admin = _adminRepository.AddNewAdmin(newAdmin);

			if (admin.Username == null)
			{
				return StatusCode(409, $"Already existing admin with username \"{newAdmin.Username}\"!");
			}

			return Ok(admin);
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

		[Route("RemoveUser/{username}")]
		[HttpDelete]
		public IActionResult RemoveUser(string username)
		{
			if (_adminRepository.RemoveUser(username))
			{
				return Ok($"User {username} successfully deleted!");
			}

			return NotFound("User not found!");
		}
	}
}
