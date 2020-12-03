using Shop.Data;
using Shop.Models.Products;
using Shop.Models.User;
using Shop.ViewModels;
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

		public bool CreateNewProduct(ProductVM product)
		{
			if (DoesProductExists(product.Name))
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

		private bool DoesProductExists(string productName)
		{
			return _shopContext.Products.Any(pn => pn.Name == productName);
		}

		private Product GetProductByProductName(string productName)
		{
			return _shopContext.Products.Find(productName);
		}
	}
}
