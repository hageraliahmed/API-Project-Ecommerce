using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Orders
{
	public class ViewOrderHistoryDto
	{
		public int Id { get; set; }

		public DateTime CreationDateTime { get; set; }


		

		[Column(TypeName = "decimal(10,2)")]
		public decimal TotalPrice { get; set; }

	}
}
