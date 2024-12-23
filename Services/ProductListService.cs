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
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		// 商品一覧を取得
		public async Task<List<ProductItem>> GetProductsAsync()
		{
			// 関数を実行し、エラーなら例外を投げます
			return await ExecuteWithExceptionHandlingAsync(
				async () => await _context.ProductItems.Include(p => p.Shelf).ToListAsync(), // ラムダ式で関数を渡します。
				"商品の取得に失敗しました。"
			); // 例外時のエラーメッセージ

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
					if (existingProductItem != null)
					{
						existingProductItem.ProductName = productItemInput.ProductName;
						existingProductItem.ShelfId = productItemInput.ShelfId;
						await _context.SaveChangesAsync();
					}
					else
					{
						throw new ProductListServiceException("更新対象の商品が見つかりませんでした。");
					}
				},
				"商品の更新に失敗しました。"
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
					if (existingProductItem != null)
					{
						_context.ProductItems.Remove(existingProductItem);
						await _context.SaveChangesAsync();
					}
					else
					{
						throw new ProductListServiceException("削除対象の商品が見つかりませんでした。");
					}
				},
				"商品の削除に失敗しました。"
			); //例外時のエラーメッセージ
		}

		// 商品の追加
		public async Task AddProductAsync(ProductItem newProductItem)
		{
			if (newProductItem == null)
			{
				throw new ArgumentNullException(nameof(newProductItem));
			}

			// 関数を実行し、エラーなら例外を投げます
			// 特定の型を返さないTaskを返す関数を渡します
			await ExecuteWithExceptionHandlingAsync(
				// ラムダ式で関数を渡します。
				async () =>
				{
					await _context.ProductItems.AddAsync(newProductItem);
					await _context.SaveChangesAsync();
				},
				"商品の追加に失敗しました。"
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
				throw new ProductListServiceException("商品が見つからないか、アクセスが拒否されました。");
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
		// カスタム例外クラス	
		public class ProductListServiceException : Exception
		{
			public ProductListServiceException(string message) : base(message) { }
			public ProductListServiceException(string message, Exception innerException) : base(message, innerException) { }
		}
	}
}
