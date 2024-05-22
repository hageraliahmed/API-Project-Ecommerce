using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Products
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		IEnumerable<Product> GetByCategory(int categoryId);

		IEnumerable<Product> GetByName(string name);
		Product? GetById(int id);


	}
}
