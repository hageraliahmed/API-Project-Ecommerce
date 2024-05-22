using Ecommerce.BL.Dtos.Orders;
using Ecommerce.BL.Dtos.Products;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Managers.Orders
{
	public class OrderManager : IOrderManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public IEnumerable<ViewOrderHistoryDto> GetOrdersByUserId(string userId)
		{
			var orders = _unitOfWork.OrderRepository.GetOrdersByUserId(userId);
			return orders
				.Select(o => new ViewOrderHistoryDto
				{
					Id = o.Id,
					CreationDateTime = o.CreationDateTime,
					TotalPrice = o.TotalPrice
				});
		}

		public void PlaceOrder(List<PlaceOrderDto> placeOrderDtoList, string userId)
		{
			List<(int ProductId, int Quantity)> orderItems = placeOrderDtoList
			.Select(dto => (dto.ProductId, dto.Quantity))
			.ToList();

			_unitOfWork.OrderRepository.PlaceOrder(orderItems, userId);
			_unitOfWork.SaveChanges();
		}

		
	}
}
