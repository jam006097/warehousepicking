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
			// 関数を実行し、エラーなら例外を投げます
			return await ExecuteWithExceptionHandlingAsync(
				async () => await _context.ProductItems.Include(p => p.Shelf).ToListAsync(), // ラムダ式で関数を渡します。
				"Failed to retrieve product items."
			);　// 例外時のエラーメッセージ

		}

		// 商品の更新
		public async Task UpdateProductAsync(ProductItem productItemInput)
		{
			// 関数を実行し、エラーなら例外を投げます
			await ExecuteWithExceptionHandlingAsync(
				// ラムダ式で関数を渡します。
				async () =>
				{
					var existingProductItem = await GetProductItemAsyncFromID(productItemInput.ProductId);
					existingProductItem.ProductName = productItemInput.ProductName;
					existingProductItem.ShelfId = productItemInput.ShelfId;
					await _context.SaveChangesAsync();
				},
				"Failed to Update product item."
			); // 例外時のエラーメッセージ
		}

		// 商品の削除
		public async Task DeleteProductAsync(int productId)
		{
			// 関数を実行し、エラーなら例外を投げます
			await ExecuteWithExceptionHandlingAsync(
				// ラムダ式で関数を渡します。
				async () =>
				{
					var existingProductItem = await GetProductItemAsyncFromID(productId);
					_context.ProductItems.Remove(existingProductItem);
					await _context.SaveChangesAsync();
				},
				"Failed to delete product item."
			); //例外時のエラーメッセージ
		}

		// 商品の追加
		public async Task AddProductAsync(ProductItem newProductItem)
		{
			// 関数を実行し、エラーなら例外を投げます
			// 特定の型を返さないTaskを返す関数を渡します
			await ExecuteWithExceptionHandlingAsync(
				// ラムダ式で関数を渡します。
				async () =>
				{
					_context.ProductItems.Add(newProductItem);
					await _context.SaveChangesAsync();
				},
				"Failed to add product item."
			); //例外時のエラーメッセージ
		}

		// productIDから商品一覧を取得します
		// 例外が発生した場合、カスタム例外をスローします。
		private async Task<ProductItem> GetProductItemAsyncFromID(int productId)
		{
			var productItem = await _context.ProductItems.Include(p => p.Shelf).FirstOrDefaultAsync(p => p.ProductId == productId);
			// 商品一覧を取得出来なかった場合、カスタム例外をスローします
			if (productItem == null) 
			{
				throw new ProductListServiceException("Product item not found or access denied.");
			}
			return productItem;
		}


		// 指定された関数を実行し、例外が発生した場合にカスタム例外をスローします
		// 任意の型TのTaskを返す関数を受け取ります。
		private async Task<T> ExecuteWithExceptionHandlingAsync<T>(Func<Task<T>> func, string errorMessage)
		{
			try
			{
				return await func();
			}
			catch (Exception ex) 
			{
				throw new ProductListServiceException(errorMessage, ex);
			}
		}

		// 指定された関数を実行し、例外が発生した場合にカスタム例外をスローします
		// 特定の型を返さないTaskを返す関数を受け取ります。
		// 例えば、単にデータベースに変更を保存するTaskのような関数を受け取ります。
		private async Task ExecuteWithExceptionHandlingAsync(Func<Task> func, string errorMessage)
		{
			try
			{
				await func();
			}
			catch (Exception ex) 
			{
				throw new ProductListServiceException(errorMessage, ex);
			}
		}

	}
}
