using PickingRoute.Models;

namespace PickingRoute.Services
{
	public class RouteCalculator
	{
		/// <summary>
		/// 商品の位置から最も近い通路上の地点を計算します。
		/// </summary>
		/// <param name="product">商品アイテム</param>
		/// <param name="aisle">通路</param>
		/// <returns>最寄りの通路上の地点</returns>
		public static RoutePoint FindNearestPointOnAisle(ProductItem product, WarehousePath aisle)
		{
			// 通路のベクトルを計算
			double dx = aisle.EndX - aisle.StartX;
			double dy = aisle.EndY - aisle.StartY;

			// 通路の端点が同一の場合、例外を投げる
			if (dx == 0 && dy == 0)
			{
				throw new ArgumentException("通路の端点が同一です。");
			}

			// 垂線の足の位置を計算
			double t = ((product.Shelf.X - aisle.StartX) * dx + (product.Shelf.Y - aisle.StartY) * dy) / (dx * dx + dy * dy);

			// 通路の範囲外の場合、端点を返す
			if (t < 0)
			{
				return new RoutePoint { X = aisle.StartX, Y = aisle.StartY };
			}
			else if (t > 1)
			{
				return new RoutePoint { X = aisle.EndX, Y = aisle.EndY };
			}
			else
			{
				// 通路の範囲内の場合、垂線の足の地点を返す
				return new RoutePoint { X = aisle.StartX + t * dx, Y = aisle.StartY + t * dy };
			}
		}

		/// <summary>
		/// 商品に最も近い通路を見つけ、その通路上の最寄りの地点を計算します。
		/// </summary>
		/// <param name="product">商品アイテム</param>
		/// <param name="aisles">通路のリスト</param>
		/// <param name="nearestPoint">最寄りの通路上の地点</param>
		/// <returns>最寄りの通路</returns>
		public static WarehousePath FindNearestAisle(ProductItem product, List<WarehousePath> aisles, out RoutePoint nearestPoint)
		{
			double minDistance = double.MaxValue;
			WarehousePath nearestAisle = null;
			nearestPoint = null;

			foreach (var aisle in aisles)
			{
				var point = FindNearestPointOnAisle(product, aisle);
				double distance = Math.Sqrt(Math.Pow(point.X - product.Shelf.X, 2) + Math.Pow(point.Y - product.Shelf.Y, 2));
				if (distance < minDistance)
				{
					minDistance = distance;
					nearestAisle = aisle;
					nearestPoint = point;
				}
			}

			return nearestAisle;
		}
	}
}
