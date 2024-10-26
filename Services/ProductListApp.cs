using Microsoft.EntityFrameworkCore;
using PickingRoute.Data;
using PickingRoute.Models;

namespace PickingRoute.Services
{
	public class ProductListService
	{
		private readonly ApplicationDbContext _context;

		public ProductListService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<ProductItem>> GetProductAsync()
		{
			var items = await _context.ProductItems.ToListAsync();
			return items;
		}
	}
}
