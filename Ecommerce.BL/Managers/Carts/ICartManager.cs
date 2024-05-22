using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Managers.Carts
{
	public interface ICartManager
	{
		void AddToCart(int productId, int quantity, string userId);
		void RemoveFromCart(int productId, string userId);

		void EditCartItemQuantity(int productId, int quantity, string userId);
	}
}
