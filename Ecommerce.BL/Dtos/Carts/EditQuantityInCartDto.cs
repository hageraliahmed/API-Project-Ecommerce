using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Carts
{
	public class EditQuantityInCartDto
	{
		public int ProductId { get; set; }


		public int Quantity { get; set; }
	}
}
