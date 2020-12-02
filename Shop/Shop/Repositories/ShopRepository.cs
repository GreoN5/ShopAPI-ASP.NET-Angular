using Shop.Data;
using Shop.Models.Products;
using Shop.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories
{
	public class ShopRepository
	{
		private readonly ShopContext _shopContext;

		public ShopRepository(ShopContext context)
		{
			_shopContext = context;
		}

		public List<Product> ShowAllProducts()
		{
			return _shopContext.Products.ToList();
		}

		public List<Category> ShowAllProductCategories()
		{
			return Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
		}

		public List<Product> ShowProductsByCategory(string category)
		{
			if (Enum.TryParse(category, out Category enumCategory))
			{
				switch (enumCategory)
				{
					case Category.Meat:
						{
							return _shopContext.Products.Where(p => p.Category == Category.Meat).ToList();
						}
					case Category.Drinks:
						{
							return _shopContext.Products.Where(p => p.Category == Category.Drinks).ToList();
						}
					case Category.Pizza:
						{
							return _shopContext.Products.Where(p => p.Category == Category.Pizza).ToList();
						}
					case Category.Salad:
						{
							return _shopContext.Products.Where(p => p.Category == Category.Salad).ToList();
						}
					case Category.Sauces:
						{
							return _shopContext.Products.Where(p => p.Category == Category.Sauces).ToList();
						}
					case Category.Dessert:
						{
							return _shopContext.Products.Where(p => p.Category == Category.Dessert).ToList();
						}
					default: return null;
				}
			}

			return null;
		}

		public List<Product> ShowProductsInCart(string username)
		{
			User user = GetUserByUsername(username);

			if (user != null)
			{
				return user.Cart.Products;
			}

			return null;
		}

		public bool AddProductToCart(string username, string productName)
		{
			User user = GetUserByUsername(username);
			Product product = GetProductByProductName(productName);

			if (user == null || product == null)
			{
				return false;
			}

			user.Cart.Products.Add(product);
			return true;
		}

		public bool RemoveProductFromCart(string username, string productName)
		{
			User user = GetUserByUsername(username);
			Product product = GetProductByProductName(productName);

			if (user == null || product == null)
			{
				return false;
			}

			user.Cart.Products.Remove(product);
			return true;
		}

		public bool ChangeQuantityOfProduct(string username, string productName, int quantity)
		{
			User user = GetUserByUsername(username);
			Product product = GetProductByProductName(productName);

			if (user == null || product == null)
			{
				return false;
			}

			if (user.Cart.Products.Contains(product))
			{
				product.Quantity = quantity;
				return true;
			}

			return false;
		}

		public decimal GetFinalPrice(string username)
		{
			User user = GetUserByUsername(username);

			if (user == null)
			{
				return -1;
			}

			for (int i = 0; i < user.Cart.Products.Count; i++)
			{
				user.Cart.FinalPrice += user.Cart.Products[i].Price;
			}

			return user.Cart.FinalPrice;
		}

		public bool ClearCart(string username)
		{
			User user = GetUserByUsername(username);

			if (user == null)
			{
				return false;
			}

			user.Cart.Products.Clear();
			user.Cart.FinalPrice = 0;

			return true;
		}

		private User GetUserByUsername(string username)
		{
			return _shopContext.Users.Find(username);
		}

		private Product GetProductByProductName(string productName)
		{
			return _shopContext.Products.Find(productName);
		}
	}
}
