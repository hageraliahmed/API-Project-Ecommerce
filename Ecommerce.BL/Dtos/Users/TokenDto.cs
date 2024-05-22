using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Users
{
	public record TokenDto(string Token, DateTime Expiry);
}
