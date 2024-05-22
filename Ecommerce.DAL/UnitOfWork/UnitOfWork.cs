using Ecommerce.DAL.Data.Context;
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
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(ICartRepository cartRepository, IOrderRepository orderRepository , IProductRepository productRepository, EcommerceContext context)
		{
			CartRepository = cartRepository;
			OrderRepository = orderRepository;
			ProductRepository = productRepository;
			_context = context;
		}

		private readonly EcommerceContext _context;
		public ICartRepository CartRepository { get; }

		public IOrderRepository OrderRepository { get; }

		public IProductRepository ProductRepository { get; }

	   public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
