using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Orders
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
		void PlaceOrder(List<(int ProductId, int Quantity)> orderItems,string userId);

		IEnumerable<Order> GetOrdersByUserId(string userId);     //View orders history
	}
}
