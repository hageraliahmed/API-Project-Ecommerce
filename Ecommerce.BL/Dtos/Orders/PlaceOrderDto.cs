using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Orders
{
	public class PlaceOrderDto
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}

	
}
