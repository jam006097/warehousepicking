namespace PickingRoute.Services
{
	// ProductListAppクラスからの例外を受け取ります。
	public class ProductListServiceException : Exception
	{
		//　例外のメッセージを受け取るコンストラクタ
		public ProductListServiceException(string message) : base(message) { }
		// 例外のメッセージと種類を受け取るコンストラクタ
		public ProductListServiceException(string message, Exception inner) : base(message, inner) { }
	}
}
