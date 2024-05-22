using Ecommerce.DAL.Repositories.Carts;
using Ecommerce.DAL.Repositories.Orders;
using Ecommerce.DAL.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
	public interface IUnitOfWork
	{
		public ICartRepository CartRepository { get; }
		public IOrderRepository OrderRepository { get; }
		public IProductRepository ProductRepository { get; }
		void SaveChanges();
	}
}
