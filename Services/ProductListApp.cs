using Microsoft.EntityFrameworkCore;
using PickingRoute.Data;
using PickingRoute.Models;

namespace PickingRoute.Services
{
	public class ProductListService
	{
		private readonly ApplicationDbContext _context;

		// コンストラクタ
		public ProductListService(ApplicationDbContext context)
		{
			_context = context;
		}

		// 商品一覧を取得
		public async Task<List<ProductItem>> GetProductsAsync()
		{
			var items = await _context.ProductItems.ToListAsync();
			return items;
		}

		// 商品の更新
		public async Task UpdateProductAsync(ProductItem productItemInput)
		{
			var existingProductItem = await _context.ProductItems.FindAsync(productItemInput.ProductId);
			if (existingProductItem != null)
			{
				existingProductItem.ProductName = productItemInput.ProductName;
				existingProductItem.strangeLocationX = productItemInput.strangeLocationX;
				existingProductItem.strangeLocationY = productItemInput.strangeLocationY;
				await _context.SaveChangesAsync();
			}
		}

		// 商品の削除
		public async Task DeleteProductAsync(int id)
		{
			var existingProductItem = await _context.ProductItems.FindAsync(id);
			if (existingProductItem != null)
			{
				_context.ProductItems.Remove(existingProductItem);
				await _context.SaveChangesAsync();
			}
		}

		// 商品の追加
		public async Task AddProductAsync(ProductItem newProductItem)
		{
			_context.ProductItems.Add(newProductItem);
			await _context.SaveChangesAsync();
		}
	}
}
