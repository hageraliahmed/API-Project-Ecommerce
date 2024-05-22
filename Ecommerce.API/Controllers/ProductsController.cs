using Ecommerce.BL.Dtos.Products;
using Ecommerce.BL.Managers.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductManager _ProductManager;
		

		public ProductsController(IProductManager ProductManager)
		{
			_ProductManager = ProductManager;
			
		}

		//////////////////////////////////////////////////////////////////
		//get all products
		
		[HttpGet]
		public ActionResult<IEnumerable<GetProductDto>> GetAll()
		{
			var products = _ProductManager.GetAll();
			if (products is null)
			{
				return NotFound();
			}
			return products.ToList();
		}
		////////////////////////////////////////////////////////////////////
		//get products by category id 
		[HttpGet]
		[Route("{categoryId}")]
		public ActionResult<IEnumerable<GetProductDto>> GetByCategory(int categoryId)
		{
			var products = _ProductManager.GetByCategory(categoryId);
			if (products is null)
			{
				return NotFound();
			}
			return products.ToList();
		}

		///////////////////////////////////////////////////////////
		//get products by product name
		[HttpGet]
		[Route("{name:alpha}")]
		public ActionResult<IEnumerable<GetProductDto>> GetByName(string name)
		{
			var products = _ProductManager.GetByName(name);
			if (products is null)
			{
				return NotFound();
			}
			return products.ToList();
		}

		//////////////////////////////////////////////////////////
		///get product details by product id 
		[HttpGet]
		[Route("Details/{id}")]
		public ActionResult<GetProductDetailsDto> GetById(int id)
		{
			var product = _ProductManager.GetById(id);
			if (product is null)
			{
				return NotFound();
			}
			return product;
		}
	}
}
