using Shop.Data;
using Shop.Models.Admin;
using Shop.Models.Products;
using Shop.Models.User;
using Shop.Repositories.UserCheck;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Repositories
{
	public class AdminRepository : UniqueUser
	{
		private readonly ShopContext _shopContext;

		public AdminRepository(ShopContext context) : base()
		{
			_shopContext = context;
		}

		public List<User> ShowAllUsers()
		{
			return _shopContext.Users.ToList();
		}

		public List<Admin> ShowAllAdmins()
		{
			return _shopContext.Admins.ToList();
		}

		public List<Product> ShowAllProducts()
		{
			return _shopContext.Products.ToList();
		}

		public List<Category> ShowAllProductCategories()
		{
			return Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
		}

		public User AddNewUser(UserRegistrationVM newUser)
		{
			if (DoesUsernameAlreadyExists(newUser.Username, _shopContext))
			{
				return GetNewUserWithoutUsername(newUser);
			}

			if (DoesEmailAlreadyExists(newUser.EmailAddress, _shopContext))
			{
				return GetNewUserWithoutEmail(newUser);
			}

			if (DoesBankAccountNumberAlreadyExists(newUser.BankAccountNumber, _shopContext))
			{
				return GetNewUserWithoutBankAccountNumber(newUser);
			}

			//if there are no matches for duplicated attributes of the user it will create a complete user and add it to the database
			return AddUniqueUser(newUser, _shopContext);
		}

		public Admin AddNewAdmin(AdminVM newAdmin)
		{
			if (DoesAdminUsernameAlreadyExists(newAdmin.Username) && DoesUsernameAlreadyExists(newAdmin.Username, _shopContext))
			{
				return new Admin()
				{
					Username = null,
					Password = newAdmin.Password
				};
			}

			Admin admin = new Admin()
			{
				Username = newAdmin.Username,
				Password = newAdmin.Password
			};

			_shopContext.Admins.Add(admin);
			_shopContext.SaveChanges();

			return admin;
		}

		public bool CreateNewProduct(ProductVM product)
		{
			if (DoesProductAlreadyExists(product.Name))
			{
				return false;
			}

			Product newProduct = new Product()
			{
				//ID = product.ID,
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

		public Product GetProduct(int productID)
		{
			return GetProductByID(productID);
		}

		public Product EditProduct(int productID, ProductVM newProduct)
		{
			Product product = GetProductByID(productID);

			if (product != null)
			{
				product.Name = newProduct.Name;
				product.Description = newProduct.Description;
				product.Price = newProduct.Price;
				product.Quantity = newProduct.Quantity;

				SetProductStatus(product);
				_shopContext.SaveChanges();

				return product;
			}

			return null;
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

		public bool RemoveUser(string username)
		{
			User user = GetUser(username);

			if (user != null)
			{
				_shopContext.Users.Remove(user);
				_shopContext.SaveChanges();

				return true;
			}

			return false;
		}

		public bool RemoveAdmin(string username)
		{
			Admin admin = GetAdmin(username);

			if (admin != null)
			{
				_shopContext.Admins.Remove(admin);
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

		private User GetUser(string username)
		{
			return _shopContext.Users.Find(username);
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

		private bool DoesAdminUsernameAlreadyExists(string adminUsername)
		{
			return _shopContext.Admins.Any(a => a.Username == adminUsername);
		}

		private bool DoesProductAlreadyExists(string productName)
		{
			return _shopContext.Products.Any(pn => pn.Name == productName);
		}

		private Product GetProductByProductName(string productName)
		{
			return _shopContext.Products.Find(productName);
		}

		private Product GetProductByID(int productID)
		{
			return _shopContext.Products.Find(productID);
		}

		private Admin GetAdmin(string username)
		{
			return _shopContext.Admins.Find(username);
		}
	}
}
