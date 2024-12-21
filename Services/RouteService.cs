using System.Collections.Generic; 
using PickingRoute.Models;

namespace PickingRoute.Services
{
	public class RouteService
	{
		public List<RoutePoint> Routes { get; set; } = new List<RoutePoint>();
		public List<ProductItem> optimalItems { get; set; } = new List<ProductItem>();
		public List<ProductItem> PickingItems { get; set; } = new List<ProductItem>(); 
	}
}
