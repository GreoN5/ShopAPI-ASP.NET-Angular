using Shop.Data;
using Shop.Models.Products;
using Shop.Models.User;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Repositories
{
	public class AdminRepository
	{
		private readonly ShopContext _shopContext;

		public AdminRepository(ShopContext context)
		{
			_shopContext = context;
		}

		public List<User> GetAllUsers()
		{
			return _shopContext.Users.ToList();
		}

		public List<Product> GetAllProducts()
		{
			return _shopContext.Products.ToList();
		}

		public User AddNewUser(UserRegistrationVM newUser)
		{
			if (DoesUsernameAlreadyExists(newUser.Username))
			{
				return new User()
				{
					Username = null,
					Password = newUser.Password,
					EmailAddress = newUser.EmailAddress,
					Address = newUser.Address,
					PhoneNumber = newUser.PhoneNumber,
					BankAccountNumber = newUser.BankAccountNumber
				}; // returns the user with null username
			}

			if (DoesEmailAlreadyExists(newUser.EmailAddress))
			{
				return new User()
				{
					Username = newUser.Username,
					Password = newUser.Password,
					EmailAddress = null,
					Address = newUser.Address,
					PhoneNumber = newUser.PhoneNumber,
					BankAccountNumber = newUser.BankAccountNumber
				}; // returns the user with null email address
			}

			if (DoesBankAccountNumberAlreadyExists(newUser.BankAccountNumber))
			{
				return new User()
				{
					Username = newUser.Username,
					Password = newUser.Password,
					EmailAddress = newUser.EmailAddress,
					Address = newUser.Address,
					PhoneNumber = newUser.PhoneNumber,
					BankAccountNumber = null
				}; // returns the user with null back account
			}

			//if there are no matches for duplicated attributes of the user it will create a complete user and add it to the database
		   User user = new User()
		   {
			   Username = newUser.Username,
			   Password = newUser.Password,
			   EmailAddress = newUser.EmailAddress,
			   Address = newUser.Address,
			   PhoneNumber = newUser.PhoneNumber,
			   BankAccountNumber = newUser.BankAccountNumber
		   };

			_shopContext.BankAccounts.Add(new BankAccount()
			{
				BankAccountNumber = user.BankAccountNumber,
				BankAccountBalance = SetBankAccountBalance(),
				User = user
			});

			_shopContext.Carts.Add(new Cart()
			{
				User = user
			});

			_shopContext.Users.Add(user);
			_shopContext.SaveChanges();

			return user;
		}

		public bool CreateNewProduct(ProductVM product)
		{
			if (DoesProductAlreadyExists(product.Name))
			{
				return false;
			}

			Product newProduct = new Product()
			{
				ID = product.ID,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Quantity = product.Quantity,
				Category = product.Category
			};

			SetProductStatus(newProduct);
			_shopContext.Products.Add(newProduct);
			_shopContext.SaveChanges();

			return true;
		}

		public bool ChangeQuantityOfProduct(string productName, int quantity)
		{
			Product product = GetProductByProductName(productName);

			if (product != null)
			{
				if (quantity > 0)
				{
					product.Quantity = quantity;
					SetProductStatus(product); // sets the new status because the quantity has been changed

					_shopContext.SaveChanges();

					return true;
				}
			}

			return false;
		}

		public bool RemoveProduct(string productName)
		{
			Product product = GetProductByProductName(productName);

			if (product != null)
			{
				_shopContext.Products.Remove(product);
				_shopContext.SaveChanges();

				return true;
			}

			return false;
		}

		private void SetProductStatus(Product product)
		{
			if (product.Quantity == 0)
			{
				product.Status = Status.Unavaible;
			}
			else if (product.Quantity < 10 && product.Quantity > 0)
			{
				product.Status = Status.SmallAmount;
			}
			else
			{
				product.Status = Status.Available;
			}
		}

		private decimal SetBankAccountBalance()
		{
			Random random = new Random();

			return random.Next(100, 5000);
		}

		private bool DoesUsernameAlreadyExists(string username)
		{
			return _shopContext.Users.Any(u => u.Username == username);
		}

		private bool DoesEmailAlreadyExists(string email)
		{
			return _shopContext.Users.Any(u => u.EmailAddress == email);
		}

		private bool DoesBankAccountNumberAlreadyExists(string bankAccountNumber)
		{
			return _shopContext.Users.Any(u => u.BankAccountNumber == bankAccountNumber);
		}

		private bool DoesProductAlreadyExists(string productName)
		{
			return _shopContext.Products.Any(pn => pn.Name == productName);
		}

		private Product GetProductByProductName(string productName)
		{
			return _shopContext.Products.Find(productName);
		}
	}
}
