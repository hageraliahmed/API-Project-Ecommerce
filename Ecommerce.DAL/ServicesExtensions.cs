using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Repositories.Carts;
using Ecommerce.DAL.Repositories.Orders;
using Ecommerce.DAL.Repositories.Products;
using Ecommerce.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
	public static class ServicesExtensions
	{
		public static void AddDALServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("EcommerceDB");
			services.AddDbContext<EcommerceContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddScoped<ICartRepository, CartRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}
	}
}
