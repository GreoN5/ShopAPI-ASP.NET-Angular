using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.User
{
	public class BankAccount
	{
		[Key]
		public string BankAccountNumber { get; set; }

		[Column(TypeName = "decimal(10, 2)")]
		public decimal BankAccountBalance { get; set; }
	}
}
