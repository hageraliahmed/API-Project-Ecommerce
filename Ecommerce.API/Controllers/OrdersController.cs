using Ecommerce.BL.Dtos.Orders;
using Ecommerce.BL.Dtos.Products;
using Ecommerce.BL.Managers.Carts;
using Ecommerce.BL.Managers.Orders;
using Ecommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{

		private readonly IOrderManager _OrderManager;
		private readonly UserManager<User> _userManager;

		public OrdersController(IOrderManager OrderManager, UserManager<User> userManager)
		{
			_OrderManager = OrderManager;
			_userManager = userManager;

		}

		///////////////////////////////////////////////////////////
		[Authorize]
		[HttpGet]
		
		public async Task<ActionResult<IEnumerable<ViewOrderHistoryDto>>> GetOrdersByUserId()
		{
			User? user = await _userManager.GetUserAsync(User);

			var orders = _OrderManager.GetOrdersByUserId(user.Id);
			if (orders is null)
			{
				return NotFound();
			}
			return orders.ToList();
		}

		//////////////////////////////////////////////////////////////

		[Authorize]
		[HttpPost]

		public async Task<ActionResult> PlaceOrder(List<PlaceOrderDto> placeOrderDtoList)
		{
			User? user = await _userManager.GetUserAsync(User);


			 _OrderManager.PlaceOrder(placeOrderDtoList, user.Id);
			
			return Ok("place order done");
		}

		//the body request of this end point : 
		  /*[
		  {
			"productId": 1,
			"quantity": 5
		  },
		  {
			"productId": 2,
			"quantity": 6
		  },
		  {
			"productId": 3,
			"quantity": 9
		  }
		]*/
	}
}
