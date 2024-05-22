using Ecommerce.DAL;
using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Managers.Carts
{
	public class CartManager : ICartManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public CartManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public void AddToCart(int productId, int quantity, string userId)
		{
		    _unitOfWork.CartRepository.AddToCart(productId, quantity,userId);
			_unitOfWork.SaveChanges();
			
		}

		public void EditCartItemQuantity(int productId, int quantity, string userId)
		{
			_unitOfWork.CartRepository.EditCartItemQuantity(productId, quantity,userId);
			_unitOfWork.SaveChanges();
		}

		public void RemoveFromCart(int productId, string userId)
		{
			_unitOfWork.CartRepository.RemoveFromCart(productId,userId);
			_unitOfWork.SaveChanges();
		}
	}
}
