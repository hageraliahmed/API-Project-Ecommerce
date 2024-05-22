using Ecommerce.BL.Dtos.Products;
using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Managers.Products
{
	public interface IProductManager
	{
		IEnumerable<GetProductDto> GetAll();
		IEnumerable<GetProductDto> GetByCategory(int categoryId);

		IEnumerable<GetProductDto> GetByName(string name);
		GetProductDetailsDto? GetById(int id);
	}
}
