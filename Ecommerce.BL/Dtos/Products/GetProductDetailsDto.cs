using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Products
{
	public class GetProductDetailsDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public string CategoryName { get; set; } = string.Empty;



		[Column(TypeName = "decimal(10,2)")]

		public decimal Price { get; set; }

		public string Size { get; set; } = string.Empty;

		public string Color { get; set; } = string.Empty;


		
	}
}
