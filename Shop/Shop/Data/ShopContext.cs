using Microsoft.EntityFrameworkCore;
using Shop.Models.Products;
using Shop.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
	public class ShopContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<BankAccount> BankAccounts { get; set; }

		public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>().Property(u => u.Username).ValueGeneratedNever();
			builder.Entity<BankAccount>().Property(ba => ba.BankAccountNumber).ValueGeneratedNever();
		}
	}
}
