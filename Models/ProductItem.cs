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
}
