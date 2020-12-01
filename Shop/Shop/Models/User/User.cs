using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.User
{
	public class User
	{
		[Key]
		[Column(TypeName = "varchar(100)")]
		public string Username { get; set; }

		[Column(TypeName = "varchar(50)")]
		public string Password { get; set; }

		[Column(TypeName = "varchar(250)")]
		public string EmailAddress { get; set; }

		[Column(TypeName = "varchar(500)")]
		public string Address { get; set; }

		[Column(TypeName = "varchar(10)")]
		public string PhoneNumber { get; set; }

		[Column(TypeName = "varchar(10)")]
		public string Role { get; set; }

		public BankAccount BankAccount { get; set; }

		public Cart Cart { get; set; }
	}
}
