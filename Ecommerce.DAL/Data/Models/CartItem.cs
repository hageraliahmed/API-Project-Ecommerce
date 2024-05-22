using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Data.Models
{
	public class CartItem
	{
		public Product? Product { get; set; }

		public int ProductId { get; set; }
		public int Quantity { get; set; }

		public Cart? Cart { get; set; }

		public int CartId { get; set; }
	}
}
