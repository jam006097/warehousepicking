using System.ComponentModel.DataAnnotations;

namespace PickingRoute.Models
{
	public class ProductItem
	{
		[Key]
		public int ProductId { get; set; }

		[Required]
		public string ProductName { get; set; } = string.Empty;

		[Required]
		public int strangeLocationX { get; set; }

		[Required]
		public int strangeLocationY { get; set; }
	}
}
