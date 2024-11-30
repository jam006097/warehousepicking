using System.ComponentModel.DataAnnotations;

namespace PickingRoute.Models
{
	public class ProductItem
	{
		[Key]
		public int ProductId { get; set; }

		// 商品名
		[Required(ErrorMessage = "ProductName is required.")]
		[StringLength(10, ErrorMessage = "ProductName must be less than 10 characters.")]
		public string ProductName { get; set; } = string.Empty;

		// X座標
		[Required(ErrorMessage = "LocationX is required.")]
		public int strangeLocationX { get; set; }

		// Y座標
		[Required(ErrorMessage = "LocationY is required.")]
		public int strangeLocationY { get; set; }
	}

	public class Shelf
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public double X { get; set; }
		public double Y { get; set; }
		public double Width { get; set; } = 50; // デフォルトの幅を設定
		public double Height { get; set; } = 50; // デフォルトの高さを設定

	}

}
