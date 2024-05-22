using Ecommerce.BL.Dtos.Carts;
using Ecommerce.BL.Managers.Carts;
using Ecommerce.BL.Managers.Products;
using Ecommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartsController : ControllerBase
	{
		private readonly ICartManager _CartManager;
		private readonly UserManager<User> _userManager;

		public CartsController(ICartManager CartManager, UserManager<User> userManager)
		{
			_CartManager = CartManager;
			_userManager = userManager;

		}

		/////////////////////////////////////////////////////////////////
		[Authorize]
		[HttpPost]
		public async Task<ActionResult> AddToCart(AddToCartDto addToCartDto)
		{
			User? user = await _userManager.GetUserAsync(User);   //get the current user

			_CartManager.AddToCart(addToCartDto.ProductId, addToCartDto.Quantity,user.Id);

			return Ok("product is added to cart");

		}

		///////////////////////////////////////////////////////////////
		[Authorize]
		[HttpDelete]
		[Route("{productId}")]
		public async Task<ActionResult> RemoveFromCart(int productId)
		{
			User? user = await _userManager.GetUserAsync(User);   
			_CartManager.RemoveFromCart(productId,user.Id);
			return Ok("product is removed from cart");
		}

		///////////////////////////////////////////////////////
		[Authorize]
		[HttpPut]
		public async Task<ActionResult> EditCartItemQuantity(EditQuantityInCartDto editQuantityInCartDto)
		{
			User? user = await _userManager.GetUserAsync(User);
			_CartManager.EditCartItemQuantity(editQuantityInCartDto.ProductId, editQuantityInCartDto.Quantity,user.Id);
			return Ok("product quantity is updated");
		}
	}
}
