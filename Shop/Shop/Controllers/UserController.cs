using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models.User;
using Shop.Repositories;
using Shop.ViewModels;

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

			if (user.Username == null)
			{
				return StatusCode(409, $"Already existing user with username \"{userRegistration.Username}\"!");
			}

			if (user.EmailAddress == null)
			{
				return StatusCode(410, $"Already existing user with email \"{userRegistration.EmailAddress}\"!");
			}

			if (user.BankAccount == null)
			{
				return StatusCode(411, $"Already existing user with bank account \"{userRegistration.BankAccountNumber}\"!");
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
