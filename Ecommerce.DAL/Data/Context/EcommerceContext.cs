using Ecommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ecommerce.DAL.Data.Context
{
	public class EcommerceContext : IdentityDbContext<User>
	{
		
		public DbSet<Product> Products => Set<Product>();

		public DbSet<Category> Categories => Set<Category>();
		public DbSet<Cart> Carts => Set<Cart>();

		public DbSet<OrderItem> OrderItems => Set<OrderItem>();

		public DbSet<CartItem> CartItems => Set<CartItem>();
		public DbSet<Order> Orders => Set<Order>();


		public EcommerceContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<OrderItem>()
			.HasKey(o => new { o.ProductId, o.OrderId });


			modelBuilder.Entity<CartItem>()
			.HasKey(c => new { c.ProductId, c.CartId });


			modelBuilder.Entity<OrderItem>()
			.HasOne(item => item.Order)
			.WithMany(order => order.OrderItems)
			.HasForeignKey(item => item.OrderId);


			modelBuilder.Entity<CartItem>()
			.HasOne(item => item.Cart)
			.WithMany(cart => cart.CartItems)
			.HasForeignKey(item => item.CartId);



			modelBuilder.Entity<Cart>()
				.HasOne(c => c.User)
				.WithOne(u => u.Cart);

			modelBuilder.Entity<Order>()
				.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.UserId);

			modelBuilder.Entity<Product>()
				.HasOne(p => p.Category)
				.WithMany(c => c.Products)
				.HasForeignKey(p => p.CategoryId);


			modelBuilder.Entity<CartItem>()
				.HasOne(c => c.Product)
				.WithMany(p => p.CartItems)
				.HasForeignKey(c => c.ProductId);

			modelBuilder.Entity<OrderItem>()
				.HasOne(o => o.Product)
				.WithMany(p => p.OrderItems)
				.HasForeignKey(o => o.ProductId);

			#region Seeding

			#region Seeding categories

			var categories = new List<Category>
			{
				  new Category {Id= 1,Name= "modern"},
				  new Category {Id= 2,Name= "classic"}

				};

			#endregion


			#region Seeding Products

			var products = new List<Product>
			{
				  new Product {Id= 1,Name= "blouse",CategoryId=1,Price=1000,Size="Small",Color="Red"},
				  new Product {Id= 2,Name= "skirt",CategoryId=1,Price=500,Size="large",Color="green"},
				  new Product {Id= 3,Name= "dress",CategoryId=1,Price=3000,Size="medium",Color="blue"},
				};

			#endregion

			


			/*#region Seeding cart

			var carts = new List<Cart> {
				new Cart
			{
				Id = 1,
				CartItems = new List<CartItem>
					{
						new CartItem
						{
							ProductId=1,
							Quantity = 15,
							CartId=1
						},

					}
			},
			new Cart
			{
				Id = 2,
				CartItems = new List<CartItem>
					{
						new CartItem
						{
							ProductId=1,
							Quantity = 20,
							CartId=2
						},

					}
			}

			};


			#endregion*/

			/*#region Seeding Orders
			var orders = new List<Order> {
				new Order
			{
				Id = 1,
				CreationDateTime=new DateTime(2010,3,28),
				OrderItems = new List<OrderItem>
					{
						new OrderItem
						{
							ProductId=1,
							Quantity = 15,
							OrderId=1
						},

					}
			},
			new Order
			{
				Id = 2,
				CreationDateTime=new DateTime(2010,3,28),
				OrderItems = new List<OrderItem>
					{
						new OrderItem
						{
							ProductId=1,
							Quantity = 30,
							OrderId=2
						},

					}
			}

			};
			#endregion*/


			modelBuilder.Entity<Product>().HasData(products);
			modelBuilder.Entity<Category>().HasData(categories);

			
			#endregion
		}
	}
}
