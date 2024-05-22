using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Products
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(EcommerceContext context) : base(context)
		{
		}

		public IEnumerable<Product> GetByCategory(int categoryId)
		{
			return _context.Set<Product>()
				.Where(p => p.CategoryId == categoryId);
		}

		public Product? GetById(int id)
		{
			return _context.Set<Product>()
				.Include(p => p.Category)
				.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<Product> GetByName(string name)
		{
			return _context.Set<Product>()
				.Where(p => p.Name == name);
		}
	}
}
