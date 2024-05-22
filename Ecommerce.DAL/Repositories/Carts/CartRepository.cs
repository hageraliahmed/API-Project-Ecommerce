using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic;
using Ecommerce.DAL.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Carts
{
	public class CartRepository : GenericRepository<Cart>, ICartRepository
	{
		public CartRepository(EcommerceContext context) : base(context)
		{
		}



		public void AddToCart(int productId, int quantity, string userId)
		{
			// Retrieve the user's cart based on the logged-in user's ID
			/*var userId = "123";*/    // Replace with the actual user ID or retrieve it from the authentication system
			var cart = _context.Set<Cart>()
							   .FirstOrDefault(c => c.UserId == userId);

			if (cart == null)
			{
				// Create a new cart if it doesn't exist for the user
				cart = new Cart
				{
					UserId = userId,
					CartItems = new List<CartItem>()
				};
				_context.Set<Cart>().Add(cart);
			}

			var product = _context.Products.Find(productId);

			if (product != null)
			{
				var cartItem = _context.Set<CartItem>().FirstOrDefault(item => item.CartId == cart.Id && item.ProductId == productId);

				if (cartItem != null)
				{
					// If the cart already contains the product, increase its quantity
					cartItem.Quantity += quantity;
				}

				else
				{
					// Create a new cart item based on the provided productId and quantity
					var newCartItem = new CartItem
					{
						ProductId = productId,
						Quantity = quantity,
						CartId = cart.Id
					};

					cart.CartItems.Add(newCartItem);
				}
				// Save changes to the database
				_context.SaveChanges();
			}
		}

		////////////////////////////////////////////////////////////////////////
		public void RemoveFromCart(int productId, string userId)
		{
			/*var userId = "123";*/
			var cart = _context.Set<Cart>()
							   .FirstOrDefault(c => c.UserId == userId);

			if (cart != null)
			{
				var cartItem = _context.Set<CartItem>().FirstOrDefault(item =>item.CartId==cart.Id&& item.ProductId == productId);
				if (cartItem != null)
				{
					_context.Set<CartItem>().Remove(cartItem);
					_context.SaveChanges();
				}
			}

		}

		///////////////////////////////////////////////////////////////////////////
		public void EditCartItemQuantity(int productId, int quantity,string userId)
		{
			/*var userId = "123";*/
			var cart = _context.Set<Cart>()
							   .FirstOrDefault(c => c.UserId == userId);

			if (cart != null)
			{
				var cartItem = _context.Set<CartItem>().FirstOrDefault(item => item.CartId == cart.Id && item.ProductId == productId);
				if (cartItem != null)
				{

					cartItem.Quantity=quantity;

					_context.SaveChanges();
				}
			}
		}
}
}
