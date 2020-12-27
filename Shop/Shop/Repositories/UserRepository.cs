using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Data;
using Shop.Models.Admin;
using Shop.Models.User;
using Shop.Repositories.UserCheck;
using Shop.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Shop.Repositories
{
	public class UserRepository : UniqueUser
	{
		private readonly IConfiguration _confirguration;
		private readonly ShopContext _shopContext;

		public UserRepository(IConfiguration configuration, ShopContext context) : base()
		{
			_confirguration = configuration;
			_shopContext = context;
		}

		public User Registration(UserRegistrationVM userRegistration)
		{
			if (DoesUsernameAlreadyExists(userRegistration.Username, _shopContext))
			{
				return GetNewUserWithoutUsername(userRegistration);
			}

			if (DoesEmailAlreadyExists(userRegistration.EmailAddress, _shopContext))
			{
				return GetNewUserWithoutEmail(userRegistration);
			}

			if (DoesBankAccountNumberAlreadyExists(userRegistration.BankAccountNumber, _shopContext))
			{
				return GetNewUserWithoutBankAccountNumber(userRegistration);
			}

			// if there are no matches for duplicated attributes of the user it will create a complete user and add it to the database 
			return AddUniqueUser(userRegistration, _shopContext);
		}

		public User Login(UserLoginVM userLogin)
		{
			User loggedUser = _shopContext.Users.Where(u => u.Username == userLogin.Username && u.Password == userLogin.Password).FirstOrDefault();

			if (loggedUser != null)
			{
				return loggedUser;
			}

			return null;
		}

		public Admin LoginAdmin(UserLoginVM userLogin)
		{
			Admin admin = _shopContext.Admins.Where(a => a.Username == userLogin.Username && a.Password == userLogin.Password).FirstOrDefault();

			if (admin != null)
			{
				return admin;
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

		public string GenerateJWTTokenAdmin(Admin adminToken)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confirguration["Jwt:SecretKey"]));
			var creditentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim("username", adminToken.Username),
				new Claim("role", adminToken.Role.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var token = new JwtSecurityToken(issuer: _confirguration["Jwt:Issuer"],
											 audience: _confirguration["Jwt:Audience"],
											 claims: claims,
											 expires: DateTime.Now.AddHours(1),
											 signingCredentials: creditentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		protected override bool DoesUsernameAlreadyExists(string username, ShopContext context)
		{
			return base.DoesUsernameAlreadyExists(username, context);
		}

		protected override bool DoesEmailAlreadyExists(string email, ShopContext context)
		{
			return base.DoesEmailAlreadyExists(email, context);
		}

		protected override bool DoesBankAccountNumberAlreadyExists(string bankAccountNumber, ShopContext context)
		{
			return base.DoesBankAccountNumberAlreadyExists(bankAccountNumber, context);
		}

		protected override User GetNewUserWithoutUsername(UserRegistrationVM user)
		{
			return base.GetNewUserWithoutUsername(user);
		}

		protected override User GetNewUserWithoutEmail(UserRegistrationVM user)
		{
			return base.GetNewUserWithoutEmail(user);
		}

		protected override User GetNewUserWithoutBankAccountNumber(UserRegistrationVM user)
		{
			return base.GetNewUserWithoutBankAccountNumber(user);
		}

		protected override User AddUniqueUser(UserRegistrationVM user, ShopContext context)
		{
			return base.AddUniqueUser(user, context);
		}
	}
}
