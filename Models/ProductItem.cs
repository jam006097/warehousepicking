using System.ComponentModel.DataAnnotations;

namespace PickingRoute.Models
{
	/// <summary>
	/// 商品のプロパティ
	/// </summary>
	public class ProductItem
	{
		[Key]
		public int ProductId { get; set; }

		// 商品名
		[Required(ErrorMessage = "ProductName is required.")]
		[StringLength(10, ErrorMessage = "ProductName must be less than 10 characters.")]
		public string ProductName { get; set; } = string.Empty;

		//　棚のID
		[Required(ErrorMessage = "ShelfId is required.")]
		public int ShelfId { get; set; }

		// 棚への参照
		public virtual Shelf Shelf { get; set; }
	}

	/// <summary>
	/// 倉庫のプロパティ
	/// </summary>
	public class Shelf
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public double X { get; set; }
		public double Y { get; set; }
		public double Width { get; set; } = 50; // デフォルトの幅を設定
		public double Height { get; set; } = 50; // デフォルトの高さを設定

		// 商品リスト
		public virtual ICollection<ProductItem> ProductItems { get; set; }

	}

	/// <summary>
	/// 通路のプロパティ
	/// </summary>
	public class WarehousePath
	{
		public int Id { get; set; }
		public double StartX { get; set; }
		public double StartY { get; set; }
		public double EndX { get; set; }
		public double EndY { get; set; }
	}

}
