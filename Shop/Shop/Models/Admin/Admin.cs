using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Admin
{
	public class Admin
	{
		[Key]
		[Column(TypeName = "varchar(100)")]
		public string Username { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string Password { get; set; }

		[Required]
		[Column(TypeName = "varchar(10)")]
		public string Role { get; private set; } = "Admin";
	}
}
