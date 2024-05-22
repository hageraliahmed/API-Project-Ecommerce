using Ecommerce.BL.Dtos.Products;
using Ecommerce.DAL;
using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Managers.Products
{
	public class ProductManager : IProductManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public IEnumerable<GetProductDto> GetAll()
		{
			var products = _unitOfWork.ProductRepository.GetAll();
			return products
				.Select(p => new GetProductDto
				{
					Id = p.Id,
					Name = p.Name,
					Price=p.Price
				});
		}




		public IEnumerable<GetProductDto> GetByCategory(int categoryId)
		{
			var products = _unitOfWork.ProductRepository.GetByCategory(categoryId);
			if (products is null)
			{
				return null;
			}

			return products
				.Select(p => new GetProductDto
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price
				});
		}




		public GetProductDetailsDto? GetById(int id)
		{
			var product = _unitOfWork.ProductRepository.GetById(id);
			if (product is null)
			{
				return null;
			}

			return new GetProductDetailsDto
			{
				Id = product.Id,
				Name = product.Name,
				CategoryName = product.Category.Name,
				Price = product.Price,
				Size=product.Size,
				Color = product.Color

			};
		}



		public IEnumerable<GetProductDto> GetByName(string name)
		{
			var products = _unitOfWork.ProductRepository.GetByName(name);
			if (products is null)
			{
				return null;
			}

			return products
				.Select(p => new GetProductDto
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price
				});
		}
	}
}
