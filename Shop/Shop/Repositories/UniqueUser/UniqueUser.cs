using Shop.Data;
using Shop.Models.User;
using Shop.ViewModels;
using System;
using System.Linq;

namespace Shop.Repositories.UserCheck
{
	public abstract class UniqueUser
	{
		protected UniqueUser() { }

		protected virtual bool DoesUsernameAlreadyExists(string username, ShopContext context)
		{
			return context.Users.Any(u => u.Username == username);
		}

		protected virtual bool DoesEmailAlreadyExists(string email, ShopContext context)
		{
			return context.Users.Any(u => u.EmailAddress == email);
		}

		protected virtual bool DoesBankAccountNumberAlreadyExists(string bankAccountNumber, ShopContext context)
		{
			return context.Users.Any(u => u.BankAccountNumber == bankAccountNumber);
		}

		protected virtual User GetNewUserWithoutUsername(UserRegistrationVM user)
		{
			return new User()
			{
				Username = null,
				Password = user.Password,
				EmailAddress = user.EmailAddress,
				Address = user.Address,
				PhoneNumber = user.PhoneNumber,
				BankAccountNumber = user.BankAccountNumber
			}; // returns the user with null username
		}

		protected virtual User GetNewUserWithoutEmail(UserRegistrationVM user)
		{
			return new User()
			{
				Username = user.Username,
				Password = user.Password,
				EmailAddress = null,
				Address = user.Address,
				PhoneNumber = user.PhoneNumber,
				BankAccountNumber = user.BankAccountNumber
			}; // returns the user with null email address
		}

		protected virtual User GetNewUserWithoutBankAccountNumber(UserRegistrationVM user)
		{
			return new User()
			{
				Username = user.Username,
				Password = user.Password,
				EmailAddress = user.EmailAddress,
				Address = user.Address,
				PhoneNumber = user.PhoneNumber,
				BankAccountNumber = null
			}; // returns the user with null back account
		}

		protected virtual User AddUniqueUser(UserRegistrationVM user, ShopContext context)
		{
			User newUser = new User()
			{
				Username = user.Username,
				Password = user.Password,
				EmailAddress = user.EmailAddress,
				Address = user.Address,
				PhoneNumber = user.PhoneNumber,
				BankAccountNumber = user.BankAccountNumber
			};

			context.BankAccounts.Add(new BankAccount()
			{
				BankAccountNumber = newUser.BankAccountNumber,
				BankAccountBalance = SetBankAccountBalance(),
				User = newUser
			});

			context.Carts.Add(new Cart()
			{
				User = newUser
			});

			context.Users.Add(newUser);
			context.SaveChanges();

			return newUser;
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
	}
}
