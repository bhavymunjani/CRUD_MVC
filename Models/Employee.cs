using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
	public class Employee
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string First_Name { get; set; }

		[Required]
		public string Last_Name { get; set; }

		[EmailAddress]
		public string Email { get; set; }
	}
}

