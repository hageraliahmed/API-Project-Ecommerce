using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.DAL.Data.Models
{
	public class Order
	{
        public int Id { get; set; }
        
        public DateTime CreationDateTime { get; set; }


		public List<OrderItem> OrderItems { get; set; } = [];

		[Column(TypeName = "decimal(10,2)")]
		public decimal TotalPrice {get; set;}

        public User? User { get; set; }

		public string UserId { get; set; } = string.Empty;
    }
}
