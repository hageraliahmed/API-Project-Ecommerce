using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Carts;
using Ecommerce.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Orders
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(EcommerceContext context) : base(context)
		{
		}

		

		public void PlaceOrder(List<(int ProductId, int Quantity)> orderItems,string userId)
		{
			/*var userId = "123";*/
			var cart = _context.Set<Cart>()
							   .FirstOrDefault(c => c.UserId == userId);

			if (cart != null)
			{

				// Create a new order
				var order = new Order
			{
				CreationDateTime = DateTime.Now,
				UserId = userId,
				OrderItems = new List<OrderItem>()
			};
				// Add the order to the context and save changes
				_context.Set<Order>().Add(order);


				decimal total = 0;


				// Add order items from the provided list
				foreach (var (productId, quantity) in orderItems)
				{
					var product = _context.Set<Product>().Find(productId);
					if (product != null)
					{
						var orderItem = new OrderItem
						{
							ProductId = productId,
							Quantity = quantity,
							OrderId = order.Id
						};
						order.OrderItems.Add(orderItem);

						
							
						total += quantity * product.Price;
						order.TotalPrice= total;


						_context.SaveChanges();


						// Clear the user's cart
						var cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
						if (cartItem != null)
						{
							cart.CartItems.Remove(cartItem);
							_context.SaveChanges();
						}
					}
				}


			}
			
		}
		///////////////////////////////////////////////////////////////////////////
		public IEnumerable<Order> GetOrdersByUserId(string userId)
		{
			return _context.Set<Order>()
				.Where(o => o.UserId == userId);
		}
	}
}
