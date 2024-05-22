using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Data.Models
{
	public class Product
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

		public Category? Category { get; set; }

        public int CategoryId { get; set; }



        [Column(TypeName = "decimal(10,2)")]

		public decimal Price { get; set; }

        public string Size { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;


		public ICollection<CartItem> CartItems { get; set; } = [];

		public ICollection<OrderItem> OrderItems { get; set; } = [];
	}
}
