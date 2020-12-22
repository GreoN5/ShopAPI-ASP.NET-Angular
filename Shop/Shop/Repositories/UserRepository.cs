using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Data;
using Shop.Models.User;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Shop.Repositories
{
	public class UserRepository
	{
		private readonly IConfiguration _confirguration;
		private readonly ShopContext _shopContext;

		public UserRepository(IConfiguration configuration, ShopContext context)
		{
			_confirguration = configuration;
			_shopContext = context;
		}

		public User Registration(UserRegistrationVM userRegistration)
		{
			List<User> users = _shopContext.Users.ToList();

			if (CheckIfUsernameAlreadyExists(users, userRegistration.Username))
			{
				return new User()
				{
					Username = null,
					Password = userRegistration.Password,
					EmailAddress = userRegistration.EmailAddress,
					Address = userRegistration.Address,
					PhoneNumber = userRegistration.PhoneNumber,
					BankAccountNumber = userRegistration.BankAccountNumber
				}; // returns the user with null username
			}

			if (CheckIfEmailAlreadyExists(users, userRegistration.EmailAddress))
			{
				return new User()
				{
					Username = userRegistration.Username,
					Password = userRegistration.Password,
					EmailAddress = null,
					Address = userRegistration.Address,
					PhoneNumber = userRegistration.PhoneNumber,
					BankAccountNumber = userRegistration.BankAccountNumber
				}; // returns the user with null email address
			}

			if (CheckIfBankAccountNumberAlreadyExists(users, userRegistration.BankAccountNumber))
			{
				return new User()
				{
					Username = userRegistration.Username,
					Password = userRegistration.Password,
					EmailAddress = userRegistration.EmailAddress,
					Address = userRegistration.Address,
					PhoneNumber = userRegistration.PhoneNumber,
					BankAccountNumber = null
				}; // returns the user with null back account
			}

			// if there are no matches for duplicated attributes of the user it will create a complete user and add it to the database 
			User newUser = new User()
			{
				Username = userRegistration.Username,
				Password = userRegistration.Password,
				EmailAddress = userRegistration.EmailAddress,
				Address = userRegistration.Address,
				PhoneNumber = userRegistration.PhoneNumber,
				BankAccountNumber = userRegistration.BankAccountNumber
			};

			_shopContext.BankAccounts.Add(new BankAccount() 
			{
				BankAccountNumber = newUser.BankAccountNumber,
				BankAccountBalance = SetBankAccountBalance(),
				User = newUser
			});

			_shopContext.Carts.Add(new Cart()
			{
				User = newUser
			});

			_shopContext.Users.Add(newUser);
			_shopContext.SaveChanges();

			return newUser;
		}

		public User Login(UserLoginVM userLogin)
		{
			User loggedUser = _shopContext.Users.Where(u => u.Username == userLogin.Username && u.Password == u.Password).FirstOrDefault();

			if (loggedUser != null)
			{
				return loggedUser;
			}

			return null;
		}

		public string GenerateJWTToken(User userToken)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confirguration["Jwt:SecretKey"]));
			var creditentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim("username", userToken.Username),
				new Claim("role", userToken.Role.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var token = new JwtSecurityToken(issuer: _confirguration["Jwt:Issuer"], 
											 audience: _confirguration["Jwt:Audience"], 
											 claims: claims, 
											 expires: DateTime.Now.AddMinutes(30),
											 signingCredentials: creditentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		/// <summary>
		/// Simulates real-life bank account balance
		/// </summary>
		/// <returns>Random number between 100 and 5000 for the particular bank account number</returns>
		private decimal SetBankAccountBalance()
		{
			Random random = new Random();

			return random.Next(100, 5000);
		}

		private bool CheckIfUsernameAlreadyExists(List<User> users, string username) 
		{
			return users.Where(u => u.Role == "User").Any(u => u.Username == username);
		}

		private bool CheckIfEmailAlreadyExists(List<User> users, string email)
		{
			return users.Where(u => u.Role == "User").Any(u => u.EmailAddress == email);
		}

		private bool CheckIfBankAccountNumberAlreadyExists(List<User> users, string bankAccountNumber)
		{
			return users.Where(u => u.Role == "User").Any(u => u.BankAccountNumber == bankAccountNumber);
		}
	}
}
