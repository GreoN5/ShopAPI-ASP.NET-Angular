using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
	[AllowAnonymous]
	public class UserController : Controller
	{
		private UserRepository _userRepository;

		public UserController(UserRepository repository)
		{
			_userRepository = repository;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("Registration")]
		public IActionResult Registration([FromBody] UserRegistrationVM userRegistration)
		{
			User user = _userRepository.Registration(userRegistration);

			if (user == null)
			{
				return StatusCode(409, $"Already existing user with \"{userRegistration.Username}\" username" +
					$" or \"{userRegistration.EmailAddress}\" email or \"{userRegistration.BankAccountNumber}\" bank account number!");
			}

			return Ok(user);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("Login")]
		public IActionResult Login([FromBody] UserLoginVM userLogin)
		{
			User user = _userRepository.Login(userLogin);

			if (user != null)
			{
				var token = _userRepository.GenerateJWTToken(user);

				return Ok(new { AuthToken = token, User = user });
			}

			return NotFound("User not found!");
		}
	}
}
