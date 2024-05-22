using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Carts
{
	public interface ICartRepository : IGenericRepository<Cart>
	{
		 void AddToCart(int productId, int quantity, string userId);
		void RemoveFromCart(int productId, string userId);

		void EditCartItemQuantity(int productId, int quantity, string userId);
	}
}
