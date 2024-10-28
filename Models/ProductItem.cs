using System.ComponentModel.DataAnnotations;

namespace PickingRoute.Models
{
	public class ProductItem
	{
		[Key]
		public int ProductId { get; set; }

		[Required(ErrorMessage = "ProductName is required.")]
		[StringLength(10, ErrorMessage = "ProductName must be less than 10 characters.")]
		public string ProductName { get; set; } = string.Empty;

		[Required(ErrorMessage = "StrangeLocationX is required.")]
		public int strangeLocationX { get; set; }

		[Required(ErrorMessage = "StrangeLocationY is required.")]
		public int strangeLocationY { get; set; }
	}
}
