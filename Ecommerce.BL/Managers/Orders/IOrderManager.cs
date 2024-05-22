using Ecommerce.BL.Dtos.Orders;
using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Managers.Orders
{
	public interface IOrderManager
	{
		IEnumerable<ViewOrderHistoryDto> GetOrdersByUserId(string userId);
		void PlaceOrder(List<PlaceOrderDto> placeOrderDtoList, string userId);
	}
}
